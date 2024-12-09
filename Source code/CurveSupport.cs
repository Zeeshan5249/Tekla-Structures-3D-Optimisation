using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;
using System;

namespace TeklaBillboardAid
{
    public class CurveSupport
    {
        /// <summary>
        /// Method to create a beam model on Tekla Structures.
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
        /// <returns>Returns a created and inserted beam</returns>
        public static Beam StraightBeam(string partprefix, string assprefix, string name, TSG.Point startPos, TSG.Point endPos, string material, string profile, string beamClass, int[] enums, double[] offsets)
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

            if (!beam.Insert()) { Console.WriteLine("Insertion of beam " + name + " failed."); }
            return beam;
        }

        /// <summary>
        /// Method to create a curve polybeam model on Tekla Structures.
        /// </summary>
        /// <param name="partprefix"> The part prefix as string
        /// <param name="assprefix"> The part prefix as string
        /// <param name="name"> The name of the polybeam
        /// <param name="startPos"> 3D coordinates of the polybeam's starting point (mm)</param>
        /// <param name="endPos"> 3D coordinates of the polybeam's ending point (mm)</param>
        /// <param name="material"> The polybeam's material</param>
        /// <param name="profile"> The polybeam's profile</param>
        /// <param name="beamClass"> The polybeam's class e.g. polybeamClass : "1" </param>
        /// <param name="enums"> Array in the form [Position.DepthEnum, Position.PlaneEnum, Position.RotationEnum] </param>
        /// <param name="offsets"> A list of doubles, indicating the offsets of the polybeam</param>
        /// <returns>Returns a created and inserted polybeam</returns>
        public static PolyBeam CurveBeam(string partprefix, string assprefix, string name, ContourPoint startPos, ContourPoint midPos, ContourPoint endPos, string material, string profile, string beamClass, int[] enums, double[] offsets)
        {
            // PolyBeam properties
            PolyBeam polyBeam = new PolyBeam(PolyBeam.PolyBeamTypeEnum.BEAM);

            polyBeam.AddContourPoint(startPos);
            polyBeam.AddContourPoint(midPos);
            polyBeam.AddContourPoint(endPos);

            polyBeam.PartNumber = new NumberingSeries(partprefix, 1);
            polyBeam.AssemblyNumber = new NumberingSeries(assprefix, 1);
            polyBeam.Name = name;

            polyBeam.Profile.ProfileString = profile;
            polyBeam.Material.MaterialString = material;

            // Depth position - First element in the array : 0 - Middle, 1 - Front, 2 - Back
            polyBeam.Position.Depth = (Position.DepthEnum)enums[0];
            polyBeam.Position.DepthOffset = offsets[0];

            // Plane position - Second element in the array : 0 - Middle, 1 - Left, 2 - Right
            polyBeam.Position.Plane = (Position.PlaneEnum)enums[1];
            polyBeam.Position.PlaneOffset = offsets[1];

            // Rotation position - Third element in the array : 0 - Front, 1 - Top, 2 - Back, 3 - Below
            polyBeam.Position.Rotation = (Position.RotationEnum)enums[2];
            polyBeam.Position.RotationOffset = offsets[2];

            polyBeam.Class = beamClass;

            if (!polyBeam.Insert()) { Console.WriteLine("Insertion of polyBeam " + name + " failed."); }
            return polyBeam;
        }

        /// <summary>
        /// A function to calculate y coordinate of a point on a circle
        /// </summary>
        /// <param name="X_coord">A double indicating the x coordinate of the point</param>
        /// <param name="Circle_Radius">A double indicating the radius of the circle</param>
        /// <param name="modelParameters">A class storing the parameters of the model</param>
        /// <returns>a double indicating the y coodinate of the point on a circle</returns>
        public static double Circle_Ycoord(double X_coord, double Circle_Radius, ModelParameters modelParameters)
        {
            double Radius = modelParameters.Radius;
            double Width = modelParameters.ScreenLength;

            double Ycoord = -Math.Sqrt(Math.Pow(Circle_Radius, 2) - Math.Pow(X_coord - (Width / 2), 2))
                            + Math.Sqrt(Math.Pow(Radius, 2) - (Math.Pow(Width, 2) / 4));
            return Ycoord;
        }
        
