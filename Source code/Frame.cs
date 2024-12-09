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
    public class Frame
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
        public bool EnableTopBeam { get; set; }
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
        /// <param name="modelParameters"></param>
        /// <param name="cutbeambottom"></param>
        /// <param name="cutbeamtop"></param>
        public Frame
            (
                bool seatingPlateRight,
                TSG.Point point1,
                TSG.Point point2,
                TSG.Point point3,
                TSG.Point point4,
                int planeType,
                bool side1,
                bool side3,
                ModelParameters modelParameters,
                PolyBeam cutbeambottom,
                PolyBeam cutbeamtop,
                bool EnableTopBeam = true,
                bool EnableBottomBeam = true
            )
        {
            this.SeatingPlateRight = seatingPlateRight;
            this.Seatplate = null;
            this.Point1 = point1;
            this.Point2 = point2;
            this.Point3 = point3;
            this.Point4 = point4;
            this.PlaneType = planeType;
            this.ModelParameters = modelParameters;
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
            // For Horizontal Split Connections/////////////////////////////////////////////////
            double var1 = 30;


            // Create points for the weld offsets
            TSG.Point WeldOffSetY = new TSG.Point(0, ModelParameters.WeldOffset, 0);
            TSG.Point WeldOffsetZ = new TSG.Point(0, 0, ModelParameters.WeldOffset);

            // Initialise B1 dimension
            // 
            double[] b1Dimensions = ModelParameters.BeamDimensions(ModelParameters.B1Profile);

            // FRONT VERTICAL BEAMS (Points 1-4) /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Initialise FRONT dimension profile
            double[] frontDimensions = ModelParameters.BeamDimensions(ModelParameters.C1Profile);

            /* 
             * POSITION PARAMETERS
             * First Element in Array -> Depth
             * Second Element in Array -> Plane
             * Third Element in Array -> Rotation
             */
            int[] frontEnums = new int[] { 0, 0, 3 };
            double[] frontOffsets = new double[] { 0.0, 0.0, 90.0 };

            // BACK VERTICAL BEAMS (Points 3-2) /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Initialise BACK beam dimensions
            double[] backDimensions = ModelParameters.BeamDimensions(ModelParameters.C1Profile);

            // POSITION PARAMETERS
            int[] backEnums = new int[] { 0, 0, 0 };
            double[] backOffsets = new double[] { 0.0, 0.0, 0.0 };

            // BOTTOM HORIZONTAL BEAM (Points 2-1) /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Initialise BOTTOM dimension profile
            double[] bottomDimensions = ModelParameters.BeamDimensions(ModelParameters.B5Profile);

            // Bottom beam Position parameters
            int[] bottomEnums = new int[] { 0, 1, 2 };
            double[] bottomOffsets = new double[] { 0.0, 0.0, 90 };

            // TOP HORIZONTAL BEAMS (Points 3-4) /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Get the dimensions for the B2 beams
            double[] topDimensions = ModelParameters.BeamDimensions(ModelParameters.B2Profile);

            // Top beam Position parameters
            int[] topEnums = new int[] { 0, 2, 2 };
            double[] topOffsets = new double[] { 0.0, 0.0, 90 };

            // SPLIT BEAMS /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            double[] frontSplitDimensions = ModelParameters.BeamDimensions(ModelParameters.C1SplitProfile);
            double[] backSplitDimensions = ModelParameters.BeamDimensions(ModelParameters.C1SplitProfile);
            double[] bottomSplitDimensions = ModelParameters.BeamDimensions(ModelParameters.B5SplitProfile);
            double[] topSplitDimensions = ModelParameters.BeamDimensions(ModelParameters.B2SplitProfile);

            // Plane == 0 -> Split Plane
            // Plane == 1 -> First Plane
            // Plane == 2 -> Last Plane
            // Plane == 3 -> Middle Plane.

            // Split Plane
            if (PlaneType == 0)
            {
                // Split Plane on Right side
                if (SeatingPlateRight)
                {
                    // Move the model's origin in the positive x direction origin by half front beam width.
                    TSG.Point frontOffsetX = new TSG.Point(+frontSplitDimensions[1] / 2 + ModelParameters.BoxGap, 0, 0);

                    // Move the model's origin in the positive y direction by half the front beam depth.
                    TSG.Point frontOffsetY = new TSG.Point(0, 0.5 * frontSplitDimensions[0], 0);

                    TSG.Point frontOffsetZ = new TSG.Point();
                    TSG.Point ColumnPoint = new TSG.Point();
                    // Check if horizontal split
                    if (Side3)
                    {
                        frontOffsetZ = new TSG.Point(0, 0, 0);
                    }
                    else
                    {
                        // Reduce the length of the front beam in the z direction by twice the B1 depth 
                        frontOffsetZ = new TSG.Point(0, 0, -b1Dimensions[1]);
                    }
                    if (Side1)
                    {
                        ColumnPoint = Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ - new TSG.Point(0, 0, ModelParameters.B1BeamDepth);
                    }
                    else
                    {
                        ColumnPoint = Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ;
                    }

                    // Check what kind of horizontal split, is B1 an RHS or EA?
                    TSG.Point startPos = new TSG.Point();
                    TSG.Point endPos = new TSG.Point();
                    if (!(ModelParameters.B1SplitProfile.StartsWith("RHS") || ModelParameters.B1SplitProfile.StartsWith("SHS")))
                    {
                        startPos = ColumnPoint;
                        endPos = Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ;
                    }
                    else
                    {
                        startPos = Side1 ? 
                            ColumnPoint + new TSG.Point(0, 0, ModelParameters.B1SplitBeamWidth) 
                            : ColumnPoint;

                        endPos = Side3 ?
                            Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ - new TSG.Point(0, 0, ModelParameters.B1SplitBeamWidth)
                            : Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ;
                    }

                    // CREATE Front Beam
                    Front = Box.CreateBeam(Prefix.part,Prefix.assembly,
                        startPos,
                        endPos,
                        ModelParameters.C1SplitMaterial,
                        ModelParameters.C1SplitProfile,
                        "2",
                        frontEnums,
                        frontOffsets,
                        modelParameters: ModelParameters,
                        parentProfile: ModelParameters.C1Profile
                        );

                    // Align the bottom beams with the far edge of the structure -> 
                    TSG.Point bottomOffsetX = new TSG.Point(Math.Abs(bottomSplitDimensions[1] - frontSplitDimensions[1]) / 2 + frontSplitDimensions[1] / 2 + ModelParameters.BoxGap, 0, 0);

                    // Reduce the length of the bottom beam by the width of B1 beam such that it aligns 
                    TSG.Point bottomOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                    // Shift the bottom beam in the negative z direction by the width of the B1 beam.
                    TSG.Point bottomOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                    // Create Bottom Beam
                    if (EnableBottomBeam)
                    {
                        Bottom = Box.CreateBeam(Prefix.part, Prefix.assembly,
                            Point1 + bottomOffsetX + bottomOffsetY - bottomOffsetZ + WeldOffSetY,
                            Point2 + bottomOffsetX - bottomOffsetY - bottomOffsetZ - WeldOffSetY,
                            ModelParameters.B5SplitMaterial,
                            ModelParameters.B5SplitProfile,
                            "4",
                            bottomEnums,
                            bottomOffsets,
                            modelParameters: ModelParameters,
                            parentProfile: ModelParameters.B5Profile

                            );
                    }

                    // Shift the top beam in the first plane by half the width of the bottom beam.
                    //TSG.Point topOffsetX = new TSG.Point(topSplitDimensions[1] * 0.5 - (topSplitDimensions[1] - frontSplitDimensions[1]) * 0.5 + ModelParameters.BoxGap, 0, 0);
                    TSG.Point topOffsetX = new TSG.Point(topSplitDimensions[1] / 2 + ModelParameters.BoxGap, 0, 0);

                    // Reduce the length of the top beam by the width of B1 to make it between 2 B1 beams.
                    TSG.Point topOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                    // Bring down the top beams by B1 depth so it aligns with the frame 
                    TSG.Point topOffsetZ = new TSG.Point(0, 0, 0);

                    // CREATE the TOP beam if enabled
                    if (EnableTopBeam)
                    {
                        Top = Box.CreateBeam(Prefix.part, Prefix.assembly,
                            Point4 + topOffsetY - topOffsetZ + WeldOffSetY + topOffsetX,
                            Point3 - topOffsetY - topOffsetZ - WeldOffSetY + topOffsetX,
                            ModelParameters.B2SplitMaterial,
                            ModelParameters.B2SplitProfile,
                            "4",
                            topEnums,
                            topOffsets,
                            modelParameters: ModelParameters,
                            parentProfile: ModelParameters.B2Profile
                            );
                        this.B2Beams.Add(Top);
                    }


                    // OFFSET POINT GENERATION
                    // Move the model's origin in the positive x direction origin by half back beam width.
                    TSG.Point backOffsetX = new TSG.Point(0.5 * backSplitDimensions[1] + ModelParameters.BoxGap, 0, 0);

                    // Move the model's origin in the positive y direction by half the back beam depth
                    TSG.Point backOffsetY = new TSG.Point(0, 0.5 * backSplitDimensions[0], 0);

                    // Reduce the length of the back beam in the z direction by twice the B1 depth 
                    TSG.Point backOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                    // CREATE back beam
                    Back = Box.CreateBeam(Prefix.part,Prefix.assembly,Point2 + backOffsetX - backOffsetY + WeldOffsetZ,
                        Point3 + backOffsetX - backOffsetY - backOffsetZ - WeldOffsetZ,
                        ModelParameters.C1SplitMaterial,
                        ModelParameters.C1SplitProfile,
                        "2",
                        backEnums,
                        backOffsets,
                        modelParameters: ModelParameters,
                        parentProfile: ModelParameters.C1Profile
                        );

                    // Create Seating Plate
                    if (ModelParameters.BuildSeatingPlate && !Side1)
                    {
                        Seatplate = CreateSeatingPlate(
                            ColumnPoint + new TSG.Point(frontSplitDimensions[1] / 2 + ModelParameters.SeatingPlateOffset + (65.0 / 2), 0, 0),
                            frontSplitDimensions,
                            ModelParameters,
                            true);
                    }

                    // Check if the split beam is RHS or EA
                    if (!(ModelParameters.B1SplitProfile.StartsWith("RHS") || ModelParameters.B1SplitProfile.StartsWith("SHS")))
                    {
                        // Cut the front beam with cutbeambottm and cutbeamtop if there's a split
                        if (Side1)
                        {
                            BooleanPart beam = new BooleanPart();
                            beam.Father = Front;
                            beam.SetOperativePart(CutBeamBottom);
                            // beam.Type = BooleanPart.BooleanTypeEnum.BOOLEAN_ADD; // BOOLEAN_CUT is default type.
                            if (!beam.Insert()) { Console.WriteLine("Insert failed!"); }
                        }
                        if (Side3)
                        {
                            BooleanPart beam = new BooleanPart();
                            beam.Father = Front;
                            beam.SetOperativePart(CutBeamTop);
                            // beam.Type = BooleanPart.BooleanTypeEnum.BOOLEAN_ADD; // BOOLEAN_CUT is default type.
                            if (!beam.Insert()) { Console.WriteLine("Insert failed!"); }
                        }

                        // Also cut the little hole in the corner.
                        if (Side1)
                        {
                            CutPlane cutPlaneBot = new CutPlane
                            {
                                Plane = new Plane
                                {
                                    Origin = Point1 + new TSG.Point(
                                        0,
                                        ModelParameters.C1BeamDepth - var1,
                                        -ModelParameters.B1BeamDepth
                                        ),

                                    AxisY = new TSG.Vector(1, 0, 0),
                                    AxisX = new TSG.Vector(0, 1, 1)
                                },
                                Father = Front
                            };
                            cutPlaneBot.Insert();
                        }
                        if (Side3)
                        {
                            CutPlane cutPlaneBot = new CutPlane
                            {
                                Plane = new Plane
                                {
                                    Origin = Point4 + new TSG.Point(
                                        0,
                                        ModelParameters.C1BeamDepth - var1,
                                        0
                                        ),

                                    AxisY = new TSG.Vector(-1, 0, 0),
                                    AxisX = new TSG.Vector(0, 1, -1)
                                },
                                Father = Front
                            };
                            cutPlaneBot.Insert();
                        }
                    }
                }
                // Seating Plate on Left side
                else if (!SeatingPlateRight)
                {
                    // Move the model's origin in the positive x direction origin by half front beam width.
                    TSG.Point frontOffsetX = new TSG.Point(-frontSplitDimensions[1] / 2 - ModelParameters.BoxGap, 0, 0);

                    // Move the model's origin in the positive y direction by half the front beam depth.
                    TSG.Point frontOffsetY = new TSG.Point(0, 0.5 * frontSplitDimensions[0], 0);

                    TSG.Point frontOffsetZ = new TSG.Point();
                    TSG.Point ColumnPoint = new TSG.Point();
                    // Check if horizontal split
                    if (Side3)
                    {
                        frontOffsetZ = new TSG.Point(0, 0, 0);
                    }
                    else
                    {
                        // Reduce the length of the front beam in the z direction by twice the B1 depth 
                        frontOffsetZ = new TSG.Point(0, 0, -b1Dimensions[1]);
                    }
                    if (Side1)
                    {
                        ColumnPoint = Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ - new TSG.Point(0, 0, ModelParameters.B1BeamDepth);
                    }
                    else
                    {
                        ColumnPoint = Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ;
                    }

                    // Check what kind of horizontal split, is B1 an RHS or EA?
                    TSG.Point startPos = new TSG.Point();
                    TSG.Point endPos = new TSG.Point();
                    if (!(ModelParameters.B1SplitProfile.StartsWith("RHS") || ModelParameters.B1SplitProfile.StartsWith("SHS")))
                    {
                        startPos = ColumnPoint;
                        endPos = Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ;
                    }
                    else
                    {
                        startPos = Side1 ?
                            ColumnPoint + new TSG.Point(0, 0, ModelParameters.B1SplitBeamWidth)
                            : ColumnPoint;

                        endPos = Side3 ?
                            Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ - new TSG.Point(0, 0, ModelParameters.B1SplitBeamWidth)
                            : Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ;
                    }

                        // CREATE Front Beam
                        Front = Box.CreateBeam(Prefix.part,Prefix.assembly,
                            startPos,
                            endPos,
                            ModelParameters.C1SplitMaterial,
                            ModelParameters.C1SplitProfile,
                            "2",
                            frontEnums,
                            frontOffsets,
                            modelParameters: ModelParameters,
                            parentProfile: ModelParameters.C1Profile
                            );

                    // Align the bottom beams with the far edge of the structure -> 
                    TSG.Point bottomOffsetX = new TSG.Point(-Math.Abs(bottomSplitDimensions[1] - frontSplitDimensions[1]) / 2 - frontSplitDimensions[1] / 2 - ModelParameters.BoxGap, 0, 0);

                    // Reduce the length of the bottom beam by the width of B1 beam such that it aligns 
                    TSG.Point bottomOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                    // Shift the bottom beam in the negative z direction by the width of the B1 beam.
                    TSG.Point bottomOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                    // Create Bottom Beam
                    if (EnableBottomBeam)
                    {
                        Bottom = Box.CreateBeam(Prefix.part, Prefix.assembly,
                            Point1 + bottomOffsetX + bottomOffsetY - bottomOffsetZ + WeldOffSetY,
                            Point2 + bottomOffsetX - bottomOffsetY - bottomOffsetZ - WeldOffSetY,
                            ModelParameters.B5SplitMaterial,
                            ModelParameters.B5SplitProfile,
                            "4",
                            bottomEnums,
                            bottomOffsets,
                            modelParameters: ModelParameters,
                            parentProfile: ModelParameters.B5Profile

                            );
                    }

                    // Shift the top beam in the first plane by half the width of the bottom beam.
                    //TSG.Point topOffsetX = new TSG.Point(-frontSplitDimensions[1] / 2 - ModelParameters.BoxGap, 0, 0);
                    TSG.Point topOffsetX = new TSG.Point(-topSplitDimensions[1] / 2 - ModelParameters.BoxGap, 0, 0);

                    // Reduce the length of the top beam by the width of B1 to make it between 2 B1 beams.
                    TSG.Point topOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                    // Bring down the top beams by B1 depth so it aligns with the frame 
                    TSG.Point topOffsetZ = new TSG.Point(0, 0, 0);

                    // CREATE the TOP beam if enabled
                    if (EnableTopBeam)
                    {
                        Top = Box.CreateBeam(Prefix.part, Prefix.assembly,
                            Point4 + topOffsetY - topOffsetZ + WeldOffSetY + topOffsetX,
                            Point3 - topOffsetY - topOffsetZ - WeldOffSetY + topOffsetX,
                            ModelParameters.B2SplitMaterial,
                            ModelParameters.B2SplitProfile,
                            "4",
                            topEnums,
                            topOffsets,
                            modelParameters: ModelParameters,
                            parentProfile: ModelParameters.B2Profile
                            );
                        this.B2Beams.Add(Top);
                    }


                    // OFFSET POINT GENERATION
                    // Move the model's origin in the positive x direction origin by half back beam width.
                    TSG.Point backOffsetX = new TSG.Point(-frontSplitDimensions[1] / 2 - ModelParameters.BoxGap, 0, 0);

                    // Move the model's origin in the positive y direction by half the back beam depth
                    TSG.Point backOffsetY = new TSG.Point(0, 0.5 * backSplitDimensions[0], 0);

                    // Reduce the length of the back beam in the z direction by twice the B1 depth 
                    TSG.Point backOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                    // CREATE back beam
                    Back = Box.CreateBeam(Prefix.part,Prefix.assembly,
                        Point2 + backOffsetX - backOffsetY + WeldOffsetZ,
                        Point3 + backOffsetX - backOffsetY - backOffsetZ - WeldOffsetZ,
                        ModelParameters.C1SplitMaterial,
                        ModelParameters.C1SplitProfile,
                        "2",
                        backEnums,
                        backOffsets,
                        modelParameters: ModelParameters,
                        parentProfile: ModelParameters.C1Profile
                        );

                    // Create seating plate
                    if (ModelParameters.BuildSeatingPlate && !Side1)
                    {
                        Seatplate = CreateSeatingPlate(
                            ColumnPoint - new TSG.Point((frontSplitDimensions[1] / 2) + ModelParameters.SeatingPlateOffset + (65.0 / 2), 0, 0),
                            frontSplitDimensions,
                            ModelParameters,
                            true);
                    }

                    // Check if the split beam is RHS or EA
                    if (!(ModelParameters.B1SplitProfile.StartsWith("RHS") || ModelParameters.B1SplitProfile.StartsWith("SHS")))
                    {
                        // Cut the front beam with cutbeambottm and cutbeamtop if there's a split
                        if (Side1)
                        {
                            BooleanPart beam = new BooleanPart();
                            beam.Father = Front;
                            beam.SetOperativePart(CutBeamBottom);
                            // beam.Type = BooleanPart.BooleanTypeEnum.BOOLEAN_ADD; // BOOLEAN_CUT is default type.
                            if (!beam.Insert()) { Console.WriteLine("Insert failed!"); }
                        }
                        if (Side3)
                        {
                            BooleanPart beam = new BooleanPart();
                            beam.Father = Front;
                            beam.SetOperativePart(CutBeamTop);
                            // beam.Type = BooleanPart.BooleanTypeEnum.BOOLEAN_ADD; // BOOLEAN_CUT is default type.
                            if (!beam.Insert()) { Console.WriteLine("Insert failed!"); }
                        }

                        // Also cut the little hole in the corner.
                        if (Side1)
                        {
                            CutPlane CutPlaneBot = new CutPlane
                            {
                                Plane = new Plane
                                {
                                    Origin = Point1 + new TSG.Point(
                                        0,
                                        ModelParameters.C1BeamDepth - var1,
                                        -ModelParameters.B1BeamDepth
                                        ),

                                    AxisY = new TSG.Vector(1, 0, 0),
                                    AxisX = new TSG.Vector(0, 1, 1)
                                },
                                Father = Front
                            };
                            CutPlaneBot.Insert();
                        }
                        if (Side3)
                        {
                            CutPlane CutPlaneBot = new CutPlane
                            {
                                Plane = new Plane
                                {
                                    Origin = Point4 + new TSG.Point(
                                        0,
                                        ModelParameters.C1BeamDepth - var1,
                                        0
                                        ),

                                    AxisY = new TSG.Vector(-1, 0, 0),
                                    AxisX = new TSG.Vector(0, 1, -1)
                                },
                                Father = Front
                            };
                            CutPlaneBot.Insert();
                        }
                    }    
                }
            }
            // First plane
            else if (PlaneType == 1)
            {
                // Move the model's origin in the positive x direction origin by half front beam width.
                TSG.Point frontOffsetX = new TSG.Point(0, 0, 0);

                // Move the model's origin in the positive y direction by half the front beam depth.
                TSG.Point frontOffsetY = new TSG.Point(0, 0.5 * frontDimensions[0], 0);

                TSG.Point frontOffsetZ = new TSG.Point();
                TSG.Point ColumnPoint = new TSG.Point();
                // Check if horizontal split
                if (Side3)
                {
                    frontOffsetZ = new TSG.Point(0, 0, 0);
                }
                else
                {
                    // Reduce the length of the front beam in the z direction by twice the B1 depth 
                    frontOffsetZ = new TSG.Point(0, 0, -b1Dimensions[1]);
                }
                if (Side1)
                {
                    ColumnPoint = Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ - new TSG.Point(0, 0, ModelParameters.B1BeamDepth);
                }
                else
                {
                    ColumnPoint = Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ;
                }

                // Check what kind of horizontal split, is B1 an RHS or EA?
                TSG.Point startPos = new TSG.Point();
                TSG.Point endPos = new TSG.Point();
                if (!(ModelParameters.B1SplitProfile.StartsWith("RHS") || ModelParameters.B1SplitProfile.StartsWith("SHS")))
                {
                    startPos = ColumnPoint;
                    endPos = Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ;
                }
                else
                {
                    startPos = Side1 ?
                        ColumnPoint + new TSG.Point(0, 0, ModelParameters.B1SplitBeamWidth)
                        : ColumnPoint;

                    endPos = Side3 ?
                        Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ - new TSG.Point(0, 0, ModelParameters.B1SplitBeamWidth)
                        : Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ;
                }

                    // CREATE Front Beam
                    Front = Box.CreateBeam(Prefix.part,Prefix.assembly,
                        startPos,
                        endPos,
                        ModelParameters.C1Material,
                        ModelParameters.C1Profile,
                        "2",
                        frontEnums,
                        frontOffsets,
                        modelParameters: ModelParameters
                    );

                // OFFSET POINT GENERATION
                // Shift the bottom beam in the first plane by half the width of the bottom beam.
                TSG.Point bottomOffsetX = new TSG.Point(bottomDimensions[1] / 2 - frontDimensions[1] / 2, 0, 0);

                // Reduce the length of the bottom beam by the width of B1 beam such that it aligns 
                TSG.Point bottomOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Shift the bottom beam in the negative z direction by the width of the B1 beam.
                TSG.Point bottomOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                // CREATE the BOTTOM beam
                if (EnableBottomBeam)
                {
                    Bottom = Box.CreateBeam(Prefix.part, Prefix.assembly,
                        Point1 + bottomOffsetX + bottomOffsetY - bottomOffsetZ + WeldOffSetY,
                        Point2 + bottomOffsetX - bottomOffsetY - bottomOffsetZ - WeldOffSetY,
                        ModelParameters.B5Material,
                        ModelParameters.B5Profile,
                        "4",
                        bottomEnums,
                        bottomOffsets,
                        modelParameters: ModelParameters
                        );
                }


                // OFFSET POINT GENERATION
                // Shift the bottom beam in the first plane by half the width of the bottom beam.
                TSG.Point topOffsetX = new TSG.Point( -Math.Abs(frontDimensions[1] - topDimensions[1]) / 2, 0, 0);

                // Reduce the length of the top beam by the width of B1 to make it between 2 B1 beams.
                TSG.Point topOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Bring down the top beams by B1 depth so it aligns with the frame 
                TSG.Point topOffsetZ = new TSG.Point(0, 0, 0);

                // CREATE the TOP beam if enabled
                if (EnableTopBeam)
                {
                    Top = Box.CreateBeam(Prefix.part, Prefix.assembly,
                        Point4 + topOffsetY - topOffsetZ + WeldOffSetY + topOffsetX,
                        Point3 - topOffsetY - topOffsetZ - WeldOffSetY + topOffsetX,
                        ModelParameters.B2Material,
                        ModelParameters.B2Profile,
                        "4",
                        topEnums,
                        topOffsets,
                        modelParameters: ModelParameters
                        );
                    this.B2Beams.Add(Top);
                }


                // OFFSET POINT GENERATION
                // Move the model's origin in the positive x direction origin by half back beam width.
                TSG.Point backOffsetX = new TSG.Point(0, 0, 0);

                // Move the model's origin in the positive y direction by half the back beam depth
                TSG.Point backOffsetY = new TSG.Point(0, 0.5 * backDimensions[0], 0);

                // Reduce the length of the back beam in the z direction by twice the B1 depth 
                TSG.Point backOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                // CREATE back beam
                Back = Box.CreateBeam(Prefix.part,Prefix.assembly,
                    Point2 + backOffsetX - backOffsetY + WeldOffsetZ,
                    Point3 + backOffsetX - backOffsetY - backOffsetZ - WeldOffsetZ,
                    ModelParameters.C1Material,
                    ModelParameters.C1Profile,
                    "2",
                    backEnums,
                    backOffsets, modelParameters: ModelParameters);

                // Create Seating Plates
                if (ModelParameters.BuildSeatingPlate && !Side1)
                {
                    Seatplate = CreateSeatingPlate(
                        ColumnPoint + new TSG.Point(frontDimensions[1] / 2 + ModelParameters.SeatingPlateOffset + (65.0 / 2), 0, 0),
                        frontDimensions,
                        ModelParameters,
                        true);
                }

                // Check if the split beam is RHS or EA
                if (!(ModelParameters.B1SplitProfile.StartsWith("RHS") || ModelParameters.B1SplitProfile.StartsWith("SHS")))
                {
                    // Cut the front beam with cutbeambottm and cutbeamtop if there's a split
                    if (Side1)
                    {
                        BooleanPart beam = new BooleanPart();
                        beam.Father = Front;
                        beam.SetOperativePart(CutBeamBottom);
                        // beam.Type = BooleanPart.BooleanTypeEnum.BOOLEAN_ADD; // BOOLEAN_CUT is default type.
                        if (!beam.Insert()) { Console.WriteLine("Insert failed!"); }
                    }
                    if (Side3)
                    {
                        BooleanPart beam = new BooleanPart();
                        beam.Father = Front;
                        beam.SetOperativePart(CutBeamTop);
                        // beam.Type = BooleanPart.BooleanTypeEnum.BOOLEAN_ADD; // BOOLEAN_CUT is default type.
                        if (!beam.Insert()) { Console.WriteLine("Insert failed!"); }
                    }

                    // Also cut the little hole in the corner.
                    if (Side1)
                    {
                        CutPlane cutPlaneBot = new CutPlane
                        {
                            Plane = new Plane
                            {
                                Origin = Point1 + new TSG.Point(
                                    0,
                                    ModelParameters.C1BeamDepth - var1,
                                    -ModelParameters.B1BeamDepth
                                    ),

                                AxisY = new TSG.Vector(1, 0, 0),
                                AxisX = new TSG.Vector(0, 1, 1)
                            },
                            Father = Front
                        };
                        cutPlaneBot.Insert();
                    }
                    if (Side3)
                    {
                        CutPlane cutPlaneBot = new CutPlane
                        {
                            Plane = new Plane
                            {
                                Origin = Point4 + new TSG.Point(
                                    0,
                                    ModelParameters.C1BeamDepth - var1,
                                    0
                                    ),

                                AxisY = new TSG.Vector(-1, 0, 0),
                                AxisX = new TSG.Vector(0, 1, -1)
                            },
                            Father = Front
                        };
                        cutPlaneBot.Insert();
                    }
                }
            }
            // Last Plane
            else if (PlaneType == 2)
            {
                // Move the model's origin in the positive x direction origin by half front beam width.
                TSG.Point frontOffsetX = new TSG.Point(0, 0, 0);

                // Move the model's origin in the positive y direction by half the front beam depth.
                TSG.Point frontOffsetY = new TSG.Point(0, 0.5 * frontDimensions[0], 0);

                TSG.Point frontOffsetZ = new TSG.Point();
                TSG.Point ColumnPoint = new TSG.Point();
                
                // Check if horizontal split
                // If false, reduce the length of the front beam in the z direction by twice the B1 depth 
                frontOffsetZ = Side3 ? new TSG.Point(0, 0, 0) : frontOffsetZ = new TSG.Point(0, 0, -b1Dimensions[1]);
                ColumnPoint = Side1 ? Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ - new TSG.Point(0, 0, ModelParameters.B1BeamDepth) : Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ;
   

                // Check what kind of horizontal split, is B1 an RHS or EA?
                TSG.Point startPos = new TSG.Point();
                TSG.Point endPos = new TSG.Point();
                if (!(ModelParameters.B1SplitProfile.StartsWith("RHS") || ModelParameters.B1SplitProfile.StartsWith("SHS")))
                {
                    startPos = ColumnPoint;
                    endPos = Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ;
                }
                else
                {
                    startPos = Side1 ?
                        ColumnPoint + new TSG.Point(0, 0, ModelParameters.B1SplitBeamWidth)
                        : ColumnPoint;

                    endPos = Side3 ?
                        Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ - new TSG.Point(0, 0, ModelParameters.B1SplitBeamWidth)
                        : Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ;
                }

                // CREATE Front Beam
                Front = Box.CreateBeam(Prefix.part,Prefix.assembly,
                    startPos,
                    endPos,
                    ModelParameters.C1Material,
                    ModelParameters.C1Profile,
                    "2",
                    frontEnums,
                    frontOffsets,
                    modelParameters: ModelParameters
                    );

                // Align the bottom beam with the edge of the C1 Beam.
                TSG.Point bottomOffsetX = new TSG.Point(frontDimensions[1] / 2 - bottomDimensions[1] / 2 , 0, 0);

                // Reduce the length of the bottom beam by the width of B1 beam such that it aligns 
                TSG.Point bottomOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Shift the bottom beam in the negative z direction by the width of the B1 beam.
                TSG.Point bottomOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                // Bottom Beam
                if (EnableBottomBeam)
                {
                    Bottom = Box.CreateBeam(Prefix.part, Prefix.assembly,
                        Point1 + bottomOffsetX + bottomOffsetY - bottomOffsetZ + WeldOffSetY,
                        Point2 + bottomOffsetX - bottomOffsetY - bottomOffsetZ - WeldOffSetY,
                        ModelParameters.B5Material,
                        ModelParameters.B5Profile,
                        "4",
                        bottomEnums,
                        bottomOffsets,
                        modelParameters: ModelParameters
                        );
                }

                // Shift the top beam in the first plane by half the width of the bottom beam.
                TSG.Point topOffsetX = new TSG.Point(frontDimensions[1] / 2 - topDimensions[1] / 2, 0, 0);

                // Reduce the length of the top beam by the width of B1 to make it between 2 B1 beams.
                TSG.Point topOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Bring down the top beams by B1 depth so it aligns with the frame 
                TSG.Point topOffsetZ = new TSG.Point(0, 0, 0);

                // CREATE the TOP beam if enabled
                if (EnableTopBeam)
                {
                    Top = Box.CreateBeam(Prefix.part, Prefix.assembly,
                        Point4 + topOffsetY - topOffsetZ + WeldOffSetY + topOffsetX,
                        Point3 - topOffsetY - topOffsetZ - WeldOffSetY + topOffsetX,
                        ModelParameters.B2Material,
                        ModelParameters.B2Profile,
                        "4",
                        topEnums,
                        topOffsets,
                        modelParameters: ModelParameters
                        );
                    this.B2Beams.Add(Top);
                }


                // OFFSET POINT GENERATION
                // Move the model's origin in the positive x direction origin by half back beam width.
                TSG.Point backOffsetX = new TSG.Point(0, 0, 0);

                // Move the model's origin in the positive y direction by half the back beam depth
                TSG.Point backOffsetY = new TSG.Point(0, 0.5 * backDimensions[0], 0);

                // Reduce the length of the back beam in the z direction by twice the B1 depth 
                TSG.Point backOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                // CREATE back beam
                Back = Box.CreateBeam(Prefix.part,Prefix.assembly,
                    Point2 + backOffsetX - backOffsetY + WeldOffsetZ,
                    Point3 + backOffsetX - backOffsetY - backOffsetZ - WeldOffsetZ,
                    ModelParameters.C1Material,
                    ModelParameters.C1Profile,
                    "2",
                    backEnums,
                    backOffsets,
                    modelParameters: ModelParameters
                    );

                // Create Seating Plate
                if (ModelParameters.BuildSeatingPlate && !Side1)
                {
                    Seatplate = CreateSeatingPlate(
                        ColumnPoint - new TSG.Point((frontDimensions[1] / 2) + ModelParameters.SeatingPlateOffset + (65.0 / 2), 0, 0),
                        frontDimensions,
                        ModelParameters, true);
                }

                // Check if the split beam is RHS or EA
                if (!(ModelParameters.B1SplitProfile.StartsWith("RHS") || ModelParameters.B1SplitProfile.StartsWith("SHS")))
                {
                    // Cut the front beam with cutbeambottm and cutbeamtop if there's a split
                    if (Side1)
                    {
                        BooleanPart beam = new BooleanPart();
                        beam.Father = Front;
                        beam.SetOperativePart(CutBeamBottom);
                        // beam.Type = BooleanPart.BooleanTypeEnum.BOOLEAN_ADD; // BOOLEAN_CUT is default type.
                        if (!beam.Insert()) { Console.WriteLine("Insert failed!"); }
                    }
                    if (Side3)
                    {
                        BooleanPart beam = new BooleanPart();
                        beam.Father = Front;
                        beam.SetOperativePart(CutBeamTop);
                        // beam.Type = BooleanPart.BooleanTypeEnum.BOOLEAN_ADD; // BOOLEAN_CUT is default type.
                        if (!beam.Insert()) { Console.WriteLine("Insert failed!"); }
                    }

                    // Also cut the little hole in the corner.
                    if (Side1)
                    {
                        CutPlane cutPlaneBot = new CutPlane
                        {
                            Plane = new Plane
                            {
                                Origin = Point1 + new TSG.Point(
                                    0,
                                    ModelParameters.C1BeamDepth - var1,
                                    -ModelParameters.B1BeamDepth
                                    ),

                                AxisY = new TSG.Vector(1, 0, 0),
                                AxisX = new TSG.Vector(0, 1, 1)
                            },
                            Father = Front
                        };
                        cutPlaneBot.Insert();
                    }
                    if (Side3)
                    {
                        CutPlane cutPlaneBot = new CutPlane
                        {
                            Plane = new Plane
                            {
                                Origin = Point4 + new TSG.Point(
                                    0,
                                    ModelParameters.C1BeamDepth - var1,
                                    0
                                    ),

                                AxisY = new TSG.Vector(-1, 0, 0),
                                AxisX = new TSG.Vector(0, 1, -1)
                            },
                            Father = Front
                        };
                        cutPlaneBot.Insert();
                    }
                }
            }

            // Middle Plane
            else if (PlaneType == 3)
            {
                // Move the model's origin in the positive x direction origin by half front beam width.
                TSG.Point frontOffsetX = new TSG.Point(0, 0, 0);

                // Move the model's origin in the positive y direction by half the front beam depth.
                TSG.Point frontOffsetY = new TSG.Point(0, 0.5 * frontDimensions[0], 0);

                TSG.Point frontOffsetZ = new TSG.Point();
                TSG.Point ColumnPoint = new TSG.Point();

                // Check if horizontal split
                // If false, reduce the length of the front beam in the z direction by twice the B1 depth 
                frontOffsetZ = Side3 ? new TSG.Point(0, 0, 0) : new TSG.Point(0, 0, -b1Dimensions[1]);
                ColumnPoint = Side1 ? Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ - new TSG.Point(0,0,ModelParameters.B1BeamDepth) : Point1 + frontOffsetX + frontOffsetY + WeldOffsetZ;

                // Check what kind of horizontal split, is B1 an RHS or EA?
                TSG.Point startPos = new TSG.Point();
                TSG.Point endPos = new TSG.Point();
                if (!(ModelParameters.B1SplitProfile.StartsWith("RHS") || ModelParameters.B1SplitProfile.StartsWith("SHS")))
                {
                    startPos = ColumnPoint;
                    endPos = Point4 + frontOffsetX + frontOffsetY + frontOffsetZ;
                }
                else
                {
                    startPos = Side1 ?
                        ColumnPoint + new TSG.Point(0, 0, ModelParameters.B1SplitBeamWidth)
                        : ColumnPoint;

                    endPos = Side3 ?
                        Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ - new TSG.Point(0, 0, ModelParameters.B1SplitBeamWidth)
                        : Point4 + frontOffsetX + frontOffsetY + frontOffsetZ - WeldOffsetZ;
                }

                // CREATE Front Beam
                Front = Box.CreateBeam(Prefix.part,Prefix.assembly,
                        startPos,
                        endPos,
                        ModelParameters.C1Material,
                        ModelParameters.C1Profile,
                        "2",
                        frontEnums,
                        frontOffsets,
                        modelParameters: ModelParameters
                        );

                // Align the bottom beams with the far edge of the structure -> 
                TSG.Point bottomOffsetX = new TSG.Point(0, 0, 0);

                // Reduce the length of the bottom beam by the width of B1 beam such that it aligns 
                TSG.Point bottomOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Shift the bottom beam in the negative z direction by the width of the B1 beam.
                TSG.Point bottomOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                // Bottom Beam
                if (EnableBottomBeam)
                {
                    Bottom = Box.CreateBeam(Prefix.part, Prefix.assembly,
                        Point1 + bottomOffsetX + bottomOffsetY - bottomOffsetZ + WeldOffSetY,
                        Point2 + bottomOffsetX - bottomOffsetY - bottomOffsetZ - WeldOffSetY,
                        ModelParameters.B5Material,
                        ModelParameters.B5Profile,
                        "4",
                        bottomEnums,
                        bottomOffsets,
                        modelParameters: ModelParameters
                        );
                }

                // Shift the bottom beam in the first plane by half the width of the bottom beam.
                TSG.Point topOffsetX = new TSG.Point(0, 0, 0);

                // Reduce the length of the top beam by the width of B1 to make it between 2 B1 beams.
                TSG.Point topOffsetY = new TSG.Point(0, b1Dimensions[0], 0);

                // Bring down the top beams by B1 depth so it aligns with the frame 
                TSG.Point topOffsetZ = new TSG.Point(0, 0, 0);

                // CREATE the TOP beam if enabled
                if (EnableTopBeam)
                {
                    Top = Box.CreateBeam(Prefix.part, Prefix.assembly,
                        Point4 + topOffsetY - topOffsetZ + WeldOffSetY + topOffsetX,
                        Point3 - topOffsetY - topOffsetZ - WeldOffSetY + topOffsetX,
                        ModelParameters.B2Material,
                        ModelParameters.B2Profile,
                        "4",
                        topEnums,
                        topOffsets,
                            modelParameters: ModelParameters);
                    this.B2Beams.Add(Top);
                }

                // OFFSET POINT GENERATION
                // Move the model's origin in the positive x direction origin by half back beam width.
                TSG.Point backOffsetX = new TSG.Point(0, 0, 0);

                // Move the model's origin in the positive y direction by half the back beam depth
                TSG.Point backOffsetY = new TSG.Point(0, 0.5 * backDimensions[0], 0);

                // Reduce the length of the back beam in the z direction by twice the B1 depth 
                TSG.Point backOffsetZ = new TSG.Point(0, 0, b1Dimensions[1]);

                // CREATE back beam
                Back = Box.CreateBeam(Prefix.part,Prefix.assembly,
                    Point2 + backOffsetX - backOffsetY + WeldOffsetZ,
                    Point3 + backOffsetX - backOffsetY - backOffsetZ - WeldOffsetZ,
                    ModelParameters.C1Material,
                    ModelParameters.C1Profile,
                    "2",
                    backEnums,
                    backOffsets,
                    modelParameters: ModelParameters
                    );

                // Create Seating Plate
                if (ModelParameters.BuildSeatingPlate && !Side1)
                {
                    Seatplate = CreateSeatingPlate(
                        ColumnPoint + new TSG.Point(0, 0, 0),
                        frontDimensions,
                        ModelParameters,
                        false);
                }

                // Check if the split beam is RHS or EA
                if (!(ModelParameters.B1SplitProfile.StartsWith("RHS") || ModelParameters.B1SplitProfile.StartsWith("SHS")))
                {
                    // Cut the front beam with cutbeambottom and cutbeamtop if there's a split
                    if (Side1)
                    {
                        BooleanPart beam = new BooleanPart();
                        beam.Father = Front;
                        beam.SetOperativePart(CutBeamBottom);
                        // Beam.Type = BooleanPart.BooleanTypeEnum.BOOLEAN_ADD; // BOOLEAN_CUT is default type.
                        if (!beam.Insert()) { Console.WriteLine("Insert failed!"); }
                    }
                    if (Side3)
                    {
                        BooleanPart beam = new BooleanPart();
                        beam.Father = Front;
                        beam.SetOperativePart(CutBeamTop);
                        // beam.Type = BooleanPart.BooleanTypeEnum.BOOLEAN_ADD; // BOOLEAN_CUT is default type.
                        if (!beam.Insert()) { Console.WriteLine("Insert failed!"); }
                    }

                    // Also cut the little hole in the corner.
                    if (Side1)
                    {
                        CutPlane CutPlaneBot = new CutPlane
                        {
                            Plane = new Plane
                            {
                                Origin = Point1 + new TSG.Point(
                                    0,
                                    ModelParameters.C1BeamDepth - var1,
                                    -ModelParameters.B1BeamDepth
                                    ),

                                AxisY = new TSG.Vector(1, 0, 0),
                                AxisX = new TSG.Vector(0, 1, 1)
                            },
                            Father = Front
                        };
                        CutPlaneBot.Insert();
                    }
                    if (Side3)
                    {
                        CutPlane CutPlaneBot = new CutPlane
                        {
                            Plane = new Plane
                            {
                                Origin = Point4 + new TSG.Point(
                                    0,
                                    ModelParameters.C1BeamDepth - var1,
                                    0
                                    ),

                                AxisY = new TSG.Vector(-1, 0, 0),
                                AxisX = new TSG.Vector(0, 1, -1)
                            },
                            Father = Front
                        };
                        CutPlaneBot.Insert();
                    }
                }
            }
        }

        /// <summary>
        /// Method to create a seating plate.
        /// </summary>
        /// <param name="C1BeamOrigin"></param>
        /// <param name="frontDimensions"></param>
        /// <param name="modelParameters"></param>
        /// <param name="EndPlate"></param>
        /// <returns></returns>
        private static ContourPlate CreateSeatingPlate(TSG.Point C1BeamOrigin, double[] frontDimensions, ModelParameters modelParameters, bool EndPlate)
        {

            // Depth and Width of the reference column
            double ColDepth = frontDimensions[0];
            double ColWidth = frontDimensions[1];

            // Create a new Contour Plate
            ContourPlate CP = new ContourPlate();
            CP.Profile.ProfileString = modelParameters.SeatingPlateProfile;
            CP.Material.MaterialString = modelParameters.SeatingPlateMaterial;
            CP.Class = "5";
            CP.PartNumber = new NumberingSeries("PL", 1);
            CP.AssemblyNumber = new NumberingSeries("A", 1);

            // Get the thickness of the seating plate
            double PlateDepth = Convert.ToDouble(modelParameters.SeatingPlateProfile.Substring(2));
            double ZPosition = C1BeamOrigin.Z + (PlateDepth / 2) - modelParameters.WeldOffset;

            double a = modelParameters.SeatingPlateExtrusionLength;

            // If the plate is at the end
            if (EndPlate)
            {
                // Define plate points
                ContourPoint point1a = new ContourPoint(new TSG.Point(C1BeamOrigin.X - (65.0 / 2), C1BeamOrigin.Y + (ColDepth / 2), ZPosition), null);
                ContourPoint point2b = new ContourPoint(new TSG.Point(point1a.X, point1a.Y - ColDepth - a + 20, ZPosition), null);
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
                ContourPoint point1a = new ContourPoint(new TSG.Point(C1BeamOrigin.X - (ColWidth * 0.5) - modelParameters.SeatingPlateOffset, C1BeamOrigin.Y - (ColDepth * 0.5) - modelParameters.SeatingPlateOffset, ZPosition), null);
                ContourPoint point2b = new ContourPoint(new TSG.Point(point1a.X, C1BeamOrigin.Y + (ColDepth * 0.5), ZPosition), null);
                ContourPoint point3c = new ContourPoint(new TSG.Point(point1a.X - 25, point2b.Y, ZPosition), null);
                ContourPoint point4d = new ContourPoint(new TSG.Point(point3c.X, point3c.Y - ColDepth - (a - 20), ZPosition), null);
                ContourPoint point5e = new ContourPoint(new TSG.Point(point4d.X + 20, C1BeamOrigin.Y - (ColDepth * 0.5) - a, ZPosition), null);

                ContourPoint point10j = new ContourPoint(new TSG.Point(C1BeamOrigin.X + (ColWidth * 0.5) + modelParameters.SeatingPlateOffset, point1a.Y, ZPosition), null);
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