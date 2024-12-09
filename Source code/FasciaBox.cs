using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures;
using System.Linq;

namespace TeklaBillboardAid
{
    /// <summary>
    /// A class for the fascia box.
    /// </summary>
    public class FasciaBox
    {
        /// <value>
        /// The vertical offset of the fascia box from the bottom of the billboard to the indicated user input
        /// </value>
        public double VertOffset;

        /// <value>
        /// The current horizontal offset
        /// </value>
        public double HorizOffset;
        /// <value>
        /// The offset for the position accounting for beams at the base of the billboard
        /// </value>
        public double OriginVertOffset;

        /// <value>
        /// The parameters for the model
        /// </value>
        public ModelParameters p;

        /// <summary>
        /// Adds 4 bolts, based on left or right column based on inputs
        /// </summary>
        /// <param name="leftSide">Indicates if on the left side of the column</param>
        /// <param name="top">Indicates the top beam</param>
        /// <param name="bot">Indicates the bottom beam</param>
        /// <param name="middle">Indicates the middle beam</param>
        /// <param name="bottom">Indicates the bottom plate</param>
        /// <param name="topEdge">Indicates the top corner plate</param>
        public void AddEdgeBoltsBolts(bool leftSide, Beam top, Beam bot, ContourPlate middle, ContourPlate bottom, ContourPlate topEdge)
        {
            
            for (int i = 0; i < 4; i++)
            {
                double x = 0, y = 0, z = 0;
                switch (i)
                {
                    case 0:
                        x = leftSide
                            ? this.HorizOffset + 86 - p.EABeamDepth * 0.5 + 5
                            : this.HorizOffset - 86 + p.EABeamDepth * 0.5;
                        y = (p.EABeamDepth + 5) * 0.5;
                        z = -(p.WeldOffset + p.B1BeamWidth + 8) + p.EABeamDepth - 205 - p.EABeamWidth * 0.5;
                        break;
                    case 1:
                        x = leftSide ? -p.EABeamDepth * 0.5 + 100 : this.HorizOffset - 100 + p.EABeamDepth * 0.5;
                        y = p.EABeamWidth * 0.5;
                        z = this.VertOffset + 5;
                        break;
                    case 2:
                        x = leftSide ? -p.EABeamDepth * 0.5 + 150 : this.HorizOffset + p.EABeamDepth * 0.5 - 150;
                        y = p.B1BeamWidth * 0.5;
                        z = -1 * (p.WeldOffset + p.B1BeamWidth + 8);
                        break;
                    case 3:
                        x = leftSide ? -p.EABeamDepth * 0.5 + 250 : this.HorizOffset + p.EABeamDepth * 0.5 - 250;
                        y = p.B1BeamWidth * 0.5;
                        z = -1 * (p.WeldOffset + p.B1BeamWidth + 8);
                        break;
                }

                BoltArray bolt = new BoltArray
                {
                    Bolt = true,
                    BoltSize = 16.0,
                    BoltStandard = p.BracketBoltStandard,
                    CutLength = 250,
                    FirstPosition = new TSG.Point(x, y, z),
                    SecondPosition = new TSG.Point(x, y, z) + new TSG.Point(30, 0),
                    PartToBoltTo = top,
                    PartToBeBolted = middle,
                    ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                };

                if (i == 1)
                {
                    bolt.PartToBoltTo = bottom;
                    bolt.PartToBeBolted = bot;
                    
                }
                else if (i >= 2)
                {
                    bolt.PartToBoltTo = topEdge;
                    bolt.PartToBeBolted = topEdge;
                }

                bolt.Washer1 = false;
                bolt.Washer2 = false;
                bolt.Washer3 = true;
                bolt.Nut1 = true;
                bolt.Nut2 = false;

                bolt.Hole1 = false;
                bolt.Hole2 = false;
                bolt.Hole3 = false;
                bolt.Hole4 = false;
                bolt.Hole5 = false;

                //if (this.Mult == -1) { bolt.Position.RotationOffset = 180; }

                // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)
                bolt.AddBoltDistY(0);

                // Add the distance between two bolts (set to 0 because we want one)
                bolt.AddBoltDistX(0);


                if (!bolt.PartToBeBolted.Identifier.IsValid())
                {
                    // Fix the validation problem with the identifier.
                    // Identifier is initialize with the default setting of having 0 as id. When id is 0, validation fails.
                    bolt.PartToBeBolted.Identifier.ID = 1;
                }

                // Insert bolts
                if (!bolt.Insert()) { MessageBox.Show("Insertion of bolt failed."); }
            }
        }

