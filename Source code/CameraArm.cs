using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Tekla.Structures;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// The class for the camera arm, containing its attributes and functions to generate a camera arm for the structure
    /// </summary>
    public class CameraArm
    {
        /// <value>
        /// String indicating the profile of the arms
        /// </value>
        public string Profile { get; set; }

        /// <value>
        /// String indicating the profile of the plates on the arm
        /// </value>
        public string Material { get; set; }

        /// <value>
        /// Double representing an angle for geometric analysis 
        /// </value>
        public double Alpha { get; set; }

        /// <value>
        /// Double representing an angle for geometric analysis
        /// </value>
        public double Beta { get; set; }

        /// <value>
        /// Used for additional supports 
        /// </value>
        public double M { get; set; }

        /// <value>
        /// Used for additional supports
        /// </value>
        public double N { get; set; }

        /// <value>
        /// Switches the Z coordinates if the camera is on the bottom of the billboard
        /// </value>
        public int Mult { get; set; }

        /// <value>
        /// Attribute to store the model's parameters
        /// </value>
        public ModelParameters modelParameters { get; set; }

        /// <value>
        /// Indicates the depth of the provided profile
        /// </value>
        public double BeamDepth { get; set; }

        /// <value>
        /// Indicates the width of the provided profile
        /// </value>
        public double BeamWidth { get; set; }

        /// <value>
        /// Indicates the thickness of the provided profile
        /// </value>
        public double BeamThicccness { get; set; }

        /// <value>
        /// Indicates the thickness of the provided plate profile
        /// </value>
        public double PlateThickness { get; set; }

        /// <value>
        /// Indicates the Height of the model 
        /// </value>
        public double Height { get; set; }

        /// <value>
        /// Indicates the lower baseplate for the camera arm
        /// </value>
        public Plate BasePlateLower { get; set; }

        /// <value>
        /// Indicates the upper baseplate for the camera arm
        /// </value>
        public Plate BasePlateUpper { get; set; }

        /// <value>
        /// Indicates the left complex support plate
        /// </value>
        public Plate SupPlateLeft { get; set; }

        /// <value>
        /// Indicates the right complesx support plate
        /// </value>
        public Plate SupPlateRight { get; set; }

        /// <value>
        /// Indicates an additional left support plate
        /// </value>
        public Plate ExtraSupPlateLeft { get; set; }

        /// <value>
        /// Indicates an additional right support plate
        /// </value>
        public Plate ExtraSupPlateRight { get; set; }

        /// <summary>
        /// Constructor, which builds the camera arm with the relevant positioning and user inputs
        /// </summary>
        /// <param name="beamProfile"> The profile for the beams in the arm</param>
        /// <param name="plateProfile"> The profile of the plates in the arm</param>
        /// <param name="modelParameters"> The parameters of the model</param>
        public CameraArm
            (
                string beamProfile,
                string plateProfile,
                ModelParameters modelParameters
            )
        {
            if (modelParameters.NoArm) { return; }

            this.Profile = beamProfile;
            this.Material = plateProfile;
            this.Beta = Math.PI / 2 - modelParameters.ArmAngle;
            this.modelParameters = modelParameters;
            this.Height = modelParameters.BillboardHeight;


            // Convert the first. second and third string to a double that represents the depth, width and thickness of the beam 
            string[] FinalDimensions;
            FinalDimensions = this.Profile.Substring(3).Split('*');
            this.BeamDepth = Convert.ToDouble(FinalDimensions[0]);
            this.BeamWidth = Convert.ToDouble(FinalDimensions[1]);
            this.BeamThicccness = Convert.ToDouble(FinalDimensions[2]);

            FinalDimensions = modelParameters.CamPlateProfile.Substring(2).Split('T');
            this.PlateThickness = Convert.ToDouble(FinalDimensions[1]);

            this.Mult = -1;
            this.Height = -16;
            if (modelParameters.ArmAtTop)
            {
                this.Mult = 1;
                this.Height = modelParameters.BillboardHeight - 6;
            }

            this.Height -= this.BeamWidth;

            // Creates the Camera Arm
            (TSG.Point b1, TSG.Point b2, TSG.Point b3) = CreatePolyBeam();

            b3.Translate(0, -5 * Math.Cos(modelParameters.ArmAngle), this.Mult * 10 * Math.Sin(modelParameters.ArmAngle));

            // Creates the Support Plates
            this.M = 200;
            this.N = 100;
            this.Alpha = modelParameters.ArmAngle + Math.PI / 2 - Math.Atan((N / 2 * Math.Sin(modelParameters.ArmAngle + Math.PI / 2) / (M / 2 + N / 2 * Math.Cos(modelParameters.ArmAngle + Math.PI / 2))));
            if (modelParameters.VertArmLength + M / 2 / Math.Tan(Alpha) > 400)
            {
                this.M = 100;
                this.N = 100;
                this.Alpha = modelParameters.ArmAngle + Math.PI / 2 - Math.Atan((N / 2 * Math.Sin(modelParameters.ArmAngle + Math.PI / 2) / (M / 2 + N / 2 * Math.Cos(modelParameters.ArmAngle + Math.PI / 2))));
                TSG.Point C1 = new TSG.Point(b2);

                C1.Translate(this.Mult * (-PlateThickness * (0.5)), -98.5 - M / 2, this.Mult * -(300 - M / 2 / Math.Tan(Alpha))); // Bottom of sup plate.
                b2.Translate(this.Mult * (-PlateThickness * (0.5)), -98.5 - M / 2, this.Mult * (M / 2 / Math.Tan(Alpha))); // Top corner of sup plate.
                List<TSG.Point> leftSupPlate = SupPlatePoints(C1, b2);

                b2.Translate(this.Mult * (BeamWidth + PlateThickness), 0, 0);
                C1.Translate(this.Mult * (BeamWidth + PlateThickness), 0, 0);
                List<TSG.Point> rightSupPlate = SupPlatePoints(C1, b2);

                this.SupPlateLeft = new Plate(leftSupPlate, modelParameters.CamPlateProfile,
                    modelParameters.CamPlateMaterial);
                this.SupPlateRight = new Plate(rightSupPlate, modelParameters.CamPlateProfile,
                    modelParameters.CamPlateMaterial);


                // These are the extra support plates that will be needed
                TSG.Point leftSide = new TSG.Point(b1);
                leftSide.Translate(this.Mult * -PlateThickness / 2, -100, 0);
                TSG.Point rightSide = new TSG.Point(leftSide);
                rightSide.Translate(this.Mult * (BeamWidth + PlateThickness), 0, 0);

                List<TSG.Point> leftExtraSupPlate = ExtraSupPlatePoints(leftSide);
                List<TSG.Point> rightExtraSupPlate = ExtraSupPlatePoints(rightSide);
                this.ExtraSupPlateLeft = new Plate(leftExtraSupPlate, modelParameters.CamPlateProfile,
                    modelParameters.CamPlateMaterial);
                this.ExtraSupPlateRight = new Plate(rightExtraSupPlate, modelParameters.CamPlateProfile,
                    modelParameters.CamPlateMaterial);

            }
            else
            {
                b1.Translate(this.Mult * (-PlateThickness) * (0.5), 0.5 - M / 2 + modelParameters.WeldOffset, 0); // Bottom of sup plate.
                b2.Translate(this.Mult * (-PlateThickness) * (0.5), 0.5 - M / 2 + modelParameters.WeldOffset, this.Mult * M / 2 / Math.Tan(Alpha)); // Top corner of sup plate.
                List<TSG.Point> leftSupPlate = SupPlatePoints(b1, b2);
                b1.Translate(this.Mult * (+BeamWidth + PlateThickness), 0, 0);
                b2.Translate(this.Mult * (+BeamWidth + PlateThickness), 0, 0);
                List<TSG.Point> rightSupPlate = SupPlatePoints(b1, b2);

                this.SupPlateLeft = new Plate(leftSupPlate, modelParameters.CamPlateProfile,
                    modelParameters.CamPlateMaterial);
                this.SupPlateRight = new Plate(rightSupPlate, modelParameters.CamPlateProfile,
                    modelParameters.CamPlateMaterial);

            }

            // Creates the Base Plate
            List<TSG.Point> basePoints;

            // Creates the second Base Plate
            List<TSG.Point> basePoints2;

            if (modelParameters.Radius > 0)
            {
                if (this.Mult == 1)
                {
                    basePoints = BasePlatePoints(new TSG.Point(modelParameters.ArmOffset, (112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10) + CameraDistanceEdit(), Height));
                    basePoints2 = BasePlatePoints(new TSG.Point(modelParameters.ArmOffset, (112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10) + CameraDistanceEdit(), Height - 10));
                }
                else
                {
                    basePoints = BasePlatePoints(new TSG.Point(modelParameters.ArmOffset, (112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10) + CameraDistanceEdit(), Height - 10));
                    basePoints2 = BasePlatePoints(new TSG.Point(modelParameters.ArmOffset, (112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10) + CameraDistanceEdit(), Height));
                }

                this.BasePlateUpper = new Plate(basePoints, modelParameters.CamPlateProfile, modelParameters.CamPlateMaterial);
                this.BasePlateLower = new Plate(basePoints2, modelParameters.CamPlateProfile, modelParameters.CamPlateMaterial);

            }
            else {
                if (this.Mult == 1)
                {
                    basePoints = BasePlatePoints(new TSG.Point(modelParameters.ArmOffset, 112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10, Height));
                    basePoints2 = BasePlatePoints(new TSG.Point(modelParameters.ArmOffset, 112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10, Height - 10));
                }
                else
                {
                    basePoints = BasePlatePoints(new TSG.Point(modelParameters.ArmOffset, 112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10, Height - 10));
                    basePoints2 = BasePlatePoints(new TSG.Point(modelParameters.ArmOffset, 112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10, Height));
                }

                this.BasePlateUpper = new Plate(basePoints, modelParameters.CamPlateProfile, modelParameters.CamPlateMaterial);
                this.BasePlateLower = new Plate(basePoints2, modelParameters.CamPlateProfile, modelParameters.CamPlateMaterial);
            }

            // Creates the Camera Plate
            List<TSG.Point> CamPlatePoints = CameraPlatePoints(b3);
            Plate cp = new Plate(CamPlatePoints, modelParameters.CamPlateProfile, modelParameters.CamPlateMaterial, Position.DepthEnum.FRONT);


            // Create 4 bolts with washer 3, nuts 1 for each point on the base plates
            for (int i = 0; i < 4; i++)
            {
                double x, y;
                double z = Height;
                if (modelParameters.Radius > 0)
                {

                    if (i == 0)
                    {
                        x = modelParameters.ArmOffset + 70;
                        y = 82.5 + 97 + modelParameters.B1BeamWidth - 10 + modelParameters.WeldOffset + CameraDistanceEdit();
                    }
                    else if (i == 1)
                    {
                        x = modelParameters.ArmOffset + 70;
                        y = -82.5 + 122 + modelParameters.B1BeamWidth - 10 + modelParameters.WeldOffset + CameraDistanceEdit();

                    }
                    else if (i == 2)
                    {
                        x = modelParameters.ArmOffset - 70;
                        y = 82.5 + 97 + modelParameters.B1BeamWidth - 10 + modelParameters.WeldOffset + CameraDistanceEdit();

                    }
                    else
                    {
                        x = modelParameters.ArmOffset - 70;
                        y = -82.5 + 122 + modelParameters.B1BeamWidth - 10 + modelParameters.WeldOffset + CameraDistanceEdit();

                    }
                }
                else {
                    if (i == 0)
                    {
                        x = modelParameters.ArmOffset + 70;
                        y = 82.5 + 97 + modelParameters.B1BeamWidth - 10 + modelParameters.WeldOffset;
                    }
                    else if (i == 1)
                    {
                        x = modelParameters.ArmOffset + 70;
                        y = -82.5 + 122 + modelParameters.B1BeamWidth - 10 + modelParameters.WeldOffset;

                    }
                    else if (i == 2)
                    {
                        x = modelParameters.ArmOffset - 70;
                        y = 82.5 + 97 + modelParameters.B1BeamWidth - 10 + modelParameters.WeldOffset;

                    }
                    else
                    {
                        x = modelParameters.ArmOffset - 70;
                        y = -82.5 + 122 + modelParameters.B1BeamWidth - 10 + modelParameters.WeldOffset;

                    }
                }
                BoltArray bolt = new BoltArray
                {
                    Bolt = true,
                    BoltSize = 16.0,
                    BoltStandard = modelParameters.BracketBoltStandard,
                    CutLength = 250,
                    FirstPosition = new TSG.Point(x, y, z),
                    SecondPosition = new TSG.Point(x, y, z) + new TSG.Point(30, 0),
                    PartToBoltTo = this.BasePlateLower.ContourPlate,
                    PartToBeBolted = this.BasePlateUpper.ContourPlate,
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

                if (this.Mult == -1) { bolt.Position.RotationOffset = 180; }

                // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)
                bolt.AddBoltDistY(0);

                // Add the distance between two bolts (set to 0 because we want one)
                bolt.AddBoltDistX(0);

                // Insert bolts
                if (!bolt.Insert()) { MessageBox.Show("Insertion of bolt failed."); }
            }

            //Single hole for wire both plates
            if (modelParameters.Radius > 0)
            {
                BoltArray hole1 = new BoltArray
                {
                    Bolt = false,
                    BoltSize = 40.0,
                    BoltStandard = modelParameters.BracketBoltStandard,
                    CutLength = 250,
                    FirstPosition = new TSG.Point(modelParameters.ArmOffset, 112.5 + CameraDistanceEdit() + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10, Height),
                    SecondPosition = new TSG.Point(modelParameters.ArmOffset, 112.5 + CameraDistanceEdit() + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10, Height) + new TSG.Point(30, 0),
                    PartToBoltTo = this.BasePlateLower.ContourPlate,
                    PartToBeBolted = this.BasePlateUpper.ContourPlate,
                    ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                };

                // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)
                hole1.AddBoltDistY(0);

                // Add the distance between two bolts (set to 0 because we want one)
                hole1.AddBoltDistX(0);

                // Insert bolts
                if (!hole1.Insert()) { MessageBox.Show("Insertion of bolt failed."); }
            }
            else
            { //Single hole for wire both plates
                BoltArray hole1 = new BoltArray
                {
                    Bolt = false,
                    BoltSize = 40.0,
                    BoltStandard = modelParameters.BracketBoltStandard,
                    CutLength = 250,
                    FirstPosition = new TSG.Point(modelParameters.ArmOffset, 112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10, Height),
                    SecondPosition = new TSG.Point(modelParameters.ArmOffset, 112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10, Height) + new TSG.Point(30, 0),
                    PartToBoltTo = this.BasePlateLower.ContourPlate,
                    PartToBeBolted = this.BasePlateUpper.ContourPlate,
                    ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                };

                // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)
                hole1.AddBoltDistY(0);

                // Add the distance between two bolts (set to 0 because we want one)
                hole1.AddBoltDistX(0);

                // Insert bolts
                if (!hole1.Insert()) { MessageBox.Show("Insertion of bolt failed."); }
            }

            for (int i = 0; i < 6; i++)
            {
                double x = 0, y = 0, z = 0;
                double theta = modelParameters.ArmAngle;

                // a
                if (i == 0)
                {
                    x = modelParameters.ArmOffset + 40;
                    y = b3.Y;
                    z = b3.Z - this.Mult * 140 - 40 * this.Mult * Math.Sin(theta);
                }

                // b
                else if (i == 1)
                {
                    x = modelParameters.ArmOffset - 40;
                    y = b3.Y;
                    z = b3.Z - this.Mult * 140 - 40 * this.Mult * Math.Sin(theta);
                }

                // c
                else if (i == 2)
                {
                    x = modelParameters.ArmOffset + 40;
                    y = b3.Y;
                    z = b3.Z - this.Mult * 60 - 40 * this.Mult * Math.Sin(theta);
                }

                // d
                else if (i == 3)
                {
                    x = modelParameters.ArmOffset - 40;
                    y = b3.Y;
                    z = b3.Z - this.Mult * 60 - 40 * this.Mult * Math.Sin(theta);
                }

                // e
                else if (i == 4)
                {
                    x = modelParameters.ArmOffset;
                    y = b3.Y;
                    z = b3.Z - this.Mult * 100 - 40 * this.Mult * Math.Sin(theta);
                }
                else
                {
                    x = modelParameters.ArmOffset;
                    y = b3.Y;
                    z = b3.Z - this.Mult * -12 - 40 * this.Mult * Math.Sin(theta);
                }

                BoltArray hole = new BoltArray
                {
                    Bolt = false,
                    BoltSize = 8.0,
                    BoltStandard = modelParameters.BracketBoltStandard,
                    CutLength = 250,
                    FirstPosition = new TSG.Point(x, y, z),
                    SecondPosition = new TSG.Point(x, y, z) + new TSG.Point(0, 1000 * Math.Sin(this.Mult * theta), 1000 * Math.Cos(this.Mult * theta)),
                    PartToBoltTo = cp.ContourPlate,
                    PartToBeBolted = cp.ContourPlate,
                    ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                };

                // bug in the API causes SecondPosition to be interpreted incorrectly when it approaches (0, 0, 1). From testing, this occurs when theta < 1.4325 degrees
                hole.Position.Rotation = theta > 1.4325 * Math.PI / 180 ? Position.RotationEnum.FRONT : Position.RotationEnum.TOP;
                hole.Washer1 = false;
                hole.Washer2 = false;
                hole.Washer3 = false;
                hole.Nut1 = false;
                hole.Nut2 = false;

                hole.Hole1 = false;
                hole.Hole2 = false;
                hole.Hole3 = false;
                hole.Hole4 = false;
                hole.Hole5 = false;

                if (i == 4)
                {
                    hole.BoltSize = 20.0;
                }
                else if (i == 5)
                {
                    hole.BoltSize = 40.0;
                }

                // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)
                hole.AddBoltDistY(0);

                // Add the distance between two bolts (set to 0 because we want one)
                hole.AddBoltDistX(0);

                // Insert bolts
                if (!hole.Insert()) { MessageBox.Show("Insertion of bolt failed."); }
            }

        }



        /// <summary>
        /// Creates a the arm component of the camera arm, which is a poly beam
        /// </summary>
        /// <returns>It returns three TSG points to be used for other aspects</returns>
        private (TSG.Point b1, TSG.Point b2, TSG.Point b3) CreatePolyBeam()
        {
            int mod = this.Mult == -1 ? 10 : 0;
            if (modelParameters.Radius > 0)
            {
                TSG.Point b1 = new TSG.Point(
                         modelParameters.ArmOffset - this.Mult * (BeamWidth * (0.5)),
                         (112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10) + CameraDistanceEdit(),
                         Height - mod
                         );
                ContourPoint a1 = new ContourPoint(b1, null);

                TSG.Point b2 = new TSG.Point(
                        modelParameters.ArmOffset - this.Mult * (BeamWidth * (0.5)),
                        (112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10) + CameraDistanceEdit(),
                        Height + this.Mult * modelParameters.VertArmLength - mod
                        );
                ContourPoint a2 = new ContourPoint(b2, null);

                TSG.Point b3 = new TSG.Point(
                        modelParameters.ArmOffset - this.Mult * (BeamWidth * (0.5)),
                        (112.5 + modelParameters.B1BeamWidth - 1 * (modelParameters.SetArmLength * Math.Cos(modelParameters.ArmAngle)) - BeamThicccness * 0.5 - 10) + CameraDistanceEdit(),
                        Height + this.Mult * (modelParameters.VertArmLength + modelParameters.SetArmLength * Math.Sin(modelParameters.ArmAngle) - mod)
                        );
                ContourPoint a3 = new ContourPoint(b3, null);

                int[] cameraarmEnums = new int[] { 2, 0, 2 };
                int[] cameraarmEnums2 = new int[] { 3, 2, 0 };
                double[] cameraarmOffsets = new double[] { 0.0, 0.0, 90 };

                Prefix.name = "CAMERA ARM";
                Beam CameraArm1 = Box.CreateBeam(Prefix.part, "W",
                        b1, b2,
                        Material,
                        Profile,
                        "1",
                        cameraarmEnums2,
                        cameraarmOffsets
                        );
                Beam CameraArm2 = Box.CreateBeam(Prefix.part, "W",
                        b2, b3,
                        Material,
                        Profile,
                        "1",
                        cameraarmEnums,
                        cameraarmOffsets
                        );

                Prefix.name = "BEAM";

                MitreJoin(CameraArm2, CameraArm1);
                return (b1, b2, b3);
            }
            else {
                TSG.Point b1 = new TSG.Point(
                     modelParameters.ArmOffset - this.Mult * (BeamWidth * (0.5)),
                     112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10,
                     Height - mod
                     );
                ContourPoint a1 = new ContourPoint(b1, null);

                TSG.Point b2 = new TSG.Point(
                        modelParameters.ArmOffset - this.Mult * (BeamWidth * (0.5)),
                        112.5 + modelParameters.B1BeamWidth - BeamThicccness * 0.5 - 10,
                        Height + this.Mult * modelParameters.VertArmLength - mod
                        );
                ContourPoint a2 = new ContourPoint(b2, null);

                TSG.Point b3 = new TSG.Point(
                        modelParameters.ArmOffset - this.Mult * (BeamWidth * (0.5)),
                        112.5 + modelParameters.B1BeamWidth - 1 * (modelParameters.SetArmLength * Math.Cos(modelParameters.ArmAngle)) - BeamThicccness * 0.5 - 10,
                        Height + this.Mult * (modelParameters.VertArmLength + modelParameters.SetArmLength * Math.Sin(modelParameters.ArmAngle) - mod)
                        );
                ContourPoint a3 = new ContourPoint(b3, null);

                int[] cameraarmEnums = new int[] { 2, 0, 2 };
                int[] cameraarmEnums2 = new int[] { 3, 2, 0 };
                double[] cameraarmOffsets = new double[] { 0.0, 0.0, 90 };

                Prefix.name = "CAMERA ARM";
                Beam CameraArm1 = Box.CreateBeam(Prefix.part, "W",
                        b1, b2,
                        Material,
                        Profile,
                        "1",
                        cameraarmEnums2,
                        cameraarmOffsets
                        );
                Beam CameraArm2 = Box.CreateBeam(Prefix.part, "W",
                        b2, b3,
                        Material,
                        Profile,
                        "1",
                        cameraarmEnums,
                        cameraarmOffsets
                        );

                Prefix.name = "BEAM";

                MitreJoin(CameraArm2, CameraArm1);
                return (b1, b2, b3);
            }
            
        }

        /// <summary>
        ///  Creates the Supporting plates on either side of the PolyBeam (Camera Arm).
        /// </summary>
        /// <param name="b1"> A reference point created in the poly beam</param>
        /// <param name="b2"> Another reference point created in the poly bea</param>
        /// <returns>Returns a list of points used for the support plate</returns>
        private List<TSG.Point> SupPlatePoints(TSG.Point b1, TSG.Point b2)
        {
            List<TSG.Point> points = new List<TSG.Point> { };

            TSG.Point P1 = new TSG.Point(b1);
            P1.Translate(0, 121.5 + BeamWidth + BeamThicccness * 0.5, 0);

            TSG.Point P2 = new TSG.Point(b2);
            P2.Translate(0, 121.5 + BeamWidth + BeamThicccness * 0.5, 0);

            TSG.Point P3 = new TSG.Point(P2);
            P3.Translate(0, -300 * Math.Cos(modelParameters.ArmAngle), this.Mult * (300 * Math.Sin(modelParameters.ArmAngle)));
            TSG.Point P4 = new TSG.Point(P3);
            P4.Translate(0, -N * Math.Sin(modelParameters.ArmAngle), this.Mult * (-N * Math.Cos(modelParameters.ArmAngle)));
            TSG.Point P5 = new TSG.Point(P1);
            P5.Translate(0, -M, 0);

            points.Add(P1);
            points.Add(P2);
            points.Add(P3);
            points.Add(P4);
            points.Add(P5);

            return points;
        }

        /// <summary>
        /// Creates the base plate points
        /// </summary>
        /// <param name="origin"> A reference point to offset the position of the plate</param>
        /// <returns>Returns a list of points used for the base plate</returns>
        private List<TSG.Point> BasePlatePoints(TSG.Point origin)
        {
            List<TSG.Point> points = new List<TSG.Point> { };

            origin.Translate(0, 0, this.Mult * -PlateThickness / 2);

            TSG.Point P1 = new TSG.Point(origin);
            P1.Translate(100, 100, 0);
            TSG.Point P2 = new TSG.Point(P1);
            P2.Translate(-200, 0, 0);
            TSG.Point P3 = new TSG.Point(P2);
            P3.Translate(0, -200, 0);
            TSG.Point P4 = new TSG.Point(P3);
            P4.Translate(200, 0, 0);

            points.Add(P1);
            points.Add(P2);
            points.Add(P3);
            points.Add(P4);

            return points;
        }

        /// <summary>
        /// Creates the camera plate points
        /// </summary>
        /// <param name="origin">A reference point to offset the position of the plate</param>
        /// <returns>Returns a list of points used for the camera plate</returns>
        private List<TSG.Point> CameraPlatePoints(TSG.Point origin)
        {
            origin.Translate(0, PlateThickness / 2 * Math.Cos(modelParameters.ArmAngle) + BeamWidth * Math.Sin(modelParameters.ArmAngle), this.Mult * (PlateThickness / 2 * Math.Sin(modelParameters.ArmAngle)));

            List<TSG.Point> points = new List<TSG.Point> { };

            TSG.Point P1 = new TSG.Point(origin);
            P1.Translate(-75 + this.Mult * BeamWidth / 2, -BeamWidth / 2 * Math.Cos(Beta), this.Mult * (BeamWidth / 2 * Math.Sin(Beta)));
            TSG.Point P2 = new TSG.Point(P1);
            P2.Translate(150, 0, 0);
            TSG.Point P3 = new TSG.Point(P2);
            P3.Translate(0, -210 * Math.Cos(Beta), this.Mult * (-210 * Math.Sin(Beta)));
            TSG.Point P4 = new TSG.Point(P3);
            P4.Translate(-150, 0, 0);

            points.Add(P1);
            points.Add(P2);
            points.Add(P3);
            points.Add(P4);

            return points;
        }

        /// <summary>
        /// Creates additional support plates
        /// </summary>
        /// <param name="origin">A reference point to offset the position of the plate</param>
        /// <returns>Returns a list of points used for the extra support plate</returns>
        private List<TSG.Point> ExtraSupPlatePoints(TSG.Point origin)
        {
            List<TSG.Point> points = new List<TSG.Point> { };

            TSG.Point P1 = new TSG.Point(origin);
            TSG.Point P2 = new TSG.Point(P1);
            P2.Translate(0, 0, this.Mult * 100);
            TSG.Point P3 = new TSG.Point(P2);
            P3.Translate(0, 200, 0);
            TSG.Point P4 = new TSG.Point(P3);
            P4.Translate(0, 0, this.Mult * -100);

            points.Add(P1);
            points.Add(P2);
            points.Add(P3);
            points.Add(P4);

            return points;
        }
        private static void MitreJoin(ModelObject PrimaryObject, ModelObject SecondaryObject)
        {
            Connection CrankedBeam = new Connection();

            CrankedBeam.Name = "Cranked beam";
            CrankedBeam.Number = 41;
            CrankedBeam.LoadAttributesFromFile("standard");
            CrankedBeam.UpVector = new TSG.Vector(0, 0, 1000);
            CrankedBeam.PositionType = PositionTypeEnum.COLLISION_PLANE;

            CrankedBeam.SetPrimaryObject(PrimaryObject);
            CrankedBeam.SetSecondaryObject(SecondaryObject);
            // CrankedBeam.SetAttribute("cut", 1);  //Enable anchor rods

            if (!CrankedBeam.Insert())
            {
                Console.WriteLine("Insertion of stiffened base plate failed.");
            }

        }

        /// <summary>
        /// A function to calculate the adjestments for the camera arm distance for a curve Bill Board
        /// </summary>
        /// <returns>a double indicating the change in y coordinate for the camera arm</returns>
        private double CameraDistanceEdit()
        {
            // Basic Parameters
            double Radius = modelParameters.Radius;
            double Width = modelParameters.ScreenLength;
            double B1BeamDepth = modelParameters.B1BeamDepth;

            // When the BillBoard is Straight no changes in Ycoord required
            if (Radius == 0)
            {
                return 0;
            }
            else
            {
                double Ycoord_Change = -Math.Abs(-(Radius - B1BeamDepth) + Math.Sqrt(Math.Pow(Radius, 2) - (Math.Pow(Width, 2) / 4)) - B1BeamDepth);
                return Ycoord_Change;
            }
        }

    }
}