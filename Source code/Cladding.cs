using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Enumeration to support different cladding material profiles on Tekla Structures.
    /// </summary>
    public enum CladdingType
    {
        /// <summary>
        /// MINIORB042
        /// </summary>
        MiniOrb42,
        
        /// <summary>
        /// MINIORB048
        /// </summary>
        MiniOrb48,

        /// <summary>
        /// PANELRIB035
        /// </summary>
        PanelRib35,
        
        /// <summary>
        /// PANELRIB042
        /// </summary>
        PanelRib42,
        
        /// <summary>
        /// Perforated Sheet
        /// </summary>
        PerfSheet,
        
        /// <summary>
        /// Aluminium Composite Panel
        /// </summary>
        ACM,

        /// <summary>
        /// No cladding.
        /// </summary>
        None
    };

    /// <summary>
    /// Enumeration to specify which side(s) of the billboard to place cladding and/or flashings on.
    /// </summary>
    public enum BillboardSide
    {
        /// <summary>
        /// Back of the billboard (opposite the LED panels).
        /// </summary>
        Back,

        /// <summary>
        /// Left side of the billboard.
        /// </summary>
        Left,

        /// <summary>
        /// Right side of the billboard.
        /// </summary>
        Right,

        /// <summary>
        /// Top of the billboard.
        /// </summary>
        Top,

        /// <summary>
        /// Bottom of the billboard.
        /// </summary>
        Bottom
    };

    /// <summary>
    /// Enumeration to support different material colours/finishes
    /// </summary>
    public enum Colour
    {
        /// <summary>
        /// Basalt colour
        /// </summary>
        Basalt,

        /// <summary>
        /// Cove colour
        /// </summary>
        Cove,

        /// <summary>
        /// Dune colour
        /// </summary>
        Dune,

        /// <summary>
        /// EveningHaze Colour
        /// </summary>
        EveningHaze,

        /// <summary>
        /// Gully Colour
        /// </summary>
        Gully,

        /// <summary>
        /// Ironstone Colour
        /// </summary>
        Ironstone,

        /// <summary>
        /// Jasper COlour
        /// </summary>
        Jasper,

        /// <summary>
        /// Mangrove Colour
        /// </summary>
        Mangrove,

        /// <summary>
        /// Monument Colour
        /// </summary>
        Monument,

        /// <summary>
        /// ShaleGrey Colour
        /// </summary>
        ShaleGrey,

        /// <summary>
        /// Surfmist Colour
        /// </summary>
        Surfmist,

        /// <summary>
        /// Terrain Colour
        /// </summary>
        Terrain,

        /// <summary>
        /// Wallaby Colour
        /// </summary>
        Wallaby,

        /// <summary>
        /// Windspray Colour
        /// </summary>
        Windspray
    }

    /// <summary>
    /// Class to support modeling of cladding on the exteriors of the billboard.
    /// </summary>
    public class Cladding
    {
        /// <value>
        /// Profile of Beam based on cladding material.
        /// </value>
        public string Profile { get; set; }

        /// <value>
        /// Material of Beam.
        /// </value>
        public string Material { get; set; }

        /// <summary>
        /// Indicates the cladding type currently being used
        /// </summary>
        public CladdingType Type { get; set; }

        /// <value>
        /// Colour of cladding sheet.
        /// </value>
        public Colour Colour { get; set; }

        /// <value>
        /// Indicates the user input of open area for perforated sheet profiles
        /// </value>
        public double PercentOpenArea { get; set; }

        /// <value>
        /// Indicates the thickness of the cladding
        /// </value>
        public double Thickness { get; set; }

        /// <value>
        /// Indicates which side of the billboard has cladding being applied
        /// </value>
        public BillboardSide Side { get; set; }

        /// <value>
        /// A list of beams being inserted to represent MiniOrb and PanelRib claddings
        /// </value>
        public List<Beam> Beams { get; set; }

        /// <value>
        /// A list of plates being inserted to represent ACM and PerfSheet claddings
        /// </value>
        public List<Plate> Plates { get; set; }

        /// <summary>
        /// A method to convert a provided colour into a string to be used to represent the cladding profile colour
        /// </summary>
        /// <param name="colour">Indicates the colour to be converted to a numerical string</param> 
        /// <returns>A string containing an integer</returns> 
        public static string ColourToClass(Colour colour)
        {
            switch (colour)
            {
                case Colour.Basalt:
                case Colour.Dune:
                case Colour.Gully:
                case Colour.Monument:
                case Colour.ShaleGrey:
                case Colour.Surfmist:
                case Colour.Wallaby:
                case Colour.Windspray:
                    return "1";
                case Colour.Cove:
                case Colour.EveningHaze:
                case Colour.Mangrove:
                    return "10";
                case Colour.Ironstone:
                    return "4";
                case Colour.Jasper:
                case Colour.Terrain:
                    return "8";
                default:
                    return "1";
            }
        }

        /// <summary>
        /// A method to convert a provided finish into a string to be used to represent the cladding profile finish
        /// </summary>
        /// <param name="colour">Indicates the finish to be converted </param> 
        /// <returns>A string containing a colour option</returns> 
        public static string ColourToFinish(Colour colour)
        {
            switch (colour)
            {
                case Colour.Basalt:
                    return "Basalt";
                case Colour.Dune:
                    return "Dune";
                case Colour.Gully:
                    return "Gully";
                case Colour.ShaleGrey:
                    return "Shale Grey";
                case Colour.Surfmist:
                    return "Surfmist";
                case Colour.Wallaby:
                    return "Wallaby";
                case Colour.Windspray:
                    return "Windspray";
                case Colour.Cove:
                    return "Cove";
                case Colour.EveningHaze:
                    return "Evening Haze";
                case Colour.Mangrove:
                    return "Mangrove";
                case Colour.Ironstone:
                    return "Ironstone";
                case Colour.Jasper:
                    return "Jasper";
                case Colour.Terrain:
                    return "Terrain";
                default:
                    return "Monument";
            }
        }

        /// <summary>
        /// A method to inser beams for the left, back and right sides of the billboard to insert MiniOrb and PanelRib cladding
        /// </summary>
        /// <param name="modelParameters">The parameters of the model</param> 
        /// <param name="xyEnd">The boundary end of the cladding</param> 
        /// <param name="xyVector">A vector for looping through positions</param> 
        /// <param name="start">The start position to insert cladding</param> 
        /// <param name="enums">A list of integers for updating positions</param> 
        private void CladdingBeams(ModelParameters modelParameters, double xyEnd, TSG.Point xyVector, TSG.Point start, int[] enums)
        {
            double zEnd = modelParameters.ScreenHeight + modelParameters.HeightOffsetTop + modelParameters.WeldOffset +
                          modelParameters.B1BeamWidth;
            for (double xy = modelParameters.EffectiveCoverWidths[(int)this.Side] / 2;
                 xy < xyEnd + modelParameters.EffectiveCoverWidths[(int)this.Side] / 2;
                 xy += modelParameters.EffectiveCoverWidths[(int)this.Side])
            {
                Beam b1;
                for (double z = -modelParameters.B1BeamDepth;
                     z < zEnd - modelParameters.TopCladdingOffsets[(int)this.Side];
                     z += modelParameters.CladdingLengths[(int)this.Side])
                {
                    TSG.Point offset = new TSG.Point(xy * xyVector.X, xy * xyVector.Y, z);

                    // cut the last cladding short to not exceed billboard height
                    double zLength = Math.Min(modelParameters.CladdingLengths[(int)this.Side],
                        zEnd - modelParameters.TopCladdingOffsets[(int)this.Side] - (start + offset).Z);

                    b1 = Box.CreateBeam(Prefix.part,Prefix.assembly, start + offset,
                        start + offset + new TSG.Point(0, 0, zLength), Material, Profile,
                        ColourToClass(this.Colour), enums, new double[] { 0, 0, 0 }, ColourToFinish(this.Colour));

                    // If the next beam exceeds past the available space, cut it short
                    if (xy + modelParameters.EffectiveCoverWidths[(int)this.Side] / 2 > xyEnd)
                    {
                        // Front/back: xyVector = (1, 0, 0), axisX = (0, 1, 0), axisY = (0, 0, 1)
                        // Left/right: xyVector = (0, 1, 0), axisX = (0, 0, 1), axisY = (1, 0, 0)
                        TSG.Vector axisX = xyVector.Equals(new TSG.Point(0, 1, 0)) ? new TSG.Vector(0, 0, 1) : new TSG.Vector(0, 1, 0);
                        TSG.Vector axisY = xyVector.Equals(new TSG.Point(0, 1, 0)) ? new TSG.Vector(1, 0, 0) : new TSG.Vector(0, 0, 1);
                        CutPlane cp1 = new CutPlane
                        {
                            Plane = new Plane
                            {
                                Origin = new TSG.Point(xyEnd * xyVector.X, xyEnd * xyVector.Y, z),
                                AxisX = axisX,
                                AxisY = axisY
                            },
                            Father = b1
                        };
                        cp1.Insert();
                    }
                    this.Beams.Add(b1);
                }
            }
        }

        /// <summary>
        /// A method to inser beams for the top and bottom sides of the billboard to insert MiniOrb and PanelRib cladding
        /// </summary>
        /// <param name="modelParameters">The parameters of the model</param> 
        /// <param name="z">The vertical position to inset claddings</param> 
        /// <param name="enums">A list of integers for updating positions</param> 
        private void CladdingBeamsTopBot(ModelParameters modelParameters, double z, int[] enums)
        {
            double xEnd = modelParameters.BillboardLength + (modelParameters.C1BeamWidth + modelParameters.FlashingThickness) / 2;
            for (double x = -(modelParameters.C1BeamWidth + modelParameters.FlashingThickness) / 2 + modelParameters.EffectiveCoverWidths[(int)this.Side] / 2;
                 x < xEnd + modelParameters.EffectiveCoverWidths[(int)this.Side] / 2;
                 x += modelParameters.EffectiveCoverWidths[(int)this.Side])
            {
                Beam b1;
                for (double y = 0;
                     y < modelParameters.BillboardDepth;
                     y += modelParameters.CladdingLengths[(int)this.Side])
                {

                    // cut the last cladding short to not exceed billboard depth
                    double yLength = Math.Min(modelParameters.CladdingLengths[(int)this.Side],
                        modelParameters.BillboardDepth - y);

                    b1 = Box.CreateBeam(Prefix.part,Prefix.assembly, new TSG.Point(x, y, z),
                        new TSG.Point(x, y + yLength, z), Material, Profile,
                        ColourToClass(this.Colour), enums, new double[] { 0, 0, 0 }, ColourToFinish(this.Colour));

                    // If the next beam exceeds past the available space, cut it short
                    if (x + modelParameters.EffectiveCoverWidths[(int)this.Side] / 2 > xEnd)
                    {
                        TSG.Vector axisX = new TSG.Vector(0, 1, 0);
                        TSG.Vector axisY = new TSG.Vector(0, 0, 1);
                        CutPlane cp1 = new CutPlane
                        {
                            Plane = new Plane
                            {
                                Origin = new TSG.Point(xEnd, 0, z),
                                AxisX = axisX,
                                AxisY = axisY
                            },
                            Father = b1
                        };
                        cp1.Insert();
                    }
                    this.Beams.Add(b1);
                }
            }
        }

        /// <summary>
        /// A method to inser plates for the left, back and right sides of the billboard to insert PerfSheet and ACM cladding
        /// </summary>
        /// <param name="modelParameters">The parameters of the model</param> 
        /// <param name="xyEnd">The boundary end of the cladding</param> 
        /// <param name="xyVector">A vector for looping through positions</param> 
        /// <param name="start">The start position to insert cladding</param> 
        /// <param name="depth">The depth to insert to account for thickness</param> 
        private void CladdingPlates(ModelParameters modelParameters, double xyEnd, TSG.Point xyVector, TSG.Point start, Position.DepthEnum depth)
        {
            double zEnd = modelParameters.ScreenHeight + modelParameters.HeightOffsetTop + modelParameters.WeldOffset +
                          modelParameters.B1BeamWidth;
            for (double xy = 0; xy < xyEnd; xy += modelParameters.EffectiveCoverWidths[(int)this.Side])
            {
                // If the next plate goes past the available space, shorten it
                double xyLength = Math.Min(xyEnd - xy, modelParameters.EffectiveCoverWidths[(int)this.Side]);

                for (double z = -modelParameters.B5BeamWidth;
                     z < zEnd - modelParameters.TopCladdingOffsets[(int)this.Side];
                     z += modelParameters.CladdingLengths[(int)this.Side])
                {
                    TSG.Point bRight = start + new TSG.Point(xy * xyVector.X, xy * xyVector.Y, z);

                    // cut the last cladding short to not exceed billboard height
                    double zLength = Math.Min(modelParameters.CladdingLengths[(int)this.Side],
                        zEnd - modelParameters.TopCladdingOffsets[(int)this.Side] - bRight.Z);

                    TSG.Point tRight = start + new TSG.Point(xy * xyVector.X, xy * xyVector.Y, z + zLength);
                    TSG.Point bLeft = start + new TSG.Point((xy + xyLength) * xyVector.X, (xy + xyLength) * xyVector.Y, z);
                    TSG.Point tLeft = start + new TSG.Point((xy + xyLength) * xyVector.X, (xy + xyLength) * xyVector.Y, z + zLength);
                    List<TSG.Point> points = new List<TSG.Point>() { bRight, tRight, tLeft, bLeft };

                    string plateName = this.Type == CladdingType.ACM ? "ACM" : $"Perf Sheet ({this.PercentOpenArea}%)";
                    this.Plates.Add(new Plate(points, this.Profile, this.Material, depth: depth, plateClass: ColourToClass(this.Colour), plateName: plateName, plateFinish: ColourToFinish(this.Colour)));
                }
            }
        }

        /// <summary>
        /// A method to inser plates for the top and bottom sides of the billboard to insert PerfSheet and ACM cladding
        /// </summary>
        /// <param name="modelParameters">The parameters of the model</param> 
        /// <param name="z">The vertical position to inset claddings</param> 
        /// <param name="depth">The depth to insert to account for thickness</param> 
        private void CladdingPlatesTopBot(ModelParameters modelParameters, double z, Position.DepthEnum depth)
        {
            double xEnd = modelParameters.BillboardLength + (modelParameters.C1BeamWidth + modelParameters.FlashingThickness) / 2;
            for (double x = -modelParameters.C1BeamWidth / 2; x < xEnd; x += modelParameters.EffectiveCoverWidths[(int)this.Side])
            {
                // If the next plate goes past the available space, shorten it
                double xLength = Math.Min(xEnd - x, modelParameters.EffectiveCoverWidths[(int)this.Side]);

                for (double y = 0;
                     y < modelParameters.BillboardDepth;
                     y += modelParameters.CladdingLengths[(int)this.Side])
                {

                    // cut the last cladding short to not exceed billboard depth
                    double yLength = Math.Min(modelParameters.CladdingLengths[(int)this.Side],
                        modelParameters.BillboardDepth - y);

                    TSG.Point bLeft = new TSG.Point(x, y, z);
                    TSG.Point bRight = new TSG.Point(x + xLength, y, z);
                    TSG.Point tRight = new TSG.Point((x + xLength), y + yLength, z);
                    TSG.Point tLeft = new TSG.Point(x, y + yLength, z);
                    List<TSG.Point> points = new List<TSG.Point>() { bRight, tRight, tLeft, bLeft };

                    string plateName = this.Type == CladdingType.ACM ? "ACM" : $"Perf Sheet ({this.PercentOpenArea}%)";
                    this.Plates.Add(new Plate(points, this.Profile, this.Material, depth: depth, plateClass: ColourToClass(this.Colour), plateName: plateName, plateFinish: ColourToFinish(this.Colour)));
                }
            }
        }

        /// <summary>
        /// The constructor for the cladding. Upon creating an instance, the program will generate the cladding for the model.
        /// </summary>
        /// <param name="type">Indicates which type of cladding is to be created</param> 
        /// <param name="modelParameters">The parameters of the model</param> 
        /// <param name="side">Indicates which side the cladding is being inserted</param> 
        /// <param name="colour">Indicates the colour of the cladding</param> 
        /// <param name="openArea">Indicates the open area for the profile</param> 
        /// <param name="thickness">Indicates the thickness of the cladding</param> 
        public Cladding(CladdingType type, ModelParameters modelParameters, BillboardSide side, Colour colour, double openArea, double thickness)
        {
            this.Material = "300PLUS";
            this.Type = type;
            this.Colour = colour;
            this.PercentOpenArea = openArea;
            this.Thickness = thickness;
            this.Side = side;
            this.Beams = new List<Beam>();
            this.Plates = new List<Plate>();

            bool isBeam = true;
            switch (type)
            {
                case CladdingType.MiniOrb42:
                    this.Profile = "MINIORB042";
                    break;

                case CladdingType.MiniOrb48:
                    this.Profile = "MINIORB048";
                    break;

                case CladdingType.PanelRib35:
                    this.Profile = "PANELRIB035";
                    break;

                case CladdingType.PanelRib42:
                    this.Profile = "PANELRIB042";
                    break;

                case CladdingType.PerfSheet:
                    this.Profile = $"PERF{this.Thickness}";
                    isBeam = false;
                    break;

                case CladdingType.ACM:
                    this.Profile = "ACM3";
                    isBeam = false;
                    break;
            }

            TSG.Point start = new TSG.Point(0, 0, 0), xyVector = new TSG.Point(0, 0, 0);
            double xyEnd = 0;
            int[] enums = new[] { (int)Position.DepthEnum.MIDDLE, (int)Position.PlaneEnum.MIDDLE, (int)Position.RotationEnum.FRONT };
            Position.DepthEnum plateEnum = Position.DepthEnum.FRONT;
            switch (side)
            {
                case BillboardSide.Back:
                    start = new TSG.Point(-(modelParameters.C1BeamWidth + modelParameters.FlashingThickness) / 2, modelParameters.BillboardDepth, 0);
                    xyVector = new TSG.Point(1, 0, 0);
                    enums = new[]
                    {
                        (int)Position.DepthEnum.MIDDLE, (int)Position.PlaneEnum.MIDDLE,
                        (int)Position.RotationEnum.FRONT
                    };
                    xyEnd = modelParameters.BillboardLength + (modelParameters.C1BeamWidth + modelParameters.FlashingThickness) / 2;
                    xyEnd = isBeam ? xyEnd : xyEnd + modelParameters.C1BeamWidth / 2;
                    break;

                case BillboardSide.Left:
                    start = new TSG.Point(-(modelParameters.C1BeamWidth + modelParameters.FlashingThickness) / 2, 0, 0);
                    xyVector = new TSG.Point(0, 1, 0);
                    enums = new[]
                    {
                        (int)Position.DepthEnum.MIDDLE, (int)Position.PlaneEnum.MIDDLE,
                        (int)Position.RotationEnum.TOP
                    };
                    xyEnd = modelParameters.BillboardDepth;
                    plateEnum = Position.DepthEnum.FRONT;
                    break;

                case BillboardSide.Right:
                    start = new TSG.Point(modelParameters.BillboardLength + (modelParameters.C1BeamWidth + modelParameters.FlashingThickness) / 2, 0, 0);
                    xyVector = new TSG.Point(0, 1, 0);
                    enums = new int[]
                    {
                        (int)Position.DepthEnum.MIDDLE, (int)Position.PlaneEnum.MIDDLE,
                        (int)Position.RotationEnum.TOP
                    };
                    xyEnd = modelParameters.BillboardDepth;
                    plateEnum = Position.DepthEnum.BEHIND;
                    break;

                case BillboardSide.Top:
                    plateEnum = Position.DepthEnum.FRONT;
                    enums = new int[]
                    {
                        (int)Position.DepthEnum.FRONT, (int)Position.PlaneEnum.MIDDLE,
                        (int)Position.RotationEnum.TOP
                    };
                    break;

                case BillboardSide.Bottom:
                    plateEnum = Position.DepthEnum.BEHIND;
                    enums = new int[]
                    {
                        (int)Position.DepthEnum.BEHIND, (int)Position.PlaneEnum.MIDDLE,
                        (int)Position.RotationEnum.BELOW
                    };
                    break;
            }

            double z = modelParameters.ScreenHeight + modelParameters.HeightOffsetTop + modelParameters.WeldOffset +
                          modelParameters.B1BeamWidth;
            if (isBeam)
            {
                if (side == BillboardSide.Top)
                {
                    CladdingBeamsTopBot(modelParameters, z, enums);
                }
                else if (side == BillboardSide.Bottom)
                {
                    CladdingBeamsTopBot(modelParameters, -modelParameters.HeightOffsetBottom - modelParameters.B1BeamDepth, enums);
                }
                else
                {
                    CladdingBeams(modelParameters, xyEnd, xyVector, start, enums);
                }

            }
            else
            {
                if (side == BillboardSide.Top)
                {
                    CladdingPlatesTopBot(modelParameters, z, plateEnum);
                }
                else if (side == BillboardSide.Bottom)
                {
                    CladdingPlatesTopBot(modelParameters, -modelParameters.HeightOffsetBottom - modelParameters.B1BeamDepth, plateEnum);
                }
                else
                {
                    CladdingPlates(modelParameters, xyEnd, xyVector, start, plateEnum);
                }

            }

        }


    }

}