        /// <summary>
        /// A function to calculate x coordinate of a point on a circle that previously exist on a straight line
        /// </summary>
        /// <param name="X_coord">A double indicating the x coordinate of the point previously on a line</param>
        /// <param name="Circle_Radius">A double indicating the radius of the circle</param>
        /// <param name="modelParameters">A class storing the parameters of the model</param>
        /// <returns>a double indicating the x coodinate of the point on a circle</returns>
        public static double Circle_Xcoord(double X_coord, double Circle_Radius, ModelParameters modelParameters)
        {
            double Radius = modelParameters.Radius;
            double Width = modelParameters.ScreenLength;
            double Angle = Math.Asin((-(Width / 2) + X_coord) / Radius);

            double Xcoord = ((Width * Math.Pow(Math.Tan(Angle), 2)) + Width + 2 * Circle_Radius * Math.Tan(Angle) * Math.Sqrt(Math.Pow(Math.Tan(Angle), 2) + 1))
                            / (2 * (Math.Pow(Math.Tan(Angle), 2) + 1));
            return Xcoord;
        }

        /// <summary>
        /// A function to calculate cumulative sum from individual list of seperate value 
        /// </summary>
        /// <param name="List">A list of individual values</param>
        /// <returns>a list of cumulative sum of all individual value</returns>
        public static List<double> GetCumulativeSum(List<double> List)
        {
            double sum = 0;
            List<double> cumulativeSumList = new List<double>();

            for (int i = 1; i < List.Count - 1; i++)
            {
                sum += List[i];
                cumulativeSumList.Add(sum);
            }

            return cumulativeSumList;
        }

        /// <summary>
        /// A function to create a list of points where the horizontal railings should be created.
        /// </summary>
        /// <param name="modelParameters">A class storing the parameters of the model</param>
        /// <returns>a list of z coordinates for the horizontal railings</returns>
        public static List<double> HorizontalRailings_Points(ModelParameters modelParameters)
        {

            double KneeRailing_Height = modelParameters.RailingSpace1;
            double HandRailing_Height = modelParameters.RailingSpace2;
            double TrimmerDistance = modelParameters.TrimmerDistance;
            double Actual_HandRailing_Height = KneeRailing_Height + HandRailing_Height;
            double TopHeightLimit = modelParameters.ScreenHeight + modelParameters.HeightOffsetTop + modelParameters.B1BeamDepth;

            List<double> Zcoord_List = new List<double>
            {
                KneeRailing_Height,
                Actual_HandRailing_Height
            };

            double currentPoint = Actual_HandRailing_Height;

            while (currentPoint + TrimmerDistance < TopHeightLimit)
            {
                currentPoint += TrimmerDistance;
                Zcoord_List.Add(currentPoint);
            }

            return Zcoord_List;
        }

        /// <summary>
        /// A function to calculate pair of x coordinates for a horizontal railing
        /// </summary>
        /// <param name="modelParameters">A class storing the parameters of the model</param>
        /// <returns>a list consisting of pairs of x coordinates for horizontal railing</returns>
        public static List<(double, double)> IndividualRailings_PointsPair(ModelParameters modelParameters)
        {
            double C1BeamWidth = modelParameters.C1BeamWidth;
            double WeldingGap = modelParameters.BoxGap;

            List<(double, double)> Xcoord_PairList = new List<(double, double)>();

            List<double> Xcoord_List = CurveSupport.GetCumulativeSum(modelParameters.XCoordinates);

            // Adding the Start and End points to the list and sorting it in assending order
            Xcoord_List.Add(0);
            Xcoord_List.Add(modelParameters.ScreenLength);
            Xcoord_List.Sort();

            for (int i = 0; i < Xcoord_List.Count - 1; i++)
            {
                double Right_Xcoord = Xcoord_List[i] + C1BeamWidth + WeldingGap;
                double Left_Xcoord = Xcoord_List[i + 1] - WeldingGap;

                Xcoord_PairList.Add((Right_Xcoord, Left_Xcoord));
            }

            return Xcoord_PairList;
        }
    }
}