        /// <summary>
        /// Adds 8 bolts per central column
        /// </summary>
        /// <param name="mid">Indicates the middle beam</param>
        /// <param name="prevMid">Indicates the previous middle beam</param>
        /// <param name="bot">Indicates the bottom beam</param>
        /// <param name="prevBot">Indicates the previous bottom beam</param>
        /// <param name="topEdge">Indicates the top level plate</param>
        /// <param name="middleRight">Indicates the middle plate on the right</param>
        /// <param name="middleLeft">Indicates the midddle plate on the left</param>
        /// <param name="bottom">Indicates the bottom plate</param>
        public void AddColumnBolts(Beam mid, Beam prevMid, Beam bot, Beam prevBot, ContourPlate topEdge, ContourPlate middleRight, ContourPlate middleLeft, ContourPlate bottom)
        {
            for (int i = 0; i < 8; i++)
            {
                double x = 0, y = 0, z = 0;
                // Bottom
                if (i == 0)
                {// Right
                    x = this.HorizOffset + 75;
                    y = p.EABeamDepth * 0.5;
                    z = this.VertOffset + 5;
                }
                else if (i == 1)
                {//left
                    x = this.HorizOffset - 75;
                    y = p.EABeamWidth * 0.5;
                    z = this.VertOffset + 5;

                }
                // Middle
                else if (i == 2)
                {//right
                    x = this.HorizOffset + 65;
                    y = (p.EABeamDepth + 5) * 0.5;
                    z = -1 * (p.WeldOffset + p.B1BeamWidth + 8) + p.EABeamDepth - 205 - p.EABeamWidth * 0.5;
                }
                else if (i == 3)
                {
                    x = this.HorizOffset + 115;
                    y = (p.EABeamDepth + 5) * 0.5;
                    z = -1 * (p.WeldOffset + p.B1BeamWidth + 8) + p.EABeamDepth - 205 - p.EABeamWidth * 0.5;
                }
                else if (i == 4)
                {//left
                    x = this.HorizOffset - 65;
                    y = (p.EABeamDepth + 5) * 0.5;
                    z = -1 * (p.WeldOffset + p.B1BeamWidth + 8) + p.EABeamDepth - 205 - p.EABeamWidth * 0.5;
                }
                else if (i == 5)
                {
                    x = this.HorizOffset - 115;
                    y = (p.EABeamDepth + 5) * 0.5;
                    z = -1 * (p.WeldOffset + p.B1BeamWidth + 8) + p.EABeamDepth - 205 - p.EABeamWidth * 0.5;
                }

                // Top
                else if (i == 6)
                {//doesn't matter
                    x = this.HorizOffset + 87.5;
                    y = p.B1BeamWidth * 0.5;
                    z = -1 * (p.WeldOffset + p.B1BeamWidth + 8);
                }
                else if (i == 7)
                {
                    x = this.HorizOffset - 87.5;
                    y = p.B1BeamWidth * 0.5;
                    z = -1 * (p.WeldOffset + p.B1BeamWidth + 8);
                }


                BoltArray bolt = new BoltArray
                {
                    Bolt = true,
                    BoltSize = 16.0,
                    BoltStandard = p.BracketBoltStandard,
                    CutLength = 150,
                    FirstPosition = new TSG.Point(x, y, z),
                    SecondPosition = new TSG.Point(x, y, z) + new TSG.Point(30, 0),
                    PartToBoltTo = bottom,
                    PartToBeBolted = bot,
                    ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                };
                if (i == 1)
                {
                    bolt.PartToBoltTo = bottom;
                    bolt.PartToBeBolted = prevBot;
                }
                else if (i >= 2 && i <= 3)
                {
                    bolt.PartToBoltTo = middleRight;
                    bolt.PartToBeBolted = mid;

                }
                else if (i >= 4 && i <= 5)
                {
                    bolt.PartToBoltTo = middleLeft;
                    bolt.PartToBeBolted = prevMid;

                }
                else if (i >= 6)
                {
                    bolt.PartToBoltTo = topEdge;
                    bolt.PartToBeBolted = topEdge;
                }

                bolt.Washer1 = false;
                bolt.Washer2 = false;
                bolt.Washer3 = true;
                bolt.Nut1 = true;
                bolt.Nut2 = false;

                bolt.Hole1 = false;
                bolt.Hole2 = false;
                bolt.Hole3 = false;
                bolt.Hole4 = false;
                bolt.Hole5 = false;

                // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)
                bolt.AddBoltDistY(0);

                // Add the distance between two bolts (set to 0 because we want one)
                bolt.AddBoltDistX(0);

                if (!bolt.PartToBeBolted.Identifier.IsValid())
                {
                    //MessageBox.Show("Invalid");

                    // Fix the validation problem with the identifier.
                    // Identifier is initialize with the default setting of having 0 as id. When id is 0, validation fails.
                    bolt.PartToBeBolted.Identifier.ID = 1;
                }

                // Insert bolts
                if (!bolt.Insert()) { MessageBox.Show("Insertion of bolt failed."); }
            }
        }

