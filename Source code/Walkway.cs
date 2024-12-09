using System;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Class for holding methods for creating mid-walkways
    /// </summary>
    public class Walkway
    {
        /// <summary>
        /// Walkway constructor
        /// </summary>
        /// <param name="walkwayZ">Height of the mid-walkway (offset from bottom)</param>
        /// <param name="xSubCoordinates">Sub-list of frame X-coordinates (for the current box)</param>
        /// <param name="modelParameters">Model parameters</param>
        /// <param name="OriginOffset">Origin point of the current box</param>
        /// <param name="side2">Whether the left side of the box is at a split, true if split</param>
        /// <param name="side4">Whether the right side of the box is at a split, true if split</param>
        /// <param name="boxlength">Length of the current box</param>
        ///
        /// <returns> List of Beam objects created </returns>
        public static List<Beam> Walkways
            (
            double walkwayZ,
            List<double> xSubCoordinates,
            ModelParameters modelParameters,
            TSG.Point OriginOffset,
            bool side2,
            bool side4,
            double boxlength
            )
        {
            List<Beam> BeamsCreated = new List<Beam>();

            double B3BeamWidth = modelParameters.B3BeamWidth;
            double B1BeamWidth = modelParameters.B1BeamWidth;
            double B1BeamDepth = modelParameters.B1BeamDepth;
            double B2BeamWidth = modelParameters.B2BeamWidth;
            double BR1BeamDepth = modelParameters.BR1BeamDepth;
            double C1BeamDepth = modelParameters.C1BeamDepth;
            double C1BeamWidth = modelParameters.C1BeamWidth;
            double EABeamDepth = modelParameters.EABeamDepth;
            double BillboardDepth = modelParameters.BillboardDepth;
            double weldOffset = modelParameters.WeldOffset;

            // HORIZONTAL RAILINGS //

            // Initialise the spacing variables for the horisztonal railings 
            double xRailingSpacingCurrent = 0;

            // Create the enums and offsets for the railings
            int[] railingEnums = new int[] { 2, 0, 2 };
            double[] railingOffsets = new double[] { 0.0, 0.0, 90 };

            // Initiate start and end positions
            TSG.Point startPos;
            TSG.Point endPos;

            string Material;
            string Profile;

            for (int indexXcoordinates = 0; indexXcoordinates < xSubCoordinates.Count - 1; indexXcoordinates++)
            {
                // Calculate the current x coordinate and the next x coordinate using the spacings 
                xRailingSpacingCurrent += xSubCoordinates[indexXcoordinates];
                double xRailingSpacingNext = xRailingSpacingCurrent + xSubCoordinates[indexXcoordinates + 1];

                // Creates B2 short beams allong the underside of the walkway.
                // Differentiate between the middle and ends
                if (indexXcoordinates == 0)
                {
                    // Differentiate between a split and an edge.
                    if (side2) // If it is a split then do some alignment math.
                    {
                        startPos = new TSG.Point(
                            xRailingSpacingCurrent - modelParameters.BoxGap,
                            C1BeamDepth + weldOffset,
                            walkwayZ - modelParameters.MeshThickness)
                            + OriginOffset;

                        endPos = new TSG.Point(
                            xRailingSpacingCurrent - modelParameters.BoxGap,
                            BillboardDepth - C1BeamDepth - weldOffset,
                            walkwayZ - modelParameters.MeshThickness)
                            + OriginOffset;

                        Material = modelParameters.B2Material;
                        Profile = modelParameters.B2SplitProfile;
                    }
                    else // If its an edge then do something other alignment math.
                    {
                        startPos = new TSG.Point(
                            xRailingSpacingCurrent + B2BeamWidth - C1BeamWidth / 2,
                            C1BeamDepth + weldOffset,
                            walkwayZ - modelParameters.MeshThickness)
                            + OriginOffset;

                        endPos = new TSG.Point(
                            xRailingSpacingCurrent + B2BeamWidth - C1BeamWidth / 2,
                            BillboardDepth - C1BeamDepth - weldOffset,
                            walkwayZ - modelParameters.MeshThickness)
                            + OriginOffset;

                        Material = modelParameters.B2Material;
                        Profile = modelParameters.B2Profile;
                    }
                    BeamsCreated.Add(
                        Box.CreateBeam(Prefix.part, Prefix.assembly,
                            startPos,
                            endPos,
                            Material,
                            Profile,
                            "4",
                            railingEnums,
                            railingOffsets

                        )
                    );
                }
                else // middle brackets
                {
                    startPos = new TSG.Point(
                        xRailingSpacingCurrent + B2BeamWidth / 2,
                        C1BeamDepth + weldOffset,
                        walkwayZ - modelParameters.MeshThickness)
                        + OriginOffset;

                    endPos = new TSG.Point(
                        xRailingSpacingCurrent + B2BeamWidth / 2,
                        BillboardDepth - C1BeamDepth - weldOffset,
                        walkwayZ - modelParameters.MeshThickness)
                        + OriginOffset;

                    
                    BeamsCreated.Add(
                        Box.CreateBeam(Prefix.part,Prefix.assembly,
                            startPos,
                            endPos,
                            modelParameters.B2Material,
                            modelParameters.B2Profile,
                            "4",
                            railingEnums,
                            railingOffsets
                        )
                    );

                    // Don't forget to make the last railing.
                    if (indexXcoordinates == xSubCoordinates.Count - 2)
                    {
                        // Differentiate between a split and an edge.
                        if (side4) // If it is a split then do some alignment math.
                        {
                            startPos = new TSG.Point(
                                xRailingSpacingNext + C1BeamWidth / 2 + modelParameters.BoxGap,
                                C1BeamDepth + weldOffset,
                                walkwayZ - modelParameters.MeshThickness)
                                + OriginOffset;

                            endPos = new TSG.Point(
                                xRailingSpacingNext + C1BeamWidth / 2 + modelParameters.BoxGap,
                                BillboardDepth - C1BeamDepth - weldOffset,
                                walkwayZ - modelParameters.MeshThickness)
                                + OriginOffset;

                            Material = modelParameters.B2Material;
                            Profile = modelParameters.B2SplitProfile;
                        }
                        else // If its an edge then do something other alignment math.
                        {
                            startPos = new TSG.Point(
                                xRailingSpacingNext + C1BeamWidth / 2,
                                C1BeamDepth + weldOffset,
                                walkwayZ - modelParameters.MeshThickness)
                                + OriginOffset;

                            endPos = new TSG.Point(
                                xRailingSpacingNext + C1BeamWidth / 2,
                                BillboardDepth - C1BeamDepth - weldOffset,
                                walkwayZ - modelParameters.MeshThickness)
                                + OriginOffset;

                            Material = modelParameters.B2Material;
                            Profile = modelParameters.B2Profile;
                        }

                        BeamsCreated.Add(
                            Box.CreateBeam(Prefix.part, Prefix.assembly,
                                startPos,
                                endPos,
                                Material,
                                Profile,
                                "4",
                                railingEnums,
                                railingOffsets
                            )
                        );
                    }
                }

                // Reset start and end offset.
                double startOffset = C1BeamWidth / 2;
                double endOffset = C1BeamWidth / 2;

                if (side2 && indexXcoordinates == 0)
                {
                    startOffset = modelParameters.C1SplitBeamWidth + modelParameters.BoxGap;
                }
                if (side4 && indexXcoordinates == xSubCoordinates.Count - 2)
                {
                    endOffset = modelParameters.C1SplitBeamWidth + modelParameters.BoxGap;
                }

                // State the normal start and end positions for the back horizontal rail.
                startPos = new TSG.Point(
                        xRailingSpacingCurrent + weldOffset + startOffset,
                        BillboardDepth - B1BeamWidth,
                        walkwayZ) + OriginOffset;

                endPos = new TSG.Point(
                        xRailingSpacingNext - weldOffset - endOffset,
                        BillboardDepth - B1BeamWidth,
                        walkwayZ) + OriginOffset;

                // Insert the beams
                BeamsCreated.Add(
                    Box.CreateBeam(Prefix.part, Prefix.assembly,
                        startPos,
                        endPos,
                        modelParameters.B1Material,
                        modelParameters.B1Profile,
                        "11",
                        railingEnums,
                        railingOffsets
                    )
                );

                // State the normal start and end positions for the front horizontal rail.
                startPos = new TSG.Point(
                        xRailingSpacingCurrent + weldOffset + startOffset,
                        0,
                        walkwayZ) + OriginOffset;

                endPos = new TSG.Point(
                        xRailingSpacingNext - weldOffset - endOffset,
                        0,
                        walkwayZ) + OriginOffset;

                // Insert the beams
                BeamsCreated.Add(
                    Box.CreateBeam(Prefix.part,Prefix.assembly,
                        startPos,
                        endPos,
                        modelParameters.B1Material,
                        modelParameters.B1Profile,
                        "11",
                        railingEnums,
                        railingOffsets
                    )
                );
            }

            double separatorBeamWidth = modelParameters.B2BeamWidth;
            double separatorSplitBeamWidth = modelParameters.B2SplitBeamWidth;
            double diagonalOffset = 0;//- modelParameters.DiagonalTopOffset;
            double zCoordinateDiagonals = walkwayZ - Math.Abs(BR1BeamDepth - B1BeamDepth) / 2;
            bool Camera = false;
            bool EASupports = true;

            // Create Diagonal Bracings with EA Supports
            BeamsCreated.AddRange(
                Diagonal.DiagonalBracing(
                    xSubCoordinates,
                    separatorBeamWidth,
                    separatorSplitBeamWidth,
                    OriginOffset,
                    modelParameters,
                    diagonalOffset,
                    zCoordinateDiagonals - modelParameters.MeshThickness,
                    side2,
                    side4,
                    Camera,
                    EASupports
                )
            );

            string walkwayMeshThicknessString = Convert.ToString(modelParameters.MeshThickness);

            // Obtain the width of the walkway 
            double walkwayMeshWidth = modelParameters.WalkwayWidth;

            // Convert the walkway width to a string
            string walkwayMeshWidthString = Convert.ToString(walkwayMeshWidth);

            // Concatenate the strings e.g. MESH14*615
            string walkwayProfile = "MESH" + walkwayMeshThicknessString + "*" + walkwayMeshWidthString;

            // Create enums and offsets for the walkway mesh
            int[] meshEnums = new int[] { 1, 1, 0 };
            double[] meshOffsets = new double[] { 0.0, 0.0, 0.0 };

            // Create the plate 
            TSG.Point plateStartPos = new TSG.Point();
            TSG.Point plateEndPos = new TSG.Point();

            if (side4)
            {
                plateEndPos = new TSG.Point(
                       boxlength - modelParameters.BoxGap,
                       B1BeamWidth + modelParameters.WalkwayClearance,
                       walkwayZ - Math.Abs(BR1BeamDepth - B1BeamDepth) / 2 - modelParameters.MeshThickness + EABeamDepth) + OriginOffset;
            }
            else
            {
                plateEndPos = new TSG.Point(
                        boxlength + B3BeamWidth / 2,
                        B1BeamWidth + modelParameters.WalkwayClearance,
                        walkwayZ - Math.Abs(BR1BeamDepth - B1BeamDepth) / 2 - modelParameters.MeshThickness + EABeamDepth) + OriginOffset;
            }

            if (side2)
            {
                plateStartPos = new TSG.Point(
                        xSubCoordinates[0] + modelParameters.BoxGap,
                        B1BeamWidth + modelParameters.WalkwayClearance,
                        walkwayZ - Math.Abs(BR1BeamDepth - B1BeamDepth) / 2 - modelParameters.MeshThickness + EABeamDepth) + OriginOffset;
            }
            else
            {
                plateStartPos = new TSG.Point(
                        xSubCoordinates[0] - B2BeamWidth / 2,
                        B1BeamWidth + modelParameters.WalkwayClearance,
                        walkwayZ - Math.Abs(BR1BeamDepth - B1BeamDepth) / 2 - modelParameters.MeshThickness + EABeamDepth) + OriginOffset;

            }

            BeamsCreated.Add(
                Box.CreateBeam(Prefix.part, Prefix.assembly,
                    plateStartPos,
                    plateEndPos,
                    modelParameters.MeshMaterial,
                    walkwayProfile,
                    "1",
                    meshEnums,
                    meshOffsets
                )
            );
           
            return BeamsCreated;
        }

        /// <summary>
        /// Walkway constructor
        /// </summary>
        /// <param name="walkwayZ">Height of the mid-walkway (offset from bottom)</param>
        /// <param name="xSubCoordinates">Sub-list of frame X-coordinates (for the current box)</param>
        /// <param name="modelParameters">Model parameters</param>
        /// <param name="OriginOffset">Origin point of the current box</param>
        /// <param name="side2">Whether the left side of the box is at a split, true if split</param>
        /// <param name="side4">Whether the right side of the box is at a split, true if split</param>
        /// <param name="boxlength">Length of the current box</param>
        /// TODO Descirption for return and the hatch stuffs
        public static List<Beam> WalkwaysWithHatch
            (
            double walkwayZ,
            List<double> xSubCoordinates,
            ModelParameters modelParameters,
            TSG.Point OriginOffset,
            bool side2,
            bool side4,
            double boxlength,
            TSG.Point HatchStart,
            TSG.Point HatchEnd
            )
        {
            List<Beam> BeamsCreated = new List<Beam>();

            double B3BeamWidth = modelParameters.B3BeamWidth;
            double B1BeamWidth = modelParameters.B1BeamWidth;
            double B1BeamDepth = modelParameters.B1BeamDepth;
            double B2BeamWidth = modelParameters.B2BeamWidth;
            double BR1BeamDepth = modelParameters.BR1BeamDepth;
            double C1BeamDepth = modelParameters.C1BeamDepth;
            double C1BeamWidth = modelParameters.C1BeamWidth;
            double EABeamDepth = modelParameters.EABeamDepth;
            double BillboardDepth = modelParameters.BillboardDepth;
            double weldOffset = modelParameters.WeldOffset;

            // HORIZONTAL RAILINGS //

            // Initialise the spacing variables for the horisztonal railings 
            double xRailingSpacingCurrent = 0;

            // Create the enums and offsets for the railings
            int[] railingEnums = new int[] { 2, 0, 2 };
            double[] railingOffsets = new double[] { 0.0, 0.0, 90 };

            // Initiate start and end positions
            TSG.Point startPos;
            TSG.Point endPos;

            string Material;
            string Profile;

            for (int indexXcoordinates = 0; indexXcoordinates < xSubCoordinates.Count - 1; indexXcoordinates++)
            {
                // Calculate the current x coordinate and the next x coordinate using the spacings 
                xRailingSpacingCurrent += xSubCoordinates[indexXcoordinates];
                double xRailingSpacingNext = xRailingSpacingCurrent + xSubCoordinates[indexXcoordinates + 1];

                // Creates B2 short beams allong the underside of the walkway.
                // Differentiate between the middle and ends
                if (indexXcoordinates == 0)
                {
                    // Differentiate between a split and an edge.
                    if (side2) // If it is a split then do some alignment math.
                    {
                        startPos = new TSG.Point(
                            xRailingSpacingCurrent - modelParameters.BoxGap,
                            C1BeamDepth + weldOffset,
                            walkwayZ - modelParameters.MeshThickness)
                            + OriginOffset;

                        endPos = new TSG.Point(
                            xRailingSpacingCurrent - modelParameters.BoxGap,
                            BillboardDepth - C1BeamDepth - weldOffset,
                            walkwayZ - modelParameters.MeshThickness)
                            + OriginOffset;

                        Material = modelParameters.B2Material;
                        Profile = modelParameters.B2SplitProfile;
                    }
                    else // If its an edge then do something other alignment math.
                    {
                        startPos = new TSG.Point(
                            xRailingSpacingCurrent + B2BeamWidth - C1BeamWidth / 2,
                            C1BeamDepth + weldOffset,
                            walkwayZ - modelParameters.MeshThickness)
                            + OriginOffset;

                        endPos = new TSG.Point(
                            xRailingSpacingCurrent + B2BeamWidth - C1BeamWidth / 2,
                            BillboardDepth - C1BeamDepth - weldOffset,
                            walkwayZ - modelParameters.MeshThickness)
                            + OriginOffset;

                        Material = modelParameters.B2Material;
                        Profile = modelParameters.B2Profile;
                    }
                    BeamsCreated.Add(
                        Box.CreateBeam(Prefix.part, Prefix.assembly,
                            startPos,
                            endPos,
                            Material,
                            Profile,
                            "4",
                            railingEnums,
                            railingOffsets

                        )
                    );
                }
                else // middle brackets
                {
                    startPos = new TSG.Point(
                        xRailingSpacingCurrent + B2BeamWidth / 2,
                        C1BeamDepth + weldOffset,
                        walkwayZ - modelParameters.MeshThickness)
                        + OriginOffset;

                    endPos = new TSG.Point(
                        xRailingSpacingCurrent + B2BeamWidth / 2,
                        BillboardDepth - C1BeamDepth - weldOffset,
                        walkwayZ - modelParameters.MeshThickness)
                        + OriginOffset;


                    BeamsCreated.Add(
                        Box.CreateBeam(Prefix.part, Prefix.assembly,
                            startPos,
                            endPos,
                            modelParameters.B2Material,
                            modelParameters.B2Profile,
                            "4",
                            railingEnums,
                            railingOffsets
                        )
                    );

                    // Don't forget to make the last railing.
                    if (indexXcoordinates == xSubCoordinates.Count - 2)
                    {
                        // Differentiate between a split and an edge.
                        if (side4) // If it is a split then do some alignment math.
                        {
                            startPos = new TSG.Point(
                                xRailingSpacingNext + C1BeamWidth / 2 + modelParameters.BoxGap,
                                C1BeamDepth + weldOffset,
                                walkwayZ - modelParameters.MeshThickness)
                                + OriginOffset;

                            endPos = new TSG.Point(
                                xRailingSpacingNext + C1BeamWidth / 2 + modelParameters.BoxGap,
                                BillboardDepth - C1BeamDepth - weldOffset,
                                walkwayZ - modelParameters.MeshThickness)
                                + OriginOffset;

                            Material = modelParameters.B2Material;
                            Profile = modelParameters.B2SplitProfile;
                        }
                        else // If its an edge then do something other alignment math.
                        {
                            startPos = new TSG.Point(
                                xRailingSpacingNext + C1BeamWidth / 2,
                                C1BeamDepth + weldOffset,
                                walkwayZ - modelParameters.MeshThickness)
                                + OriginOffset;

                            endPos = new TSG.Point(
                                xRailingSpacingNext + C1BeamWidth / 2,
                                BillboardDepth - C1BeamDepth - weldOffset,
                                walkwayZ - modelParameters.MeshThickness)
                                + OriginOffset;

                            Material = modelParameters.B2Material;
                            Profile = modelParameters.B2Profile;
                        }

                        BeamsCreated.Add(
                            Box.CreateBeam(Prefix.part, Prefix.assembly,
                                startPos,
                                endPos,
                                Material,
                                Profile,
                                "4",
                                railingEnums,
                                railingOffsets
                            )
                        );
                    }
                }

                // Reset start and end offset.
                double startOffset = C1BeamWidth / 2;
                double endOffset = C1BeamWidth / 2;

                if (side2 && indexXcoordinates == 0)
                {
                    startOffset = modelParameters.C1SplitBeamWidth + modelParameters.BoxGap;
                }
                if (side4 && indexXcoordinates == xSubCoordinates.Count - 2)
                {
                    endOffset = modelParameters.C1SplitBeamWidth + modelParameters.BoxGap;
                }

                // State the normal start and end positions for the back horizontal rail.
                startPos = new TSG.Point(
                        xRailingSpacingCurrent + weldOffset + startOffset,
                        BillboardDepth - B1BeamWidth,
                        walkwayZ) + OriginOffset;

                endPos = new TSG.Point(
                        xRailingSpacingNext - weldOffset - endOffset,
                        BillboardDepth - B1BeamWidth,
                        walkwayZ) + OriginOffset;

                // Insert the beams
                BeamsCreated.Add(
                    Box.CreateBeam(Prefix.part, Prefix.assembly,
                        startPos,
                        endPos,
                        modelParameters.B1Material,
                        modelParameters.B1Profile,
                        "11",
                        railingEnums,
                        railingOffsets
                    )
                );

                // State the normal start and end positions for the front horizontal rail.
                startPos = new TSG.Point(
                        xRailingSpacingCurrent + weldOffset + startOffset,
                        0,
                        walkwayZ) + OriginOffset;

                endPos = new TSG.Point(
                        xRailingSpacingNext - weldOffset - endOffset,
                        0,
                        walkwayZ) + OriginOffset;

                // Insert the beams
                BeamsCreated.Add(
                    Box.CreateBeam(Prefix.part, Prefix.assembly,
                        startPos,
                        endPos,
                        modelParameters.B1Material,
                        modelParameters.B1Profile,
                        "11",
                        railingEnums,
                        railingOffsets
                    )
                );
            }

            double separatorBeamWidth = modelParameters.B2BeamWidth;
            double separatorSplitBeamWidth = modelParameters.B2SplitBeamWidth;
            double diagonalOffset = 0;//- modelParameters.DiagonalTopOffset;
            double zCoordinateDiagonals = walkwayZ - Math.Abs(BR1BeamDepth - B1BeamDepth) / 2;
            bool Camera = false;
            bool EASupports = true;

            // Create Diagonal Bracings with EA Supports
            BeamsCreated.AddRange(
                Diagonal.DiagonalBracing(
                    xSubCoordinates,
                    separatorBeamWidth,
                    separatorSplitBeamWidth,
                    OriginOffset,
                    modelParameters,
                    diagonalOffset,
                    zCoordinateDiagonals - modelParameters.MeshThickness,
                    side2,
                    side4,
                    Camera,
                    EASupports
                )
            );

            string walkwayMeshThicknessString = Convert.ToString(modelParameters.MeshThickness);

            // Obtain the width of the walkway 
            double walkwayMeshWidth = modelParameters.WalkwayWidth;

            // Convert the walkway width to a string
            string walkwayMeshWidthString = Convert.ToString(walkwayMeshWidth);

            // Concatenate the strings e.g. MESH14*615
            string walkwayProfile = "MESH" + walkwayMeshThicknessString + "*" + walkwayMeshWidthString;

            // Create enums and offsets for the walkway mesh
            int[] meshEnums = new int[] { 1, 1, 0 };
            double[] meshOffsets = new double[] { 0.0, 0.0, 0.0 };

            // Create the plate 
            TSG.Point plateStartPos = new TSG.Point();
            TSG.Point plateEndPos = new TSG.Point();

            if (side4)
            {
                plateEndPos = new TSG.Point(
                       boxlength - modelParameters.BoxGap,
                       B1BeamWidth + modelParameters.WalkwayClearance,
                       walkwayZ - Math.Abs(BR1BeamDepth - B1BeamDepth) / 2 - modelParameters.MeshThickness + EABeamDepth) + OriginOffset;
            }
            else
            {
                plateEndPos = new TSG.Point(
                        boxlength + B3BeamWidth / 2,
                        B1BeamWidth + modelParameters.WalkwayClearance,
                        walkwayZ - Math.Abs(BR1BeamDepth - B1BeamDepth) / 2 - modelParameters.MeshThickness + EABeamDepth) + OriginOffset;
            }

            if (side2)
            {
                plateStartPos = new TSG.Point(
                        xSubCoordinates[0] + modelParameters.BoxGap,
                        B1BeamWidth + modelParameters.WalkwayClearance,
                        walkwayZ - Math.Abs(BR1BeamDepth - B1BeamDepth) / 2 - modelParameters.MeshThickness + EABeamDepth) + OriginOffset;
            }
            else
            {
                plateStartPos = new TSG.Point(
                        xSubCoordinates[0] - B2BeamWidth / 2,
                        B1BeamWidth + modelParameters.WalkwayClearance,
                        walkwayZ - Math.Abs(BR1BeamDepth - B1BeamDepth) / 2 - modelParameters.MeshThickness + EABeamDepth) + OriginOffset;

            }

            BeamsCreated.Add(
                Box.CreateBeam(Prefix.part, Prefix.assembly,
                    plateStartPos,
                    plateEndPos,
                    modelParameters.MeshMaterial,
                    walkwayProfile,
                    "1",
                    meshEnums,
                    meshOffsets
                )
            );

            return BeamsCreated;
        }
    }
}