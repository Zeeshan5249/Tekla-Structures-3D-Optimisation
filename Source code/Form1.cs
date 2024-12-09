using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text.Json;
using Tekla.Structures;
using Tekla.Structures.Catalogs;
using Tekla.Structures.Dialog;
using Tekla.Structures.Dialog.UIControls;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;
using TSD = Tekla.Structures.Datatype;
using TSC = Tekla.Structures.Catalogs;
using static Tekla.Structures.Filtering.Categories.PartFilterExpressions;
using System.Net;
using System.Runtime.Remoting;
using System.Collections;
using System.Reflection;




/*
 *  CRISP BILLBOARD AID
 */
namespace TeklaBillboardAid
{
    /// <summary>
    /// Windows Form to power the Tekla Billboard Aid program.
    /// </summary>
    public partial class Form1 : ApplicationFormBase
    {

        public readonly Model MyModel;
        public ModelParameters modelParameters;
        
            /// <summary>
            /// Constructor to initialise the Windows Form application.
            /// </summary>
            public Form1()
        {
            InitializeComponent();
            MyModel = new Model();

            modelParameters = new ModelParameters();
            
            if (!MyModel.GetConnectionStatus())
            {
                MessageBox.Show("Tekla 2022 not running");
                return;
            }

            MyModel.CommitChanges();
        }