        /// <summary>
        /// Create the angled support with bolts
        /// </summary>
        /// <param name="leftCol">Indicates if it is the left column</param>
        /// <param name="rightCol">Indicates if it is the right column</param>
        public void InsertAngledSupport( bool leftCol, bool rightCol)
        {
            // 0.75 is obtained by looking at reference board which had the support at 75% of the depth. Plates were 75 dpeth by 62 width
            double depthOffset = (p.BillboardDepth - p.EABeamDepth) * 0.75;
            double theta = Math.Atan((this.VertOffset - this.OriginVertOffset) / depthOffset);

            // First create the plate to insert at the billboard anchor
            // Create points and account for plate dimensions
            TSG.Point p1 = new TSG.Point(this.HorizOffset - 31, depthOffset - 37.5 + p.EABeamDepth * 0.5 - 10, this.OriginVertOffset + 5);     // back left
            TSG.Point p2 = new TSG.Point(this.HorizOffset - 31, depthOffset + 37.5 + p.EABeamDepth * 0.5 - 10, this.OriginVertOffset + 5);     // top left
            TSG.Point p3 = new TSG.Point(this.HorizOffset + 31, depthOffset + 37.5 + p.EABeamDepth * 0.5 - 10, this.OriginVertOffset + 5);     // top right
            TSG.Point p4 = new TSG.Point(this.HorizOffset + 31, depthOffset - 37.5 + p.EABeamDepth * 0.5 - 10, this.OriginVertOffset + 5);     // back right
            List<TSG.Point> basePts = new List<TSG.Point>() { p1, p2, p3, p4 };

            // Add the first plate on top
            ContourPlate basePlate = new Plate(basePts, "PLT10", "250").ContourPlate;

            // Then create a plate on the side of the new plate with 4 points, where the left column extends from the left, the others from the right
            double xaddValue = 5;

            if (leftCol) { xaddValue = 16; }
            else if (!leftCol && rightCol) { xaddValue = 46; }    // Simple method about it
            else { xaddValue = 46; }

            // 152mm
            double refSize = p.EABeamDepth/2;
            double q = refSize / Math.Sin(Math.Abs(theta));
            double xItem = q / (1 + Math.Tan(Math.Abs(theta)));
            double alpha = Math.Acos(xItem/ refSize);
            //double alpha = Math.Acos(1 / (35 * Math.Sin(Math.Abs(theta))));
            //double hyp = 17.5 / (2 * Math.Sin(Math.Abs(theta)));
            double zAdd = refSize * Math.Sin(alpha);

            // Create points and account for plate dimensions; 3mm offset from edge of base plate, hence 34.5
            TSG.Point a = new TSG.Point(this.HorizOffset - 31 + xaddValue, depthOffset - 34.5 + p.EABeamDepth * 0.5 - 10, this.OriginVertOffset);     // top left
            TSG.Point b = new TSG.Point(this.HorizOffset - 31 + xaddValue, depthOffset + 34.5 + p.EABeamDepth * 0.5 - 10, this.OriginVertOffset);     // top right
            TSG.Point c = new TSG.Point(this.HorizOffset - 31 + xaddValue, depthOffset - 152 * Math.Cos(theta) + xItem, this.OriginVertOffset + 152 * Math.Sin(theta) - 2* zAdd);     // bot right
            TSG.Point d = new TSG.Point(this.HorizOffset - 31 + xaddValue, depthOffset - 152 * Math.Cos(theta) - xItem, this.OriginVertOffset + 152 * Math.Sin(theta) );     // bot left
            //TSG.Point c = new TSG.Point(this.HorizOffset - 31 + xaddValue, depthOffset + 34.5 - (122 + 69 * Math.Cos(theta)) * Math.Cos(theta) + p.EABeamDepth * 0.5 - 10, this.OriginVertOffset + (122 - 69 * Math.Sin(theta)) * Math.Sin(theta));     // bot right
            //TSG.Point d = new TSG.Point(this.HorizOffset - 31 + xaddValue, depthOffset - 34.5 - 122 * Math.Cos(theta) + p.EABeamDepth * 0.5 - 10, this.OriginVertOffset + 122 * Math.Sin(theta));     // bot left
            List<TSG.Point> topPts = new List<TSG.Point>() { a, b, c, d };

            // Add the bottom side support plate
            ContourPlate topSidePlate = new Plate(topPts, "PLT10", "250").ContourPlate;

            // 165mm
            // Create points and account for plate dimensions; 3mm offset from edge of base plate, hence 34.5
            TSG.Point e = new TSG.Point(this.HorizOffset - 31 + xaddValue, 5, this.VertOffset + 35 * Math.Cos(theta)); 
            TSG.Point f = new TSG.Point(this.HorizOffset - 31 + xaddValue, 5, this.VertOffset);
            TSG.Point g = new TSG.Point(this.HorizOffset - 31 + xaddValue, p.EABeamDepth, this.VertOffset);
            TSG.Point h = new TSG.Point(this.HorizOffset - 31 + xaddValue, p.EABeamDepth - ((p.EABeamDepth - p.EABeamDepth * 0.1) / 2) + 165 * Math.Cos(theta) + xItem, this.VertOffset - 165 * Math.Sin(theta) );
            TSG.Point j = new TSG.Point(this.HorizOffset - 31 + xaddValue, p.EABeamDepth - ((p.EABeamDepth - p.EABeamDepth * 0.1) / 2) + 165 * Math.Cos(theta) - xItem, this.VertOffset - 165 * Math.Sin(theta) + 2 * zAdd);
            //TSG.Point h = new TSG.Point(this.horizOffset - 31 + xaddValue, p.EABeamDepth + 134 * Math.Cos(theta), this.vertOffset - 134 * Math.Sin(theta));
            //TSG.Point j = new TSG.Point(this.horizOffset - 31 + xaddValue, p.EABeamDepth + (134) * Math.Cos(theta) - 35 * Math.Cos(theta), this.vertOffset - (134) * Math.Sin(theta) - 35 * Math.Sin(theta));
            List<TSG.Point> botPts = new List<TSG.Point>() { e, f, g, h, j };

            // Add the top side support plate
            ContourPlate lowSidePlate = new Plate(botPts, "PLT10", "250").ContourPlate;

            // Create the diagonal beam and relevant items
            int[] diagEnums = new int[] { 0, 0, 0 };
            double[] diagOffsets = new double[] { 0.0, 0.0, 0.0 };
            double xShift = 0;

            // Left column
            if (leftCol) {
            }

            // Right column
            else if (!leftCol && rightCol)
            {
                diagEnums[2] = 1;
            }    
            //Center columns
            else 
            {
                diagEnums[2] = 1;
            }

            // Insert the diagonal beam
            Beam diaogonalBeam = Box.CreateBeam(Prefix.part,Prefix.assembly,
                new TSG.Point(this.HorizOffset + xShift, depthOffset - 52 * Math.Cos(theta) + p.EABeamDepth * 0.5, this.OriginVertOffset + 52 * Math.Sin(theta)),
                new TSG.Point(this.HorizOffset + xShift, 0 + p.EABeamDepth * 0.5 + 66 * Math.Cos(theta), this.VertOffset -  66 * Math.Sin(theta)),
                p.EAMaterial,
                p.EAProfile,
                "3",
                diagEnums,
                diagOffsets
            );  //52mm from base plate, 100mm within the side plate, 66mm from the bottom base plate

            // Insert 5 bolts, 1 at the base plate and four for the connecting plates
            for (int i = 0; i < 5; i++)
            {
                double x = 0, y = 0, z = 0;
                // Base bolt
                if (i == 0)
                {
                    x = this.HorizOffset + 5;
                    y = depthOffset + p.EABeamDepth * 0.5 - 10;
                    z = this.OriginVertOffset;
                    if (!rightCol && !leftCol) { x -= 10; }
                }
                // 1st Upper beam bolt
                else if (i == 1)
                {
                    x = this.HorizOffset;
                    y = depthOffset + p.EABeamDepth * 0.5 - 10  - 70 * Math.Cos(theta);
                    z = this.OriginVertOffset + 70 * Math.Sin(theta);

                }
                // 2nd Upper beam bolt
                else if (i == 2)
                {//right
                    x = this.HorizOffset;
                    y = depthOffset + p.EABeamDepth * 0.5 - 10 - 115 * Math.Cos(theta);
                    z = this.OriginVertOffset + 115 * Math.Sin(theta);
                }
                // 1st lower beam bolt
                else if (i == 3)
                {
                    x = this.HorizOffset - 31 + xaddValue;
                    y = (p.EABeamDepth + (134) * Math.Cos(theta) - 17.5 * Math.Cos(theta)) - 28 * Math.Cos(theta);
                    z = this.VertOffset - (134) * Math.Sin(theta) - 35 * Math.Sin(theta) + 28 * Math.Sin(theta) - 5;
                }
                // 2nd lower beam bolt
                else if (i == 4)
                {
                    x = this.HorizOffset - 31 + xaddValue;
                    y = (p.EABeamDepth + (134) * Math.Cos(theta) - 17.5 * Math.Cos(theta)) - 72 * Math.Cos(theta);
                    z = this.VertOffset - (134) * Math.Sin(theta) - 35 * Math.Sin(theta) + 72 * Math.Sin(theta) - 5;
                }

                BoltArray bolt = new BoltArray
                {
                    Bolt = true,
                    BoltSize = 12.0,
                    BoltStandard = p.BracketBoltStandard,
                    CutLength = 150,
                    FirstPosition = new TSG.Point(x, y, z),
                    SecondPosition = new TSG.Point(x, y, z) + new TSG.Point(30, 0),
                    PartToBoltTo = basePlate,
                    PartToBeBolted = basePlate,
                    ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                };

                // Beam and top plate
                if (i >= 1 && i <= 4)
                {
                    if (leftCol)
                    {
                        bolt.Position.Rotation = Position.RotationEnum.TOP;
                    }
                    else
                    {
                        bolt.Position.Rotation = Position.RotationEnum.BELOW;
                    }
                    if (i == 1 || i == 2)
                    {
                        bolt.PartToBeBolted = topSidePlate;
                    }
                    else
                    {
                        bolt.PartToBeBolted = lowSidePlate;
                    }
                    bolt.PartToBoltTo = diaogonalBeam;
                    
                    bolt.SecondPosition = new TSG.Point(x, y, z) + new TSG.Point(0, 30,0);
                }

                bolt.Washer1 = false;
                bolt.Washer2 = false;
                bolt.Washer3 = true;
                bolt.Nut1 = true;
                bolt.Nut2 = false;

                bolt.Hole1 = false;
                bolt.Hole2 = false;
                bolt.Hole3 = false;
                bolt.Hole4 = false;
                bolt.Hole5 = false;

                // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)
                bolt.AddBoltDistY(0);

                // Add the distance between two bolts (set to 0 because we want one)
                bolt.AddBoltDistX(0);

                // Insert bolts
                if (!bolt.Insert()) { MessageBox.Show("Insertion of bolt failed."); }
            }
        }

