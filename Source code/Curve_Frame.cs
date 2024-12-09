using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Class to support modeling of the major structural components of the billboard frame in Tekla Structures.
    /// </summary>
    public class Curve_Frame
    {
        /// <value>
        /// The point coordinate for the bottom-right corner of the plate (mm)
        /// </value>
        public TSG.Point Point1 { get; set; }

        /// <value>
        /// The point coordinate for the bottom-left corner of the plate (mm)
        /// </value>
        public TSG.Point Point2 { get; set; }

        /// <value>
        /// The point coordinate for the top-left corner of the plate (mm)
        /// </value>
        public TSG.Point Point3 { get; set; }

        /// <value>
        /// The point coordinate for the top-right corner of the plate (mm)
        /// </value>
        public TSG.Point Point4 { get; set; }

        /// <value>
        /// Integer representation for the plane position: 0 = first plane, 1 = last plane, 2 = planes in between the first and last planes
        /// </value>
        public int PlaneType { get; set; }

        /// <value>
        /// The front beam between points 1 and 4
        /// </value>
        public Beam Front { get; set; }

        /// <value>
        /// The back beam between points 2 and 3
        /// </value>
        public Beam Back { get; set; }

        /// <value>
        /// The top beam between points 3 and 4
        /// </value>
        public Beam Top { get; set; }

        /// <value>
        /// The bottom beam between points 1 and 2
        /// </value>
        public Beam Bottom { get; set; }

        /// <value>
        /// The seating plate below the LED cabinets
        /// </value>
        public ContourPlate Seatplate { get; set; }

        /// <value>
        /// The model parameters data store
        /// </value>
        public ModelParameters ModelParameters { get; set; }

        /// <value>
        /// A boolean which is true if the seating plate is ment to be on the right hand side of the front beam
        /// </value>
        public bool SeatingPlateRight { get; set; }

        /// <value>
        /// This is a polybeam part, it's used to cut the front beams
        /// </value>
        public PolyBeam CutBeamBottom { get; set; }

        /// <value>
        /// This is a polybeam part, it's used to cut the front beams
        /// </value>
        public PolyBeam CutBeamTop { get; set; }

        /// <value>
        /// Boolean parameter. If true means that there's a split on side 1.
        /// </value>
        public bool Side1 { get; set; }

        /// <value>
        /// Boolean parameter. If true means that there's a split on side 3.
        /// </value>
        public bool Side3 { get; set; }

        /// <value>
        /// A list of the B2Beams, used to booleanpart cut the flashings if they overlap.
        /// </value>
        public List<Beam> B2Beams { get; set; }

        /// <value>
        ///
        /// </value>
        public bool EnableTopBeam { get; set; }

        /// <value>
        ///
        /// </value>
        public bool EnableBottomBeam { get; set; }

        /// <summary>
        /// The Frame class contains functions for building the frame.
        /// </summary>
        /// <param name="seatingPlateRight"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="point3"></param>
        /// <param name="point4"></param>
        /// <param name="planeType"></param>
        /// <param name="side1"></param>
        /// <param name="side3"></param>
        /// <param name="ModelParameters"></param>
        /// <param name="cutbeambottom"></param>
        /// <param name="cutbeamtop"></param>
        public Curve_Frame (bool seatingPlateRight, TSG.Point point1, TSG.Point point2, TSG.Point point3, TSG.Point point4, int planeType, bool side1, bool side3, ModelParameters ModelParameters, PolyBeam cutbeambottom, PolyBeam cutbeamtop, bool EnableTopBeam = true, bool EnableBottomBeam = true)
        {
            this.SeatingPlateRight = seatingPlateRight;
            this.Seatplate = null;
            this.Point1 = point1;
            this.Point2 = point2;
            this.Point3 = point3;
            this.Point4 = point4;
            this.PlaneType = planeType;
            this.ModelParameters = ModelParameters;
            this.CutBeamBottom = cutbeambottom;
            this.CutBeamTop = cutbeamtop;
            this.EnableTopBeam = EnableTopBeam;
            this.EnableBottomBeam = EnableBottomBeam;
            this.Side1 = side1;
            this.Side3 = side3;
            this.B2Beams = new List<Beam>();
            this.Top = null;
            this.Bottom = null;
            this.Front = null;
            this.Back = null;
            BuildFrame();
        }

        /* Figure 1. Representation of a single plane of the frame box (side view).
           ________
        3 |        | 4
          |        |
          |        |  front 
          |        |
          |        |
          |________|
        2            1
            bottom
    
        */

        /// <summary>
        /// Method to build the frame, using member variables set in the constructor
        /// </summary>
        private void BuildFrame()
        {
            // Basic Bill Board Property
            double ScreenHeight = ModelParameters.ScreenHeight;
            double Radius = ModelParameters.Radius;
            double ScreenLength = ModelParameters.ScreenLength;
            double HeightOffsetBottom = ModelParameters.HeightOffsetBottom;
            double HeightOffsetTop = ModelParameters.HeightOffsetTop;

            // Z axis Offsets
            TSG.Point WeldOffsetZ = new TSG.Point(0, 0, ModelParameters.WeldOffset);
            TSG.Point B1DepthOffsetZ = new TSG.Point(0, 0, ModelParameters.B1BeamDepth);

            // FRONT VERTICAL BEAMS (Points 1-4) /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Initialise FRONT dimension profile
            double[] frontDimensions = ModelParameters.BeamDimensions(ModelParameters.C1Profile);

            // Radius of the Front Circle 1
            double FrontCircle_1 = ModelParameters.Radius;

            // Radius of the Front Circle 2
            double FrontCircle_2 = ModelParameters.Radius - ModelParameters.B1BeamDepth;

            // Radius of the Back Circle 1
            double BackCircle_1 = ModelParameters.Radius - ModelParameters.B1BeamDepth - ModelParameters.Distance;

            // Plane == 1 -> First Plane
            // Plane == 2 -> Last Plane
            // Plane == 3 -> Middle Plane.

            // First plane
            if (PlaneType == 1)
            {
                // Move the model's origin in the positive x direction origin by half front beam width.
                TSG.Point frontOffsetX = new TSG.Point(0, 0, 0);

                // Move the model's origin in the positive y direction by half the front beam depth.
                TSG.Point frontOffsetY = new TSG.Point(0, 0.5 * frontDimensions[0], 0);
                
                TSG.Point ColumnPoint = Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ;

                // Tilt angle for the Vertical beams in radian
                double TiltAngle = Math.Atan((ScreenLength / 2) / Math.Sqrt(Math.Pow(Radius, 2) - Math.Pow(ScreenLength, 2) / 4)) * 180 / Math.PI;

                // Beam Position parameters
                int[] Y_AxisEnums = { 2, 2, 2 }; double[] Y_AxisOffsets = { 0, 0, 0 };
                int[] Z_AxisEnums = { 2, 1, 2 }; double[] Z_AxisOffsets = { 0, 0, -TiltAngle };

                // Creating the Points needed for the Front Vertical Beams
                TSG.Point Point_1 = new TSG.Point(CurveSupport.Circle_Xcoord(0, FrontCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, FrontCircle_1, ModelParameters), FrontCircle_1, ModelParameters), 0 - HeightOffsetBottom);
                TSG.Point Point_4 = new TSG.Point(CurveSupport.Circle_Xcoord(0, FrontCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, FrontCircle_1, ModelParameters), FrontCircle_1, ModelParameters), ScreenHeight + HeightOffsetTop);

                // Creating the Points needed for the Back Vertical Beams
                TSG.Point Point_2 = new TSG.Point(CurveSupport.Circle_Xcoord(0, BackCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, BackCircle_1, ModelParameters), BackCircle_1, ModelParameters), 0 - HeightOffsetBottom);
                TSG.Point Point_3 = new TSG.Point(CurveSupport.Circle_Xcoord(0, BackCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, BackCircle_1, ModelParameters), BackCircle_1, ModelParameters), ScreenHeight + HeightOffsetTop);

                // Creating the Points needed for the Top and Bottom Vertical Beams. The _Back corrosponds to the Front points - B1BeamDepth
                TSG.Point Point_1_Back = new TSG.Point(CurveSupport.Circle_Xcoord(0, FrontCircle_2, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, FrontCircle_2, ModelParameters), FrontCircle_2, ModelParameters), 0 - HeightOffsetBottom);
                TSG.Point Point_4_Back = new TSG.Point(CurveSupport.Circle_Xcoord(0, FrontCircle_2, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(0, FrontCircle_2, ModelParameters), FrontCircle_2, ModelParameters), ScreenHeight + HeightOffsetTop);

                // CREATE Front Beam
                Front = CurveSupport.StraightBeam("M", "A", "C1", Point_1 + WeldOffsetZ, Point_4 - WeldOffsetZ, ModelParameters.C1Material, ModelParameters.C1Profile, "2", Z_AxisEnums, Z_AxisOffsets);

                // Bottom Beam
                if (EnableBottomBeam)
                {
                    Bottom = CurveSupport.StraightBeam("M", "A", "B5", Point_1_Back, Point_2, ModelParameters.B5Material, ModelParameters.B5Profile, "4", Y_AxisEnums, Y_AxisOffsets);
                }

                // CREATE the TOP beam if enabled
                if (EnableTopBeam)
                {
                    Top = CurveSupport.StraightBeam("M", "A", "B5", Point_4_Back + B1DepthOffsetZ, Point_3 + B1DepthOffsetZ, ModelParameters.B5Material, ModelParameters.B5Profile, "4", Y_AxisEnums, Y_AxisOffsets);
                }

                // CREATE back beam
                Back = CurveSupport.StraightBeam("M", "A", "C1", Point_2 + WeldOffsetZ, Point_3 - WeldOffsetZ, ModelParameters.C1Material, ModelParameters.C1Profile, "2", Z_AxisEnums, Z_AxisOffsets);

                // Create Seating Plates
                if (ModelParameters.BuildSeatingPlate && !Side1)
                {
                    Seatplate = CreateSeatingPlate(
                        ColumnPoint + new TSG.Point(frontDimensions[1] / 2 + ModelParameters.SeatingPlateOffset + (65.0 / 2), 0, 0),
                        frontDimensions,
                        ModelParameters,
                        true);
                }
            }
            // Last Plane
            else if (PlaneType == 2)
            {
                // Move the model's origin in the positive x direction origin by half front beam width.
                TSG.Point frontOffsetX = new TSG.Point(0, 0, 0);

                // Move the model's origin in the positive y direction by half the front beam depth.
                TSG.Point frontOffsetY = new TSG.Point(0, 0.5 * frontDimensions[0], 0);
                
                TSG.Point ColumnPoint = Side1 ? Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ - new TSG.Point(0, 0, ModelParameters.B1BeamDepth) : Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ;

                // Tilt angle for the Vertical beams in radian
                double TiltAngle = Math.Atan((ScreenLength / 2) / Math.Sqrt(Math.Pow(Radius, 2) - Math.Pow(ScreenLength, 2) / 4)) * 180 / Math.PI;

                // Beam Position parameters
                int[] Y_AxisEnums = { 2, 1, 0 }; double[] Y_AxisOffsets = { 0, 0, 0 };
                int[] Z_AxisEnums = { 1, 1, 2 }; double[] Z_AxisOffsets = { 0, 0, TiltAngle };

                // Creating the Points needed for the Front Vertical Beams
                TSG.Point Point_1 = new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_1, ModelParameters), FrontCircle_1, ModelParameters), 0 - HeightOffsetBottom);
                TSG.Point Point_4 = new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_1, ModelParameters), FrontCircle_1, ModelParameters), ScreenHeight + HeightOffsetTop);

                // Creating the Points needed for the Back Vertical Beams
                TSG.Point Point_2 = new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_1, ModelParameters), BackCircle_1, ModelParameters), 0 - HeightOffsetBottom);
                TSG.Point Point_3 = new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, BackCircle_1, ModelParameters), BackCircle_1, ModelParameters), ScreenHeight + HeightOffsetTop);

                // Creating the Points needed for the Top and Bottom Vertical Beams. The _Back corrosponds to the Front points - B1BeamDepth
                TSG.Point Point_1_Back = new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_2, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_2, ModelParameters), FrontCircle_2, ModelParameters), 0 - HeightOffsetBottom);
                TSG.Point Point_4_Back = new TSG.Point(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_2, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ScreenLength, FrontCircle_2, ModelParameters), FrontCircle_2, ModelParameters), ScreenHeight + HeightOffsetTop);

                // CREATE Front Beam
                Front = CurveSupport.StraightBeam("M", "A", "C1", Point_1 + WeldOffsetZ, Point_4 - WeldOffsetZ, ModelParameters.C1Material, ModelParameters.C1Profile, "2", Z_AxisEnums, Z_AxisOffsets);

                // Bottom Beam
                if (EnableBottomBeam)
                {
                    Bottom = CurveSupport.StraightBeam("M", "A", "B5", Point_1_Back, Point_2, ModelParameters.B5Material, ModelParameters.B5Profile, "4", Y_AxisEnums, Y_AxisOffsets);
                }

                // CREATE the TOP beam if enabled
                if (EnableTopBeam)
                {
                    Top = CurveSupport.StraightBeam("M", "A", "B5", Point_4_Back + B1DepthOffsetZ, Point_3 + B1DepthOffsetZ, ModelParameters.B5Material, ModelParameters.B5Profile, "4", Y_AxisEnums, Y_AxisOffsets);
                }

                // CREATE back beam
                Back = CurveSupport.StraightBeam("M", "A", "C1", Point_2 + WeldOffsetZ, Point_3 - WeldOffsetZ, ModelParameters.C1Material, ModelParameters.C1Profile, "2", Z_AxisEnums, Z_AxisOffsets);

                // Create Seating Plate
                if (ModelParameters.BuildSeatingPlate && !Side1)
                {
                    Seatplate = CreateSeatingPlate(
                        ColumnPoint - new TSG.Point((frontDimensions[1] / 2) + ModelParameters.SeatingPlateOffset + (65.0 / 2), 0, 0),
                        frontDimensions,
                        ModelParameters, true);
                }
            }
            // Middle Plane
            else if (PlaneType == 3)
            {
                // Move the model's origin in the positive x direction origin by half front beam width.
                TSG.Point frontOffsetX = new TSG.Point(0, 0, 0);

                // Move the model's origin in the positive y direction by half the front beam depth.
                TSG.Point frontOffsetY = new TSG.Point(0, 0.5 * frontDimensions[0], 0);

                TSG.Point ColumnPoint = Side1 ? Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ - new TSG.Point(0,0,ModelParameters.B1BeamDepth) : Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ;

                // Tilt angle for the Vertical beams in radian
                double TiltAngle = Math.Asin((-(ScreenLength / 2) + ColumnPoint.X) / Radius) * 180 / Math.PI;

                // Beam Position parameters
                int[] Y_AxisEnums = { 2, 1, 0 }; double[] Y_AxisOffsets = { 0, -ModelParameters.C1BeamWidth, 0 };
                int[] Z_AxisEnums = { 2, 1, 2 }; double[] Z_AxisOffsets = { 0, 0, TiltAngle };

                // Creating the Points needed for the Front Vertical Beams
                TSG.Point Point_1 = new TSG.Point(CurveSupport.Circle_Xcoord(ColumnPoint.X, FrontCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ColumnPoint.X, FrontCircle_1, ModelParameters), FrontCircle_1, ModelParameters), 0 - HeightOffsetBottom);
                TSG.Point Point_4 = new TSG.Point(CurveSupport.Circle_Xcoord(ColumnPoint.X, FrontCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ColumnPoint.X, FrontCircle_1, ModelParameters), FrontCircle_1, ModelParameters), ScreenHeight + HeightOffsetTop);

                // Creating the Points needed for the Back Vertical Beams
                TSG.Point Point_2 = new TSG.Point(CurveSupport.Circle_Xcoord(ColumnPoint.X, BackCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ColumnPoint.X, BackCircle_1, ModelParameters), BackCircle_1, ModelParameters), 0 - HeightOffsetBottom);
                TSG.Point Point_3 = new TSG.Point(CurveSupport.Circle_Xcoord(ColumnPoint.X, BackCircle_1, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ColumnPoint.X, BackCircle_1, ModelParameters), BackCircle_1, ModelParameters), ScreenHeight + HeightOffsetTop);

                // Creating the Points needed for the Top and Bottom Vertical Beams. The _Back corrosponds to the Front points - B1BeamDepth
                TSG.Point Point_1_Back = new TSG.Point(CurveSupport.Circle_Xcoord(ColumnPoint.X, FrontCircle_2, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ColumnPoint.X, FrontCircle_2, ModelParameters), FrontCircle_2, ModelParameters), 0 - HeightOffsetBottom);
                TSG.Point Point_4_Back = new TSG.Point(CurveSupport.Circle_Xcoord(ColumnPoint.X, FrontCircle_2, ModelParameters), CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(ColumnPoint.X, FrontCircle_2, ModelParameters), FrontCircle_2, ModelParameters), ScreenHeight + HeightOffsetTop);

                // CREATE Front Beam
                Front = CurveSupport.StraightBeam("M", "A", "C1", Point_1 + WeldOffsetZ, Point_4 - WeldOffsetZ, ModelParameters.C1Material, ModelParameters.C1Profile, "2", Z_AxisEnums, Z_AxisOffsets);

                // Bottom Beam
                if (EnableBottomBeam)
                {
                    Bottom = CurveSupport.StraightBeam("M", "A", "B5", Point_1_Back, Point_2, ModelParameters.B5Material, ModelParameters.B5Profile, "4", Y_AxisEnums, Y_AxisOffsets);
                }

                // CREATE the TOP beam if enabled
                if (EnableTopBeam)
                {
                    Top = CurveSupport.StraightBeam("M", "A", "B5", Point_4_Back + B1DepthOffsetZ, Point_3 + B1DepthOffsetZ, ModelParameters.B5Material, ModelParameters.B5Profile, "4", Y_AxisEnums, Y_AxisOffsets);
                }

                // CREATE back beam
                Back = CurveSupport.StraightBeam("M", "A", "C1", Point_2 + WeldOffsetZ, Point_3 - WeldOffsetZ, ModelParameters.C1Material, ModelParameters.C1Profile, "2", Z_AxisEnums, Z_AxisOffsets);

                // Create Seating Plate
                if (ModelParameters.BuildSeatingPlate && !Side1)
                {
                    Seatplate = CreateSeatingPlate(
                        ColumnPoint + new TSG.Point(0, 0, 0),
                        frontDimensions,
                        ModelParameters,
                        false);
                }
            }
        }

        /// <summary>
        /// Method to create a seating plate.
        /// </summary>
        /// <param name="C1BeamOrigin"></param>
        /// <param name="frontDimensions"></param>
        /// <param name="ModelParameters"></param>
        /// <param name="EndPlate"></param>
        /// <returns></returns>
        private static ContourPlate CreateSeatingPlate(TSG.Point C1BeamOrigin, double[] frontDimensions, ModelParameters ModelParameters, bool EndPlate)
        {
            // Depth and Width of the reference column
            double ColDepth = frontDimensions[0];
            double ColWidth = frontDimensions[1];

            // Adjestment for the First and Last individual plates
            double Offset = (Math.Abs(C1BeamOrigin.X / ModelParameters.BillboardLength) <= 0.5) ? 0 : -65.0;

            // Radius of the Front Circle 1
            double FrontCircle_1 = ModelParameters.Radius;

            // Create a new Contour Plate
            ContourPlate CP = new ContourPlate();
            CP.Profile.ProfileString = ModelParameters.SeatingPlateProfile;
            CP.Material.MaterialString = ModelParameters.SeatingPlateMaterial;
            CP.Class = "5";
            CP.PartNumber = new NumberingSeries("PL", 1);
            CP.AssemblyNumber = new NumberingSeries("A", 1);

            // Get the thickness of the seating plate
            double PlateDepth = Convert.ToDouble(ModelParameters.SeatingPlateProfile.Substring(2));
            double ZPosition = C1BeamOrigin.Z + (PlateDepth / 2) - ModelParameters.WeldOffset;

            double a = ModelParameters.SeatingPlateExtrusionLength;
            
            // If the plate is at the end
            if (EndPlate)
            {
                // Define plate points
                ContourPoint point1a = new ContourPoint(new TSG.Point(C1BeamOrigin.X + Offset, C1BeamOrigin.Y + (ColDepth / 2) + CurveSupport.Circle_Ycoord(C1BeamOrigin.X - (65.0 / 2), FrontCircle_1, ModelParameters), ZPosition), null);
                ContourPoint point2b = new ContourPoint(new TSG.Point(point1a.X, point1a.Y - ColDepth - a + 20 , ZPosition), null);
                ContourPoint point3c = new ContourPoint(new TSG.Point(point2b.X + 20, point2b.Y - 20, ZPosition), null);
                ContourPoint point4d = new ContourPoint(new TSG.Point(point3c.X + 25, point3c.Y, ZPosition), null);
                ContourPoint point5e = new ContourPoint(new TSG.Point(point4d.X + 20, point4d.Y + 20, ZPosition), null);
                ContourPoint point6f = new ContourPoint(new TSG.Point(point5e.X, point1a.Y, ZPosition), null);

                // Add points to plate
                CP.AddContourPoint(point1a);
                CP.AddContourPoint(point2b);
                CP.AddContourPoint(point3c);
                CP.AddContourPoint(point4d);
                CP.AddContourPoint(point5e);
                CP.AddContourPoint(point6f);
            }
            else
            {
                // Define plate points
                ContourPoint point1a = new ContourPoint(new TSG.Point(C1BeamOrigin.X - ModelParameters.SeatingPlateOffset, C1BeamOrigin.Y - (ColDepth * 0.5) - ModelParameters.SeatingPlateOffset + CurveSupport.Circle_Ycoord(C1BeamOrigin.X - (ColWidth * 0.5) - ModelParameters.SeatingPlateOffset, FrontCircle_1, ModelParameters), ZPosition), null);
                ContourPoint point2b = new ContourPoint(new TSG.Point(point1a.X, C1BeamOrigin.Y + (ColDepth * 0.5) + CurveSupport.Circle_Ycoord(C1BeamOrigin.X - (ColWidth * 0.5) - ModelParameters.SeatingPlateOffset, FrontCircle_1, ModelParameters), ZPosition), null);
                ContourPoint point3c = new ContourPoint(new TSG.Point(point1a.X - 25, point2b.Y, ZPosition), null);
                ContourPoint point4d = new ContourPoint(new TSG.Point(point3c.X, point3c.Y - ColDepth - (a - 20), ZPosition), null);
                ContourPoint point5e = new ContourPoint(new TSG.Point(point4d.X + 20, C1BeamOrigin.Y - (ColDepth * 0.5) - a + CurveSupport.Circle_Ycoord(C1BeamOrigin.X - (ColWidth * 0.5) - ModelParameters.SeatingPlateOffset, FrontCircle_1, ModelParameters), ZPosition), null);

                ContourPoint point10j = new ContourPoint(new TSG.Point(C1BeamOrigin.X + (ColWidth) + ModelParameters.SeatingPlateOffset, point1a.Y , ZPosition), null);
                ContourPoint point9i = new ContourPoint(new TSG.Point(point10j.X, point2b.Y, ZPosition), null);
                ContourPoint point8h = new ContourPoint(new TSG.Point(point9i.X + 25, point3c.Y, ZPosition), null);
                ContourPoint point7g = new ContourPoint(new TSG.Point(point8h.X, point4d.Y, ZPosition), null);
                ContourPoint point6f = new ContourPoint(new TSG.Point(point7g.X - 20, point5e.Y, ZPosition), null);

                // Add points to plate
                CP.AddContourPoint(point1a);
                CP.AddContourPoint(point2b);
                CP.AddContourPoint(point3c);
                CP.AddContourPoint(point4d);
                CP.AddContourPoint(point5e);
                CP.AddContourPoint(point6f);
                CP.AddContourPoint(point7g);
                CP.AddContourPoint(point8h);
                CP.AddContourPoint(point9i);
                CP.AddContourPoint(point10j);
            }

            // Insert plate
            if (!CP.Insert()) { MessageBox.Show("Insertion of Seating Plate failed."); }

            return CP;
        }
    }
}