        /// <summary>
        /// When the Build button is clicked, build the model in Tekla Structures.
        /// </summary>
        private void BuildButton_Click(object sender, EventArgs e)
        {
            // Disable build button until validated again
            button1.Enabled = false;

            // Check that the program is connected to tekla
            if (!MyModel.GetConnectionStatus())
            {
                MessageBox.Show("Tekla 2022 not running");
                return;
            }
            if (!Radius_Text.Enabled)
            {
                // Setting variables for hatches.
                bool HatchFlag = false;
                bool IsLeftHatch = true;
                bool TopHatchFlag = true;
                modelParameters.Radius = 0;
                modelParameters.HeightOffsetBottom += 8;

                if (modelParameters.LadderMode == 0) // Left hatch
                {
                    HatchFlag = true;
                    IsLeftHatch = true;
                }
                else if (modelParameters.LadderMode == 1) // Right hatch
                {
                    HatchFlag = true;
                    IsLeftHatch = false;
                }

                double HatchDistanceFromLadder = modelParameters.LadderOffsetBack + 65 + 50;
                double HatchWidth = modelParameters.HatchWidth;



                // Insert LED screen material into materials catalog
                TSC.MaterialItem LEDMaterialItem = new MaterialItem();
                LEDMaterialItem.MaterialName = LEDMaterial.Text;
                LEDMaterialItem.ProfileDensity = Convert.ToDouble(LEDDensity.Text);
                LEDMaterialItem.PlateDensity = Convert.ToDouble(LEDDensity.Text);
                LEDMaterialItem.Type = TSC.MaterialItem.MaterialItemTypeEnum.MATERIAL_MISC;
                LEDMaterialItem.Insert();

                // Create a list of x coordinates for the planes / spacings between the columns from engineering drawings
                List<double> xCoordinates = modelParameters.XCoordinates;

                // List of Z coordinates
                List<double> zCoordinates = modelParameters.ZCoordinates;

                // List of mid walkway heights, offset from the bottom of the billboard
                List<double> walkwayList = modelParameters.WalkwayList;

                // Lists of indexes where splits should be made
                List<int> xSplits = modelParameters.XSplits;
                List<int> zSplits = modelParameters.ZSplits;


                // Create a variable for the mesh thickness 
                double meshThickness = modelParameters.MeshThickness;



                double B3BeamWidth = modelParameters.B3BeamWidth;
                double B1BeamWidth = modelParameters.B1BeamWidth;
                double B1BeamDepth = modelParameters.B1BeamDepth;
                double BR1BeamDepth = modelParameters.BR1BeamDepth;
                double C1BeamWidth = modelParameters.C1BeamWidth;

                // Difference between depth of B1 and B5
                double differenceb1b5Depth = modelParameters.B1BeamDepth - modelParameters.B5BeamDepth;

                // Initialise the height coordinates or altitude location based on the engineering drawing 
                // We add the mesh thickness and subtract the difference in depth between b1 and b5 from the user since the dimensions ar given from the top of the mesh int he engineering drawing 
                List<double> railingCoordinates = modelParameters.RailingCoordinates;

                // Cabinet starting offset, half the profile dimension of the starting beam
                //double cabinetXOffset = (ModelParameters.BeamDimensions(modelParameters.C1Profile)[1]) / 2;
                double cabinetXOffset = 0;
                modelParameters.CabinetXOffset = cabinetXOffset;
                double cabinetZOffSet = 0;
                CreateCabinet(xCoordinates, zCoordinates, cabinetXOffset, cabinetZOffSet, false);

                List<double> xSubCoordinates = new List<double>();
                List<double> zSubCoordinates = new List<double>();
                List<double> walkwaySubList = new List<double>();

                walkwayList.Sort();
                double boxLength;
                double boxHeight;
                TSG.Point OriginOffset = new TSG.Point();

                List<Box> boxes = new List<Box>();

                if (zSplits.Count == 0)
                {
                    boxHeight = modelParameters.ScreenHeight;

                    if (xSplits.Count == 0)
                    {
                        boxLength = modelParameters.ScreenLength;
                        boxes.Add(new Box(zCoordinates, xCoordinates, walkwayList, boxHeight, boxLength, new TSG.Point(0, 0, 0), false, false, false, false, StructureAutoRadio.Checked, modelParameters, HatchFlag, IsLeftHatch, TopHatchFlag, HatchDistanceFromLadder, HatchWidth));

                    }
                    else
                    {
                        boxLength = 0;
                        for (int i = 0; i < xCoordinates.Count; i++)
                        {
                            boxLength += xCoordinates[i];
                            xSubCoordinates.Add(xCoordinates[i]);

                            // Detect Vertical split
                            if (xSplits.Contains(i) || i == xCoordinates.Count - 1)
                            {
                                bool side2 = true;
                                bool side4 = true;
                                if (i == xCoordinates.Count - 1)
                                {
                                    side4 = false;
                                }
                                if (OriginOffset.X == 0)
                                {
                                    side2 = false;
                                }

                                // Check if there need a hatch.
                                if (HatchFlag && ((IsLeftHatch && !side2) || (!IsLeftHatch && !side4)))
                                {
                                    boxes.Add(new Box(zCoordinates, xSubCoordinates, walkwayList, boxHeight, boxLength, OriginOffset, false, side2, false, side4, StructureAutoRadio.Checked, modelParameters, HatchFlag, IsLeftHatch, TopHatchFlag, HatchDistanceFromLadder, HatchWidth));
                                }
                                else
                                {
                                    boxes.Add(new Box(zCoordinates, xSubCoordinates, walkwayList, boxHeight, boxLength, OriginOffset, false, side2, false, side4, StructureAutoRadio.Checked, modelParameters));
                                }

                                xSubCoordinates.Clear();
                                xSubCoordinates.Add(0);
                                OriginOffset.X += boxLength;
                                boxLength = 0;
                            }
                        }
                    }
                }
                else
                {
                    boxHeight = 0;
                    for (int j = 0; j < zCoordinates.Count; j++)
                    {
                        boxHeight += zCoordinates[j];
                        zSubCoordinates.Add(zCoordinates[j]);

                        // Detect horizontal Split
                        if (zSplits.Contains(j) || j == zCoordinates.Count - 1)
                        {
                            // Figure out which side is a split or edge.
                            bool side1 = true;
                            bool side3 = true;
                            if (j == zCoordinates.Count - 1)
                            {
                                side3 = false;
                            }
                            if (OriginOffset.Z == 0)
                            {
                                side1 = false;
                            }

                            // Populate WalkwaySubList
                            for (int k = 0; k < walkwayList.Count; k++)
                            {
                                if (walkwayList[k] > OriginOffset.Z && walkwayList[k] < OriginOffset.Z + boxHeight)
                                {
                                    walkwaySubList.Add(walkwayList[k] - OriginOffset.Z);
                                }
                            }

                            // If there's no vertical splits then just make a box. (Phase III comment: no HORIZONTAL split?)
                            if (xSplits.Count == 0)
                            {
                                boxLength = modelParameters.ScreenLength;

                                // No HORIZONTAL split so hatch will definitely be at this column if a hatch is needed.
                                // If it is the top box, pass in the top hatch flag.
                                if (!side3)
                                {
                                    boxes.Add(new Box(zSubCoordinates, xCoordinates, walkwaySubList, boxHeight, boxLength, OriginOffset, side1, false, side3, false, StructureAutoRadio.Checked, modelParameters, HatchFlag, IsLeftHatch, TopHatchFlag, HatchDistanceFromLadder, HatchWidth));
                                }
                                else
                                {
                                    boxes.Add(new Box(zSubCoordinates, xCoordinates, walkwaySubList, boxHeight, boxLength, OriginOffset, side1, false, side3, false, StructureAutoRadio.Checked, modelParameters, HatchFlag, IsLeftHatch, false, HatchDistanceFromLadder, HatchWidth));
                                }

                            }
                            else
                            {
                                boxLength = 0;
                                for (int i = 0; i < xCoordinates.Count; i++)
                                {
                                    boxLength += xCoordinates[i];
                                    xSubCoordinates.Add(xCoordinates[i]);

                                    // Detect Vertical Split
                                    if (xSplits.Contains(i) || i == xCoordinates.Count - 1)
                                    {
                                        bool side2 = true;
                                        bool side4 = true;
                                        if (i == xCoordinates.Count - 1)
                                        {
                                            side4 = false;
                                        }
                                        if (OriginOffset.X == 0)
                                        {
                                            side2 = false;
                                        }

                                        // Check if the box generating will have hatch/es.
                                        if (HatchFlag && (IsLeftHatch && !side2) || (!IsLeftHatch && !side4))
                                        {
                                            if (!side3) // If the top most box, pass top hatch flag.
                                            {
                                                boxes.Add(new Box(zSubCoordinates, xSubCoordinates, walkwaySubList, boxHeight, boxLength, OriginOffset, side1, side2, side3, side4, StructureAutoRadio.Checked, modelParameters, HatchFlag, IsLeftHatch, TopHatchFlag, HatchDistanceFromLadder, HatchWidth));

                                            }
                                            else
                                            {
                                                boxes.Add(new Box(zSubCoordinates, xSubCoordinates, walkwaySubList, boxHeight, boxLength, OriginOffset, side1, side2, side3, side4, StructureAutoRadio.Checked, modelParameters, HatchFlag, IsLeftHatch, false, HatchDistanceFromLadder, HatchWidth));
                                            }
                                        }
                                        else
                                        {
                                            boxes.Add(new Box(zSubCoordinates, xSubCoordinates, walkwaySubList, boxHeight, boxLength, OriginOffset, side1, side2, side3, side4, StructureAutoRadio.Checked, modelParameters));
                                        }

                                        xSubCoordinates.Clear();
                                        xSubCoordinates.Add(0);
                                        OriginOffset.X += boxLength;
                                        boxLength = 0;
                                    }
                                }
                            }
                            // Reset parameters
                            zSubCoordinates.Clear();
                            zSubCoordinates.Add(0);
                            xSubCoordinates.Clear();
                            walkwaySubList.Clear();
                            OriginOffset.Z += boxHeight;
                            OriginOffset.X = 0;
                            boxHeight = 0;
                        }
                    }
                }

                // Connect Split EA Beams between horizontal box splits
                foreach (Box box in boxes)
                {
                    // Check if box has a split at the top.
                    if (box.Side3)
                    {
                        // Now loop through the boxes untill you find the box above it
                        for (int i = 0; i < boxes.Count; i++)
                        {

                            if (boxes[i].BoxOrigin.X == box.BoxOrigin.X && boxes[i].BoxOrigin.Z == box.BoxOrigin.Z + box.Height)
                            {
                                // Now get the beams to be connected
                                Beam TopBeam = boxes[i].B1Beam1;
                                Beam BotBeam = box.B1Beam3;

                                double CurrentPlane = 0;

                                // Now Connect them with a bolt on each frame
                                for (int j = 0; j < box.XSubCoordinates.Count; j++)
                                {
                                    CurrentPlane += box.XSubCoordinates[j];


                                    // Create a new bolt array
                                    BoltArray Hole1 = new BoltArray
                                    {
                                        Bolt = true,
                                        BoltSize = 12,
                                        BoltStandard = modelParameters.BracketBoltStandard,
                                        CutLength = 100,
                                        FirstPosition = new TSG.Point(
                                            CurrentPlane + boxes[i].BoxOrigin.X - modelParameters.EASplitBoltOffset,
                                            boxes[i].BoxOrigin.X + modelParameters.B1BeamWidth / 2,
                                            boxes[i].BoxOrigin.Z + modelParameters.B1SplitBeamThickness + modelParameters.BoxGap
                                            ),
                                        SecondPosition = new TSG.Point(
                                            CurrentPlane + boxes[i].BoxOrigin.X - modelParameters.EASplitBoltOffset,
                                            boxes[i].BoxOrigin.X + modelParameters.B1BeamWidth / 2 + 100,
                                            boxes[i].BoxOrigin.Z + modelParameters.B1SplitBeamThickness + modelParameters.BoxGap
                                            ),
                                        PartToBoltTo = TopBeam,
                                        PartToBeBolted = BotBeam,
                                        ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                                    };

                                    // Bolt offsets
                                    Hole1.Position.Depth = Position.DepthEnum.MIDDLE;
                                    Hole1.Position.DepthOffset = 0;
                                    Hole1.Position.Plane = Position.PlaneEnum.MIDDLE;
                                    Hole1.Position.PlaneOffset = 0;
                                    Hole1.Position.Rotation = Position.RotationEnum.FRONT;
                                    Hole1.Position.RotationOffset = 0;

                                    // the following properties determine the shape of bolts
                                    // In this case, we set everything to false
                                    Hole1.Washer1 = true;
                                    Hole1.Washer2 = true;
                                    Hole1.Washer3 = false;
                                    Hole1.Nut1 = true;
                                    Hole1.Nut2 = false;

                                    Hole1.Hole1 = false;
                                    Hole1.Hole2 = false;
                                    Hole1.Hole3 = false;
                                    Hole1.Hole4 = false;
                                    Hole1.Hole5 = false;

                                    // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                                    Hole1.AddBoltDistY(0);

                                    // Add the distance between two holes (set to 0 because we want one)
                                    Hole1.AddBoltDistX(0);

                                    // Create a new bolt array
                                    BoltArray Hole2 = new BoltArray
                                    {
                                        Bolt = true,
                                        BoltSize = 12,
                                        BoltStandard = modelParameters.BracketBoltStandard,
                                        CutLength = 100,
                                        FirstPosition = new TSG.Point(
                                            CurrentPlane + boxes[i].BoxOrigin.X + modelParameters.EASplitBoltOffset,
                                            boxes[i].BoxOrigin.X + modelParameters.B1BeamWidth / 2,
                                            boxes[i].BoxOrigin.Z + modelParameters.B1SplitBeamThickness + modelParameters.BoxGap
                                            ),
                                        SecondPosition = new TSG.Point(
                                            CurrentPlane + boxes[i].BoxOrigin.X + modelParameters.EASplitBoltOffset,
                                            boxes[i].BoxOrigin.X + modelParameters.B1BeamWidth / 2 + 100,
                                            boxes[i].BoxOrigin.Z + modelParameters.B1SplitBeamThickness + modelParameters.BoxGap
                                            ),
                                        PartToBoltTo = TopBeam,
                                        PartToBeBolted = BotBeam,
                                        ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                                    };

                                    // Bolt offsets
                                    Hole2.Position.Depth = Position.DepthEnum.MIDDLE;
                                    Hole2.Position.DepthOffset = 0;
                                    Hole2.Position.Plane = Position.PlaneEnum.MIDDLE;
                                    Hole2.Position.PlaneOffset = 0;
                                    Hole2.Position.Rotation = Position.RotationEnum.FRONT;
                                    Hole2.Position.RotationOffset = 0;

                                    // the following properties determine the shape of bolts
                                    // In this case, we set everything to false
                                    Hole2.Washer1 = true;
                                    Hole2.Washer2 = true;
                                    Hole2.Washer3 = false;
                                    Hole2.Nut1 = true;
                                    Hole2.Nut2 = false;

                                    Hole2.Hole1 = false;
                                    Hole2.Hole2 = false;
                                    Hole2.Hole3 = false;
                                    Hole2.Hole4 = false;
                                    Hole2.Hole5 = false;

                                    // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                                    Hole2.AddBoltDistY(0);

                                    // Add the distance between two holes (set to 0 because we want one)
                                    Hole2.AddBoltDistX(0);

                                    // Check if to add the hole or not
                                    if (j == 0)
                                    {
                                        // Insert the second hole
                                        if (!Hole2.Insert())
                                        {
                                            MessageBox.Show("Insertion of Bolt failed.");
                                        }
                                    }
                                    else if (j == box.XSubCoordinates.Count - 1)
                                    {
                                        // Insert the first hole
                                        if (!Hole1.Insert())
                                        {
                                            MessageBox.Show("Insertion of Bolt failed.");
                                        }
                                    }
                                    else
                                    {
                                        // Insert both holes
                                        if (!Hole1.Insert())
                                        {
                                            MessageBox.Show("Insertion of Bolt failed.");
                                        }
                                        if (!Hole2.Insert())
                                        {
                                            MessageBox.Show("Insertion of Bolt failed.");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                // Make lift points
                foreach (Box box in boxes)
                {
                    foreach (double liftTopX in modelParameters.LiftPointsTopX)
                    {
                        double Z = box.Side3 ? box.BoxOrigin.Z + box.Height - modelParameters.WeldOffset : box.BoxOrigin.Z + box.Height + modelParameters.HeightOffsetTop + B1BeamDepth;
                        if (liftTopX > box.BoxOrigin.X && liftTopX < box.BoxOrigin.X + box.Length) // TOP
                        {
                            new LiftPoint(
                                box.B1Beam3,
                                new TSG.Point(
                                    liftTopX,
                                    0.5 * B1BeamWidth,
                                    Z),
                                modelParameters.LugPlateWidth,
                                true,
                                modelParameters.LugPlateProfile,
                                modelParameters.LugPlateMaterial,
                                modelParameters.HeightOffsetBottom,
                                modelParameters.BracketBoltStandard);


                            new LiftPoint(
                                box.B1Beam4,
                                new TSG.Point(
                                    liftTopX,
                                    modelParameters.BillboardDepth - 0.5 * B1BeamWidth,
                                    Z),
                                modelParameters.LugPlateWidth,
                                true,
                                modelParameters.LugPlateProfile,
                                modelParameters.LugPlateMaterial,
                                modelParameters.HeightOffsetBottom,
                                modelParameters.BracketBoltStandard);
                        }
                    }

                    foreach (double liftBottomX in modelParameters.LiftPointsBottomX)
                    {
                        double Z = box.Side1 ? box.BoxOrigin.Z + B1BeamDepth - modelParameters.WeldOffset + 10 : box.BoxOrigin.Z;
                        if (liftBottomX > box.BoxOrigin.X && liftBottomX < box.BoxOrigin.X + box.Length)
                        {
                            new LiftPoint(
                                box.B1Beam1,
                                new TSG.Point(
                                    liftBottomX,
                                    0.5 * B1BeamWidth,
                                    Z),
                                modelParameters.LugPlateWidth,
                                false,
                                modelParameters.LugPlateProfile,
                                modelParameters.LugPlateMaterial,
                                modelParameters.HeightOffsetBottom,
                                modelParameters.BracketBoltStandard);


                            new LiftPoint(
                                box.B1Beam2,
                                new TSG.Point(
                                    liftBottomX,
                                    modelParameters.BillboardDepth - 0.5 * B1BeamWidth,
                                    Z),
                                modelParameters.LugPlateWidth,
                                false,
                                modelParameters.LugPlateProfile,
                                modelParameters.LugPlateMaterial,
                                modelParameters.HeightOffsetBottom,
                                modelParameters.BracketBoltStandard);
                        }
                    }
                }

                // Flashing
                if (modelParameters.FlashingEnabled)
                {
                    Flashing flashingLeft = new Flashing(new[] { BillboardSide.Left }, modelParameters);
                    Flashing flashingRight = new Flashing(new[] { BillboardSide.Right }, modelParameters);
                    Flashing flashingBottom = new Flashing(new[] { BillboardSide.Bottom }, modelParameters);
                    Flashing flashingTop = new Flashing(new[] { BillboardSide.Top }, modelParameters);
                    List<Part> cutPartsTop = new List<Part>(), cutPartsLeft = new List<Part>(), cutPartsRight = new List<Part>();

                    foreach (Box box in boxes)
                    {
                        foreach (Frame f in box.Planes)
                        {
                            foreach (Beam b in f.B2Beams) { cutPartsTop.Add(b); }
                        }
                    }

                    // top flashing intersects with camera arm on top
                    if (!modelParameters.NoArm && modelParameters.ArmAtTop)
                    {
                        cutPartsTop.Add(Diagonal.CameraArmLeft);

                        if (Diagonal.CameraArmRight != null) { cutPartsTop.Add(Diagonal.CameraArmRight); }

                        cutPartsTop.Add(Diagonal.CameraArm.BasePlateUpper.ContourPlate);
                        cutPartsTop.Add(Diagonal.CameraArm.SupPlateRight.ContourPlate);
                        cutPartsTop.Add(Diagonal.CameraArm.SupPlateLeft.ContourPlate);

                        if (Diagonal.CameraArm.ExtraSupPlateLeft != null)
                        {
                            cutPartsTop.Add(Diagonal.CameraArm.ExtraSupPlateLeft.ContourPlate);
                            cutPartsTop.Add(Diagonal.CameraArm.ExtraSupPlateRight.ContourPlate);
                        }
                    }

                    // top flashing intersects with side railings
                    cutPartsTop.Add(HorizontalRailing.TopLeftSideRailing);
                    cutPartsTop.Add(HorizontalRailing.TopRightSideRailing);

                    // vertical flashings intersect with horizontal flashings
                    cutPartsLeft.Add(flashingTop.PolyBeams[0]);
                    cutPartsLeft.Add(flashingBottom.PolyBeams[0]);
                    cutPartsRight.Add(flashingTop.PolyBeams[0]);
                    cutPartsRight.Add(flashingBottom.PolyBeams[0]);

                    // trim intersecting parts
                    CutParts(flashingTop.PolyBeams[0], cutPartsTop);
                    CutParts(flashingLeft.PolyBeams[0], cutPartsLeft);
                    CutParts(flashingRight.PolyBeams[0], cutPartsRight);
                }

                // Cladding
                for (int i = 0; i < 5; i++)
                {
                    if (modelParameters.CladdingTypes[i] != CladdingType.None)
                    {
                        modelParameters.BillboardHeight -= modelParameters.TopCladdingOffsets[i];
                        new Cladding(modelParameters.CladdingTypes[i], modelParameters,
                            (BillboardSide)i, modelParameters.CladdingColours[i], modelParameters.CladdingPercentsOpenArea[i], modelParameters.CladdingThicknesses[i]);
                    }
                }


                // Fascia Box
                if (modelParameters.FasciaEnabled)
                {
                    if (modelParameters.isTwoD)
                    {
                        new FasciaBox(modelParameters.XCoordinates, modelParameters);
                    }
                    else
                    {
                        new _3DFascia(new List<double> { -modelParameters.FasciaBoxHeight }, xCoordinates, modelParameters.FasciaBoxHeight, modelParameters.BillboardLength, new TSG.Point(0, 0, 0), false, false, false, false, StructureAutoRadio.Checked, modelParameters);
                    }
                }

                // Weight
                double totalWeight = 0;
                double objectWeight = 0;
                // int objects = 0;
                Type[] types = { typeof(Part),
                    typeof(BoltGroup) };



                foreach (ModelObject obj in MyModel.GetModelObjectSelector().GetAllObjectsWithType(types))
                {
                    if (obj != null && obj.GetReportProperty("WEIGHT", ref objectWeight))
                    {
                        totalWeight += objectWeight;
                    }
                    else
                    {
                        Console.WriteLine("Error retrieving weight");
                    }
                }
                BillboardWeight.Text = String.Format("{0:0.###}", totalWeight);

                // BACC BRACING INSTALLATION
                if (modelParameters.EnableBackBracing)
                {
                    for (int i = 0; i < boxes.Count; i++)
                    {
                        Diagonal.BackShot(boxes[i], modelParameters, i);
                    }
                }

                MyModel.CommitChanges();
            }
            this.button1.Click -= new System.EventHandler(this.BuildButton_Click);

        }

        /// <summary>
        /// When the Build button is clicked, build the curve model in Tekla Structures.
        /// </summary>
        private void BuildCurve_Button_Click(object sender, EventArgs e)
        {
            // Disable build button until validated again
            button1.Enabled = false;

            // Check that the program is connected to tekla
            if (!MyModel.GetConnectionStatus())
            {
                MessageBox.Show("Tekla 2022 not running");
                return;
            }

            if (Radius_Text.Enabled)
            {
                modelParameters.HeightOffsetBottom += 8;

                // Insert LED screen material into materials catalog
                TSC.MaterialItem LEDMaterialItem = new MaterialItem();
                LEDMaterialItem.MaterialName = LEDMaterial.Text;
                LEDMaterialItem.ProfileDensity = Convert.ToDouble(LEDDensity.Text);
                LEDMaterialItem.PlateDensity = Convert.ToDouble(LEDDensity.Text);
                LEDMaterialItem.Type = TSC.MaterialItem.MaterialItemTypeEnum.MATERIAL_MISC;
                LEDMaterialItem.Insert();

                // Create a list of x coordinates for the planes / spacings between the columns from engineering drawings
                List<double> xCoordinates = modelParameters.XCoordinates;

                // List of Z coordinates
                List<double> zCoordinates = modelParameters.ZCoordinates;

                // Create a variable for the mesh thickness 
                double meshThickness = modelParameters.MeshThickness;

                double B3BeamWidth = modelParameters.B3BeamWidth;
                double B1BeamWidth = modelParameters.B1BeamWidth;
                double B1BeamDepth = modelParameters.B1BeamDepth;
                double BR1BeamDepth = modelParameters.BR1BeamDepth;
                double C1BeamWidth = modelParameters.C1BeamWidth;

                // Difference between depth of B1 and B5
                double differenceb1b5Depth = modelParameters.B1BeamDepth - modelParameters.B5BeamDepth;

                // Initialise the height coordinates or altitude location based on the engineering drawing 
                // We add the mesh thickness and subtract the difference in depth between b1 and b5 from the user since the dimensions ar given from the top of the mesh int he engineering drawing 
                List<double> railingCoordinates = modelParameters.RailingCoordinates;

                // Cabinet starting offset, half the profile dimension of the starting beam
                //double cabinetXOffset = (ModelParameters.BeamDimensions(modelParameters.C1Profile)[1]) / 2;
                double cabinetXOffset = 0;
                modelParameters.CabinetXOffset = cabinetXOffset;
                double cabinetZOffSet = 0;
                CreateCabinet(xCoordinates, zCoordinates, cabinetXOffset, cabinetZOffSet, true);

                List<double> xSubCoordinates = new List<double>();
                List<double> zSubCoordinates = new List<double>();
                List<double> walkwaySubList = new List<double>();

                double boxLength;
                double boxHeight;
                TSG.Point OriginOffset = new TSG.Point();

                List<Curve_Box> boxes = new List<Curve_Box>();
                boxHeight = modelParameters.ScreenHeight;

                boxLength = modelParameters.ScreenLength;
                boxes.Add(new Curve_Box(xCoordinates, boxHeight, new TSG.Point(0, 0, 0), modelParameters));

                // Weight
                double totalWeight = 0;
                double objectWeight = 0;
                // int objects = 0;
                Type[] types = { typeof(Part),
                    typeof(BoltGroup) };



                foreach (ModelObject obj in MyModel.GetModelObjectSelector().GetAllObjectsWithType(types))
                {
                    if (obj != null && obj.GetReportProperty("WEIGHT", ref objectWeight))
                    {
                        totalWeight += objectWeight;
                    }
                    else
                    {
                        Console.WriteLine("Error retrieving weight");
                    }
                }
                BillboardWeight.Text = String.Format("{0:0.###}", totalWeight);

                MyModel.CommitChanges();
            }
            this.button1.Click -= new System.EventHandler(this.BuildCurve_Button_Click);
        }

        /// <summary>
        /// Decide if the model is a normal BillBoard or a Curve BillBoard.
        /// </summary>
        private void BuildTypeSelection_Button_Click(object sender, EventArgs e)
        {
            if (Radius_Text.Enabled)
            {
                this.button1.Click += new System.EventHandler(this.BuildCurve_Button_Click);
            }
            else if (!Radius_Text.Enabled)
            {
                this.button1.Click += new System.EventHandler(this.BuildButton_Click);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="father"></param>
        /// <param name="operativeParts"></param>
        private void CutParts(Part father, List<Part> operativeParts)
        {
            foreach (Part cp in operativeParts)
            {
                cp.Class = BooleanPart.BooleanOperativeClassName;
                BooleanPart bp = new BooleanPart
                {
                    Father = father,
                    OperativePart = cp,
                    Type = BooleanPart.BooleanTypeEnum.BOOLEAN_CUT
                };
                bp.Insert();
            }
        }

        /// <summary>
        /// Method to create all LED cabinets on Tekla Structures.
        /// </summary>
        /// <param name="xCoordinates"> List of relative x coordinates to divide the cabinets vertically (mm) </param>
        /// <param name="zCoordinates"> List of relative z coordinates to divide the cabinets horizontally (mm) </param>
        /// <param name="cabinetXOffset"> Offset of cabinet's left edge (mm) </param>
        /// <param name="cabinetZOffset"> Offset of cabinet's bottom edge (mm) </param>
        /// /// <param name="Curve"> If the Led cabinets is for a curve bill board </param>
        public void CreateCabinet(List<double> xCoordinates, List<double> zCoordinates, double cabinetXOffset, double cabinetZOffset, bool Curve)
        {
            // x offset for the left edge
            double xOffsetPlateLeft = 0.0 + cabinetXOffset;
            // x offset for the right edge
            double xOffsetPlateRight = 0.0 + cabinetXOffset;
            // z offset for the lower edge
            double zOffsetPlateLower = 0 + cabinetZOffset;
            // z offset for the upper edge
            double zOffsetPlateUpper = 0 + cabinetZOffset;

            // Radius of the Front Circle 1
            double FrontCircle_1 = modelParameters.Radius;

            // Loop for each row
            for (int indexZ = 0; indexZ < zCoordinates.Count - 1; indexZ++)
            {
                // Lower and Upper edge offset
                zOffsetPlateLower += zCoordinates[indexZ];
                zOffsetPlateUpper += zCoordinates[indexZ + 1];

                // Loop for each column
                for (int indexX = 0; indexX < xCoordinates.Count - 1; indexX++)
                {
                    // Left and Right edge offset
                    xOffsetPlateLeft += xCoordinates[indexX];
                    xOffsetPlateRight += xCoordinates[indexX + 1];

                    // If a straight BillBoard LED Required
                    if (!Curve) {
                        // Define the four corners
                        // Important: Sequence matters! The points adds to be a path to enclose the box
                        TSG.Point point1p = new TSG.Point(xOffsetPlateLeft, 0, zOffsetPlateLower);
                        TSG.Point point2p = new TSG.Point(xOffsetPlateRight, 0, zOffsetPlateLower);
                        TSG.Point point3p = new TSG.Point(xOffsetPlateRight, 0, zOffsetPlateUpper);
                        TSG.Point point4p = new TSG.Point(xOffsetPlateLeft, 0, zOffsetPlateUpper);
                        //MessageBox.Show(point1p.ToString() + " " + point2p.ToString() + " "+point3p.ToString() + " "+ point4p.ToString() );
                        // Create a plate
                        Plate plate = new Plate(new List<TSG.Point> { point1p, point2p, point3p, point4p },
                            modelParameters.LEDProfile, modelParameters.LEDMaterial, depth: Position.DepthEnum.FRONT, plateClass: "0", "Screen", "", "X", "XX");

                        // Call the method CreateBoltHoles, to make bolt array on created plate
                        CreateBoltHoles(plate);
                    }
                    else
                    {
                        // Define the four corners
                        // Important: Sequence matters! The points adds to be a path to enclose the box
                        TSG.Point point1p = new TSG.Point(xOffsetPlateLeft, CurveSupport.Circle_Ycoord(xOffsetPlateLeft, FrontCircle_1, modelParameters), zOffsetPlateLower);
                        TSG.Point point2p = new TSG.Point(xOffsetPlateRight, CurveSupport.Circle_Ycoord(xOffsetPlateRight, FrontCircle_1, modelParameters), zOffsetPlateLower);
                        TSG.Point point3p = new TSG.Point(xOffsetPlateRight, CurveSupport.Circle_Ycoord(xOffsetPlateRight, FrontCircle_1, modelParameters), zOffsetPlateUpper);
                        TSG.Point point4p = new TSG.Point(xOffsetPlateLeft, CurveSupport.Circle_Ycoord(xOffsetPlateLeft, FrontCircle_1, modelParameters), zOffsetPlateUpper);
                        //MessageBox.Show(point1p.ToString() + " " + point2p.ToString() + " "+point3p.ToString() + " "+ point4p.ToString() );
                        // Create a plate
                        Plate plate = new Plate(new List<TSG.Point> { point1p, point2p, point3p, point4p },
                            modelParameters.LEDProfile, modelParameters.LEDMaterial, depth: Position.DepthEnum.FRONT, plateClass: "0", "Screen", "", "X", "XX");

                        // Call the method CreateBoltHoles, to make bolt array on created plate
                        CreateBoltHoles(plate);
                    }
                }

                // Reset starting x position
                xOffsetPlateLeft = 0.0 + cabinetXOffset;
                xOffsetPlateRight = 0.0 + cabinetXOffset;
            }
        }

        /// <summary>
        /// Method to create bolt holes on a plate
        /// </summary>
        /// <param name="plate"> Plate to insert bolt holes in </param>
        private void CreateBoltHoles(Plate plate)
        {
            plate.ContourPlate.Identifier = new Identifier(1);

            // Create a new bolt array
            BoltArray B = new BoltArray
            {
                // Define part (plate) for array
                PartToBeBolted = plate.ContourPlate,
                PartToBoltTo = plate.ContourPlate,
                // Set the midpoints 
                // Start from middle bottom to middle top
                // Right edge - half of the length (right edge - left edge)/2
                FirstPosition = plate.Points[1] - new TSG.Point((plate.Points[1].X - plate.Points[0].X) / 2, 0.0, 0.0),
                SecondPosition = plate.Points[2] - new TSG.Point((plate.Points[2].X - plate.Points[3].X) / 2, 0.0, 0.0),

                // Bolt properties
                BoltSize = modelParameters.BoltSize,
                Tolerance = 3.00,
                BoltStandard = "UNDEFINED_STUD",
                BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_WORKSHOP,
                CutLength = 105,
                Length = 120,
                ExtraLength = 15,
                ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_NO
            };

            // Bolt offsets
            B.Position.Depth = Position.DepthEnum.MIDDLE;
            B.Position.DepthOffset = 0;
            B.Position.Plane = Position.PlaneEnum.MIDDLE;
            B.Position.Rotation = Position.RotationEnum.BELOW;
            B.Position.RotationOffset = 0;

            // the following properties determine the shape of bolts
            // In this case, we set everything to false
            B.Bolt = true;
            B.Washer1 = false;
            B.Washer2 = false;
            B.Washer3 = false;
            B.Nut1 = false;
            B.Nut2 = false;

            B.Hole1 = false;
            B.Hole2 = false;
            B.Hole3 = false;
            B.Hole4 = false;
            B.Hole5 = false;

            // Add the distance between two holes on the same horizontal line
            // Length of plate is difference between two edge
            // Distance is length - 2 * hole distance from edge
            B.AddBoltDistY(plate.Points[1].X - plate.Points[0].X - (2 * modelParameters.BoltOffsetDz));

            // Add the distance between two holes on the same vertical line
            B.AddBoltDistX(plate.Points[3].Z - plate.Points[0].Z - (2 * modelParameters.BoltOffsetDx));

            // Bolt array x-y axis is in line with first -> second position
            B.StartPointOffset.Dx = modelParameters.BoltOffsetDx;



            



            // Insert bolts
            if (!B.Insert())
            {
                MessageBox.Show("Insertion of Bolt failed.");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="output"></param>
        /// <param name="lowerLimit"></param>
        /// <param name="upperLimit"></param>
        /// <returns></returns>
        public bool ValidateDouble(string text, ref double output, double lowerLimit = 0, double upperLimit = Double.MaxValue)
        {
            try
            {
                double result = Convert.ToDouble(text);
                output = result < lowerLimit || result > upperLimit ? ModelParameters.InvalidValue : result;
                return result >= lowerLimit && result <= upperLimit;
            }
            catch (Exception)
            {
                output = ModelParameters.InvalidValue;
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="output"></param>
        /// <param name="lowerLimit"></param>
        /// <param name="upperLimit"></param>
        /// <returns></returns>
        public bool ValidateInt32(string text, ref int output, int lowerLimit = 0, int upperLimit = Int32.MaxValue)
        {
            try
            {
                int result = Convert.ToInt32(text);
                output = result < lowerLimit || result > upperLimit ? (int)ModelParameters.InvalidValue : result;
                return !(result < lowerLimit || result > upperLimit);
            }
            catch (Exception)
            {
                output = (int)ModelParameters.InvalidValue;
                return false;
            }
        }

        private void CabinetValueAddButton_Click(object sender, EventArgs e)
        {
            // Disable build button
            button1.Enabled = false;
            double result = 0;

            if (ValidateDouble(cabinetAddValue.Text, ref result, Double.Epsilon))
            {
                // Check if it's adding row or column
                if (RowAddRadioButton.Checked)
                {
                    // Add value to UI list and variable
                    rowList.Items.Add(cabinetAddValue.Text);
                    //modelParameters.ZCoordinates.Add(addValue);

                    // Display count and sum
                    rowSumLabel.Text = rowList.Items.Count.ToString();
                    //modelParameters.BillboardHeight += addValue;
                    CabinetHeightSumLabel.Text = (Convert.ToDouble(CabinetHeightSumLabel.Text) + result).ToString(); //modelParameters.BillboardHeight.ToString();
                }
                else if (ColumnAddRadioButton.Checked)
                {
                    columnList.Items.Add(cabinetAddValue.Text);
                    //modelParameters.XCoordinates.Add(Value);
                    columnSumLabel.Text = columnList.Items.Count.ToString();
                    //modelParameters.BillboardLength += Value;
                    CabinetLengthSumLabel.Text = (Convert.ToDouble(CabinetLengthSumLabel.Text) + result).ToString(); //modelParameters.BillboardLength.ToString();
                }
            }
            else
            {
                MessageBox.Show("Invalid Input for LED screens");
            }
        }

        private void RowList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RowEditRadioButton.Checked && rowList.SelectedIndex != -1)
            {
                // Check if the selected item has an asterisk
                string row = ((string)rowList.SelectedItem).Replace("*", "");

                // if no selection, display nothing, otherwise display selected item
                CabinetEditValue.Text = rowList.SelectedIndex == -1 ? "" : row;
            }
        }

        private void ColumnList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ColumnEditRadioButton.Checked && columnList.SelectedIndex != -1)
            {
                // Check if the selected item has an asterisk
                string column = ((string)columnList.SelectedItem).Replace("*", "");
                CabinetEditValue.Text = columnList.SelectedIndex == -1 ? "" : column;
            }
        }

        private void EditRowRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rowList.SelectedIndex != -1)
            {
                string row = ((string)rowList.SelectedItem).Replace("*", "");
                CabinetEditValue.Text = rowList.SelectedIndex == -1 ? "" : row;
            }
        }

        private void EditColumnRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rowList.SelectedIndex != -1)
            {
                //string column = ((string)columnList.SelectedItem).Replace("*", "");
                //  CabinetEditValue.Text = columnList.SelectedIndex == -1 ? "" : column;
            }
        }

        private void CabinetEditButton_Click(object sender, EventArgs e)
        {
            double editValue = 0;
            if (ValidateDouble(CabinetEditValue.Text, ref editValue, Double.Epsilon))
            {
                if (RowEditRadioButton.Checked && rowList.SelectedIndex != -1)
                {
                    button1.Enabled = false;

                    // Get the index of selected item
                    int rowIndex = rowList.SelectedIndex;
                    string row = rowList.Items[rowIndex].ToString();

                    // Check if asterisk
                    if (row.EndsWith("*"))
                    {
                        row = row.Replace("*", "");
                        rowList.Items[rowIndex] = editValue + "*";
                    }
                    else
                    {
                        // Replace item at index with new value
                        rowList.Items[rowIndex] = editValue.ToString();
                    }

                    // Update the Cabinet Height on the UI
                    CabinetHeightSumLabel.Text = (Convert.ToDouble(CabinetHeightSumLabel.Text) + editValue - Convert.ToDouble(row)).ToString();
                }
                else if (ColumnEditRadioButton.Checked && columnList.SelectedIndex != -1)
                {
                    button1.Enabled = false;

                    // Get the index of selected item
                    int columnIndex = columnList.SelectedIndex;
                    string column = columnList.Items[columnIndex].ToString();

                    // Check if asterisk
                    if (column.EndsWith("*"))
                    {
                        column = column.Replace("*", "");
                        columnList.Items[columnIndex] = editValue + "*";
                    }
                    else
                    {
                        // Replace item at index with new value
                        columnList.Items[columnIndex] = editValue.ToString();
                    }

                    // Update the Cabinet Height on the UI
                    CabinetLengthSumLabel.Text = (Convert.ToDouble(CabinetLengthSumLabel.Text) + editValue - Convert.ToDouble(column)).ToString();
                }
            }
        }

        private void AddSplitButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (RowAddRadioButton.Checked && rowList.SelectedIndex != -1)
            {
                int rowIndex = rowList.SelectedIndex;
                string row = (string)rowList.Items[rowIndex];

                if (!row.EndsWith("*"))
                {
                    rowList.Items[rowIndex] += "*";
                }
                else
                {
                    MessageBox.Show("Split already in place");
                }
            }
            else if (ColumnAddRadioButton.Checked && columnList.SelectedIndex != -1)
            {
                int columnIndex = columnList.SelectedIndex;
                string column = (string)columnList.Items[columnIndex];

                if (!column.EndsWith("*"))
                {
                    columnList.Items[columnIndex] += "*";
                }
                else
                {
                    MessageBox.Show("Split already in place");
                }
            }
        }

        private void CabinetRemoveButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (RowEditRadioButton.Checked && rowList.SelectedIndex != -1)
            {
                int rowIndex = rowList.SelectedIndex;
                string row = ((string)rowList.Items[rowIndex]).Replace("*", "");

                // Remove value from variable list, +1 to shift index away from required 0 value in list
                double value = Convert.ToDouble(row);
                //modelParameters.ZCoordinates.RemoveAt(rowIndex + 1);

                //modelParameters.BillboardHeight -= val;
                CabinetHeightSumLabel.Text = (Convert.ToDouble(CabinetHeightSumLabel.Text) - value).ToString(); // modelParameters.BillboardHeight.ToString();

                // Remove item at index in UI
                rowList.Items.RemoveAt(rowIndex);

                // Display total, -1 to account for required value already counted
                rowSumLabel.Text = rowList.Items.Count.ToString();

            }
            else if (ColumnEditRadioButton.Checked && columnList.SelectedIndex != -1)
            {

                int columnIndex = columnList.SelectedIndex;
                string column = ((string)columnList.Items[columnIndex]).Replace("*", "");

                // Remove value from variable list, +1 to shift index away from required 0 value in list
                double value = Convert.ToDouble(column);
                //modelParameters.ZCoordinates.RemoveAt(rowIndex + 1);

                //modelParameters.BillboardLength -= val;
                CabinetLengthSumLabel.Text = (Convert.ToDouble(CabinetLengthSumLabel.Text) - value).ToString(); //modelParameters.BillboardLength.ToString();

                // Remove item at index in UI
                columnList.Items.RemoveAt(columnIndex);

                // Display total, -1 to account for required value already counted
                columnSumLabel.Text = columnList.Items.Count.ToString();
            }

            button1.Enabled = false;
        }
        private void EditRemoveSplit_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            // Are we in rows or columns and have they selected something from the list
            if (RowEditRadioButton.Checked && rowList.SelectedIndex != -1)
            {
                int rowIndex = rowList.SelectedIndex;
                rowList.Items[rowIndex] = ((string)rowList.Items[rowIndex]).Replace("*", "");
            }
            else if (ColumnEditRadioButton.Checked && columnList.SelectedIndex != -1)
            {
                int columnIndex = columnList.SelectedIndex;
                columnList.Items[columnIndex] = ((string)columnList.Items[columnIndex]).Replace("*", "");
            }
        }

        private void CabinetResetButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            // Clear UI list
            rowList.Items.Clear();
            columnList.Items.Clear();

            // Reset label
            rowSumLabel.Text = "0";
            columnSumLabel.Text = "0";
            CabinetEditValue.Text = "";
            CabinetLengthSumLabel.Text = "0";
            CabinetHeightSumLabel.Text = "0";
        }

        private void ValidateButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            //Read prefix from text box and save to class to be read later
            Prefix.part = partPrefix.Text;
            Prefix.assembly = assemblyPrefix.Text;
            
            // Make sure the Lists are clear
            modelParameters.XCoordinates = new List<double> { 0 };
            modelParameters.ZCoordinates = new List<double> { 0 };
            modelParameters.XSplits.Clear();
            modelParameters.ZSplits.Clear();
            modelParameters.WalersCoordinates.Clear();
            modelParameters.WalkwayList.Clear();
            modelParameters.BillboardHeight = 0;
            modelParameters.BillboardLength = 0;
            modelParameters.LiftPointsTopX.Clear();
            modelParameters.LiftPointsBottomX.Clear();


            //Moved all dimension due to error where as it was not adjusting depth to suit the B1 until after a first build.  had to run then delete sign and run again to get working.  This fixed it  was only issue with B1 but i moved them all over as its just getting saved into the ModelParameters anyway. DP

        
            // B3 Dimensions
            double[] B3Dimensions = ModelParameters.BeamDimensions(modelParameters.B3Profile);
            modelParameters.B3BeamWidth = B3Dimensions[1];
            
            // Dimensions for B1 
            double[] B1Dimensions = ModelParameters.BeamDimensions(modelParameters.B1Profile);
            modelParameters.B1BeamDepth = B1Dimensions[0];
            modelParameters.B1BeamWidth = B1Dimensions[1];
            modelParameters.B1BeamThickness = B1Dimensions[2];

            // Dimensions for B2 
            double[] B2Dimensions = ModelParameters.BeamDimensions(modelParameters.B2Profile);
            modelParameters.B2BeamDepth = B2Dimensions[0];
            modelParameters.B2BeamWidth = B2Dimensions[1];

            // Dimensions for BR1 
            double[] BR1Dimensions = ModelParameters.BeamDimensions(modelParameters.BR1Profile);
            modelParameters.BR1BeamDepth = BR1Dimensions[0];
            modelParameters.BR1BeamWidth = BR1Dimensions[1];

            // B5 Dimensions
            double[] B5Dimensions = ModelParameters.BeamDimensions(modelParameters.B5Profile);
            modelParameters.B5BeamDepth = B5Dimensions[0];
            modelParameters.B5BeamWidth = B5Dimensions[1];

            // Dimensions for C1
            double[] C1Dimensions = ModelParameters.BeamDimensions(modelParameters.C1Profile);
            modelParameters.C1BeamDepth = C1Dimensions[0];
            modelParameters.C1BeamWidth = C1Dimensions[1];

            // Dimensions for EA
            double[] EADimensions = ModelParameters.BeamDimensions(modelParameters.EAProfile);
            modelParameters.EABeamDepth = EADimensions[0];
            modelParameters.EABeamWidth = EADimensions[1];

            // Dimensions for waler
            double[] WalerDimensions = ModelParameters.BeamDimensions(modelParameters.WalerProfile);
            modelParameters.WalerBeamDepth = WalerDimensions[0];
            modelParameters.WalerBeamWidth = WalerDimensions[1];

            // Dimensions for z-bracket
            double[] zBracketDimensions = ModelParameters.BeamDimensions(modelParameters.ZBracketProfile);
            modelParameters.ZBracketThickness = zBracketDimensions[0];
            modelParameters.ZBracketWidth = zBracketDimensions[1];

            // Dimensions for Splits
            double[] C1SplitDimensions = ModelParameters.BeamDimensions(modelParameters.C1SplitProfile);
            modelParameters.C1SplitBeamDepth = C1SplitDimensions[0];
            modelParameters.C1SplitBeamWidth = C1SplitDimensions[1];

            double[] B2SplitDimensions = ModelParameters.BeamDimensions(modelParameters.B2SplitProfile);
            modelParameters.B2SplitBeamDepth = B2SplitDimensions[0];
            modelParameters.B2SplitBeamWidth = B2SplitDimensions[1];

            double[] B5SplitDimensions = ModelParameters.BeamDimensions(modelParameters.B5SplitProfile);
            modelParameters.B5SplitBeamDepth = B5SplitDimensions[0];
            modelParameters.B5SplitBeamWidth = B5SplitDimensions[1];

            double[] B1SplitDimensions = ModelParameters.BeamDimensions(modelParameters.B1SplitProfile);
            modelParameters.B1SplitBeamDepth = B1SplitDimensions[0];
            modelParameters.B1SplitBeamWidth = B1SplitDimensions[1];
            modelParameters.B1SplitBeamThickness = B1SplitDimensions[2];

            //Dimesnsion for ladder
            //modelParameters.LadderOffsetBack = Convert.ToDouble(LadderOffsetBackText.Text);
            //modelParameters.LadderOffsetSide = Convert.ToDouble(LadderOffsetSideText.Text);
            //modelParameters.LadderRungDiameter = Convert.ToDouble(LadderRungDiameterText.Text);

            try // Check for string or empty value.
            {
                modelParameters.LadderOffsetBack = Convert.ToDouble(LadderOffsetBackText.Text);
            }
            catch (Exception)
            {
                modelParameters.LadderOffsetBack = -1; // -1 to indicate that the vlaue is invalid.
            }

            try // Check for string or empty value.
            {
                modelParameters.LadderOffsetSide = Convert.ToDouble(LadderOffsetSideText.Text);
            }
            catch (Exception)
            {
                modelParameters.LadderOffsetSide = -1; // -1 to indicate that the vlaue is invalid.
            }


            // Deminesions for hatch beam
            double[] HatchBeamDimensions = ModelParameters.BeamDimensions(modelParameters.HatchBeamProfile);
            modelParameters.HatchBeamDepth = HatchBeamDimensions[0];
            modelParameters.HatchBeamWidth = HatchBeamDimensions[1];

            try // Check for string or empty value.
            {
                modelParameters.HatchWidth = Convert.ToDouble(HatchWidthValue.Text);
            } catch (Exception)
            {
                modelParameters.HatchWidth = -1; // -1 to indicate that the vlaue is invalid.
            }
            //Dimesnsions for ladder
            if (modelParameters.LadderMode != 2)
            {
                try
                {
                    modelParameters.LadderOffsetBack = Convert.ToDouble(LadderOffsetBackText.Text);
                    modelParameters.LadderOffsetSide = Convert.ToDouble(LadderOffsetSideText.Text);
                    modelParameters.LadderRungSpacing = Convert.ToDouble(LadderRungSpacingText.Text);
                    modelParameters.LadderRungMaterial = LadderRungMaterialText.Text;
                    modelParameters.LadderPlateHeight = Convert.ToDouble(LadderPlateHeightText.Text);
                    modelParameters.LadderPlateMaterial = LadderPlateMaterialText.Text;
                    modelParameters.LadderRailMaterial = LadderSideRailMaterialText.Text;
                    modelParameters.LadderWidth = Convert.ToDouble(LadderWidthText.Text);
                    modelParameters.LadderRailProfile = LadderRailProfileText.Text;
                    modelParameters.LadderRungProfile = LadderRungProfileText.Text;
                    modelParameters.LadderPlateProfile = LadderPlateProfileText.Text;

                    double[] LadderRungDimensions = ModelParameters.BeamDimensions(LadderRungProfileText.Text);
                    modelParameters.LadderRungDiameter = LadderRungDimensions[0];

                    double[] LadderRailDimensions = ModelParameters.BeamDimensions(LadderRailProfileText.Text);
                    modelParameters.LadderRailLength = LadderRailDimensions[0];
                    modelParameters.LadderRailWidth = LadderRailDimensions[1];

                    double[] LadderPlateDimensions = ModelParameters.BeamDimensions(LadderPlateProfileText.Text);
                    modelParameters.LadderPlateThickness = LadderPlateDimensions[0];


                }
                catch (Exception)
                {

                    modelParameters.LadderMode = 2;
                    MessageBox.Show("Invalid Input for Ladder. Ladder would not generate.");
                }
            }
            

            //Dimensions for Rear Door
            if(RearDoorEnable.Checked == true) { modelParameters.DoorON = true; }
            if (RearDoorEnable.Checked == false) { modelParameters.DoorON = false; }
            if (modelParameters.DoorON)
            {
                try
                {
                    modelParameters.DoorOffsetLeft = Convert.ToDouble(DoorOffsetText.Text);
                    modelParameters.DoorWidth = Convert.ToDouble(DoorWidthText.Text);
                    modelParameters.DoorHeight = Convert.ToDouble(DoorMinHeightText.Text);
                    modelParameters.DoorPanelFrameSpacing = Convert.ToDouble(DoorPanelFrameDistanceText.Text);
                    modelParameters.DoorFrameMaterial = DoorFrameMaterialText.Text;
                    modelParameters.DoorPanelMaterial = DoorPanelMaterialText.Text;
                    modelParameters.DoorFrameProfile = DoorFrameProfileText.Text;
                    modelParameters.DoorPanelProfile = DoorPanelProfileText.Text;

                    double[] DoorFrameBeamDimensions = ModelParameters.BeamDimensions(DoorFrameProfileText.Text);
                    modelParameters.DoorFrameHeight = DoorFrameBeamDimensions[0];
                    modelParameters.DoorFrameWidth = DoorFrameBeamDimensions[1];
                    

                    double[] DoorPanelBeamDimesnions = ModelParameters.BeamDimensions(DoorPanelProfileText.Text);
                    modelParameters.DoorPanelHeight = DoorPanelBeamDimesnions[0];
                    modelParameters.DoorPanelWidth = DoorPanelBeamDimesnions[1];
                }
                catch (Exception)
                {

                    modelParameters.DoorON = false;
                    MessageBox.Show("Invalid Input for Rear Door. Rear Door would not generate.");
                }
            }

            // Working variables to calculate dimensions of largest box
            double cX = 0, cZ = 0, mX = 0, mZ = 0;
            bool s = false;

            // Add to the lists
            for (int i = 0; i < rowList.Items.Count; i++)
            {
                string row = rowList.Items[i].ToString();
                if (row.EndsWith("*"))  // Split after this row
                {
                    modelParameters.ZSplits.Add(i + 1);
                    row = row.Replace("*", "");
                    s = true;
                }

                modelParameters.ZCoordinates.Add(Convert.ToDouble(row));

                // Add to billboardHeight
                modelParameters.BillboardHeight += Convert.ToDouble(row);

                // Track current and maximum box heights
                cZ += Convert.ToDouble(row);
                mZ = Math.Max(cZ, mZ);
                if (s) { cZ = 0; s = false; }
            }

            for (int j = 0; j < columnList.Items.Count; j++)
            {
                string column = columnList.Items[j].ToString();
                if (column.EndsWith("*"))
                {
                    modelParameters.XSplits.Add(j + 1);
                    column = column.Replace("*", "");
                    s = true;
                }

                modelParameters.XCoordinates.Add(Convert.ToDouble(column));

                // Add to billboardLength
                modelParameters.BillboardLength += Convert.ToDouble(column);

                // Track current and maximum box lengths
                cX += Convert.ToDouble(column);
                mX = Math.Max(cX, mX);
                if (s) { cX = 0; s = false; }
            }


            // Update materials and profiles
            modelParameters.B3Material = B3Material.Text;
            modelParameters.B3Profile = B3Profile.Text;
            modelParameters.BR1Material = BR1Material.Text;
            modelParameters.BR1Profile = BR1Profile.Text;
            modelParameters.LEDMaterial = LEDMaterial.Text;
            modelParameters.LEDProfile = LEDProfile.Text;
            modelParameters.C1Material = C1Material.Text;
            modelParameters.C1Profile = C1Profile.Text;
            modelParameters.B1Material = B1Material.Text;
            modelParameters.B1Profile = B1Profile.Text;
            modelParameters.B2Material = B2Material.Text;
            modelParameters.B2Profile = B2Profile.Text;
            modelParameters.B5Material = B5Material.Text;
            modelParameters.B5Profile = B5Profile.Text;
            modelParameters.EAMaterial = EAMaterial.Text;
            modelParameters.EAProfile = EAProfile.Text;
            modelParameters.BracketMaterial = ZBracketMaterial.Text;
            modelParameters.ZBracketProfile = ZBracketProfile.Text;
            modelParameters.HatchBeamProfile = HatchBeamProfile.Text;
            modelParameters.HatchBeamMaterial = HatchBeamMaterial.Text;

            // Update split materials and profiles
            modelParameters.C1SplitProfile = C1SplitBeamProfile.Text;
            modelParameters.C1SplitMaterial = C1SplitBeamMaterial.Text;
            modelParameters.B1SplitProfile = B1SplitBeamProfile.Text;
            modelParameters.B1SplitMaterial = B1SplitBeamMaterial.Text;
            modelParameters.B2SplitProfile = B2SplitBeamProfile.Text;
            modelParameters.B2SplitMaterial = B2SplitBeamMaterial.Text;
            modelParameters.B5SplitProfile = B5SplitBeamProfile.Text;
            modelParameters.B5SplitMaterial = B5SplitBeamMaterial.Text;

            // Update the offset of bolts connecting the EA beams at horizontal splits
            double result = 0;
            ValidateDouble(EASplitBoltOffset.Text, ref result);
            modelParameters.EASplitBoltOffset = result;
            ValidateDouble(EACabinetBoltHoleSize.Text, ref result);
            modelParameters.EASplitCabinetBoltHoleSize = result;

            // Update offsets
            ValidateDouble(HeightOffsetTop.Text, ref result);
            modelParameters.HeightOffsetTop = result;
            ValidateDouble(HeightOffsetBottom.Text, ref result);
            modelParameters.HeightOffsetBottom = result;
            ValidateDouble(CornerOffset.Text, ref result);
            modelParameters.CornerOffset = result;
            ValidateDouble(DiagonalTopOffset.Text, ref result);
            modelParameters.DiagonalTopOffset = result;
            ValidateDouble(DiagonalBottomOffset.Text, ref result);
            modelParameters.DiagonalBottomOffset = result;

            // Bolts
            ValidateDouble(HoleHorizontalOffset.Text, ref result);
            modelParameters.BoltOffsetDz = result;
            ValidateDouble(HoleVerticalOffset.Text, ref result);
            modelParameters.BoltOffsetDx = result;
            ValidateDouble(BoltDiameter.Text, ref result, Double.Epsilon);
            modelParameters.BoltSize = result;

            // Update rail spacings
            modelParameters.AutoSpacing = !StructureManualRadio.Checked;
            ValidateDouble(RailingSpace1.Text, ref result, Double.Epsilon);
            modelParameters.RailingSpace1 = result;
            ValidateDouble(RailingSpace2.Text, ref result, Double.Epsilon);
            modelParameters.RailingSpace2 = result;
            modelParameters.RailingCoordinates = new List<double>() { modelParameters.RailingSpace1, modelParameters.RailingSpace2 };
            foreach (double x in HorizontalBeamsList.Items) { modelParameters.RailingCoordinates.Add(x); }

            // Walkways
            modelParameters.MeshMaterial = WalkwayMaterial.Text;
            ValidateDouble(MeshThickness.Text, ref result, Double.Epsilon);
            modelParameters.MeshThickness = result;
            ValidateDouble(EAClearance.Text, ref result, Double.Epsilon);
            modelParameters.EASupportClearance = result;
            ValidateDouble(WalkwayClearance.Text, ref result, Double.Epsilon);
            modelParameters.WalkwayClearance = result;
            ValidateDouble(WalkwayWidth.Text, ref result, Double.Epsilon);
            modelParameters.WalkwayWidth = Convert.ToDouble(WalkwayWidth.Text);
            modelParameters.EndBracketSpacing = result;

            // Welding
            ValidateDouble(Welding.Text, ref result);
            modelParameters.WeldOffset = result;

            // Walers
            int result2 = 0;
            modelParameters.WalerMaterial = WalerMaterial.Text;
            modelParameters.WalerProfile = WalerProfile.Text;
            modelParameters.WalerAuto = WalerAutoRadio.Checked;

            if (WalerAutoRadio.Checked)
            {
                ValidateInt32(WalerAddValue.Text, ref result2);
                modelParameters.WalersNumber = result2;
            }
            else
            {
                foreach (double x in WalersList.Items) { modelParameters.WalersCoordinates.Add(x); }
            }

            ValidateDouble(UpperWalerSpacing.Text, ref result, Double.Epsilon);
            modelParameters.UpperWalerSpacing = result;
            ValidateDouble(LowerWalerSpacing.Text, ref result, Double.Epsilon);
            modelParameters.LowerWalerSpacing = result;

            // Gal holes
            modelParameters.NoGalHole = NoGalHole.Checked;
            ValidateDouble(GH_holeSize.Text, ref result, Double.Epsilon);
            modelParameters.GalHoleSize = result;
            ValidateDouble(GH_offset1.Text, ref result, Double.Epsilon);
            modelParameters.GalHoleOffset1 = result;
            ValidateDouble(GH_offset2.Text, ref result, Double.Epsilon);
            modelParameters.GalHoleOffset2 = result;


            // Seating Plate
            modelParameters.SeatingPlateMaterial = SeatingPlateMaterial.Text;
            modelParameters.SeatingPlateProfile = SeatingPlateProfile.Text;
            modelParameters.BuildSeatingPlate = SeatingPlateOnButton.Checked;
            ValidateDouble(SeatingPlateOffset.Text, ref result, Double.Epsilon);
            modelParameters.SeatingPlateOffset = result;
            ValidateDouble(ExtrusionLength.Text, ref result, Double.Epsilon);
            modelParameters.SeatingPlateExtrusionLength = result;

            // Walkway Railings
            ValidateDouble(TrimmerBox.Text, ref result, Double.Epsilon);
            modelParameters.TrimmerDistance = result;

            ValidateDouble(HandRailingBox.Text, ref result, Double.Epsilon);
            modelParameters.RailingSpace2 = result;

            ValidateDouble(KneeRailingBox.Text, ref result, Double.Epsilon);
            modelParameters.RailingSpace1 = result;

            // Radius
            ValidateDouble(Radius_Text.Text, ref result, Double.Epsilon);
            modelParameters.Radius = result;
            try
            {
                if (Radius_Text.Enabled && modelParameters.Radius <= (modelParameters.ScreenLength / 2))
                {
                    MessageBox.Show("Radius should be a greater than Half of the Screen Length");
                    return;
                }
                else if (Radius_Text.Enabled && modelParameters.Radius >= (modelParameters.ScreenLength / 2))
                {
                    modelParameters.IsCircularBill = true;
                }
                else if (!Radius_Text.Enabled) 
                {
                    modelParameters.IsCircularBill = false;
                }
            } catch (Exception)
            {
                modelParameters.IsCircularBill = false;
                modelParameters.Radius = -1; // Set to -1 so that ModelParameters raises it as error.
            }

    // Z Brackets
    ValidateDouble(ZbracketSpacingA.Text, ref result, Double.Epsilon);
            modelParameters.BracketASpacing = result;
            ValidateDouble(ZbracketSpacingB.Text, ref result, Double.Epsilon);
            modelParameters.BracketBSpacing = result;
            ValidateDouble(ZbracketEndSpacing.Text, ref result, Double.Epsilon);
            modelParameters.EndBracketSpacing = result;
            modelParameters.BracketBoltStandard = BracketBoltStandard.Text;
            ValidateDouble(BracketBoltDiameter.Text, ref result, Double.Epsilon);
            modelParameters.BracketBoltDiameter = result;
            ValidateDouble(BracketHoleDiameter.Text, ref result, Double.Epsilon);
            modelParameters.BracketHoleDiameter = result;

            // Check for string input and also enables spacer plate if the switch is checked.
            try
            {
                if (SpacerPlateSwitch.Checked && BracketSpacerThickness.Text != null)
                {
                    modelParameters.ZBracketSpacer = true;
                    ValidateDouble(BracketSpacerThickness.Text, ref result);
                    modelParameters.ZBracketSpacerThickness = result;
                }
                else
                {
                    modelParameters.ZBracketSpacer = false;
                }
            } catch (Exception)
            {
                modelParameters.ZBracketSpacer = true;
                modelParameters.ZBracketSpacerThickness = -1; // Set to -1 so that ModelParameters raises it as error.
            }
            

            // Mid Walkways
            foreach (double x in WW_list.Items) { modelParameters.WalkwayList.Add(x); }

            // Lift points
            foreach (double x in topList.Items) { modelParameters.LiftPointsTopX.Add(x); }
            foreach (double x in bottomList.Items) { modelParameters.LiftPointsBottomX.Add(x); }

            // Camera arm
            double a = 0, b = 0, c = 0, d = 0;
            ValidateDouble(ArmLeftOffset.Text, ref a, upperLimit: Convert.ToDouble(CabinetLengthSumLabel.Text));
            ValidateDouble(ArmLengthBox.Text, ref b, lowerLimit: 100);
            ValidateDouble(VertArmLength.Text, ref c, lowerLimit: 100);
            ValidateDouble(ArmAngle.Text, ref d, upperLimit: 30);

            modelParameters.ArmOffset = a;
            modelParameters.SetArmLength = b;
            modelParameters.VertArmLength = c;
            modelParameters.ArmAngle = ModelParameters.IsValid(d) ? d * Math.PI / 180 : d;

            if (BotArm.Checked)
            {
                modelParameters.ArmAtTop = false;
                modelParameters.NoArm = false;
            }
            else if (TopArm.Checked)
            {
                modelParameters.ArmAtTop = true;
                modelParameters.NoArm = false;
            }
            else
            {
                modelParameters.NoArm = true;
            }

            // Cladding 
            // save current selection
            if (modelParameters.CladIndex == 0)
            {
                for (int i = 0; i < modelParameters.CladdingTypes.Count; ++i)
                {
                    SaveCladding(i);
                }
            }
            else
            {
                SaveCladding(modelParameters.CladIndex - 1);
            }

            // Flashings
            modelParameters.FlashingEnabled = FlashingsEnabled.Checked;
            ValidateDouble(FlashingDimA.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[0] = result;
            ValidateDouble(FlashingDimB.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[1] = result;
            ValidateDouble(FlashingDimC.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[2] = result;
            ValidateDouble(FlashingDimD.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[3] = result;
            ValidateDouble(FlashingDimE.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[4] = result;
            ValidateDouble(FlashingDimF.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[5] = result;
            ValidateDouble(FlashingDimG.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[6] = result;
            ValidateDouble(FlashingDimH.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[7] = result;
            ValidateDouble(FlashingDimI.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[8] = result;
            ValidateDouble(FlashingDimJ.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[9] = result;
            ValidateDouble(FlashingDimK.Text, ref result, upperLimit: 90);
            modelParameters.FlashingDimensions[10] = ModelParameters.IsValid(result) ? result * Math.PI / 180 : result;
            ValidateDouble(FlashingDimL.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[11] = result;
            ValidateDouble(FlashingDimM.Text, ref result, upperLimit: 90);
            modelParameters.FlashingDimensions[12] = ModelParameters.IsValid(result) ? result * Math.PI / 180 : result;
            ValidateDouble(FlashingDimN.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[13] = result;
            ValidateDouble(FlashingDimO.Text, ref result, upperLimit: 90);
            modelParameters.FlashingDimensions[14] = ModelParameters.IsValid(result) ? result * Math.PI / 180 : result;
            ValidateDouble(FlashingDimP.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[15] = result;
            ValidateDouble(FlashingDimQ.Text, ref result, upperLimit: 90);
            modelParameters.FlashingDimensions[16] = ModelParameters.IsValid(result) ? result * Math.PI / 180 : result;
            ValidateDouble(FlashingDimR.Text, ref result, Double.Epsilon);
            modelParameters.FlashingDimensions[17] = result;
            ValidateDouble(FlashingDimS.Text, ref result, upperLimit: 90);
            modelParameters.FlashingDimensions[18] = ModelParameters.IsValid(result) ? result * Math.PI / 180 : result;
            ValidateDouble(FlashingThickness.Text, ref result, Double.Epsilon);
            modelParameters.FlashingThickness = result;

            switch (FlashingColour.SelectedIndex)
            {
                case 0:
                    modelParameters.FlashingColour = Colour.Basalt;
                    break;
                case 1:
                    modelParameters.FlashingColour = Colour.Cove;
                    break;
                case 2:
                    modelParameters.FlashingColour = Colour.Dune;
                    break;
                case 3:
                    modelParameters.FlashingColour = Colour.EveningHaze;
                    break;
                case 4:
                    modelParameters.FlashingColour = Colour.Gully;
                    break;
                case 5:
                    modelParameters.FlashingColour = Colour.Ironstone;
                    break;
                case 6:
                    modelParameters.FlashingColour = Colour.Jasper;
                    break;
                case 8:
                    modelParameters.FlashingColour = Colour.Monument;
                    break;
                case 9:
                    modelParameters.FlashingColour = Colour.ShaleGrey;
                    break;
                case 10:
                    modelParameters.FlashingColour = Colour.Surfmist;
                    break;
                case 11:
                    modelParameters.FlashingColour = Colour.Terrain;
                    break;
                case 12:
                    modelParameters.FlashingColour = Colour.Wallaby;
                    break;
                case 13:
                    modelParameters.FlashingColour = Colour.Windspray;
                    break;
                default:
                    modelParameters.FlashingColour = Colour.Mangrove;
                    break;
            }

            // Gal bath location
            modelParameters.GalBathLength = Convert.ToDouble(galLength.Text);
            modelParameters.GalBathWidth = Convert.ToDouble(galWidth.Text);
            modelParameters.GalBathHeight = Convert.ToDouble(galDepth.Text);

            // Check whether boxes fit in specified gal bath
            // ASSUMING BILLBOARD DEPTH IS ALWAYS THE SHORTEST DIMENSION
            double boxDim1 = Math.Max(mX, mZ);
            double boxDim2 = Math.Min(mX, mZ);
            double bathDim1, bathDim2;

            if (modelParameters.GalBathLength >= modelParameters.GalBathWidth && modelParameters.GalBathLength >= modelParameters.GalBathHeight)
            {
                bathDim1 = modelParameters.GalBathLength;
                bathDim2 = Math.Max(modelParameters.GalBathWidth, modelParameters.GalBathHeight);
            }
            else if (modelParameters.GalBathWidth >= modelParameters.GalBathLength && modelParameters.GalBathWidth >= modelParameters.GalBathHeight)
            {
                bathDim1 = modelParameters.GalBathWidth;
                bathDim2 = Math.Max(modelParameters.GalBathLength, modelParameters.GalBathHeight);
            }
            else
            {
                bathDim1 = modelParameters.GalBathHeight;
                bathDim2 = Math.Max(modelParameters.GalBathLength, modelParameters.GalBathWidth);
            }

            if (boxDim1 > bathDim1 || boxDim2 > bathDim2)
                MessageBox.Show("Warning: Boxes may not fit in the specified gal bath");

            // Fascia box
            modelParameters.FasciaEnabled = enableFascia.Checked;
            ValidateDouble(fasciaHeight.Text, ref result, 400);
            modelParameters.FasciaBoxHeight = result;
            modelParameters.isTwoD = TwoDButton.Checked;

            // Check if all inputs are valid, enable build and save button if it is
            button1.Enabled = modelParameters.ValidateInputs();
            SaveButton.Enabled = button1.Enabled;

            // Get global screen Length
            double screenLength = 0;
            foreach (double x in modelParameters.XCoordinates)
            {
                screenLength += x;
            }
            modelParameters.ScreenLength = screenLength;

            // Get global screen Height
            double screenHeight = 0;
            foreach (double coordinate in modelParameters.ZCoordinates)
            {
                screenHeight += coordinate;
            }
            modelParameters.ScreenHeight = screenHeight;

            // Calculating Billboard Height from Screen Height
            double billboardHeight = screenHeight + modelParameters.HeightOffsetTop +
                                     modelParameters.HeightOffsetBottom + modelParameters.B1BeamDepth * 2;

            // Get Billboard Depth
            double billboardDepth = modelParameters.WalkwayWidth + (2 * modelParameters.WalkwayClearance) + (2 * modelParameters.B1BeamWidth); // TODO: Verify it's width

            BillBoardDepth.Text = billboardDepth.ToString();
            modelParameters.BillboardDepth = billboardDepth;

            // Store and Display information on GUI
            modelParameters.BillboardHeight = billboardHeight;
            modelParameters.BillboardLength = screenLength;
            BillBoardHeight.Text = modelParameters.BillboardHeight.ToString();
            BillBoardLength.Text = modelParameters.BillboardLength.ToString();

        }

        // Horizontal Railings
        private void StructureManualRadio_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;

            // Enable value editing if manual input
            if (StructureManualRadio.Checked)
            {
                HorizontalBeamsAddValue.Enabled = true;
                HorizontalBeamsAddButton.Enabled = true;
                HorizontalBeamsEditValue.Enabled = true;
                HorizontalBeamsEditButton.Enabled = true;
                HorizontalBeamsRemoveButton.Enabled = true;
                HorizontalBeamsResetButton.Enabled = true;
            }
            else
            {
                HorizontalBeamsAddValue.Enabled = false;
                HorizontalBeamsAddButton.Enabled = false;
                HorizontalBeamsEditValue.Enabled = false;
                HorizontalBeamsEditButton.Enabled = false;
                HorizontalBeamsRemoveButton.Enabled = false;
                HorizontalBeamsResetButton.Enabled = false;
            }
        }

        private void HorizontalBeamsAddButton_Click(object sender, EventArgs e)
        {
            double result = 0;
            if (ValidateDouble(HorizontalBeamsAddValue.Text, ref result, Double.Epsilon))
            {
                button1.Enabled = false;
                HorizontalBeamsList.Items.Add(result);
                BeamsSumLabel.Text = HorizontalBeamsList.Items.Count.ToString();
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void HorizontalBeamsEditButton_Click(object sender, EventArgs e)
        {
            double result = 0;
            if (ValidateDouble(HorizontalBeamsEditValue.Text, ref result, Double.Epsilon))
            {
                if (HorizontalBeamsList.SelectedIndex != -1)
                {
                    button1.Enabled = false;
                    int rowIndex = HorizontalBeamsList.SelectedIndex;
                    HorizontalBeamsList.Items[rowIndex] = result;
                }
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void HorizontalBeamsRemoveButton_Click(object sender, EventArgs e)
        {
            if (HorizontalBeamsList.SelectedIndex != -1)
            {
                button1.Enabled = false;
                int editIndex = HorizontalBeamsList.SelectedIndex;
                HorizontalBeamsList.Items.RemoveAt(editIndex);
                BeamsSumLabel.Text = HorizontalBeamsList.Items.Count.ToString();
                HorizontalBeamsEditValue.Text = "";
            }
        }

        private void HorizontalBeamsResetButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            HorizontalBeamsList.Items.Clear();
            BeamsSumLabel.Text = "0";
            HorizontalBeamsEditValue.Text = "";
        }

        private void HorizontalBeamsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HorizontalBeamsEditValue.Text = HorizontalBeamsList.SelectedIndex == -1 ? "" : HorizontalBeamsList.SelectedItem.ToString();
        }

        // Walers
        private void WalerAutoRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (WalerAutoRadio.Checked)
            {
                WalerNumberLabel.Visible = true;
                WalerAddButton.Enabled = false;
                WalerEditValue.Enabled = false;
                WalerEditButton.Enabled = false;
                WalerRemoveButton.Enabled = false;
                WalerResetButton.Enabled = false;
                WalersSumLabel.Text = "0";
                WalerAddValue.Text = "0";
            }
            else
            {
                WalerNumberLabel.Visible = false;
                WalerAddButton.Enabled = true;
                WalerEditValue.Enabled = true;
                WalerEditButton.Enabled = true;
                WalerRemoveButton.Enabled = true;
                WalerResetButton.Enabled = true;
                WalersSumLabel.Text = WalersList.Items.Count.ToString();
                WalerAddValue.Text = "";
            }
        }

        private void WalerAddButton_Click(object sender, EventArgs e)
        {
            double result = 0;

            if (ValidateDouble(WalerAddValue.Text, ref result, Double.Epsilon))
            {
                button1.Enabled = false;
                WalersList.Items.Add(result);
                WalersSumLabel.Text = modelParameters.WalersCoordinates.Count.ToString();
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void WalerEditButton_Click(object sender, EventArgs e)
        {
            double result = 0;

            if (ValidateDouble(WalerAddValue.Text, ref result, Double.Epsilon))
            {
                if (WalersList.SelectedIndex != -1)
                {
                    button1.Enabled = false;
                    int rowIndex = WalersList.SelectedIndex;
                    WalersList.Items[rowIndex] = result;
                }
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void WalerRemoveButton_Click(object sender, EventArgs e)
        {
            if (WalersList.SelectedIndex != -1)
            {
                button1.Enabled = false;
                int editIndex = WalersList.SelectedIndex;
                WalersList.Items.RemoveAt(editIndex);
                WalersSumLabel.Text = WalersList.Items.Count.ToString();
                WalerEditValue.Text = "";
            }
        }

        private void WalerResetButton_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            WalersList.Items.Clear();
            modelParameters.WalersCoordinates.Clear();
            WalersSumLabel.Text = "0";
            WalerEditValue.Text = "";
        }

        private void WalersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WalerEditValue.Text = WalersList.SelectedIndex == -1 ? "" : WalersList.SelectedItem.ToString();
        }

        private void WalerAddValue_TextChanged(object sender, EventArgs e)
        {
            if (WalerAutoRadio.Checked)
            {
                int result = 0;
                if (String.IsNullOrEmpty(WalerAddValue.Text) || ValidateInt32(WalerAddValue.Text, ref result))
                {
                    button1.Enabled = false;
                    WalersSumLabel.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Input");
                }
            }
        }

        // Seating Plate
        private void SeatingPlateOnButton_CheckedChanged(object sender, EventArgs e)
        {
            if (SeatingPlateOnButton.Checked)
            {
                SeatingPlateOffset.Enabled = true;
                ExtrusionLength.Enabled = true;
                ValidateDoubleWithWarning(SeatingPlateOffset);
                ValidateDoubleWithWarning(ExtrusionLength);
            }
            else
            {
                SeatingPlateOffset.Enabled = false;
                ExtrusionLength.Enabled = false;
                errorProvider.SetError(SeatingPlateOffset, null);
                errorProvider.SetError(ExtrusionLength, null);
            }
        }

        // Walkways
        private void WW_add_Click(object sender, EventArgs e)
        {
            double result = 0;
            if (ValidateDouble(WW_box.Text, ref result, upperLimit: Convert.ToDouble(CabinetHeightSumLabel.Text)))
            {
                button1.Enabled = false;
                WW_list.Items.Add(result);
                WW_count.Text = WW_list.Items.Count.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input.");
            }
        }

        private void WW_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if no selection, display nothing, otherwise display selected item
            WW_box.Text = WW_list.SelectedIndex == -1 ? "" : WW_list.SelectedItem.ToString();
        }

        private void WW_edit_Click(object sender, EventArgs e)
        {
            double result = 0;
            if (ValidateDouble(WW_box2.Text, ref result, upperLimit: Convert.ToDouble(CabinetHeightSumLabel.Text)))
            {
                button1.Enabled = false;
                WW_list.Items[WW_list.SelectedIndex] = result;
                WW_count.Text = WW_list.Items.Count.ToString();
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void WW_removeAll_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            // Clear UI list
            WW_list.Items.Clear();

            // Reset label
            WW_count.Text = "0";
            WW_box2.Text = "";
        }

        private void WW_remove_Click(object sender, EventArgs e)
        {
            if (WW_list.SelectedIndex != -1)
            {
                button1.Enabled = false;
                WW_list.Items.RemoveAt(WW_list.SelectedIndex);
            }

            // Reset label
            WW_count.Text = WW_list.Items.Count.ToString();
            WW_box2.Text = "";
        }

        // Lifting points
        private void AddLP_Click(object sender, EventArgs e)
        {
            double result = 0;
            if (ValidateDouble(AddLPTextBox.Text, ref result, upperLimit: Convert.ToDouble(CabinetLengthSumLabel.Text)) && ModelParameters.RegexValidateProfile(C1Profile.Text))
            {

                if ((AddLPBoth.Checked || AddLPTop.Checked) &&
                    LiftPoint.ValidateLiftPoint(result, ModelParameters.BeamDimensions(C1Profile.Text)[1], true, columnList.Items, topList.Items))
                {
                    button1.Enabled = false;
                    topList.Items.Add(result);
                }

                if ((AddLPBoth.Checked || AddLPBottom.Checked) &&
                    LiftPoint.ValidateLiftPoint(result, ModelParameters.BeamDimensions(C1Profile.Text)[1], false, columnList.Items, bottomList.Items))
                {
                    button1.Enabled = false;
                    bottomList.Items.Add(result);
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Lift point must lie within the billboard.");
            }

            TopLPCount.Text = topList.Items.Count.ToString(); //modelParameters.LiftPointsTopX.Count.ToString();
            BottomLPCount.Text = bottomList.Items.Count.ToString(); //modelParameters.LiftPointsBottomX.Count.ToString();
        }

        private void topList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EditLPTop.Checked)
            {
                // if no selection, display nothing, otherwise display selected item
                EditLPTextBox.Text = topList.SelectedIndex == -1 ? "" : topList.SelectedItem.ToString();
            }
        }

        private void bottomList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EditLPBottom.Checked)
            {
                // if no selection, display nothing, otherwise display selected item
                EditLPTextBox.Text = bottomList.SelectedIndex == -1 ? "" : bottomList.SelectedItem.ToString();
            }
        }

        private void EditLPTop_CheckedChanged(object sender, EventArgs e)
        {
            if (EditLPTop.Checked)
            {
                // if no selection, display nothing, otherwise display selected item
                EditLPTextBox.Text = topList.SelectedIndex == -1 ? "" : topList.SelectedItem.ToString();
            }
            else
            {
                // if no selection, display nothing, otherwise display selected item
                EditLPTextBox.Text = bottomList.SelectedIndex == -1 ? "" : bottomList.SelectedItem.ToString();
            }
        }

        private void EditLP_Click(object sender, EventArgs e)
        {
            double result = 0;
            if (ValidateDouble(EditLPTextBox.Text, ref result, upperLimit: Convert.ToDouble(CabinetLengthSumLabel.Text)) && ModelParameters.RegexValidateProfile(C1Profile.Text))
            {
                double old;
                if (EditLPTop.Checked && topList.SelectedIndex != -1)
                {
                    old = Convert.ToDouble(topList.SelectedItem);
                    if (LiftPoint.ValidateLiftPoint(result, ModelParameters.BeamDimensions(C1Profile.Text)[1], true,
                            columnList.Items, topList.Items, old))
                    {
                        button1.Enabled = false;
                        topList.Items[topList.SelectedIndex] = result;
                        //modelParameters.LiftPointsTopX[topList.SelectedIndex] = result;
                    }
                }

                else if (EditLPBottom.Checked && bottomList.SelectedIndex != -1)
                {
                    old = Convert.ToDouble(bottomList.SelectedItem);
                    if (LiftPoint.ValidateLiftPoint(result, ModelParameters.BeamDimensions(C1Profile.Text)[1], false,
                            columnList.Items, bottomList.Items, old))
                    {
                        //modelParameters.LiftPointsBottomX.Add(result);
                        button1.Enabled = false;
                        bottomList.Items.Add(result);
                    }
                }

                TopLPCount.Text = topList.Items.Count.ToString(); //modelParameters.LiftPointsTopX.Count.ToString();
                BottomLPCount.Text = bottomList.Items.Count.ToString(); //modelParameters.LiftPointsBottomX.Count.ToString();
            }
            else
            {
                MessageBox.Show("Invalid input. Lift point must lie within the billboard.");
            }
        }

        private void ClearLP_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            // Clear UI list
            topList.Items.Clear();
            bottomList.Items.Clear();

            // Reset label
            TopLPCount.Text = topList.Items.Count.ToString(); //modelParameters.LiftPointsTopX.Count.ToString();
            BottomLPCount.Text = bottomList.Items.Count.ToString(); //modelParameters.LiftPointsBottomX.Count.ToString();
            EditLPTextBox.Text = "";
        }

        private void RemoveLP_Click(object sender, EventArgs e)
        {

            if (EditLPTop.Checked && topList.SelectedIndex != -1)
            {
                button1.Enabled = false;
                topList.Items.RemoveAt(topList.SelectedIndex);
            }
            else if (EditLPBottom.Checked && bottomList.SelectedIndex != -1)
            {
                button1.Enabled = false;
                bottomList.Items.RemoveAt(bottomList.SelectedIndex);
            }

            // Reset label
            TopLPCount.Text = topList.Items.Count.ToString(); //modelParameters.LiftPointsTopX.Count.ToString();
            BottomLPCount.Text = bottomList.Items.Count.ToString(); //modelParameters.LiftPointsBottomX.Count.ToString();
            EditLPTextBox.Text = "";
        }

        // Camera arm
        private void noArm_CheckedChanged(object sender, EventArgs e)
        {
            ArmAngle.Enabled = !noArm.Checked;
            ArmAngle.Text = noArm.Checked ? "" : "10";
            ArmLeftOffset.Enabled = !noArm.Checked;
            ArmLeftOffset.Text = noArm.Checked ? "" : "0";
            ArmLengthBox.Enabled = !noArm.Checked;
            ArmLengthBox.Text = noArm.Checked ? "" : "1000";
            VertArmLength.Enabled = !noArm.Checked;
            VertArmLength.Text = noArm.Checked ? "" : "200";
        }

        // Cladding
        private void CladProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            SheetWidth.Enabled = true;
            CladdingColour.Enabled = true;

            int idx = Math.Max(0, theSide.SelectedIndex - 1);

            CladdingColour.Text = Cladding.ColourToFinish(modelParameters.CladdingColours[idx]);
            Thickness.Enabled = false;
            CladSize.Enabled = false;
            CladSize.Text = "";
            CladLength.Enabled = true;
            CladLength.Text = ModelParameters.DimToString(modelParameters.CladdingLengths[idx]);
            OpenArea.Enabled = false;
            OpenArea.Text = "";
            ManualOpenArea.Enabled = false;

            switch (CladProfile.SelectedIndex)
            {
                // Mini Orb
                case 0:
                case 1:
                    CladOffset.Enabled = theSide.SelectedIndex < (int)BillboardSide.Top;
                    SheetWidth.Text = "865";
                    EffectiveWidth.Text = "820";
                    Overlap.Text = "45";
                    Thickness.Text = "4.00";
                    break;

                // Panel Rib
                case 2:
                case 3:
                    CladOffset.Enabled = theSide.SelectedIndex < (int)BillboardSide.Top;
                    SheetWidth.Text = "920";
                    EffectiveWidth.Text = "850";
                    Overlap.Text = "70";
                    Thickness.Text = "6.00";
                    break;

                // Perforated sheets
                case 4:
                    CladOffset.Enabled = theSide.SelectedIndex < (int)BillboardSide.Top;
                    CladSize.Enabled = false;
                    CladLength.Enabled = false;
                    Thickness.Enabled = true;
                    CladLength.Text = "2400";
                    SheetWidth.Text = "1200";
                    EffectiveWidth.Text = "1170";
                    Overlap.Text = "30";
                    Thickness.Text = "";
                    OpenArea.Enabled = true;
                    OpenArea.Text = "10";
                    break;

                // ACM sheets
                case 5:
                    CladOffset.Enabled = theSide.SelectedIndex < (int)BillboardSide.Top;
                    CladSize.Enabled = false;
                    CladSize.Text = "";
                    CladLength.Enabled = false;
                    UpdateAcmUI();
                    break;

                // no cladding
                default:
                    CladLength.Enabled = false;
                    CladLength.Text = "";
                    CladdingColour.Enabled = false;
                    CladdingColour.Text = "";
                    SheetWidth.Text = "";
                    CladOffset.Enabled = false;
                    CladOffset.Text = "";
                    EffectiveWidth.Text = "";
                    Overlap.Text = "";
                    Thickness.Text = "";
                    break;
            }
        }

        private void UpdateAcmUI(int i = -1)
        {
            CladLength.Text = "";
            CladSize.Enabled = true;
            CladSize.Text = "";
            EffectiveWidth.Text = "";
            Overlap.Text = "0";
            Thickness.Text = "3.00";

            if (i == -1)
            {
                switch (CladSize.SelectedIndex)
                {
                    case 0:
                        SheetWidth.Text = "1220";
                        EffectiveWidth.Text = "1220";
                        CladLength.Text = "2440";
                        break;
                    case 1:
                        SheetWidth.Text = "1220";
                        EffectiveWidth.Text = "1220";
                        CladLength.Text = "3660";
                        break;
                    case 2:
                        SheetWidth.Text = "1500";
                        EffectiveWidth.Text = "1500";
                        CladLength.Text = "2440";
                        break;
                    case 3:
                        SheetWidth.Text = "1500";
                        EffectiveWidth.Text = "1500";
                        CladLength.Text = "3050";
                        break;
                    case 4:
                        SheetWidth.Text = "1500";
                        EffectiveWidth.Text = "1500";
                        CladLength.Text = "3660";
                        break;
                    case 5:
                        SheetWidth.Text = "1500";
                        EffectiveWidth.Text = "1500";
                        CladLength.Text = "4000";
                        break;
                    case 6:
                        SheetWidth.Text = "2000";
                        EffectiveWidth.Text = "2000";
                        CladLength.Text = "4000";
                        break;
                }
            }
            // show previous selection
            else
            {
                CladLength.Text = ModelParameters.DimToString(modelParameters.CladdingLengths[i]);
                SheetWidth.Text = ModelParameters.DimToString(modelParameters.CladdingWidths[i]);
                EffectiveWidth.Text = ModelParameters.DimToString(modelParameters.EffectiveCoverWidths[i]);
                CladSize.Text = $"{CladLength.Text} x {SheetWidth.Text}";
            }
        }

        private void CladSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            UpdateAcmUI();
        }

        // Changes client wants - Eetana
        private void theSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            // save existing selections
            if (modelParameters.CladIndex == 0)
            {
                for (int i = 0; i < modelParameters.CladdingTypes.Count; ++i)
                {
                    SaveCladding(i);
                }
            }
            else
            {
                SaveCladding(modelParameters.CladIndex - 1);
            }


            // show previous selections - do nothing if All is selected
            modelParameters.CladIndex = theSide.SelectedIndex;
            ShowCladding(theSide.SelectedIndex - 1);

        }

        private void ShowCladding(int i)
        {
            // All sides selected and profile other than 'No Cladding' selected
            if (i < 0)
            {
                if (CladProfile.Text != "No Cladding")
                {
                    CladOffset.Enabled = true;
                    CladOffset.Text = ModelParameters.DimToString(modelParameters.TopCladdingOffsets.Max(x => x));
                }

                return;
            }

            CladLength.Enabled = false;
            CladdingColour.Enabled = true;
            Thickness.Enabled = false;
            OpenArea.Enabled = false;
            ManualOpenArea.Enabled = false;
            CladSize.Enabled = false;
            CladOffset.Enabled = true;
            CladLength.Text = "";
            CladdingColour.Text = Cladding.ColourToFinish(modelParameters.CladdingColours[i]);
            CladSize.Text = "";
            CladOffset.Text = "";
            SheetWidth.Text = "";
            EffectiveWidth.Text = "";
            Overlap.Text = "";
            Thickness.Text = "";
            OpenArea.Text = "";
            ManualOpenArea.Text = "";

            switch (modelParameters.CladdingTypes[i])
            {
                // Mini Orb
                case CladdingType.MiniOrb42:
                case CladdingType.MiniOrb48:
                    CladLength.Enabled = true;
                    CladLength.Text = ModelParameters.DimToString(modelParameters.CladdingLengths[i]);
                    CladProfile.Text = modelParameters.CladdingTypes[i] == CladdingType.MiniOrb42
                        ? "Mini Orb 42"
                        : "Mini Orb 48";
                    SheetWidth.Text = "865";
                    EffectiveWidth.Text = "820";
                    Overlap.Text = "45";
                    Thickness.Text = "4.00";
                    CladOffset.Text = ModelParameters.DimToString(modelParameters.TopCladdingOffsets[i]);
                    break;

                // Panel Rib
                case CladdingType.PanelRib35:
                case CladdingType.PanelRib42:
                    CladLength.Enabled = true;
                    CladLength.Text = ModelParameters.DimToString(modelParameters.CladdingLengths[i]);
                    CladProfile.Text = modelParameters.CladdingTypes[i] == CladdingType.PanelRib35
                        ? "Panel Rib 0.48 (35)"
                        : "Panel Rib 0.48 (42)";
                    SheetWidth.Text = "920";
                    EffectiveWidth.Text = "850";
                    Overlap.Text = "70";
                    Thickness.Text = "6.00";
                    CladOffset.Text = ModelParameters.DimToString(modelParameters.TopCladdingOffsets[i]);
                    break;

                // Perforated sheets
                case CladdingType.PerfSheet:
                    Thickness.Enabled = true;
                    CladLength.Text = "2400";
                    SheetWidth.Text = "1200";
                    EffectiveWidth.Text = "1170";
                    Overlap.Text = "30";
                    Thickness.Text = "";
                    OpenArea.Enabled = true;
                    CladProfile.Text = "Perforated Sheet";
                    CladOffset.Text = ModelParameters.DimToString(modelParameters.TopCladdingOffsets[i]);

                    if (modelParameters.CladdingPercentsOpenArea[i] == 10)
                    {
                        OpenArea.Text = "10";
                    }
                    else if (modelParameters.CladdingPercentsOpenArea[i] == 30)
                    {
                        OpenArea.Text = "30";
                    }
                    else if (modelParameters.CladdingPercentsOpenArea[i] == 49)
                    {
                        OpenArea.Text = "49";
                    }
                    else
                    {
                        OpenArea.Text = "Custom";
                        ManualOpenArea.Enabled = true;
                        ManualOpenArea.Text = ModelParameters.DimToString(modelParameters.CladdingPercentsOpenArea[i]);
                    }
                    break;

                // ACM sheets
                case CladdingType.ACM:
                    CladSize.Enabled = true;
                    CladProfile.Text = "ACM";
                    CladOffset.Text = ModelParameters.DimToString(modelParameters.TopCladdingOffsets[i]);
                    UpdateAcmUI(i);
                    break;

                // no cladding
                default:
                    CladOffset.Enabled = false;
                    CladOffset.Text = "";
                    CladProfile.Text = "No Cladding";
                    CladdingColour.Enabled = false;
                    CladdingColour.Text = "";
                    break;
            }


            if (i >= (int)BillboardSide.Top)
            {
                CladOffset.Enabled = false;
                CladOffset.Text = "";
            }
        }

        private void SaveCladding(int i)
        {
            double length = 0, thickness = 0, openArea = 0, topOffset = 0, width = 0, overlap = 0, effectiveWidth = 0;
            ValidateDouble(CladLength.Text, ref length, Double.Epsilon);
            ValidateDouble(Thickness.Text, ref thickness, Double.Epsilon);
            if (!ValidateDouble(OpenArea.Text, ref openArea)) { ValidateDouble(ManualOpenArea.Text, ref openArea, upperLimit: 100); }

            ValidateDouble(CladOffset.Text, ref topOffset);
            ValidateDouble(SheetWidth.Text, ref width, Double.Epsilon);
            ValidateDouble(Overlap.Text, ref overlap);
            ValidateDouble(EffectiveWidth.Text, ref effectiveWidth, Double.Epsilon);

            switch (CladProfile.SelectedIndex)
            {
                // Mini Orb
                case 0:
                    modelParameters.CladdingTypes[i] = CladdingType.MiniOrb42;
                    break;

                case 1:
                    modelParameters.CladdingTypes[i] = CladdingType.MiniOrb48;
                    break;

                // Panel Rib
                case 2:
                    modelParameters.CladdingTypes[i] = CladdingType.PanelRib35;
                    break;

                case 3:
                    modelParameters.CladdingTypes[i] = CladdingType.PanelRib42;
                    break;

                // Perforated sheets
                case 4:
                    modelParameters.CladdingTypes[i] = CladdingType.PerfSheet;
                    break;

                // ACM sheets
                case 5:
                    modelParameters.CladdingTypes[i] = CladdingType.ACM;
                    break;

                // no cladding
                default:
                    modelParameters.CladdingTypes[i] = CladdingType.None;
                    break;
            }

            switch (CladdingColour.SelectedIndex)
            {
                case 0:
                    modelParameters.CladdingColours[i] = Colour.Basalt;
                    break;
                case 1:
                    modelParameters.CladdingColours[i] = Colour.Cove;
                    break;
                case 2:
                    modelParameters.CladdingColours[i] = Colour.Dune;
                    break;
                case 3:
                    modelParameters.CladdingColours[i] = Colour.EveningHaze;
                    break;
                case 4:
                    modelParameters.CladdingColours[i] = Colour.Gully;
                    break;
                case 5:
                    modelParameters.CladdingColours[i] = Colour.Ironstone;
                    break;
                case 6:
                    modelParameters.CladdingColours[i] = Colour.Jasper;
                    break;
                case 7:
                    modelParameters.CladdingColours[i] = Colour.Mangrove;
                    break;
                case 9:
                    modelParameters.CladdingColours[i] = Colour.ShaleGrey;
                    break;
                case 10:
                    modelParameters.CladdingColours[i] = Colour.Surfmist;
                    break;
                case 11:
                    modelParameters.CladdingColours[i] = Colour.Terrain;
                    break;
                case 12:
                    modelParameters.CladdingColours[i] = Colour.Wallaby;
                    break;
                case 13:
                    modelParameters.CladdingColours[i] = Colour.Windspray;
                    break;
                default:
                    modelParameters.CladdingColours[i] = Colour.Monument;
                    break;
            }

            modelParameters.CladdingLengths[i] = length;
            modelParameters.CladdingOverlaps[i] = overlap;
            modelParameters.CladdingPercentsOpenArea[i] = openArea;
            modelParameters.CladdingThicknesses[i] = thickness;
            modelParameters.CladdingWidths[i] = width;
            modelParameters.EffectiveCoverWidths[i] = effectiveWidth;
            modelParameters.TopCladdingOffsets[i] = topOffset;
        }

        // Gal Bath
        private void galLocSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // depth and height are equivalent
            switch (galLocSelect.SelectedIndex)
            {
                // GB Dandenong (VIC)
                case 0:
                    galLength.Text = "13500";
                    galWidth.Text = "1800";
                    galDepth.Text = "2700";
                    break;

                // GB Bayswater (VIC)
                case 1:
                    galLength.Text = "9000";
                    galWidth.Text = "1800";
                    galDepth.Text = "2400";
                    break;

                // Geelong (VIC)
                case 2:
                    galLength.Text = "9200";
                    galWidth.Text = "1300";
                    galDepth.Text = "2200";
                    break;

                // Industrial Gal (VIC)
                case 3:
                    galLength.Text = "12300";
                    galWidth.Text = "1800";
                    galDepth.Text = "2400";
                    break;

                // Kingfield (VIC)
                case 4:
                    galLength.Text = "12000";
                    galWidth.Text = "1500";
                    galDepth.Text = "3100";
                    break;

                // Industrial Gal (QLD)
                case 5:
                    galLength.Text = "12000";
                    galWidth.Text = "1800";
                    galDepth.Text = "2400";
                    break;

                // Fero (QLD)
                case 6:
                    galLength.Text = "13000";
                    galWidth.Text = "1800";
                    galDepth.Text = "3000";
                    break;
            }
        }

        // Flashings
        private void FlashingsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;

            FlashingColour.Enabled = FlashingsEnabled.Checked;
            FlashingColour.Text = FlashingColour.Enabled ? "Monument" : "";

            FlashingThickness.Enabled = FlashingsEnabled.Checked;
            FlashingThickness.Text = FlashingThickness.Enabled ? ".45" : "";

            AutoFlashDim.Enabled = FlashingsEnabled.Checked;
            ManualFlashDim.Enabled = FlashingsEnabled.Checked;

            FlashingDimA.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimB.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimC.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimD.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimE.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimF.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimG.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimH.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimI.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimJ.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimK.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimL.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimM.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimN.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimO.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimP.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimQ.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimR.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            FlashingDimS.Enabled = FlashingsEnabled.Checked && !AutoFlashDim.Checked;
            ResetFlashingDimensions();
        }

        private void enableFascia_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            fasciaHeight.Enabled = enableFascia.Checked;
            TwoDButton.Enabled = enableFascia.Checked;
            ThreeDButton.Enabled = enableFascia.Checked;
        }

        // Disable the build button if changes are made
        private void LEDMaterial_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void LEDProfile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void C1Material_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B1Material_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B2Material_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B2Profile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B5Material_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B5Profile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void C1SplitProfile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void C1SplitMaterial_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B1SplitProfile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B1SplitMaterial_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B2SplitProfile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B2SplitMaterial_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B5SplitProfile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B5SplitMaterial_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void HoleHorizontalOffset_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void HoleVerticalOffset_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B3Material_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void B3Profile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void BR1Material_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void BR1Profile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void RailingSpace1_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void RailingSpace2_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void MeshThickness_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void CornerOffset_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void DiagonalTopOffset_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void BoltDiameter_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void DiagonalBottomOffset_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void WalerMaterial_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void WalerProfile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void SeatingPlateMaterial_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void SeatingPlateProfile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void EAMaterial_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void WalkwayMaterial_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void EAProfile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void ZBracketMaterial_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void ZBracketProfile_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void BracketBoltStandard_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void UpperWalerSpacing_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void LowerWalerSpacing_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void SeatingPlateOffset_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void TrimmerBox_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void HandRailingBox_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void KneeRailingBox_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void Radius_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void ExtrusionLength_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void EAClearance_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void ZbracketSpacingA_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void ZbracketSpacingB_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void WalkwayClearance_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void WalkwayWidth_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        
        private void ZbracketEndSpacing_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void BracketBoltDiameter_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void CladLength_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void Thickness_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void Colour_SelectedIndexChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingColour_SelectedIndexChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingThickness_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void TwoDButton_CheckedChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void ThreeDButton_CheckedChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimA_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimB_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimC_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimD_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimE_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimF_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimG_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimH_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimI_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimJ_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimK_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimL_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimM_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimN_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimO_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimP_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimQ_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimR_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void FlashingDimS_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void textBox1_TextChanged(object sender, EventArgs e) { button1.Enabled = false; }
        private void OpenArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            ManualOpenArea.Enabled = OpenArea.SelectedIndex == 3;
        }
        private void LEDThickness_TextChanged(object sender, EventArgs e)
        {

            button1.Enabled = false;
            if (String.IsNullOrEmpty(LEDThickness.Text))
            {
                LEDThickness.Text = "170";
            }

            else
            {

                LEDProfile.Text = "SCREEN" + LEDThickness.Text;
                FlashingDimC.Text = FlashingsEnabled.Checked && AutoFlashDim.Checked ? LEDThickness.Text : FlashingDimC.Text;
                ExtrusionLength.Text = (Convert.ToInt32(LEDThickness.Text) - 25).ToString();
            }

        }

        private void Welding_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                FlashingDimB.Text = FlashingsEnabled.Checked && AutoFlashDim.Checked
                    ? (Convert.ToDouble(HeightOffsetTop.Text) + Convert.ToDouble(Welding.Text) +
                       ModelParameters.BeamDimensions(B1Profile.Text)[0]).ToString()
                    : FlashingDimB.Text;
                FlashingDimH.Text = FlashingsEnabled.Checked && AutoFlashDim.Checked
                    ? (Convert.ToDouble(HeightOffsetTop.Bottom) + Convert.ToDouble(Welding.Text) +
                       ModelParameters.BeamDimensions(B1Profile.Text)[0]).ToString()
                    : FlashingDimH.Text;
            }
            catch (System.FormatException) { }
        }
        private void LEDDensity_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            LEDMaterial.Text = "digital" + LEDDensity.Text;
        }

        private void HeightOffsetTop_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                FlashingDimB.Text = FlashingsEnabled.Checked && AutoFlashDim.Checked
                    ? (Convert.ToDouble(HeightOffsetTop.Text) + Convert.ToDouble(Welding.Text) +
                       ModelParameters.BeamDimensions(B1Profile.Text)[0]).ToString()
                    : FlashingDimB.Text;
            }
            catch (System.FormatException) { }
        }