        /// <summary>
        /// Install diagonal bracing on (non slanted) vertical side of the fasci box 2D
        /// <param name="xCoordinates">The vertical columns in the billboard</param>
        /// <param name="modelParameters">The parameters of the model</param>
        /// <summary>
        /// 
        public void InstallFascialBrace(List<double> xCoordinates, ModelParameters modelParameters)
        {
            // Depth, plane and rotation (DPR) enums + Offsets
            int[] DPR = new int[] { 0, 0, 0 };
            double[] DPROffsets = new double[] { 0.0, 0.0, 0.0 };

            // Extract necessary variables for calculations
            double yOffset = 10;
            double zOffsetTop = modelParameters.EABeamDepth - 200 ;
            double zOffsetBottom = 2*(-10 - modelParameters.EABeamDepth * 0.5);
            double beamOffset = -10 - modelParameters.EABeamDepth * 0.5;

            // Start end coordinates
            double xStart = 0;
            double yStart = modelParameters.EABeamDepth * 0.5;
            double zStart = -1 * (modelParameters.WeldOffset + modelParameters.B1BeamWidth + 8) - 10 +beamOffset;

            double xEnd = 0;
            double yEnd = modelParameters.EABeamDepth * 0.5;
            double zEnd = -modelParameters.FasciaBoxHeight + zStart - beamOffset; 


            // Plate dimention calculation
            // * There exist a complex set of equations which allows to calculate  standardised values of bolts and their positions.
            // However, it is not yet implemented !!!
            // Current implmentation of bracing has assumptions and for now, it will generate bolted bracing
            // List of plate offsets   
            double plateOffset = 100;

            // Check if dimension is large enough
            CheckFasciaDim(modelParameters);

            // Iterate through vertical columns
            for (int i = 0; i < (xCoordinates.Count - 1); i++)
            {
                
                // Calculate start and end positions only for X - Y and Z coordinates remain constant
                xStart += xCoordinates[i];
                xEnd += xCoordinates[i + 1];

                //// Beam type ofject for diagonal bracing
                Beam DiagonalBracing = null;

                // Calculate necessary offsets 
                List<double> PlateSizeOffsets = CalculatePlateDimensions(xStart, xEnd, zStart, zEnd);

                // CREATE BOTTOM L PLATE
                // Create points for usage
                TSG.Point aB = new TSG.Point(xEnd - plateOffset - 1, 0, zEnd   - 5);
                TSG.Point bB = new TSG.Point(xEnd - plateOffset - PlateSizeOffsets[0] * 1.5 - 1, 0, zEnd  -5);
                TSG.Point cB = new TSG.Point(xEnd - plateOffset - PlateSizeOffsets[0] * 1.5 - 1, modelParameters.EABeamDepth, zEnd  - 5);
                TSG.Point dB = new TSG.Point(xEnd - plateOffset - 1, modelParameters.EABeamDepth, zEnd - 5);
                List<TSG.Point> Bottompoints = new List<TSG.Point>() { aB, bB, cB, dB };

                // Bottom Plate Flat
                ContourPlate Bottom = new Plate(Bottompoints, "PLT10", "250").ContourPlate;
                

                // Plate for bolts
                TSG.Point aPLB = new TSG.Point(xEnd - plateOffset - 1, 5, zEnd );
                TSG.Point bPLB = new TSG.Point(xEnd - plateOffset - PlateSizeOffsets[0] *  1.5 - 1, 5, zEnd );
                TSG.Point cPLB = new TSG.Point(xEnd - plateOffset - PlateSizeOffsets[0] * 1.5 - 1, 5, zEnd  + PlateSizeOffsets[1]);
                TSG.Point dPLB = new TSG.Point(xEnd - plateOffset - 1, 5, zEnd  + PlateSizeOffsets[1]);
                List<TSG.Point> PBpoints = new List<TSG.Point>() { aPLB, bPLB, cPLB, dPLB };

                // Add the first plate
                ContourPlate boltBottomPlate = new Plate(PBpoints, "PLT10", "250").ContourPlate;

                if (i == 0) 
                {
                    /// Generate a box objects for bracing
                    DiagonalBracing = Box.CreateBeam(Prefix.part, Prefix.assembly,
                    new TSG.Point(xStart    + plateOffset , yStart + yOffset, zStart  + zOffsetTop - PlateSizeOffsets[1] / 3 - 5),
                              new TSG.Point(xEnd - plateOffset , yEnd + yOffset, zEnd  + zOffsetBottom - 2 *beamOffset + PlateSizeOffsets[1] / 3 + 5),
                                modelParameters.EAMaterial,
                                modelParameters.EAProfile,
                                "1",
                                DPR,
                                DPROffsets
                            );

                    // Plate for bolts on top beam 
                    TSG.Point aT = new TSG.Point(xStart + plateOffset - 3, 0, zStart - 2* modelParameters.B1BeamDepth + 5);
                    TSG.Point bT = new TSG.Point(xStart + plateOffset + PlateSizeOffsets[0] * 1.5 - 3, 0, zStart - 2 * modelParameters.B1BeamDepth + 5);
                    TSG.Point cT = new TSG.Point(xStart + plateOffset + PlateSizeOffsets[0] * 1.5 - 3, modelParameters.EABeamDepth , zStart - 2 * modelParameters.B1BeamDepth + 5);
                    TSG.Point dT = new TSG.Point(xStart + plateOffset - 3, modelParameters.EABeamDepth, zStart - 2 * modelParameters.B1BeamDepth + 5);
                    List<TSG.Point> TopPoints = new List<TSG.Point>() { aT, bT, cT, dT };
                    ContourPlate Top = new Plate(TopPoints, "PLT10", "250").ContourPlate;
                    

                    // Plate for bolts on bracings 
                    TSG.Point aPLT = new TSG.Point(xStart + plateOffset - 3, 5, zStart - 2 * modelParameters.B1BeamDepth );
                    TSG.Point bPLT = new TSG.Point(xStart + plateOffset + PlateSizeOffsets[0] * 1.5 - 3, 5, zStart - 2 * modelParameters.B1BeamDepth );
                    TSG.Point cPLT = new TSG.Point(xStart + plateOffset + PlateSizeOffsets[0] * 1.5 - 3, 5, zStart - 2 * modelParameters.B1BeamDepth  - PlateSizeOffsets[1]  );
                    TSG.Point dPLT = new TSG.Point(xStart + plateOffset - 3, 5, zStart - 2 * modelParameters.B1BeamDepth  - PlateSizeOffsets[1] );
                    List<TSG.Point> TopPointsPL = new List<TSG.Point>() { aPLT, bPLT, cPLT, dPLT };
                    ContourPlate TopPL = new Plate(TopPointsPL, "PLT10", "250").ContourPlate;

                    // Bolting the BRACES to the plates on TOP
                    fasciaBraceBolt(xStart, xEnd, zStart, zEnd, 0, true, DiagonalBracing, TopPL, modelParameters);
                } 
                else
                {   /// Generate a box objects for bracing
                    DiagonalBracing = Box.CreateBeam(Prefix.part, Prefix.assembly,
                    new TSG.Point(xStart +plateOffset +  38   , yStart + yOffset, zStart + zOffsetTop - PlateSizeOffsets[1]/3 - 5)  ,
                              new TSG.Point(xEnd - plateOffset, yEnd + yOffset, zEnd + zOffsetBottom - 2* beamOffset + PlateSizeOffsets[1]/3 + 5),
                                modelParameters.EAMaterial,
                                modelParameters.EAProfile,
                                "1",
                                DPR,
                                DPROffsets
                            );

                    // Plate for bolts on top beam 
                    TSG.Point aT = new TSG.Point(xStart + plateOffset + 38, 0, zStart - 2 * modelParameters.B1BeamDepth + 5);
                    TSG.Point bT = new TSG.Point(xStart + plateOffset + PlateSizeOffsets[0] * 1.5 + 38, 0, zStart - 2 * modelParameters.B1BeamDepth + 5);
                    TSG.Point cT = new TSG.Point(xStart + plateOffset + PlateSizeOffsets[0] * 1.5 + 38, modelParameters.EABeamDepth, zStart - 2 * modelParameters.B1BeamDepth + 5) ;
                    TSG.Point dT = new TSG.Point(xStart + plateOffset + 38, modelParameters.EABeamDepth, zStart - 2 * modelParameters.B1BeamDepth + 5);
                    List<TSG.Point> TopPoints = new List<TSG.Point>() { aT, bT, cT, dT };
                    ContourPlate Top = new Plate(TopPoints, "PLT10", "250").ContourPlate;
                    

                    //  Plate for bolts on bracings 
                    TSG.Point aPLT = new TSG.Point(xStart + plateOffset + 50 - 12, 5, zStart - 2 * modelParameters.B1BeamDepth);
                    TSG.Point bPLT = new TSG.Point(xStart + plateOffset + 50 + PlateSizeOffsets[0] * 1.5 - 12, 5, zStart - 2 * modelParameters.B1BeamDepth );
                    TSG.Point cPLT = new TSG.Point(xStart + plateOffset + 50 + PlateSizeOffsets[0] * 1.5 - 12, 5, zStart - 2 * modelParameters.B1BeamDepth  - PlateSizeOffsets[1] );
                    TSG.Point dPLT = new TSG.Point(xStart + plateOffset + 50 - 12, 5, zStart - 2 * modelParameters.B1BeamDepth  - PlateSizeOffsets[1] );
                    List<TSG.Point> TopPointsPL = new List<TSG.Point>() { aPLT, bPLT, cPLT, dPLT };
                    ContourPlate TopPL = new Plate(TopPointsPL, "PLT10", "250").ContourPlate;

                    // Bolting the BRACES to the plates on TOP
                    fasciaBraceBolt(xStart, xEnd, zStart, zEnd, 50, true, DiagonalBracing,  TopPL, modelParameters);
                }
                // Bolting the BRACES to the plates on BOTTOM 
                fasciaBraceBolt(xStart,xEnd,zStart,zEnd,0,false,DiagonalBracing,boltBottomPlate,modelParameters); 
             }


        }

