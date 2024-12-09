using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Represents a box that is used to fill up each setion in a billboard with splits.
    /// </summary>
    public class Box
    {
        /// <value>
        /// Represents the front side of the billboard
        /// </value>
        public bool Side1 { get; set; }

        /// <value>
        /// Represents the left side of the billboard
        /// </value>
        public bool Side2 { get; set; }

        /// <value>
        /// Represents the back side of the billboard
        /// </value>
        public bool Side3 { get; set; }

        /// <value>
        /// Represents the right side of the billboard
        /// </value>
        public bool Side4 { get; set; }

        /// <value>
        /// Represents the first B1 Beam in a rectangle
        /// </value>
        public Beam B1Beam1 { get; set; }

        /// <value>
        /// Represents the second B1 Beam in a rectangle
        /// </value>
        public Beam B1Beam2 { get; set; }

        /// <value>
        /// Represents the third B1 Beam in a rectangle
        /// </value>
        public Beam B1Beam3 { get; set; }

        /// <value>
        /// Represents the fourth B1 Beam in a rectangle
        /// </value>
        public Beam B1Beam4 { get; set; }

        /// <value>
        /// A TSG point representing the origin position of the box
        /// </value>
        public TSG.Point BoxOrigin { get; set; }

        /// <value>
        /// Indicates the height of the box
        /// </value>
        public double Height { get; set; }

        /// <value>
        /// Indicates the length of the box
        /// </value>
        public double Length { get; set; }

        /// <value>
        /// A list of frames for the planes of the box
        /// </value>
        public List<Frame> Planes { get; set; }

        /// <value>
        /// Indicates the x positions where vertical supports in the box are to be placed
        /// </value>
        public List<double> XSubCoordinates { get; set; }

        private Assembly _boxAssembly = new Assembly();

        /* Figure 1. Representation of a single plane of the box (front view)
                            side 3
                       _________________
                    3 |                 | 4
             side 2   |                 |   side 4
                      |_________________|
                    2                     1
                            side 1
        // side == True Means there's a split
        // side == False Means there's an edge
        */
        /// <summary>
        /// The constructor for a box, which generates a model section in the billboard.
        /// </summary>
        /// <param name="zSubCoordinates">The vertical height of where the box is constructed</param>
        /// <param name="xSubCoordinates">The horizontal distances of where vertical columns go</param>
        /// <param name="walkwaySubList">A list of the vertical positions of where walkways are positioned </param>
        /// <param name="boxHeight">The height of the box</param>
        /// <param name="boxLength">The length of the box</param>
        /// <param name="OriginOffset">A TSG point reference for the position of the box</param>
        /// <param name="side1">Indicates if front is selected</param>
        /// <param name="side2">Indicates if left is selected</param>
        /// <param name="side3">Indicates if back is selected</param>
        /// <param name="side4">Indicates if right is selected</param>
        /// <param name="StructureAutoRadio">Used to indicate to create intermediate horizontal railing supports</param>
        /// <param name="modelParameters">The parameters of the model</param>
        /// <param name="HatchFlag"> Indicats whether a hatch would be needed for this box. </param>
        /// <param name="IsLeftHatch"> Indicate whether the hatch is a left hatch or a right hatch. </param>
        /// <param name="TopHatchFlag"> Indicate whether there will have a top hatch. </param>
        /// <param name="HatchDistanceFromLadder"> The distance of the hatch from the ladder. </param>
        /// <param name="HatchWidth"> The width of the hatch. </param>
        /// TODO Desc for additional hatch related parameters
        public Box
            (
            List<double> zSubCoordinates,
            List<double> xSubCoordinates,
            List<double> walkwaySubList,
            double boxHeight,
            double boxLength,
            TSG.Point OriginOffset,
            bool side1,
            bool side2,
            bool side3,
            bool side4,
            bool StructureAutoRadio,
            ModelParameters modelParameters,
            bool HatchFlag = false,
            bool IsLeftHatch = false,
            bool TopHatchFlag = false,
            double HatchDistanceFromLadder = 0,
            double HatchWidth = 0
            )
        {

            // Calculate the inner start and end position of the hatch.
            TSG.Point HatchStart = null;
            TSG.Point HatchEnd = null;
            int NumOfFrameRemoved = 0;
            if (HatchFlag)
            {
                // The Y position of both left and right hatches will be the same.
                double EndY = modelParameters.BillboardDepth - modelParameters.B1BeamWidth - HatchDistanceFromLadder - modelParameters.HatchBeamDepth;
                double StartY = modelParameters.B1BeamWidth + modelParameters.HatchBeamDepth + modelParameters.WeldOffset * 2;
                if (IsLeftHatch)
                {
                    // (B5 beam)(B2 support beam)(left hatch beam) with box offset x at the middle of the b5 beam.
                    double StartX = OriginOffset.X + modelParameters.B5BeamWidth/2 + modelParameters.B2BeamWidth + modelParameters.HatchBeamDepth + 8.5 + 1;
                    HatchStart = new TSG.Point(StartX, StartY);
                    HatchEnd = new TSG.Point(StartX + HatchWidth - 2*(modelParameters.B2BeamWidth + modelParameters.HatchBeamDepth), EndY);

                } else
                {
                    double EndX = (OriginOffset.X + boxLength) - modelParameters.B5BeamWidth/2 - modelParameters.B2BeamWidth - modelParameters.HatchBeamDepth - 8.5 - 1; // Alan
                    HatchStart = new TSG.Point(EndX - HatchWidth + 2 * (modelParameters.B2BeamWidth + modelParameters.HatchBeamDepth), StartY); // Was
                    HatchEnd = new TSG.Point(EndX, EndY); // Here
                }

                // P.S. The Hatch class is probably capable of generating hacthes at any location with modification but for now only left or right side of the billboard.
            }


            this.XSubCoordinates = xSubCoordinates;

            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
            Side4 = side4;
            BoxOrigin = new TSG.Point(OriginOffset);
            Height = boxHeight;
            Length = boxLength;

            // Create a list of x coordinates for the planes / spacings between the columns from engineering drawings
            List<double> xCoordinates = xSubCoordinates;

            double B1BeamWidth = modelParameters.B1BeamWidth;
            double B1BeamDepth = modelParameters.B1BeamDepth;
            double B2BeamWidth = modelParameters.B2BeamWidth;
            double BR1BeamDepth = modelParameters.BR1BeamDepth;
            double C1BeamDepth = modelParameters.C1BeamDepth;
            double C1BeamWidth = modelParameters.C1BeamWidth;
            double B5BeamWidth = modelParameters.B5BeamWidth;
            double B2SplitBeamWidth = modelParameters.B2SplitBeamWidth;
            double B5SplitBeamWidth = modelParameters.B5SplitBeamWidth;

            double B1SplitBeamDepth = modelParameters.B1SplitBeamDepth;

            // Difference between depth of B1 and B5
            double differenceb1b5Depth = modelParameters.B1BeamDepth - modelParameters.B5BeamDepth;
            double billboardDepth = modelParameters.BillboardDepth;

            // Figure out the starting and end height of the frame
            double boxZStart;
            double boxZEnd;
            double splitGap = B1BeamDepth + 2 * modelParameters.BoxGap;
            double var1 = 0; // Displaces the split.
            if (side1)
            {
                boxZStart = splitGap + var1;
            }
            else
            {
                boxZStart = -modelParameters.HeightOffsetBottom;
            }

            if (side3)
            {
                boxZEnd = boxHeight + var1;
            }
            else
            {
                boxZEnd = boxHeight + modelParameters.HeightOffsetTop + B1BeamDepth;
            }

            // Check to see if in split.
            double xStart = 0;
            double xEnd = 0;
            if (side2)
            {
                xStart = modelParameters.BoxGap;
            }
            else
            {
                xStart = -C1BeamWidth / 2;
            }

            if (side4)
            {
                xEnd = boxLength - modelParameters.BoxGap;
            }
            else
            {
                xEnd = boxLength + C1BeamWidth / 2;
            }

            // Create the Bottom Beam with which we're going to cut the front beams. But only if the B1 Split Beam is an EA beam.
            PolyBeam cutBeamBottom = new PolyBeam();
            PolyBeam cutBeamTop = new PolyBeam();

            if (!(modelParameters.B1SplitProfile.StartsWith("RHS") || modelParameters.B1SplitProfile.StartsWith("SHS")))
            {
                cutBeamBottom.AddContourPoint(
                    new ContourPoint(
                        new TSG.Point(
                            -C1BeamWidth,
                            0,
                            boxZStart - B1BeamDepth
                            ) + OriginOffset,
                        null)
                    );

                cutBeamBottom.AddContourPoint(
                    new ContourPoint(
                        new TSG.Point(
                            -C1BeamWidth,
                            C1BeamDepth,
                            boxZStart - B1BeamDepth
                            ) + OriginOffset,
                        null)
                    );

                cutBeamBottom.AddContourPoint(
                    new ContourPoint(
                        new TSG.Point(
                            -C1BeamWidth,
                            C1BeamDepth,
                            boxZStart - B1BeamDepth + B1SplitBeamDepth + modelParameters.WeldOffset
                            ) + OriginOffset,
                        null)
                    );

                cutBeamBottom.Profile.ProfileString = "PLT" + (modelParameters.B1SplitBeamThickness + modelParameters.WeldOffset).ToString() + "*" + (boxLength + 2 * C1BeamWidth).ToString();
                cutBeamBottom.Material.MaterialString = modelParameters.B1Material;

                // Depth position - First element in the array : 0 - Middle, 1 - Front, 2 - Back
                cutBeamBottom.Position.Depth = (Position.DepthEnum)1;
                cutBeamBottom.Position.DepthOffset = 0;

                // Plane position - Second element in the array : 0 - Middle, 1 - Left, 2 - Right
                cutBeamBottom.Position.Plane = (Position.PlaneEnum)2;
                cutBeamBottom.Position.PlaneOffset = 0;

                // Rotation position - Third element in the array : 0 - Front, 1 - Top, 2 - Back, 3 - Below
                cutBeamBottom.Position.Rotation = (Position.RotationEnum)0;
                cutBeamBottom.Position.RotationOffset = 0;

                cutBeamBottom.Class = BooleanPart.BooleanOperativeClassName;

                if (!cutBeamBottom.Insert()) { Console.WriteLine("Insertion of beam failed."); }

                // Create the Top Beam with which we're going to cut the front beams.
                cutBeamTop.AddContourPoint(
                    new ContourPoint(
                        new TSG.Point(
                            -C1BeamWidth,
                            0,
                            boxZEnd
                            ) + OriginOffset,
                        null)
                    );

                cutBeamTop.AddContourPoint(
                    new ContourPoint(
                        new TSG.Point(
                            -C1BeamWidth,
                            C1BeamDepth,
                            boxZEnd
                            ) + OriginOffset,
                        null)
                    );

                cutBeamTop.AddContourPoint(
                    new ContourPoint(
                        new TSG.Point(
                            -C1BeamWidth,
                            C1BeamDepth,
                            boxZEnd - B1SplitBeamDepth - modelParameters.WeldOffset
                            ) + OriginOffset,
                        null)
                    );

                cutBeamTop.Profile.ProfileString = "PLT" + (modelParameters.B1SplitBeamThickness + modelParameters.WeldOffset).ToString() + "*" + (boxLength + 2 * C1BeamWidth).ToString();
                cutBeamTop.Material.MaterialString = modelParameters.B1Material;

                // Depth position - First element in the array : 0 - Middle, 1 - Front, 2 - Back
                cutBeamTop.Position.Depth = (Position.DepthEnum)2;
                cutBeamTop.Position.DepthOffset = 0;

                // Plane position - Second element in the array : 0 - Middle, 1 - Left, 2 - Right
                cutBeamTop.Position.Plane = (Position.PlaneEnum)2;
                cutBeamTop.Position.PlaneOffset = 0;

                // Rotation position - Third element in the array : 0 - Front, 1 - Top, 2 - Back, 3 - Below
                cutBeamTop.Position.Rotation = (Position.RotationEnum)0;
                cutBeamTop.Position.RotationOffset = 0;

                cutBeamTop.Class = BooleanPart.BooleanOperativeClassName;

                if (!cutBeamTop.Insert()) { Console.WriteLine("Insertion of beam failed."); }
            }

            (B1Beam1, B1Beam2, B1Beam3, B1Beam4) = HorizontalBeam.HorizontalBeams
                (
                xStart,
                xEnd,
                boxZStart,
                boxZEnd,
                OriginOffset,
                Side1,
                Side3,
                B1BeamWidth,
                B1BeamDepth,
                billboardDepth,
                xSubCoordinates,
                modelParameters
                );

            // Creating Frames
            List<Frame> planes = new List<Frame>(); // Storing each plane (of each x offset)

            // Loop through the indexes of the xCoordinates list to set identifying values for the planeType variable 
            // I.e. loops through integers from 0 to number of inputs in xCoordinates list 

            // New 
            // Plane == 0 -> Split Plane
            // Plane == 1 -> First Plane
            // Plane == 2 -> Last Plane
            // Plane == 3 -> Middle Plane.
            // initial offset
            double xOffset = 0;
            for (int i = 0; i < xCoordinates.Count; i++)
            {
                bool splitPlaneRight = true;
                int planeType;
                // Split Plant With seating plate on the right
                if (i == 0 && side2)
                {
                    planeType = 0;
                }
                // Split Plate With Seating Plate on the left
                else if (i == xCoordinates.Count - 1 && side4)
                {
                    splitPlaneRight = false;
                    planeType = 0;
                }
                // Plane on left edge
                else if (i == 0)
                {
                    planeType = 1;
                }
                // Plane on right edge
                else if (i == xCoordinates.Count - 1)
                {
                    planeType = 2;
                }
                // Middle Plane
                else
                {
                    planeType = 3;
                }
                // Total offset for the current plane
                xOffset += xCoordinates[i];

                // The four points of a plane
                TSG.Point point1 = new TSG.Point(xOffset, 0, boxZStart) + OriginOffset;
                TSG.Point point2 = new TSG.Point(xOffset, billboardDepth, boxZStart) + OriginOffset;
                TSG.Point point3 = new TSG.Point(xOffset, billboardDepth, boxZEnd) + OriginOffset;
                TSG.Point point4 = new TSG.Point(xOffset, 0, boxZEnd) + OriginOffset;

                // Create a plane and store this plane
                Frame plane = null;

                // Get the X range to check for removal of top and bottom frame for the hatch. 
                double AdjustedHatchXRangeStart = 0;
                double AdjustedHatchXRangeEnd = 0;
                if (HatchFlag)
                {
                    AdjustedHatchXRangeStart = HatchStart.X - modelParameters.HatchBeamDepth - modelParameters.B2BeamWidth;
                    AdjustedHatchXRangeEnd = HatchEnd.X + modelParameters.HatchBeamDepth + modelParameters.B2BeamWidth;

                    // TODO: When the hatch support B2 beam is too close to the following B2 beam, the diagonal beam will look weird.
                    // Can implement something to remove the following B2 beam by adding a tolerance to the range.
                    // The frame removing part is already done by changing this tolerance value, but not the x sub coords adjusting.
                    double HatchBeamB2Tolerance = 0;

                    // Adjust the X range of the right side if right hatch and vice versa.
                    if (!IsLeftHatch)
                    {
                        AdjustedHatchXRangeStart -= HatchBeamB2Tolerance;
                    }
                    else
                    {
                        AdjustedHatchXRangeEnd -= HatchBeamB2Tolerance;
                    }
                }


                // Disable the top and/or bottom beams of the frame depending on if there need to be a hatch.
                if ((HatchFlag) &&
                    (point3.X >= (AdjustedHatchXRangeStart) && point3.X <= (AdjustedHatchXRangeEnd)))
                {
                    NumOfFrameRemoved++;
                    if (!side1) // Bottom edge box does not need a hatch, but it's top frame beam within the range need to be disable for the bottom hatch in the box atop.
                    {
                        plane = new Frame(splitPlaneRight, point1, point2, point3, point4, planeType, side1, side3, modelParameters, cutBeamBottom, cutBeamTop, false);
                    } else
                    {
                        plane = new Frame(splitPlaneRight, point1, point2, point3, point4, planeType, side1, side3, modelParameters, cutBeamBottom, cutBeamTop, false, false);
                    }

                } else // For boxes without a hatch.
                {
                    plane = new Frame(splitPlaneRight, point1, point2, point3, point4, planeType, side1, side3, modelParameters, cutBeamBottom, cutBeamTop);
                }

                planes.Add(plane);
            }

            this.Planes = planes;

            // Save all the Part objects created in frame generation to the list.
            List<Part> FrameParts = new List<Part>();
            foreach (Frame Plane in planes) {
                if (Plane.Top != null)
                {
                    FrameParts.Add(Plane.Top);
                }

                if (Plane.Bottom != null)
                {
                    FrameParts.Add(Plane.Bottom);
                }
                
                FrameParts.Add(Plane.Back);
                FrameParts.Add(Plane.Front);

                if (Plane.Seatplate != null)
                {
                    FrameParts.Add(Plane.Seatplate);
                }
            }

            // Remember to delete the cutting beams
            if (!(modelParameters.B1SplitProfile.StartsWith("RHS") || modelParameters.B1SplitProfile.StartsWith("SHS")))
            {
                cutBeamBottom.Delete();
                cutBeamTop.Delete();
            }
            
            // THIS CODE IS FOR THE WALERS //
            // From the bottom of the billboard to the top of the bottom waler
            double bottomWalerSpacing = modelParameters.LowerWalerSpacing;
            // From the top of the billboard to the top of the uppermost waler
            double topWalerSpacing = modelParameters.UpperWalerSpacing;

            // Spacing is from the top edge of the lower waler to the top edge of the waler above
            List<double> walermiddleSpacings = modelParameters.WalersCoordinates;

            // Initialise a z coordinate fot the middle walers
            double walerZcoordinate = boxZStart + bottomWalerSpacing;

            // Create a list for the z-coordinates of the walers so that they can be used in the insertion of the z-brackets (coordinates from bottom to top)
            List<double> zCoordinatesForZBrackets = new List<double> { walerZcoordinate, boxZEnd - topWalerSpacing };

            if (!modelParameters.WalerAuto)
            {
                for (int walerSpacingIndex = 0; walerSpacingIndex <= walermiddleSpacings.Count - 1; walerSpacingIndex++)
                {
                    // Update the z coordinate
                    walerZcoordinate += walermiddleSpacings[walerSpacingIndex];

                    // Add the next waler z-coordinate into the z-coordinate list for the z brackets
                    zCoordinatesForZBrackets.Add(walerZcoordinate);
                }
            }
            else
            {
                // Calculating the distance between the top and bottom waler
                double topBottomWalerSpacing = boxZEnd - boxZStart - bottomWalerSpacing - topWalerSpacing;

                // The number of middle walers to be added
                int numberOfWalers = modelParameters.WalersNumber;

                // Calculate the spacing between the walers
                double walerBeamSpacing = topBottomWalerSpacing / (numberOfWalers + 1);

                // Loop through the number of walers
                for (int i = 0; i < numberOfWalers; i++)
                {
                    // Update the z coordinate
                    walerZcoordinate += walerBeamSpacing;

                    // Add the next waler z-coordinate into the z-coordinate list for the z brackets
                    zCoordinatesForZBrackets.Add(walerZcoordinate);
                }
            }

            List<Beam> Walers = null;
            if (!side2) 
            { 
                Walers = Waler.Walers(
                    zCoordinatesForZBrackets, side2, side4, boxZStart, boxZEnd, OriginOffset, modelParameters
                    ); 
            }



            // GENERATING HATCH
            List<Part> HatchParts = new List<Part>();

            if (HatchFlag)
            {

                // Generate the bottom hatch and save all Part objects created.
                if (side1)
                {
                    Hatch BottomHatch = new Hatch(HatchStart, HatchEnd, OriginOffset.Z + modelParameters.B5BeamDepth, HatchDistanceFromLadder, IsLeftHatch); // NOTE: 200 distance from ladder are just for testing
                    HatchParts.AddRange(BottomHatch.BuildHatch(modelParameters));
                }


                // Generate the top hatch and save all Part objects created.
                if (TopHatchFlag)
                {
                    Hatch TopHatch = new Hatch(HatchStart, HatchEnd, OriginOffset.Z + boxHeight + modelParameters.B2BeamDepth + modelParameters.HeightOffsetTop - modelParameters.HatchBeamWidth/2, HatchDistanceFromLadder, IsLeftHatch);
                    HatchParts.AddRange(TopHatch.BuildHatch(modelParameters));
                }
            }



            // Calculate the new x subcoords for the top bracing to adjust to the hatch.
            List<double> NewDiagonalXSubCoord = new List<double>(xSubCoordinates);

            if (HatchFlag && (Side1 || (!Side1 && !Side3))) // Either a box with bottom split or a box with top and bottom edge.
            {
                if (!side2 && IsLeftHatch) // Left hatches
                {

                    // New x sub coord index 0 adjusted to the center of the right B2 support beam.
                    NewDiagonalXSubCoord[0] = HatchEnd.X + modelParameters.HatchBeamDepth + modelParameters.B2BeamWidth/2 + modelParameters.WeldOffset;

                    if (NumOfFrameRemoved != 0) {
                        if (Side4 && XSubCoordinates.Count == 3) // For NewDiagonalXSubCoord[1] or originally xSubCoordinates[1] ending at a B2 split beam.
                        {
                            NewDiagonalXSubCoord[1] -= Math.Abs(NewDiagonalXSubCoord[1] - NewDiagonalXSubCoord[0]) + modelParameters.B2SplitBeamWidth/2 + modelParameters.WeldOffset;
                        }
                        else
                        {
                            NewDiagonalXSubCoord[1] -= Math.Abs(NewDiagonalXSubCoord[1] - NewDiagonalXSubCoord[0]);
                        }

                    } else // For hatches that is smaller than LED screen width.
                    {
                        NewDiagonalXSubCoord[1] = Math.Abs(NewDiagonalXSubCoord[1] - NewDiagonalXSubCoord[0]);
                    }

                    for (int i = 0; i < NumOfFrameRemoved; i++)
                    {
                        NewDiagonalXSubCoord.RemoveAt(NewDiagonalXSubCoord.Count - 1);
                    }

                } else if (!side4 && !IsLeftHatch) // Right hatches
                {
                    NewDiagonalXSubCoord.RemoveAt(NewDiagonalXSubCoord.Count - 1); // Remove the last x sub coord as that diagonal is included in the hatch.

                    if (NumOfFrameRemoved != 0)
                    {
                        NewDiagonalXSubCoord.RemoveAt(NewDiagonalXSubCoord.Count - 1);
                    }

                    NewDiagonalXSubCoord.Add((HatchStart.X - modelParameters.HatchBeamDepth - modelParameters.B2BeamWidth/2 - BoxOrigin.X) - NewDiagonalXSubCoord.Sum() - modelParameters.WeldOffset);
                }

            }



            // THIS CODE IS FOR DIAGONALS //
            List<double> zCoordinateDiagonals = new List<double> { boxZStart - B1BeamDepth, boxZEnd - BR1BeamDepth };

            // Make the Diagonals
            double separatorBeamWidth;
            double separatorSplitBeamWidth;

            List<Part> DiagonalBracingBeams = new List<Part>();
            for (int i = 0; i < zCoordinateDiagonals.Count; ++i)
            {
                if (i == 0 & !HatchFlag)
                {
                    separatorBeamWidth = B5BeamWidth;
                    separatorSplitBeamWidth = B5SplitBeamWidth;
                }
                else
                {
                    separatorBeamWidth = B2BeamWidth;
                    separatorSplitBeamWidth = B2SplitBeamWidth;
                }

                // Check if the camera is ment to go in this box
                bool Camera = false;
                if (modelParameters.ArmAtTop && !side3 && modelParameters.ArmOffset >= OriginOffset.X && modelParameters.ArmOffset < OriginOffset.X + boxLength && i == 1)
                {
                    Camera = true;
                }
                else if (!modelParameters.ArmAtTop && !side1 && modelParameters.ArmOffset >= OriginOffset.X && modelParameters.ArmOffset < OriginOffset.X + boxLength && i == 0)
                {
                    Camera = true;
                }
                if (modelParameters.NoArm)
                {
                    Camera = false;
                }
                
                /*
                if(!modelParameters.ArmAtTop && modelParameters.FasciaEnabled && !modelParameters.isTwoD)
                {
                    Camera = false;
                }
                */
                
                double diagonalOffset = 0;
                bool EASupports = false;

                if (i == 0)
                {
                    diagonalOffset = modelParameters.DiagonalBottomOffset;
                    EASupports = true;
                }
                else if (i == zCoordinateDiagonals.Count - 1)
                {
                    diagonalOffset = -modelParameters.DiagonalTopOffset;
                }

                
                if (!(side3 && i == zCoordinateDiagonals.Count - 1))
                {
                    DiagonalBracingBeams.AddRange(
                        Diagonal.DiagonalBracing
                        (
                            NewDiagonalXSubCoord,
                            separatorBeamWidth,
                            separatorSplitBeamWidth,
                            OriginOffset,
                            modelParameters,
                            diagonalOffset,
                            zCoordinateDiagonals[i],
                            side2,
                            side4,
                            Camera,
                            EASupports
                        )
                    );
                }
            }

            // THIS CODE IS FOR THE EA SUPPORTS on the WALKWAY //
            //EASupport.EASupports(xSubCoordinates, boxZStart, OriginOffset, modelParameters);

            // THIS CODE IS FOR THE WALKWAY MESH //
            // Get the mesh thickness as a string
            string walkwayMeshThicknessString = Convert.ToString(modelParameters.MeshThickness);

            // Obtain the width of the walkway 
            double walkwayMeshWidth = modelParameters.WalkwayWidth;

            // Convert the walkway width to a string
            string walkwayMeshWidthString = Convert.ToString(walkwayMeshWidth);

            // Concatenate the strings e.g. FM14*615
            string walkwayProfile = "FM" + walkwayMeshThicknessString + "*" + walkwayMeshWidthString;

            // Create enums and offsets for the walkway mesh
            int[] meshEnums = new int[] { 1, 1, 0 };
            double[] meshOffsets = new double[] { 0.0, 0.0, 0.0 };

            // Initiate start and end of walkway
            double xStart2 = 0;
            double xEnd2 = 0;

            // If there's a split then just add the split gap, if not then it's at an edge and needs to start back a bit.
            if (side2)
            {
                xStart2 = modelParameters.BoxGap;
            }
            else
            {
                xStart2 = -C1BeamWidth / 2;
            }

            // Similar to above.
            if (side4)
            {
                xEnd2 = boxLength - modelParameters.BoxGap;
            }
            else
            {
                xEnd2 = boxLength + C1BeamWidth / 2;
            }

            // Create the plate 
            Prefix.name = "MESH";

            Beam Mesh = null;

            // Adjust the mesh so that it doesn't cover the hatch.
            if (HatchFlag && Side1)
            {
                if (IsLeftHatch)
                {
                    Mesh = CreateBeam("FM", Prefix.assembly,
                        new TSG.Point(HatchEnd.X + modelParameters.HatchBeamDepth + modelParameters.B2BeamWidth, B1BeamWidth + modelParameters.WalkwayClearance, boxZStart - differenceb1b5Depth) + OriginOffset,
                        new TSG.Point(xEnd2, B1BeamWidth + modelParameters.WalkwayClearance, boxZStart - differenceb1b5Depth) + OriginOffset,
                        modelParameters.MeshMaterial,
                        walkwayProfile,
                        "1",
                        meshEnums,
                        meshOffsets
                    );
                }
                else // No hatch
                {
                    //MessageBox.Show((HatchStart.X - modelParameters.HatchBeamDepth - modelParameters.B2BeamWidth).ToString());
                    Mesh = CreateBeam("FM", Prefix.assembly,
                        new TSG.Point(xStart2, B1BeamWidth + modelParameters.WalkwayClearance, boxZStart - differenceb1b5Depth) + OriginOffset,
                        new TSG.Point(HatchStart.X - modelParameters.HatchBeamDepth - modelParameters.B2BeamWidth - OriginOffset.X, B1BeamWidth + modelParameters.WalkwayClearance, boxZStart - differenceb1b5Depth) + OriginOffset,
                        modelParameters.MeshMaterial,
                        walkwayProfile,
                        "1",
                        meshEnums,
                        meshOffsets
                    );
                }
            } else
            {
                Mesh = CreateBeam("FM", Prefix.assembly,
                    new TSG.Point(xStart2, B1BeamWidth + modelParameters.WalkwayClearance, boxZStart - differenceb1b5Depth) + OriginOffset,
                    new TSG.Point(xEnd2, B1BeamWidth + modelParameters.WalkwayClearance, boxZStart - differenceb1b5Depth) + OriginOffset,
                    modelParameters.MeshMaterial,
                    walkwayProfile,
                    "1",
                    meshEnums,
                    meshOffsets
                );
            }


            Prefix.name = "BEAM";

            // THIS CODE IS FOR THE Z BRACKETS // 
            List<Part> ZBrackets = ZBracket.ZBrackets(xSubCoordinates, OriginOffset, planes, zCoordinatesForZBrackets, modelParameters);
            

            // THIS CODE IS FOR THE HORIZONTAL RAILINGS AND WALKWAY //
            List<Part> HorizontalRailingsBeams = new List<Part>();

            List<Part> WalkWayList = new List<Part>();

            if (walkwaySubList.Count == 0)
            {
                double railingsZStart = 0;
                double railingsZEnd = boxHeight;
                HorizontalRailingsBeams.AddRange(HorizontalRailing.HorizontalRailings(xSubCoordinates, side2, side4, OriginOffset, StructureAutoRadio, modelParameters, railingsZStart, railingsZEnd));
            }
            else
            {
                walkwaySubList.Insert(walkwaySubList.Count, boxHeight);
                double walkwayZ;
                double railingsZStart;
                double railingsZEnd;

                for (int index = 0; index < walkwaySubList.Count - 1; index++)
                {
                    walkwayZ = walkwaySubList[index]; // Relative to OriginOffset
                    railingsZStart = walkwaySubList[index];
                    railingsZEnd = walkwaySubList[index + 1] - railingsZStart; // Needs to be relative to railingsZStart

                    WalkWayList.AddRange(Walkway.Walkways(walkwayZ, xSubCoordinates, modelParameters, OriginOffset, side2, side4, boxLength));
                    HorizontalRailingsBeams.AddRange(HorizontalRailing.HorizontalRailings(xSubCoordinates, side2, side4, OriginOffset, StructureAutoRadio, modelParameters, railingsZStart, railingsZEnd));
                   
                    // Don't Forget the bottom horizontal railings.
                    if (index == 0)
                    {
                        HorizontalRailingsBeams.AddRange(HorizontalRailing.HorizontalRailings(xSubCoordinates, side2, side4, OriginOffset, StructureAutoRadio, modelParameters, 0, walkwaySubList[0]));
                    }
                }
                walkwaySubList.RemoveAt(walkwaySubList.Count - 1);
            }

            // INSERT SIDE BRACING
            List<Part> SideBraces = new List<Part>();

            List<double> SideCoords = new List<double>  { 0.0, modelParameters.BillboardLength };

            // Side bracing on LEFT side
            SideBraces.AddRange(Diagonal.InstallSideBracing(HorizontalRailingsBeams,
            modelParameters,
            boxLength,
            boxHeight,
            OriginOffset,
            SideCoords[0],
            side1,
            side3
            ));

            // Side bracing on RIGHT side
            SideBraces.AddRange(Diagonal.InstallSideBracing(HorizontalRailingsBeams,
            modelParameters,
            boxLength,
            boxHeight,
            OriginOffset,
            SideCoords[1],
            side1,
            side3
            ));


            // Ladder
            List<double> RailingHeights = new List<double>();
            foreach(Beam beam in HorizontalRailingsBeams)
            {
                RailingHeights.Add(beam.StartPoint.Z);
            }
            RailingHeights = RailingHeights.Distinct().ToList();

            // Based on the ladder mode, create and build the ladder parts
            List<Part> LadderParts = new List<Part>();

            // Extracting B2 Beam parameters from the ModelParameters object
            string[] B2Beamparameter = modelParameters.B2Profile.Split('*');
            double B2BeamW = double.Parse(B2Beamparameter[1]);

            // Extracting C1 Beam parameters from the ModelParameters object
            string[] C1Beamparameter = modelParameters.C1Profile.Split('*');
            double C1BeamW = double.Parse(C1Beamparameter[1]);
            //MessageBox.Show(C1BeamW.ToString());
            switch (modelParameters.LadderMode)
            {
                // Ladder Mode 0 - Check if side2 is not active
                case 0:
                    if (!side2)
                    {
                        // Calculating the start and end points for the ladder
                        TSG.Point startpoint = new TSG.Point(modelParameters.LadderOffsetSide + modelParameters.LadderRailWidth/2 ,
                            modelParameters.BillboardDepth - modelParameters.LadderOffsetBack - modelParameters.B1BeamDepth - modelParameters.LadderRailLength/2,
                            boxZStart + BoxOrigin.Z + modelParameters.MeshThickness + modelParameters.WeldOffset );
                        
                        TSG.Point endpoint = new TSG.Point(modelParameters.LadderOffsetSide + modelParameters.LadderRailWidth/2 ,
                            modelParameters.BillboardDepth - modelParameters.LadderOffsetBack - modelParameters.B1BeamDepth - modelParameters.LadderRailLength/2,
                            boxZEnd + BoxOrigin.Z);
                        LadderBuilder ladderBuilder = new LadderBuilder(modelParameters);
                       
                        LadderParts = ladderBuilder.BuildLadder(startpoint, endpoint, RailingHeights);
                    }
                    break;
                // Ladder Mode 1 - Check if side4 is not active
                case 1:
                    if (!side4)
                    {
                        TSG.Point startpoint = new TSG.Point(modelParameters.BillboardLength - modelParameters.LadderWidth  - modelParameters.LadderOffsetSide - modelParameters.B2BeamWidth + modelParameters.LadderRailWidth/2,
                            modelParameters.BillboardDepth - modelParameters.LadderOffsetBack - modelParameters.B1BeamDepth - modelParameters.LadderRailLength / 2,
                            boxZStart + BoxOrigin.Z + modelParameters.MeshThickness + modelParameters.WeldOffset) ; 
                        TSG.Point endpoint = new TSG.Point(modelParameters.BillboardLength - modelParameters.LadderWidth  - modelParameters.LadderOffsetSide - modelParameters.B2BeamWidth + modelParameters.LadderRailWidth/2,
                            modelParameters.BillboardDepth - modelParameters.LadderOffsetBack - modelParameters.B1BeamDepth - modelParameters.LadderRailLength / 2,
                            boxZEnd + BoxOrigin.Z);
                        LadderBuilder ladderBuilder = new LadderBuilder(modelParameters);
               
                        LadderParts = ladderBuilder.BuildLadder(startpoint, endpoint, RailingHeights);
                    }
                    break;
                case 2:
                    break;
            }

            List<Part> RearDoorParts = new List<Part>();
            List<double> DoorCrossRailling = new List<double>();
            List<Beam> BeamCutted = new List<Beam>();
            bool DoorValid = false;
            bool LeftDoorFrameReplace = false;
            bool RightDoorFrameReplace = false;
            double DoorStartX =  modelParameters.DoorOffsetLeft - modelParameters.C1BeamWidth/2;
            double DoorWidth = modelParameters.DoorWidth;
            double DoorEndX = DoorStartX + DoorWidth - modelParameters.DoorFrameHeight;

            // Check is user enable the door or not
            if (modelParameters.DoorON)
            {
                // Check if the user input is within the range of the billboard
                if ((xStart + OriginOffset.X) <= DoorStartX && DoorEndX <= (xEnd + OriginOffset.X))
                {
                    // Check is the box is the lowest box or not
                    if (!side1)
                    {
                        // Check the correct position and if there is a B3 beam is heigher than the setted min height
                        foreach (Beam HorizontalRailing in HorizontalRailingsBeams)
                        {
                            // Check the door position for frame replacing
                            if (DoorEndX == (HorizontalRailing.EndPoint.X + modelParameters.WeldOffset + modelParameters.C1BeamWidth - modelParameters.DoorFrameHeight))
                            {
                                RightDoorFrameReplace = true;
                            }
                            if (DoorStartX == (HorizontalRailing.StartPoint.X - modelParameters.WeldOffset - modelParameters.C1BeamWidth))
                            {
                                LeftDoorFrameReplace = true;
                            }
                            if ((HorizontalRailing.StartPoint.X <= DoorStartX && DoorEndX <= HorizontalRailing.EndPoint.X)
                                || LeftDoorFrameReplace || RightDoorFrameReplace)
                            {

                                // The height of the door higher than setting height
                                if ((HorizontalRailing.StartPoint.Z - boxZStart) < modelParameters.DoorHeight)
                                {
                                    BeamCutted.Add(HorizontalRailing);
                                }

                                if ((HorizontalRailing.StartPoint.Z - boxZStart) >= modelParameters.DoorHeight)
                                {
                                    RearDoor RearDoor = new RearDoor(modelParameters,
                                        boxZStart,
                                        HorizontalRailing.StartPoint.Z,
                                        BeamCutted,
                                        LeftDoorFrameReplace,
                                        RightDoorFrameReplace);
                                    RearDoorParts = RearDoor.RearDoorBuilder(DoorStartX, DoorEndX);

                                    DoorValid = true;

                                    modelParameters.DoorON = false;

                                    break;
                                }
                            }
                            LeftDoorFrameReplace = false;
                            RightDoorFrameReplace = false;


                        }

                    }
                }
                if (!DoorValid) { MessageBox.Show("Door insertion failed. Door overlaped with column or not enough height"); }
            }
            

            // ASSEMBLY ASSEMBLING:

            // Add the B1 beams into the assembly.
            _boxAssembly = B1Beam1.GetAssembly();
            _boxAssembly.SetMainPart(B1Beam1);

            Assembly B1Beam2Assembly = B1Beam2.GetAssembly();
            B1Beam2Assembly.SetMainPart(B1Beam2);

            Assembly B1Beam3Assembly = B1Beam3.GetAssembly();
            B1Beam3Assembly.SetMainPart(B1Beam3);

            Assembly B1Beam4Assembly = B1Beam4.GetAssembly();
            B1Beam4Assembly.SetMainPart(B1Beam4);

            _boxAssembly.Add(B1Beam2Assembly);
            _boxAssembly.Add(B1Beam3Assembly);
            _boxAssembly.Add(B1Beam4Assembly);

            /*// Add the walkway mesh into the assembly.
            Assembly MeshAssembly = Mesh.GetAssembly();
            MeshAssembly.SetMainPart(Mesh);

            _boxAssembly.Add(MeshAssembly);

            // Add the wahler beams into the assembly. (Walers are not included in assemblies)
            //if (Walers != null)
            //{
            //    //AddBeamsToAssembly(Walers);
            //}
            
            // Add the beams created in HorizontalRailings to the assembly.
            AddBeamsToAssembly(HorizontalRailingsBeams);

            if (WalkWayList.Count != 0)
            {
                AddBeamsToAssembly(WalkWayList);
            }


            // Add the beams created for diagonal bracing to the assembly.
            AddBeamsToAssembly(DiagonalBracingBeams);*/

            // Add the beams created for side bracing to the assembly.
            AddBeamsToAssembly(SideBraces);

            // Add the frame parts to the assembly.
            AddBeamsToAssembly(FrameParts);

            // Add the ladder parts to the assembly.
            AddBeamsToAssembly(LadderParts);

            // Add the Part objects created for the hatch.
            AddBeamsToAssembly(HatchParts);

            AddBeamsToAssembly(RearDoorParts);

            if (!_boxAssembly.Modify())
            {
                MessageBox.Show("Box assembly failed!");
            }
        }

        /// <summary>
        /// Method to create a beam model on Tekla Structures.
        /// </summary>
        /// <param name="partprefix"> The part prefix as string
        /// <param name="assprefix"> The part prefix as string
        /// <param name="startPos"> 3D coordinates of the beam's starting point (mm)</param>
        /// <param name="endPos"> 3D coordinates of the beam's ending point (mm)</param>
        /// <param name="material"> The beam's material</param>
        /// <param name="profile"> The beam's profile</param>
        /// <param name="beamClass"> The beam's class e.g. beamClass : "1" </param>
        /// <param name="enums"> Array in the form [Position.DepthEnum, Position.PlaneEnum, Position.RotationEnum] </param>
        /// <param name="offsets"> A list of doubles, indicating the offsets of the beams</param>
        /// <param name="beamFinish"> The desired beam profile finish</param>
        /// <param name="modelParameters"> The parameters of the model</param>
        /// <param name="parentProfile"> The profile of the parent structure</param>
        /// <param name="cutOrigin"> Cut origin
        /// 
        /// 
        /// <returns>Returns a created and inserted beam</returns>
        public static Beam CreateBeam(string partprefix, string assprefix,TSG.Point startPos, TSG.Point endPos, string material, string profile, string beamClass, int[] enums, double[] offsets,string beamFinish = "", ModelParameters modelParameters = null, string parentProfile = "", TSG.Point cutOrigin = null)
        {

            // Beam properties
            Beam beam = new Beam(startPos, endPos);

            beam.PartNumber = new NumberingSeries(partprefix, 1);
            beam.AssemblyNumber = new NumberingSeries(assprefix, 1);
            beam.Name = Prefix.name;

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
            beam.Finish = beamFinish;

            if (!beam.Insert()) { Console.WriteLine("Insertion of beam failed."); }

            if (modelParameters != null)
            {
                GalHole.galHole(beam, modelParameters, enums, parentProfile);
            }

            return beam;
        }

        private void AddBeamsToAssembly(List<Part> Parts)
        {
            foreach (Part P in Parts)
            {
                Assembly PartAssembly = P.GetAssembly();
                PartAssembly.SetMainPart(P);

                _boxAssembly.Add(PartAssembly);
            }
        }
    }
}