using System;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Represents a 3D fascia box that is located under the billboard
    /// </summary>
    public class _3DFascia
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
        /// The constructor for a 3D fascia box, generating the model when called.
        /// </summary>
        /// <param name="zSubCoordinates">The vertical height of where the box is constructed</param>
        /// <param name="xSubCoordinates">The horizontal distances of where vertical columns go</param>
        /// <param name="boxHeight">The height of the fascia box</param>
        /// <param name="boxLength">The length of the fascia box</param>
        /// <param name="OriginOffset">A TSG point reference for the position of the box</param>
        /// <param name="side1">Indicates if front is selected</param>
        /// <param name="side2">Indicates if left is selected</param>
        /// <param name="side3">Indicates if back is selected</param>
        /// <param name="side4">Indicates if right is selected</param>
        /// <param name="structureAutoRadio">Used to indicate to create intermediate horizontal railing supports</param>
        /// <param name="modelParameters">The parameters of the model</param>
        public _3DFascia
            (
            List<double> zSubCoordinates,
            List<double> xSubCoordinates,
            double boxHeight,
            double boxLength,
            TSG.Point OriginOffset,
            bool side1,
            bool side2,
            bool side3,
            bool side4,
            bool structureAutoRadio,
            ModelParameters modelParameters
            )
        {
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
            double billboardDepth = modelParameters.BillboardDepth;

            // Figure out the starting and end height of the frame
            double boxZStart;
            double boxZEnd;

            boxZStart = - modelParameters.FasciaBoxHeight;
            boxZEnd =  - modelParameters.HeightOffsetTop - B1BeamDepth;


            // Check to see if in split.
            double xStart = 0;
            double xEnd = 0;
            if (side2)
            {
                xStart = modelParameters.BoxGap;
            }
            else if (!side2)
            {
                xStart = -C1BeamWidth / 2;
            }

            if (side4)
            {
                xEnd = boxLength - modelParameters.BoxGap;
            }
            else if (!side4)
            {
                xEnd = boxLength + C1BeamWidth / 2;
            }

            // Create the Bottom Beam with which we're going to cut the front beams. But only if the B1 Split Beam is an EA beam.
            PolyBeam cutBeamBottom = new PolyBeam();
            PolyBeam cutBeamTop = new PolyBeam();

            if (modelParameters.B1SplitProfile.StartsWith("EA"))
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
                            boxZStart - B1BeamDepth + C1BeamDepth + modelParameters.WeldOffset
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

                if (!cutBeamBottom.Insert())
                {
                    Console.WriteLine("Insertion of beam failed.");
                }

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
                            boxZEnd - C1BeamDepth - modelParameters.WeldOffset
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

                if (!cutBeamTop.Insert())
                {
                    Console.WriteLine("Insertion of beam failed.");
                }
            }

            // Create the B1 Horizontal Beams
            // Create the enums and the offsets for the b1 beams
            int[] b1Enums = new int[] { 2, 0, 0 };
            double[] b1Offsets = new double[] { 0.0, 0.0, 0.0 };

            int[] B1SplitEnumsBot;
            double[] B1SplitOffsetsBot;
            TSG.Point startPos = new TSG.Point();
            TSG.Point endPos = new TSG.Point();

            // Check if at a split
            if (Side1)
            {
                // Check if B1Split is an RHS or EA Beam
                if (modelParameters.B1SplitProfile.StartsWith("EA"))
                {
                    // Create the enums and the offsets for the EA beams on the bottom
                    B1SplitEnumsBot = new int[] { 2, 0, 1 };
                    B1SplitOffsetsBot = new double[] { 0.0, 0.0, 0.0 };

                    startPos = new TSG.Point(xStart, 0.5 * B1BeamWidth, boxZStart) + OriginOffset;
                    endPos = new TSG.Point(xEnd, 0.5 * B1BeamWidth, boxZStart) + OriginOffset;
                }
                else
                {
                    // Create the enums and the offsets for the RHS beams on the bottom
                    B1SplitEnumsBot = new int[] { 1, 0, 0 };
                    B1SplitOffsetsBot = new double[] { 0.0, 0.0, 0.0 };

                    startPos = new TSG.Point(xStart, 0.5 * B1BeamWidth, boxZStart - B1BeamDepth) + OriginOffset;
                    endPos = new TSG.Point(xEnd, 0.5 * B1BeamWidth, boxZStart - B1BeamDepth) + OriginOffset;
                }

                B1Beam1 = Box.CreateBeam(Prefix.part,Prefix.assembly,
                    startPos,
                    endPos,
                    modelParameters.B1SplitMaterial,
                    modelParameters.B1SplitProfile,
                    "11",
                    B1SplitEnumsBot,
                    B1SplitOffsetsBot
                );
            }
            else
            {
                B1Beam1 = Box.CreateBeam(Prefix.part,Prefix.assembly,
                new TSG.Point(xStart, 0.5 * B1BeamWidth, boxZStart) + OriginOffset,
                new TSG.Point(xEnd, 0.5 * B1BeamWidth, boxZStart) + OriginOffset,
                modelParameters.B1Material,
                modelParameters.B1Profile,
                "11",
                b1Enums,
                b1Offsets
                );
            }

            B1Beam2 = Box.CreateBeam(Prefix.part,Prefix.assembly,
                new TSG.Point(xStart, billboardDepth - 0.5 * B1BeamWidth, boxZStart) + OriginOffset,
                new TSG.Point(xEnd, billboardDepth - 0.5 * B1BeamWidth, boxZStart) + OriginOffset,
                modelParameters.B1Material,
                modelParameters.B1Profile,
                "11",
                b1Enums,
                b1Offsets
            );

            int[] B1SplitEnumsTop;
            double[] B1SplitOffsetsTop;

            // Check if at a split
            if (Side3)
            {
                // Check if B1Split is an RHS or EA Beam
                if (modelParameters.B1SplitProfile.StartsWith("EA"))
                {
                    // Create the enums and the offsets for the EA beams on the top
                    B1SplitEnumsTop = new int[] { 2, 0, 2 };
                    B1SplitOffsetsTop = new double[] { 0.0, 0.0, 0.0 };
                }
                else
                {
                    // Create the enums and the offsets for the RHS beams on the top
                    B1SplitEnumsTop = new int[] { 2, 0, 0 };
                    B1SplitOffsetsTop = new double[] { 0.0, 0.0, 0.0 };
                }

                B1Beam3 = Box.CreateBeam(Prefix.part,Prefix.assembly,
                new TSG.Point(xStart, 0.5 * B1BeamWidth, boxZEnd) + OriginOffset,
                new TSG.Point(xEnd, 0.5 * B1BeamWidth, boxZEnd) + OriginOffset,
                modelParameters.B1SplitMaterial,
                modelParameters.B1SplitProfile,
                "11",
                B1SplitEnumsTop,
                B1SplitOffsetsTop
                );
            }
            else
            {
                B1Beam3 = Box.CreateBeam(Prefix.part,Prefix.assembly,
                new TSG.Point(xStart, 0.5 * B1BeamWidth, boxZEnd) + OriginOffset,
                new TSG.Point(xEnd, 0.5 * B1BeamWidth, boxZEnd) + OriginOffset,
                modelParameters.B1Material,
                modelParameters.B1Profile,
                "11",
                b1Enums,
                b1Offsets
                );
            }

            B1Beam4 = Box.CreateBeam(Prefix.part,Prefix.assembly,
                new TSG.Point(xStart, billboardDepth - 0.5 * B1BeamWidth, boxZEnd) + OriginOffset,
                new TSG.Point(xEnd, billboardDepth - 0.5 * B1BeamWidth, boxZEnd) + OriginOffset,
                modelParameters.B1Material,
                modelParameters.B1Profile,
                "11",
                b1Enums,
                b1Offsets
            );

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
            modelParameters.BuildSeatingPlate = false;
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
                Frame plane = new Frame(splitPlaneRight, point1, point2, point3, point4, planeType, side1, side3, modelParameters, cutBeamBottom, cutBeamTop);
                planes.Add(plane);
            }

            this.Planes = planes;
            // Remember to delete the cutting beams
            if (modelParameters.B1SplitProfile.StartsWith("EA"))
            {
                cutBeamBottom.Delete();
                cutBeamTop.Delete();
            }

            // THIS CODE IS FOR DIAGONALS //
            List<double> zCoordinateDiagonals = new List<double> { boxZStart - B1BeamDepth, boxZEnd - BR1BeamDepth };

            // Make the Diagonals
            double separatorBeamWidth;
            double separatorSplitBeamWidth;

            for (int i = 0; i < zCoordinateDiagonals.Count; ++i)
            {
                if (i == 0)
                {
                    separatorBeamWidth = B5BeamWidth;
                    separatorSplitBeamWidth = B5SplitBeamWidth;
                }
                else
                {
                    separatorBeamWidth = B2BeamWidth;
                    separatorSplitBeamWidth = B2SplitBeamWidth;
                }

                // Check if the camera is meant to go in this box
                bool Camera = false;

                /*
                if (!modelParameters.ArmAtTop)
                {
                    Camera = true;
                }
                */

                double diagonalOffset = 0;
                bool EASupports = false;
                if (i == 0)
                {
                    diagonalOffset = modelParameters.DiagonalBottomOffset;
                    
                }
                else if (i == zCoordinateDiagonals.Count - 1)
                {
                    diagonalOffset = -modelParameters.DiagonalTopOffset;
                }

                if (!(side3 && i == zCoordinateDiagonals.Count - 1))
                {
                    Diagonal.DiagonalBracing(
                    xSubCoordinates,
                    separatorBeamWidth,
                    separatorSplitBeamWidth,
                    OriginOffset,
                    modelParameters,
                    diagonalOffset,
                    zCoordinateDiagonals[i],
                    side2,
                    side4,
                    Camera,
                    EASupports);
                }
            }
        }
    }
}