        /// Bolt plate dimension calculation for fascia bracings
        /// <summary>
        /// <summary>
        /// 
        private List <double> CalculatePlateDimensions(double StartX, double EndX, double StartZ, double EndZ )
        {   
            // List of plate dimension- [0] = X, [1]= Z
            List<double> PlateDimension = new List<double>();

            // Get angle 
            double lengthBrace = EndX - StartX;
            double heightBrace = EndZ - StartZ;
            double boltDisp = 50;
            double theta = Math.Atan(heightBrace / lengthBrace);

            // Get Height and length of bolt plates
            double X = Math.Cos(theta) * boltDisp;
            double Z = Math.Sin(theta) * boltDisp;

            // Get final dimensions
            double botBoltOffset = 50;
            double lengthPlate = (X + botBoltOffset)  ;
            double heightPlate = (Z + botBoltOffset) * 3;
            
            PlateDimension.Add(lengthPlate);
            PlateDimension.Add(heightPlate);

            return PlateDimension;
        }

        /// Function installing bolts to plates forthe fascia box bracing 
        /// <summary>
        /// Install diagonal bracing on (non slanted) vertical side of the fasci box 2D
        /// <param name="StartX"> Start coordinate of bracing on X </param>
        /// <param name="EndX"> End coordinate of bracing on X </param>
        /// <param name="StartZ"> Start coordinate of bracing on Z </param>
        /// <param name="EndZ"> End coordinate of bracing on Z </param>
        /// <param name="Top"> Boolean indicating if the plate is on top </param>
        /// <param name="Brace"> Beam object indicating the bracing </param>m>
        /// <param name="Plate"> Beam object indicating the bracing </param>
        /// <param name="modelParameters">The parameters of the model</param>
        /// <summary>
        /// 
        private void fasciaBraceBolt
            (double StartX,
            double EndX,
            double StartZ,
            double EndZ,
            double posOffset,
            bool Top,
            Beam Brace,
            ContourPlate Plate,
            ModelParameters modelParameters)
        {
            // Few constants are gonna be used 
            double boltOffset = 30;             // Bolt offset from endpoint  (mm)
            double boltDistance = 30;           // Distance from center of each bolts (mm)
            double boltQuantity = 2;            // 2 bolt per plates  (mm)

            // Get angle 
            double lengthBrace = EndX - StartX ;
            double heightBrace = EndZ - StartZ;
            double theta = Math.Atan(heightBrace / lengthBrace);

            for (int i = 0; i < boltQuantity; i++)
            {
                // Coordinates of bolts
                double x = 0, y = 0, z = 0;

                if (Top) // Install on top beam 
                {
                    switch (i)
                    {
                        // BOLT TOP POSITIONS
                        case 0: // First bolt on the bracing TOP 
                            x = Brace.StartPoint.X + boltOffset * Math.Cos(theta);
                            y = 0;
                            z = Brace.StartPoint.Z - boltOffset * Math.Sin(theta)- modelParameters.EABeamDepth/2 + 5;
                            break;

                        case 1:// Second bolt on the bracing TOP 
                            x = Brace.StartPoint.X + (boltOffset + boltDistance) * Math.Cos(theta);
                            y = 0;
                            z = Brace.StartPoint.Z - (boltOffset - boltDistance) * Math.Sin(theta) - modelParameters.EABeamDepth / 2 +5; 
                            break;
                    }
                }
                else
                {
                    switch (i)
                    {
                        // BOLT TOP POSITIONS
                        case 0: // First bolt on the bracing TOP 
                            x = Brace.EndPoint.X - boltOffset * Math.Cos(theta) - posOffset ;
                            y = 0;
                            z = Brace.EndPoint.Z + boltOffset * Math.Sin(theta) + modelParameters.EABeamDepth / 2; 
                            break;

                        case 1:// Second bolt on the bracing TOP 
                            x = Brace.EndPoint.X - (boltOffset + boltDistance) * Math.Cos(theta) - posOffset;
                            y = 0;
                            z = Brace.EndPoint.Z + (boltOffset - boltDistance) * Math.Sin(theta) + modelParameters.EABeamDepth / 2; 
                            break;
                    }
                }


                // Inserting bolts 
                BoltArray bolt = new BoltArray
                {
                    Bolt = true,
                    BoltSize = 16.0,
                    BoltStandard = modelParameters.BracketBoltStandard,
                    CutLength = 120,
                    FirstPosition = new TSG.Point(x, y, z),
                    SecondPosition = new TSG.Point(x, y, z) + new TSG.Point(30, 0),
                    PartToBoltTo = Plate,
                    PartToBeBolted = Brace,
                    ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                };

                bolt.Washer1 = false;
                bolt.Washer2 = false;
                bolt.Washer3 = true;
                bolt.Nut1 = true;
                bolt.Nut2 = false;

                bolt.Hole1 = false;
                bolt.Hole2 = false;
                bolt.Hole3 = false;
                bolt.Hole4 = false;
                bolt.Hole5 = false;

                bolt.Position.Rotation = Position.RotationEnum.TOP;

                // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)
                bolt.AddBoltDistY(0);

                // Add the distance between two bolts (set to 0 because we want one)
                bolt.AddBoltDistX(0);
                

                // Insert bolts
                if (!bolt.Insert()) { MessageBox.Show("Insertion of bolt failed on [fascia bracing PLATES]."); }

            }
        }

