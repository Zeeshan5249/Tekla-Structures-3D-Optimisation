using System;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{   
    /// <summary>
    /// A class used to create EA supports in a more efficient manner than Phase I
    /// </summary>
    public class BetterEASupport
    {
        /// <summary>
        /// This is the constructor and is used to create the EA supports in the correct locations in the model
        /// </summary>
        /// <param name="zCoordinate"> The Z position of the support</param>
        /// <param name="xCurrentPlane">The current section in the x-plane being examined</param>
        /// <param name="xNextPlane">The next section in the x-plane being examined</param>
        /// <param name="startPos">A TSG point indicating the start position</param>
        /// <param name="endPos">A TSG point indicating the end position</param>
        /// <param name="DiagonalOffset">The diagonal offset of the support</param>
        /// <param name="OriginOffset">A reference TSG point position indicating the offset from the origin</param>
        /// <param name="modelParameters">Contains all parameters in the model</param>
        /// TODO Description for return
        public static List<Beam> BetterEASupports
            (
            double zCoordinate,
            double xCurrentPlane,
            double xNextPlane,
            TSG.Point startPos,
            TSG.Point endPos,
            double DiagonalOffset,
            TSG.Point OriginOffset,
            ModelParameters modelParameters
            )
        {
            List<Beam> BeamsCreated = new List<Beam>();

            double EASupportClearance = modelParameters.EASupportClearance;
            double EAWidth = modelParameters.EABeamWidth;
            double B1BeamWidth = modelParameters.B1BeamWidth;
            double WeldOffset = modelParameters.WeldOffset;
            double BillboardDepth = modelParameters.BillboardDepth;


            // Get theta
            double theta = Math.Atan((endPos.Y - startPos.Y) / (endPos.X - startPos.X));

            // State the positions of the screen side EA support
            TSG.Point EAOneStart = new TSG.Point(
                    xCurrentPlane + (EAWidth + EASupportClearance - DiagonalOffset) / Math.Tan(theta),
                    B1BeamWidth,
                    zCoordinate
                ) + OriginOffset;

            TSG.Point EAOneEnd = new TSG.Point(
                    xNextPlane - EASupportClearance,
                    B1BeamWidth,
                    zCoordinate
                ) + OriginOffset;

            // Create enums and offsets for EA supports at the screen side of the billboard
            int[] EAEnums = new int[] { 2, 1, 3 };
            double[] EAOffsets = new double[] { 0.0, 0.0, 0.0 };

            BeamsCreated.Add(
                Box.CreateBeam(
                    Prefix.part,
                    Prefix.assembly,
                    EAOneStart,
                    EAOneEnd,
                    modelParameters.EAMaterial,
                    modelParameters.EAProfile,
                    "8",
                    EAEnums,
                    EAOffsets
                )
            );

            // State the positions of the other EA supports
            EAOneStart = new TSG.Point(
                    xCurrentPlane + EASupportClearance,
                    BillboardDepth-B1BeamWidth,
                    zCoordinate
                ) + OriginOffset;

            EAOneEnd = new TSG.Point(
                    xNextPlane - (EAWidth + EASupportClearance - DiagonalOffset) / Math.Tan(theta),
                    BillboardDepth-B1BeamWidth,
                    zCoordinate
                ) + OriginOffset;

            // Create enums and offsets for EA supports at the other end of the billboard depth
            EAEnums = new int[] { 2, 2, 2 };
            EAOffsets = new double[] { 0.0, 0.0, 0.0 };

            BeamsCreated.Add(
                Box.CreateBeam(Prefix.part,Prefix.assembly,
                        EAOneStart,
                        EAOneEnd,
                        modelParameters.EAMaterial,
                        modelParameters.EAProfile,
                        "8",
                        EAEnums,
                        EAOffsets
                )
            );

            return BeamsCreated;
        }
    }
}