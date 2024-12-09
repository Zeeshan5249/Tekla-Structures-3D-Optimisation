using System;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Class which contains methods and constructors for creating the flashings.
    /// </summary>
    public class Flashing
    {
        /// <value>
        /// List of Tekla Structures parts containing the flashing(s). 
        /// </value>
        public List<PolyBeam> PolyBeams { get; set; }

        /// <value>
        /// Colour of the flashing(s).
        /// </value>
        public Colour Colour { get; set; }

        /// <value>
        /// Thickness of the flashing(s).
        /// </value>
        public double Thickness { get; set; }

        /// <value>
        /// Dimensions of the flashing(s). See Technical Documentation for the corresponding schematics.
        /// Ordered as follows: BC (top), CD (top), DE (top), BC (sides), CD (sides), DE (sides), CD (bottom), DE (bottom),
        /// AB = BC (sides), AB (top), alpha (top), EF (top), beta (top), AB (sides), alpha (sides), EF (sides), beta (sides),
        /// EF (bottom), gamma.
        /// </value>
        public double[] Dimensions { get; set; }

        /// <summary>
        /// Constructor to build flashings in Tekla Structures.
        /// </summary>
        /// <param name="sides"> List of billboard sides to include flashings </param>
        /// <param name="modelParameters"> The model data store </param>
        public Flashing(BillboardSide[] sides, ModelParameters modelParameters)
        {
            this.Colour = modelParameters.FlashingColour;
            this.Thickness = modelParameters.FlashingThickness;
            this.Dimensions = modelParameters.FlashingDimensions;
            this.PolyBeams = new List<PolyBeam>();

            foreach (BillboardSide side in sides)
            {
                PolyBeam flashing = BuildFlashing(side, modelParameters);
                if (flashing != null) { this.PolyBeams.Add(flashing); }
            }
        }

        /// <summary>
        /// Helper method to build flashings for a single side.
        /// </summary>
        /// <param name="side"> Billboard side to include flashings </param>
        /// <param name="modelParameters"> The model data store </param>
        /// <returns></returns>
        private PolyBeam BuildFlashing(BillboardSide side, ModelParameters modelParameters)
        {
            int[] enums =
                { (int)Position.DepthEnum.FRONT, (int)Position.PlaneEnum.LEFT, (int)Position.RotationEnum.BACK };

            // start building horizontal flashings from the far left
            double xStart = -(modelParameters.B2BeamDepth + this.Thickness) / 2;

            // start building side flashings from the bottom edge of the billboard
            double zStart = -(modelParameters.HeightOffsetBottom + modelParameters.WeldOffset + modelParameters.B1BeamWidth);

            // extra length needed for flashings to span the whole billboard
            double xExtra = 2 * Math.Abs(xStart);
            double zExtra = Math.Abs(zStart) + modelParameters.HeightOffsetTop + modelParameters.WeldOffset + modelParameters.B1BeamWidth;

            switch (side)
            {
                case BillboardSide.Top:

                    // hotfix for rotation issue at large angles
                    if (this.Dimensions[10] > 84.2608 * Math.PI / 180) { enums = new[] { (int)Position.DepthEnum.BEHIND, (int)Position.PlaneEnum.LEFT, (int)Position.RotationEnum.TOP }; }

                    double z = modelParameters.ScreenHeight + this.Dimensions[1];
                    
                    List<ContourPoint> points = new List<ContourPoint>
                    {
                        new ContourPoint(new TSG.Point(xStart, this.Dimensions[0] + this.Dimensions[9]*Math.Cos(this.Dimensions[10]), z - this.Dimensions[9]*Math.Sin(this.Dimensions[10])), null),
                        new ContourPoint(new TSG.Point(xStart, this.Dimensions[0], z), null),
                        new ContourPoint(new TSG.Point(xStart, 0, z), null),
                        new ContourPoint(new TSG.Point(xStart, 0, modelParameters.ScreenHeight), null),
                        new ContourPoint(new TSG.Point(xStart, -this.Dimensions[2], modelParameters.ScreenHeight), null),
                        new ContourPoint(new TSG.Point(xStart, -this.Dimensions[2] - this.Dimensions[11]*Math.Cos(this.Dimensions[12]), modelParameters.ScreenHeight - this.Dimensions[11]*Math.Sin(this.Dimensions[12])), null)
                    };
                    return ZBracket.CreatePolyBeam(points,
                        $"PLT{this.Thickness}*{modelParameters.ScreenLength + xExtra}",
                        "250",
                        enums,
                        new double[] { 0, 0, 0 },
                        Cladding.ColourToClass(this.Colour), Cladding.ColourToFinish(this.Colour));

                case BillboardSide.Bottom:
                    points = new List<ContourPoint>
                    {
                        new ContourPoint(new TSG.Point(xStart, -(this.Dimensions[6]-this.Dimensions[8]), this.Dimensions[8]), null),
                        new ContourPoint(new TSG.Point(xStart, -this.Dimensions[6], this.Dimensions[8]), null),
                        new ContourPoint(new TSG.Point(xStart, -this.Dimensions[6], 0), null),
                        new ContourPoint(new TSG.Point(xStart, 0, 0), null),
                        new ContourPoint(new TSG.Point(xStart, 0, -this.Dimensions[7]), null),
                        new ContourPoint(new TSG.Point(xStart, this.Dimensions[17]*Math.Cos(this.Dimensions[18]), -this.Dimensions[7] - this.Dimensions[17]*Math.Sin(this.Dimensions[18])), null)
                    };
                    return ZBracket.CreatePolyBeam(points,
                        $"PLT{this.Thickness}*{modelParameters.ScreenLength + xExtra}", "250", enums,
                        new double[] { 0, 0, 0 }, Cladding.ColourToClass(this.Colour), Cladding.ColourToFinish(this.Colour));

                case BillboardSide.Left:
                    
                    enums = new[]
                    {
                        (int)Position.DepthEnum.FRONT, (int)Position.PlaneEnum.RIGHT,
                        (int)Position.RotationEnum.BELOW
                    };
                    points = new List<ContourPoint>
                    {
                        new ContourPoint(
                            new TSG.Point(-this.Dimensions[4] + this.Dimensions[13]*Math.Sin(this.Dimensions[14]),
                                this.Dimensions[3] + this.Dimensions[13]*Math.Cos(this.Dimensions[14]), zStart), null),
                        new ContourPoint(new TSG.Point(-this.Dimensions[4], this.Dimensions[3], zStart), null),
                        new ContourPoint(new TSG.Point(-this.Dimensions[4], 0, zStart), null),
                        new ContourPoint(new TSG.Point(0, 0, zStart), null),
                        new ContourPoint(new TSG.Point(0, -this.Dimensions[5], zStart), null),
                        new ContourPoint(new TSG.Point(this.Dimensions[15]*Math.Sin(this.Dimensions[16]), -this.Dimensions[5] - this.Dimensions[15]*Math.Cos(this.Dimensions[16]), zStart), null)
                    };
                    return ZBracket.CreatePolyBeam(points,
                        $"PLT{this.Thickness}*{modelParameters.ScreenHeight + zExtra}", "250", enums,
                        new double[] { 0, 0, 0 }, Cladding.ColourToClass(this.Colour), Cladding.ColourToFinish(this.Colour));

                case BillboardSide.Right:
                    enums = new[]
                    {
                        (int)Position.DepthEnum.FRONT, (int)Position.PlaneEnum.LEFT,
                        (int)Position.RotationEnum.BELOW
                    };
                    points = new List<ContourPoint>
                    {
                        new ContourPoint(
                            new TSG.Point(modelParameters.ScreenLength + this.Dimensions[4] - this.Dimensions[13]*Math.Sin(this.Dimensions[14]),
                                this.Dimensions[3] + this.Dimensions[13]*Math.Cos(this.Dimensions[14]), zStart), null),
                        new ContourPoint(new TSG.Point(modelParameters.ScreenLength + this.Dimensions[4], this.Dimensions[3], zStart), null),
                        new ContourPoint(new TSG.Point(modelParameters.ScreenLength + this.Dimensions[4], 0, zStart), null),
                        new ContourPoint(new TSG.Point(modelParameters.ScreenLength, 0, zStart), null),
                        new ContourPoint(new TSG.Point(modelParameters.ScreenLength, -this.Dimensions[5], zStart), null),
                        new ContourPoint(new TSG.Point(modelParameters.ScreenLength - this.Dimensions[15]*Math.Sin(this.Dimensions[16]), -this.Dimensions[5] - this.Dimensions[15]*Math.Cos(this.Dimensions[16]), zStart), null)
                    };
                    return ZBracket.CreatePolyBeam(points,
                        $"PLT{this.Thickness}*{modelParameters.ScreenHeight + zExtra}", "250", enums,
                        new double[] { 0, 0, 0 }, Cladding.ColourToClass(this.Colour), Cladding.ColourToFinish(this.Colour));

                // other faces don't have flashings
                default:
                    return null;
            }
        }
    }
}