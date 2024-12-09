using System.Windows.Forms;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// A class to create th B1 horizontal beams in the model
    /// </summary>
    public class HorizontalBeam
    {
        /// <summary>
        /// The constructor of the class to insert B1 horizontal beams in the model
        /// </summary>
        /// <param name="xStart">A double indicating the start position of the beam</param>
        /// <param name="xEnd">A double indicating the end position og the beam</param>
        /// <param name="boxZStart">A double indicating the starting vertical position of the box frame</param>
        /// <param name="boxZEnd">A double indicating the ending vertical position of the box frame </param>
        /// <param name="originOffset">A TSG point indicating the offset from the origin</param>
        /// <param name="side1">A boolean indicating if this side has a split or not (true if it is a split)</param>
        /// <param name="Side3">A boolean indicating if this side has a split or not (true if it is a split)</param>
        /// <param name="B1SplitBeamWidth">A double indicating the width of the B1 beams</param>
        /// <param name="B1SplitBeamDepth">A double indicating the depth of the B1 beams</param>
        /// <param name="billboardDepth">A double indicating the billboard depth</param>
        /// <param name="xSubCoordinates">A list of doubles which is a subset of x coordinates which a list of LED cabinet widths</param>
        /// <param name="modelParameters">A class storing the parameters of the model</param>
        /// <returns></returns>
        public static (Beam, Beam, Beam, Beam) HorizontalBeams
            (
            double xStart,
            double xEnd,
            double boxZStart,
            double boxZEnd,
            TSG.Point originOffset,
            bool side1,
            bool Side3,
            double B1SplitBeamWidth,
            double B1SplitBeamDepth,
            double billboardDepth,
            List<double> xSubCoordinates,
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
            int[] b1Enums = new int[] { 2, 0, 0 };
            double[] b1Offsets = new double[] { 0.0, 0.0, 0.0 };

            int[] B1SplitEnumsBot;
            double[] B1SplitOffsetsBot;
            TSG.Point startPos = new TSG.Point();
            TSG.Point endPos = new TSG.Point();

            Beam B1Beam1;
            Beam B1Beam2;
            Beam B1Beam3;
            Beam B1Beam4;

            // Check if at a split
            if (side1)
            {
                // Check if B1Split is an RHS or EA Beam
                if (!(modelParameters.B1SplitProfile.StartsWith("RHS") || modelParameters.B1SplitProfile.StartsWith("SHS")))
                {
                    // Create the enums and the offsets for the EA beams on the bottom
                    B1SplitEnumsBot = new int[] { 1, 0, 1 };
                    B1SplitOffsetsBot = new double[] { 0.0, 0.0, 0.0 };

                    startPos = new TSG.Point(xStart, 0.5 * B1SplitBeamWidth, boxZStart - B1SplitBeamDepth) + originOffset;
                    endPos = new TSG.Point(xEnd, 0.5 * B1SplitBeamWidth, boxZStart - B1SplitBeamDepth) + originOffset;
                }
                else
                {
                    // Create the enums and the offsets for the RHS beams on the bottom
                    B1SplitEnumsBot = new int[] { 1, 0, 0 };
                    B1SplitOffsetsBot = new double[] { 0.0, 0.0, 0.0 };

                    startPos = new TSG.Point(xStart, 0.5 * B1SplitBeamWidth, boxZStart - B1SplitBeamDepth) + originOffset;
                    endPos = new TSG.Point(xEnd, 0.5 * B1SplitBeamWidth, boxZStart - B1SplitBeamDepth) + originOffset;
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
                    new TSG.Point(xStart, 0.5 * B1SplitBeamWidth, boxZStart) + originOffset,
                    new TSG.Point(xEnd, 0.5 * B1SplitBeamWidth, boxZStart) + originOffset,
                    modelParameters.B1Material,
                    modelParameters.B1Profile,
                    "11",
                    b1Enums,
                    b1Offsets
                    );
            }

            B1Beam2 = Box.CreateBeam(Prefix.part,Prefix.assembly,
                new TSG.Point(xStart, billboardDepth - 0.5 * B1SplitBeamWidth, boxZStart) + originOffset,
                new TSG.Point(xEnd, billboardDepth - 0.5 * B1SplitBeamWidth, boxZStart) + originOffset,
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
                if (!(modelParameters.B1SplitProfile.StartsWith("RHS") || modelParameters.B1SplitProfile.StartsWith("SHS")))
                {
                    // Create the enums and the offsets for the EA beams on the top
                    B1SplitEnumsTop = new int[] { 2, 0, 3 };
                    B1SplitOffsetsTop = new double[] { 0.0, 0.0, 0.0 };
                }
                else
                {
                    // Create the enums and the offsets for the RHS beams on the top
                    B1SplitEnumsTop = new int[] { 2, 0, 0 };
                    B1SplitOffsetsTop = new double[] { 0.0, 0.0, 0.0 };
                }

                // Reverse the start and end possition for EA or UA split beams
                B1Beam3 = Box.CreateBeam(Prefix.part,Prefix.assembly,
                    new TSG.Point(xEnd, 0.5 * B1SplitBeamWidth, boxZEnd) + originOffset,
                    new TSG.Point(xStart, 0.5 * B1SplitBeamWidth, boxZEnd) + originOffset,
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
                    new TSG.Point(xEnd, 0.5 * B1SplitBeamWidth, boxZEnd) + originOffset,
                    new TSG.Point(xStart, 0.5 * B1SplitBeamWidth, boxZEnd) + originOffset,
                    modelParameters.B1Material,
                    modelParameters.B1Profile,
                    "11",
                    b1Enums,
                    b1Offsets
                    );
            }

            B1Beam4 = Box.CreateBeam(Prefix.part,Prefix.assembly,
                new TSG.Point(xStart, billboardDepth - 0.5 * B1SplitBeamWidth, boxZEnd) + originOffset,
                new TSG.Point(xEnd, billboardDepth - 0.5 * B1SplitBeamWidth, boxZEnd) + originOffset,
                modelParameters.B1Material,
                modelParameters.B1Profile,
                "11",
                b1Enums,
                b1Offsets
            );

            // Poke holes through the B1 Beam where the LED bolts will intersect it, if it is an EA beam profile
            // Check if EA profile
            if (!(modelParameters.B1SplitProfile.StartsWith("RHS") || modelParameters.B1SplitProfile.StartsWith("SHS")))
            {
                double xCurrentPlane = 0;
                // loop through xSubCoordinates
                for (int i = 0; i < xSubCoordinates.Count; i++)
                {
                    xCurrentPlane += xSubCoordinates[i];
                    // Check if split
                    if (side1)
                    {
                        Beam BeamToBeBolted = B1Beam1;

                        TSG.Point HoleFirstPosition = new TSG.Point(
                            xCurrentPlane - modelParameters.BoltOffsetDz,
                            B1SplitBeamWidth - modelParameters.B1BeamThickness,
                            modelParameters.BoltOffsetDx
                            ) + originOffset;

                        TSG.Point HoleSecondPosition = new TSG.Point(
                            xCurrentPlane - modelParameters.BoltOffsetDz + 100,
                            B1SplitBeamWidth - modelParameters.B1BeamThickness,
                            modelParameters.BoltOffsetDx
                            ) + originOffset;

                        double HoleSize = modelParameters.EASplitCabinetBoltHoleSize;
                        double CutLength = 500;

                        CreateHole(BeamToBeBolted, HoleFirstPosition, HoleSecondPosition, HoleSize, CutLength, modelParameters);

                        HoleFirstPosition.X += modelParameters.BoltOffsetDz * 2;
                        HoleSecondPosition.X += modelParameters.BoltOffsetDz * 2;

                        CreateHole(BeamToBeBolted, HoleFirstPosition, HoleSecondPosition, HoleSize, CutLength, modelParameters);
                    }

                    if (Side3)
                    {
                        Beam BeamToBeBolted = B1Beam3;

                        TSG.Point HoleFirstPosition = new TSG.Point(
                            xCurrentPlane - modelParameters.BoltOffsetDz,
                            B1SplitBeamWidth - modelParameters.B1BeamThickness,
                            boxZEnd - modelParameters.BoltOffsetDx
                            ) + originOffset;

                        TSG.Point HoleSecondPosition = new TSG.Point(
                            xCurrentPlane - modelParameters.BoltOffsetDz + 100,
                            B1SplitBeamWidth - modelParameters.B1BeamThickness,
                            boxZEnd - modelParameters.BoltOffsetDx
                            ) + originOffset;

                        double HoleSize = modelParameters.EASplitCabinetBoltHoleSize;
                        double CutLength = 500;

                        CreateHole(BeamToBeBolted, HoleFirstPosition, HoleSecondPosition, HoleSize, CutLength, modelParameters);

                        HoleFirstPosition.X += modelParameters.BoltOffsetDz * 2;
                        HoleSecondPosition.X += modelParameters.BoltOffsetDz * 2;

                        CreateHole(BeamToBeBolted, HoleFirstPosition, HoleSecondPosition, HoleSize, CutLength, modelParameters);
                    }
                }
            }
            return (B1Beam1, B1Beam2, B1Beam3, B1Beam4);
        }

        /// <summary>
        /// A function to create a hole on a provided beam
        /// </summary>
        /// <param name="BeamToBeBolted">The beam to have a hole inserted</param>
        /// <param name="HoleFirstPosition">The position of the hole as TSG point</param>
        /// <param name="HoleSecondPosition">A reference point to indicate the perpendicular orientation of the hole</param>
        /// <param name="HoleSize">A double indicating the diameter of the hole</param>
        /// <param name="CutLength">A double indicating the length of the hole</param>
        /// <param name="modelParameters">A parameter indicating the parameters of the model</param>
        public static void CreateHole
            (
            Beam BeamToBeBolted,
            TSG.Point HoleFirstPosition,
            TSG.Point HoleSecondPosition,
            double HoleSize,
            double CutLength,
            ModelParameters modelParameters
            )
        {
            // INSERT THE BOLT HOLE ON WALER
            // Create a new bolt array
            BoltArray Hole = new BoltArray
            {
                Bolt = false,
                BoltSize = HoleSize,
                BoltStandard = modelParameters.BracketBoltStandard,
                CutLength = CutLength,
                FirstPosition = HoleFirstPosition,
                SecondPosition = HoleSecondPosition,
                PartToBoltTo = BeamToBeBolted,
                PartToBeBolted = BeamToBeBolted,
                ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
            };

            // Bolt offsets
            Hole.Position.Depth = Position.DepthEnum.MIDDLE;
            Hole.Position.DepthOffset = 0;
            Hole.Position.Plane = Position.PlaneEnum.MIDDLE;
            Hole.Position.PlaneOffset = 0;
            Hole.Position.Rotation = Position.RotationEnum.BELOW;
            Hole.Position.RotationOffset = 0;

            // the following properties determine the shape of bolts
            // In this case, we set everything to false
            Hole.Bolt = false;
            Hole.Washer1 = false;
            Hole.Washer2 = false;
            Hole.Washer3 = false;
            Hole.Nut1 = false;
            Hole.Nut2 = false;

            Hole.Hole1 = false;
            Hole.Hole2 = false;
            Hole.Hole3 = false;
            Hole.Hole4 = false;
            Hole.Hole5 = false;

            // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
            Hole.AddBoltDistY(0);

            // Add the distance between two holes (set to 0 because we want one)
            Hole.AddBoltDistX(0);

            // Insert bolts
            if (!Hole.Insert())
            {
                MessageBox.Show("Insertion of Bolt failed.");
            }
        }
    }
}