using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tekla.Structures.Dialog.UIControls;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    public class Hatch
    {
        /// <summary>
        /// The starting point of the hatch.
        /// </summary>
        public TSG.Point HatchStart { get; set; }

        /// <summary>
        /// The ending point of the hatch.
        /// </summary>
        public TSG.Point HatchEnd { get; set; }

        /// <summary>
        /// The distance of the hatch from the ladder.
        /// The space that will be left out.
        /// </summary>
        public double YDistanceForLadder { get; set; }

        /// <summary>
        /// Indicate if this hatch is a left hatch or not.
        /// </summary>
        public bool IsLeftHatch { get; set; }

        // TODO
        //private Assembly _hatchAssembly = new Assembly();



        /*
         * HatchStart and HatchEnd are the start and end point of the inner rectangle of the hatch 
         * 
         * High-level view of the hatch and its components:
         * 
         * 
         * 
         *                          (horizontal beam)
         *                 _     (ladder would be here)
         *                 |
         *                 |  y distance left out for the ladder
         *                 | 
         *                 |
         *                 |            back         HatchEnd point    
         *                 -_____________________________*
         *                 |                            /|
         *                 |                      /      |
         *        y   left |              /  diaganal    | right         
         *                 |       /                     |
         *                 |/       LED screen side      |
         *                 *-----------------------------|
         *     HatchStart point         front            
         *                                                 
         *                                x   
         *                                
         * There will also be hinge gap left out on the left and right side so that the hatch can open.
         * This is not illustrated.
         * 
         * Seating plate will be under the side of the beam (left/right) that is opposite to the beam with the hinges. 
         * (e.g. the seating plate will be under the right beam if it is a left hatch.)
         *                             
         */
        /// <summary>
        /// A hatch class representing each of the individual hatches of the billboard.
        /// </summary>
        /// <param name="HatchStart"> The starting position of the hatch (refer to diagram). </param>
        /// <param name="HatchEnd"> The end position of the hatch. (refer to diagram)</param>
        /// <param name="HatchZ"> The Z position of the hatch. </param>
        /// <param name="YDistanceForLadder"> The distance of the hatch from the ladder. </param>
        /// <param name="IsLeftHatch"> True: this hatch is a hatch on the left side, False: it is a hatch on the right side of the billboard. </param>
        public Hatch(TSG.Point HatchStart, TSG.Point HatchEnd, double HatchZ, double YDistanceForLadder, bool IsLeftHatch)
        {
            this.HatchStart = HatchStart;
            this.HatchEnd = HatchEnd;
            this.YDistanceForLadder = YDistanceForLadder;

            this.HatchStart.Z = HatchZ;
            this.HatchEnd.Z = HatchZ;
            this.IsLeftHatch = IsLeftHatch;
        }

        /// <summary>
        /// Builds the hatch with the input specification.
        /// </summary>
        /// <param name="modelParameters"> modelParameters </param>
        /// <returns> List of Part objects of the Part objects created for the hatch. </returns>
        public List<Part> BuildHatch(ModelParameters modelParameters)
        {
            List<Part> PartsCreated = new List<Part>();

            // Define width and height for the hatch beam.
            double HatchBeamWidth = modelParameters.HatchBeamDepth;
            double HatchBeamHeight = modelParameters.HatchBeamWidth;
            double HingeSpace = 10;

            // Create the front beam:
            // Adjust the end point of the beam.
            TSG.Point FrontBeamStartPoint = new TSG.Point(HatchStart);
            // Translate by half of the beam width and weld offset to the correct start pos of the reference line.
            FrontBeamStartPoint.Y -= (HatchBeamWidth / 2) + modelParameters.WeldOffset; 
            FrontBeamStartPoint.X += modelParameters.WeldOffset;

            TSG.Point FrontBeamEndPoint = new TSG.Point(HatchEnd);
            FrontBeamEndPoint.Y = FrontBeamStartPoint.Y;
            FrontBeamEndPoint.X -= modelParameters.WeldOffset;

            // Adjust the start and end point for hinge space.
            TSG.Point FrontBeamStartPointAdjusted = new TSG.Point(FrontBeamStartPoint);
            TSG.Point FrontBeamEndPointAdjusted = new TSG.Point(FrontBeamEndPoint);

            FrontBeamStartPointAdjusted.X += HingeSpace;
            FrontBeamEndPointAdjusted.X -= HingeSpace;

            // Create the front beam.
            PartsCreated.Add(Box.CreateBeam
                (
                   Prefix.part,
                   Prefix.assembly,
                   FrontBeamStartPointAdjusted,
                   FrontBeamEndPointAdjusted,
                   modelParameters.HatchBeamMaterial,
                   modelParameters.HatchBeamProfile,
                   "9",
                   new int[] { 0, 0, 0 },
                   new double[] { 0, 0, 0 }
                )
            );
            
            // Create the back beam:
            TSG.Point BackBeamEndPoint = new TSG.Point(HatchEnd);
            BackBeamEndPoint.Y += (HatchBeamWidth / 2) - modelParameters.WeldOffset;
            BackBeamEndPoint.X -= modelParameters.WeldOffset;

            TSG.Point BackBeamStartPoint = new TSG.Point(HatchStart);
            BackBeamStartPoint.Y = BackBeamEndPoint.Y;
            BackBeamStartPoint.X += modelParameters.WeldOffset;

            TSG.Point BackBeamStartPointAdjusted = new TSG.Point(BackBeamStartPoint);
            TSG.Point BackBeamEndPointAdjusted = new TSG.Point(BackBeamEndPoint);

            BackBeamStartPointAdjusted.X += HingeSpace;
            BackBeamEndPointAdjusted.X -= HingeSpace;

            PartsCreated.Add(Box.CreateBeam
                (
                   Prefix.part,
                   Prefix.assembly,
                   BackBeamStartPointAdjusted,
                   BackBeamEndPointAdjusted,
                   modelParameters.HatchBeamMaterial,
                   modelParameters.HatchBeamProfile,
                   "9",
                   new int[] { 0, 0, 0 },
                   new double[] { 0, 0, 0 }
                )
            );

            // Create the left beam
            TSG.Point LeftBeamStartPoint = new TSG.Point(HatchStart);
            LeftBeamStartPoint.X -= (HatchBeamWidth / 2);
            LeftBeamStartPoint.Y -= HatchBeamWidth + modelParameters.WeldOffset;

            TSG.Point LeftBeamEndPoint = new TSG.Point(HatchEnd);
            LeftBeamEndPoint.X = LeftBeamStartPoint.X;
            LeftBeamEndPoint.Y += HatchBeamWidth - modelParameters.WeldOffset;

            TSG.Point LeftBeamStartPointAdjusted = new TSG.Point(LeftBeamStartPoint);
            TSG.Point LeftBeamEndPointAdjusted = new TSG.Point(LeftBeamEndPoint);

            LeftBeamStartPointAdjusted.X += HingeSpace;
            LeftBeamEndPointAdjusted.X += HingeSpace;

            PartsCreated.Add(Box.CreateBeam
                (
                    Prefix.part,
                    Prefix.assembly,
                    LeftBeamStartPointAdjusted,
                    LeftBeamEndPointAdjusted,
                    modelParameters.HatchBeamMaterial,
                    modelParameters.HatchBeamProfile,
                    "9",
                    new int[] { 0, 0, 0 },
                    new double[] { 0, 0, 0 }
                )
            );

            // Create the right beam
            TSG.Point RightBeamEndPoint = new TSG.Point(HatchEnd);
            RightBeamEndPoint.X += (HatchBeamWidth / 2);
            RightBeamEndPoint.Y += HatchBeamWidth - modelParameters.WeldOffset;

            TSG.Point RightBeamStartPoint = new TSG.Point(HatchStart);
            RightBeamStartPoint.X = RightBeamEndPoint.X;
            RightBeamStartPoint.Y -= HatchBeamWidth + modelParameters.WeldOffset;

            TSG.Point RightBeamEndPoinAdjustedt = new TSG.Point(RightBeamEndPoint);
            TSG.Point RightBeamStartPoinAdjustedt = new TSG.Point(RightBeamStartPoint);
            
            RightBeamStartPoinAdjustedt.X -= HingeSpace;
            RightBeamEndPoinAdjustedt.X -= HingeSpace;

            PartsCreated.Add(
                Box.CreateBeam
                (
                    Prefix.part,
                    Prefix.assembly,
                    RightBeamStartPoinAdjustedt,
                    RightBeamEndPoinAdjustedt,
                    modelParameters.HatchBeamMaterial,
                    modelParameters.HatchBeamProfile,
                    "9",
                    new int[] { 0, 0, 0 },
                    new double[] { 0, 0, 0 }
                )
            );

            // Create the diagonal beam.
            TSG.Point HatchStartAdjusted = new TSG.Point(HatchStart);
            TSG.Point HatchEndAdjusted = new TSG.Point(HatchEnd);

            HatchStartAdjusted.X += HingeSpace;
            HatchEndAdjusted.X -= HingeSpace;

            PartsCreated.Add(Diagonal.CreateDiagonalBeam(
                HatchStartAdjusted,
                HatchEndAdjusted,
                new TSG.Point(0, HatchStart.Y, 0),
                modelParameters,
                modelParameters.HatchBeamProfile,
                modelParameters.HatchBeamMaterial,
                modelParameters.HatchBeamDepth,
                modelParameters.HatchBeamWidth
                )
            );

            // Create the B2 beam support on the left side of the hatch.
            TSG.Point LeftSupportStart = new TSG.Point(LeftBeamStartPoint);
            TSG.Point LeftSupportEnd = new TSG.Point(LeftBeamEndPoint);

            LeftSupportEnd.X -= (HatchBeamWidth / 2) + (modelParameters.B2BeamWidth / 2) + modelParameters.WeldOffset;
            LeftSupportEnd.Y += YDistanceForLadder;
            LeftSupportStart.X = LeftSupportEnd.X;

            LeftSupportStart.Z += HatchBeamHeight / 2;
            LeftSupportEnd.Z = LeftSupportStart.Z;

            PartsCreated.Add(Box.CreateBeam(
                Prefix.part, 
                Prefix.assembly,
                LeftSupportStart,
                LeftSupportEnd,
                modelParameters.B2Material,
                modelParameters.B2Profile,
                "4",
                new int[] { 2, 0, 1 },
                new double[] { 0, 0, 0 }
                )
            );

            // Create the B2 beam support on the right side of the hatch.
            TSG.Point RightSupportStart = new TSG.Point(RightBeamStartPoint);
            TSG.Point RightSupportEnd = new TSG.Point(RightBeamEndPoint);

            RightSupportEnd.X += (HatchBeamWidth / 2) + (modelParameters.B2BeamWidth / 2) + modelParameters.WeldOffset;
            RightSupportEnd.Y += YDistanceForLadder;
            RightSupportStart.X = RightSupportEnd.X;

            RightSupportStart.Z = LeftSupportStart.Z;
            RightSupportEnd.Z = LeftSupportStart.Z;

            PartsCreated.Add(Box.CreateBeam(
                Prefix.part,
                Prefix.assembly,
                RightSupportStart,
                RightSupportEnd,
                modelParameters.B2Material,
                modelParameters.B2Profile,
                "4",
                new int[] { 2, 0, 1 },
                new double[] { 0, 0, 0 }
                )
             );



            /* Generate the hinges for the hatch. The hinges will connect to either the left/right beam and the corresponding left/right support beam.
             * 
             *         2             100                3
             *           *____________________________*
             *           |                            |
             *           |        bolt hole --> (+)   | 30      the bolt hole is 15mm away from the three surround side
             *  z     50 |              *_____________*
             *           |            5 |    50         4
             *           |              | 20
             *           *______________*
             *         1         50       6
             *                          
             *                         x
             */

            // The default hinges are for hatches on the right side. For hatches on the left side which opens towards the left, it will need to translate its x by the x adjustment.
            double LeftHatchHingeAdjustment = 0;
            if (IsLeftHatch)
            {
                // Distance between the support beams in X coord.
                LeftHatchHingeAdjustment = (RightSupportStart.X - LeftSupportStart.X) - (modelParameters.B2BeamWidth/2) * 2 - 70;
            }

            // NOTE: the variable name and comment are for the default right hacthes. 
            // For left hatch, switch the position to the opposite. (e.g. HingeSupportBeamFrontPoints is more like HingeHatchBeamFromPoints for left hatches because it translated)

            // Generate the hinge on the support beam on the front.
            List<TSG.Point> HingeSupportBeamFrontPoints = new List<TSG.Point>();

            TSG.Point HingeSupportBeamFrontPoint1 = new TSG.Point(FrontBeamEndPoint.X + HatchBeamWidth + 2*modelParameters.WeldOffset + modelParameters.B2BeamWidth, FrontBeamEndPoint.Y, RightSupportStart.Z + modelParameters.WeldOffset);
            TSG.Point HingeSupportBeamFrontPoint2 = new TSG.Point(HingeSupportBeamFrontPoint1.X, HingeSupportBeamFrontPoint1.Y, HingeSupportBeamFrontPoint1.Z + 50);
            TSG.Point HingeSupportBeamFrontPoint3 = new TSG.Point(HingeSupportBeamFrontPoint2.X - 100, HingeSupportBeamFrontPoint1.Y, HingeSupportBeamFrontPoint2.Z);
            TSG.Point HingeSupportBeamFrontPoint4 = new TSG.Point(HingeSupportBeamFrontPoint3.X, HingeSupportBeamFrontPoint1.Y, HingeSupportBeamFrontPoint2.Z - 30);
            TSG.Point HingeSupportBeamFrontPoint5 = new TSG.Point(HingeSupportBeamFrontPoint3.X + 50, HingeSupportBeamFrontPoint1.Y, HingeSupportBeamFrontPoint4.Z);
            TSG.Point HingeSupportBeamFrontPoint6 = new TSG.Point(HingeSupportBeamFrontPoint5.X, HingeSupportBeamFrontPoint1.Y, HingeSupportBeamFrontPoint4.Z - 20 + modelParameters.WeldOffset);

            HingeSupportBeamFrontPoints.Add(HingeSupportBeamFrontPoint1);
            HingeSupportBeamFrontPoints.Add(HingeSupportBeamFrontPoint2);
            HingeSupportBeamFrontPoints.Add(HingeSupportBeamFrontPoint3);
            HingeSupportBeamFrontPoints.Add(HingeSupportBeamFrontPoint4);
            HingeSupportBeamFrontPoints.Add(HingeSupportBeamFrontPoint5);
            HingeSupportBeamFrontPoints.Add(HingeSupportBeamFrontPoint6);
            
            foreach (TSG.Point points in HingeSupportBeamFrontPoints)
            {
                points.X -= LeftHatchHingeAdjustment;
            }

            Plate HingeSupportBeamFront = new Plate(HingeSupportBeamFrontPoints, modelParameters.CamPlateProfile, modelParameters.CamPlateMaterial, Position.DepthEnum.BEHIND);
            PartsCreated.Add(HingeSupportBeamFront.ContourPlate);



            // Generate the hinge on the hatch beam on the front.
            List<TSG.Point> HingeHatchBeamFrontPoints = new List<TSG.Point>();

            double HingeHatchBeamOffset = 100 + 100 - 30;
            TSG.Point HingeHatchBeamFrontPoint1 = new TSG.Point(HingeSupportBeamFrontPoint1);
            HingeHatchBeamFrontPoint1.X -= HingeHatchBeamOffset;
            TSG.Point HingeHatchBeamFrontPoint2 = new TSG.Point(HingeSupportBeamFrontPoint2);
            HingeHatchBeamFrontPoint2.X = HingeHatchBeamFrontPoint1.X;
            TSG.Point HingeHatchBeamFrontPoint3 = new TSG.Point(HingeSupportBeamFrontPoint3);
            HingeHatchBeamFrontPoint3.X = HingeHatchBeamFrontPoint1.X + 100;
            TSG.Point HingeHatchBeamFrontPoint4 = new TSG.Point(HingeSupportBeamFrontPoint4);
            HingeHatchBeamFrontPoint4.X = HingeHatchBeamFrontPoint3.X;
            TSG.Point HingeHatchBeamFrontPoint5 = new TSG.Point(HingeSupportBeamFrontPoint5);
            HingeHatchBeamFrontPoint5.X = HingeHatchBeamFrontPoint4.X - 50;
            TSG.Point HingeHatchBeamFrontPoint6 = new TSG.Point(HingeSupportBeamFrontPoint6);
            HingeHatchBeamFrontPoint6.X = HingeHatchBeamFrontPoint5.X;

            HingeHatchBeamFrontPoints.Add(HingeHatchBeamFrontPoint1);
            HingeHatchBeamFrontPoints.Add(HingeHatchBeamFrontPoint2);
            HingeHatchBeamFrontPoints.Add(HingeHatchBeamFrontPoint3);
            HingeHatchBeamFrontPoints.Add(HingeHatchBeamFrontPoint4);
            HingeHatchBeamFrontPoints.Add(HingeHatchBeamFrontPoint5);
            HingeHatchBeamFrontPoints.Add(HingeHatchBeamFrontPoint6);

            Plate HingeHatchBeamFront = new Plate(HingeHatchBeamFrontPoints, modelParameters.CamPlateProfile, modelParameters.CamPlateMaterial, Position.DepthEnum.BEHIND);
            PartsCreated.Add(HingeHatchBeamFront.ContourPlate);



            // Generate the hinge on the support beam in the back.
            List<TSG.Point> HingeSupportBeamBackPoints = new List<TSG.Point>();

            TSG.Point HingeSupportBeamBackPoint1 = new TSG.Point(HingeSupportBeamFrontPoint1);
            HingeSupportBeamBackPoint1.Y = BackBeamEndPoint.Y;
            TSG.Point HingeSupportBeamBackPoint2 = new TSG.Point(HingeSupportBeamFrontPoint2);
            HingeSupportBeamBackPoint2 .Y = HingeSupportBeamBackPoint1.Y;
            TSG.Point HingeSupportBeamBackPoint3 = new TSG.Point(HingeSupportBeamFrontPoint3);
            HingeSupportBeamBackPoint3.Y = HingeSupportBeamBackPoint1.Y;
            TSG.Point HingeSupportBeamBackPoint4 = new TSG.Point(HingeSupportBeamFrontPoint4);
            HingeSupportBeamBackPoint4.Y = HingeSupportBeamBackPoint1.Y;
            TSG.Point HingeSupportBeamBackPoint5 = new TSG.Point(HingeSupportBeamFrontPoint5);
            HingeSupportBeamBackPoint5.Y = HingeSupportBeamBackPoint1.Y;
            TSG.Point HingeSupportBeamBackPoint6 = new TSG.Point(HingeSupportBeamFrontPoint6);
            HingeSupportBeamBackPoint6.Y = HingeSupportBeamBackPoint1.Y;

            HingeSupportBeamBackPoints.Add(HingeSupportBeamBackPoint1);
            HingeSupportBeamBackPoints.Add(HingeSupportBeamBackPoint2);
            HingeSupportBeamBackPoints.Add(HingeSupportBeamBackPoint3);
            HingeSupportBeamBackPoints.Add(HingeSupportBeamBackPoint4);
            HingeSupportBeamBackPoints.Add(HingeSupportBeamBackPoint5);
            HingeSupportBeamBackPoints.Add(HingeSupportBeamBackPoint6);

            Plate HingeSupportBeamBack = new Plate(HingeSupportBeamBackPoints, modelParameters.CamPlateProfile, modelParameters.CamPlateMaterial, Position.DepthEnum.BEHIND);
            PartsCreated.Add(HingeSupportBeamBack.ContourPlate);



            // Generate the hinge on the hatch beam in the back.
            List<TSG.Point> HingeHatchBeamBackPoints = new List<TSG.Point>();

            //double HingeHatchBeamOffset = 100 + 100 - 30;
            TSG.Point HingeHatchBeamBackPoint1 = new TSG.Point(HingeHatchBeamFrontPoint1);
            HingeHatchBeamBackPoint1.Y = BackBeamEndPoint.Y;
            TSG.Point HingeHatchBeamBackPoint2 = new TSG.Point(HingeHatchBeamFrontPoint2);
            HingeHatchBeamBackPoint2.Y = HingeHatchBeamBackPoint1.Y;
            TSG.Point HingeHatchBeamBackPoint3 = new TSG.Point(HingeHatchBeamFrontPoint3);
            HingeHatchBeamBackPoint3.Y = HingeHatchBeamBackPoint1.Y;
            TSG.Point HingeHatchBeamBackPoint4 = new TSG.Point(HingeHatchBeamFrontPoint4);
            HingeHatchBeamBackPoint4.Y = HingeHatchBeamBackPoint1.Y;
            TSG.Point HingeHatchBeamBackPoint5 = new TSG.Point(HingeHatchBeamFrontPoint5);
            HingeHatchBeamBackPoint5.Y = HingeHatchBeamBackPoint1.Y;
            TSG.Point HingeHatchBeamBackPoint6 = new TSG.Point(HingeHatchBeamFrontPoint6);
            HingeHatchBeamBackPoint6.Y = HingeHatchBeamBackPoint1.Y;

            HingeHatchBeamBackPoints.Add(HingeHatchBeamBackPoint1);
            HingeHatchBeamBackPoints.Add(HingeHatchBeamBackPoint2);
            HingeHatchBeamBackPoints.Add(HingeHatchBeamBackPoint3);
            HingeHatchBeamBackPoints.Add(HingeHatchBeamBackPoint4);
            HingeHatchBeamBackPoints.Add(HingeHatchBeamBackPoint5);
            HingeHatchBeamBackPoints.Add(HingeHatchBeamBackPoint6);

            Plate HingeHatchBeamBack = new Plate(HingeHatchBeamBackPoints, modelParameters.CamPlateProfile, modelParameters.CamPlateMaterial, Position.DepthEnum.BEHIND);
            PartsCreated.Add(HingeHatchBeamBack.ContourPlate);


            // TODO
            //// Create the two bolts
            //TSG.Point BoltPosition = new TSG.Point(HingeHatchBeamBackPoint4);
            //BoltPosition.X -= 15;
            //BoltPosition.Z += 15;


            //BoltArray Bolts = new BoltArray
            //{
            //    PartToBeBolted = HingeHatchBeamBack.ContourPlate,
            //    PartToBoltTo = HingeSupportBeamBack.ContourPlate,

            //    FirstPosition = BoltPosition,
            //    SecondPosition = BoltPosition,

            //    BoltSize = modelParameters.BoltSize,
            //    Tolerance = 2.0,
            //    BoltStandard = modelParameters.BracketBoltStandard,
            //    CutLength = 500,
            //    Length = 0,
            //    ExtraLength = 5,
            //    ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
            //};

            //// Bolt offsets
            //Bolts.Position.Depth = Position.DepthEnum.MIDDLE;
            //Bolts.Position.DepthOffset = 0;
            //Bolts.Position.Plane = Position.PlaneEnum.MIDDLE;
            //Bolts.Position.Rotation = Position.RotationEnum.BELOW;
            //Bolts.Position.RotationOffset = 0;

            //// the following properties determine the shape of bolts
            //// In this case, we set everything to false
            //Bolts.Bolt = true;
            //Bolts.Washer1 = false;
            //Bolts.Washer2 = false;
            //Bolts.Washer3 = true;
            //Bolts.Nut1 = true;
            //Bolts.Nut2 = false;

            //Bolts.Hole1 = false;
            //Bolts.Hole2 = false;
            //Bolts.Hole3 = false;
            //Bolts.Hole4 = false;
            //Bolts.Hole5 = false;

            //// Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
            //Bolts.AddBoltDistY(0);

            //// Add the distance between two holes 
            //Bolts.AddBoltDistX(0);

            //// Specify the offset to the first bolt 
            //Bolts.StartPointOffset.Dx = 0;

            //if (!Bolts.Insert())
            //{
            //    MessageBox.Show("Insert hatch hinge bolts failed");
            //}



            /* Create Seating Plate
             * 
             *                  2  back  3
             *                   *______*
             *                   |      |
             *                   |      |
             *                   |      |
             *         y    left |      | right
             *                   |      |
             *                   |      |
             *                   *______*
             *                  1  front 4
             *                       
             *                      x
             */

            // The default seating plate location places the plate on the right side (i.e. for left side hatches). For the left side it need to translate.
            double SeatingPlateXAdjustment = 0;
            if (!IsLeftHatch)
            {
                SeatingPlateXAdjustment = (HatchEnd.X - HatchStart.X) + 2 * HatchBeamWidth - 2 * HingeSpace;
            }

            // Establish the four points and height.
            double FrontY = RightBeamStartPoint.Y;
            double BackY = RightBeamEndPoint.Y;
            double RightX = RightSupportStart.X - modelParameters.B2BeamWidth/2 - modelParameters.WeldOffset - SeatingPlateXAdjustment;
            double LeftX = RightX - HingeSpace * 2;
            double SeatingPlateZ = HatchEnd.Z - HatchBeamHeight/2;

            List<TSG.Point> SeatingPlatePoints = new List<TSG.Point>();
            TSG.Point SeatingPlatePoint1 = new TSG.Point(LeftX, FrontY, SeatingPlateZ);
            TSG.Point SeatingPlatePoint2 = new TSG.Point(LeftX, BackY, SeatingPlateZ);
            TSG.Point SeatingPlatePoint3 = new TSG.Point(RightX, BackY, SeatingPlateZ);
            TSG.Point SeatingPlatePoint4 = new TSG.Point(RightX, FrontY, SeatingPlateZ);

            SeatingPlatePoints.Add(SeatingPlatePoint1);
            SeatingPlatePoints.Add(SeatingPlatePoint2);
            SeatingPlatePoints.Add(SeatingPlatePoint3);
            SeatingPlatePoints.Add(SeatingPlatePoint4);

            Plate SeatingPlate = new Plate(SeatingPlatePoints, modelParameters.SeatingPlateProfile, modelParameters.SeatingPlateMaterial, Position.DepthEnum.BEHIND);
            PartsCreated.Add(SeatingPlate.ContourPlate);

            return PartsCreated;
        }
    }
}