        /// <summary>
        /// Function checking if fascia box dimension is appropriate for bracing. 
        ///  Gives warning message if not
        ///  Minimum dimension L * W = 2000 x 1000  (mm)
        /// </summary>
        /// <param name="xCoordinates">The vertical columns in the billboard</param>
        private void CheckFasciaDim (ModelParameters modelParameters)
        {
            // Get total height
            double totalHeight = modelParameters.ZCoordinates.Sum();
            double totalLength = modelParameters.XCoordinates.Sum();

            // get count for each list 
            int countRow = modelParameters.ZCoordinates.Count - 1;
            int countCol = modelParameters.XCoordinates.Count - 1;
            // Get length per each section
            double length = totalLength / countCol;
            double height = totalHeight/ countRow;

            bool checkHeight = height >= 1000.0;
            bool checkLength =length >= 2000.0;

            // Print message 
            if (!(checkHeight && checkLength)){ MessageBox.Show("Insertion of bolts may not be successful as dimension of fascia box cannot accomodate enough space\n" +
                "Recommended minimum Length = 2000 mm, Height = 1000mm"); }


        }

        /// <summary>
        /// The constructor of the fascia box, which generates the fascia box in the model
        /// </summary>
        /// <param name="xCoordinates">The vertical columns in the billboard</param>
        /// <param name="modelParameters">The parameters of the model</param>
        public FasciaBox(List<double> xCoordinates, ModelParameters modelParameters)
        {
            this.p = modelParameters;
            double xOffset = 0;
            double yOffset = modelParameters.EABeamDepth * 0.5;
            double zOffset = -modelParameters.FasciaBoxHeight;      // User input
            

            double zStart = -1 * ( modelParameters.WeldOffset + modelParameters.B1BeamWidth + 8) - 10;
            int[] b1Enums = new int[] { 0, 0, 0 };
            double[] b1Offsets = new double[] { 0.0, 0.0, 0.0 };
            bool first = true;

            this.OriginVertOffset = zStart;
            this.VertOffset = zStart + zOffset;

            // For horizontal orientations
            int[] horiEnums = new int[] { 0, 0, 3};
            int[] topHoriEnums = new int[] { 0, 0, 4 };

            Beam botHoriBeamPrev = null;
            Beam topHoriBeamPrev = null;

            for (int i = 0; i < xCoordinates.Count; i++)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    b1Enums[0] = 0;
                    b1Enums[1] = 0;
                    b1Enums[2] = 3;
                }

                xOffset += xCoordinates[i];
                this.HorizOffset = xOffset;

                Beam vertBeam = Box.CreateBeam(Prefix.part,Prefix.assembly,
                    new TSG.Point(xOffset, yOffset, zStart),
                    new TSG.Point(xOffset, yOffset, zStart + zOffset),
                    modelParameters.EAMaterial,
                    modelParameters.EAProfile,
                    "2",
                    b1Enums,
                    b1Offsets
                );

