using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TSD = Tekla.Structures.Datatype;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Class to support modeling of diagonal bracings in Tekla Structures.
    /// </summary>
    public class CurveDiagonal
    {
        /// <summary>
        /// The constructor for a diagonal bracing, generating a diagonl beam in the model
        /// </summary>
        /// <param name="modelParameters">The parameters of the model</param>
        /// 
        /// <returns> A list of Beam objects created </returns>
        public static (List<Beam>, List<Beam>, List<Beam>, List<Beam>) DiagonalBracing(ModelParameters modelParameters)
        {
            List<Beam> TopDiagonalBRACING = new List<Beam>();
            List<Beam> LeftDiagonalBRACING = new List<Beam>();
            List<Beam> RightDiagonalBRACING = new List<Beam>();
            List<Beam> BottomDiagonalBRACING = new List<Beam>();

            // Basic BillBoard Property
            double WeldOffset = modelParameters.WeldOffset;
            double B3WidthOffset = modelParameters.B3BeamWidth;
            double BottomHeight = 0 - modelParameters.HeightOffsetBottom;
            double TopHeight = modelParameters.ScreenHeight + modelParameters.HeightOffsetTop + modelParameters.B1BeamDepth;

            // Create the enums and the offsets for the right, top, and bottom diagonal bracings 
            int[] Enums = { 2, 2, 2 }; 
            double[] Offsets = { 0, 0, 0 };

            // Create the enums and the offsets for the Left diagonal bracings
            int[] LeftSideEnums = { 2, 1, 2 }; 
            double[] LeftSideOffsets = { 0, 0, 0 };

            // Radius of the Front Circle 3
            double FrontCircle_3 = modelParameters.Radius - modelParameters.B1BeamDepth - 10;

            // Radius of the Front Circle 4
            double FrontCircle_4 = modelParameters.Radius - modelParameters.B1BeamDepth - 50;

            // Radius of the Back Circle 1
            double BackCircle_1 = modelParameters.Radius - modelParameters.B1BeamDepth - modelParameters.Distance;

            // Radius of the Back Circle 3
            double FrontCircle_5 = modelParameters.Radius - modelParameters.B1BeamDepth - 75;

            // Creating the Zcoordinates and X coordinates lists
            List<double> Zcoords = CurveSupport.HorizontalRailings_Points(modelParameters);
            List<double> Xcoords = CurveSupport.GetCumulativeSum(modelParameters.XCoordinates);

            // Adding the Start and End points to Zcoords
            Zcoords.Add(BottomHeight);
            Zcoords.Add(TopHeight - 15);
            Zcoords.Sort();

            // Inserting the Left and Right Side Bracings
            for (int i = 0; i < Zcoords.Count - 1; i++)
            {
                // Right Diagonal BRACING
                ContourPoint FPoint1B = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(0, FrontCircle_5, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, FrontCircle_5, modelParameters), FrontCircle_5, modelParameters), Zcoords[i + 1] - B3WidthOffset - WeldOffset), null);
                ContourPoint BPoint2 = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(0, BackCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, BackCircle_1, modelParameters), BackCircle_1, modelParameters), (Zcoords[i] + WeldOffset)), null);

                Beam RightBRACING = CreateDiagonalBeam("M", "A", "C1", FPoint1B, BPoint2, modelParameters.B3Material, modelParameters.B3Profile, "7", Enums, Offsets);

                // Left Diagonal BRACING
                ContourPoint Point1B = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(modelParameters.ScreenLength, FrontCircle_5, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(modelParameters.ScreenLength, FrontCircle_5, modelParameters), FrontCircle_5, modelParameters), Zcoords[i + 1] - B3WidthOffset - WeldOffset), null);
                ContourPoint Point2 = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(modelParameters.ScreenLength, BackCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(modelParameters.ScreenLength, BackCircle_1, modelParameters), BackCircle_1, modelParameters), (Zcoords[i] + WeldOffset)), null);

                Beam LeftBRACING = CreateDiagonalBeam("M", "A", "C1", Point1B, Point2, modelParameters.B3Material, modelParameters.B3Profile, "7", LeftSideEnums, LeftSideOffsets);

                RightDiagonalBRACING.Add(RightBRACING);
                LeftDiagonalBRACING.Add(LeftBRACING);
            }
            
            // Adding the Start and End points to Xcoords
            Xcoords.Add(0 + 15);
            Xcoords.Add(modelParameters.ScreenLength - 50);
            Xcoords.Sort();

            // Inserting the Top and Bottom Side Bracings
            for (int i = 0; i < Xcoords.Count - 1; i++)
            {
                // Top Diagonal BRACING
                ContourPoint Point1 = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(Xcoords[i] + 50, FrontCircle_4, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(Xcoords[i] + 50, FrontCircle_4, modelParameters), FrontCircle_4, modelParameters), TopHeight), null);
                ContourPoint Point2 = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(Xcoords[i + 1] - 15, BackCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(Xcoords[i + 1] - 15, BackCircle_1, modelParameters), BackCircle_1, modelParameters), TopHeight), null);

                Beam TopBRACING = CurveSupport.StraightBeam("M", "A", "C1", Point1, Point2, modelParameters.B3Material, modelParameters.B3Profile, "7", Enums, Offsets);

                // Bottom Diagonal BRACING
                ContourPoint BPoint1 = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(Xcoords[i] + 50, FrontCircle_4, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(Xcoords[i] + 50, FrontCircle_4, modelParameters), FrontCircle_4, modelParameters), BottomHeight), null);
                ContourPoint BPoint2 = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(Xcoords[i + 1] - 15, BackCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(Xcoords[i + 1] - 15, BackCircle_1, modelParameters), BackCircle_1, modelParameters), BottomHeight), null);

                Beam BottomBRACING = CurveSupport.StraightBeam("M", "A", "C1", BPoint1, BPoint2, modelParameters.B3Material, modelParameters.B3Profile, "7", Enums, Offsets);

                TopDiagonalBRACING.Add(TopBRACING);
                BottomDiagonalBRACING.Add(BottomBRACING);
            }

            // Inserting CameraArm 
            new CameraArm("SHS75*75*4.0", "C350L0", modelParameters);

            return (TopDiagonalBRACING, LeftDiagonalBRACING, RightDiagonalBRACING, BottomDiagonalBRACING);
        }

        /// <summary>
        /// Method to create a beam model on Tekla Structures with Fittings.
        /// </summary>
        /// <param name="partprefix"> The part prefix as string
        /// <param name="assprefix"> The part prefix as string
        /// <param name="name"> The name of the beam
        /// <param name="startPos"> 3D coordinates of the beam's starting point (mm)</param>
        /// <param name="endPos"> 3D coordinates of the beam's ending point (mm)</param>
        /// <param name="material"> The beam's material</param>
        /// <param name="profile"> The beam's profile</param>
        /// <param name="beamClass"> The beam's class e.g. beamClass : "1" </param>
        /// <param name="enums"> Array in the form [Position.DepthEnum, Position.PlaneEnum, Position.RotationEnum] </param>
        /// <param name="offsets"> A list of doubles, indicating the offsets of the beams</param>
        /// <returns>Returns a created and inserted beam </returns>
        private static Beam CreateDiagonalBeam(string partprefix, string assprefix, string name, TSG.Point startPos, TSG.Point endPos, string material, string profile, string beamClass, int[] enums, double[] offsets)
        {
            // Beam properties
            Beam beam = new Beam(startPos, endPos)
            {
                PartNumber = new NumberingSeries(partprefix, 1),
                AssemblyNumber = new NumberingSeries(assprefix, 1),
                Name = name
            };

            beam.Profile.ProfileString = profile;
            beam.Material.MaterialString = material;

            // Depth position - First element in the array : 0 - Middle, 1 - Front, 2 - Back
            beam.Position.Depth = (Position.DepthEnum)enums[0];
            beam.Position.DepthOffset = offsets[0];

            // Plane position - Second element in the array : 0 - Middle, 1 - Left, 2 - Right
            beam.Position.Plane = (Position.PlaneEnum)enums[1];
            beam.Position.PlaneOffset = offsets[1];

            // Rotation position - Third element in the array : 0 - Front, 1 - Top, 2 - Back, 3 - Below
            beam.Position.Rotation = (Position.RotationEnum)enums[2];
            beam.Position.RotationOffset = offsets[2];

            beam.Class = beamClass;

            if (!beam.Insert())
            {
                Console.WriteLine("Insertion of beam " + name + " failed.");
            }

            // Adding Fitting to the Right side of the beam (At the startPos Coord)
            Fitting RightSide = new Fitting
            {
                Plane = new Plane
                {
                    Origin = startPos,
                    AxisX = new TSG.Vector(0, 1, 0),
                    AxisY = new TSG.Vector(-1, 0, 0)
                },

                Father = beam
            };
            RightSide.Insert();

            // Adding Fitting to the Left side of the beam (At the endPos Coord)
            Fitting LeftSide = new Fitting
            {
                Plane = new Plane
                {
                    Origin = endPos,
                    AxisX = new TSG.Vector(0, 1, 0),
                    AxisY = new TSG.Vector(-1, 0, 0)
                },

                Father = beam
            };
            LeftSide.Insert();

            return beam;
        }
    }
}