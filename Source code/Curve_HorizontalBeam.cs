using System.Windows.Forms;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// A class to create th B1 horizontal beams in the model
    /// </summary>
    public class Curve_HorizontalBeam
    {
        /// <summary>
        /// The constructor of the class to insert B1 horizontal curve beams in the model
        /// </summary>
        /// <param name="modelParameters">A class storing the parameters of the model</param>
        /// <returns></returns>
        public static (PolyBeam, PolyBeam, PolyBeam, PolyBeam) CurveHorizontalBeams
            (
            ModelParameters modelParameters
            )
        {

            /* Figure 1. Representation of a single plane of the frame box (side view).
                   ________
            Beam4 |        | Beam3
                  |        |
                  |        |  front 
                  |        |
                  |        |
                  |________|
            Beam2            Beam1
                bottom
    
            */

            // Create the B1 Horizontal Beams
            // Create the enums and the offsets for the b1 beams
            int[] b1Enums = { 2, 1, 0 };
            double[] b1Offsets = { 0.0, 0.0, 0.0 };

            // Basic Bill Board Properties
            double ScreenLength = modelParameters.ScreenLength;
            double ScreenHeight = modelParameters.ScreenHeight;
            double B1BeamDepth = modelParameters.B1BeamDepth;
            double HeightOffsetBottom = modelParameters.HeightOffsetBottom;
            double HeightOffsetTop = modelParameters.HeightOffsetTop;

            // Radius of the Front Circle 1
            double FrontCircle_1 = modelParameters.Radius;

            // Radius of the Back Circle 1
            double BackCircle_1 = modelParameters.Radius - modelParameters.B1BeamDepth - modelParameters.Distance;
            PolyBeam B1Beam1;
            PolyBeam B1Beam2;
            PolyBeam B1Beam3;
            PolyBeam B1Beam4;

            B1Beam1 = CurveSupport.CurveBeam("M", "A", "B1",
                new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(0, FrontCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, FrontCircle_1, modelParameters), FrontCircle_1, modelParameters), 0 - HeightOffsetBottom), null), 
                new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength / 2, FrontCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength / 2, FrontCircle_1, modelParameters), FrontCircle_1, modelParameters), 0 - HeightOffsetBottom), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT)), 
                new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_1, modelParameters), FrontCircle_1, modelParameters), 0 - HeightOffsetBottom), null),
                modelParameters.B1Material,
                modelParameters.B1Profile, 
                "11",
                b1Enums,
                b1Offsets);

            B1Beam2 = CurveSupport.CurveBeam("M", "A", "B1",
                new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(0, BackCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, BackCircle_1, modelParameters), BackCircle_1, modelParameters), 0 - HeightOffsetBottom), null), 
                new ContourPoint(new TSG.Point(ScreenLength / 2, CurveSupport.Circle_Ycoord(ScreenLength / 2, BackCircle_1, modelParameters), 0 - HeightOffsetBottom), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT)), 
                new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_1, modelParameters), BackCircle_1, modelParameters), 0 - HeightOffsetBottom), null),
                modelParameters.B1Material,
                modelParameters.B1Profile,
                "11",
                b1Enums,
                b1Offsets);

            B1Beam3 = CurveSupport.CurveBeam("M", "A", "B1",
                new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(0, FrontCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, FrontCircle_1, modelParameters), FrontCircle_1, modelParameters), ScreenHeight + HeightOffsetTop + B1BeamDepth), null), 
                new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength / 2, FrontCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength / 2, FrontCircle_1, modelParameters), FrontCircle_1, modelParameters), ScreenHeight + HeightOffsetTop + B1BeamDepth), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT)), 
                new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_1, modelParameters), FrontCircle_1, modelParameters), ScreenHeight + HeightOffsetTop + B1BeamDepth), null),
                modelParameters.B1Material,
                modelParameters.B1Profile,
                "11",
                b1Enums,
                b1Offsets);

            B1Beam4 = CurveSupport.CurveBeam("M", "A", "B1",
                new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(0, BackCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, BackCircle_1, modelParameters), BackCircle_1, modelParameters), ScreenHeight + HeightOffsetTop + B1BeamDepth), null), 
                new ContourPoint(new TSG.Point(ScreenLength / 2, CurveSupport.Circle_Ycoord(ScreenLength / 2, BackCircle_1, modelParameters), ScreenHeight + HeightOffsetTop + B1BeamDepth), new Chamfer(0, 0, Chamfer.ChamferTypeEnum.CHAMFER_ARC_POINT)), 
                new ContourPoint(new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_1, modelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_1, modelParameters), BackCircle_1, modelParameters), ScreenHeight + HeightOffsetTop + B1BeamDepth), null),
                modelParameters.B1Material,
                modelParameters.B1Profile,
                "11",
                b1Enums,
                b1Offsets);

            return (B1Beam1, B1Beam2, B1Beam3, B1Beam4);
        }
    }
}