using System;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// A Class which contains functions/methods for building the horizontal railings.
    /// </summary>
    public class HorizontalRailing
    {
        /// <value>
        /// The top railing on the left side, which is used to booleancut the flashings
        /// </value>
        public static Beam TopLeftSideRailing { get; set; }

        /// <value>
        /// The top railing on the right side, which is used to booleancut the flashings
        /// </value>
        public static Beam TopRightSideRailing { get; set; }

        /// <summary>
        /// Constructor to create horizontal railings.
        /// </summary>
        /// <param name="xSubCoordinates"></param>
        /// <param name="side2"></param>
        /// <param name="side4"></param>
        /// <param name="OriginOffset"></param>
        /// <param name="AutoRadio"></param>
        /// <param name="modelParameters"></param>
        /// <param name="railingsZStart"></param>
        /// <param name="railingsZEnd"></param>
        /// 
        /// <returns> List of Beam objects created </returns>
        public static List<Beam> HorizontalRailings
            (
                List<double> xSubCoordinates,
                bool side2,
                bool side4,
                TSG.Point OriginOffset,
                bool AutoRadio, // StructureAutoRadio.Checked
                ModelParameters modelParameters,
                double railingsZStart,
                double railingsZEnd
            )
        {

            List<Beam> BeamsCreated = new List<Beam>();

            double B3BeamWidth = modelParameters.B3BeamWidth;
            double B1BeamDepth = modelParameters.B1BeamDepth;
            double C1BeamDepth = modelParameters.C1BeamDepth;
            double C1BeamWidth = modelParameters.C1BeamWidth;
            double BillboardDepth = modelParameters.BillboardDepth;
            double meshThickness = modelParameters.MeshThickness;
            double differenceb1b5Depth = modelParameters.B1BeamDepth - modelParameters.B5BeamDepth;

            List<double> railingCoordinates = modelParameters.RailingCoordinates;

            // Offset for the welds that shortens members (spacing between connecting members)
            double weldOffset = modelParameters.WeldOffset;

            // Initialise the spacing variables for the horisztonal railings 
            double xRailingSpacingCurrent = 0;

            // We add the mesh thickness and subtract the difference in depth between b1 and b5 from the user since the dimensions ar given from the top of the mesh int he engineering drawing 
            double zRailingSpacing = meshThickness - differenceb1b5Depth;

            // Create coordinates that can be used to offset the horizontal railings (also include the welding offset)
            double railingOffsetX = 0;
            double railingOffsetY = B3BeamWidth;
            double railingOffsetZ = railingsZStart;

            // Create the enums and offsets for the railings
            int[] railingEnums = new int[] { 2, 0, 2 };
            double[] railingOffsets = new double[] { 0.0, 0.0, 90 };

            // Create a list for the z-coordinates of the railings so that they can be used in the insertion of the side railings (coordinates from bottom to top)
            List<double> zCoordinatesForSideBracings = new List<double> { 0 };

            // Initiate start and end positions
            TSG.Point startPos;
            TSG.Point endPos;

            // Create the horizontal railings //
            // Loop through the integers 0 to the length of the xSubCoordinates array less 1 
            for (int indexxSubCoordinates = 0; indexxSubCoordinates < xSubCoordinates.Count - 1; indexxSubCoordinates++)
            {
                // Calculate the current x coordinate and the next x coordinate using the spacings 
                xRailingSpacingCurrent += xSubCoordinates[indexxSubCoordinates];
                double xRailingSpacingNext = xRailingSpacingCurrent + xSubCoordinates[indexxSubCoordinates + 1];

                // Loop through the railing coordinates 
                for (int i = 0; AutoRadio ? i < 2 : i < railingCoordinates.Count; i++)
                {
                    // Calculate the spacing
                    zRailingSpacing += railingCoordinates[i];

                    // Only add to the zCoordinates list one time
                    if (indexxSubCoordinates == 0)
                    {
                        // Add the next railings z-coordinate into the z-coordinate list for the railings
                        zCoordinatesForSideBracings.Add(zRailingSpacing);
                    }

                    // Check if it's the first x coordinate i.e. 0
                    // Check if side2 is a split, if it is then no side railing.
                    if (indexxSubCoordinates == 0 && !side2)
                    {
                        
                        // Insert the side beams
                        Beam b = Box.CreateBeam(Prefix.part,Prefix.assembly,
                            new TSG.Point(
                                xSubCoordinates[indexxSubCoordinates] + B3BeamWidth - C1BeamWidth / 2, 
                                C1BeamDepth + weldOffset, 
                                zRailingSpacing + railingOffsetZ) + OriginOffset,

                            new TSG.Point(
                                xSubCoordinates[indexxSubCoordinates] + B3BeamWidth - C1BeamWidth / 2, 
                                BillboardDepth - C1BeamDepth - weldOffset, 
                                zRailingSpacing + railingOffsetZ) + OriginOffset,

                            modelParameters.B3Material,
                            modelParameters.B3Profile,
                            "5",
                            railingEnums,
                            railingOffsets
                        );

                        BeamsCreated.Add( b );

                        // save the top left side railing
                        HorizontalRailing.TopLeftSideRailing = b;
                    }

                    // If it's at the final coordinate
                    // Check if side4 is a split, if it is then no side railing.
                    else if (indexxSubCoordinates == (xSubCoordinates.Count - 2) && !side4)
                    {
                        //Insert the side beams
                        Beam b = Box.CreateBeam(Prefix.part,Prefix.assembly,
                           new TSG.Point(
                               xRailingSpacingNext + C1BeamWidth / 2, 
                               C1BeamDepth + weldOffset, 
                               zRailingSpacing + railingOffsetZ) + OriginOffset,

                           new TSG.Point(
                               xRailingSpacingNext + C1BeamWidth / 2, 
                               BillboardDepth - C1BeamDepth - weldOffset, 
                               zRailingSpacing + railingOffsetZ) + OriginOffset,

                           modelParameters.B3Material,
                           modelParameters.B3Profile,
                           "5",
                           railingEnums,
                           railingOffsets
                        );

                        BeamsCreated.Add(b);

                        // save the top right side railing
                        HorizontalRailing.TopRightSideRailing = b;
                    }

                    // Reset start and end offset.
                    double startOffset = C1BeamWidth / 2;
                    double endOffset = C1BeamWidth / 2;

                    if (side2 && indexxSubCoordinates == 0)
                    {
                        startOffset = modelParameters.C1SplitBeamWidth + modelParameters.BoxGap;
                    }
                    if (side4 && indexxSubCoordinates == xSubCoordinates.Count - 2)
                    {
                        endOffset = modelParameters.C1SplitBeamWidth + modelParameters.BoxGap;
                    }

                    // State the normal start and end positions for the back horizontal rail.
                    startPos = new TSG.Point(
                            xRailingSpacingCurrent + railingOffsetX + weldOffset + startOffset,
                            BillboardDepth - railingOffsetY,
                            zRailingSpacing + railingOffsetZ) + OriginOffset;

                    endPos = new TSG.Point(
                            xRailingSpacingNext - weldOffset - endOffset,
                            BillboardDepth - railingOffsetY,
                            zRailingSpacing + railingOffsetZ) + OriginOffset;

                    // Insert the beams
                    BeamsCreated.Add(
                        Box.CreateBeam
                        (
                            Prefix.part,
                            Prefix.assembly,
                            startPos,
                            endPos,
                            modelParameters.B3Material,
                            modelParameters.B3Profile,
                            "5",
                            railingEnums,
                            railingOffsets
                        )
                    );
                }

                // If automatic beam spacing, run this
                if (AutoRadio)
                {
                    // Get remaining spacing
                    double totalHorizontalBeamSpacing = (railingsZEnd - B1BeamDepth - 0.5 * B1BeamDepth) - zRailingSpacing;

                    // Calculate number of beams needed
                    int numberOfHorizontalBeams = (int)Math.Floor(totalHorizontalBeamSpacing / 1200);

                    // Get the middle distance of each spacing for each beam
                    double horizontalBeamSpacing = totalHorizontalBeamSpacing / (numberOfHorizontalBeams + 1);
                    for (int i = 0; i < numberOfHorizontalBeams; i++)
                    {
                        // Calculate the spacing
                        zRailingSpacing += horizontalBeamSpacing;

                        // Only add to the zCoordinates list one time
                        if (indexxSubCoordinates == 0)
                        {
                            // Add the next railings z-coordinate into the z-coordinate list for the railings
                            zCoordinatesForSideBracings.Add(zRailingSpacing);
                        }

                        // Check if it's the first x coordinate i.e. 0
                        // Check if side2 is a split, if it is then no side railing.
                        if (indexxSubCoordinates == 0 && !side2)
                        {
                            // Insert the side beams
                            Beam b = Box.CreateBeam(Prefix.part,Prefix.assembly,
                                new TSG.Point(
                                    xSubCoordinates[indexxSubCoordinates] + B3BeamWidth - C1BeamWidth / 2, 
                                    C1BeamDepth + weldOffset, 
                                    zRailingSpacing + railingOffsetZ) + OriginOffset,

                                new TSG.Point(
                                    xSubCoordinates[indexxSubCoordinates] + B3BeamWidth - C1BeamWidth / 2, 
                                    BillboardDepth - C1BeamDepth - weldOffset, 
                                    zRailingSpacing + railingOffsetZ) + OriginOffset,

                                modelParameters.B3Material,
                                modelParameters.B3Profile,
                                "5",
                                railingEnums,
                                railingOffsets
                            );

                            BeamsCreated.Add( b );

                            // save the top left side railing
                            //HorizontalRailing.TopLeftSideRailing = b;
                        }

                        // If it's at the final coordinate
                        // Check if side4 is a split, if it is then no side railing.
                        else if (indexxSubCoordinates == (xSubCoordinates.Count - 2) && !side4)
                        {
                            //Insert the side beams
                            Beam b = Box.CreateBeam(Prefix.part, Prefix.assembly,
                                new TSG.Point(
                                    xRailingSpacingNext + C1BeamWidth / 2,
                                    C1BeamDepth + weldOffset,
                                    zRailingSpacing + railingOffsetZ) + OriginOffset,

                                new TSG.Point
                                    (xRailingSpacingNext + C1BeamWidth / 2,
                                    BillboardDepth - C1BeamDepth - weldOffset,
                                    zRailingSpacing + railingOffsetZ) + OriginOffset,

                                modelParameters.B3Material,
                                modelParameters.B3Profile,
                                "5",
                                railingEnums,
                                railingOffsets
                            );

                            BeamsCreated.Add(b);

                            // save the top right side railing
                            //HorizontalRailing.TopRightSideRailing = b;
                        }

                        // Reset start and end offset.
                        double startOffset = C1BeamWidth / 2;
                        double endOffset = C1BeamWidth / 2;

                        if (side2 && indexxSubCoordinates == 0)
                        {
                            startOffset = modelParameters.C1SplitBeamWidth + modelParameters.BoxGap;
                        }
                        if (side4 && indexxSubCoordinates == xSubCoordinates.Count - 2)
                        {
                            endOffset = modelParameters.C1SplitBeamWidth + modelParameters.BoxGap;
                        }

                        // State the normal start and end positions for the back horizontal rail.
                        startPos = new TSG.Point(
                                xRailingSpacingCurrent + railingOffsetX + weldOffset + startOffset,
                                BillboardDepth - railingOffsetY,
                                zRailingSpacing + railingOffsetZ) + OriginOffset;

                        endPos = new TSG.Point(
                                xRailingSpacingNext - weldOffset - endOffset,
                                BillboardDepth - railingOffsetY,
                                zRailingSpacing + railingOffsetZ) + OriginOffset;

                        // Insert Horizontal Beam
                        BeamsCreated.Add(
                            Box.CreateBeam
                            (
                                Prefix.part,
                                Prefix.assembly,
                                startPos,
                                endPos,
                                modelParameters.B3Material,
                                modelParameters.B3Profile,
                                "5",
                                railingEnums,
                                railingOffsets
                            )
                        );
                    }
                }
                // Set the z spacing equal to 0 each time in the loop 
                zRailingSpacing = meshThickness - differenceb1b5Depth;
            }

            return BeamsCreated;
        }
    }
}