        private void HeightOffsetBottom_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                FlashingDimH.Text = FlashingsEnabled.Checked && AutoFlashDim.Checked
                    ? (Convert.ToDouble(HeightOffsetTop.Bottom) + Convert.ToDouble(Welding.Text) +
                       ModelParameters.BeamDimensions(B1Profile.Text)[0]).ToString()
                    : FlashingDimH.Text;
            }
            catch (System.FormatException) { }
        }

        private void C1Profile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                FlashingDimD.Text = FlashingsEnabled.Checked && AutoFlashDim.Checked
                    ? ModelParameters.BeamDimensions(C1Profile.Text)[0].ToString()
                    : FlashingDimD.Text;
                FlashingDimE.Text = FlashingsEnabled.Checked && AutoFlashDim.Checked
                    ? (ModelParameters.BeamDimensions(C1Profile.Text)[0] / 2).ToString()
                    : FlashingDimE.Text;
            }
            catch (System.FormatException) { }
        }

        private void B1Profile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            try
            {
                FlashingDimA.Text = FlashingsEnabled.Checked && AutoFlashDim.Checked
                    ? ModelParameters.BeamDimensions(B1Profile.Text)[1].ToString()
                    : FlashingDimA.Text;
                FlashingDimB.Text = FlashingsEnabled.Checked && AutoFlashDim.Checked
                    ? (Convert.ToDouble(HeightOffsetTop.Text) + Convert.ToDouble(Welding.Text) +
                       ModelParameters.BeamDimensions(B1Profile.Text)[0]).ToString()
                    : FlashingDimB.Text;
                FlashingDimH.Text = FlashingsEnabled.Checked && AutoFlashDim.Checked
                    ? (Convert.ToDouble(HeightOffsetTop.Bottom) + Convert.ToDouble(Welding.Text) +
                       ModelParameters.BeamDimensions(B1Profile.Text)[0]).ToString()
                    : FlashingDimH.Text;
            }
            catch (System.FormatException) { }
        }

        private void AutoFlashDim_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            FlashingDimA.Enabled = !AutoFlashDim.Checked;
            FlashingDimB.Enabled = !AutoFlashDim.Checked;
            FlashingDimC.Enabled = !AutoFlashDim.Checked;
            FlashingDimD.Enabled = !AutoFlashDim.Checked;
            FlashingDimE.Enabled = !AutoFlashDim.Checked;
            FlashingDimF.Enabled = !AutoFlashDim.Checked;
            FlashingDimG.Enabled = !AutoFlashDim.Checked;
            FlashingDimH.Enabled = !AutoFlashDim.Checked;
            FlashingDimI.Enabled = !AutoFlashDim.Checked;
            FlashingDimJ.Enabled = !AutoFlashDim.Checked;
            FlashingDimK.Enabled = !AutoFlashDim.Checked;
            FlashingDimL.Enabled = !AutoFlashDim.Checked;
            FlashingDimM.Enabled = !AutoFlashDim.Checked;
            FlashingDimN.Enabled = !AutoFlashDim.Checked;
            FlashingDimO.Enabled = !AutoFlashDim.Checked;
            FlashingDimP.Enabled = !AutoFlashDim.Checked;
            FlashingDimQ.Enabled = !AutoFlashDim.Checked;
            FlashingDimR.Enabled = !AutoFlashDim.Checked;
            FlashingDimS.Enabled = !AutoFlashDim.Checked;
            ResetFlashingDimensions();
        }

        private void ResetFlashingDimensions()
        {
            try
            {
                FlashingDimA.Text = FlashingsEnabled.Checked
                    ? ModelParameters.BeamDimensions(B1Profile.Text)[1].ToString()
                    : "";
                FlashingDimB.Text = FlashingsEnabled.Checked
                    ? (Convert.ToDouble(HeightOffsetTop.Text) + Convert.ToDouble(Welding.Text) +
                       ModelParameters.BeamDimensions(B1Profile.Text)[0]).ToString()
                    : "";
                FlashingDimC.Text = FlashingsEnabled.Checked ? LEDThickness.Text : "";
                FlashingDimD.Text = FlashingsEnabled.Checked
                    ? ModelParameters.BeamDimensions(C1Profile.Text)[0].ToString()
                    : "";
                FlashingDimE.Text = FlashingsEnabled.Checked
                    ? (ModelParameters.BeamDimensions(C1Profile.Text)[1] / 2).ToString()
                    : "";
                FlashingDimF.Text = FlashingsEnabled.Checked ? LEDThickness.Text : "";
                FlashingDimG.Text = FlashingsEnabled.Checked
                    ? (Convert.ToDouble(LEDThickness.Text) + 15).ToString()
                    : "";
                FlashingDimH.Text = FlashingsEnabled.Checked
                    ? (Convert.ToDouble(HeightOffsetBottom.Text) + Convert.ToDouble(Welding.Text) +
                       ModelParameters.BeamDimensions(B1Profile.Text)[0]).ToString()
                    : "";
                FlashingDimI.Text = FlashingsEnabled.Checked ? "15" : "";
                FlashingDimJ.Text = FlashingsEnabled.Checked ? "10" : "";
                FlashingDimK.Text = FlashingsEnabled.Checked ? "10" : "";
                FlashingDimL.Text = FlashingsEnabled.Checked ? "10" : "";
                FlashingDimM.Text = FlashingsEnabled.Checked ? "10" : "";
                FlashingDimN.Text = FlashingsEnabled.Checked ? "10" : "";
                FlashingDimO.Text = FlashingsEnabled.Checked ? "10" : "";
                FlashingDimP.Text = FlashingsEnabled.Checked ? "10" : "";
                FlashingDimQ.Text = FlashingsEnabled.Checked ? "10" : "";
                FlashingDimR.Text = FlashingsEnabled.Checked ? "10" : "";
                FlashingDimS.Text = FlashingsEnabled.Checked ? "10" : "";
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Invalid input in Board Parameters.");
                FlashingDimA.Text = "";
                FlashingDimB.Text = "";
                FlashingDimC.Text = "";
                FlashingDimD.Text = "";
                FlashingDimE.Text = "";
                FlashingDimF.Text = "";
                FlashingDimG.Text = "";
                FlashingDimH.Text = "";
                FlashingDimI.Text = "";
                FlashingDimJ.Text = "";
                FlashingDimK.Text = "";
                FlashingDimL.Text = "";
                FlashingDimM.Text = "";
                FlashingDimN.Text = "";
                FlashingDimO.Text = "";
                FlashingDimP.Text = "";
                FlashingDimQ.Text = "";
                FlashingDimR.Text = "";
                FlashingDimS.Text = "";
            }
        }

        private void GH_autoSelector_CheckedChanged(object sender, EventArgs e)
        {
            modelParameters.IsAutoGalHoleSize = GH_autoSelector.Checked;
            GH_holeSize.Enabled = !GH_autoSelector.Checked;
            GH_holeSize.Text = GH_holeSize.Enabled ? "14" : "";
        }

        private void NoGalHole_CheckedChanged(object sender, EventArgs e)
        {
            GH_holeSize.Enabled = !NoGalHole.Checked;
            GH_offset1.Enabled = !NoGalHole.Checked;
            GH_offset2.Enabled = !NoGalHole.Checked;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                File.WriteAllText(saveFileDialog.FileName, JsonSerializer.Serialize(modelParameters));
                //File.WriteAllText(saveFileDialog.FileName, JsonSerializer.Serialize(modelParameters));
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            
            openFileDialog.FileName = "";
            openFileDialog.ShowDialog();

            // If the file name is not an empty string open it.
            if (openFileDialog.FileName != "")
            {
                modelParameters = JsonSerializer.Deserialize<ModelParameters>(File.ReadAllText(openFileDialog.FileName));

                // populate the UI with previous values
                PopulateUI();

                // enable the build button
                button1.Enabled = false;
            }
        }

        private void PopulateUI()
        {
            // LED cabinets
            rowList.Items.Clear();
            for (int i = 1; i < modelParameters.ZCoordinates.Count; i++)
            {
                rowList.Items.Add(modelParameters.ZCoordinates[i].ToString() + (modelParameters.ZSplits.Contains(i) ? "*" : ""));
            }
            rowSumLabel.Text = rowList.Items.Count.ToString();
            CabinetHeightSumLabel.Text = modelParameters.ScreenHeight.ToString();

            columnList.Items.Clear();
            for (int i = 1; i < modelParameters.XCoordinates.Count; i++)
            {
                columnList.Items.Add(modelParameters.XCoordinates[i].ToString() + (modelParameters.XSplits.Contains(i) ? "*" : ""));
            }
            columnSumLabel.Text = columnList.Items.Count.ToString();
            CabinetLengthSumLabel.Text = modelParameters.ScreenLength.ToString();

            // frame structure
            StructureAutoRadio.Checked = modelParameters.RailingCoordinates.Count == 2;
            StructureManualRadio.Checked = !StructureAutoRadio.Checked;
            HorizontalBeamsList.Items.Clear();
            for (int i = 2; i < modelParameters.RailingCoordinates.Count; i++) { HorizontalBeamsList.Items.Add(modelParameters.RailingCoordinates[i].ToString()); }
            BeamsSumLabel.Text = HorizontalBeamsList.Items.Count.ToString();
            RailingSpace1.Text = ModelParameters.DimToString(modelParameters.RailingSpace1);
            RailingSpace2.Text = ModelParameters.DimToString(modelParameters.RailingSpace2);

            // walers
            WalerAutoRadio.Checked = modelParameters.WalerAuto;
            WalerManualRadio.Checked = !modelParameters.WalerAuto;
            WalerAddValue.Text = modelParameters.WalerAuto ? modelParameters.WalersNumber.ToString() : "";
            WalersList.Items.Clear();
            foreach (double z in modelParameters.WalersCoordinates) { WalersList.Items.Add(z.ToString()); }
            WalerNumberLabel.Text = WalersList.Items.Count.ToString();
            UpperWalerSpacing.Text = ModelParameters.DimToString(modelParameters.UpperWalerSpacing);
            LowerWalerSpacing.Text = ModelParameters.DimToString(modelParameters.LowerWalerSpacing);

            // features
            Welding.Text = ModelParameters.DimToString(modelParameters.WeldOffset);

            // diagonal beam    
            CornerOffset.Text = ModelParameters.DimToString(modelParameters.CornerOffset);
            DiagonalTopOffset.Text = ModelParameters.DimToString(modelParameters.DiagonalTopOffset);
            DiagonalBottomOffset.Text = ModelParameters.DimToString(modelParameters.DiagonalBottomOffset);

            // LED screens
            LEDThickness.Text = modelParameters.LEDProfile.Substring(6);
            LEDDensity.Text = modelParameters.LEDMaterial.Remove(0, 7);

            // gal bath
            galDepth.Text = modelParameters.GalBathHeight.ToString();
            galLength.Text = modelParameters.GalBathLength.ToString();
            galWidth.Text = modelParameters.GalBathWidth.ToString();

            switch (modelParameters.GalBathLength)
            {
                case 13500:
                    galLocSelect.Text = "GB Dandenong (VIC)";
                    break;
                case 9000:
                    galLocSelect.Text = "GB Bayswater (VIC)";
                    break;
                case 9200:
                    galLocSelect.Text = "Geelong (VIC)";
                    break;
                case 12300:
                    galLocSelect.Text = "Industrial Gal (VIC)";
                    break;
                case 13000:
                    galLocSelect.Text = "Fero (QLD)";
                    break;
                default:
                    galLocSelect.Text = Math.Abs(modelParameters.GalBathWidth - 1500) < Double.Epsilon
                        ? "Kingfield (VIC)"
                        : "Industrial Gal (QLD)";
                    break;
            }

            // billboard dimensions
            BillBoardHeight.Text = modelParameters.BillboardHeight.ToString();
            BillBoardLength.Text = modelParameters.BillboardLength.ToString();
            BillBoardDepth.Text = modelParameters.BillboardDepth.ToString();
            BillboardWeight.Text = "0";
            HeightOffsetTop.Text = ModelParameters.DimToString(modelParameters.HeightOffsetTop);
            HeightOffsetBottom.Text = ModelParameters.DimToString(modelParameters.HeightOffsetBottom);

            // cabinet bolts
            HoleHorizontalOffset.Text = ModelParameters.DimToString(modelParameters.BoltOffsetDx);
            HoleVerticalOffset.Text = ModelParameters.DimToString(modelParameters.BoltOffsetDz);
            BoltDiameter.Text = ModelParameters.DimToString(modelParameters.BoltSize);

            // bracket bolts
            BracketBoltStandard.Text = modelParameters.BracketBoltStandard;
            BracketBoltDiameter.Text = ModelParameters.DimToString(modelParameters.BracketBoltDiameter);

            // material and profile
            LEDMaterial.Text = modelParameters.LEDMaterial;
            LEDProfile.Text = modelParameters.LEDProfile;
            C1Material.Text = modelParameters.C1Material;
            C1Profile.Text = modelParameters.C1Profile;
            B1Material.Text = modelParameters.B1Material;
            B1Profile.Text = modelParameters.B1Profile;
            B2Material.Text = modelParameters.B2Material;
            B2Profile.Text = modelParameters.B2Profile;
            B3Material.Text = modelParameters.B3Material;
            B3Profile.Text = modelParameters.B3Profile;
            B5Material.Text = modelParameters.B5Material;
            B5Profile.Text = modelParameters.B5Profile;
            BR1Material.Text = modelParameters.BR1Material;
            BR1Profile.Text = modelParameters.BR1Profile;
            WalerMaterial.Text = modelParameters.WalerMaterial;
            WalerProfile.Text = modelParameters.WalerProfile;
            SeatingPlateMaterial.Text = modelParameters.SeatingPlateMaterial;
            SeatingPlateProfile.Text = modelParameters.SeatingPlateProfile;
            EAMaterial.Text = modelParameters.EAMaterial;
            EAProfile.Text = modelParameters.EAProfile;
            ZBracketMaterial.Text = modelParameters.BracketMaterial;
            ZBracketProfile.Text = modelParameters.ZBracketProfile;

            // split beams
            C1SplitBeamMaterial.Text = modelParameters.C1SplitMaterial;
            C1SplitBeamProfile.Text = modelParameters.C1SplitProfile;
            B1SplitBeamMaterial.Text = modelParameters.B1SplitMaterial;
            B1SplitBeamProfile.Text = modelParameters.B1SplitProfile;
            B2SplitBeamMaterial.Text = modelParameters.B2SplitMaterial;
            B2SplitBeamProfile.Text = modelParameters.B2SplitProfile;
            B5SplitBeamMaterial.Text = modelParameters.B5SplitMaterial;
            B5SplitBeamProfile.Text = modelParameters.B5SplitProfile;
            EASplitBoltOffset.Text = ModelParameters.DimToString(modelParameters.EASplitBoltOffset);
            EACabinetBoltHoleSize.Text = ModelParameters.DimToString(modelParameters.EASplitCabinetBoltHoleSize);

            // seating plate
            SeatingPlateOnButton.Checked = modelParameters.BuildSeatingPlate;
            SeatingPlateOffButton.Checked = !modelParameters.BuildSeatingPlate;
            SeatingPlateOffset.Text = ModelParameters.DimToString(modelParameters.SeatingPlateOffset);
            ExtrusionLength.Text = ModelParameters.DimToString(modelParameters.SeatingPlateExtrusionLength);

            // walkway mesh
            MeshThickness.Text = ModelParameters.DimToString(modelParameters.MeshThickness);
            WalkwayMaterial.Text = modelParameters.MeshMaterial;
            WalkwayClearance.Text = ModelParameters.DimToString(modelParameters.WalkwayClearance);
            WalkwayWidth.Text = ModelParameters.DimToString(modelParameters.WalkwayWidth);
            WalkwayClearance.Text = ModelParameters.DimToString(modelParameters.WalkwayClearance);

            // Z bracket
            ZbracketSpacingA.Text = ModelParameters.DimToString(modelParameters.BracketASpacing);
            ZbracketSpacingB.Text = ModelParameters.DimToString(modelParameters.BracketBSpacing);
            ZbracketEndSpacing.Text = ModelParameters.DimToString(modelParameters.EndBracketSpacing);
            BracketSpacerThickness.Text = ModelParameters.DimToString(modelParameters.ZBracketSpacerThickness);
            SpacerPlateSwitch.Checked = modelParameters.ZBracketSpacer;

            // camera arm
            TopArm.Checked = modelParameters.ArmAtTop && !modelParameters.NoArm;
            BotArm.Checked = !modelParameters.ArmAtTop && !modelParameters.NoArm;
            noArm.Checked = modelParameters.NoArm;
            ArmLengthBox.Text = ModelParameters.DimToString(modelParameters.SetArmLength);
            ArmLeftOffset.Text = ModelParameters.DimToString(modelParameters.ArmOffset);
            ArmAngle.Text = ModelParameters.DimToString(modelParameters.ArmAngle * 180 / Math.PI);
            VertArmLength.Text = ModelParameters.DimToString(modelParameters.VertArmLength);

            // fascia box
            enableFascia.Checked = modelParameters.FasciaEnabled;
            fasciaHeight.Text = ModelParameters.DimToString(modelParameters.FasciaBoxHeight);
            TwoDButton.Checked = modelParameters.isTwoD;
            ThreeDButton.Checked = !modelParameters.isTwoD;

            // lifting points
            topList.Items.Clear();
            foreach (double x in modelParameters.LiftPointsTopX) { topList.Items.Add(x); }
            TopLPCount.Text = topList.Items.Count.ToString();
            bottomList.Items.Clear();
            foreach (double x in modelParameters.LiftPointsBottomX) { bottomList.Items.Add(x); }
            BottomLPCount.Text = bottomList.Items.Count.ToString();

            // mid walkways
            WW_list.Items.Clear();
            foreach (double z in modelParameters.WalkwayList) { WW_list.Items.Add(z); }
            WW_count.Text = WW_list.Items.Count.ToString();

            // cladding
            theSide.Text = "Back";
            ShowCladding(0);

            // gal holes
            NoGalHole.Checked = modelParameters.NoGalHole;
            GH_autoSelector.Checked = modelParameters.IsAutoGalHoleSize;
            GH_manualSelector.Checked = !modelParameters.IsAutoGalHoleSize;
            GH_offset1.Text = modelParameters.GalHoleOffset1.ToString();
            GH_offset2.Text = ModelParameters.DimToString(modelParameters.GalHoleOffset2);
            GH_holeSize.Text = ModelParameters.DimToString(modelParameters.IsAutoGalHoleSize ? 14 : modelParameters.GalHoleSize);

            // flashings
            FlashingsEnabled.Checked = modelParameters.FlashingEnabled;
            FlashingColour.Text = Cladding.ColourToFinish(modelParameters.FlashingColour);
            FlashingThickness.Text = ModelParameters.DimToString(modelParameters.FlashingThickness);
            AutoFlashDim.Checked = false;
            FlashingDimA.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[0]);
            FlashingDimB.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[1]);
            FlashingDimC.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[2]);
            FlashingDimD.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[3]);
            FlashingDimE.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[4]);
            FlashingDimF.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[5]);
            FlashingDimG.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[6]);
            FlashingDimH.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[7]);
            FlashingDimI.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[8]);
            FlashingDimJ.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[9]);
            FlashingDimK.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[10] * 180 / Math.PI);
            FlashingDimL.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[11]);
            FlashingDimM.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[12] * 180 / Math.PI);
            FlashingDimN.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[13]);
            FlashingDimO.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[14] * 180 / Math.PI);
            FlashingDimP.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[15]);
            FlashingDimQ.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[16] * 180 / Math.PI);
            FlashingDimR.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[17]);
            FlashingDimS.Text = ModelParameters.DimToString(modelParameters.FlashingDimensions[18] * 180 / Math.PI);

            //Ladder
            if (modelParameters.LadderMode == 0) { LeftLadder.Checked = true; }
            if (modelParameters.LadderMode == 1) { RightLadder.Checked = true; }
            if (modelParameters.LadderMode == 2) { NoLadder.Checked = true; }
           
            LadderOffsetBackText.Text = modelParameters.LadderOffsetBack.ToString();
            LadderOffsetSideText.Text = modelParameters.LadderOffsetSide.ToString();
            LadderRungSpacingText.Text = modelParameters.LadderRungSpacing.ToString();
            LadderRungMaterialText.Text = modelParameters.LadderRungMaterial;
            LadderPlateMaterialText.Text = modelParameters.LadderPlateMaterial;
            LadderPlateHeightText.Text = modelParameters.LadderPlateHeight.ToString();
            LadderSideRailMaterialText.Text = modelParameters.LadderRailMaterial;
            LadderWidthText.Text = modelParameters.LadderWidth.ToString();
            LadderRailProfileText.Text = modelParameters.LadderRailProfile;
            LadderRungProfileText.Text = modelParameters.LadderRungProfile;
            LadderPlateProfileText.Text = modelParameters.LadderPlateProfile;
            

            //RearDoor
            if (modelParameters.DoorON) { RearDoorEnable.Checked = true; }
            if(!modelParameters.DoorON) { RearDoorEnable.Checked = false; }
            DoorOffsetText.Text = modelParameters.DoorOffsetLeft.ToString();
            DoorWidthText.Text = modelParameters.DoorWidth.ToString();
            DoorMinHeightText.Text = modelParameters.DoorHeight.ToString();
            DoorPanelFrameDistanceText.Text = modelParameters.DoorPanelFrameSpacing.ToString();
            DoorFrameMaterialText.Text = modelParameters.DoorFrameMaterial;
            DoorFrameProfileText.Text = modelParameters.DoorFrameProfile;
            DoorPanelMaterialText.Text = modelParameters.DoorPanelMaterial;
            DoorPanelProfileText.Text = modelParameters.DoorPanelProfile;
        
            if(LeftLadder.Checked == true || RightLadder.Checked == true) { 
                LadderOffsetBackText.Text = modelParameters.LadderOffsetBack.ToString();
                LadderOffsetSideText.Text = modelParameters.LadderOffsetSide.ToString();

                HatchWidthValue.Text = modelParameters.HatchWidth.ToString();
                HatchBeamMaterial.Text = modelParameters.HatchBeamMaterial.ToString();
                HatchBeamProfile.Text = modelParameters.HatchBeamProfile.ToString();
            }
        }

        private void collist_click(object sender, EventArgs e)
        {

            rowList.SelectedIndex = -1;
            ColumnEditRadioButton.Checked = true;
            RowEditRadioButton.Checked = false;
            ColumnAddRadioButton.Checked = true;
            RowAddRadioButton.Checked = false;

        }

        private void rowlist_click(object sender, EventArgs e)
        {
            columnList.SelectedIndex = -1;
            ColumnEditRadioButton.Checked = false;
            RowEditRadioButton.Checked = true;
            ColumnAddRadioButton.Checked = false;
            RowAddRadioButton.Checked = true;

        }

        private void screenlength_changed(object sender, EventArgs e)
        {
            int cameraarm = 0;

            cameraarm = Convert.ToInt32(CabinetLengthSumLabel.Text) / 2;
            if (Convert.ToInt16(columnSumLabel.Text) % 2 == 0)
            {
                cameraarm = cameraarm - 100;
            }


            if (Cameracentre.Checked == true)
            {
                ArmLeftOffset.Text = cameraarm.ToString();
            }


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cameraarmcentre_click(object sender, EventArgs e)
        {
            int cameraarm = 0;

            cameraarm = Convert.ToInt32(CabinetLengthSumLabel.Text) / 2;
            if (Convert.ToInt16(columnSumLabel.Text) % 2 == 0)
            {
                cameraarm = cameraarm - 100;
            }

            if (Cameracentre.Checked == true)
            {
                ArmLeftOffset.Text = cameraarm.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void profileCatalog1_Load(object sender, EventArgs e)
        {

        }





        private void CabinetLengthSumLabel_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
            
            Decimal LEDheightM = (Convert.ToDecimal(LEDHeight.Text) / 1000);
            Decimal LEDwidthM = (Convert.ToDecimal(LEDWidth.Text) / 1000);
            Decimal LEDThicknessM = (Convert.ToDecimal(LEDThickness.Text) / 1000);
            Decimal LEDweight = Convert.ToDecimal(LEDWeight.Text);

            if (LEDheightM == 0)
            {
                MessageBox.Show("Height Cannot be 0");
            }
            else if (LEDwidthM == 0)
            {
                MessageBox.Show("Width Cannot be 0");
            }
            else if (LEDThicknessM == 0)
            {
                MessageBox.Show("Depth Cannot be 0");
            }
            else if (LEDweight == 0)
            {
                MessageBox.Show("Weight Cannot be 0");
            }
            else
            {

                Decimal LEDm3 = LEDheightM * LEDwidthM * LEDThicknessM;
                Decimal LEDdensity = Math.Round((LEDweight / LEDm3), 2);

                LEDDensity.Text = LEDdensity.ToString();
            }

        }

        private void BillboardWeight_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        

        private void profileCatalog1_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog1.SelectedProfile = C1Profile.Text;
        }

        private void profileCatalog1_SelectionDone(object sender, EventArgs e)
        {
            
            C1Profile.Text = profileCatalog1.SelectedProfile;
        }

        private void profileCatalog2_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog2.SelectedProfile = B1Profile.Text;
        }

        private void profileCatalog2_SelectionDone(object sender, EventArgs e)
        {
            B1Profile.Text = profileCatalog2.SelectedProfile;
        }

        private void profileCatalog3_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog3.SelectedProfile = B2Profile.Text;
        }

        private void profileCatalog3_SelectionDone(object sender, EventArgs e)
        {
            B2Profile.Text = profileCatalog3.SelectedProfile;
        }

        private void profileCatalog4_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog4.SelectedProfile = B3Profile.Text;
        }

        private void profileCatalog4_SelectionDone(object sender, EventArgs e)
        {
            B3Profile.Text = profileCatalog4.SelectedProfile;
        }

        private void profileCatalog5_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog5.SelectedProfile = B5Profile.Text;
        }

        private void profileCatalog5_SelectionDone(object sender, EventArgs e)
        {
            B5Profile.Text = profileCatalog5.SelectedProfile;
        }

        private void profileCatalog6_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog6.SelectedProfile = BR1Profile.Text;
        }

        private void profileCatalog6_SelectionDone(object sender, EventArgs e)
        {
            BR1Profile.Text = profileCatalog6.SelectedProfile;
        }

        private void profileCatalog7_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog7.SelectedProfile = WalerProfile.Text;
        }

        private void profileCatalog7_SelectionDone(object sender, EventArgs e)
        {
            WalerProfile.Text = profileCatalog7.SelectedProfile;
        }

        private void profileCatalog8_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog8.SelectedProfile = EAProfile.Text;            
        }

        private void profileCatalog8_SelectionDone(object sender, EventArgs e)
        {
            EAProfile.Text = profileCatalog8.SelectedProfile;
        }

        private void profileCatalog9_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog9.SelectedProfile = ZBracketProfile.Text;
        }

        private void profileCatalog9_SelectionDone(object sender, EventArgs e)
        {
            ZBracketProfile.Text = profileCatalog9.SelectedProfile;
        }

        private void profileCatalog10_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog10.SelectedProfile = C1SplitBeamProfile.Text;
        }

        private void profileCatalog10_SelectionDone(object sender, EventArgs e)
        {
            C1SplitBeamProfile.Text = profileCatalog10.SelectedProfile;
        }

        private void profileCatalog11_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog11.SelectedProfile = B1SplitBeamProfile.Text;
        }

        private void profileCatalog11_SelectionDone(object sender, EventArgs e)
        {
            B1SplitBeamProfile.Text = profileCatalog11.SelectedProfile;
        }

        private void profileCatalog12_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog12.SelectedProfile = B2SplitBeamProfile.Text;
        }

        private void profileCatalog12_SelectionDone(object sender, EventArgs e)
        {
            B2SplitBeamProfile.Text = profileCatalog12.SelectedProfile;
        }

        private void profileCatalog13_SelectClicked(object sender, EventArgs e)
        {
            profileCatalog13.SelectedProfile = B5SplitBeamProfile.Text;
        }

        private void profileCatalog13_SelectionDone(object sender, EventArgs e)
        {
            B5SplitBeamProfile.Text = profileCatalog13.SelectedProfile;
        }

        private void profileCatalog9_Load(object sender, EventArgs e)
        {

        }

        private void LEDWidth_TextChanged(object sender, EventArgs e)
        {

        }

        private void TopArm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BotArm_CheckedChanged(object sender, EventArgs e)
        {

        }

       

        private void partPrefix_TextChanged(object sender, EventArgs e)
        {

           Prefix.part = partPrefix.Text;

        }

        private void assemblyPrefix_TextChanged(object sender, EventArgs e)
        {
           Prefix.assembly = assemblyPrefix.Text;
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void cabinetAddValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void SpacerPlateSwitch_CheckedChanged(object sender, EventArgs e)
        {
            if (SpacerPlateSwitch.Checked)
            {
                BracketSpacerThickness.Enabled = true;
            } else if (!SpacerPlateSwitch.Checked)
            {
                BracketSpacerThickness.Enabled = false;
            }
        }

        private void Curved_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Curved_Check.Checked)
            {
                Radius_Text.Enabled = true;
            }
            else if (!Curved_Check.Checked)
            {
                Radius_Text.Enabled = false;
            }
        }

        private void Ladder_Builder(object sender, EventArgs e)
        {

        }

        private void Enable_Ladder(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event handler for the Right Ladder option.
        /// Enables settings for the right ladder and sets the LadderMode to 1.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Right_Ladder(object sender, EventArgs e)
        {
            // Disable the build button
            button1.Enabled = false;

            // Check if RightLadder button is clickable
            if (RightLadder.Checked)
            {
                // Set the LadderMode to 1 (Right Ladder)
                modelParameters.LadderMode = 1;

                // Enable settings for the right ladder
                
                LadderOffsetBack.Enabled = true;
                LadderOffsetfromSide.Enabled = true;
                LadderOffsetBackText.Enabled = true;
                LadderOffsetSideText.Enabled = true;
                LadderRungSpacing.Enabled = true;
                LadderRungSpacingText.Enabled = true;
                LadderRungMaterialText.Enabled = true;
                LadderPlateHeightText.Enabled = true;
                LadderPlateHeight.Enabled = true;
                LadderPlateMaterialText.Enabled = true;
                LadderSideRailMaterialText.Enabled = true;
                LadderWidth.Enabled = true;
                LadderWidthText.Enabled = true;
                LadderRung.Enabled = true;
                LadderRungProfileText.Enabled = true;
                LadderRungSelect.Enabled = true;
                LadderSideRail.Enabled = true;
                LadderRailProfileText.Enabled = true;
                LadderRailSelect.Enabled = true;
                LadderPlate.Enabled = true;
                LadderPlateProfileText.Enabled = true;
                LadderPlateSelect.Enabled = true;
                //LadderMaterial.Enabled = true;
                //LadderProfile.Enabled = true;

                HatchBeamMaterial.Enabled = true;
                HatchBeamProfile.Enabled = true;
                HatchBeamProfileSelector.Enabled = true;
                HatchWidthValue.Enabled = true;
                HatchWidthName.Enabled = true;
                HatchBeamMaterialName.Enabled = true;

                LadderHatchMaterialName.Enabled = true;
                LadderHatchProfileName.Enabled = true;
            }
        }

        /// <summary>
        /// Event handler for the Left Ladder option.
        /// Enables settings for the left ladder and sets the LadderMode to 0.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Left_Ladder(object sender, EventArgs e)
        {
            // Disable the main button
            button1.Enabled=false;

            // Check if LeftLadder option is clickable
            if (LeftLadder.Checked)
            {
                // Enable settings for the left ladder
                modelParameters.LadderMode = 0;
                LadderOffsetBack.Enabled = true;
                LadderOffsetfromSide.Enabled = true; 
                LadderOffsetBackText.Enabled = true;
                LadderOffsetSideText.Enabled = true;
                LadderRungSpacing.Enabled = true;
                LadderRungSpacingText.Enabled = true;
                LadderRungMaterialText.Enabled = true;
                LadderPlateHeightText.Enabled = true;
                LadderPlateHeight.Enabled = true;
                LadderPlateMaterialText.Enabled = true;
                LadderSideRailMaterialText.Enabled = true;
                LadderWidth.Enabled = true;
                LadderWidthText.Enabled = true;
                LadderRung.Enabled = true;
                LadderRungProfileText.Enabled = true;
                LadderRungSelect.Enabled = true;
                LadderSideRail.Enabled = true;
                LadderRailProfileText.Enabled = true;
                LadderRailSelect.Enabled = true;
                LadderPlate.Enabled = true;
                LadderPlateProfileText.Enabled = true;
                LadderPlateSelect.Enabled = true;


                HatchBeamMaterial.Enabled = true;
                HatchBeamProfile.Enabled = true;
                HatchBeamProfileSelector.Enabled = true;
                HatchWidthValue.Enabled = true;
                HatchWidthName.Enabled = true;
                HatchBeamMaterialName.Enabled = true;

                LadderHatchMaterialName.Enabled = true;
                LadderHatchProfileName.Enabled = true;
            }
        }

        /// <summary>
        /// Event handler for the No Ladder option.
        /// Enables the main button and sets the LadderMode to 2 (No Ladder).
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void No_Ladder(object sender, EventArgs e)
        {
            // Enable the main button
            button1.Enabled=true;

            // Check if NoLadder option is clickable
            if (NoLadder.Checked)
            {

                // Set the LadderMode to 2 (No Ladder)
                modelParameters.LadderMode = 2;

                // Disable settings for any ladder
                
                LadderOffsetBack.Enabled = false;
                LadderOffsetfromSide.Enabled = false;
                LadderOffsetBackText.Enabled = false;
                LadderOffsetSideText.Enabled = false;
                LadderRungSpacing.Enabled = false;
                LadderRungSpacingText.Enabled = false;
                LadderRungMaterialText.Enabled = false;
                LadderPlateHeightText.Enabled = false;
                LadderPlateHeight.Enabled = false;
                LadderPlateMaterialText.Enabled = false;
                LadderSideRailMaterialText.Enabled = false;
                LadderWidth.Enabled = false;
                LadderWidthText.Enabled = false;
                LadderRung.Enabled = false;
                LadderRungProfileText.Enabled = false;
                LadderRungSelect.Enabled = false;
                LadderSideRail.Enabled = false;
                LadderRailProfileText.Enabled = false;
                LadderRailSelect.Enabled = false;
                LadderPlate.Enabled = false;
                LadderPlateProfileText.Enabled = false;
                LadderPlateSelect.Enabled = false;


                HatchBeamMaterial.Enabled = false;
                HatchBeamProfile.Enabled = false;
                HatchBeamProfileSelector.Enabled = false;
                HatchWidthValue.Enabled = false;
                HatchWidthName.Enabled = false;
                HatchBeamMaterialName.Enabled = false;

                LadderHatchMaterialName.Enabled = false;
                LadderHatchProfileName.Enabled = false;
            }
        }

        private void AddLPTop_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LadderOffset_Back(object sender, EventArgs e)
        {

        }

        private void LadderOffsetfrom_Side(object sender, EventArgs e)
        {
            
            
        }

        private void LadderOffsetBack_Text(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void ArmLengthBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LadderOffsetSide_Text(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void LadderRungDiameter_Text(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void LadderRung_Spacing(object sender, EventArgs e)
        {

        }

        private void LadderRungSpacing_Text(object sender, EventArgs e)
        {

        }

        private void LadderRung_Material(object sender, EventArgs e)
        {

        }

        private void LadderRungMaterial_Text(object sender, EventArgs e)
        {

        }

        private void LadderPlate_Thickness(object sender, EventArgs e)
        {

        }

        private void LadderPlateThickness_Text(object sender, EventArgs e)
        {

        }

        private void RearDoor_Group(object sender, EventArgs e)
        {

        }

        private void RearDoor_ON(object sender, EventArgs e)
        {

        }

        private void RearDoor_Enable(object sender, EventArgs e)
        {
            if(RearDoorEnable.Checked )
            {
                modelParameters.DoorON = true;
                DoorOffset.Enabled = true;
                DoorOffsetText.Enabled = true;
                DoorWidth.Enabled = true;
                DoorWidthText.Enabled = true;
                DoorrMinHeight.Enabled = true;
                DoorMinHeightText.Enabled = true;
                DoorFramePanelDistance.Enabled = true;
                DoorPanelFrameDistanceText.Enabled = true;
                DoorMaterial.Enabled = true;
                DoorProfile.Enabled = true;
                DoorFrameProfileText.Enabled = true;
                DoorFrameMaterialText.Enabled = true;
                DoorPanelProfileText.Enabled = true;
                DoorPanelMaterialText.Enabled = true;
                DoorPanelBeamSelect.Enabled = true;
                DoorFrameBeamSelect.Enabled = true;
                DoorPanelBeam.Enabled = true;
                DoorFrameBeam.Enabled = true;

            }
            else
            {
                modelParameters.DoorON = false;
                DoorOffset.Enabled = false;
                DoorOffsetText.Enabled = false;
                DoorWidth.Enabled = false;
                DoorWidthText.Enabled = false;
                DoorrMinHeight.Enabled = false;
                DoorMinHeightText.Enabled = false;
                DoorFramePanelDistance.Enabled = false;
                DoorPanelFrameDistanceText.Enabled = false;
                DoorMaterial.Enabled = false;
                DoorProfile.Enabled = false;
                DoorFrameProfileText.Enabled = false;
                DoorFrameMaterialText.Enabled = false;
                DoorPanelProfileText.Enabled = false;
                DoorPanelMaterialText.Enabled = false;
                DoorPanelBeamSelect.Enabled = false;
                DoorFrameBeamSelect.Enabled = false;
                DoorPanelBeam.Enabled = false;
                DoorFrameBeam.Enabled = false;

            }
        }

        private void DoorFrameProfoile_Done(object sender, EventArgs e)
        {
            DoorFrameProfileText.Text = DoorFrameBeamSelect.SelectedProfile;
        }

        private void DoorPanelProfoile_Done(object sender, EventArgs e)
        {
            DoorPanelProfileText.Text = DoorPanelBeamSelect.SelectedProfile;
        }

        private void LadderRailProfoile_Done(object sender, EventArgs e)
        {
            LadderRailProfileText.Text = LadderRailSelect.SelectedProfile;
        }

        private void LadderRungProfoile_Done(object sender, EventArgs e)
        {
            LadderRungProfileText.Text = LadderRungSelect.SelectedProfile;
        }

        private void LadderPlateProfoile_Done(object sender, EventArgs e)
        {
            LadderPlateProfileText.Text = LadderPlateSelect.SelectedProfile;
        }

        //public void BuildLadder(double height, double width, TSG.Point startpoint)
        //{
        //    Beam sideRail = CreateSideRail(height, width, startpoint);
        //    Beam rung = CreateRung(width, startpoint);

        //    // Insert side rails and rungs into the model
        //    //sideRail.Insert();
        //    //rung.Insert();    

        //    // Connect the rungs to the side rails
        //    ConnectRungs(sideRail, rung);
        //}


        private void HatchBeamProfile_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
            //modelParameters.HatchBeamProfile = HatchBeamProfile.Text;
        }

        private void HatchBeamMaterial_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void HatchBeamProfileSelector_SelectClicked(object sender, EventArgs e)
        {
            HatchBeamProfileSelector.SelectedProfile = HatchBeamProfile.Text;
        }

        private void HatchBeamProfileSelector_SelectionDone(object sender, EventArgs e)
        {
            HatchBeamProfile.Text = HatchBeamProfileSelector.SelectedProfile;
        }

        private void HatchWidth_TextChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = false;

        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            // Bacck bracing is enabled.
            // This feature is optional as the it is still in progress.
            button1.Enabled = false;
            if (checkBox1.Checked)
            {
                modelParameters.EnableBackBracing = true;
            } else
            {
                modelParameters.EnableBackBracing = false;
            }
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }
    }
}