                Beam botHoriBeam = null;
                Beam topHoriBeam = null;

                // If not the final column, then
                if (xCoordinates.Count - 1 != i)
                {
                    
                    // Account for negative space
                    if (i == 0)
                    {
                        // Insert the horizontal beams: the bottom
                        botHoriBeam = Box.CreateBeam(Prefix.part,Prefix.assembly,
                            new TSG.Point(xOffset - modelParameters.EABeamDepth * 0.5, yOffset, zStart + zOffset - 10 - modelParameters.EABeamDepth * 0.5),
                            new TSG.Point(xOffset + xCoordinates[i + 1] - modelParameters.EABeamDepth * 0.5, yOffset, zStart + zOffset - 10 - modelParameters.EABeamDepth * 0.5),
                            modelParameters.EAMaterial,
                            modelParameters.EAProfile,
                            "2",
                            horiEnums,
                            b1Offsets
                        );

                        // The top
                        topHoriBeam = Box.CreateBeam(Prefix.part,Prefix.assembly,
                            new TSG.Point(xOffset + modelParameters.EABeamDepth * 0.5 + 12, yOffset, zStart + modelParameters.EABeamDepth - 200),
                            new TSG.Point(xOffset + xCoordinates[i + 1] - modelParameters.EABeamDepth * 0.5 - 12, yOffset, zStart + modelParameters.EABeamDepth - 200),
                            modelParameters.EAMaterial,
                            modelParameters.EAProfile,
                            "2",
                            topHoriEnums,
                            b1Offsets
                        );
                    }
                    else if (i == (xCoordinates.Count - 2))
                    {
                        // Insert the horizontal beams: the bottom
                        botHoriBeam = Box.CreateBeam(Prefix.part,Prefix.assembly,
                            new TSG.Point(xOffset + modelParameters.EABeamDepth * 0.5, yOffset, zStart + zOffset - 10 - modelParameters.EABeamDepth * 0.5),
                            new TSG.Point(xOffset + xCoordinates[i + 1] + modelParameters.EABeamDepth * 0.5, yOffset, zStart + zOffset - 10 - modelParameters.EABeamDepth * 0.5),
                            modelParameters.EAMaterial,
                            modelParameters.EAProfile,
                            "2",
                            horiEnums,
                            b1Offsets
                        );

                        // The top
                        topHoriBeam = Box.CreateBeam(Prefix.part,Prefix.assembly,
                            new TSG.Point(xOffset + modelParameters.EABeamDepth * 0.5 + 12, yOffset, zStart + modelParameters.EABeamDepth - 200),
                            new TSG.Point(xOffset + xCoordinates[i + 1] - modelParameters.EABeamDepth * 0.5 - 12, yOffset, zStart + modelParameters.EABeamDepth - 200),
                            modelParameters.EAMaterial,
                            modelParameters.EAProfile,
                            "2",
                            topHoriEnums,
                            b1Offsets
                        );
                    }
                    else
                    {
                        // Insert the horizontal beams: the bottom
                        botHoriBeam = Box.CreateBeam(Prefix.part,Prefix.assembly,
                            new TSG.Point(xOffset + modelParameters.EABeamDepth * 0.5, yOffset, zStart + zOffset - 10 - modelParameters.EABeamDepth * 0.5),
                            new TSG.Point(xOffset + xCoordinates[i + 1] - modelParameters.EABeamDepth * 0.5, yOffset, zStart + zOffset - 10 - modelParameters.EABeamDepth * 0.5),
                            modelParameters.EAMaterial,
                            modelParameters.EAProfile,
                            "2",
                            horiEnums,
                            b1Offsets
                        );

                        // The top
                        topHoriBeam = Box.CreateBeam(Prefix.part,Prefix.assembly,
                            new TSG.Point(xOffset + modelParameters.EABeamDepth * 0.5 + 12, yOffset, zStart + modelParameters.EABeamDepth - 200),
                            new TSG.Point(xOffset + xCoordinates[i + 1] - modelParameters.EABeamDepth * 0.5 - 12, yOffset, zStart + modelParameters.EABeamDepth - 200),
                            modelParameters.EAMaterial,
                            modelParameters.EAProfile,
                            "2",
                            topHoriEnums,
                            b1Offsets
                        );
                    }
                }


