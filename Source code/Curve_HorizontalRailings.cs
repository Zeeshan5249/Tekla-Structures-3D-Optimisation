using System;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// A Class which contains functions/methods for building the horizontal railings.
    /// </summary>
    public class Curve_HorizontalRailings
    {
        /// <summary>
        /// Constructor to create horizontal railings and Side Bracings.
        /// </summary>
        /// <param name="modelParameters"></param>
        /// <returns> List of Beam and PolyBeam objects created </returns>
        public static (List<Beam>, List<PolyBeam>) CurveHorizontalRailings (ModelParameters modelParameters )
        {
            List<Beam> SideBracings = new List<Beam>();
            List<PolyBeam> HorizontalRailings = new List<PolyBeam>();

            // Basic BillBoard Properties
            double ScreenLength = modelParameters.ScreenLength;

            // Create the enums and the offsets for the right side bracings
            int[] RightSideEnums = { 2, 2, 0 }; 
            double[] RightSideOffsets = { 0, 0, 0 };

            // Create the enums and the offsets for the left side bracings
            int[] LeftSideEnums = { 2, 1, 0 }; 
            double[] LeftSideOffsets = { 0, 0, 0 };

            // Create the enums and the offsets for the horizontal railings
            int[] HorizontalRailingEnums = { 0, 2, 0 }; 
            double[] HorizontalRailingOffsets = { 0, 0, 0 };

            // Radius of the Front Circle 2
            double FrontCircle_2 = modelParameters.Radius - modelParameters.B1BeamDepth;

            // Radius of the Back Circle 1
            double BackCircle_1 = modelParameters.Radius - modelParameters.B1BeamDepth - modelParameters.Distance;

            // Radius of the Back Circle 2
            double BackCircle_2 = modelParameters.Radius - (2 * modelParameters.B1BeamDepth) - modelParameters.Distance;

            // Creating the Zcoordinates and X coordinates lists
            List<double> Zcoords = CurveSupport.HorizontalRailings_Points(modelParameters);
            List<(double, double)> Xcoords = CurveSupport.IndividualRailings_PointsPair(modelParameters);

            (double first, double last) = Xcoords[Xcoords.Count - 1];
            Xcoords[Xcoords.Count - 1] = (first, last - modelParameters.C1BeamWidth);

            // Iterating over all possible Zcoords
            foreach (var Zcoord in Zcoords)
            {
                // RightSideBracings
                ContourPoint Front_RSB = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(0, FrontCircle_2, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, FrontCircle_2, modelParameters), FrontCircle_2, modelParameters), Zcoord), null);
                ContourPoint Back_RSB = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(0, BackCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, BackCircle_1, modelParameters), BackCircle_1, modelParameters), Zcoord), null);

                // LeftSideBracings
                ContourPoint Front_LSB = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_2, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_2, modelParameters), FrontCircle_2, modelParameters), Zcoord), null);
                ContourPoint Back_LSB = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_1, modelParameters), BackCircle_1, modelParameters), Zcoord), null);

                Beam RightSideBracings = CurveSupport.StraightBeam("M", "A", "B3", Front_RSB, Back_RSB, modelParameters.B3Material, modelParameters.B3Profile, "5", RightSideEnums, RightSideOffsets);
                Beam LeftSideBracings = CurveSupport.StraightBeam("M", "A", "B3", Front_LSB, Back_LSB, modelParameters.B3Material, modelParameters.B3Profile, "5", LeftSideEnums, LeftSideOffsets);

                SideBracings.Add(RightSideBracings);
                SideBracings.Add(LeftSideBracings);

                // Iterating over all possible Xcoords pairs to create individual sections
                foreach (var RailingPairs in Xcoords)
                {
                    // Horizontal Railings Points
                    double Xcoords_starts = RailingPairs.Item1;
                    double Xcoord_ends = RailingPairs.Item2;
                    double Xcoords_midPoint = (Xcoords_starts + Xcoord_ends) / 2;
                    
                    ContourPoint Startpos = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(Xcoords_starts, BackCircle_2, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(Xcoords_starts, BackCircle_2, modelParameters), BackCircle_2, modelParameters), Zcoord), null);
                    ContourPoint Midpos = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(Xcoords_midPoint, BackCircle_2, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(Xcoords_midPoint, BackCircle_2, modelParameters), BackCircle_2, modelParameters), Zcoord), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
                    ContourPoint Endpos = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(Xcoord_ends, BackCircle_2, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(Xcoord_ends, BackCircle_2, modelParameters), BackCircle_2, modelParameters), Zcoord), null);

                    PolyBeam BackHorizontalRailings = CurveSupport.CurveBeam("M", "A", "B3", Startpos, Midpos, Endpos, modelParameters.B3Material, modelParameters.B3Profile, "5", HorizontalRailingEnums, HorizontalRailingOffsets);

                    HorizontalRailings.Add(BackHorizontalRailings);
                }
            }

            return (SideBracings, HorizontalRailings);
        }
    }
}
