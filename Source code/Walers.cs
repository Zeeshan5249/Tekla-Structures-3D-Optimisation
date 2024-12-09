using System;
using System.Collections.Generic;
using Tekla.Structures.Datatype;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Class to model waler beams in Tekla Structures.
    /// </summary>
    public class Waler
    {
        /// <summary>
        /// Method to construct waler beams for a row of boxes, based on a list of Z-coordinates.
        /// </summary>
        /// <param name="walerZcoordinate">List of Z-coordinates to create walers</param>
        /// <param name="side2">True if the left side of the box (facing the front of the screens) is a split point, false if it is the left side of the full billboard</param>
        /// <param name="side4">True if the right side of the box is a split point</param>
        /// <param name="OriginOffset">Origin point of the current box</param>
        /// <param name="modelParameters">Tekla model parameters</param>
        /// TODO add return description. //TODO Remove return
        public static List<Beam> Walers
            (
                List<double> walerZcoordinate,
                bool side2,
                bool side4,
                double boxZStart,
                double boxZEnd,
                TSG.Point OriginOffset,
                ModelParameters modelParameters
            )
        {
            double C1BeamWidth = modelParameters.C1BeamWidth;
            double BillboardDepth = modelParameters.BillboardDepth;


            TSG.Point startOffset = new TSG.Point();
            TSG.Point endOffset = new TSG.Point();

           // if (!side2)
           // {
                startOffset.X = - C1BeamWidth / 2;
           // }
          //  if (!side4)
           // {
                endOffset.X = C1BeamWidth / 2;
          //  }

            // Set the enums for the walers
            int[] walerEnums = new int[] { 2, 2, 0 };
            double[] walerOffsets = new double[] { 0.0, 0.0, 90 };

            List<Beam> Walers = new List<Beam>();

            foreach (double walerZ in walerZcoordinate)
            {
                Prefix.name = "WALER";
                // Create the bottom waler
                Beam bottomWaler = Box.CreateBeam(Prefix.part,"W",
                    new TSG.Point(0, BillboardDepth, walerZ) + OriginOffset + startOffset,
                    new TSG.Point(modelParameters.ScreenLength, BillboardDepth, walerZ) + OriginOffset + endOffset,
                    modelParameters.WalerMaterial,
                    modelParameters.WalerProfile,
                    "3",
                    walerEnums, 
                    walerOffsets
                    );
                Prefix.name = "BEAM";

                Walers.Add(bottomWaler);
            }

            return Walers;
        }

        /// <summary>
        /// Method to construct curve waler beams for a row of boxes, based on a list of Z-coordinates.
        /// </summary>
        /// <param name="walerZcoordinate">List of Z-coordinates to create walers</param>
        /// <param name="modelParameters">Tekla model parameters</param>
        /// TODO add return description. //TODO Remove return
        public static List<PolyBeam> Walers_Curve (List<double> walerZcoordinate,
                ModelParameters modelParameters)
        {
            double ScreenLength = modelParameters.ScreenLength;

            // Radius of the Back Circle 2
            double BackCircle_2 = modelParameters.Radius - (2 * modelParameters.B1BeamDepth) - modelParameters.Distance;

            // Set the enums for the walers
            int[] walerEnums = new int[] { 2, 2, 0 };
            double[] walerOffsets = new double[] { 0.0, 0.0, 90 };

            List<PolyBeam> Walers = new List<PolyBeam>();

            foreach (double walerZ in walerZcoordinate)
            {
                ContourPoint BPoint3 = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(0, BackCircle_2, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, BackCircle_2, modelParameters), BackCircle_2, modelParameters), walerZ), null);
                ContourPoint BMid3_4 = new ContourPoint(new TSG.Point(ScreenLength / 2, CurveSupport.Circle_Ycoord(ScreenLength / 2, BackCircle_2, modelParameters), walerZ), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT));
                ContourPoint BPoint4 = new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_2, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_2, modelParameters), BackCircle_2, modelParameters), walerZ), null);

                // Create the bottom waler
                PolyBeam bottomWaler = CurveSupport.CurveBeam("M", "W", "WALER", BPoint3, BMid3_4, BPoint4, modelParameters.WalerMaterial, modelParameters.WalerProfile, "3", walerEnums, walerOffsets);

                Walers.Add(bottomWaler);
            }

            return Walers;
        }
    }
}