                if (i != 0 && i != xCoordinates.Count -1)
                {
                    // Create points
                    TSG.Point p1 = new TSG.Point(xOffset - 112.5, 0, zStart + 5);
                    TSG.Point p2 = new TSG.Point(xOffset + 112.5, 0, zStart + 5);
                    TSG.Point p3 = new TSG.Point(xOffset + 112.5, modelParameters.B1BeamWidth, zStart + 5);
                    TSG.Point p4 = new TSG.Point(xOffset - 112.5, modelParameters.B1BeamWidth, zStart + 5);
                    List<TSG.Point> pts = new List<TSG.Point>() { p1, p2, p3, p4 };

                    // Add the first plate on top
                    ContourPlate aPlate = new Plate(pts, "PLT10", "250").ContourPlate;

                    // Translate the positions
                    p1.Translate(12.5, 0, zOffset - 10);
                    p2.Translate(-12.5, 0, zOffset - 10);
                    p3.Translate(-12.5, - modelParameters.B1BeamWidth + modelParameters.EABeamDepth, zOffset - 10);
                    p4.Translate(12.5, -modelParameters.B1BeamWidth + modelParameters.EABeamDepth, zOffset - 10);

                    // Add the bottom plate
                    ContourPlate bPlate = new Plate(pts, "PLT10", "250").ContourPlate;

                    // Add the top level plates on either side of the beam
                    // Translate the positions to upper level
                    TSG.Point tp1 = new TSG.Point(xOffset + modelParameters.EABeamWidth * 0.5, 5, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    TSG.Point tp2 = new TSG.Point(xOffset + 137, 5, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    TSG.Point tp3 = new TSG.Point(xOffset + 137,modelParameters.EABeamWidth, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    TSG.Point tp4 = new TSG.Point(xOffset + modelParameters.EABeamWidth * 0.5, modelParameters.EABeamWidth, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    List<TSG.Point> tpts = new List<TSG.Point>() { tp1, tp2, tp3, tp4 };

                    // Add the first middle plate
                    ContourPlate tRPlate = new Plate(tpts, "PLT10", "250").ContourPlate;

                    // Translate the positions
                    tp1.Translate(-162.2, 0, 0);
                    tp2.Translate(-116.6, 0, 0);
                    tp3.Translate(-116.6, 0, 0);
                    tp4.Translate(-162.2, 0, 0);

                    // Add the second middle plate
                    ContourPlate tLPlate = new Plate(tpts, "PLT10", "250").ContourPlate;

                    AddColumnBolts(topHoriBeam, topHoriBeamPrev, botHoriBeam, botHoriBeamPrev, aPlate, tRPlate, tLPlate, bPlate);
                }

                // If the first column
                else if (i == 0)
                {
                    // The very top corner plate
                    // Create points for usage
                    TSG.Point a = new TSG.Point(-modelParameters.EABeamDepth * 0.5, 0, zStart + 5);
                    TSG.Point b = new TSG.Point(-modelParameters.EABeamDepth * 0.5 + 275, 0, zStart + 5);
                    TSG.Point c = new TSG.Point(-modelParameters.EABeamDepth * 0.5 + 275, modelParameters.B1BeamWidth, zStart + 5);
                    TSG.Point d = new TSG.Point(-modelParameters.EABeamDepth * 0.5, modelParameters.B1BeamWidth, zStart + 5);
                    List<TSG.Point> points = new List<TSG.Point>() { a, b, c, d };

                    // Add the first plate
                    ContourPlate p = new Plate(points, "PLT10", "250").ContourPlate;

                    // Create points
                    TSG.Point p1 = new TSG.Point(xOffset - modelParameters.EABeamWidth * 0.5 + 5, 5, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    TSG.Point p2 = new TSG.Point(xOffset + 96, 5, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    TSG.Point p3 = new TSG.Point(xOffset + 96, modelParameters.EABeamWidth, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    TSG.Point p4 = new TSG.Point(xOffset - modelParameters.EABeamWidth * 0.5 + 5,modelParameters.EABeamWidth, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    List<TSG.Point> pts = new List<TSG.Point>() { p1, p2, p3, p4 };

                    // Add the plate on top
                    ContourPlate aPlate = new Plate(pts, "PLT10", "250").ContourPlate;

                    // Translate plate positioms
                    TSG.Point e = new TSG.Point(-modelParameters.EABeamDepth * 0.5, 0, zStart + zOffset - 5);
                    TSG.Point f = new TSG.Point(-modelParameters.EABeamDepth * 0.5, modelParameters.EABeamWidth, zStart + zOffset - 5);
                    TSG.Point g = new TSG.Point(-modelParameters.EABeamDepth * 0.5 + 125, modelParameters.EABeamWidth, zStart + zOffset - 5);
                    TSG.Point h = new TSG.Point(-modelParameters.EABeamDepth * 0.5 + 125, 0, zStart + zOffset - 5);

                    List<TSG.Point> ptss = new List<TSG.Point>() { e, f, g, h };

                    // Add the second plate
                    ContourPlate pS = new Plate(ptss, "PLT10", "250").ContourPlate;

                    AddEdgeBoltsBolts(true, topHoriBeam, botHoriBeam, aPlate, pS, p);

                }
                // If the last column
                else
                {
                    // The very top corner plate
                    // Add the second last plate
                    // Create points for usage
                    TSG.Point a = new TSG.Point(-modelParameters.EABeamDepth * 0.5, 0, zStart + 5);
                    TSG.Point b = new TSG.Point(-modelParameters.EABeamDepth * 0.5 + 275, 0, zStart + 5);
                    TSG.Point c = new TSG.Point(-modelParameters.EABeamDepth * 0.5 + 275, modelParameters.B1BeamWidth, zStart + 5);
                    TSG.Point d = new TSG.Point(-modelParameters.EABeamDepth * 0.5, modelParameters.B1BeamWidth, zStart + 5);
                    List<TSG.Point> points = new List<TSG.Point>() { a, b, c, d };

                    a.Translate(xOffset - 275 + modelParameters.EABeamDepth, 0, 0);
                    b.Translate(xOffset - 275 + modelParameters.EABeamDepth, 0, 0);
                    c.Translate(xOffset - 275 + modelParameters.EABeamDepth, 0, 0);
                    d.Translate(xOffset - 275 + modelParameters.EABeamDepth, 0, 0);

                    // Add the second last plate
                    ContourPlate pE = new Plate(points, "PLT10", "250").ContourPlate; ;

                    // Create points
                    TSG.Point p1 = new TSG.Point(xOffset - modelParameters.EABeamWidth * 0.5 + 5 - 75.6, 5, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    TSG.Point p2 = new TSG.Point(xOffset + 20.4, 5, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    TSG.Point p3 = new TSG.Point(xOffset + 20.4, modelParameters.EABeamWidth, zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    TSG.Point p4 = new TSG.Point(xOffset - modelParameters.EABeamWidth * 0.5 + 5 - 75.6, modelParameters.EABeamWidth , zStart + modelParameters.EABeamDepth - 205 - modelParameters.EABeamWidth * 0.5);
                    List<TSG.Point> pts = new List<TSG.Point>() { p1, p2, p3, p4 };

                    // Add the plate on top
                    ContourPlate aPlate = new Plate(pts, "PLT10", "250").ContourPlate;

                    // Translate plate positioms
                    TSG.Point e = new TSG.Point(xOffset - 125 + modelParameters.EABeamDepth * 0.5, 0, zStart + zOffset - 5);
                    TSG.Point f = new TSG.Point(xOffset - 125 + modelParameters.EABeamDepth * 0.5, modelParameters.EABeamWidth, zStart + zOffset - 5);
                    TSG.Point g = new TSG.Point(xOffset + modelParameters.EABeamDepth * 0.5, modelParameters.EABeamWidth, zStart + zOffset - 5);
                    TSG.Point h = new TSG.Point(xOffset + modelParameters.EABeamDepth * 0.5, 0, zStart + zOffset - 5);

                    List<TSG.Point> ptss = new List<TSG.Point>() { e, f, g, h };

                    // Add the second plate
                    ContourPlate pS = new Plate(ptss, "PLT10", "250").ContourPlate;

                    AddEdgeBoltsBolts(false, topHoriBeamPrev, botHoriBeamPrev, aPlate, pS, pE);
                }

                if (i == 0)
                {
                    InsertAngledSupport(true, false);
                }
                else if (i == xCoordinates.Count - 1)
                {
                    InsertAngledSupport(false, true);
                }
                else
                {
                    InsertAngledSupport(false, false);
                }
                botHoriBeamPrev = botHoriBeam;
                topHoriBeamPrev = topHoriBeam;
            }

            InstallFascialBrace(xCoordinates, modelParameters);

        }
    }
}