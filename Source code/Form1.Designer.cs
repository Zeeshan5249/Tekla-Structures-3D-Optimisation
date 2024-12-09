using System;
using System.Text.RegularExpressions;

namespace TeklaBillboardAid
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.PictureBox pictureBox1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ledCabinets = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.CabinetHeightLabel = new System.Windows.Forms.Label();
            this.CabinetLengthLabel = new System.Windows.Forms.Label();
            this.CabinetHeightSumLabel = new System.Windows.Forms.Label();
            this.CabinetLengthSumLabel = new System.Windows.Forms.Label();
            this.CabinetControl = new System.Windows.Forms.TabControl();
            this.CabinetAddTab = new System.Windows.Forms.TabPage();
            this.Radius_Text = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.AddSplit = new System.Windows.Forms.Button();
            this.ColumnAddRadioButton = new System.Windows.Forms.RadioButton();
            this.RowAddRadioButton = new System.Windows.Forms.RadioButton();
            this.cabinetAddValue = new System.Windows.Forms.TextBox();
            this.cabinetValueAddButton = new System.Windows.Forms.Button();
            this.CabinetEditTab = new System.Windows.Forms.TabPage();
            this.EditRemoveSplit = new System.Windows.Forms.Button();
            this.CabinetResetButton = new System.Windows.Forms.Button();
            this.ColumnEditRadioButton = new System.Windows.Forms.RadioButton();
            this.RowEditRadioButton = new System.Windows.Forms.RadioButton();
            this.CabinetRemoveButton = new System.Windows.Forms.Button();
            this.CabinetEditValue = new System.Windows.Forms.TextBox();
            this.CabinetEditButton = new System.Windows.Forms.Button();
            this.columnSumLabel = new System.Windows.Forms.Label();
            this.columnLabel = new System.Windows.Forms.Label();
            this.rowSumLabel = new System.Windows.Forms.Label();
            this.rowLabel = new System.Windows.Forms.Label();
            this.columnList = new System.Windows.Forms.ListBox();
            this.rowList = new System.Windows.Forms.ListBox();
            this.MaterialAndProfile = new System.Windows.Forms.GroupBox();
            this.profileCatalog1 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Waler = new System.Windows.Forms.Label();
            this.B5Profile = new System.Windows.Forms.TextBox();
            this.B2Profile = new System.Windows.Forms.TextBox();
            this.B2Material = new System.Windows.Forms.TextBox();
            this.B5Material = new System.Windows.Forms.TextBox();
            this.B1Profile = new System.Windows.Forms.TextBox();
            this.B1Material = new System.Windows.Forms.TextBox();
            this.BR1Profile = new System.Windows.Forms.TextBox();
            this.BR1Material = new System.Windows.Forms.TextBox();
            this.BR1 = new System.Windows.Forms.Label();
            this.C1Profile = new System.Windows.Forms.TextBox();
            this.LEDProfile = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.B5 = new System.Windows.Forms.Label();
            this.B2 = new System.Windows.Forms.Label();
            this.LED = new System.Windows.Forms.Label();
            this.C1 = new System.Windows.Forms.Label();
            this.B1 = new System.Windows.Forms.Label();
            this.LEDMaterial = new System.Windows.Forms.TextBox();
            this.C1Material = new System.Windows.Forms.TextBox();
            this.B3 = new System.Windows.Forms.Label();
            this.B3Material = new System.Windows.Forms.TextBox();
            this.B3Profile = new System.Windows.Forms.TextBox();
            this.WalerMaterial = new System.Windows.Forms.TextBox();
            this.WalerProfile = new System.Windows.Forms.TextBox();
            this.SeatingPlate = new System.Windows.Forms.Label();
            this.SeatingPlateMaterial = new System.Windows.Forms.TextBox();
            this.SeatingPlateProfile = new System.Windows.Forms.TextBox();
            this.EAMaterial = new System.Windows.Forms.TextBox();
            this.EAProfile = new System.Windows.Forms.TextBox();
            this.EASupport = new System.Windows.Forms.Label();
            this.ZBracketLabel = new System.Windows.Forms.Label();
            this.ZBracketMaterial = new System.Windows.Forms.TextBox();
            this.ZBracketProfile = new System.Windows.Forms.TextBox();
            this.profileCatalog2 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.profileCatalog3 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.profileCatalog4 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.profileCatalog5 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.profileCatalog6 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.profileCatalog7 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.profileCatalog8 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.profileCatalog9 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.BillboardDimensions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.BillBoardHeight = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BillBoardLength = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.HeightOffsetBottom = new System.Windows.Forms.TextBox();
            this.HeightOffsetTop = new System.Windows.Forms.TextBox();
            this.BillBoardDepth = new System.Windows.Forms.Label();
            this.BillboardWeight = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.BoltDiameter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HoleHorizontalOffset = new System.Windows.Forms.TextBox();
            this.HoleVerticalOffset = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.Welding = new System.Windows.Forms.TextBox();
            this.MeshThickLabel = new System.Windows.Forms.Label();
            this.MeshThickness = new System.Windows.Forms.TextBox();
            this.RailingSpace2 = new System.Windows.Forms.TextBox();
            this.RailingSpace1 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.LowerWalerSpacing = new System.Windows.Forms.TextBox();
            this.UpperWalerSpacing = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.WalerNumberLabel = new System.Windows.Forms.Label();
            this.WalerManualRadio = new System.Windows.Forms.RadioButton();
            this.WalerAddValue = new System.Windows.Forms.TextBox();
            this.WalerAddButton = new System.Windows.Forms.Button();
            this.WalerAutoRadio = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.WalerResetButton = new System.Windows.Forms.Button();
            this.WalerRemoveButton = new System.Windows.Forms.Button();
            this.WalerEditValue = new System.Windows.Forms.TextBox();
            this.WalerEditButton = new System.Windows.Forms.Button();
            this.WalersSumLabel = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.WalersList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.label23 = new System.Windows.Forms.Label();
            this.CornerOffset = new System.Windows.Forms.TextBox();
            this.CornerOffsetLabel = new System.Windows.Forms.Label();
            this.TopOffsetLabel = new System.Windows.Forms.Label();
            this.DiagonalBottomOffset = new System.Windows.Forms.TextBox();
            this.DiagonalTopOffset = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label21 = new System.Windows.Forms.Label();
            this.StructureControl = new System.Windows.Forms.TabControl();
            this.StructureAddTab = new System.Windows.Forms.TabPage();
            this.StructureManualRadio = new System.Windows.Forms.RadioButton();
            this.HorizontalBeamsAddValue = new System.Windows.Forms.TextBox();
            this.HorizontalBeamsAddButton = new System.Windows.Forms.Button();
            this.StructureAutoRadio = new System.Windows.Forms.RadioButton();
            this.StructureEditTab = new System.Windows.Forms.TabPage();
            this.HorizontalBeamsResetButton = new System.Windows.Forms.Button();
            this.HorizontalBeamsRemoveButton = new System.Windows.Forms.Button();
            this.HorizontalBeamsEditValue = new System.Windows.Forms.TextBox();
            this.HorizontalBeamsEditButton = new System.Windows.Forms.Button();
            this.BeamsSumLabel = new System.Windows.Forms.Label();
            this.BeamsLabel = new System.Windows.Forms.Label();
            this.HorizontalBeamsList = new System.Windows.Forms.ListBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.ZBracketHoleDiameter = new System.Windows.Forms.Label();
            this.BracketBoltDiameter = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.BracketBoltStandard = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.BracketHoleDiameter = new System.Windows.Forms.TextBox();
            this.SeatingPlateOffButton = new System.Windows.Forms.RadioButton();
            this.SeatingPlateOnButton = new System.Windows.Forms.RadioButton();
            this.SeatingPlateOffset = new System.Windows.Forms.TextBox();
            this.ExtrusionLength = new System.Windows.Forms.TextBox();
            this.seatingplateextrusionlengthLabel = new System.Windows.Forms.Label();
            this.SeatingplateoffsetLabel = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.WalkwayWidth = new System.Windows.Forms.ComboBox();
            this.WalkwayMaterial = new System.Windows.Forms.TextBox();
            this.MeshMaterialLabel = new System.Windows.Forms.Label();
            this.WalkwayWidthLabel = new System.Windows.Forms.Label();
            this.WalkwayClearanceLabel = new System.Windows.Forms.Label();
            this.EAclearanceLabel = new System.Windows.Forms.Label();
            this.WalkwayClearance = new System.Windows.Forms.TextBox();
            this.EAClearance = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.SpacerPlateSwitch = new System.Windows.Forms.CheckBox();
            this.BracketSpacerThickness = new System.Windows.Forms.TextBox();
            this.BracketSpacer = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.ZbracketEndSpacing = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.ZbracketSpacingA = new System.Windows.Forms.TextBox();
            this.ZbracketSpacingALabel = new System.Windows.Forms.Label();
            this.ZbracketSpacingB = new System.Windows.Forms.TextBox();
            this.ZbracketSpacingBLabel = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.RailingInfo = new System.Windows.Forms.GroupBox();
            this.TrimmerBox = new System.Windows.Forms.TextBox();
            this.HandRailingBox = new System.Windows.Forms.TextBox();
            this.KneeRailingBox = new System.Windows.Forms.TextBox();
            this.KneeRail = new System.Windows.Forms.Label();
            this.HandRail = new System.Windows.Forms.Label();
            this.Trimmer = new System.Windows.Forms.Label();
            this.ScreenProfile = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.LEDThickness = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LEDDensity = new System.Windows.Forms.TextBox();
            this.LEDWidthlable = new System.Windows.Forms.Label();
            this.LEDWidth = new System.Windows.Forms.TextBox();
            this.LEDHeight = new System.Windows.Forms.TextBox();
            this.LEDHeightLable = new System.Windows.Forms.Label();
            this.LEDWeightLable = new System.Windows.Forms.Label();
            this.LEDWeight = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.profileCatalog13 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.EACabinetBoltHoleSize = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.EASplitBoltOffset = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.B5SplitBeamProfile = new System.Windows.Forms.TextBox();
            this.B2SplitBeamProfile = new System.Windows.Forms.TextBox();
            this.B2SplitBeamMaterial = new System.Windows.Forms.TextBox();
            this.B5SplitBeamMaterial = new System.Windows.Forms.TextBox();
            this.B1SplitBeamProfile = new System.Windows.Forms.TextBox();
            this.B1SplitBeamMaterial = new System.Windows.Forms.TextBox();
            this.C1SplitBeamProfile = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.B5Split = new System.Windows.Forms.Label();
            this.B2Split = new System.Windows.Forms.Label();
            this.C1Split = new System.Windows.Forms.Label();
            this.B1Split = new System.Windows.Forms.Label();
            this.C1SplitBeamMaterial = new System.Windows.Forms.TextBox();
            this.profileCatalog10 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.profileCatalog11 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.profileCatalog12 = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.galDepth = new System.Windows.Forms.Label();
            this.galWidth = new System.Windows.Forms.Label();
            this.galLength = new System.Windows.Forms.Label();
            this.galDepthLabel = new System.Windows.Forms.Label();
            this.galWidthLabel = new System.Windows.Forms.Label();
            this.galLengthLabel = new System.Windows.Forms.Label();
            this.galLocSelect = new System.Windows.Forms.ComboBox();
            this.galLocation = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.RearDoorGroup = new System.Windows.Forms.GroupBox();
            this.DoorFrameBeamSelect = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.DoorPanelBeamSelect = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.DoorPanelProfileText = new System.Windows.Forms.TextBox();
            this.DoorPanelMaterialText = new System.Windows.Forms.TextBox();
            this.DoorFrameProfileText = new System.Windows.Forms.TextBox();
            this.DoorFrameMaterialText = new System.Windows.Forms.TextBox();
            this.DoorProfile = new System.Windows.Forms.Label();
            this.DoorMaterial = new System.Windows.Forms.Label();
            this.DoorPanelBeam = new System.Windows.Forms.Label();
            this.DoorFrameBeam = new System.Windows.Forms.Label();
            this.DoorFramePanelDistance = new System.Windows.Forms.Label();
            this.DoorrMinHeight = new System.Windows.Forms.Label();
            this.DoorPanelFrameDistanceText = new System.Windows.Forms.TextBox();
            this.DoorMinHeightText = new System.Windows.Forms.TextBox();
            this.DoorWidthText = new System.Windows.Forms.TextBox();
            this.DoorWidth = new System.Windows.Forms.Label();
            this.DoorOffsetText = new System.Windows.Forms.TextBox();
            this.DoorOffset = new System.Windows.Forms.Label();
            this.RearDoorEnable = new System.Windows.Forms.CheckBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.LadderBuilder = new System.Windows.Forms.GroupBox();
            this.LadderWidthText = new System.Windows.Forms.TextBox();
            this.LadderWidth = new System.Windows.Forms.Label();
            this.LadderPlateHeightText = new System.Windows.Forms.TextBox();
            this.LadderPlateHeight = new System.Windows.Forms.Label();
            this.LadderRungSpacing = new System.Windows.Forms.Label();
            this.LadderRungSpacingText = new System.Windows.Forms.TextBox();
            this.HatchWidthValue = new System.Windows.Forms.TextBox();
            this.HatchWidthName = new System.Windows.Forms.Label();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.LadderPlateSelect = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.LadderPlateProfileText = new System.Windows.Forms.TextBox();
            this.LadderHatchProfileName = new System.Windows.Forms.Label();
            this.LadderRungProfileText = new System.Windows.Forms.TextBox();
            this.LadderPlate = new System.Windows.Forms.Label();
            this.LadderRungSelect = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.LadderPlateMaterialText = new System.Windows.Forms.TextBox();
            this.LadderHatchMaterialName = new System.Windows.Forms.Label();
            this.LadderRailSelect = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.LadderSideRail = new System.Windows.Forms.Label();
            this.LadderRailProfileText = new System.Windows.Forms.TextBox();
            this.LadderRung = new System.Windows.Forms.Label();
            this.LadderSideRailMaterialText = new System.Windows.Forms.TextBox();
            this.LadderRungMaterialText = new System.Windows.Forms.TextBox();
            this.HatchBeamMaterialName = new System.Windows.Forms.Label();
            this.HatchBeamMaterial = new System.Windows.Forms.TextBox();
            this.HatchBeamProfile = new System.Windows.Forms.TextBox();
            this.HatchBeamProfileSelector = new Tekla.Structures.Dialog.UIControls.ProfileCatalog();
            this.LadderOffsetSideText = new System.Windows.Forms.TextBox();
            this.LadderOffsetfromSide = new System.Windows.Forms.Label();
            this.LadderOffsetBack = new System.Windows.Forms.Label();
            this.LadderOffsetBackText = new System.Windows.Forms.TextBox();
            this.NoLadder = new System.Windows.Forms.RadioButton();
            this.RightLadder = new System.Windows.Forms.RadioButton();
            this.LeftLadder = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ThreeDButton = new System.Windows.Forms.RadioButton();
            this.TwoDButton = new System.Windows.Forms.RadioButton();
            this.enableFascia = new System.Windows.Forms.CheckBox();
            this.fasciaHeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.TopFlashingTab = new System.Windows.Forms.TabPage();
            this.FlashingDimK = new System.Windows.Forms.TextBox();
            this.FlashingDimJ = new System.Windows.Forms.TextBox();
            this.FlashingDimM = new System.Windows.Forms.TextBox();
            this.FlashingDimL = new System.Windows.Forms.TextBox();
            this.FlashingDimC = new System.Windows.Forms.TextBox();
            this.FlashingDimB = new System.Windows.Forms.TextBox();
            this.FlashingDimA = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.BottomFlashingTab = new System.Windows.Forms.TabPage();
            this.FlashingDimR = new System.Windows.Forms.TextBox();
            this.FlashingDimS = new System.Windows.Forms.TextBox();
            this.FlashingDimH = new System.Windows.Forms.TextBox();
            this.FlashingDimI = new System.Windows.Forms.TextBox();
            this.FlashingDimG = new System.Windows.Forms.TextBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.SideFlashingTab = new System.Windows.Forms.TabPage();
            this.FlashingDimO = new System.Windows.Forms.TextBox();
            this.FlashingDimN = new System.Windows.Forms.TextBox();
            this.FlashingDimQ = new System.Windows.Forms.TextBox();
            this.FlashingDimP = new System.Windows.Forms.TextBox();
            this.FlashingDimF = new System.Windows.Forms.TextBox();
            this.FlashingDimE = new System.Windows.Forms.TextBox();
            this.FlashingDimD = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.FlashingsEnabled = new System.Windows.Forms.CheckBox();
            this.ManualFlashDim = new System.Windows.Forms.RadioButton();
            this.AutoFlashDim = new System.Windows.Forms.RadioButton();
            this.FlashingThickness = new System.Windows.Forms.TextBox();
            this.FlashingThicknessLabel = new System.Windows.Forms.Label();
            this.FlashingColour = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.GH_panel = new System.Windows.Forms.GroupBox();
            this.NoGalHole = new System.Windows.Forms.RadioButton();
            this.GH_manualSelector = new System.Windows.Forms.RadioButton();
            this.GH_autoSelector = new System.Windows.Forms.RadioButton();
            this.GH_offset1 = new System.Windows.Forms.TextBox();
            this.GH_holeSize = new System.Windows.Forms.TextBox();
            this.GH_offset2 = new System.Windows.Forms.TextBox();
            this.GH_label_offset1 = new System.Windows.Forms.Label();
            this.GH_label_offset2 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.cameraArm = new System.Windows.Forms.GroupBox();
            this.Cameracentre = new System.Windows.Forms.CheckBox();
            this.noArm = new System.Windows.Forms.RadioButton();
            this.TopArm = new System.Windows.Forms.RadioButton();
            this.BotArm = new System.Windows.Forms.RadioButton();
            this.ArmLeftOffset = new System.Windows.Forms.TextBox();
            this.LeftOffset = new System.Windows.Forms.Label();
            this.ArmLengthBox = new System.Windows.Forms.TextBox();
            this.VertArmLength = new System.Windows.Forms.TextBox();
            this.ArmAngle = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.WW_panel = new System.Windows.Forms.GroupBox();
            this.WW_tabControl = new System.Windows.Forms.TabControl();
            this.WW_tab = new System.Windows.Forms.TabPage();
            this.WW_add_label = new System.Windows.Forms.Label();
            this.WW_box = new System.Windows.Forms.TextBox();
            this.WW_add = new System.Windows.Forms.Button();
            this.WW_tab2 = new System.Windows.Forms.TabPage();
            this.label33 = new System.Windows.Forms.Label();
            this.WW_removeAll = new System.Windows.Forms.Button();
            this.WW_remove = new System.Windows.Forms.Button();
            this.WW_box2 = new System.Windows.Forms.TextBox();
            this.WW_edit = new System.Windows.Forms.Button();
            this.WW_label = new System.Windows.Forms.Label();
            this.WW_list = new System.Windows.Forms.ListBox();
            this.WW_count = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.ManualOpenArea = new System.Windows.Forms.TextBox();
            this.sides = new System.Windows.Forms.Label();
            this.theSide = new System.Windows.Forms.ComboBox();
            this.CladOffset = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenArea = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.CladdingColour = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.Thickness = new System.Windows.Forms.TextBox();
            this.CladLength = new System.Windows.Forms.TextBox();
            this.CladSize = new System.Windows.Forms.ComboBox();
            this.CladSizeLabel = new System.Windows.Forms.Label();
            this.CladProfile = new System.Windows.Forms.ComboBox();
            this.EffectiveWidth = new System.Windows.Forms.Label();
            this.SheetWidth = new System.Windows.Forms.Label();
            this.Overlap = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.TopLPCount = new System.Windows.Forms.Label();
            this.BottomLPCount = new System.Windows.Forms.Label();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.AddLPBoth = new System.Windows.Forms.RadioButton();
            this.AddLPBottom = new System.Windows.Forms.RadioButton();
            this.AddLPTop = new System.Windows.Forms.RadioButton();
            this.AddLPTextBox = new System.Windows.Forms.TextBox();
            this.AddLP = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.ClearLP = new System.Windows.Forms.Button();
            this.RemoveLP = new System.Windows.Forms.Button();
            this.EditLPBottom = new System.Windows.Forms.RadioButton();
            this.EditLPTop = new System.Windows.Forms.RadioButton();
            this.EditLPTextBox = new System.Windows.Forms.TextBox();
            this.EditLP = new System.Windows.Forms.Button();
            this.label49 = new System.Windows.Forms.Label();
            this.topList = new System.Windows.Forms.ListBox();
            this.bottomList = new System.Windows.Forms.ListBox();
            this.label59 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ValidateButton = new System.Windows.Forms.Button();
            this.label58 = new System.Windows.Forms.Label();
            this.GH_count = new System.Windows.Forms.Label();
            this.GH_button = new System.Windows.Forms.Button();
            this.GH_countX = new System.Windows.Forms.Label();
            this.GH_countY = new System.Windows.Forms.Label();
            this.GH_countZ = new System.Windows.Forms.Label();
            this.angelLabel = new System.Windows.Forms.Label();
            this.vertLabel = new System.Windows.Forms.Label();
            this.armOffsetLabel = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.armLengthLabel = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.EditAddSplit = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label41 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.partPrefix = new System.Windows.Forms.TextBox();
            this.assemblyPrefix = new System.Windows.Forms.TextBox();
            this.programBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Curved_Check = new System.Windows.Forms.CheckBox();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.ledCabinets.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.CabinetControl.SuspendLayout();
            this.CabinetAddTab.SuspendLayout();
            this.CabinetEditTab.SuspendLayout();
            this.MaterialAndProfile.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.BillboardDimensions.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.StructureControl.SuspendLayout();
            this.StructureAddTab.SuspendLayout();
            this.StructureEditTab.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.RailingInfo.SuspendLayout();
            this.ScreenProfile.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.RearDoorGroup.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.LadderBuilder.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.TopFlashingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.BottomFlashingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SideFlashingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.GH_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.cameraArm.SuspendLayout();
            this.WW_panel.SuspendLayout();
            this.WW_tabControl.SuspendLayout();
            this.WW_tab.SuspendLayout();
            this.WW_tab2.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.structuresExtender.SetAttributeName(pictureBox1, null);
            this.structuresExtender.SetAttributeTypeName(pictureBox1, null);
            pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.structuresExtender.SetBindPropertyName(pictureBox1, null);
            pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            pictureBox1.Location = new System.Drawing.Point(1293, 44);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(389, 340);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // ledCabinets
            // 
            this.structuresExtender.SetAttributeName(this.ledCabinets, null);
            this.structuresExtender.SetAttributeTypeName(this.ledCabinets, null);
            this.structuresExtender.SetBindPropertyName(this.ledCabinets, null);
            this.ledCabinets.Controls.Add(this.tableLayoutPanel5);
            this.ledCabinets.Controls.Add(this.CabinetControl);
            this.ledCabinets.Controls.Add(this.columnSumLabel);
            this.ledCabinets.Controls.Add(this.columnLabel);
            this.ledCabinets.Controls.Add(this.rowSumLabel);
            this.ledCabinets.Controls.Add(this.rowLabel);
            this.ledCabinets.Controls.Add(this.columnList);
            this.ledCabinets.Controls.Add(this.rowList);
            this.ledCabinets.Location = new System.Drawing.Point(31, 20);
            this.ledCabinets.Margin = new System.Windows.Forms.Padding(4);
            this.ledCabinets.Name = "ledCabinets";
            this.ledCabinets.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ledCabinets.Size = new System.Drawing.Size(485, 294);
            this.ledCabinets.TabIndex = 0;
            this.ledCabinets.TabStop = false;
            this.ledCabinets.Text = "LED Cabinets";
            // 
            // tableLayoutPanel5
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel5, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel5, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel5, null);
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.CabinetHeightLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.CabinetLengthLabel, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.CabinetHeightSumLabel, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.CabinetLengthSumLabel, 1, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(281, 165);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.66667F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.33333F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(204, 82);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // CabinetHeightLabel
            // 
            this.structuresExtender.SetAttributeName(this.CabinetHeightLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetHeightLabel, null);
            this.CabinetHeightLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.CabinetHeightLabel, null);
            this.CabinetHeightLabel.Location = new System.Drawing.Point(4, 0);
            this.CabinetHeightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CabinetHeightLabel.Name = "CabinetHeightLabel";
            this.CabinetHeightLabel.Size = new System.Drawing.Size(125, 16);
            this.CabinetHeightLabel.TabIndex = 1;
            this.CabinetHeightLabel.Text = "Screen Height (mm)";
            // 
            // CabinetLengthLabel
            // 
            this.structuresExtender.SetAttributeName(this.CabinetLengthLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetLengthLabel, null);
            this.CabinetLengthLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.CabinetLengthLabel, null);
            this.CabinetLengthLabel.Location = new System.Drawing.Point(3, 38);
            this.CabinetLengthLabel.Name = "CabinetLengthLabel";
            this.CabinetLengthLabel.Size = new System.Drawing.Size(126, 16);
            this.CabinetLengthLabel.TabIndex = 0;
            this.CabinetLengthLabel.Text = "Screen Length (mm)";
            // 
            // CabinetHeightSumLabel
            // 
            this.structuresExtender.SetAttributeName(this.CabinetHeightSumLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetHeightSumLabel, null);
            this.CabinetHeightSumLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.CabinetHeightSumLabel, null);
            this.CabinetHeightSumLabel.Location = new System.Drawing.Point(136, 0);
            this.CabinetHeightSumLabel.Name = "CabinetHeightSumLabel";
            this.CabinetHeightSumLabel.Size = new System.Drawing.Size(14, 16);
            this.CabinetHeightSumLabel.TabIndex = 3;
            this.CabinetHeightSumLabel.Text = "0";
            // 
            // CabinetLengthSumLabel
            // 
            this.structuresExtender.SetAttributeName(this.CabinetLengthSumLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetLengthSumLabel, null);
            this.CabinetLengthSumLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.CabinetLengthSumLabel, null);
            this.CabinetLengthSumLabel.Location = new System.Drawing.Point(136, 38);
            this.CabinetLengthSumLabel.Name = "CabinetLengthSumLabel";
            this.CabinetLengthSumLabel.Size = new System.Drawing.Size(14, 16);
            this.CabinetLengthSumLabel.TabIndex = 2;
            this.CabinetLengthSumLabel.Text = "0";
            this.CabinetLengthSumLabel.TextChanged += new System.EventHandler(this.screenlength_changed);
            this.CabinetLengthSumLabel.Click += new System.EventHandler(this.CabinetLengthSumLabel_Click);
            // 
            // CabinetControl
            // 
            this.structuresExtender.SetAttributeName(this.CabinetControl, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetControl, null);
            this.structuresExtender.SetBindPropertyName(this.CabinetControl, null);
            this.CabinetControl.Controls.Add(this.CabinetAddTab);
            this.CabinetControl.Controls.Add(this.CabinetEditTab);
            this.CabinetControl.Location = new System.Drawing.Point(8, 25);
            this.CabinetControl.Margin = new System.Windows.Forms.Padding(4);
            this.CabinetControl.Name = "CabinetControl";
            this.CabinetControl.SelectedIndex = 0;
            this.CabinetControl.Size = new System.Drawing.Size(365, 134);
            this.CabinetControl.TabIndex = 0;
            // 
            // CabinetAddTab
            // 
            this.structuresExtender.SetAttributeName(this.CabinetAddTab, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetAddTab, null);
            this.structuresExtender.SetBindPropertyName(this.CabinetAddTab, null);
            this.CabinetAddTab.Controls.Add(this.Curved_Check);
            this.CabinetAddTab.Controls.Add(this.Radius_Text);
            this.CabinetAddTab.Controls.Add(this.label45);
            this.CabinetAddTab.Controls.Add(this.AddSplit);
            this.CabinetAddTab.Controls.Add(this.ColumnAddRadioButton);
            this.CabinetAddTab.Controls.Add(this.RowAddRadioButton);
            this.CabinetAddTab.Controls.Add(this.cabinetAddValue);
            this.CabinetAddTab.Controls.Add(this.cabinetValueAddButton);
            this.CabinetAddTab.Location = new System.Drawing.Point(4, 25);
            this.CabinetAddTab.Margin = new System.Windows.Forms.Padding(4);
            this.CabinetAddTab.Name = "CabinetAddTab";
            this.CabinetAddTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CabinetAddTab.Size = new System.Drawing.Size(357, 105);
            this.CabinetAddTab.TabIndex = 0;
            this.CabinetAddTab.Text = "Add";
            this.CabinetAddTab.UseVisualStyleBackColor = true;
            // 
            // Radius_Text
            // 
            this.structuresExtender.SetAttributeName(this.Radius_Text, null);
            this.structuresExtender.SetAttributeTypeName(this.Radius_Text, null);
            this.structuresExtender.SetBindPropertyName(this.Radius_Text, null);
            this.Radius_Text.Location = new System.Drawing.Point(277, 58);
            this.Radius_Text.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Radius_Text.Name = "Radius_Text";
            this.Radius_Text.Size = new System.Drawing.Size(68, 22);
            this.Radius_Text.TabIndex = 13;
            this.Radius_Text.Text = "0";
            this.Radius_Text.Enabled = false;
            this.Radius_Text.TextChanged += new System.EventHandler(this.Radius_TextChanged);
            this.Radius_Text.Validating += new System.ComponentModel.CancelEventHandler(this.Radius_Validating);
            // 
            // label45
            // 
            this.structuresExtender.SetAttributeName(this.label45, null);
            this.structuresExtender.SetAttributeTypeName(this.label45, null);
            this.label45.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label45, null);
            this.label45.Location = new System.Drawing.Point(273, 40);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(50, 16);
            this.label45.TabIndex = 10;
            this.label45.Text = "Radius";
            this.label45.Click += new System.EventHandler(this.label45_Click);
            // 
            // AddSplit
            // 
            this.structuresExtender.SetAttributeName(this.AddSplit, null);
            this.structuresExtender.SetAttributeTypeName(this.AddSplit, null);
            this.structuresExtender.SetBindPropertyName(this.AddSplit, null);
            this.AddSplit.Location = new System.Drawing.Point(121, 68);
            this.AddSplit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddSplit.Name = "AddSplit";
            this.AddSplit.Size = new System.Drawing.Size(111, 25);
            this.AddSplit.TabIndex = 7;
            this.AddSplit.Text = "Add Split";
            this.AddSplit.UseVisualStyleBackColor = true;
            this.AddSplit.Click += new System.EventHandler(this.AddSplitButton_Click);
            // 
            // ColumnAddRadioButton
            // 
            this.structuresExtender.SetAttributeName(this.ColumnAddRadioButton, null);
            this.structuresExtender.SetAttributeTypeName(this.ColumnAddRadioButton, null);
            this.ColumnAddRadioButton.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.ColumnAddRadioButton, null);
            this.ColumnAddRadioButton.Location = new System.Drawing.Point(79, 7);
            this.ColumnAddRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.ColumnAddRadioButton.Name = "ColumnAddRadioButton";
            this.ColumnAddRadioButton.Size = new System.Drawing.Size(73, 20);
            this.ColumnAddRadioButton.TabIndex = 3;
            this.ColumnAddRadioButton.TabStop = true;
            this.ColumnAddRadioButton.Text = "Column";
            this.ColumnAddRadioButton.UseVisualStyleBackColor = true;
            // 
            // RowAddRadioButton
            // 
            this.structuresExtender.SetAttributeName(this.RowAddRadioButton, null);
            this.structuresExtender.SetAttributeTypeName(this.RowAddRadioButton, null);
            this.RowAddRadioButton.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RowAddRadioButton, null);
            this.RowAddRadioButton.Checked = true;
            this.RowAddRadioButton.Location = new System.Drawing.Point(8, 7);
            this.RowAddRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.RowAddRadioButton.Name = "RowAddRadioButton";
            this.RowAddRadioButton.Size = new System.Drawing.Size(55, 20);
            this.RowAddRadioButton.TabIndex = 2;
            this.RowAddRadioButton.TabStop = true;
            this.RowAddRadioButton.Text = "Row";
            this.RowAddRadioButton.UseVisualStyleBackColor = true;
            // 
            // cabinetAddValue
            // 
            this.structuresExtender.SetAttributeName(this.cabinetAddValue, null);
            this.structuresExtender.SetAttributeTypeName(this.cabinetAddValue, null);
            this.structuresExtender.SetBindPropertyName(this.cabinetAddValue, null);
            this.cabinetAddValue.Location = new System.Drawing.Point(8, 36);
            this.cabinetAddValue.Margin = new System.Windows.Forms.Padding(4);
            this.cabinetAddValue.Name = "cabinetAddValue";
            this.cabinetAddValue.Size = new System.Drawing.Size(223, 22);
            this.cabinetAddValue.TabIndex = 0;
            this.cabinetAddValue.TextChanged += new System.EventHandler(this.cabinetAddValue_TextChanged);
            // 
            // cabinetValueAddButton
            // 
            this.structuresExtender.SetAttributeName(this.cabinetValueAddButton, null);
            this.structuresExtender.SetAttributeTypeName(this.cabinetValueAddButton, null);
            this.structuresExtender.SetBindPropertyName(this.cabinetValueAddButton, null);
            this.cabinetValueAddButton.Location = new System.Drawing.Point(8, 68);
            this.cabinetValueAddButton.Margin = new System.Windows.Forms.Padding(4);
            this.cabinetValueAddButton.Name = "cabinetValueAddButton";
            this.cabinetValueAddButton.Size = new System.Drawing.Size(111, 25);
            this.cabinetValueAddButton.TabIndex = 1;
            this.cabinetValueAddButton.Text = "Add";
            this.cabinetValueAddButton.UseVisualStyleBackColor = true;
            this.cabinetValueAddButton.Click += new System.EventHandler(this.CabinetValueAddButton_Click);
            // 
            // CabinetEditTab
            // 
            this.structuresExtender.SetAttributeName(this.CabinetEditTab, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetEditTab, null);
            this.structuresExtender.SetBindPropertyName(this.CabinetEditTab, null);
            this.CabinetEditTab.Controls.Add(this.EditRemoveSplit);
            this.CabinetEditTab.Controls.Add(this.CabinetResetButton);
            this.CabinetEditTab.Controls.Add(this.ColumnEditRadioButton);
            this.CabinetEditTab.Controls.Add(this.RowEditRadioButton);
            this.CabinetEditTab.Controls.Add(this.CabinetRemoveButton);
            this.CabinetEditTab.Controls.Add(this.CabinetEditValue);
            this.CabinetEditTab.Controls.Add(this.CabinetEditButton);
            this.CabinetEditTab.Location = new System.Drawing.Point(4, 25);
            this.CabinetEditTab.Margin = new System.Windows.Forms.Padding(4);
            this.CabinetEditTab.Name = "CabinetEditTab";
            this.CabinetEditTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CabinetEditTab.Size = new System.Drawing.Size(357, 105);
            this.CabinetEditTab.TabIndex = 1;
            this.CabinetEditTab.Text = "Edit";
            this.CabinetEditTab.UseVisualStyleBackColor = true;
            // 
            // EditRemoveSplit
            // 
            this.structuresExtender.SetAttributeName(this.EditRemoveSplit, null);
            this.structuresExtender.SetAttributeTypeName(this.EditRemoveSplit, null);
            this.structuresExtender.SetBindPropertyName(this.EditRemoveSplit, null);
            this.EditRemoveSplit.Location = new System.Drawing.Point(123, 68);
            this.EditRemoveSplit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EditRemoveSplit.Name = "EditRemoveSplit";
            this.EditRemoveSplit.Size = new System.Drawing.Size(111, 25);
            this.EditRemoveSplit.TabIndex = 6;
            this.EditRemoveSplit.Text = "Remove Split";
            this.EditRemoveSplit.UseVisualStyleBackColor = true;
            this.EditRemoveSplit.Click += new System.EventHandler(this.EditRemoveSplit_Click);
            // 
            // CabinetResetButton
            // 
            this.structuresExtender.SetAttributeName(this.CabinetResetButton, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetResetButton, null);
            this.structuresExtender.SetBindPropertyName(this.CabinetResetButton, null);
            this.CabinetResetButton.Location = new System.Drawing.Point(240, 68);
            this.CabinetResetButton.Margin = new System.Windows.Forms.Padding(4);
            this.CabinetResetButton.Name = "CabinetResetButton";
            this.CabinetResetButton.Size = new System.Drawing.Size(107, 25);
            this.CabinetResetButton.TabIndex = 5;
            this.CabinetResetButton.TabStop = false;
            this.CabinetResetButton.Text = "Remove All";
            this.CabinetResetButton.UseVisualStyleBackColor = true;
            this.CabinetResetButton.Click += new System.EventHandler(this.CabinetResetButton_Click);
            // 
            // ColumnEditRadioButton
            // 
            this.structuresExtender.SetAttributeName(this.ColumnEditRadioButton, null);
            this.structuresExtender.SetAttributeTypeName(this.ColumnEditRadioButton, null);
            this.ColumnEditRadioButton.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.ColumnEditRadioButton, null);
            this.ColumnEditRadioButton.Location = new System.Drawing.Point(79, 7);
            this.ColumnEditRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.ColumnEditRadioButton.Name = "ColumnEditRadioButton";
            this.ColumnEditRadioButton.Size = new System.Drawing.Size(73, 20);
            this.ColumnEditRadioButton.TabIndex = 1;
            this.ColumnEditRadioButton.Text = "Column";
            this.ColumnEditRadioButton.UseVisualStyleBackColor = true;
            this.ColumnEditRadioButton.CheckedChanged += new System.EventHandler(this.EditColumnRadioButton_CheckedChanged);
            // 
            // RowEditRadioButton
            // 
            this.structuresExtender.SetAttributeName(this.RowEditRadioButton, null);
            this.structuresExtender.SetAttributeTypeName(this.RowEditRadioButton, null);
            this.RowEditRadioButton.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RowEditRadioButton, null);
            this.RowEditRadioButton.Checked = true;
            this.RowEditRadioButton.Location = new System.Drawing.Point(8, 7);
            this.RowEditRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.RowEditRadioButton.Name = "RowEditRadioButton";
            this.RowEditRadioButton.Size = new System.Drawing.Size(55, 20);
            this.RowEditRadioButton.TabIndex = 0;
            this.RowEditRadioButton.TabStop = true;
            this.RowEditRadioButton.Text = "Row";
            this.RowEditRadioButton.UseVisualStyleBackColor = true;
            this.RowEditRadioButton.CheckedChanged += new System.EventHandler(this.EditRowRadioButton_CheckedChanged);
            // 
            // CabinetRemoveButton
            // 
            this.structuresExtender.SetAttributeName(this.CabinetRemoveButton, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetRemoveButton, null);
            this.structuresExtender.SetBindPropertyName(this.CabinetRemoveButton, null);
            this.CabinetRemoveButton.Location = new System.Drawing.Point(8, 68);
            this.CabinetRemoveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CabinetRemoveButton.Name = "CabinetRemoveButton";
            this.CabinetRemoveButton.Size = new System.Drawing.Size(109, 25);
            this.CabinetRemoveButton.TabIndex = 4;
            this.CabinetRemoveButton.Text = "Remove";
            this.CabinetRemoveButton.UseVisualStyleBackColor = true;
            this.CabinetRemoveButton.Click += new System.EventHandler(this.CabinetRemoveButton_Click);
            // 
            // CabinetEditValue
            // 
            this.structuresExtender.SetAttributeName(this.CabinetEditValue, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetEditValue, null);
            this.structuresExtender.SetBindPropertyName(this.CabinetEditValue, null);
            this.CabinetEditValue.Location = new System.Drawing.Point(8, 36);
            this.CabinetEditValue.Margin = new System.Windows.Forms.Padding(4);
            this.CabinetEditValue.Name = "CabinetEditValue";
            this.CabinetEditValue.Size = new System.Drawing.Size(223, 22);
            this.CabinetEditValue.TabIndex = 2;
            // 
            // CabinetEditButton
            // 
            this.structuresExtender.SetAttributeName(this.CabinetEditButton, null);
            this.structuresExtender.SetAttributeTypeName(this.CabinetEditButton, null);
            this.structuresExtender.SetBindPropertyName(this.CabinetEditButton, null);
            this.CabinetEditButton.Location = new System.Drawing.Point(240, 34);
            this.CabinetEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CabinetEditButton.Name = "CabinetEditButton";
            this.CabinetEditButton.Size = new System.Drawing.Size(107, 25);
            this.CabinetEditButton.TabIndex = 3;
            this.CabinetEditButton.Text = "Edit";
            this.CabinetEditButton.UseVisualStyleBackColor = true;
            this.CabinetEditButton.Click += new System.EventHandler(this.CabinetEditButton_Click);
            // 
            // columnSumLabel
            // 
            this.structuresExtender.SetAttributeName(this.columnSumLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.columnSumLabel, null);
            this.columnSumLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.columnSumLabel, null);
            this.columnSumLabel.Location = new System.Drawing.Point(208, 270);
            this.columnSumLabel.Name = "columnSumLabel";
            this.columnSumLabel.Size = new System.Drawing.Size(14, 16);
            this.columnSumLabel.TabIndex = 7;
            this.columnSumLabel.Text = "0";
            // 
            // columnLabel
            // 
            this.structuresExtender.SetAttributeName(this.columnLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.columnLabel, null);
            this.columnLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.columnLabel, null);
            this.columnLabel.Location = new System.Drawing.Point(140, 270);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(65, 16);
            this.columnLabel.TabIndex = 6;
            this.columnLabel.Text = "Columns: ";
            // 
            // rowSumLabel
            // 
            this.structuresExtender.SetAttributeName(this.rowSumLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.rowSumLabel, null);
            this.rowSumLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.rowSumLabel, null);
            this.rowSumLabel.Location = new System.Drawing.Point(53, 270);
            this.rowSumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowSumLabel.Name = "rowSumLabel";
            this.rowSumLabel.Size = new System.Drawing.Size(14, 16);
            this.rowSumLabel.TabIndex = 5;
            this.rowSumLabel.Text = "0";
            // 
            // rowLabel
            // 
            this.structuresExtender.SetAttributeName(this.rowLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.rowLabel, null);
            this.rowLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.rowLabel, null);
            this.rowLabel.Location = new System.Drawing.Point(4, 270);
            this.rowLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(47, 16);
            this.rowLabel.TabIndex = 4;
            this.rowLabel.Text = "Rows: ";
            // 
            // columnList
            // 
            this.structuresExtender.SetAttributeName(this.columnList, null);
            this.structuresExtender.SetAttributeTypeName(this.columnList, null);
            this.structuresExtender.SetBindPropertyName(this.columnList, null);
            this.columnList.FormattingEnabled = true;
            this.columnList.ItemHeight = 16;
            this.columnList.Location = new System.Drawing.Point(144, 165);
            this.columnList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.columnList.Name = "columnList";
            this.columnList.Size = new System.Drawing.Size(128, 100);
            this.columnList.TabIndex = 7;
            this.columnList.Click += new System.EventHandler(this.collist_click);
            this.columnList.SelectedIndexChanged += new System.EventHandler(this.ColumnList_SelectedIndexChanged);
            // 
            // rowList
            // 
            this.rowList.AllowDrop = true;
            this.structuresExtender.SetAttributeName(this.rowList, null);
            this.structuresExtender.SetAttributeTypeName(this.rowList, null);
            this.structuresExtender.SetBindPropertyName(this.rowList, null);
            this.rowList.FormattingEnabled = true;
            this.rowList.ItemHeight = 16;
            this.rowList.Location = new System.Drawing.Point(8, 165);
            this.rowList.Margin = new System.Windows.Forms.Padding(4);
            this.rowList.Name = "rowList";
            this.rowList.Size = new System.Drawing.Size(128, 100);
            this.rowList.TabIndex = 6;
            this.rowList.Click += new System.EventHandler(this.rowlist_click);
            this.rowList.SelectedIndexChanged += new System.EventHandler(this.RowList_SelectedIndexChanged);
            // 
            // MaterialAndProfile
            // 
            this.structuresExtender.SetAttributeName(this.MaterialAndProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.MaterialAndProfile, null);
            this.structuresExtender.SetBindPropertyName(this.MaterialAndProfile, null);
            this.MaterialAndProfile.Controls.Add(this.profileCatalog1);
            this.MaterialAndProfile.Controls.Add(this.tableLayoutPanel1);
            this.MaterialAndProfile.Location = new System.Drawing.Point(848, 20);
            this.MaterialAndProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaterialAndProfile.Name = "MaterialAndProfile";
            this.MaterialAndProfile.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaterialAndProfile.Size = new System.Drawing.Size(376, 464);
            this.MaterialAndProfile.TabIndex = 2;
            this.MaterialAndProfile.TabStop = false;
            this.MaterialAndProfile.Text = "Material and Profile";
            // 
            // profileCatalog1
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog1, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog1, null);
            this.profileCatalog1.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog1, null);
            this.profileCatalog1.ButtonText = "Select...";
            this.profileCatalog1.Location = new System.Drawing.Point(295, 81);
            this.profileCatalog1.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog1.Name = "profileCatalog1";
            this.profileCatalog1.SelectedProfile = "";
            this.profileCatalog1.Size = new System.Drawing.Size(75, 25);
            this.profileCatalog1.TabIndex = 24;
            this.profileCatalog1.SelectClicked += new System.EventHandler(this.profileCatalog1_SelectClicked);
            this.profileCatalog1.SelectionDone += new System.EventHandler(this.profileCatalog1_SelectionDone);
            // 
            // tableLayoutPanel1
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel1, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel1, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel1, null);
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.Controls.Add(this.Waler, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.B5Profile, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.B2Profile, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.B2Material, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.B5Material, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.B1Profile, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.B1Material, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.BR1Profile, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.BR1Material, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.BR1, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.C1Profile, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LEDProfile, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.B5, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.B2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.LED, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.C1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.B1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.LEDMaterial, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.C1Material, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.B3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.B3Material, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.B3Profile, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.WalerMaterial, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.WalerProfile, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.SeatingPlate, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.SeatingPlateMaterial, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.SeatingPlateProfile, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.EAMaterial, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.EAProfile, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.EASupport, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.ZBracketLabel, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.ZBracketMaterial, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.ZBracketProfile, 2, 13);
            this.tableLayoutPanel1.Controls.Add(this.profileCatalog2, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.profileCatalog3, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.profileCatalog4, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.profileCatalog5, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.profileCatalog6, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.profileCatalog7, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.profileCatalog8, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.profileCatalog9, 3, 13);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 25);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 412);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Waler
            // 
            this.structuresExtender.SetAttributeName(this.Waler, null);
            this.structuresExtender.SetAttributeTypeName(this.Waler, null);
            this.Waler.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.Waler, null);
            this.Waler.Location = new System.Drawing.Point(3, 242);
            this.Waler.Name = "Waler";
            this.Waler.Size = new System.Drawing.Size(43, 16);
            this.Waler.TabIndex = 14;
            this.Waler.Text = "Waler";
            // 
            // B5Profile
            // 
            this.structuresExtender.SetAttributeName(this.B5Profile, null);
            this.structuresExtender.SetAttributeTypeName(this.B5Profile, null);
            this.structuresExtender.SetBindPropertyName(this.B5Profile, null);
            this.B5Profile.Location = new System.Drawing.Point(170, 178);
            this.B5Profile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B5Profile.Name = "B5Profile";
            this.B5Profile.Size = new System.Drawing.Size(111, 22);
            this.B5Profile.TabIndex = 11;
            this.B5Profile.Text = "SHS65*65*4.0";
            this.B5Profile.TextChanged += new System.EventHandler(this.B5Profile_TextChanged);
            this.B5Profile.Validating += new System.ComponentModel.CancelEventHandler(this.B5Profile_Validating);
            // 
            // B2Profile
            // 
            this.structuresExtender.SetAttributeName(this.B2Profile, null);
            this.structuresExtender.SetAttributeTypeName(this.B2Profile, null);
            this.structuresExtender.SetBindPropertyName(this.B2Profile, null);
            this.B2Profile.Location = new System.Drawing.Point(170, 112);
            this.B2Profile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B2Profile.Name = "B2Profile";
            this.B2Profile.Size = new System.Drawing.Size(111, 22);
            this.B2Profile.TabIndex = 7;
            this.B2Profile.Text = "RHS75*50*4.0";
            this.B2Profile.TextChanged += new System.EventHandler(this.B2Profile_TextChanged);
            this.B2Profile.Validating += new System.ComponentModel.CancelEventHandler(this.B2Profile_Validating);
            // 
            // B2Material
            // 
            this.structuresExtender.SetAttributeName(this.B2Material, null);
            this.structuresExtender.SetAttributeTypeName(this.B2Material, null);
            this.structuresExtender.SetBindPropertyName(this.B2Material, null);
            this.B2Material.Location = new System.Drawing.Point(96, 112);
            this.B2Material.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B2Material.Name = "B2Material";
            this.B2Material.Size = new System.Drawing.Size(68, 22);
            this.B2Material.TabIndex = 6;
            this.B2Material.Text = "C350L0";
            this.B2Material.TextChanged += new System.EventHandler(this.B2Material_TextChanged);
            // 
            // B5Material
            // 
            this.structuresExtender.SetAttributeName(this.B5Material, null);
            this.structuresExtender.SetAttributeTypeName(this.B5Material, null);
            this.structuresExtender.SetBindPropertyName(this.B5Material, null);
            this.B5Material.Location = new System.Drawing.Point(96, 178);
            this.B5Material.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B5Material.Name = "B5Material";
            this.B5Material.Size = new System.Drawing.Size(68, 22);
            this.B5Material.TabIndex = 10;
            this.B5Material.Text = "C350L0";
            this.B5Material.TextChanged += new System.EventHandler(this.B5Material_TextChanged);
            // 
            // B1Profile
            // 
            this.structuresExtender.SetAttributeName(this.B1Profile, null);
            this.structuresExtender.SetAttributeTypeName(this.B1Profile, null);
            this.structuresExtender.SetBindPropertyName(this.B1Profile, null);
            this.B1Profile.Location = new System.Drawing.Point(170, 79);
            this.B1Profile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B1Profile.Name = "B1Profile";
            this.B1Profile.Size = new System.Drawing.Size(111, 22);
            this.B1Profile.TabIndex = 5;
            this.B1Profile.Text = "SHS75*75*4.0";
            this.B1Profile.TextChanged += new System.EventHandler(this.B1Profile_TextChanged);
            this.B1Profile.Validating += new System.ComponentModel.CancelEventHandler(this.B1Profile_Validating);
            // 
            // B1Material
            // 
            this.structuresExtender.SetAttributeName(this.B1Material, null);
            this.structuresExtender.SetAttributeTypeName(this.B1Material, null);
            this.structuresExtender.SetBindPropertyName(this.B1Material, null);
            this.B1Material.Location = new System.Drawing.Point(96, 79);
            this.B1Material.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B1Material.Name = "B1Material";
            this.B1Material.Size = new System.Drawing.Size(68, 22);
            this.B1Material.TabIndex = 4;
            this.B1Material.Text = "C350L0";
            this.B1Material.TextChanged += new System.EventHandler(this.B1Material_TextChanged);
            // 
            // BR1Profile
            // 
            this.structuresExtender.SetAttributeName(this.BR1Profile, null);
            this.structuresExtender.SetAttributeTypeName(this.BR1Profile, null);
            this.structuresExtender.SetBindPropertyName(this.BR1Profile, null);
            this.BR1Profile.Location = new System.Drawing.Point(170, 211);
            this.BR1Profile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BR1Profile.Name = "BR1Profile";
            this.BR1Profile.Size = new System.Drawing.Size(111, 22);
            this.BR1Profile.TabIndex = 13;
            this.BR1Profile.Text = "SHS50*50*3.0";
            this.BR1Profile.TextChanged += new System.EventHandler(this.BR1Profile_TextChanged);
            this.BR1Profile.Validating += new System.ComponentModel.CancelEventHandler(this.BR1Profile_Validating);
            // 
            // BR1Material
            // 
            this.structuresExtender.SetAttributeName(this.BR1Material, null);
            this.structuresExtender.SetAttributeTypeName(this.BR1Material, null);
            this.structuresExtender.SetBindPropertyName(this.BR1Material, null);
            this.BR1Material.Location = new System.Drawing.Point(96, 211);
            this.BR1Material.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BR1Material.Name = "BR1Material";
            this.BR1Material.Size = new System.Drawing.Size(68, 22);
            this.BR1Material.TabIndex = 12;
            this.BR1Material.Text = "C350L0";
            this.BR1Material.TextChanged += new System.EventHandler(this.BR1Material_TextChanged);
            // 
            // BR1
            // 
            this.structuresExtender.SetAttributeName(this.BR1, null);
            this.structuresExtender.SetAttributeTypeName(this.BR1, null);
            this.BR1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BR1, null);
            this.BR1.Location = new System.Drawing.Point(3, 209);
            this.BR1.Name = "BR1";
            this.BR1.Size = new System.Drawing.Size(33, 16);
            this.BR1.TabIndex = 13;
            this.BR1.Text = "BR1";
            // 
            // C1Profile
            // 
            this.structuresExtender.SetAttributeName(this.C1Profile, null);
            this.structuresExtender.SetAttributeTypeName(this.C1Profile, null);
            this.structuresExtender.SetBindPropertyName(this.C1Profile, null);
            this.C1Profile.Location = new System.Drawing.Point(170, 53);
            this.C1Profile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.C1Profile.Name = "C1Profile";
            this.C1Profile.Size = new System.Drawing.Size(111, 22);
            this.C1Profile.TabIndex = 3;
            this.C1Profile.Text = "RHS75*50*4.0";
            this.C1Profile.TextChanged += new System.EventHandler(this.C1Profile_TextChanged);
            this.C1Profile.Validating += new System.ComponentModel.CancelEventHandler(this.C1Profile_Validating);
            // 
            // LEDProfile
            // 
            this.structuresExtender.SetAttributeName(this.LEDProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.LEDProfile, null);
            this.structuresExtender.SetBindPropertyName(this.LEDProfile, null);
            this.LEDProfile.Enabled = false;
            this.LEDProfile.Location = new System.Drawing.Point(170, 27);
            this.LEDProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LEDProfile.Name = "LEDProfile";
            this.LEDProfile.Size = new System.Drawing.Size(111, 22);
            this.LEDProfile.TabIndex = 1;
            this.LEDProfile.Text = "PLT170";
            this.LEDProfile.TextChanged += new System.EventHandler(this.LEDProfile_TextChanged);
            this.LEDProfile.Validating += new System.ComponentModel.CancelEventHandler(this.LEDProfile_Validating);
            // 
            // label7
            // 
            this.structuresExtender.SetAttributeName(this.label7, null);
            this.structuresExtender.SetAttributeTypeName(this.label7, null);
            this.label7.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label7, null);
            this.label7.Location = new System.Drawing.Point(170, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Profile";
            // 
            // label6
            // 
            this.structuresExtender.SetAttributeName(this.label6, null);
            this.structuresExtender.SetAttributeTypeName(this.label6, null);
            this.label6.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label6, null);
            this.label6.Location = new System.Drawing.Point(96, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "Material";
            // 
            // B5
            // 
            this.structuresExtender.SetAttributeName(this.B5, null);
            this.structuresExtender.SetAttributeTypeName(this.B5, null);
            this.B5.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.B5, null);
            this.B5.Location = new System.Drawing.Point(3, 176);
            this.B5.Name = "B5";
            this.B5.Size = new System.Drawing.Size(23, 16);
            this.B5.TabIndex = 3;
            this.B5.Text = "B5";
            // 
            // B2
            // 
            this.structuresExtender.SetAttributeName(this.B2, null);
            this.structuresExtender.SetAttributeTypeName(this.B2, null);
            this.B2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.B2, null);
            this.B2.Location = new System.Drawing.Point(3, 110);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(23, 16);
            this.B2.TabIndex = 8;
            this.B2.Text = "B2";
            // 
            // LED
            // 
            this.structuresExtender.SetAttributeName(this.LED, null);
            this.structuresExtender.SetAttributeTypeName(this.LED, null);
            this.LED.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LED, null);
            this.LED.Location = new System.Drawing.Point(3, 25);
            this.LED.Name = "LED";
            this.LED.Size = new System.Drawing.Size(33, 16);
            this.LED.TabIndex = 0;
            this.LED.Text = "LED";
            // 
            // C1
            // 
            this.structuresExtender.SetAttributeName(this.C1, null);
            this.structuresExtender.SetAttributeTypeName(this.C1, null);
            this.C1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.C1, null);
            this.C1.Location = new System.Drawing.Point(3, 51);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(23, 16);
            this.C1.TabIndex = 1;
            this.C1.Text = "C1";
            // 
            // B1
            // 
            this.structuresExtender.SetAttributeName(this.B1, null);
            this.structuresExtender.SetAttributeTypeName(this.B1, null);
            this.B1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.B1, null);
            this.B1.Location = new System.Drawing.Point(3, 77);
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(23, 16);
            this.B1.TabIndex = 2;
            this.B1.Text = "B1";
            // 
            // LEDMaterial
            // 
            this.structuresExtender.SetAttributeName(this.LEDMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.LEDMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.LEDMaterial, null);
            this.LEDMaterial.Enabled = false;
            this.LEDMaterial.Location = new System.Drawing.Point(96, 27);
            this.LEDMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LEDMaterial.Name = "LEDMaterial";
            this.LEDMaterial.Size = new System.Drawing.Size(68, 22);
            this.LEDMaterial.TabIndex = 0;
            this.LEDMaterial.Text = "digital1.0";
            this.LEDMaterial.TextChanged += new System.EventHandler(this.LEDMaterial_TextChanged);
            // 
            // C1Material
            // 
            this.structuresExtender.SetAttributeName(this.C1Material, null);
            this.structuresExtender.SetAttributeTypeName(this.C1Material, null);
            this.structuresExtender.SetBindPropertyName(this.C1Material, null);
            this.C1Material.Location = new System.Drawing.Point(96, 53);
            this.C1Material.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.C1Material.Name = "C1Material";
            this.C1Material.Size = new System.Drawing.Size(68, 22);
            this.C1Material.TabIndex = 2;
            this.C1Material.Text = "C350L0";
            this.C1Material.TextChanged += new System.EventHandler(this.C1Material_TextChanged);
            // 
            // B3
            // 
            this.structuresExtender.SetAttributeName(this.B3, null);
            this.structuresExtender.SetAttributeTypeName(this.B3, null);
            this.B3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.B3, null);
            this.B3.Location = new System.Drawing.Point(3, 143);
            this.B3.Name = "B3";
            this.B3.Size = new System.Drawing.Size(23, 16);
            this.B3.TabIndex = 12;
            this.B3.Text = "B3";
            // 
            // B3Material
            // 
            this.structuresExtender.SetAttributeName(this.B3Material, null);
            this.structuresExtender.SetAttributeTypeName(this.B3Material, null);
            this.structuresExtender.SetBindPropertyName(this.B3Material, null);
            this.B3Material.Location = new System.Drawing.Point(96, 145);
            this.B3Material.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B3Material.Name = "B3Material";
            this.B3Material.Size = new System.Drawing.Size(68, 22);
            this.B3Material.TabIndex = 8;
            this.B3Material.Text = "C350L0";
            this.B3Material.TextChanged += new System.EventHandler(this.B3Material_TextChanged);
            // 
            // B3Profile
            // 
            this.structuresExtender.SetAttributeName(this.B3Profile, null);
            this.structuresExtender.SetAttributeTypeName(this.B3Profile, null);
            this.structuresExtender.SetBindPropertyName(this.B3Profile, null);
            this.B3Profile.Location = new System.Drawing.Point(170, 145);
            this.B3Profile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B3Profile.Name = "B3Profile";
            this.B3Profile.Size = new System.Drawing.Size(111, 22);
            this.B3Profile.TabIndex = 9;
            this.B3Profile.Text = "SHS50*50*3.0";
            this.B3Profile.TextChanged += new System.EventHandler(this.B3Profile_TextChanged);
            this.B3Profile.Validating += new System.ComponentModel.CancelEventHandler(this.B3Profile_Validating);
            // 
            // WalerMaterial
            // 
            this.structuresExtender.SetAttributeName(this.WalerMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.WalerMaterial, null);
            this.WalerMaterial.Location = new System.Drawing.Point(96, 244);
            this.WalerMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WalerMaterial.Name = "WalerMaterial";
            this.WalerMaterial.Size = new System.Drawing.Size(68, 22);
            this.WalerMaterial.TabIndex = 14;
            this.WalerMaterial.Text = "C350L0";
            this.WalerMaterial.TextChanged += new System.EventHandler(this.WalerMaterial_TextChanged);
            // 
            // WalerProfile
            // 
            this.structuresExtender.SetAttributeName(this.WalerProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerProfile, null);
            this.structuresExtender.SetBindPropertyName(this.WalerProfile, null);
            this.WalerProfile.Location = new System.Drawing.Point(170, 244);
            this.WalerProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WalerProfile.Name = "WalerProfile";
            this.WalerProfile.Size = new System.Drawing.Size(111, 22);
            this.WalerProfile.TabIndex = 15;
            this.WalerProfile.Text = "SHS75*75*4.0";
            this.WalerProfile.TextChanged += new System.EventHandler(this.WalerProfile_TextChanged);
            this.WalerProfile.Validating += new System.ComponentModel.CancelEventHandler(this.WalerProfile_Validating);
            // 
            // SeatingPlate
            // 
            this.structuresExtender.SetAttributeName(this.SeatingPlate, null);
            this.structuresExtender.SetAttributeTypeName(this.SeatingPlate, null);
            this.SeatingPlate.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.SeatingPlate, null);
            this.SeatingPlate.Location = new System.Drawing.Point(3, 275);
            this.SeatingPlate.Name = "SeatingPlate";
            this.SeatingPlate.Size = new System.Drawing.Size(87, 16);
            this.SeatingPlate.TabIndex = 17;
            this.SeatingPlate.Text = "Seating Plate";
            // 
            // SeatingPlateMaterial
            // 
            this.structuresExtender.SetAttributeName(this.SeatingPlateMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.SeatingPlateMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.SeatingPlateMaterial, null);
            this.SeatingPlateMaterial.Location = new System.Drawing.Point(96, 277);
            this.SeatingPlateMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SeatingPlateMaterial.Name = "SeatingPlateMaterial";
            this.SeatingPlateMaterial.Size = new System.Drawing.Size(68, 22);
            this.SeatingPlateMaterial.TabIndex = 16;
            this.SeatingPlateMaterial.Text = "250";
            this.SeatingPlateMaterial.TextChanged += new System.EventHandler(this.SeatingPlateMaterial_TextChanged);
            // 
            // SeatingPlateProfile
            // 
            this.structuresExtender.SetAttributeName(this.SeatingPlateProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.SeatingPlateProfile, null);
            this.structuresExtender.SetBindPropertyName(this.SeatingPlateProfile, null);
            this.SeatingPlateProfile.Location = new System.Drawing.Point(170, 277);
            this.SeatingPlateProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SeatingPlateProfile.Name = "SeatingPlateProfile";
            this.SeatingPlateProfile.Size = new System.Drawing.Size(111, 22);
            this.SeatingPlateProfile.TabIndex = 17;
            this.SeatingPlateProfile.Text = "FL8";
            this.SeatingPlateProfile.TextChanged += new System.EventHandler(this.SeatingPlateProfile_TextChanged);
            this.SeatingPlateProfile.Validating += new System.ComponentModel.CancelEventHandler(this.SeatingPlateProfile_Validating);
            // 
            // EAMaterial
            // 
            this.structuresExtender.SetAttributeName(this.EAMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.EAMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.EAMaterial, null);
            this.EAMaterial.Location = new System.Drawing.Point(96, 302);
            this.EAMaterial.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.EAMaterial.Name = "EAMaterial";
            this.EAMaterial.Size = new System.Drawing.Size(68, 22);
            this.EAMaterial.TabIndex = 18;
            this.EAMaterial.Text = "C350L0";
            this.EAMaterial.TextChanged += new System.EventHandler(this.EAMaterial_TextChanged);
            // 
            // EAProfile
            // 
            this.structuresExtender.SetAttributeName(this.EAProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.EAProfile, null);
            this.structuresExtender.SetBindPropertyName(this.EAProfile, null);
            this.EAProfile.Location = new System.Drawing.Point(170, 302);
            this.EAProfile.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.EAProfile.Name = "EAProfile";
            this.EAProfile.Size = new System.Drawing.Size(111, 22);
            this.EAProfile.TabIndex = 19;
            this.EAProfile.Text = "EA50*50*5";
            this.EAProfile.TextChanged += new System.EventHandler(this.EAProfile_TextChanged);
            this.EAProfile.Validating += new System.ComponentModel.CancelEventHandler(this.EAProfile_Validating);
            // 
            // EASupport
            // 
            this.structuresExtender.SetAttributeName(this.EASupport, null);
            this.structuresExtender.SetAttributeTypeName(this.EASupport, null);
            this.EASupport.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.EASupport, null);
            this.EASupport.Location = new System.Drawing.Point(3, 301);
            this.EASupport.Name = "EASupport";
            this.EASupport.Size = new System.Drawing.Size(75, 16);
            this.EASupport.TabIndex = 20;
            this.EASupport.Text = "EA Support";
            // 
            // ZBracketLabel
            // 
            this.structuresExtender.SetAttributeName(this.ZBracketLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.ZBracketLabel, null);
            this.ZBracketLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.ZBracketLabel, null);
            this.ZBracketLabel.Location = new System.Drawing.Point(3, 334);
            this.ZBracketLabel.Name = "ZBracketLabel";
            this.ZBracketLabel.Size = new System.Drawing.Size(63, 16);
            this.ZBracketLabel.TabIndex = 23;
            this.ZBracketLabel.Text = "Z bracket";
            // 
            // ZBracketMaterial
            // 
            this.structuresExtender.SetAttributeName(this.ZBracketMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.ZBracketMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.ZBracketMaterial, null);
            this.ZBracketMaterial.Location = new System.Drawing.Point(96, 335);
            this.ZBracketMaterial.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.ZBracketMaterial.Name = "ZBracketMaterial";
            this.ZBracketMaterial.Size = new System.Drawing.Size(68, 22);
            this.ZBracketMaterial.TabIndex = 20;
            this.ZBracketMaterial.Text = "250";
            this.ZBracketMaterial.TextChanged += new System.EventHandler(this.ZBracketMaterial_TextChanged);
            // 
            // ZBracketProfile
            // 
            this.structuresExtender.SetAttributeName(this.ZBracketProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.ZBracketProfile, null);
            this.structuresExtender.SetBindPropertyName(this.ZBracketProfile, null);
            this.ZBracketProfile.Location = new System.Drawing.Point(170, 335);
            this.ZBracketProfile.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.ZBracketProfile.Name = "ZBracketProfile";
            this.ZBracketProfile.Size = new System.Drawing.Size(111, 22);
            this.ZBracketProfile.TabIndex = 21;
            this.ZBracketProfile.Text = "PLT12*75";
            this.ZBracketProfile.TextChanged += new System.EventHandler(this.ZBracketProfile_TextChanged);
            this.ZBracketProfile.Validating += new System.ComponentModel.CancelEventHandler(this.ZBracketProfile_Validating);
            // 
            // profileCatalog2
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog2, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog2, null);
            this.profileCatalog2.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog2, null);
            this.profileCatalog2.ButtonText = "Select...";
            this.profileCatalog2.Location = new System.Drawing.Point(289, 82);
            this.profileCatalog2.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog2.Name = "profileCatalog2";
            this.profileCatalog2.SelectedProfile = "";
            this.profileCatalog2.Size = new System.Drawing.Size(69, 23);
            this.profileCatalog2.TabIndex = 24;
            this.profileCatalog2.SelectClicked += new System.EventHandler(this.profileCatalog2_SelectClicked);
            this.profileCatalog2.SelectionDone += new System.EventHandler(this.profileCatalog2_SelectionDone);
            // 
            // profileCatalog3
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog3, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog3, null);
            this.profileCatalog3.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog3, null);
            this.profileCatalog3.ButtonText = "Select...";
            this.profileCatalog3.Location = new System.Drawing.Point(289, 115);
            this.profileCatalog3.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog3.Name = "profileCatalog3";
            this.profileCatalog3.SelectedProfile = "";
            this.profileCatalog3.Size = new System.Drawing.Size(69, 23);
            this.profileCatalog3.TabIndex = 25;
            this.profileCatalog3.SelectClicked += new System.EventHandler(this.profileCatalog3_SelectClicked);
            this.profileCatalog3.SelectionDone += new System.EventHandler(this.profileCatalog3_SelectionDone);
            // 
            // profileCatalog4
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog4, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog4, null);
            this.profileCatalog4.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog4, null);
            this.profileCatalog4.ButtonText = "Select...";
            this.profileCatalog4.Location = new System.Drawing.Point(289, 148);
            this.profileCatalog4.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog4.Name = "profileCatalog4";
            this.profileCatalog4.SelectedProfile = "";
            this.profileCatalog4.Size = new System.Drawing.Size(69, 23);
            this.profileCatalog4.TabIndex = 26;
            this.profileCatalog4.SelectClicked += new System.EventHandler(this.profileCatalog4_SelectClicked);
            this.profileCatalog4.SelectionDone += new System.EventHandler(this.profileCatalog4_SelectionDone);
            // 
            // profileCatalog5
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog5, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog5, null);
            this.profileCatalog5.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog5, null);
            this.profileCatalog5.ButtonText = "Select...";
            this.profileCatalog5.Location = new System.Drawing.Point(289, 181);
            this.profileCatalog5.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog5.Name = "profileCatalog5";
            this.profileCatalog5.SelectedProfile = "";
            this.profileCatalog5.Size = new System.Drawing.Size(69, 23);
            this.profileCatalog5.TabIndex = 27;
            this.profileCatalog5.SelectClicked += new System.EventHandler(this.profileCatalog5_SelectClicked);
            this.profileCatalog5.SelectionDone += new System.EventHandler(this.profileCatalog5_SelectionDone);
            this.profileCatalog5.Load += new System.EventHandler(this.profileCatalog5_SelectClicked);
            // 
            // profileCatalog6
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog6, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog6, null);
            this.profileCatalog6.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog6, null);
            this.profileCatalog6.ButtonText = "Select...";
            this.profileCatalog6.Location = new System.Drawing.Point(289, 214);
            this.profileCatalog6.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog6.Name = "profileCatalog6";
            this.profileCatalog6.SelectedProfile = "";
            this.profileCatalog6.Size = new System.Drawing.Size(69, 23);
            this.profileCatalog6.TabIndex = 28;
            this.profileCatalog6.SelectClicked += new System.EventHandler(this.profileCatalog6_SelectClicked);
            this.profileCatalog6.SelectionDone += new System.EventHandler(this.profileCatalog6_SelectionDone);
            // 
            // profileCatalog7
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog7, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog7, null);
            this.profileCatalog7.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog7, null);
            this.profileCatalog7.ButtonText = "Select...";
            this.profileCatalog7.Location = new System.Drawing.Point(289, 247);
            this.profileCatalog7.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog7.Name = "profileCatalog7";
            this.profileCatalog7.SelectedProfile = "";
            this.profileCatalog7.Size = new System.Drawing.Size(69, 23);
            this.profileCatalog7.TabIndex = 29;
            this.profileCatalog7.SelectClicked += new System.EventHandler(this.profileCatalog7_SelectClicked);
            this.profileCatalog7.SelectionDone += new System.EventHandler(this.profileCatalog7_SelectionDone);
            // 
            // profileCatalog8
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog8, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog8, null);
            this.profileCatalog8.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog8, null);
            this.profileCatalog8.ButtonText = "Select...";
            this.profileCatalog8.Location = new System.Drawing.Point(289, 306);
            this.profileCatalog8.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog8.Name = "profileCatalog8";
            this.profileCatalog8.SelectedProfile = "";
            this.profileCatalog8.Size = new System.Drawing.Size(69, 23);
            this.profileCatalog8.TabIndex = 30;
            this.profileCatalog8.SelectClicked += new System.EventHandler(this.profileCatalog8_SelectClicked);
            this.profileCatalog8.SelectionDone += new System.EventHandler(this.profileCatalog8_SelectionDone);
            // 
            // profileCatalog9
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog9, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog9, null);
            this.profileCatalog9.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog9, null);
            this.profileCatalog9.ButtonText = "Select...";
            this.profileCatalog9.Location = new System.Drawing.Point(289, 339);
            this.profileCatalog9.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog9.Name = "profileCatalog9";
            this.profileCatalog9.SelectedProfile = "";
            this.profileCatalog9.Size = new System.Drawing.Size(69, 23);
            this.profileCatalog9.TabIndex = 31;
            this.profileCatalog9.SelectClicked += new System.EventHandler(this.profileCatalog9_SelectClicked);
            this.profileCatalog9.SelectionDone += new System.EventHandler(this.profileCatalog9_SelectionDone);
            this.profileCatalog9.Load += new System.EventHandler(this.profileCatalog9_Load);
            // 
            // BillboardDimensions
            // 
            this.structuresExtender.SetAttributeName(this.BillboardDimensions, null);
            this.structuresExtender.SetAttributeTypeName(this.BillboardDimensions, null);
            this.structuresExtender.SetBindPropertyName(this.BillboardDimensions, null);
            this.BillboardDimensions.Controls.Add(this.tableLayoutPanel4);
            this.BillboardDimensions.Location = new System.Drawing.Point(523, 468);
            this.BillboardDimensions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BillboardDimensions.Name = "BillboardDimensions";
            this.BillboardDimensions.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BillboardDimensions.Size = new System.Drawing.Size(319, 154);
            this.BillboardDimensions.TabIndex = 3;
            this.BillboardDimensions.TabStop = false;
            this.BillboardDimensions.Text = "Billboard Dimensions";
            // 
            // tableLayoutPanel4
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel4, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel4, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel4, null);
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.BillBoardHeight, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.BillBoardLength, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label14, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.label13, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label15, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.HeightOffsetBottom, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.HeightOffsetTop, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.BillBoardDepth, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.BillboardWeight, 1, 3);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(5, 22);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(307, 127);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // label10
            // 
            this.structuresExtender.SetAttributeName(this.label10, null);
            this.structuresExtender.SetAttributeTypeName(this.label10, null);
            this.label10.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label10, null);
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Overall Height";
            // 
            // BillBoardHeight
            // 
            this.structuresExtender.SetAttributeName(this.BillBoardHeight, null);
            this.structuresExtender.SetAttributeTypeName(this.BillBoardHeight, null);
            this.BillBoardHeight.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BillBoardHeight, null);
            this.BillBoardHeight.Location = new System.Drawing.Point(164, 0);
            this.BillBoardHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BillBoardHeight.Name = "BillBoardHeight";
            this.BillBoardHeight.Size = new System.Drawing.Size(14, 16);
            this.BillBoardHeight.TabIndex = 8;
            this.BillBoardHeight.Text = "0";
            // 
            // label11
            // 
            this.structuresExtender.SetAttributeName(this.label11, null);
            this.structuresExtender.SetAttributeTypeName(this.label11, null);
            this.label11.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label11, null);
            this.label11.Location = new System.Drawing.Point(3, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Overall Length";
            // 
            // BillBoardLength
            // 
            this.structuresExtender.SetAttributeName(this.BillBoardLength, null);
            this.structuresExtender.SetAttributeTypeName(this.BillBoardLength, null);
            this.BillBoardLength.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BillBoardLength, null);
            this.BillBoardLength.Location = new System.Drawing.Point(163, 16);
            this.BillBoardLength.Name = "BillBoardLength";
            this.BillBoardLength.Size = new System.Drawing.Size(14, 16);
            this.BillBoardLength.TabIndex = 9;
            this.BillBoardLength.Text = "0";
            // 
            // label12
            // 
            this.structuresExtender.SetAttributeName(this.label12, null);
            this.structuresExtender.SetAttributeTypeName(this.label12, null);
            this.label12.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label12, null);
            this.label12.Location = new System.Drawing.Point(3, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Overall Depth";
            // 
            // label14
            // 
            this.structuresExtender.SetAttributeName(this.label14, null);
            this.structuresExtender.SetAttributeTypeName(this.label14, null);
            this.label14.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label14, null);
            this.label14.Location = new System.Drawing.Point(3, 88);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 16);
            this.label14.TabIndex = 11;
            this.label14.Text = "Screen Gap (Bottom)";
            // 
            // label13
            // 
            this.structuresExtender.SetAttributeName(this.label13, null);
            this.structuresExtender.SetAttributeTypeName(this.label13, null);
            this.label13.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label13, null);
            this.label13.Location = new System.Drawing.Point(3, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 16);
            this.label13.TabIndex = 10;
            this.label13.Text = "Screen Gap (Top)";
            // 
            // label15
            // 
            this.structuresExtender.SetAttributeName(this.label15, null);
            this.structuresExtender.SetAttributeTypeName(this.label15, null);
            this.label15.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label15, null);
            this.label15.Location = new System.Drawing.Point(3, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 16);
            this.label15.TabIndex = 23;
            this.label15.Text = "Overall Weight";
            // 
            // HeightOffsetBottom
            // 
            this.structuresExtender.SetAttributeName(this.HeightOffsetBottom, null);
            this.structuresExtender.SetAttributeTypeName(this.HeightOffsetBottom, null);
            this.structuresExtender.SetBindPropertyName(this.HeightOffsetBottom, null);
            this.HeightOffsetBottom.Location = new System.Drawing.Point(163, 89);
            this.HeightOffsetBottom.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.HeightOffsetBottom.Name = "HeightOffsetBottom";
            this.HeightOffsetBottom.Size = new System.Drawing.Size(68, 22);
            this.HeightOffsetBottom.TabIndex = 1;
            this.HeightOffsetBottom.Text = "8.0";
            this.HeightOffsetBottom.TextChanged += new System.EventHandler(this.HeightOffsetBottom_TextChanged);
            this.HeightOffsetBottom.Validating += new System.ComponentModel.CancelEventHandler(this.HeightOffsetBottom_Validating);
            // 
            // HeightOffsetTop
            // 
            this.structuresExtender.SetAttributeName(this.HeightOffsetTop, null);
            this.structuresExtender.SetAttributeTypeName(this.HeightOffsetTop, null);
            this.structuresExtender.SetBindPropertyName(this.HeightOffsetTop, null);
            this.HeightOffsetTop.Location = new System.Drawing.Point(163, 65);
            this.HeightOffsetTop.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.HeightOffsetTop.Name = "HeightOffsetTop";
            this.HeightOffsetTop.Size = new System.Drawing.Size(68, 22);
            this.HeightOffsetTop.TabIndex = 0;
            this.HeightOffsetTop.Text = "8.0";
            this.HeightOffsetTop.TextChanged += new System.EventHandler(this.HeightOffsetTop_TextChanged);
            this.HeightOffsetTop.Validating += new System.ComponentModel.CancelEventHandler(this.HeightOffsetTop_Validating);
            // 
            // BillBoardDepth
            // 
            this.structuresExtender.SetAttributeName(this.BillBoardDepth, null);
            this.structuresExtender.SetAttributeTypeName(this.BillBoardDepth, null);
            this.BillBoardDepth.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BillBoardDepth, null);
            this.BillBoardDepth.Location = new System.Drawing.Point(163, 32);
            this.BillBoardDepth.Name = "BillBoardDepth";
            this.BillBoardDepth.Size = new System.Drawing.Size(14, 16);
            this.BillBoardDepth.TabIndex = 22;
            this.BillBoardDepth.Text = "0";
            // 
            // BillboardWeight
            // 
            this.structuresExtender.SetAttributeName(this.BillboardWeight, null);
            this.structuresExtender.SetAttributeTypeName(this.BillboardWeight, null);
            this.BillboardWeight.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BillboardWeight, null);
            this.BillboardWeight.Location = new System.Drawing.Point(163, 48);
            this.BillboardWeight.Name = "BillboardWeight";
            this.BillboardWeight.Size = new System.Drawing.Size(14, 16);
            this.BillboardWeight.TabIndex = 24;
            this.BillboardWeight.Text = "0";
            this.BillboardWeight.Click += new System.EventHandler(this.BillboardWeight_Click);
            // 
            // groupBox2
            // 
            this.structuresExtender.SetAttributeName(this.groupBox2, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox2, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox2, null);
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Location = new System.Drawing.Point(524, 626);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(319, 121);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cabinet Bolts";
            // 
            // tableLayoutPanel3
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel3, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel3, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel3, null);
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.BoltDiameter, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.HoleHorizontalOffset, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.HoleVerticalOffset, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(7, 22);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(307, 91);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // BoltDiameter
            // 
            this.structuresExtender.SetAttributeName(this.BoltDiameter, null);
            this.structuresExtender.SetAttributeTypeName(this.BoltDiameter, null);
            this.structuresExtender.SetBindPropertyName(this.BoltDiameter, null);
            this.BoltDiameter.Location = new System.Drawing.Point(163, 54);
            this.BoltDiameter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoltDiameter.Name = "BoltDiameter";
            this.BoltDiameter.Size = new System.Drawing.Size(68, 22);
            this.BoltDiameter.TabIndex = 2;
            this.BoltDiameter.Text = "10.0";
            this.BoltDiameter.TextChanged += new System.EventHandler(this.BoltDiameter_TextChanged);
            this.BoltDiameter.Validating += new System.ComponentModel.CancelEventHandler(this.BoltDiameter_Validating);
            // 
            // label9
            // 
            this.structuresExtender.SetAttributeName(this.label9, null);
            this.structuresExtender.SetAttributeTypeName(this.label9, null);
            this.label9.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label9, null);
            this.label9.Location = new System.Drawing.Point(3, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Bolt Diameter";
            // 
            // label1
            // 
            this.structuresExtender.SetAttributeName(this.label1, null);
            this.structuresExtender.SetAttributeTypeName(this.label1, null);
            this.label1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label1, null);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bolt Horizontal Offsets";
            // 
            // HoleHorizontalOffset
            // 
            this.structuresExtender.SetAttributeName(this.HoleHorizontalOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.HoleHorizontalOffset, null);
            this.structuresExtender.SetBindPropertyName(this.HoleHorizontalOffset, null);
            this.HoleHorizontalOffset.Location = new System.Drawing.Point(163, 2);
            this.HoleHorizontalOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HoleHorizontalOffset.Name = "HoleHorizontalOffset";
            this.HoleHorizontalOffset.Size = new System.Drawing.Size(68, 22);
            this.HoleHorizontalOffset.TabIndex = 0;
            this.HoleHorizontalOffset.Text = "65.0";
            this.HoleHorizontalOffset.TextChanged += new System.EventHandler(this.HoleHorizontalOffset_TextChanged);
            this.HoleHorizontalOffset.Validating += new System.ComponentModel.CancelEventHandler(this.HoleHorizontalOffset_Validating);
            // 
            // HoleVerticalOffset
            // 
            this.structuresExtender.SetAttributeName(this.HoleVerticalOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.HoleVerticalOffset, null);
            this.structuresExtender.SetBindPropertyName(this.HoleVerticalOffset, null);
            this.HoleVerticalOffset.Location = new System.Drawing.Point(163, 28);
            this.HoleVerticalOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HoleVerticalOffset.Name = "HoleVerticalOffset";
            this.HoleVerticalOffset.Size = new System.Drawing.Size(68, 22);
            this.HoleVerticalOffset.TabIndex = 1;
            this.HoleVerticalOffset.Text = "50";
            this.HoleVerticalOffset.TextChanged += new System.EventHandler(this.HoleVerticalOffset_TextChanged);
            this.HoleVerticalOffset.Validating += new System.ComponentModel.CancelEventHandler(this.HoleVerticalOffset_Validating);
            // 
            // label8
            // 
            this.structuresExtender.SetAttributeName(this.label8, null);
            this.structuresExtender.SetAttributeTypeName(this.label8, null);
            this.label8.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label8, null);
            this.label8.Location = new System.Drawing.Point(3, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 16);
            this.label8.TabIndex = 1;
            this.label8.Text = "Bolt Vertical Offsets";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tableLayoutPanel2
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel2, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel2, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel2, null);
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Welding, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 25);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(207, 38);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label17
            // 
            this.structuresExtender.SetAttributeName(this.label17, null);
            this.structuresExtender.SetAttributeTypeName(this.label17, null);
            this.label17.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label17, null);
            this.label17.Location = new System.Drawing.Point(3, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 16);
            this.label17.TabIndex = 4;
            this.label17.Text = "Welding Offset";
            // 
            // Welding
            // 
            this.structuresExtender.SetAttributeName(this.Welding, null);
            this.structuresExtender.SetAttributeTypeName(this.Welding, null);
            this.structuresExtender.SetBindPropertyName(this.Welding, null);
            this.Welding.Location = new System.Drawing.Point(106, 2);
            this.Welding.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Welding.Name = "Welding";
            this.Welding.Size = new System.Drawing.Size(68, 22);
            this.Welding.TabIndex = 23;
            this.Welding.Text = "1.0";
            this.Welding.TextChanged += new System.EventHandler(this.Welding_TextChanged);
            this.Welding.Validating += new System.ComponentModel.CancelEventHandler(this.Welding_Validating);
            // 
            // MeshThickLabel
            // 
            this.structuresExtender.SetAttributeName(this.MeshThickLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.MeshThickLabel, null);
            this.MeshThickLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.MeshThickLabel, null);
            this.MeshThickLabel.Location = new System.Drawing.Point(3, 0);
            this.MeshThickLabel.Name = "MeshThickLabel";
            this.MeshThickLabel.Size = new System.Drawing.Size(127, 16);
            this.MeshThickLabel.TabIndex = 5;
            this.MeshThickLabel.Text = "Walkway Thickness";
            // 
            // MeshThickness
            // 
            this.structuresExtender.SetAttributeName(this.MeshThickness, null);
            this.structuresExtender.SetAttributeTypeName(this.MeshThickness, null);
            this.structuresExtender.SetBindPropertyName(this.MeshThickness, null);
            this.MeshThickness.Location = new System.Drawing.Point(163, 2);
            this.MeshThickness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MeshThickness.Name = "MeshThickness";
            this.MeshThickness.Size = new System.Drawing.Size(68, 22);
            this.MeshThickness.TabIndex = 0;
            this.MeshThickness.Text = "14.0";
            this.MeshThickness.TextChanged += new System.EventHandler(this.MeshThickness_TextChanged);
            this.MeshThickness.Validating += new System.ComponentModel.CancelEventHandler(this.MeshThickness_Validating);
            // 
            // RailingSpace2
            // 
            this.structuresExtender.SetAttributeName(this.RailingSpace2, null);
            this.structuresExtender.SetAttributeTypeName(this.RailingSpace2, null);
            this.structuresExtender.SetBindPropertyName(this.RailingSpace2, null);
            this.RailingSpace2.Location = new System.Drawing.Point(116, 2);
            this.RailingSpace2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RailingSpace2.Name = "RailingSpace2";
            this.RailingSpace2.Size = new System.Drawing.Size(68, 22);
            this.RailingSpace2.TabIndex = 0;
            this.RailingSpace2.Text = "550.0";
            this.RailingSpace2.TextChanged += new System.EventHandler(this.RailingSpace2_TextChanged);
            this.RailingSpace2.Validating += new System.ComponentModel.CancelEventHandler(this.RailingSpace2_Validating);
            // 
            // RailingSpace1
            // 
            this.structuresExtender.SetAttributeName(this.RailingSpace1, null);
            this.structuresExtender.SetAttributeTypeName(this.RailingSpace1, null);
            this.structuresExtender.SetBindPropertyName(this.RailingSpace1, null);
            this.RailingSpace1.Location = new System.Drawing.Point(343, 2);
            this.RailingSpace1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RailingSpace1.Name = "RailingSpace1";
            this.RailingSpace1.Size = new System.Drawing.Size(68, 22);
            this.RailingSpace1.TabIndex = 1;
            this.RailingSpace1.Text = "560.0";
            this.RailingSpace1.TextChanged += new System.EventHandler(this.RailingSpace1_TextChanged);
            this.RailingSpace1.Validating += new System.ComponentModel.CancelEventHandler(this.RailingSpace1_Validating);
            // 
            // label19
            // 
            this.structuresExtender.SetAttributeName(this.label19, null);
            this.structuresExtender.SetAttributeTypeName(this.label19, null);
            this.label19.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label19, null);
            this.label19.Location = new System.Drawing.Point(230, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(91, 32);
            this.label19.TabIndex = 6;
            this.label19.Text = "Lower Railing Spacing";
            // 
            // label20
            // 
            this.structuresExtender.SetAttributeName(this.label20, null);
            this.structuresExtender.SetAttributeTypeName(this.label20, null);
            this.label20.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label20, null);
            this.label20.Location = new System.Drawing.Point(3, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(93, 32);
            this.label20.TabIndex = 7;
            this.label20.Text = "Upper Railing Spacing";
            // 
            // groupBox4
            // 
            this.structuresExtender.SetAttributeName(this.groupBox4, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox4, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox4, null);
            this.groupBox4.Controls.Add(this.tableLayoutPanel8);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.tabControl1);
            this.groupBox4.Controls.Add(this.WalersSumLabel);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.WalersList);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.tableLayoutPanel7);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.StructureControl);
            this.groupBox4.Controls.Add(this.BeamsSumLabel);
            this.groupBox4.Controls.Add(this.BeamsLabel);
            this.groupBox4.Controls.Add(this.HorizontalBeamsList);
            this.groupBox4.Location = new System.Drawing.Point(31, 322);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(485, 554);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Frame Structure";
            // 
            // tableLayoutPanel8
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel8, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel8, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel8, null);
            this.tableLayoutPanel8.ColumnCount = 5;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.LowerWalerSpacing, 4, 0);
            this.tableLayoutPanel8.Controls.Add(this.UpperWalerSpacing, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.label31, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.label32, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(13, 226);
            this.tableLayoutPanel8.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(460, 34);
            this.tableLayoutPanel8.TabIndex = 21;
            // 
            // LowerWalerSpacing
            // 
            this.structuresExtender.SetAttributeName(this.LowerWalerSpacing, null);
            this.structuresExtender.SetAttributeTypeName(this.LowerWalerSpacing, null);
            this.structuresExtender.SetBindPropertyName(this.LowerWalerSpacing, null);
            this.LowerWalerSpacing.Location = new System.Drawing.Point(343, 2);
            this.LowerWalerSpacing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LowerWalerSpacing.Name = "LowerWalerSpacing";
            this.LowerWalerSpacing.Size = new System.Drawing.Size(68, 22);
            this.LowerWalerSpacing.TabIndex = 13;
            this.LowerWalerSpacing.Text = "350.0";
            this.LowerWalerSpacing.TextChanged += new System.EventHandler(this.LowerWalerSpacing_TextChanged);
            this.LowerWalerSpacing.Validating += new System.ComponentModel.CancelEventHandler(this.LowerWalerSpacing_Validating);
            // 
            // UpperWalerSpacing
            // 
            this.structuresExtender.SetAttributeName(this.UpperWalerSpacing, null);
            this.structuresExtender.SetAttributeTypeName(this.UpperWalerSpacing, null);
            this.structuresExtender.SetBindPropertyName(this.UpperWalerSpacing, null);
            this.UpperWalerSpacing.Location = new System.Drawing.Point(116, 2);
            this.UpperWalerSpacing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UpperWalerSpacing.Name = "UpperWalerSpacing";
            this.UpperWalerSpacing.Size = new System.Drawing.Size(68, 22);
            this.UpperWalerSpacing.TabIndex = 12;
            this.UpperWalerSpacing.Text = "350.0";
            this.UpperWalerSpacing.TextChanged += new System.EventHandler(this.UpperWalerSpacing_TextChanged);
            this.UpperWalerSpacing.Validating += new System.ComponentModel.CancelEventHandler(this.UpperWalerSpacing_Validating);
            // 
            // label31
            // 
            this.structuresExtender.SetAttributeName(this.label31, null);
            this.structuresExtender.SetAttributeTypeName(this.label31, null);
            this.label31.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label31, null);
            this.label31.Location = new System.Drawing.Point(230, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(85, 32);
            this.label31.TabIndex = 6;
            this.label31.Text = "Lower Waler Spacing";
            // 
            // label32
            // 
            this.structuresExtender.SetAttributeName(this.label32, null);
            this.structuresExtender.SetAttributeTypeName(this.label32, null);
            this.label32.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label32, null);
            this.label32.Location = new System.Drawing.Point(3, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(87, 32);
            this.label32.TabIndex = 7;
            this.label32.Text = "Upper Waler Spacing";
            // 
            // label28
            // 
            this.structuresExtender.SetAttributeName(this.label28, null);
            this.structuresExtender.SetAttributeTypeName(this.label28, null);
            this.label28.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label28, null);
            this.label28.Location = new System.Drawing.Point(268, 276);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(50, 16);
            this.label28.TabIndex = 19;
            this.label28.Text = "Walers";
            // 
            // tabControl1
            // 
            this.structuresExtender.SetAttributeName(this.tabControl1, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl1, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl1, null);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 268);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(251, 134);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.structuresExtender.SetAttributeName(this.tabPage1, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage1, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage1, null);
            this.tabPage1.Controls.Add(this.WalerNumberLabel);
            this.tabPage1.Controls.Add(this.WalerManualRadio);
            this.tabPage1.Controls.Add(this.WalerAddValue);
            this.tabPage1.Controls.Add(this.WalerAddButton);
            this.tabPage1.Controls.Add(this.WalerAutoRadio);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(243, 105);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // WalerNumberLabel
            // 
            this.structuresExtender.SetAttributeName(this.WalerNumberLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerNumberLabel, null);
            this.WalerNumberLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.WalerNumberLabel, null);
            this.WalerNumberLabel.Location = new System.Drawing.Point(127, 39);
            this.WalerNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WalerNumberLabel.Name = "WalerNumberLabel";
            this.WalerNumberLabel.Size = new System.Drawing.Size(74, 16);
            this.WalerNumberLabel.TabIndex = 7;
            this.WalerNumberLabel.Text = "No. Walers";
            // 
            // WalerManualRadio
            // 
            this.structuresExtender.SetAttributeName(this.WalerManualRadio, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerManualRadio, null);
            this.WalerManualRadio.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.WalerManualRadio, null);
            this.WalerManualRadio.Location = new System.Drawing.Point(79, 7);
            this.WalerManualRadio.Margin = new System.Windows.Forms.Padding(4);
            this.WalerManualRadio.Name = "WalerManualRadio";
            this.WalerManualRadio.Size = new System.Drawing.Size(72, 20);
            this.WalerManualRadio.TabIndex = 15;
            this.WalerManualRadio.TabStop = true;
            this.WalerManualRadio.Text = "Manual";
            this.WalerManualRadio.UseVisualStyleBackColor = true;
            // 
            // WalerAddValue
            // 
            this.structuresExtender.SetAttributeName(this.WalerAddValue, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerAddValue, null);
            this.structuresExtender.SetBindPropertyName(this.WalerAddValue, null);
            this.WalerAddValue.Location = new System.Drawing.Point(8, 36);
            this.WalerAddValue.Margin = new System.Windows.Forms.Padding(4);
            this.WalerAddValue.Name = "WalerAddValue";
            this.WalerAddValue.Size = new System.Drawing.Size(109, 22);
            this.WalerAddValue.TabIndex = 17;
            this.WalerAddValue.Text = "1";
            this.WalerAddValue.TextChanged += new System.EventHandler(this.WalerAddValue_TextChanged);
            // 
            // WalerAddButton
            // 
            this.structuresExtender.SetAttributeName(this.WalerAddButton, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerAddButton, null);
            this.structuresExtender.SetBindPropertyName(this.WalerAddButton, null);
            this.WalerAddButton.Enabled = false;
            this.WalerAddButton.Location = new System.Drawing.Point(8, 68);
            this.WalerAddButton.Margin = new System.Windows.Forms.Padding(4);
            this.WalerAddButton.Name = "WalerAddButton";
            this.WalerAddButton.Size = new System.Drawing.Size(111, 25);
            this.WalerAddButton.TabIndex = 18;
            this.WalerAddButton.Text = "Add";
            this.WalerAddButton.UseVisualStyleBackColor = true;
            this.WalerAddButton.Click += new System.EventHandler(this.WalerAddButton_Click);
            // 
            // WalerAutoRadio
            // 
            this.structuresExtender.SetAttributeName(this.WalerAutoRadio, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerAutoRadio, null);
            this.WalerAutoRadio.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.WalerAutoRadio, null);
            this.WalerAutoRadio.Checked = true;
            this.WalerAutoRadio.Location = new System.Drawing.Point(8, 7);
            this.WalerAutoRadio.Margin = new System.Windows.Forms.Padding(4);
            this.WalerAutoRadio.Name = "WalerAutoRadio";
            this.WalerAutoRadio.Size = new System.Drawing.Size(55, 20);
            this.WalerAutoRadio.TabIndex = 15;
            this.WalerAutoRadio.TabStop = true;
            this.WalerAutoRadio.Text = "Auto";
            this.WalerAutoRadio.UseVisualStyleBackColor = true;
            this.WalerAutoRadio.CheckedChanged += new System.EventHandler(this.WalerAutoRadio_CheckedChanged);
            // 
            // tabPage2
            // 
            this.structuresExtender.SetAttributeName(this.tabPage2, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage2, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage2, null);
            this.tabPage2.Controls.Add(this.WalerResetButton);
            this.tabPage2.Controls.Add(this.WalerRemoveButton);
            this.tabPage2.Controls.Add(this.WalerEditValue);
            this.tabPage2.Controls.Add(this.WalerEditButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(243, 105);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // WalerResetButton
            // 
            this.structuresExtender.SetAttributeName(this.WalerResetButton, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerResetButton, null);
            this.structuresExtender.SetBindPropertyName(this.WalerResetButton, null);
            this.WalerResetButton.Enabled = false;
            this.WalerResetButton.Location = new System.Drawing.Point(8, 68);
            this.WalerResetButton.Margin = new System.Windows.Forms.Padding(4);
            this.WalerResetButton.Name = "WalerResetButton";
            this.WalerResetButton.Size = new System.Drawing.Size(111, 25);
            this.WalerResetButton.TabIndex = 10;
            this.WalerResetButton.Text = "Remove All";
            this.WalerResetButton.UseVisualStyleBackColor = true;
            this.WalerResetButton.Click += new System.EventHandler(this.WalerResetButton_Click);
            // 
            // WalerRemoveButton
            // 
            this.structuresExtender.SetAttributeName(this.WalerRemoveButton, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerRemoveButton, null);
            this.structuresExtender.SetBindPropertyName(this.WalerRemoveButton, null);
            this.WalerRemoveButton.Enabled = false;
            this.WalerRemoveButton.Location = new System.Drawing.Point(123, 68);
            this.WalerRemoveButton.Margin = new System.Windows.Forms.Padding(4);
            this.WalerRemoveButton.Name = "WalerRemoveButton";
            this.WalerRemoveButton.Size = new System.Drawing.Size(107, 25);
            this.WalerRemoveButton.TabIndex = 2021;
            this.WalerRemoveButton.Text = "Remove";
            this.WalerRemoveButton.UseVisualStyleBackColor = true;
            this.WalerRemoveButton.Click += new System.EventHandler(this.WalerRemoveButton_Click);
            // 
            // WalerEditValue
            // 
            this.structuresExtender.SetAttributeName(this.WalerEditValue, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerEditValue, null);
            this.structuresExtender.SetBindPropertyName(this.WalerEditValue, null);
            this.WalerEditValue.Enabled = false;
            this.WalerEditValue.Location = new System.Drawing.Point(8, 36);
            this.WalerEditValue.Margin = new System.Windows.Forms.Padding(4);
            this.WalerEditValue.Name = "WalerEditValue";
            this.WalerEditValue.Size = new System.Drawing.Size(109, 22);
            this.WalerEditValue.TabIndex = 19;
            // 
            // WalerEditButton
            // 
            this.structuresExtender.SetAttributeName(this.WalerEditButton, null);
            this.structuresExtender.SetAttributeTypeName(this.WalerEditButton, null);
            this.structuresExtender.SetBindPropertyName(this.WalerEditButton, null);
            this.WalerEditButton.Enabled = false;
            this.WalerEditButton.Location = new System.Drawing.Point(123, 36);
            this.WalerEditButton.Margin = new System.Windows.Forms.Padding(4);
            this.WalerEditButton.Name = "WalerEditButton";
            this.WalerEditButton.Size = new System.Drawing.Size(107, 25);
            this.WalerEditButton.TabIndex = 20;
            this.WalerEditButton.Text = "Edit";
            this.WalerEditButton.UseVisualStyleBackColor = true;
            this.WalerEditButton.Click += new System.EventHandler(this.WalerEditButton_Click);
            // 
            // WalersSumLabel
            // 
            this.structuresExtender.SetAttributeName(this.WalersSumLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.WalersSumLabel, null);
            this.WalersSumLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.WalersSumLabel, null);
            this.WalersSumLabel.Location = new System.Drawing.Point(335, 400);
            this.WalersSumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WalersSumLabel.Name = "WalersSumLabel";
            this.WalersSumLabel.Size = new System.Drawing.Size(14, 16);
            this.WalersSumLabel.TabIndex = 18;
            this.WalersSumLabel.Text = "0";
            // 
            // label30
            // 
            this.structuresExtender.SetAttributeName(this.label30, null);
            this.structuresExtender.SetAttributeTypeName(this.label30, null);
            this.label30.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label30, null);
            this.label30.Location = new System.Drawing.Point(268, 400);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(56, 16);
            this.label30.TabIndex = 17;
            this.label30.Text = "Walers: ";
            // 
            // WalersList
            // 
            this.WalersList.AllowDrop = true;
            this.structuresExtender.SetAttributeName(this.WalersList, null);
            this.structuresExtender.SetAttributeTypeName(this.WalersList, null);
            this.structuresExtender.SetBindPropertyName(this.WalersList, null);
            this.WalersList.FormattingEnabled = true;
            this.WalersList.ItemHeight = 16;
            this.WalersList.Location = new System.Drawing.Point(272, 295);
            this.WalersList.Margin = new System.Windows.Forms.Padding(4);
            this.WalersList.Name = "WalersList";
            this.WalersList.Size = new System.Drawing.Size(200, 100);
            this.WalersList.TabIndex = 22;
            this.WalersList.SelectedIndexChanged += new System.EventHandler(this.WalersList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.structuresExtender.SetAttributeName(this.groupBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox1, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox1, null);
            this.groupBox1.Controls.Add(this.tableLayoutPanel6);
            this.groupBox1.Location = new System.Drawing.Point(253, 421);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(225, 127);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Diagonal Beam";
            // 
            // tableLayoutPanel6
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel6, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel6, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel6, null);
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.label23, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.CornerOffset, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.CornerOffsetLabel, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.TopOffsetLabel, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.DiagonalBottomOffset, 1, 2);
            this.tableLayoutPanel6.Controls.Add(this.DiagonalTopOffset, 1, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(8, 21);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(207, 101);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // label23
            // 
            this.structuresExtender.SetAttributeName(this.label23, null);
            this.structuresExtender.SetAttributeTypeName(this.label23, null);
            this.label23.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label23, null);
            this.label23.Location = new System.Drawing.Point(3, 52);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(86, 16);
            this.label23.TabIndex = 18;
            this.label23.Text = "Bottom Offset";
            // 
            // CornerOffset
            // 
            this.structuresExtender.SetAttributeName(this.CornerOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.CornerOffset, null);
            this.structuresExtender.SetBindPropertyName(this.CornerOffset, null);
            this.CornerOffset.Location = new System.Drawing.Point(106, 2);
            this.CornerOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CornerOffset.Name = "CornerOffset";
            this.CornerOffset.Size = new System.Drawing.Size(67, 22);
            this.CornerOffset.TabIndex = 26;
            this.CornerOffset.Text = "10.0";
            this.CornerOffset.TextChanged += new System.EventHandler(this.CornerOffset_TextChanged);
            this.CornerOffset.Validating += new System.ComponentModel.CancelEventHandler(this.CornerOffset_Validating);
            // 
            // CornerOffsetLabel
            // 
            this.structuresExtender.SetAttributeName(this.CornerOffsetLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.CornerOffsetLabel, null);
            this.CornerOffsetLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.CornerOffsetLabel, null);
            this.CornerOffsetLabel.Location = new System.Drawing.Point(3, 0);
            this.CornerOffsetLabel.Name = "CornerOffsetLabel";
            this.CornerOffsetLabel.Size = new System.Drawing.Size(84, 16);
            this.CornerOffsetLabel.TabIndex = 0;
            this.CornerOffsetLabel.Text = "Corner Offset";
            // 
            // TopOffsetLabel
            // 
            this.structuresExtender.SetAttributeName(this.TopOffsetLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.TopOffsetLabel, null);
            this.TopOffsetLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.TopOffsetLabel, null);
            this.TopOffsetLabel.Location = new System.Drawing.Point(3, 26);
            this.TopOffsetLabel.Name = "TopOffsetLabel";
            this.TopOffsetLabel.Size = new System.Drawing.Size(69, 16);
            this.TopOffsetLabel.TabIndex = 3;
            this.TopOffsetLabel.Text = "Top Offset";
            // 
            // DiagonalBottomOffset
            // 
            this.structuresExtender.SetAttributeName(this.DiagonalBottomOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.DiagonalBottomOffset, null);
            this.structuresExtender.SetBindPropertyName(this.DiagonalBottomOffset, null);
            this.DiagonalBottomOffset.Location = new System.Drawing.Point(106, 54);
            this.DiagonalBottomOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DiagonalBottomOffset.Name = "DiagonalBottomOffset";
            this.DiagonalBottomOffset.Size = new System.Drawing.Size(67, 22);
            this.DiagonalBottomOffset.TabIndex = 28;
            this.DiagonalBottomOffset.Text = "0.0";
            this.DiagonalBottomOffset.TextChanged += new System.EventHandler(this.DiagonalBottomOffset_TextChanged);
            this.DiagonalBottomOffset.Validating += new System.ComponentModel.CancelEventHandler(this.DiagonalBottomOffset_Validating);
            // 
            // DiagonalTopOffset
            // 
            this.structuresExtender.SetAttributeName(this.DiagonalTopOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.DiagonalTopOffset, null);
            this.structuresExtender.SetBindPropertyName(this.DiagonalTopOffset, null);
            this.DiagonalTopOffset.Location = new System.Drawing.Point(106, 28);
            this.DiagonalTopOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DiagonalTopOffset.Name = "DiagonalTopOffset";
            this.DiagonalTopOffset.Size = new System.Drawing.Size(67, 22);
            this.DiagonalTopOffset.TabIndex = 27;
            this.DiagonalTopOffset.Text = "0.0";
            this.DiagonalTopOffset.TextChanged += new System.EventHandler(this.DiagonalTopOffset_TextChanged);
            this.DiagonalTopOffset.Validating += new System.ComponentModel.CancelEventHandler(this.DiagonalTopOffset_Validating);
            // 
            // groupBox5
            // 
            this.structuresExtender.SetAttributeName(this.groupBox5, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox5, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox5, null);
            this.groupBox5.Controls.Add(this.tableLayoutPanel2);
            this.groupBox5.Location = new System.Drawing.Point(8, 421);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(225, 126);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Features";
            // 
            // tableLayoutPanel7
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel7, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel7, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel7, null);
            this.tableLayoutPanel7.ColumnCount = 5;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.RailingSpace1, 4, 0);
            this.tableLayoutPanel7.Controls.Add(this.RailingSpace2, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.label19, 3, 0);
            this.tableLayoutPanel7.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(12, 25);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(460, 34);
            this.tableLayoutPanel7.TabIndex = 7;
            // 
            // label21
            // 
            this.structuresExtender.SetAttributeName(this.label21, null);
            this.structuresExtender.SetAttributeTypeName(this.label21, null);
            this.label21.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label21, null);
            this.label21.Location = new System.Drawing.Point(267, 71);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(147, 16);
            this.label21.TabIndex = 6;
            this.label21.Text = "Back Horizontal Beams";
            // 
            // StructureControl
            // 
            this.structuresExtender.SetAttributeName(this.StructureControl, null);
            this.structuresExtender.SetAttributeTypeName(this.StructureControl, null);
            this.structuresExtender.SetBindPropertyName(this.StructureControl, null);
            this.StructureControl.Controls.Add(this.StructureAddTab);
            this.StructureControl.Controls.Add(this.StructureEditTab);
            this.StructureControl.Location = new System.Drawing.Point(12, 65);
            this.StructureControl.Margin = new System.Windows.Forms.Padding(4);
            this.StructureControl.Name = "StructureControl";
            this.StructureControl.SelectedIndex = 0;
            this.StructureControl.Size = new System.Drawing.Size(251, 134);
            this.StructureControl.TabIndex = 2;
            // 
            // StructureAddTab
            // 
            this.structuresExtender.SetAttributeName(this.StructureAddTab, null);
            this.structuresExtender.SetAttributeTypeName(this.StructureAddTab, null);
            this.structuresExtender.SetBindPropertyName(this.StructureAddTab, null);
            this.StructureAddTab.Controls.Add(this.StructureManualRadio);
            this.StructureAddTab.Controls.Add(this.HorizontalBeamsAddValue);
            this.StructureAddTab.Controls.Add(this.HorizontalBeamsAddButton);
            this.StructureAddTab.Controls.Add(this.StructureAutoRadio);
            this.StructureAddTab.Location = new System.Drawing.Point(4, 25);
            this.StructureAddTab.Margin = new System.Windows.Forms.Padding(4);
            this.StructureAddTab.Name = "StructureAddTab";
            this.StructureAddTab.Padding = new System.Windows.Forms.Padding(4);
            this.StructureAddTab.Size = new System.Drawing.Size(243, 105);
            this.StructureAddTab.TabIndex = 0;
            this.StructureAddTab.Text = "Add";
            this.StructureAddTab.UseVisualStyleBackColor = true;
            // 
            // StructureManualRadio
            // 
            this.structuresExtender.SetAttributeName(this.StructureManualRadio, null);
            this.structuresExtender.SetAttributeTypeName(this.StructureManualRadio, null);
            this.StructureManualRadio.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.StructureManualRadio, null);
            this.StructureManualRadio.Location = new System.Drawing.Point(79, 7);
            this.StructureManualRadio.Margin = new System.Windows.Forms.Padding(4);
            this.StructureManualRadio.Name = "StructureManualRadio";
            this.StructureManualRadio.Size = new System.Drawing.Size(72, 20);
            this.StructureManualRadio.TabIndex = 4;
            this.StructureManualRadio.TabStop = true;
            this.StructureManualRadio.Text = "Manual";
            this.StructureManualRadio.UseVisualStyleBackColor = true;
            this.StructureManualRadio.CheckedChanged += new System.EventHandler(this.StructureManualRadio_CheckedChanged);
            // 
            // HorizontalBeamsAddValue
            // 
            this.structuresExtender.SetAttributeName(this.HorizontalBeamsAddValue, null);
            this.structuresExtender.SetAttributeTypeName(this.HorizontalBeamsAddValue, null);
            this.structuresExtender.SetBindPropertyName(this.HorizontalBeamsAddValue, null);
            this.HorizontalBeamsAddValue.Enabled = false;
            this.HorizontalBeamsAddValue.Location = new System.Drawing.Point(8, 36);
            this.HorizontalBeamsAddValue.Margin = new System.Windows.Forms.Padding(4);
            this.HorizontalBeamsAddValue.Name = "HorizontalBeamsAddValue";
            this.HorizontalBeamsAddValue.Size = new System.Drawing.Size(109, 22);
            this.HorizontalBeamsAddValue.TabIndex = 5;
            // 
            // HorizontalBeamsAddButton
            // 
            this.structuresExtender.SetAttributeName(this.HorizontalBeamsAddButton, null);
            this.structuresExtender.SetAttributeTypeName(this.HorizontalBeamsAddButton, null);
            this.structuresExtender.SetBindPropertyName(this.HorizontalBeamsAddButton, null);
            this.HorizontalBeamsAddButton.Enabled = false;
            this.HorizontalBeamsAddButton.Location = new System.Drawing.Point(8, 68);
            this.HorizontalBeamsAddButton.Margin = new System.Windows.Forms.Padding(4);
            this.HorizontalBeamsAddButton.Name = "HorizontalBeamsAddButton";
            this.HorizontalBeamsAddButton.Size = new System.Drawing.Size(111, 25);
            this.HorizontalBeamsAddButton.TabIndex = 6;
            this.HorizontalBeamsAddButton.Text = "Add";
            this.HorizontalBeamsAddButton.UseVisualStyleBackColor = true;
            this.HorizontalBeamsAddButton.Click += new System.EventHandler(this.HorizontalBeamsAddButton_Click);
            // 
            // StructureAutoRadio
            // 
            this.structuresExtender.SetAttributeName(this.StructureAutoRadio, null);
            this.structuresExtender.SetAttributeTypeName(this.StructureAutoRadio, null);
            this.StructureAutoRadio.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.StructureAutoRadio, null);
            this.StructureAutoRadio.Checked = true;
            this.StructureAutoRadio.Location = new System.Drawing.Point(8, 7);
            this.StructureAutoRadio.Margin = new System.Windows.Forms.Padding(4);
            this.StructureAutoRadio.Name = "StructureAutoRadio";
            this.StructureAutoRadio.Size = new System.Drawing.Size(55, 20);
            this.StructureAutoRadio.TabIndex = 3;
            this.StructureAutoRadio.TabStop = true;
            this.StructureAutoRadio.Text = "Auto";
            this.StructureAutoRadio.UseVisualStyleBackColor = true;
            // 
            // StructureEditTab
            // 
            this.structuresExtender.SetAttributeName(this.StructureEditTab, null);
            this.structuresExtender.SetAttributeTypeName(this.StructureEditTab, null);
            this.structuresExtender.SetBindPropertyName(this.StructureEditTab, null);
            this.StructureEditTab.Controls.Add(this.HorizontalBeamsResetButton);
            this.StructureEditTab.Controls.Add(this.HorizontalBeamsRemoveButton);
            this.StructureEditTab.Controls.Add(this.HorizontalBeamsEditValue);
            this.StructureEditTab.Controls.Add(this.HorizontalBeamsEditButton);
            this.StructureEditTab.Location = new System.Drawing.Point(4, 25);
            this.StructureEditTab.Margin = new System.Windows.Forms.Padding(4);
            this.StructureEditTab.Name = "StructureEditTab";
            this.StructureEditTab.Padding = new System.Windows.Forms.Padding(4);
            this.StructureEditTab.Size = new System.Drawing.Size(243, 105);
            this.StructureEditTab.TabIndex = 1;
            this.StructureEditTab.Text = "Edit";
            this.StructureEditTab.UseVisualStyleBackColor = true;
            // 
            // HorizontalBeamsResetButton
            // 
            this.structuresExtender.SetAttributeName(this.HorizontalBeamsResetButton, null);
            this.structuresExtender.SetAttributeTypeName(this.HorizontalBeamsResetButton, null);
            this.structuresExtender.SetBindPropertyName(this.HorizontalBeamsResetButton, null);
            this.HorizontalBeamsResetButton.Enabled = false;
            this.HorizontalBeamsResetButton.Location = new System.Drawing.Point(8, 68);
            this.HorizontalBeamsResetButton.Margin = new System.Windows.Forms.Padding(4);
            this.HorizontalBeamsResetButton.Name = "HorizontalBeamsResetButton";
            this.HorizontalBeamsResetButton.Size = new System.Drawing.Size(111, 25);
            this.HorizontalBeamsResetButton.TabIndex = 10;
            this.HorizontalBeamsResetButton.TabStop = false;
            this.HorizontalBeamsResetButton.Text = "Remove All";
            this.HorizontalBeamsResetButton.UseVisualStyleBackColor = true;
            this.HorizontalBeamsResetButton.Click += new System.EventHandler(this.HorizontalBeamsResetButton_Click);
            // 
            // HorizontalBeamsRemoveButton
            // 
            this.structuresExtender.SetAttributeName(this.HorizontalBeamsRemoveButton, null);
            this.structuresExtender.SetAttributeTypeName(this.HorizontalBeamsRemoveButton, null);
            this.structuresExtender.SetBindPropertyName(this.HorizontalBeamsRemoveButton, null);
            this.HorizontalBeamsRemoveButton.Enabled = false;
            this.HorizontalBeamsRemoveButton.Location = new System.Drawing.Point(123, 68);
            this.HorizontalBeamsRemoveButton.Margin = new System.Windows.Forms.Padding(4);
            this.HorizontalBeamsRemoveButton.Name = "HorizontalBeamsRemoveButton";
            this.HorizontalBeamsRemoveButton.Size = new System.Drawing.Size(107, 25);
            this.HorizontalBeamsRemoveButton.TabIndex = 9;
            this.HorizontalBeamsRemoveButton.Text = "Remove";
            this.HorizontalBeamsRemoveButton.UseVisualStyleBackColor = true;
            this.HorizontalBeamsRemoveButton.Click += new System.EventHandler(this.HorizontalBeamsRemoveButton_Click);
            // 
            // HorizontalBeamsEditValue
            // 
            this.structuresExtender.SetAttributeName(this.HorizontalBeamsEditValue, null);
            this.structuresExtender.SetAttributeTypeName(this.HorizontalBeamsEditValue, null);
            this.structuresExtender.SetBindPropertyName(this.HorizontalBeamsEditValue, null);
            this.HorizontalBeamsEditValue.Enabled = false;
            this.HorizontalBeamsEditValue.Location = new System.Drawing.Point(8, 36);
            this.HorizontalBeamsEditValue.Margin = new System.Windows.Forms.Padding(4);
            this.HorizontalBeamsEditValue.Name = "HorizontalBeamsEditValue";
            this.HorizontalBeamsEditValue.Size = new System.Drawing.Size(109, 22);
            this.HorizontalBeamsEditValue.TabIndex = 7;
            // 
            // HorizontalBeamsEditButton
            // 
            this.structuresExtender.SetAttributeName(this.HorizontalBeamsEditButton, null);
            this.structuresExtender.SetAttributeTypeName(this.HorizontalBeamsEditButton, null);
            this.structuresExtender.SetBindPropertyName(this.HorizontalBeamsEditButton, null);
            this.HorizontalBeamsEditButton.Enabled = false;
            this.HorizontalBeamsEditButton.Location = new System.Drawing.Point(123, 36);
            this.HorizontalBeamsEditButton.Margin = new System.Windows.Forms.Padding(4);
            this.HorizontalBeamsEditButton.Name = "HorizontalBeamsEditButton";
            this.HorizontalBeamsEditButton.Size = new System.Drawing.Size(107, 25);
            this.HorizontalBeamsEditButton.TabIndex = 8;
            this.HorizontalBeamsEditButton.Text = "Edit";
            this.HorizontalBeamsEditButton.UseVisualStyleBackColor = true;
            this.HorizontalBeamsEditButton.Click += new System.EventHandler(this.HorizontalBeamsEditButton_Click);
            // 
            // BeamsSumLabel
            // 
            this.structuresExtender.SetAttributeName(this.BeamsSumLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.BeamsSumLabel, null);
            this.BeamsSumLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BeamsSumLabel, null);
            this.BeamsSumLabel.Location = new System.Drawing.Point(321, 197);
            this.BeamsSumLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BeamsSumLabel.Name = "BeamsSumLabel";
            this.BeamsSumLabel.Size = new System.Drawing.Size(14, 16);
            this.BeamsSumLabel.TabIndex = 5;
            this.BeamsSumLabel.Text = "0";
            // 
            // BeamsLabel
            // 
            this.structuresExtender.SetAttributeName(this.BeamsLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.BeamsLabel, null);
            this.BeamsLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BeamsLabel, null);
            this.BeamsLabel.Location = new System.Drawing.Point(267, 197);
            this.BeamsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BeamsLabel.Name = "BeamsLabel";
            this.BeamsLabel.Size = new System.Drawing.Size(56, 16);
            this.BeamsLabel.TabIndex = 4;
            this.BeamsLabel.Text = "Beams: ";
            // 
            // HorizontalBeamsList
            // 
            this.HorizontalBeamsList.AllowDrop = true;
            this.structuresExtender.SetAttributeName(this.HorizontalBeamsList, null);
            this.structuresExtender.SetAttributeTypeName(this.HorizontalBeamsList, null);
            this.structuresExtender.SetBindPropertyName(this.HorizontalBeamsList, null);
            this.HorizontalBeamsList.FormattingEnabled = true;
            this.HorizontalBeamsList.ItemHeight = 16;
            this.HorizontalBeamsList.Location = new System.Drawing.Point(271, 92);
            this.HorizontalBeamsList.Margin = new System.Windows.Forms.Padding(4);
            this.HorizontalBeamsList.Name = "HorizontalBeamsList";
            this.HorizontalBeamsList.Size = new System.Drawing.Size(200, 100);
            this.HorizontalBeamsList.TabIndex = 11;
            this.HorizontalBeamsList.SelectedIndexChanged += new System.EventHandler(this.HorizontalBeamsList_SelectedIndexChanged);
            // 
            // label22
            // 
            this.structuresExtender.SetAttributeName(this.label22, null);
            this.structuresExtender.SetAttributeTypeName(this.label22, null);
            this.label22.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label22, null);
            this.label22.Location = new System.Drawing.Point(1412, 4);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 16);
            this.label22.TabIndex = 9;
            this.label22.Text = "Version 3.2.03";
            this.label22.Click += new System.EventHandler(this.label22_Click);
            // 
            // label24
            // 
            this.structuresExtender.SetAttributeName(this.label24, null);
            this.structuresExtender.SetAttributeTypeName(this.label24, null);
            this.label24.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label24, null);
            this.label24.Location = new System.Drawing.Point(1776, 577);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 16);
            this.label24.TabIndex = 12;
            this.label24.Text = "Top View";
            // 
            // label25
            // 
            this.structuresExtender.SetAttributeName(this.label25, null);
            this.structuresExtender.SetAttributeTypeName(this.label25, null);
            this.label25.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label25, null);
            this.label25.Location = new System.Drawing.Point(1776, 464);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(69, 16);
            this.label25.TabIndex = 13;
            this.label25.Text = "Front View";
            // 
            // label26
            // 
            this.structuresExtender.SetAttributeName(this.label26, null);
            this.structuresExtender.SetAttributeTypeName(this.label26, null);
            this.label26.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label26, null);
            this.label26.Location = new System.Drawing.Point(1307, 412);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 16);
            this.label26.TabIndex = 14;
            this.label26.Text = "Side View 1";
            // 
            // label27
            // 
            this.structuresExtender.SetAttributeName(this.label27, null);
            this.structuresExtender.SetAttributeTypeName(this.label27, null);
            this.label27.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label27, null);
            this.label27.Location = new System.Drawing.Point(1535, 412);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(77, 16);
            this.label27.TabIndex = 15;
            this.label27.Text = "Side View 2";
            // 
            // groupBox6
            // 
            this.structuresExtender.SetAttributeName(this.groupBox6, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox6, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox6, null);
            this.groupBox6.Controls.Add(this.tableLayoutPanel9);
            this.groupBox6.Location = new System.Drawing.Point(523, 752);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(320, 124);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Bracket Bolts";
            // 
            // tableLayoutPanel9
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel9, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel9, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel9, null);
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.Controls.Add(this.ZBracketHoleDiameter, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.BracketBoltDiameter, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.label37, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.BracketBoltStandard, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.label34, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.BracketHoleDiameter, 1, 2);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(7, 22);
            this.tableLayoutPanel9.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 3;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(307, 91);
            this.tableLayoutPanel9.TabIndex = 3;
            // 
            // ZBracketHoleDiameter
            // 
            this.structuresExtender.SetAttributeName(this.ZBracketHoleDiameter, null);
            this.structuresExtender.SetAttributeTypeName(this.ZBracketHoleDiameter, null);
            this.ZBracketHoleDiameter.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.ZBracketHoleDiameter, null);
            this.ZBracketHoleDiameter.Location = new System.Drawing.Point(3, 52);
            this.ZBracketHoleDiameter.Name = "ZBracketHoleDiameter";
            this.ZBracketHoleDiameter.Size = new System.Drawing.Size(94, 16);
            this.ZBracketHoleDiameter.TabIndex = 6;
            this.ZBracketHoleDiameter.Text = "Hole Diameter";
            // 
            // BracketBoltDiameter
            // 
            this.structuresExtender.SetAttributeName(this.BracketBoltDiameter, null);
            this.structuresExtender.SetAttributeTypeName(this.BracketBoltDiameter, null);
            this.structuresExtender.SetBindPropertyName(this.BracketBoltDiameter, null);
            this.BracketBoltDiameter.Location = new System.Drawing.Point(163, 28);
            this.BracketBoltDiameter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BracketBoltDiameter.Name = "BracketBoltDiameter";
            this.BracketBoltDiameter.Size = new System.Drawing.Size(68, 22);
            this.BracketBoltDiameter.TabIndex = 1;
            this.BracketBoltDiameter.Text = "12.0";
            this.BracketBoltDiameter.TextChanged += new System.EventHandler(this.BracketBoltDiameter_TextChanged);
            this.BracketBoltDiameter.Validating += new System.ComponentModel.CancelEventHandler(this.BracketBoltDiameter_Validating);
            // 
            // label37
            // 
            this.structuresExtender.SetAttributeName(this.label37, null);
            this.structuresExtender.SetAttributeTypeName(this.label37, null);
            this.label37.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label37, null);
            this.label37.Location = new System.Drawing.Point(3, 26);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(88, 16);
            this.label37.TabIndex = 5;
            this.label37.Text = "Bolt Diameter";
            // 
            // BracketBoltStandard
            // 
            this.structuresExtender.SetAttributeName(this.BracketBoltStandard, null);
            this.structuresExtender.SetAttributeTypeName(this.BracketBoltStandard, null);
            this.structuresExtender.SetBindPropertyName(this.BracketBoltStandard, null);
            this.BracketBoltStandard.Location = new System.Drawing.Point(163, 2);
            this.BracketBoltStandard.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BracketBoltStandard.Name = "BracketBoltStandard";
            this.BracketBoltStandard.Size = new System.Drawing.Size(68, 22);
            this.BracketBoltStandard.TabIndex = 0;
            this.BracketBoltStandard.Text = "8.8S";
            this.BracketBoltStandard.TextChanged += new System.EventHandler(this.BracketBoltStandard_TextChanged);
            // 
            // label34
            // 
            this.structuresExtender.SetAttributeName(this.label34, null);
            this.structuresExtender.SetAttributeTypeName(this.label34, null);
            this.label34.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label34, null);
            this.label34.Location = new System.Drawing.Point(3, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(88, 16);
            this.label34.TabIndex = 1;
            this.label34.Text = "Bolt Standard";
            // 
            // BracketHoleDiameter
            // 
            this.structuresExtender.SetAttributeName(this.BracketHoleDiameter, null);
            this.structuresExtender.SetAttributeTypeName(this.BracketHoleDiameter, null);
            this.structuresExtender.SetBindPropertyName(this.BracketHoleDiameter, null);
            this.BracketHoleDiameter.Location = new System.Drawing.Point(163, 54);
            this.BracketHoleDiameter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BracketHoleDiameter.Name = "BracketHoleDiameter";
            this.BracketHoleDiameter.Size = new System.Drawing.Size(68, 22);
            this.BracketHoleDiameter.TabIndex = 7;
            this.BracketHoleDiameter.Text = "8";
            // 
            // SeatingPlateOffButton
            // 
            this.structuresExtender.SetAttributeName(this.SeatingPlateOffButton, null);
            this.structuresExtender.SetAttributeTypeName(this.SeatingPlateOffButton, null);
            this.SeatingPlateOffButton.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.SeatingPlateOffButton, null);
            this.SeatingPlateOffButton.Location = new System.Drawing.Point(68, 25);
            this.SeatingPlateOffButton.Margin = new System.Windows.Forms.Padding(4);
            this.SeatingPlateOffButton.Name = "SeatingPlateOffButton";
            this.SeatingPlateOffButton.Size = new System.Drawing.Size(44, 20);
            this.SeatingPlateOffButton.TabIndex = 1;
            this.SeatingPlateOffButton.TabStop = true;
            this.SeatingPlateOffButton.Text = "Off";
            this.SeatingPlateOffButton.UseVisualStyleBackColor = true;
            // 
            // SeatingPlateOnButton
            // 
            this.structuresExtender.SetAttributeName(this.SeatingPlateOnButton, null);
            this.structuresExtender.SetAttributeTypeName(this.SeatingPlateOnButton, null);
            this.SeatingPlateOnButton.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.SeatingPlateOnButton, null);
            this.SeatingPlateOnButton.Checked = true;
            this.SeatingPlateOnButton.Location = new System.Drawing.Point(8, 25);
            this.SeatingPlateOnButton.Margin = new System.Windows.Forms.Padding(4);
            this.SeatingPlateOnButton.Name = "SeatingPlateOnButton";
            this.SeatingPlateOnButton.Size = new System.Drawing.Size(45, 20);
            this.SeatingPlateOnButton.TabIndex = 0;
            this.SeatingPlateOnButton.TabStop = true;
            this.SeatingPlateOnButton.Text = "On";
            this.SeatingPlateOnButton.UseVisualStyleBackColor = true;
            this.SeatingPlateOnButton.CheckedChanged += new System.EventHandler(this.SeatingPlateOnButton_CheckedChanged);
            // 
            // SeatingPlateOffset
            // 
            this.structuresExtender.SetAttributeName(this.SeatingPlateOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.SeatingPlateOffset, null);
            this.structuresExtender.SetBindPropertyName(this.SeatingPlateOffset, null);
            this.SeatingPlateOffset.Location = new System.Drawing.Point(92, 2);
            this.SeatingPlateOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SeatingPlateOffset.Name = "SeatingPlateOffset";
            this.SeatingPlateOffset.Size = new System.Drawing.Size(68, 22);
            this.SeatingPlateOffset.TabIndex = 2;
            this.SeatingPlateOffset.Text = "10.0";
            this.SeatingPlateOffset.TextChanged += new System.EventHandler(this.SeatingPlateOffset_TextChanged);
            this.SeatingPlateOffset.Validating += new System.ComponentModel.CancelEventHandler(this.SeatingPlateOffset_Validating);
            // 
            // ExtrusionLength
            // 
            this.structuresExtender.SetAttributeName(this.ExtrusionLength, null);
            this.structuresExtender.SetAttributeTypeName(this.ExtrusionLength, null);
            this.structuresExtender.SetBindPropertyName(this.ExtrusionLength, null);
            this.ExtrusionLength.Location = new System.Drawing.Point(291, 2);
            this.ExtrusionLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ExtrusionLength.Name = "ExtrusionLength";
            this.ExtrusionLength.Size = new System.Drawing.Size(68, 22);
            this.ExtrusionLength.TabIndex = 3;
            this.ExtrusionLength.Text = "145";
            this.ExtrusionLength.TextChanged += new System.EventHandler(this.ExtrusionLength_TextChanged);
            this.ExtrusionLength.Validating += new System.ComponentModel.CancelEventHandler(this.ExtrusionLength_Validating);
            // 
            // seatingplateextrusionlengthLabel
            // 
            this.structuresExtender.SetAttributeName(this.seatingplateextrusionlengthLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.seatingplateextrusionlengthLabel, null);
            this.seatingplateextrusionlengthLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.seatingplateextrusionlengthLabel, null);
            this.seatingplateextrusionlengthLabel.Location = new System.Drawing.Point(175, 0);
            this.seatingplateextrusionlengthLabel.Name = "seatingplateextrusionlengthLabel";
            this.seatingplateextrusionlengthLabel.Size = new System.Drawing.Size(104, 16);
            this.seatingplateextrusionlengthLabel.TabIndex = 1;
            this.seatingplateextrusionlengthLabel.Text = "Extrusion Length";
            this.seatingplateextrusionlengthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SeatingplateoffsetLabel
            // 
            this.structuresExtender.SetAttributeName(this.SeatingplateoffsetLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.SeatingplateoffsetLabel, null);
            this.SeatingplateoffsetLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.SeatingplateoffsetLabel, null);
            this.SeatingplateoffsetLabel.Location = new System.Drawing.Point(3, 0);
            this.SeatingplateoffsetLabel.Name = "SeatingplateoffsetLabel";
            this.SeatingplateoffsetLabel.Size = new System.Drawing.Size(75, 16);
            this.SeatingplateoffsetLabel.TabIndex = 0;
            this.SeatingplateoffsetLabel.Text = "Plate Offset";
            this.SeatingplateoffsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox7
            // 
            this.structuresExtender.SetAttributeName(this.groupBox7, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox7, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox7, null);
            this.groupBox7.Controls.Add(this.tableLayoutPanel10);
            this.groupBox7.Location = new System.Drawing.Point(1291, 625);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(319, 187);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Walkway Mesh";
            // 
            // tableLayoutPanel10
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel10, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel10, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel10, null);
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.Controls.Add(this.WalkwayWidth, 1, 3);
            this.tableLayoutPanel10.Controls.Add(this.MeshThickness, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.MeshThickLabel, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.WalkwayMaterial, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.MeshMaterialLabel, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.WalkwayWidthLabel, 0, 3);
            this.tableLayoutPanel10.Controls.Add(this.WalkwayClearanceLabel, 0, 2);
            this.tableLayoutPanel10.Controls.Add(this.EAclearanceLabel, 0, 4);
            this.tableLayoutPanel10.Controls.Add(this.WalkwayClearance, 1, 2);
            this.tableLayoutPanel10.Controls.Add(this.EAClearance, 1, 4);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(7, 22);
            this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 5;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(307, 153);
            this.tableLayoutPanel10.TabIndex = 3;
            // 
            // WalkwayWidth
            // 
            this.structuresExtender.SetAttributeName(this.WalkwayWidth, null);
            this.structuresExtender.SetAttributeTypeName(this.WalkwayWidth, null);
            this.structuresExtender.SetBindPropertyName(this.WalkwayWidth, null);
            this.WalkwayWidth.FormattingEnabled = true;
            this.WalkwayWidth.Items.AddRange(new object[] {
            "600",
            "750",
            "900",
            "1200"});
            this.WalkwayWidth.Location = new System.Drawing.Point(164, 82);
            this.WalkwayWidth.Margin = new System.Windows.Forms.Padding(4);
            this.WalkwayWidth.Name = "WalkwayWidth";
            this.WalkwayWidth.Size = new System.Drawing.Size(67, 24);
            this.WalkwayWidth.TabIndex = 31;
            this.WalkwayWidth.Text = "600";
            // 
            // WalkwayMaterial
            // 
            this.structuresExtender.SetAttributeName(this.WalkwayMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.WalkwayMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.WalkwayMaterial, null);
            this.WalkwayMaterial.Location = new System.Drawing.Point(163, 28);
            this.WalkwayMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WalkwayMaterial.Name = "WalkwayMaterial";
            this.WalkwayMaterial.Size = new System.Drawing.Size(68, 22);
            this.WalkwayMaterial.TabIndex = 1;
            this.WalkwayMaterial.Text = "FM14";
            this.WalkwayMaterial.TextChanged += new System.EventHandler(this.WalkwayMaterial_TextChanged);
            // 
            // MeshMaterialLabel
            // 
            this.structuresExtender.SetAttributeName(this.MeshMaterialLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.MeshMaterialLabel, null);
            this.MeshMaterialLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.MeshMaterialLabel, null);
            this.MeshMaterialLabel.Location = new System.Drawing.Point(3, 26);
            this.MeshMaterialLabel.Name = "MeshMaterialLabel";
            this.MeshMaterialLabel.Size = new System.Drawing.Size(113, 16);
            this.MeshMaterialLabel.TabIndex = 1;
            this.MeshMaterialLabel.Text = "Walkway Material";
            // 
            // WalkwayWidthLabel
            // 
            this.structuresExtender.SetAttributeName(this.WalkwayWidthLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.WalkwayWidthLabel, null);
            this.WalkwayWidthLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.WalkwayWidthLabel, null);
            this.WalkwayWidthLabel.Location = new System.Drawing.Point(3, 78);
            this.WalkwayWidthLabel.Name = "WalkwayWidthLabel";
            this.WalkwayWidthLabel.Size = new System.Drawing.Size(99, 16);
            this.WalkwayWidthLabel.TabIndex = 15;
            this.WalkwayWidthLabel.Text = "Walkway Width";
            // 
            // WalkwayClearanceLabel
            // 
            this.structuresExtender.SetAttributeName(this.WalkwayClearanceLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.WalkwayClearanceLabel, null);
            this.WalkwayClearanceLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.WalkwayClearanceLabel, null);
            this.WalkwayClearanceLabel.Location = new System.Drawing.Point(3, 52);
            this.WalkwayClearanceLabel.Name = "WalkwayClearanceLabel";
            this.WalkwayClearanceLabel.Size = new System.Drawing.Size(127, 16);
            this.WalkwayClearanceLabel.TabIndex = 16;
            this.WalkwayClearanceLabel.Text = "Walkway Clearance";
            // 
            // EAclearanceLabel
            // 
            this.structuresExtender.SetAttributeName(this.EAclearanceLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.EAclearanceLabel, null);
            this.EAclearanceLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.EAclearanceLabel, null);
            this.EAclearanceLabel.Location = new System.Drawing.Point(3, 110);
            this.EAclearanceLabel.Name = "EAclearanceLabel";
            this.EAclearanceLabel.Size = new System.Drawing.Size(140, 16);
            this.EAclearanceLabel.TabIndex = 5;
            this.EAclearanceLabel.Text = "EA Support Clearance";
            // 
            // WalkwayClearance
            // 
            this.structuresExtender.SetAttributeName(this.WalkwayClearance, null);
            this.structuresExtender.SetAttributeTypeName(this.WalkwayClearance, null);
            this.structuresExtender.SetBindPropertyName(this.WalkwayClearance, null);
            this.WalkwayClearance.Location = new System.Drawing.Point(163, 54);
            this.WalkwayClearance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WalkwayClearance.Name = "WalkwayClearance";
            this.WalkwayClearance.Size = new System.Drawing.Size(68, 22);
            this.WalkwayClearance.TabIndex = 2;
            this.WalkwayClearance.Text = "10";
            this.WalkwayClearance.TextChanged += new System.EventHandler(this.WalkwayClearance_TextChanged);
            this.WalkwayClearance.Validating += new System.ComponentModel.CancelEventHandler(this.WalkwayClearance_Validating);
            // 
            // EAClearance
            // 
            this.structuresExtender.SetAttributeName(this.EAClearance, null);
            this.structuresExtender.SetAttributeTypeName(this.EAClearance, null);
            this.structuresExtender.SetBindPropertyName(this.EAClearance, null);
            this.EAClearance.Location = new System.Drawing.Point(163, 112);
            this.EAClearance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EAClearance.Name = "EAClearance";
            this.EAClearance.Size = new System.Drawing.Size(68, 22);
            this.EAClearance.TabIndex = 4;
            this.EAClearance.Text = "80";
            this.EAClearance.TextChanged += new System.EventHandler(this.EAClearance_TextChanged);
            this.EAClearance.Validating += new System.ComponentModel.CancelEventHandler(this.EAClearance_Validating);
            // 
            // groupBox8
            // 
            this.structuresExtender.SetAttributeName(this.groupBox8, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox8, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox8, null);
            this.groupBox8.Controls.Add(this.SpacerPlateSwitch);
            this.groupBox8.Controls.Add(this.BracketSpacerThickness);
            this.groupBox8.Controls.Add(this.BracketSpacer);
            this.groupBox8.Controls.Add(this.groupBox10);
            this.groupBox8.Controls.Add(this.groupBox9);
            this.groupBox8.Location = new System.Drawing.Point(1623, 628);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(319, 249);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Z Bracket";
            // 
            // SpacerPlateSwitch
            // 
            this.SpacerPlateSwitch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.structuresExtender.SetAttributeName(this.SpacerPlateSwitch, null);
            this.structuresExtender.SetAttributeTypeName(this.SpacerPlateSwitch, null);
            this.SpacerPlateSwitch.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.SpacerPlateSwitch, null);
            this.SpacerPlateSwitch.Location = new System.Drawing.Point(179, 188);
            this.SpacerPlateSwitch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SpacerPlateSwitch.Name = "SpacerPlateSwitch";
            this.SpacerPlateSwitch.Size = new System.Drawing.Size(46, 20);
            this.SpacerPlateSwitch.TabIndex = 9;
            this.SpacerPlateSwitch.Text = "On";
            this.SpacerPlateSwitch.UseVisualStyleBackColor = true;
            this.SpacerPlateSwitch.CheckedChanged += new System.EventHandler(this.SpacerPlateSwitch_CheckedChanged);
            // 
            // BracketSpacerThickness
            // 
            this.structuresExtender.SetAttributeName(this.BracketSpacerThickness, null);
            this.structuresExtender.SetAttributeTypeName(this.BracketSpacerThickness, null);
            this.structuresExtender.SetBindPropertyName(this.BracketSpacerThickness, null);
            this.BracketSpacerThickness.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BracketSpacerThickness.Enabled = false;
            this.BracketSpacerThickness.Location = new System.Drawing.Point(179, 214);
            this.BracketSpacerThickness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BracketSpacerThickness.Name = "BracketSpacerThickness";
            this.BracketSpacerThickness.Size = new System.Drawing.Size(68, 22);
            this.BracketSpacerThickness.TabIndex = 8;
            this.BracketSpacerThickness.Text = "0.0";
            this.BracketSpacerThickness.Validating += new System.ComponentModel.CancelEventHandler(this.BracketSpacerThickness_Validating);
            // 
            // BracketSpacer
            // 
            this.structuresExtender.SetAttributeName(this.BracketSpacer, null);
            this.structuresExtender.SetAttributeTypeName(this.BracketSpacer, null);
            this.BracketSpacer.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BracketSpacer, null);
            this.BracketSpacer.Location = new System.Drawing.Point(17, 192);
            this.BracketSpacer.Name = "BracketSpacer";
            this.BracketSpacer.Size = new System.Drawing.Size(137, 32);
            this.BracketSpacer.TabIndex = 7;
            this.BracketSpacer.Text = "Bracket Spacer Plate \r\nThickness";
            // 
            // groupBox10
            // 
            this.structuresExtender.SetAttributeName(this.groupBox10, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox10, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox10, null);
            this.groupBox10.Controls.Add(this.tableLayoutPanel12);
            this.groupBox10.Location = new System.Drawing.Point(11, 117);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Size = new System.Drawing.Size(296, 62);
            this.groupBox10.TabIndex = 6;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "End Bracket";
            // 
            // tableLayoutPanel12
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel12, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel12, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel12, null);
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.Controls.Add(this.ZbracketEndSpacing, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(4, 21);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(285, 33);
            this.tableLayoutPanel12.TabIndex = 4;
            // 
            // ZbracketEndSpacing
            // 
            this.structuresExtender.SetAttributeName(this.ZbracketEndSpacing, null);
            this.structuresExtender.SetAttributeTypeName(this.ZbracketEndSpacing, null);
            this.structuresExtender.SetBindPropertyName(this.ZbracketEndSpacing, null);
            this.ZbracketEndSpacing.Location = new System.Drawing.Point(163, 2);
            this.ZbracketEndSpacing.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ZbracketEndSpacing.Name = "ZbracketEndSpacing";
            this.ZbracketEndSpacing.Size = new System.Drawing.Size(68, 22);
            this.ZbracketEndSpacing.TabIndex = 2;
            this.ZbracketEndSpacing.Text = "10.0";
            this.ZbracketEndSpacing.TextChanged += new System.EventHandler(this.ZbracketEndSpacing_TextChanged);
            this.ZbracketEndSpacing.Validating += new System.ComponentModel.CancelEventHandler(this.ZbracketEndSpacing_Validating);
            // 
            // label18
            // 
            this.structuresExtender.SetAttributeName(this.label18, null);
            this.structuresExtender.SetAttributeTypeName(this.label18, null);
            this.label18.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label18, null);
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(127, 16);
            this.label18.TabIndex = 5;
            this.label18.Text = "Z bracket Spacing a";
            // 
            // groupBox9
            // 
            this.structuresExtender.SetAttributeName(this.groupBox9, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox9, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox9, null);
            this.groupBox9.Controls.Add(this.tableLayoutPanel11);
            this.groupBox9.Location = new System.Drawing.Point(11, 21);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox9.Size = new System.Drawing.Size(296, 91);
            this.groupBox9.TabIndex = 5;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Middle Bracket";
            // 
            // tableLayoutPanel11
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel11, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel11, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel11, null);
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.Controls.Add(this.ZbracketSpacingA, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.ZbracketSpacingALabel, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.ZbracketSpacingB, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.ZbracketSpacingBLabel, 0, 1);
            this.tableLayoutPanel11.Location = new System.Drawing.Point(4, 20);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(285, 65);
            this.tableLayoutPanel11.TabIndex = 3;
            // 
            // ZbracketSpacingA
            // 
            this.structuresExtender.SetAttributeName(this.ZbracketSpacingA, null);
            this.structuresExtender.SetAttributeTypeName(this.ZbracketSpacingA, null);
            this.structuresExtender.SetBindPropertyName(this.ZbracketSpacingA, null);
            this.ZbracketSpacingA.Location = new System.Drawing.Point(163, 2);
            this.ZbracketSpacingA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ZbracketSpacingA.Name = "ZbracketSpacingA";
            this.ZbracketSpacingA.Size = new System.Drawing.Size(68, 22);
            this.ZbracketSpacingA.TabIndex = 0;
            this.ZbracketSpacingA.Text = "10.0";
            this.ZbracketSpacingA.TextChanged += new System.EventHandler(this.ZbracketSpacingA_TextChanged);
            this.ZbracketSpacingA.Validating += new System.ComponentModel.CancelEventHandler(this.ZbracketSpacingA_Validating);
            // 
            // ZbracketSpacingALabel
            // 
            this.structuresExtender.SetAttributeName(this.ZbracketSpacingALabel, null);
            this.structuresExtender.SetAttributeTypeName(this.ZbracketSpacingALabel, null);
            this.ZbracketSpacingALabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.ZbracketSpacingALabel, null);
            this.ZbracketSpacingALabel.Location = new System.Drawing.Point(3, 0);
            this.ZbracketSpacingALabel.Name = "ZbracketSpacingALabel";
            this.ZbracketSpacingALabel.Size = new System.Drawing.Size(127, 16);
            this.ZbracketSpacingALabel.TabIndex = 5;
            this.ZbracketSpacingALabel.Text = "Z bracket Spacing a";
            // 
            // ZbracketSpacingB
            // 
            this.structuresExtender.SetAttributeName(this.ZbracketSpacingB, null);
            this.structuresExtender.SetAttributeTypeName(this.ZbracketSpacingB, null);
            this.structuresExtender.SetBindPropertyName(this.ZbracketSpacingB, null);
            this.ZbracketSpacingB.Location = new System.Drawing.Point(163, 28);
            this.ZbracketSpacingB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ZbracketSpacingB.Name = "ZbracketSpacingB";
            this.ZbracketSpacingB.Size = new System.Drawing.Size(68, 22);
            this.ZbracketSpacingB.TabIndex = 1;
            this.ZbracketSpacingB.Text = "20.0";
            this.ZbracketSpacingB.TextChanged += new System.EventHandler(this.ZbracketSpacingB_TextChanged);
            this.ZbracketSpacingB.Validating += new System.ComponentModel.CancelEventHandler(this.ZbracketSpacingB_Validating);
            // 
            // ZbracketSpacingBLabel
            // 
            this.structuresExtender.SetAttributeName(this.ZbracketSpacingBLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.ZbracketSpacingBLabel, null);
            this.ZbracketSpacingBLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.ZbracketSpacingBLabel, null);
            this.ZbracketSpacingBLabel.Location = new System.Drawing.Point(3, 26);
            this.ZbracketSpacingBLabel.Name = "ZbracketSpacingBLabel";
            this.ZbracketSpacingBLabel.Size = new System.Drawing.Size(127, 16);
            this.ZbracketSpacingBLabel.TabIndex = 1;
            this.ZbracketSpacingBLabel.Text = "Z bracket Spacing b";
            // 
            // label35
            // 
            this.structuresExtender.SetAttributeName(this.label35, null);
            this.structuresExtender.SetAttributeTypeName(this.label35, null);
            this.label35.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label35, null);
            this.label35.Location = new System.Drawing.Point(1820, 129);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(80, 16);
            this.label35.TabIndex = 20;
            this.label35.Text = "End Bracket";
            // 
            // label36
            // 
            this.structuresExtender.SetAttributeName(this.label36, null);
            this.structuresExtender.SetAttributeTypeName(this.label36, null);
            this.label36.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label36, null);
            this.label36.Location = new System.Drawing.Point(1804, 256);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(97, 16);
            this.label36.TabIndex = 21;
            this.label36.Text = "Middle Bracket";
            // 
            // groupBox11
            // 
            this.structuresExtender.SetAttributeName(this.groupBox11, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox11, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox11, null);
            this.groupBox11.Controls.Add(this.tableLayoutPanel13);
            this.groupBox11.Controls.Add(this.SeatingPlateOffButton);
            this.groupBox11.Controls.Add(this.SeatingPlateOnButton);
            this.groupBox11.Location = new System.Drawing.Point(853, 768);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox11.Size = new System.Drawing.Size(371, 109);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Seating Plate";
            // 
            // tableLayoutPanel13
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel13, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel13, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel13, null);
            this.tableLayoutPanel13.ColumnCount = 6;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel13.Controls.Add(this.ExtrusionLength, 4, 0);
            this.tableLayoutPanel13.Controls.Add(this.SeatingPlateOffset, 1, 0);
            this.tableLayoutPanel13.Controls.Add(this.seatingplateextrusionlengthLabel, 3, 0);
            this.tableLayoutPanel13.Controls.Add(this.SeatingplateoffsetLabel, 0, 0);
            this.tableLayoutPanel13.Location = new System.Drawing.Point(8, 54);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 1;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(363, 30);
            this.tableLayoutPanel13.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.structuresExtender.SetAttributeName(this.tabControl2, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl2, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl2, null);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(16, 11);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1955, 921);
            this.tabControl2.TabIndex = 22;
            // 
            // tabPage4
            // 
            this.structuresExtender.SetAttributeName(this.tabPage4, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage4, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage4, null);
            this.tabPage4.Controls.Add(this.RailingInfo);
            this.tabPage4.Controls.Add(this.ScreenProfile);
            this.tabPage4.Controls.Add(this.groupBox16);
            this.tabPage4.Controls.Add(this.groupBox11);
            this.tabPage4.Controls.Add(pictureBox1);
            this.tabPage4.Controls.Add(this.label36);
            this.tabPage4.Controls.Add(this.ledCabinets);
            this.tabPage4.Controls.Add(this.label35);
            this.tabPage4.Controls.Add(this.MaterialAndProfile);
            this.tabPage4.Controls.Add(this.pictureBox3);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.groupBox8);
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Controls.Add(this.groupBox6);
            this.tabPage4.Controls.Add(this.groupBox14);
            this.tabPage4.Controls.Add(this.BillboardDimensions);
            this.tabPage4.Controls.Add(this.label27);
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.label26);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.pictureBox2);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage4.Size = new System.Drawing.Size(1947, 892);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Board Parameters";
            this.tabPage4.UseVisualStyleBackColor = true;
            this.tabPage4.Click += new System.EventHandler(this.tabPage4_Click);
            // 
            // RailingInfo
            // 
            this.structuresExtender.SetAttributeName(this.RailingInfo, null);
            this.structuresExtender.SetAttributeTypeName(this.RailingInfo, null);
            this.structuresExtender.SetBindPropertyName(this.RailingInfo, null);
            this.RailingInfo.Controls.Add(this.TrimmerBox);
            this.RailingInfo.Controls.Add(this.HandRailingBox);
            this.RailingInfo.Controls.Add(this.KneeRailingBox);
            this.RailingInfo.Controls.Add(this.KneeRail);
            this.RailingInfo.Controls.Add(this.HandRail);
            this.RailingInfo.Controls.Add(this.Trimmer);
            this.RailingInfo.Location = new System.Drawing.Point(1245, 816);
            this.RailingInfo.Margin = new System.Windows.Forms.Padding(4);
            this.RailingInfo.Name = "RailingInfo";
            this.RailingInfo.Padding = new System.Windows.Forms.Padding(4);
            this.RailingInfo.Size = new System.Drawing.Size(371, 70);
            this.RailingInfo.TabIndex = 24;
            this.RailingInfo.TabStop = false;
            this.RailingInfo.Text = "Walkway Railings";
            // 
            // TrimmerBox
            // 
            this.structuresExtender.SetAttributeName(this.TrimmerBox, null);
            this.structuresExtender.SetAttributeTypeName(this.TrimmerBox, null);
            this.structuresExtender.SetBindPropertyName(this.TrimmerBox, null);
            this.TrimmerBox.Location = new System.Drawing.Point(265, 43);
            this.TrimmerBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.TrimmerBox.Name = "TrimmerBox";
            this.TrimmerBox.Size = new System.Drawing.Size(68, 22);
            this.TrimmerBox.TabIndex = 3;
            this.TrimmerBox.Text = "1200";
            this.TrimmerBox.TextChanged += new System.EventHandler(this.TrimmerBox_TextChanged);
            this.TrimmerBox.Validating += new System.ComponentModel.CancelEventHandler(this.TrimmerBox_Validating);
            // 
            // HandRailingBox
            // 
            this.structuresExtender.SetAttributeName(this.HandRailingBox, null);
            this.structuresExtender.SetAttributeTypeName(this.HandRailingBox, null);
            this.structuresExtender.SetBindPropertyName(this.HandRailingBox, null);
            this.HandRailingBox.Location = new System.Drawing.Point(145, 43);
            this.HandRailingBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.HandRailingBox.Name = "HandRailingBox";
            this.HandRailingBox.Size = new System.Drawing.Size(68, 22);
            this.HandRailingBox.TabIndex = 2;
            this.HandRailingBox.Text = "550";
            this.HandRailingBox.TextChanged += new System.EventHandler(this.HandRailingBox_TextChanged);
            this.HandRailingBox.Validating += new System.ComponentModel.CancelEventHandler(this.HandRailingBox_Validating);
            // 
            // KneeRailingBox
            // 
            this.structuresExtender.SetAttributeName(this.KneeRailingBox, null);
            this.structuresExtender.SetAttributeTypeName(this.KneeRailingBox, null);
            this.structuresExtender.SetBindPropertyName(this.KneeRailingBox, null);
            this.KneeRailingBox.Location = new System.Drawing.Point(33, 43);
            this.KneeRailingBox.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.KneeRailingBox.Name = "KneeRailingBox";
            this.KneeRailingBox.Size = new System.Drawing.Size(68, 22);
            this.KneeRailingBox.TabIndex = 1;
            this.KneeRailingBox.Text = "450";
            this.KneeRailingBox.TextChanged += new System.EventHandler(this.KneeRailingBox_TextChanged);
            this.KneeRailingBox.Validating += new System.ComponentModel.CancelEventHandler(this.KneeRailingBox_Validating);
            // 
            // KneeRail
            // 
            this.structuresExtender.SetAttributeName(this.KneeRail, null);
            this.structuresExtender.SetAttributeTypeName(this.KneeRail, null);
            this.structuresExtender.SetBindPropertyName(this.KneeRail, null);
            this.KneeRail.Location = new System.Drawing.Point(34, 26);
            this.KneeRail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.KneeRail.Name = "KneeRail";
            this.KneeRail.Size = new System.Drawing.Size(67, 27);
            this.KneeRail.TabIndex = 4;
            this.KneeRail.Text = "KneeRails:";
            // 
            // HandRail
            // 
            this.structuresExtender.SetAttributeName(this.HandRail, null);
            this.structuresExtender.SetAttributeTypeName(this.HandRail, null);
            this.structuresExtender.SetBindPropertyName(this.HandRail, null);
            this.HandRail.Location = new System.Drawing.Point(146, 26);
            this.HandRail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HandRail.Name = "HandRail";
            this.HandRail.Size = new System.Drawing.Size(67, 27);
            this.HandRail.TabIndex = 5;
            this.HandRail.Text = "HandRails:";
            // 
            // Trimmer
            // 
            this.structuresExtender.SetAttributeName(this.Trimmer, null);
            this.structuresExtender.SetAttributeTypeName(this.Trimmer, null);
            this.structuresExtender.SetBindPropertyName(this.Trimmer, null);
            this.Trimmer.Location = new System.Drawing.Point(266, 26);
            this.Trimmer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Trimmer.Name = "Trimmer";
            this.Trimmer.Size = new System.Drawing.Size(67, 27);
            this.Trimmer.TabIndex = 6;
            this.Trimmer.Text = "Trimmer:";
            // 
            // ScreenProfile
            // 
            this.structuresExtender.SetAttributeName(this.ScreenProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.ScreenProfile, null);
            this.structuresExtender.SetBindPropertyName(this.ScreenProfile, null);
            this.ScreenProfile.Controls.Add(this.tableLayoutPanel15);
            this.ScreenProfile.Location = new System.Drawing.Point(523, 20);
            this.ScreenProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScreenProfile.Name = "ScreenProfile";
            this.ScreenProfile.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ScreenProfile.Size = new System.Drawing.Size(315, 235);
            this.ScreenProfile.TabIndex = 23;
            this.ScreenProfile.TabStop = false;
            this.ScreenProfile.Text = "LED Screens";
            // 
            // tableLayoutPanel15
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel15, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel15, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel15, null);
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.LEDThickness, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel15.Controls.Add(this.LEDDensity, 1, 5);
            this.tableLayoutPanel15.Controls.Add(this.LEDWidthlable, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.LEDWidth, 1, 1);
            this.tableLayoutPanel15.Controls.Add(this.LEDHeight, 1, 2);
            this.tableLayoutPanel15.Controls.Add(this.LEDHeightLable, 0, 2);
            this.tableLayoutPanel15.Controls.Add(this.LEDWeightLable, 0, 3);
            this.tableLayoutPanel15.Controls.Add(this.LEDWeight, 1, 3);
            this.tableLayoutPanel15.Controls.Add(this.button3, 1, 4);
            this.tableLayoutPanel15.Location = new System.Drawing.Point(11, 25);
            this.tableLayoutPanel15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 6;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(299, 223);
            this.tableLayoutPanel15.TabIndex = 0;
            // 
            // label4
            // 
            this.structuresExtender.SetAttributeName(this.label4, null);
            this.structuresExtender.SetAttributeTypeName(this.label4, null);
            this.label4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label4, null);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Depth (mm)";
            // 
            // LEDThickness
            // 
            this.structuresExtender.SetAttributeName(this.LEDThickness, null);
            this.structuresExtender.SetAttributeTypeName(this.LEDThickness, null);
            this.structuresExtender.SetBindPropertyName(this.LEDThickness, null);
            this.LEDThickness.Location = new System.Drawing.Point(152, 2);
            this.LEDThickness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LEDThickness.Name = "LEDThickness";
            this.LEDThickness.Size = new System.Drawing.Size(136, 22);
            this.LEDThickness.TabIndex = 2;
            this.LEDThickness.Text = "170";
            this.LEDThickness.TextChanged += new System.EventHandler(this.LEDThickness_TextChanged);
            // 
            // label5
            // 
            this.structuresExtender.SetAttributeName(this.label5, null);
            this.structuresExtender.SetAttributeTypeName(this.label5, null);
            this.label5.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label5, null);
            this.label5.Location = new System.Drawing.Point(3, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Density (kg/m3)";
            // 
            // LEDDensity
            // 
            this.structuresExtender.SetAttributeName(this.LEDDensity, null);
            this.structuresExtender.SetAttributeTypeName(this.LEDDensity, null);
            this.structuresExtender.SetBindPropertyName(this.LEDDensity, null);
            this.LEDDensity.Location = new System.Drawing.Point(152, 181);
            this.LEDDensity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LEDDensity.Name = "LEDDensity";
            this.LEDDensity.Size = new System.Drawing.Size(136, 22);
            this.LEDDensity.TabIndex = 3;
            this.LEDDensity.Text = "1.0";
            this.LEDDensity.TextChanged += new System.EventHandler(this.LEDDensity_TextChanged);
            this.LEDDensity.Validating += new System.ComponentModel.CancelEventHandler(this.LEDDensity_Validating);
            // 
            // LEDWidthlable
            // 
            this.structuresExtender.SetAttributeName(this.LEDWidthlable, null);
            this.structuresExtender.SetAttributeTypeName(this.LEDWidthlable, null);
            this.LEDWidthlable.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LEDWidthlable, null);
            this.LEDWidthlable.Location = new System.Drawing.Point(3, 35);
            this.LEDWidthlable.Name = "LEDWidthlable";
            this.LEDWidthlable.Size = new System.Drawing.Size(74, 16);
            this.LEDWidthlable.TabIndex = 0;
            this.LEDWidthlable.Text = "Width (mm)";
            this.LEDWidthlable.Click += new System.EventHandler(this.label41_Click);
            // 
            // LEDWidth
            // 
            this.structuresExtender.SetAttributeName(this.LEDWidth, null);
            this.structuresExtender.SetAttributeTypeName(this.LEDWidth, null);
            this.structuresExtender.SetBindPropertyName(this.LEDWidth, null);
            this.LEDWidth.Location = new System.Drawing.Point(152, 37);
            this.LEDWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LEDWidth.Name = "LEDWidth";
            this.LEDWidth.Size = new System.Drawing.Size(136, 22);
            this.LEDWidth.TabIndex = 2;
            this.LEDWidth.Text = "1500";
            this.LEDWidth.TextChanged += new System.EventHandler(this.LEDWidth_TextChanged);
            // 
            // LEDHeight
            // 
            this.structuresExtender.SetAttributeName(this.LEDHeight, null);
            this.structuresExtender.SetAttributeTypeName(this.LEDHeight, null);
            this.structuresExtender.SetBindPropertyName(this.LEDHeight, null);
            this.LEDHeight.Location = new System.Drawing.Point(152, 72);
            this.LEDHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LEDHeight.Name = "LEDHeight";
            this.LEDHeight.Size = new System.Drawing.Size(136, 22);
            this.LEDHeight.TabIndex = 2;
            this.LEDHeight.Text = "1500";
            this.LEDHeight.TextChanged += new System.EventHandler(this.LEDThickness_TextChanged);
            // 
            // LEDHeightLable
            // 
            this.structuresExtender.SetAttributeName(this.LEDHeightLable, null);
            this.structuresExtender.SetAttributeTypeName(this.LEDHeightLable, null);
            this.LEDHeightLable.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LEDHeightLable, null);
            this.LEDHeightLable.Location = new System.Drawing.Point(3, 70);
            this.LEDHeightLable.Name = "LEDHeightLable";
            this.LEDHeightLable.Size = new System.Drawing.Size(79, 16);
            this.LEDHeightLable.TabIndex = 0;
            this.LEDHeightLable.Text = "Height (mm)";
            this.LEDHeightLable.Click += new System.EventHandler(this.label41_Click);
            // 
            // LEDWeightLable
            // 
            this.structuresExtender.SetAttributeName(this.LEDWeightLable, null);
            this.structuresExtender.SetAttributeTypeName(this.LEDWeightLable, null);
            this.LEDWeightLable.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LEDWeightLable, null);
            this.LEDWeightLable.Location = new System.Drawing.Point(3, 103);
            this.LEDWeightLable.Name = "LEDWeightLable";
            this.LEDWeightLable.Size = new System.Drawing.Size(76, 16);
            this.LEDWeightLable.TabIndex = 0;
            this.LEDWeightLable.Text = "Weight (Kg)";
            this.LEDWeightLable.Click += new System.EventHandler(this.label41_Click);
            // 
            // LEDWeight
            // 
            this.structuresExtender.SetAttributeName(this.LEDWeight, null);
            this.structuresExtender.SetAttributeTypeName(this.LEDWeight, null);
            this.structuresExtender.SetBindPropertyName(this.LEDWeight, null);
            this.LEDWeight.Location = new System.Drawing.Point(152, 105);
            this.LEDWeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LEDWeight.Name = "LEDWeight";
            this.LEDWeight.Size = new System.Drawing.Size(136, 22);
            this.LEDWeight.TabIndex = 2;
            this.LEDWeight.Text = "100";
            this.LEDWeight.TextChanged += new System.EventHandler(this.LEDThickness_TextChanged);
            // 
            // button3
            // 
            this.structuresExtender.SetAttributeName(this.button3, null);
            this.structuresExtender.SetAttributeTypeName(this.button3, null);
            this.structuresExtender.SetBindPropertyName(this.button3, null);
            this.button3.Location = new System.Drawing.Point(153, 139);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 36);
            this.button3.TabIndex = 4;
            this.button3.Text = "Calc LED Wieght";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox16
            // 
            this.structuresExtender.SetAttributeName(this.groupBox16, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox16, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox16, null);
            this.groupBox16.Controls.Add(this.profileCatalog13);
            this.groupBox16.Controls.Add(this.EACabinetBoltHoleSize);
            this.groupBox16.Controls.Add(this.label29);
            this.groupBox16.Controls.Add(this.EASplitBoltOffset);
            this.groupBox16.Controls.Add(this.label16);
            this.groupBox16.Controls.Add(this.tableLayoutPanel14);
            this.groupBox16.Location = new System.Drawing.Point(853, 494);
            this.groupBox16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox16.Size = new System.Drawing.Size(371, 270);
            this.groupBox16.TabIndex = 22;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Split Beams";
            // 
            // profileCatalog13
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog13, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog13, null);
            this.profileCatalog13.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog13, null);
            this.profileCatalog13.ButtonText = "Select...";
            this.profileCatalog13.Location = new System.Drawing.Point(295, 140);
            this.profileCatalog13.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog13.Name = "profileCatalog13";
            this.profileCatalog13.SelectedProfile = "";
            this.profileCatalog13.Size = new System.Drawing.Size(63, 23);
            this.profileCatalog13.TabIndex = 15;
            this.profileCatalog13.SelectClicked += new System.EventHandler(this.profileCatalog13_SelectClicked);
            this.profileCatalog13.SelectionDone += new System.EventHandler(this.profileCatalog13_SelectionDone);
            // 
            // EACabinetBoltHoleSize
            // 
            this.structuresExtender.SetAttributeName(this.EACabinetBoltHoleSize, null);
            this.structuresExtender.SetAttributeTypeName(this.EACabinetBoltHoleSize, null);
            this.structuresExtender.SetBindPropertyName(this.EACabinetBoltHoleSize, null);
            this.EACabinetBoltHoleSize.Location = new System.Drawing.Point(171, 225);
            this.EACabinetBoltHoleSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EACabinetBoltHoleSize.Name = "EACabinetBoltHoleSize";
            this.EACabinetBoltHoleSize.Size = new System.Drawing.Size(111, 22);
            this.EACabinetBoltHoleSize.TabIndex = 14;
            this.EACabinetBoltHoleSize.Text = "12";
            // 
            // label29
            // 
            this.structuresExtender.SetAttributeName(this.label29, null);
            this.structuresExtender.SetAttributeTypeName(this.label29, null);
            this.label29.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label29, null);
            this.label29.Location = new System.Drawing.Point(8, 222);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(100, 32);
            this.label29.TabIndex = 13;
            this.label29.Text = "EA Cabinet Bolt\r\nHole Size";
            // 
            // EASplitBoltOffset
            // 
            this.structuresExtender.SetAttributeName(this.EASplitBoltOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.EASplitBoltOffset, null);
            this.structuresExtender.SetBindPropertyName(this.EASplitBoltOffset, null);
            this.EASplitBoltOffset.Location = new System.Drawing.Point(171, 185);
            this.EASplitBoltOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EASplitBoltOffset.Name = "EASplitBoltOffset";
            this.EASplitBoltOffset.Size = new System.Drawing.Size(111, 22);
            this.EASplitBoltOffset.TabIndex = 12;
            this.EASplitBoltOffset.Text = "100";
            // 
            // label16
            // 
            this.structuresExtender.SetAttributeName(this.label16, null);
            this.structuresExtender.SetAttributeTypeName(this.label16, null);
            this.label16.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label16, null);
            this.label16.Location = new System.Drawing.Point(8, 181);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(121, 32);
            this.label16.TabIndex = 4;
            this.label16.Text = "EA Connecting Bolt\r\nOffset";
            // 
            // tableLayoutPanel14
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel14, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel14, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel14, null);
            this.tableLayoutPanel14.ColumnCount = 4;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel14.Controls.Add(this.B5SplitBeamProfile, 2, 6);
            this.tableLayoutPanel14.Controls.Add(this.B2SplitBeamProfile, 2, 3);
            this.tableLayoutPanel14.Controls.Add(this.B2SplitBeamMaterial, 1, 3);
            this.tableLayoutPanel14.Controls.Add(this.B5SplitBeamMaterial, 1, 6);
            this.tableLayoutPanel14.Controls.Add(this.B1SplitBeamProfile, 2, 2);
            this.tableLayoutPanel14.Controls.Add(this.B1SplitBeamMaterial, 1, 2);
            this.tableLayoutPanel14.Controls.Add(this.C1SplitBeamProfile, 2, 1);
            this.tableLayoutPanel14.Controls.Add(this.label43, 2, 0);
            this.tableLayoutPanel14.Controls.Add(this.label44, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.B5Split, 0, 6);
            this.tableLayoutPanel14.Controls.Add(this.B2Split, 0, 3);
            this.tableLayoutPanel14.Controls.Add(this.C1Split, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.B1Split, 0, 2);
            this.tableLayoutPanel14.Controls.Add(this.C1SplitBeamMaterial, 1, 1);
            this.tableLayoutPanel14.Controls.Add(this.profileCatalog10, 3, 1);
            this.tableLayoutPanel14.Controls.Add(this.profileCatalog11, 3, 2);
            this.tableLayoutPanel14.Controls.Add(this.profileCatalog12, 3, 3);
            this.tableLayoutPanel14.Location = new System.Drawing.Point(5, 25);
            this.tableLayoutPanel14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 11;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.Size = new System.Drawing.Size(356, 145);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // B5SplitBeamProfile
            // 
            this.structuresExtender.SetAttributeName(this.B5SplitBeamProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.B5SplitBeamProfile, null);
            this.structuresExtender.SetBindPropertyName(this.B5SplitBeamProfile, null);
            this.B5SplitBeamProfile.Location = new System.Drawing.Point(170, 121);
            this.B5SplitBeamProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B5SplitBeamProfile.Name = "B5SplitBeamProfile";
            this.B5SplitBeamProfile.Size = new System.Drawing.Size(111, 22);
            this.B5SplitBeamProfile.TabIndex = 11;
            this.B5SplitBeamProfile.Text = "RHS65*35*4.0";
            this.B5SplitBeamProfile.TextChanged += new System.EventHandler(this.B5SplitProfile_TextChanged);
            this.B5SplitBeamProfile.Validating += new System.ComponentModel.CancelEventHandler(this.B5Profile_Validating);
            // 
            // B2SplitBeamProfile
            // 
            this.structuresExtender.SetAttributeName(this.B2SplitBeamProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.B2SplitBeamProfile, null);
            this.structuresExtender.SetBindPropertyName(this.B2SplitBeamProfile, null);
            this.B2SplitBeamProfile.Location = new System.Drawing.Point(170, 88);
            this.B2SplitBeamProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B2SplitBeamProfile.Name = "B2SplitBeamProfile";
            this.B2SplitBeamProfile.Size = new System.Drawing.Size(111, 22);
            this.B2SplitBeamProfile.TabIndex = 7;
            this.B2SplitBeamProfile.Text = "RHS75*25*4.0";
            this.B2SplitBeamProfile.TextChanged += new System.EventHandler(this.B2SplitProfile_TextChanged);
            this.B2SplitBeamProfile.Validating += new System.ComponentModel.CancelEventHandler(this.B2Profile_Validating);
            // 
            // B2SplitBeamMaterial
            // 
            this.structuresExtender.SetAttributeName(this.B2SplitBeamMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.B2SplitBeamMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.B2SplitBeamMaterial, null);
            this.B2SplitBeamMaterial.Location = new System.Drawing.Point(96, 88);
            this.B2SplitBeamMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B2SplitBeamMaterial.Name = "B2SplitBeamMaterial";
            this.B2SplitBeamMaterial.Size = new System.Drawing.Size(68, 22);
            this.B2SplitBeamMaterial.TabIndex = 6;
            this.B2SplitBeamMaterial.Text = "C350L0";
            this.B2SplitBeamMaterial.TextChanged += new System.EventHandler(this.B2SplitMaterial_TextChanged);
            // 
            // B5SplitBeamMaterial
            // 
            this.structuresExtender.SetAttributeName(this.B5SplitBeamMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.B5SplitBeamMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.B5SplitBeamMaterial, null);
            this.B5SplitBeamMaterial.Location = new System.Drawing.Point(96, 121);
            this.B5SplitBeamMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B5SplitBeamMaterial.Name = "B5SplitBeamMaterial";
            this.B5SplitBeamMaterial.Size = new System.Drawing.Size(68, 22);
            this.B5SplitBeamMaterial.TabIndex = 10;
            this.B5SplitBeamMaterial.Text = "C350L0";
            this.B5SplitBeamMaterial.TextChanged += new System.EventHandler(this.B5SplitMaterial_TextChanged);
            // 
            // B1SplitBeamProfile
            // 
            this.structuresExtender.SetAttributeName(this.B1SplitBeamProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.B1SplitBeamProfile, null);
            this.structuresExtender.SetBindPropertyName(this.B1SplitBeamProfile, null);
            this.B1SplitBeamProfile.Location = new System.Drawing.Point(170, 55);
            this.B1SplitBeamProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B1SplitBeamProfile.Name = "B1SplitBeamProfile";
            this.B1SplitBeamProfile.Size = new System.Drawing.Size(111, 22);
            this.B1SplitBeamProfile.TabIndex = 5;
            this.B1SplitBeamProfile.Text = "RHS75*25*4.0";
            this.B1SplitBeamProfile.TextChanged += new System.EventHandler(this.B1SplitProfile_TextChanged);
            this.B1SplitBeamProfile.Validating += new System.ComponentModel.CancelEventHandler(this.B1Profile_Validating);
            // 
            // B1SplitBeamMaterial
            // 
            this.structuresExtender.SetAttributeName(this.B1SplitBeamMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.B1SplitBeamMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.B1SplitBeamMaterial, null);
            this.B1SplitBeamMaterial.Location = new System.Drawing.Point(96, 55);
            this.B1SplitBeamMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.B1SplitBeamMaterial.Name = "B1SplitBeamMaterial";
            this.B1SplitBeamMaterial.Size = new System.Drawing.Size(68, 22);
            this.B1SplitBeamMaterial.TabIndex = 4;
            this.B1SplitBeamMaterial.Text = "C350L0";
            this.B1SplitBeamMaterial.TextChanged += new System.EventHandler(this.B1SplitMaterial_TextChanged);
            // 
            // C1SplitBeamProfile
            // 
            this.structuresExtender.SetAttributeName(this.C1SplitBeamProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.C1SplitBeamProfile, null);
            this.structuresExtender.SetBindPropertyName(this.C1SplitBeamProfile, null);
            this.C1SplitBeamProfile.Location = new System.Drawing.Point(170, 22);
            this.C1SplitBeamProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.C1SplitBeamProfile.Name = "C1SplitBeamProfile";
            this.C1SplitBeamProfile.Size = new System.Drawing.Size(111, 22);
            this.C1SplitBeamProfile.TabIndex = 3;
            this.C1SplitBeamProfile.Text = "RHS75*30*4.0";
            this.C1SplitBeamProfile.TextChanged += new System.EventHandler(this.C1SplitProfile_TextChanged);
            this.C1SplitBeamProfile.Validating += new System.ComponentModel.CancelEventHandler(this.C1Profile_Validating);
            // 
            // label43
            // 
            this.structuresExtender.SetAttributeName(this.label43, null);
            this.structuresExtender.SetAttributeTypeName(this.label43, null);
            this.label43.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label43, null);
            this.label43.Location = new System.Drawing.Point(170, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(45, 16);
            this.label43.TabIndex = 1;
            this.label43.Text = "Profile";
            // 
            // label44
            // 
            this.structuresExtender.SetAttributeName(this.label44, null);
            this.structuresExtender.SetAttributeTypeName(this.label44, null);
            this.label44.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label44, null);
            this.label44.Location = new System.Drawing.Point(96, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(55, 16);
            this.label44.TabIndex = 3;
            this.label44.Text = "Material";
            // 
            // B5Split
            // 
            this.structuresExtender.SetAttributeName(this.B5Split, null);
            this.structuresExtender.SetAttributeTypeName(this.B5Split, null);
            this.B5Split.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.B5Split, null);
            this.B5Split.Location = new System.Drawing.Point(3, 119);
            this.B5Split.Name = "B5Split";
            this.B5Split.Size = new System.Drawing.Size(23, 16);
            this.B5Split.TabIndex = 3;
            this.B5Split.Text = "B5";
            // 
            // B2Split
            // 
            this.structuresExtender.SetAttributeName(this.B2Split, null);
            this.structuresExtender.SetAttributeTypeName(this.B2Split, null);
            this.B2Split.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.B2Split, null);
            this.B2Split.Location = new System.Drawing.Point(3, 86);
            this.B2Split.Name = "B2Split";
            this.B2Split.Size = new System.Drawing.Size(23, 16);
            this.B2Split.TabIndex = 8;
            this.B2Split.Text = "B2";
            // 
            // C1Split
            // 
            this.structuresExtender.SetAttributeName(this.C1Split, null);
            this.structuresExtender.SetAttributeTypeName(this.C1Split, null);
            this.C1Split.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.C1Split, null);
            this.C1Split.Location = new System.Drawing.Point(3, 20);
            this.C1Split.Name = "C1Split";
            this.C1Split.Size = new System.Drawing.Size(23, 16);
            this.C1Split.TabIndex = 1;
            this.C1Split.Text = "C1";
            // 
            // B1Split
            // 
            this.structuresExtender.SetAttributeName(this.B1Split, null);
            this.structuresExtender.SetAttributeTypeName(this.B1Split, null);
            this.B1Split.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.B1Split, null);
            this.B1Split.Location = new System.Drawing.Point(3, 53);
            this.B1Split.Name = "B1Split";
            this.B1Split.Size = new System.Drawing.Size(23, 16);
            this.B1Split.TabIndex = 2;
            this.B1Split.Text = "B1";
            // 
            // C1SplitBeamMaterial
            // 
            this.structuresExtender.SetAttributeName(this.C1SplitBeamMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.C1SplitBeamMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.C1SplitBeamMaterial, null);
            this.C1SplitBeamMaterial.Location = new System.Drawing.Point(96, 22);
            this.C1SplitBeamMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.C1SplitBeamMaterial.Name = "C1SplitBeamMaterial";
            this.C1SplitBeamMaterial.Size = new System.Drawing.Size(68, 22);
            this.C1SplitBeamMaterial.TabIndex = 2;
            this.C1SplitBeamMaterial.Text = "C350L0";
            this.C1SplitBeamMaterial.TextChanged += new System.EventHandler(this.C1SplitMaterial_TextChanged);
            // 
            // profileCatalog10
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog10, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog10, null);
            this.profileCatalog10.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog10, null);
            this.profileCatalog10.ButtonText = "Select...";
            this.profileCatalog10.Location = new System.Drawing.Point(289, 25);
            this.profileCatalog10.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog10.Name = "profileCatalog10";
            this.profileCatalog10.SelectedProfile = "";
            this.profileCatalog10.Size = new System.Drawing.Size(60, 23);
            this.profileCatalog10.TabIndex = 12;
            this.profileCatalog10.SelectClicked += new System.EventHandler(this.profileCatalog10_SelectClicked);
            this.profileCatalog10.SelectionDone += new System.EventHandler(this.profileCatalog10_SelectionDone);
            // 
            // profileCatalog11
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog11, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog11, null);
            this.profileCatalog11.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog11, null);
            this.profileCatalog11.ButtonText = "Select...";
            this.profileCatalog11.Location = new System.Drawing.Point(289, 58);
            this.profileCatalog11.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog11.Name = "profileCatalog11";
            this.profileCatalog11.SelectedProfile = "";
            this.profileCatalog11.Size = new System.Drawing.Size(60, 23);
            this.profileCatalog11.TabIndex = 13;
            this.profileCatalog11.SelectClicked += new System.EventHandler(this.profileCatalog11_SelectClicked);
            this.profileCatalog11.SelectionDone += new System.EventHandler(this.profileCatalog11_SelectionDone);
            // 
            // profileCatalog12
            // 
            this.structuresExtender.SetAttributeName(this.profileCatalog12, null);
            this.structuresExtender.SetAttributeTypeName(this.profileCatalog12, null);
            this.profileCatalog12.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.profileCatalog12, null);
            this.profileCatalog12.ButtonText = "Select...";
            this.profileCatalog12.Location = new System.Drawing.Point(289, 91);
            this.profileCatalog12.Margin = new System.Windows.Forms.Padding(5);
            this.profileCatalog12.Name = "profileCatalog12";
            this.profileCatalog12.SelectedProfile = "";
            this.profileCatalog12.Size = new System.Drawing.Size(60, 23);
            this.profileCatalog12.TabIndex = 14;
            this.profileCatalog12.SelectClicked += new System.EventHandler(this.profileCatalog12_SelectClicked);
            this.profileCatalog12.SelectionDone += new System.EventHandler(this.profileCatalog12_SelectionDone);
            // 
            // pictureBox3
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox3, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox3, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox3, null);
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1701, 65);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(155, 315);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 19;
            this.pictureBox3.TabStop = false;
            // 
            // groupBox14
            // 
            this.structuresExtender.SetAttributeName(this.groupBox14, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox14, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox14, null);
            this.groupBox14.Controls.Add(this.galDepth);
            this.groupBox14.Controls.Add(this.galWidth);
            this.groupBox14.Controls.Add(this.galLength);
            this.groupBox14.Controls.Add(this.galDepthLabel);
            this.groupBox14.Controls.Add(this.galWidthLabel);
            this.groupBox14.Controls.Add(this.galLengthLabel);
            this.groupBox14.Controls.Add(this.galLocSelect);
            this.groupBox14.Controls.Add(this.galLocation);
            this.groupBox14.Location = new System.Drawing.Point(523, 304);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox14.Size = new System.Drawing.Size(320, 158);
            this.groupBox14.TabIndex = 21;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Galvanising Bath";
            // 
            // galDepth
            // 
            this.structuresExtender.SetAttributeName(this.galDepth, null);
            this.structuresExtender.SetAttributeTypeName(this.galDepth, null);
            this.structuresExtender.SetBindPropertyName(this.galDepth, null);
            this.galDepth.Location = new System.Drawing.Point(191, 124);
            this.galDepth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.galDepth.Name = "galDepth";
            this.galDepth.Size = new System.Drawing.Size(133, 28);
            this.galDepth.TabIndex = 0;
            this.galDepth.Text = "2700";
            // 
            // galWidth
            // 
            this.structuresExtender.SetAttributeName(this.galWidth, null);
            this.structuresExtender.SetAttributeTypeName(this.galWidth, null);
            this.structuresExtender.SetBindPropertyName(this.galWidth, null);
            this.galWidth.Location = new System.Drawing.Point(191, 95);
            this.galWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.galWidth.Name = "galWidth";
            this.galWidth.Size = new System.Drawing.Size(133, 28);
            this.galWidth.TabIndex = 0;
            this.galWidth.Text = "1800";
            // 
            // galLength
            // 
            this.structuresExtender.SetAttributeName(this.galLength, null);
            this.structuresExtender.SetAttributeTypeName(this.galLength, null);
            this.structuresExtender.SetBindPropertyName(this.galLength, null);
            this.galLength.Location = new System.Drawing.Point(191, 66);
            this.galLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.galLength.Name = "galLength";
            this.galLength.Size = new System.Drawing.Size(133, 28);
            this.galLength.TabIndex = 0;
            this.galLength.Text = "13500";
            // 
            // galDepthLabel
            // 
            this.structuresExtender.SetAttributeName(this.galDepthLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.galDepthLabel, null);
            this.structuresExtender.SetBindPropertyName(this.galDepthLabel, null);
            this.galDepthLabel.Location = new System.Drawing.Point(5, 124);
            this.galDepthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.galDepthLabel.Name = "galDepthLabel";
            this.galDepthLabel.Size = new System.Drawing.Size(133, 28);
            this.galDepthLabel.TabIndex = 0;
            this.galDepthLabel.Text = "Depth:";
            // 
            // galWidthLabel
            // 
            this.structuresExtender.SetAttributeName(this.galWidthLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.galWidthLabel, null);
            this.structuresExtender.SetBindPropertyName(this.galWidthLabel, null);
            this.galWidthLabel.Location = new System.Drawing.Point(5, 95);
            this.galWidthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.galWidthLabel.Name = "galWidthLabel";
            this.galWidthLabel.Size = new System.Drawing.Size(133, 28);
            this.galWidthLabel.TabIndex = 0;
            this.galWidthLabel.Text = "Width:";
            // 
            // galLengthLabel
            // 
            this.structuresExtender.SetAttributeName(this.galLengthLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.galLengthLabel, null);
            this.structuresExtender.SetBindPropertyName(this.galLengthLabel, null);
            this.galLengthLabel.Location = new System.Drawing.Point(4, 65);
            this.galLengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.galLengthLabel.Name = "galLengthLabel";
            this.galLengthLabel.Size = new System.Drawing.Size(133, 28);
            this.galLengthLabel.TabIndex = 0;
            this.galLengthLabel.Text = "Length:";
            // 
            // galLocSelect
            // 
            this.structuresExtender.SetAttributeName(this.galLocSelect, null);
            this.structuresExtender.SetAttributeTypeName(this.galLocSelect, null);
            this.structuresExtender.SetBindPropertyName(this.galLocSelect, null);
            this.galLocSelect.Items.AddRange(new object[] {
            "GB Dandenong (VIC)",
            "GB Bayswater (VIC)",
            "Geelong (VIC)",
            "Industrial Gal (VIC)",
            "Kingfield (VIC)",
            "Industrial Gal (QLD)",
            "Fero (QLD)"});
            this.galLocSelect.Location = new System.Drawing.Point(119, 26);
            this.galLocSelect.Margin = new System.Windows.Forms.Padding(4);
            this.galLocSelect.Name = "galLocSelect";
            this.galLocSelect.Size = new System.Drawing.Size(177, 24);
            this.galLocSelect.TabIndex = 0;
            this.galLocSelect.Text = "GB Dandenong (VIC)";
            this.galLocSelect.SelectedIndexChanged += new System.EventHandler(this.galLocSelect_SelectedIndexChanged);
            // 
            // galLocation
            // 
            this.structuresExtender.SetAttributeName(this.galLocation, null);
            this.structuresExtender.SetAttributeTypeName(this.galLocation, null);
            this.structuresExtender.SetBindPropertyName(this.galLocation, null);
            this.galLocation.Location = new System.Drawing.Point(4, 28);
            this.galLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.galLocation.Name = "galLocation";
            this.galLocation.Size = new System.Drawing.Size(133, 28);
            this.galLocation.TabIndex = 0;
            this.galLocation.Text = "Location:";
            // 
            // pictureBox2
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox2, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox2, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox2, null);
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1291, 443);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(483, 164);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // tabPage6
            // 
            this.structuresExtender.SetAttributeName(this.tabPage6, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage6, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage6, null);
            this.tabPage6.Controls.Add(this.RearDoorGroup);
            this.tabPage6.Controls.Add(this.groupBox17);
            this.tabPage6.Controls.Add(this.LadderBuilder);
            this.tabPage6.Controls.Add(this.groupBox3);
            this.tabPage6.Controls.Add(this.groupBox15);
            this.tabPage6.Controls.Add(this.GH_panel);
            this.tabPage6.Controls.Add(this.cameraArm);
            this.tabPage6.Controls.Add(this.WW_panel);
            this.tabPage6.Controls.Add(this.groupBox13);
            this.tabPage6.Controls.Add(this.groupBox12);
            this.tabPage6.Location = new System.Drawing.Point(4, 25);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage6.Size = new System.Drawing.Size(1947, 892);
            this.tabPage6.TabIndex = 3;
            this.tabPage6.Text = "Add Ons";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // RearDoorGroup
            // 
            this.structuresExtender.SetAttributeName(this.RearDoorGroup, null);
            this.structuresExtender.SetAttributeTypeName(this.RearDoorGroup, null);
            this.structuresExtender.SetBindPropertyName(this.RearDoorGroup, null);
            this.RearDoorGroup.Controls.Add(this.DoorFrameBeamSelect);
            this.RearDoorGroup.Controls.Add(this.DoorPanelBeamSelect);
            this.RearDoorGroup.Controls.Add(this.DoorPanelProfileText);
            this.RearDoorGroup.Controls.Add(this.DoorPanelMaterialText);
            this.RearDoorGroup.Controls.Add(this.DoorFrameProfileText);
            this.RearDoorGroup.Controls.Add(this.DoorFrameMaterialText);
            this.RearDoorGroup.Controls.Add(this.DoorProfile);
            this.RearDoorGroup.Controls.Add(this.DoorMaterial);
            this.RearDoorGroup.Controls.Add(this.DoorPanelBeam);
            this.RearDoorGroup.Controls.Add(this.DoorFrameBeam);
            this.RearDoorGroup.Controls.Add(this.DoorFramePanelDistance);
            this.RearDoorGroup.Controls.Add(this.DoorrMinHeight);
            this.RearDoorGroup.Controls.Add(this.DoorPanelFrameDistanceText);
            this.RearDoorGroup.Controls.Add(this.DoorMinHeightText);
            this.RearDoorGroup.Controls.Add(this.DoorWidthText);
            this.RearDoorGroup.Controls.Add(this.DoorWidth);
            this.RearDoorGroup.Controls.Add(this.DoorOffsetText);
            this.RearDoorGroup.Controls.Add(this.DoorOffset);
            this.RearDoorGroup.Controls.Add(this.RearDoorEnable);
            this.RearDoorGroup.Location = new System.Drawing.Point(1115, 455);
            this.RearDoorGroup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RearDoorGroup.Name = "RearDoorGroup";
            this.RearDoorGroup.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RearDoorGroup.Size = new System.Drawing.Size(576, 363);
            this.RearDoorGroup.TabIndex = 30;
            this.RearDoorGroup.TabStop = false;
            this.RearDoorGroup.Text = "Rear Door";
            this.RearDoorGroup.Enter += new System.EventHandler(this.RearDoor_Group);
            // 
            // DoorFrameBeamSelect
            // 
            this.structuresExtender.SetAttributeName(this.DoorFrameBeamSelect, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorFrameBeamSelect, null);
            this.DoorFrameBeamSelect.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.DoorFrameBeamSelect, null);
            this.DoorFrameBeamSelect.ButtonText = "Select...";
            this.DoorFrameBeamSelect.Enabled = false;
            this.DoorFrameBeamSelect.Location = new System.Drawing.Point(387, 277);
            this.DoorFrameBeamSelect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.DoorFrameBeamSelect.Name = "DoorFrameBeamSelect";
            this.DoorFrameBeamSelect.SelectedProfile = "";
            this.DoorFrameBeamSelect.Size = new System.Drawing.Size(84, 28);
            this.DoorFrameBeamSelect.TabIndex = 26;
            this.DoorFrameBeamSelect.SelectionDone += new System.EventHandler(this.DoorFrameProfoile_Done);
            // 
            // DoorPanelBeamSelect
            // 
            this.structuresExtender.SetAttributeName(this.DoorPanelBeamSelect, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorPanelBeamSelect, null);
            this.DoorPanelBeamSelect.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.DoorPanelBeamSelect, null);
            this.DoorPanelBeamSelect.ButtonText = "Select...";
            this.DoorPanelBeamSelect.Enabled = false;
            this.DoorPanelBeamSelect.Location = new System.Drawing.Point(387, 314);
            this.DoorPanelBeamSelect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.DoorPanelBeamSelect.Name = "DoorPanelBeamSelect";
            this.DoorPanelBeamSelect.SelectedProfile = "";
            this.DoorPanelBeamSelect.Size = new System.Drawing.Size(84, 28);
            this.DoorPanelBeamSelect.TabIndex = 25;
            this.DoorPanelBeamSelect.SelectionDone += new System.EventHandler(this.DoorPanelProfoile_Done);
            // 
            // DoorPanelProfileText
            // 
            this.structuresExtender.SetAttributeName(this.DoorPanelProfileText, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorPanelProfileText, null);
            this.structuresExtender.SetBindPropertyName(this.DoorPanelProfileText, null);
            this.DoorPanelProfileText.Enabled = false;
            this.DoorPanelProfileText.Location = new System.Drawing.Point(251, 318);
            this.DoorPanelProfileText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoorPanelProfileText.Name = "DoorPanelProfileText";
            this.DoorPanelProfileText.Size = new System.Drawing.Size(127, 22);
            this.DoorPanelProfileText.TabIndex = 16;
            this.DoorPanelProfileText.Text = "SHS25*25*3.0";
            // 
            // DoorPanelMaterialText
            // 
            this.structuresExtender.SetAttributeName(this.DoorPanelMaterialText, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorPanelMaterialText, null);
            this.structuresExtender.SetBindPropertyName(this.DoorPanelMaterialText, null);
            this.DoorPanelMaterialText.Enabled = false;
            this.DoorPanelMaterialText.Location = new System.Drawing.Point(171, 318);
            this.DoorPanelMaterialText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoorPanelMaterialText.Name = "DoorPanelMaterialText";
            this.DoorPanelMaterialText.Size = new System.Drawing.Size(76, 22);
            this.DoorPanelMaterialText.TabIndex = 15;
            this.DoorPanelMaterialText.Text = "C350L0";
            // 
            // DoorFrameProfileText
            // 
            this.structuresExtender.SetAttributeName(this.DoorFrameProfileText, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorFrameProfileText, null);
            this.structuresExtender.SetBindPropertyName(this.DoorFrameProfileText, null);
            this.DoorFrameProfileText.Enabled = false;
            this.DoorFrameProfileText.Location = new System.Drawing.Point(251, 281);
            this.DoorFrameProfileText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoorFrameProfileText.Name = "DoorFrameProfileText";
            this.DoorFrameProfileText.Size = new System.Drawing.Size(127, 22);
            this.DoorFrameProfileText.TabIndex = 14;
            this.DoorFrameProfileText.Text = "SHS75*75*3.0";
            // 
            // DoorFrameMaterialText
            // 
            this.structuresExtender.SetAttributeName(this.DoorFrameMaterialText, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorFrameMaterialText, null);
            this.structuresExtender.SetBindPropertyName(this.DoorFrameMaterialText, null);
            this.DoorFrameMaterialText.Enabled = false;
            this.DoorFrameMaterialText.Location = new System.Drawing.Point(171, 281);
            this.DoorFrameMaterialText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoorFrameMaterialText.Name = "DoorFrameMaterialText";
            this.DoorFrameMaterialText.Size = new System.Drawing.Size(76, 22);
            this.DoorFrameMaterialText.TabIndex = 13;
            this.DoorFrameMaterialText.Text = "C350L0";
            // 
            // DoorProfile
            // 
            this.structuresExtender.SetAttributeName(this.DoorProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorProfile, null);
            this.DoorProfile.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.DoorProfile, null);
            this.DoorProfile.Enabled = false;
            this.DoorProfile.Location = new System.Drawing.Point(283, 250);
            this.DoorProfile.Name = "DoorProfile";
            this.DoorProfile.Size = new System.Drawing.Size(45, 16);
            this.DoorProfile.TabIndex = 12;
            this.DoorProfile.Text = "Profile";
            // 
            // DoorMaterial
            // 
            this.structuresExtender.SetAttributeName(this.DoorMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorMaterial, null);
            this.DoorMaterial.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.DoorMaterial, null);
            this.DoorMaterial.Enabled = false;
            this.DoorMaterial.Location = new System.Drawing.Point(179, 250);
            this.DoorMaterial.Name = "DoorMaterial";
            this.DoorMaterial.Size = new System.Drawing.Size(55, 16);
            this.DoorMaterial.TabIndex = 11;
            this.DoorMaterial.Text = "Material";
            // 
            // DoorPanelBeam
            // 
            this.structuresExtender.SetAttributeName(this.DoorPanelBeam, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorPanelBeam, null);
            this.DoorPanelBeam.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.DoorPanelBeam, null);
            this.DoorPanelBeam.Enabled = false;
            this.DoorPanelBeam.Location = new System.Drawing.Point(13, 320);
            this.DoorPanelBeam.Name = "DoorPanelBeam";
            this.DoorPanelBeam.Size = new System.Drawing.Size(117, 16);
            this.DoorPanelBeam.TabIndex = 10;
            this.DoorPanelBeam.Text = "Door Panel Beam:";
            // 
            // DoorFrameBeam
            // 
            this.structuresExtender.SetAttributeName(this.DoorFrameBeam, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorFrameBeam, null);
            this.DoorFrameBeam.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.DoorFrameBeam, null);
            this.DoorFrameBeam.Enabled = false;
            this.DoorFrameBeam.Location = new System.Drawing.Point(12, 283);
            this.DoorFrameBeam.Name = "DoorFrameBeam";
            this.DoorFrameBeam.Size = new System.Drawing.Size(121, 16);
            this.DoorFrameBeam.TabIndex = 9;
            this.DoorFrameBeam.Text = "Door Frame Beam:";
            // 
            // DoorFramePanelDistance
            // 
            this.structuresExtender.SetAttributeName(this.DoorFramePanelDistance, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorFramePanelDistance, null);
            this.DoorFramePanelDistance.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.DoorFramePanelDistance, null);
            this.DoorFramePanelDistance.Enabled = false;
            this.DoorFramePanelDistance.Location = new System.Drawing.Point(9, 187);
            this.DoorFramePanelDistance.Name = "DoorFramePanelDistance";
            this.DoorFramePanelDistance.Size = new System.Drawing.Size(141, 16);
            this.DoorFramePanelDistance.TabIndex = 8;
            this.DoorFramePanelDistance.Text = "Frame-Panel Distance";
            // 
            // DoorrMinHeight
            // 
            this.structuresExtender.SetAttributeName(this.DoorrMinHeight, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorrMinHeight, null);
            this.DoorrMinHeight.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.DoorrMinHeight, null);
            this.DoorrMinHeight.Enabled = false;
            this.DoorrMinHeight.Location = new System.Drawing.Point(9, 153);
            this.DoorrMinHeight.Name = "DoorrMinHeight";
            this.DoorrMinHeight.Size = new System.Drawing.Size(138, 16);
            this.DoorrMinHeight.TabIndex = 7;
            this.DoorrMinHeight.Text = "Door Minimum Height:";
            // 
            // DoorPanelFrameDistanceText
            // 
            this.structuresExtender.SetAttributeName(this.DoorPanelFrameDistanceText, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorPanelFrameDistanceText, null);
            this.structuresExtender.SetBindPropertyName(this.DoorPanelFrameDistanceText, null);
            this.DoorPanelFrameDistanceText.Enabled = false;
            this.DoorPanelFrameDistanceText.Location = new System.Drawing.Point(257, 185);
            this.DoorPanelFrameDistanceText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoorPanelFrameDistanceText.Name = "DoorPanelFrameDistanceText";
            this.DoorPanelFrameDistanceText.Size = new System.Drawing.Size(100, 22);
            this.DoorPanelFrameDistanceText.TabIndex = 6;
            this.DoorPanelFrameDistanceText.Text = "10";
            // 
            // DoorMinHeightText
            // 
            this.structuresExtender.SetAttributeName(this.DoorMinHeightText, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorMinHeightText, null);
            this.structuresExtender.SetBindPropertyName(this.DoorMinHeightText, null);
            this.DoorMinHeightText.Enabled = false;
            this.DoorMinHeightText.Location = new System.Drawing.Point(257, 149);
            this.DoorMinHeightText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoorMinHeightText.Name = "DoorMinHeightText";
            this.DoorMinHeightText.Size = new System.Drawing.Size(100, 22);
            this.DoorMinHeightText.TabIndex = 5;
            this.DoorMinHeightText.Text = "1900";
            // 
            // DoorWidthText
            // 
            this.structuresExtender.SetAttributeName(this.DoorWidthText, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorWidthText, null);
            this.structuresExtender.SetBindPropertyName(this.DoorWidthText, null);
            this.DoorWidthText.Enabled = false;
            this.DoorWidthText.Location = new System.Drawing.Point(257, 114);
            this.DoorWidthText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoorWidthText.Name = "DoorWidthText";
            this.DoorWidthText.Size = new System.Drawing.Size(100, 22);
            this.DoorWidthText.TabIndex = 4;
            this.DoorWidthText.Text = "650";
            // 
            // DoorWidth
            // 
            this.structuresExtender.SetAttributeName(this.DoorWidth, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorWidth, null);
            this.DoorWidth.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.DoorWidth, null);
            this.DoorWidth.Enabled = false;
            this.DoorWidth.Location = new System.Drawing.Point(9, 118);
            this.DoorWidth.Name = "DoorWidth";
            this.DoorWidth.Size = new System.Drawing.Size(77, 16);
            this.DoorWidth.TabIndex = 3;
            this.DoorWidth.Text = "Door Width:";
            // 
            // DoorOffsetText
            // 
            this.structuresExtender.SetAttributeName(this.DoorOffsetText, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorOffsetText, null);
            this.structuresExtender.SetBindPropertyName(this.DoorOffsetText, null);
            this.DoorOffsetText.Enabled = false;
            this.DoorOffsetText.Location = new System.Drawing.Point(257, 78);
            this.DoorOffsetText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DoorOffsetText.Name = "DoorOffsetText";
            this.DoorOffsetText.Size = new System.Drawing.Size(100, 22);
            this.DoorOffsetText.TabIndex = 2;
            this.DoorOffsetText.Text = "0";
            // 
            // DoorOffset
            // 
            this.structuresExtender.SetAttributeName(this.DoorOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.DoorOffset, null);
            this.DoorOffset.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.DoorOffset, null);
            this.DoorOffset.Enabled = false;
            this.DoorOffset.Location = new System.Drawing.Point(9, 80);
            this.DoorOffset.Name = "DoorOffset";
            this.DoorOffset.Size = new System.Drawing.Size(130, 16);
            this.DoorOffset.TabIndex = 1;
            this.DoorOffset.Text = "Door Offset from Left:";
            // 
            // RearDoorEnable
            // 
            this.structuresExtender.SetAttributeName(this.RearDoorEnable, null);
            this.structuresExtender.SetAttributeTypeName(this.RearDoorEnable, null);
            this.RearDoorEnable.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RearDoorEnable, null);
            this.RearDoorEnable.Location = new System.Drawing.Point(12, 34);
            this.RearDoorEnable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RearDoorEnable.Name = "RearDoorEnable";
            this.RearDoorEnable.Size = new System.Drawing.Size(138, 20);
            this.RearDoorEnable.TabIndex = 0;
            this.RearDoorEnable.Text = "Enable Rear Door";
            this.RearDoorEnable.UseVisualStyleBackColor = true;
            this.RearDoorEnable.CheckedChanged += new System.EventHandler(this.RearDoor_Enable);
            // 
            // groupBox17
            // 
            this.structuresExtender.SetAttributeName(this.groupBox17, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox17, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox17, null);
            this.groupBox17.Controls.Add(this.checkBox1);
            this.groupBox17.Location = new System.Drawing.Point(411, 710);
            this.groupBox17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox17.Size = new System.Drawing.Size(261, 78);
            this.groupBox17.TabIndex = 30;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Back Bracing (IN - PROGRESS)";
            this.groupBox17.Enter += new System.EventHandler(this.groupBox17_Enter);
            // 
            // checkBox1
            // 
            this.structuresExtender.SetAttributeName(this.checkBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.checkBox1, null);
            this.checkBox1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.checkBox1, null);
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(28, 30);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 20);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Enable";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged_1);
            // 
            // LadderBuilder
            // 
            this.structuresExtender.SetAttributeName(this.LadderBuilder, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderBuilder, null);
            this.structuresExtender.SetBindPropertyName(this.LadderBuilder, null);
            this.LadderBuilder.Controls.Add(this.LadderWidthText);
            this.LadderBuilder.Controls.Add(this.LadderWidth);
            this.LadderBuilder.Controls.Add(this.LadderPlateHeightText);
            this.LadderBuilder.Controls.Add(this.LadderPlateHeight);
            this.LadderBuilder.Controls.Add(this.LadderRungSpacing);
            this.LadderBuilder.Controls.Add(this.LadderRungSpacingText);
            this.LadderBuilder.Controls.Add(this.HatchWidthValue);
            this.LadderBuilder.Controls.Add(this.HatchWidthName);
            this.LadderBuilder.Controls.Add(this.tableLayoutPanel16);
            this.LadderBuilder.Controls.Add(this.LadderOffsetSideText);
            this.LadderBuilder.Controls.Add(this.LadderOffsetfromSide);
            this.LadderBuilder.Controls.Add(this.LadderOffsetBack);
            this.LadderBuilder.Controls.Add(this.LadderOffsetBackText);
            this.LadderBuilder.Controls.Add(this.NoLadder);
            this.LadderBuilder.Controls.Add(this.RightLadder);
            this.LadderBuilder.Controls.Add(this.LeftLadder);
            this.LadderBuilder.Location = new System.Drawing.Point(7, 353);
            this.LadderBuilder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderBuilder.Name = "LadderBuilder";
            this.LadderBuilder.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderBuilder.Size = new System.Drawing.Size(384, 533);
            this.LadderBuilder.TabIndex = 29;
            this.LadderBuilder.TabStop = false;
            this.LadderBuilder.Text = "Ladder and Hatch";
            this.LadderBuilder.Enter += new System.EventHandler(this.Ladder_Builder);
            // 
            // LadderWidthText
            // 
            this.structuresExtender.SetAttributeName(this.LadderWidthText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderWidthText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderWidthText, null);
            this.LadderWidthText.Enabled = false;
            this.LadderWidthText.Location = new System.Drawing.Point(204, 199);
            this.LadderWidthText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderWidthText.Name = "LadderWidthText";
            this.LadderWidthText.Size = new System.Drawing.Size(89, 22);
            this.LadderWidthText.TabIndex = 26;
            this.LadderWidthText.Text = "450";
            // 
            // LadderWidth
            // 
            this.structuresExtender.SetAttributeName(this.LadderWidth, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderWidth, null);
            this.LadderWidth.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LadderWidth, null);
            this.LadderWidth.Enabled = false;
            this.LadderWidth.Location = new System.Drawing.Point(5, 202);
            this.LadderWidth.Name = "LadderWidth";
            this.LadderWidth.Size = new System.Drawing.Size(90, 16);
            this.LadderWidth.TabIndex = 25;
            this.LadderWidth.Text = "Ladder Width:";
            // 
            // LadderPlateHeightText
            // 
            this.structuresExtender.SetAttributeName(this.LadderPlateHeightText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderPlateHeightText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderPlateHeightText, null);
            this.LadderPlateHeightText.Enabled = false;
            this.LadderPlateHeightText.Location = new System.Drawing.Point(204, 167);
            this.LadderPlateHeightText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderPlateHeightText.Name = "LadderPlateHeightText";
            this.LadderPlateHeightText.Size = new System.Drawing.Size(88, 22);
            this.LadderPlateHeightText.TabIndex = 16;
            this.LadderPlateHeightText.Text = "50";
            // 
            // LadderPlateHeight
            // 
            this.structuresExtender.SetAttributeName(this.LadderPlateHeight, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderPlateHeight, null);
            this.LadderPlateHeight.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LadderPlateHeight, null);
            this.LadderPlateHeight.Enabled = false;
            this.LadderPlateHeight.Location = new System.Drawing.Point(5, 167);
            this.LadderPlateHeight.Name = "LadderPlateHeight";
            this.LadderPlateHeight.Size = new System.Drawing.Size(83, 16);
            this.LadderPlateHeight.TabIndex = 15;
            this.LadderPlateHeight.Text = "Plate Height:";
            // 
            // LadderRungSpacing
            // 
            this.structuresExtender.SetAttributeName(this.LadderRungSpacing, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderRungSpacing, null);
            this.LadderRungSpacing.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LadderRungSpacing, null);
            this.LadderRungSpacing.Enabled = false;
            this.LadderRungSpacing.Location = new System.Drawing.Point(5, 134);
            this.LadderRungSpacing.Name = "LadderRungSpacing";
            this.LadderRungSpacing.Size = new System.Drawing.Size(95, 16);
            this.LadderRungSpacing.TabIndex = 10;
            this.LadderRungSpacing.Text = "Rung Spacing:";
            this.LadderRungSpacing.Click += new System.EventHandler(this.LadderRung_Spacing);
            // 
            // LadderRungSpacingText
            // 
            this.structuresExtender.SetAttributeName(this.LadderRungSpacingText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderRungSpacingText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderRungSpacingText, null);
            this.LadderRungSpacingText.Enabled = false;
            this.LadderRungSpacingText.Location = new System.Drawing.Point(204, 130);
            this.LadderRungSpacingText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderRungSpacingText.Name = "LadderRungSpacingText";
            this.LadderRungSpacingText.Size = new System.Drawing.Size(88, 22);
            this.LadderRungSpacingText.TabIndex = 9;
            this.LadderRungSpacingText.Text = "280";
            this.LadderRungSpacingText.TextChanged += new System.EventHandler(this.LadderRungSpacing_Text);
            // 
            // HatchWidthValue
            // 
            this.structuresExtender.SetAttributeName(this.HatchWidthValue, null);
            this.structuresExtender.SetAttributeTypeName(this.HatchWidthValue, null);
            this.structuresExtender.SetBindPropertyName(this.HatchWidthValue, null);
            this.HatchWidthValue.Enabled = false;
            this.HatchWidthValue.Location = new System.Drawing.Point(204, 231);
            this.HatchWidthValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HatchWidthValue.Name = "HatchWidthValue";
            this.HatchWidthValue.Size = new System.Drawing.Size(89, 22);
            this.HatchWidthValue.TabIndex = 11;
            this.HatchWidthValue.Text = "900";
            this.HatchWidthValue.TextChanged += new System.EventHandler(this.HatchWidth_TextChanged_1);
            // 
            // HatchWidthName
            // 
            this.structuresExtender.SetAttributeName(this.HatchWidthName, null);
            this.structuresExtender.SetAttributeTypeName(this.HatchWidthName, null);
            this.HatchWidthName.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.HatchWidthName, null);
            this.HatchWidthName.Enabled = false;
            this.HatchWidthName.Location = new System.Drawing.Point(7, 234);
            this.HatchWidthName.Name = "HatchWidthName";
            this.HatchWidthName.Size = new System.Drawing.Size(82, 16);
            this.HatchWidthName.TabIndex = 10;
            this.HatchWidthName.Text = "Hatch Width:";
            // 
            // tableLayoutPanel16
            // 
            this.structuresExtender.SetAttributeName(this.tableLayoutPanel16, null);
            this.structuresExtender.SetAttributeTypeName(this.tableLayoutPanel16, null);
            this.structuresExtender.SetBindPropertyName(this.tableLayoutPanel16, null);
            this.tableLayoutPanel16.ColumnCount = 4;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tableLayoutPanel16.Controls.Add(this.LadderPlateSelect, 3, 12);
            this.tableLayoutPanel16.Controls.Add(this.LadderPlateProfileText, 2, 12);
            this.tableLayoutPanel16.Controls.Add(this.LadderHatchProfileName, 2, 0);
            this.tableLayoutPanel16.Controls.Add(this.LadderRungProfileText, 2, 11);
            this.tableLayoutPanel16.Controls.Add(this.LadderPlate, 0, 12);
            this.tableLayoutPanel16.Controls.Add(this.LadderRungSelect, 3, 11);
            this.tableLayoutPanel16.Controls.Add(this.LadderPlateMaterialText, 1, 12);
            this.tableLayoutPanel16.Controls.Add(this.LadderHatchMaterialName, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.LadderRailSelect, 3, 10);
            this.tableLayoutPanel16.Controls.Add(this.LadderSideRail, 0, 10);
            this.tableLayoutPanel16.Controls.Add(this.LadderRailProfileText, 2, 10);
            this.tableLayoutPanel16.Controls.Add(this.LadderRung, 0, 11);
            this.tableLayoutPanel16.Controls.Add(this.LadderSideRailMaterialText, 1, 10);
            this.tableLayoutPanel16.Controls.Add(this.LadderRungMaterialText, 1, 11);
            this.tableLayoutPanel16.Controls.Add(this.HatchBeamMaterialName, 0, 13);
            this.tableLayoutPanel16.Controls.Add(this.HatchBeamMaterial, 1, 13);
            this.tableLayoutPanel16.Controls.Add(this.HatchBeamProfile, 2, 13);
            this.tableLayoutPanel16.Controls.Add(this.HatchBeamProfileSelector, 3, 13);
            this.tableLayoutPanel16.Location = new System.Drawing.Point(7, 303);
            this.tableLayoutPanel16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 14;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(356, 162);
            this.tableLayoutPanel16.TabIndex = 9;
            // 
            // LadderPlateSelect
            // 
            this.structuresExtender.SetAttributeName(this.LadderPlateSelect, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderPlateSelect, null);
            this.LadderPlateSelect.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.LadderPlateSelect, null);
            this.LadderPlateSelect.ButtonText = "Select...";
            this.LadderPlateSelect.Enabled = false;
            this.LadderPlateSelect.Location = new System.Drawing.Point(284, 100);
            this.LadderPlateSelect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LadderPlateSelect.Name = "LadderPlateSelect";
            this.LadderPlateSelect.SelectedProfile = "";
            this.LadderPlateSelect.Size = new System.Drawing.Size(65, 22);
            this.LadderPlateSelect.TabIndex = 34;
            this.LadderPlateSelect.SelectionDone += new System.EventHandler(this.LadderPlateProfoile_Done);
            // 
            // LadderPlateProfileText
            // 
            this.structuresExtender.SetAttributeName(this.LadderPlateProfileText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderPlateProfileText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderPlateProfileText, null);
            this.LadderPlateProfileText.Enabled = false;
            this.LadderPlateProfileText.Location = new System.Drawing.Point(179, 96);
            this.LadderPlateProfileText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderPlateProfileText.Name = "LadderPlateProfileText";
            this.LadderPlateProfileText.Size = new System.Drawing.Size(84, 22);
            this.LadderPlateProfileText.TabIndex = 38;
            this.LadderPlateProfileText.Text = "PLT10";
            // 
            // LadderHatchProfileName
            // 
            this.structuresExtender.SetAttributeName(this.LadderHatchProfileName, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderHatchProfileName, null);
            this.LadderHatchProfileName.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LadderHatchProfileName, null);
            this.LadderHatchProfileName.Enabled = false;
            this.LadderHatchProfileName.Location = new System.Drawing.Point(179, 0);
            this.LadderHatchProfileName.Name = "LadderHatchProfileName";
            this.LadderHatchProfileName.Size = new System.Drawing.Size(45, 16);
            this.LadderHatchProfileName.TabIndex = 1;
            this.LadderHatchProfileName.Text = "Profile";
            // 
            // LadderRungProfileText
            // 
            this.structuresExtender.SetAttributeName(this.LadderRungProfileText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderRungProfileText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderRungProfileText, null);
            this.LadderRungProfileText.Enabled = false;
            this.LadderRungProfileText.Location = new System.Drawing.Point(179, 62);
            this.LadderRungProfileText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderRungProfileText.Name = "LadderRungProfileText";
            this.LadderRungProfileText.Size = new System.Drawing.Size(83, 22);
            this.LadderRungProfileText.TabIndex = 36;
            this.LadderRungProfileText.Text = "D20";
            // 
            // LadderPlate
            // 
            this.structuresExtender.SetAttributeName(this.LadderPlate, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderPlate, null);
            this.LadderPlate.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LadderPlate, null);
            this.LadderPlate.Enabled = false;
            this.LadderPlate.Location = new System.Drawing.Point(3, 94);
            this.LadderPlate.Name = "LadderPlate";
            this.LadderPlate.Size = new System.Drawing.Size(41, 16);
            this.LadderPlate.TabIndex = 29;
            this.LadderPlate.Text = "Plate:";
            // 
            // LadderRungSelect
            // 
            this.structuresExtender.SetAttributeName(this.LadderRungSelect, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderRungSelect, null);
            this.LadderRungSelect.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.LadderRungSelect, null);
            this.LadderRungSelect.ButtonText = "Select...";
            this.LadderRungSelect.Enabled = false;
            this.LadderRungSelect.Location = new System.Drawing.Point(284, 66);
            this.LadderRungSelect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LadderRungSelect.Name = "LadderRungSelect";
            this.LadderRungSelect.SelectedProfile = "";
            this.LadderRungSelect.Size = new System.Drawing.Size(65, 22);
            this.LadderRungSelect.TabIndex = 33;
            this.LadderRungSelect.SelectionDone += new System.EventHandler(this.LadderRungProfoile_Done);
            // 
            // LadderPlateMaterialText
            // 
            this.structuresExtender.SetAttributeName(this.LadderPlateMaterialText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderPlateMaterialText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderPlateMaterialText, null);
            this.LadderPlateMaterialText.Enabled = false;
            this.LadderPlateMaterialText.Location = new System.Drawing.Point(96, 96);
            this.LadderPlateMaterialText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderPlateMaterialText.Name = "LadderPlateMaterialText";
            this.LadderPlateMaterialText.Size = new System.Drawing.Size(77, 22);
            this.LadderPlateMaterialText.TabIndex = 18;
            this.LadderPlateMaterialText.Text = "C350L0";
            // 
            // LadderHatchMaterialName
            // 
            this.structuresExtender.SetAttributeName(this.LadderHatchMaterialName, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderHatchMaterialName, null);
            this.LadderHatchMaterialName.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LadderHatchMaterialName, null);
            this.LadderHatchMaterialName.Enabled = false;
            this.LadderHatchMaterialName.Location = new System.Drawing.Point(96, 0);
            this.LadderHatchMaterialName.Name = "LadderHatchMaterialName";
            this.LadderHatchMaterialName.Size = new System.Drawing.Size(55, 16);
            this.LadderHatchMaterialName.TabIndex = 3;
            this.LadderHatchMaterialName.Text = "Material";
            // 
            // LadderRailSelect
            // 
            this.structuresExtender.SetAttributeName(this.LadderRailSelect, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderRailSelect, null);
            this.LadderRailSelect.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.LadderRailSelect, null);
            this.LadderRailSelect.ButtonText = "Select...";
            this.LadderRailSelect.Enabled = false;
            this.LadderRailSelect.Location = new System.Drawing.Point(284, 26);
            this.LadderRailSelect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.LadderRailSelect.Name = "LadderRailSelect";
            this.LadderRailSelect.SelectedProfile = "";
            this.LadderRailSelect.Size = new System.Drawing.Size(65, 28);
            this.LadderRailSelect.TabIndex = 32;
            this.LadderRailSelect.SelectionDone += new System.EventHandler(this.LadderRailProfoile_Done);
            // 
            // LadderSideRail
            // 
            this.structuresExtender.SetAttributeName(this.LadderSideRail, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderSideRail, null);
            this.LadderSideRail.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LadderSideRail, null);
            this.LadderSideRail.Enabled = false;
            this.LadderSideRail.Location = new System.Drawing.Point(3, 20);
            this.LadderSideRail.Name = "LadderSideRail";
            this.LadderSideRail.Size = new System.Drawing.Size(34, 16);
            this.LadderSideRail.TabIndex = 27;
            this.LadderSideRail.Text = "Rail:";
            // 
            // LadderRailProfileText
            // 
            this.structuresExtender.SetAttributeName(this.LadderRailProfileText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderRailProfileText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderRailProfileText, null);
            this.LadderRailProfileText.Enabled = false;
            this.LadderRailProfileText.Location = new System.Drawing.Point(179, 22);
            this.LadderRailProfileText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderRailProfileText.Name = "LadderRailProfileText";
            this.LadderRailProfileText.Size = new System.Drawing.Size(84, 22);
            this.LadderRailProfileText.TabIndex = 31;
            this.LadderRailProfileText.Text = "FL65*12";
            // 
            // LadderRung
            // 
            this.structuresExtender.SetAttributeName(this.LadderRung, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderRung, null);
            this.LadderRung.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LadderRung, null);
            this.LadderRung.Enabled = false;
            this.LadderRung.Location = new System.Drawing.Point(3, 60);
            this.LadderRung.Name = "LadderRung";
            this.LadderRung.Size = new System.Drawing.Size(42, 16);
            this.LadderRung.TabIndex = 28;
            this.LadderRung.Text = "Rung:";
            // 
            // LadderSideRailMaterialText
            // 
            this.structuresExtender.SetAttributeName(this.LadderSideRailMaterialText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderSideRailMaterialText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderSideRailMaterialText, null);
            this.LadderSideRailMaterialText.Enabled = false;
            this.LadderSideRailMaterialText.Location = new System.Drawing.Point(96, 22);
            this.LadderSideRailMaterialText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderSideRailMaterialText.Name = "LadderSideRailMaterialText";
            this.LadderSideRailMaterialText.Size = new System.Drawing.Size(75, 22);
            this.LadderSideRailMaterialText.TabIndex = 24;
            this.LadderSideRailMaterialText.Text = "C350L0";
            // 
            // LadderRungMaterialText
            // 
            this.structuresExtender.SetAttributeName(this.LadderRungMaterialText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderRungMaterialText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderRungMaterialText, null);
            this.LadderRungMaterialText.Enabled = false;
            this.LadderRungMaterialText.Location = new System.Drawing.Point(96, 62);
            this.LadderRungMaterialText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderRungMaterialText.Name = "LadderRungMaterialText";
            this.LadderRungMaterialText.Size = new System.Drawing.Size(75, 22);
            this.LadderRungMaterialText.TabIndex = 12;
            this.LadderRungMaterialText.Text = "C350L0";
            this.LadderRungMaterialText.TextChanged += new System.EventHandler(this.LadderRungMaterial_Text);
            // 
            // HatchBeamMaterialName
            // 
            this.structuresExtender.SetAttributeName(this.HatchBeamMaterialName, null);
            this.structuresExtender.SetAttributeTypeName(this.HatchBeamMaterialName, null);
            this.HatchBeamMaterialName.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.HatchBeamMaterialName, null);
            this.HatchBeamMaterialName.Enabled = false;
            this.HatchBeamMaterialName.Location = new System.Drawing.Point(3, 128);
            this.HatchBeamMaterialName.Name = "HatchBeamMaterialName";
            this.HatchBeamMaterialName.Size = new System.Drawing.Size(78, 16);
            this.HatchBeamMaterialName.TabIndex = 1;
            this.HatchBeamMaterialName.Text = "HatchBeam";
            // 
            // HatchBeamMaterial
            // 
            this.structuresExtender.SetAttributeName(this.HatchBeamMaterial, null);
            this.structuresExtender.SetAttributeTypeName(this.HatchBeamMaterial, null);
            this.structuresExtender.SetBindPropertyName(this.HatchBeamMaterial, null);
            this.HatchBeamMaterial.Enabled = false;
            this.HatchBeamMaterial.Location = new System.Drawing.Point(96, 130);
            this.HatchBeamMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HatchBeamMaterial.Name = "HatchBeamMaterial";
            this.HatchBeamMaterial.Size = new System.Drawing.Size(68, 22);
            this.HatchBeamMaterial.TabIndex = 2;
            this.HatchBeamMaterial.Text = "C350L0";
            this.HatchBeamMaterial.TextChanged += new System.EventHandler(this.HatchBeamMaterial_TextChanged);
            // 
            // HatchBeamProfile
            // 
            this.structuresExtender.SetAttributeName(this.HatchBeamProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.HatchBeamProfile, null);
            this.structuresExtender.SetBindPropertyName(this.HatchBeamProfile, null);
            this.HatchBeamProfile.Enabled = false;
            this.HatchBeamProfile.Location = new System.Drawing.Point(179, 130);
            this.HatchBeamProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.HatchBeamProfile.Name = "HatchBeamProfile";
            this.HatchBeamProfile.Size = new System.Drawing.Size(97, 22);
            this.HatchBeamProfile.TabIndex = 3;
            this.HatchBeamProfile.Text = "RHS50*30*4.0";
            this.HatchBeamProfile.TextChanged += new System.EventHandler(this.HatchBeamProfile_TextChanged);
            this.HatchBeamProfile.Validating += new System.ComponentModel.CancelEventHandler(this.HatchBeamProfile_Validating);
            // 
            // HatchBeamProfileSelector
            // 
            this.structuresExtender.SetAttributeName(this.HatchBeamProfileSelector, null);
            this.structuresExtender.SetAttributeTypeName(this.HatchBeamProfileSelector, null);
            this.HatchBeamProfileSelector.BackColor = System.Drawing.Color.Transparent;
            this.structuresExtender.SetBindPropertyName(this.HatchBeamProfileSelector, null);
            this.HatchBeamProfileSelector.ButtonText = "Select...";
            this.HatchBeamProfileSelector.Enabled = false;
            this.HatchBeamProfileSelector.Location = new System.Drawing.Point(284, 133);
            this.HatchBeamProfileSelector.Margin = new System.Windows.Forms.Padding(5);
            this.HatchBeamProfileSelector.Name = "HatchBeamProfileSelector";
            this.HatchBeamProfileSelector.SelectedProfile = "";
            this.HatchBeamProfileSelector.Size = new System.Drawing.Size(60, 23);
            this.HatchBeamProfileSelector.TabIndex = 12;
            this.HatchBeamProfileSelector.SelectClicked += new System.EventHandler(this.HatchBeamProfileSelector_SelectClicked);
            this.HatchBeamProfileSelector.SelectionDone += new System.EventHandler(this.HatchBeamProfileSelector_SelectionDone);
            // 
            // LadderOffsetSideText
            // 
            this.structuresExtender.SetAttributeName(this.LadderOffsetSideText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderOffsetSideText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderOffsetSideText, null);
            this.LadderOffsetSideText.Enabled = false;
            this.LadderOffsetSideText.Location = new System.Drawing.Point(203, 96);
            this.LadderOffsetSideText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderOffsetSideText.Name = "LadderOffsetSideText";
            this.LadderOffsetSideText.Size = new System.Drawing.Size(89, 22);
            this.LadderOffsetSideText.TabIndex = 6;
            this.LadderOffsetSideText.Text = "165";
            this.LadderOffsetSideText.TextChanged += new System.EventHandler(this.LadderOffsetSide_Text);
            // 
            // LadderOffsetfromSide
            // 
            this.structuresExtender.SetAttributeName(this.LadderOffsetfromSide, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderOffsetfromSide, null);
            this.LadderOffsetfromSide.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LadderOffsetfromSide, null);
            this.LadderOffsetfromSide.Enabled = false;
            this.LadderOffsetfromSide.Location = new System.Drawing.Point(3, 98);
            this.LadderOffsetfromSide.Name = "LadderOffsetfromSide";
            this.LadderOffsetfromSide.Size = new System.Drawing.Size(150, 16);
            this.LadderOffsetfromSide.TabIndex = 5;
            this.LadderOffsetfromSide.Text = "Ladder Offset from Side:";
            this.LadderOffsetfromSide.Click += new System.EventHandler(this.LadderOffsetfrom_Side);
            // 
            // LadderOffsetBack
            // 
            this.structuresExtender.SetAttributeName(this.LadderOffsetBack, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderOffsetBack, null);
            this.LadderOffsetBack.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LadderOffsetBack, null);
            this.LadderOffsetBack.Enabled = false;
            this.LadderOffsetBack.Location = new System.Drawing.Point(3, 64);
            this.LadderOffsetBack.Name = "LadderOffsetBack";
            this.LadderOffsetBack.Size = new System.Drawing.Size(153, 16);
            this.LadderOffsetBack.TabIndex = 4;
            this.LadderOffsetBack.Text = "Ladder Offset from Back:";
            this.LadderOffsetBack.Click += new System.EventHandler(this.LadderOffset_Back);
            // 
            // LadderOffsetBackText
            // 
            this.structuresExtender.SetAttributeName(this.LadderOffsetBackText, null);
            this.structuresExtender.SetAttributeTypeName(this.LadderOffsetBackText, null);
            this.structuresExtender.SetBindPropertyName(this.LadderOffsetBackText, null);
            this.LadderOffsetBackText.Enabled = false;
            this.LadderOffsetBackText.Location = new System.Drawing.Point(203, 62);
            this.LadderOffsetBackText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LadderOffsetBackText.Name = "LadderOffsetBackText";
            this.LadderOffsetBackText.Size = new System.Drawing.Size(89, 22);
            this.LadderOffsetBackText.TabIndex = 3;
            this.LadderOffsetBackText.Text = "165";
            this.LadderOffsetBackText.TextChanged += new System.EventHandler(this.LadderOffsetBack_Text);
            // 
            // NoLadder
            // 
            this.structuresExtender.SetAttributeName(this.NoLadder, null);
            this.structuresExtender.SetAttributeTypeName(this.NoLadder, null);
            this.NoLadder.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.NoLadder, null);
            this.NoLadder.Checked = true;
            this.NoLadder.Location = new System.Drawing.Point(229, 25);
            this.NoLadder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NoLadder.Name = "NoLadder";
            this.NoLadder.Size = new System.Drawing.Size(61, 20);
            this.NoLadder.TabIndex = 2;
            this.NoLadder.TabStop = true;
            this.NoLadder.Text = "None";
            this.NoLadder.UseVisualStyleBackColor = true;
            this.NoLadder.CheckedChanged += new System.EventHandler(this.No_Ladder);
            // 
            // RightLadder
            // 
            this.structuresExtender.SetAttributeName(this.RightLadder, null);
            this.structuresExtender.SetAttributeTypeName(this.RightLadder, null);
            this.RightLadder.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.RightLadder, null);
            this.RightLadder.Location = new System.Drawing.Point(111, 25);
            this.RightLadder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RightLadder.Name = "RightLadder";
            this.RightLadder.Size = new System.Drawing.Size(90, 20);
            this.RightLadder.TabIndex = 1;
            this.RightLadder.TabStop = true;
            this.RightLadder.Text = "Right Side";
            this.RightLadder.UseVisualStyleBackColor = true;
            this.RightLadder.CheckedChanged += new System.EventHandler(this.Right_Ladder);
            // 
            // LeftLadder
            // 
            this.structuresExtender.SetAttributeName(this.LeftLadder, null);
            this.structuresExtender.SetAttributeTypeName(this.LeftLadder, null);
            this.LeftLadder.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LeftLadder, null);
            this.LeftLadder.Location = new System.Drawing.Point(5, 25);
            this.LeftLadder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LeftLadder.Name = "LeftLadder";
            this.LeftLadder.Size = new System.Drawing.Size(80, 20);
            this.LeftLadder.TabIndex = 0;
            this.LeftLadder.TabStop = true;
            this.LeftLadder.Text = "Left Side";
            this.LeftLadder.UseVisualStyleBackColor = true;
            this.LeftLadder.CheckedChanged += new System.EventHandler(this.Left_Ladder);
            // 
            // groupBox3
            // 
            this.structuresExtender.SetAttributeName(this.groupBox3, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox3, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox3, null);
            this.groupBox3.Controls.Add(this.ThreeDButton);
            this.groupBox3.Controls.Add(this.TwoDButton);
            this.groupBox3.Controls.Add(this.enableFascia);
            this.groupBox3.Controls.Add(this.fasciaHeight);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(3, 238);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(309, 110);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fascia Box";
            // 
            // ThreeDButton
            // 
            this.structuresExtender.SetAttributeName(this.ThreeDButton, null);
            this.structuresExtender.SetAttributeTypeName(this.ThreeDButton, null);
            this.ThreeDButton.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.ThreeDButton, null);
            this.ThreeDButton.Enabled = false;
            this.ThreeDButton.Location = new System.Drawing.Point(141, 86);
            this.ThreeDButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ThreeDButton.Name = "ThreeDButton";
            this.ThreeDButton.Size = new System.Drawing.Size(45, 20);
            this.ThreeDButton.TabIndex = 37;
            this.ThreeDButton.Text = "3D";
            this.ThreeDButton.UseVisualStyleBackColor = true;
            this.ThreeDButton.CheckedChanged += new System.EventHandler(this.ThreeDButton_CheckedChanged);
            // 
            // TwoDButton
            // 
            this.structuresExtender.SetAttributeName(this.TwoDButton, null);
            this.structuresExtender.SetAttributeTypeName(this.TwoDButton, null);
            this.TwoDButton.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.TwoDButton, null);
            this.TwoDButton.Checked = true;
            this.TwoDButton.Enabled = false;
            this.TwoDButton.Location = new System.Drawing.Point(12, 86);
            this.TwoDButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TwoDButton.Name = "TwoDButton";
            this.TwoDButton.Size = new System.Drawing.Size(45, 20);
            this.TwoDButton.TabIndex = 36;
            this.TwoDButton.TabStop = true;
            this.TwoDButton.Text = "2D";
            this.TwoDButton.UseVisualStyleBackColor = true;
            this.TwoDButton.CheckedChanged += new System.EventHandler(this.TwoDButton_CheckedChanged);
            // 
            // enableFascia
            // 
            this.structuresExtender.SetAttributeName(this.enableFascia, null);
            this.structuresExtender.SetAttributeTypeName(this.enableFascia, null);
            this.enableFascia.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.enableFascia, null);
            this.enableFascia.Location = new System.Drawing.Point(13, 22);
            this.enableFascia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enableFascia.Name = "enableFascia";
            this.enableFascia.Size = new System.Drawing.Size(142, 20);
            this.enableFascia.TabIndex = 35;
            this.enableFascia.Text = "Enable Fascia Box";
            this.enableFascia.UseVisualStyleBackColor = true;
            this.enableFascia.CheckedChanged += new System.EventHandler(this.enableFascia_CheckedChanged);
            // 
            // fasciaHeight
            // 
            this.structuresExtender.SetAttributeName(this.fasciaHeight, null);
            this.structuresExtender.SetAttributeTypeName(this.fasciaHeight, null);
            this.structuresExtender.SetBindPropertyName(this.fasciaHeight, null);
            this.fasciaHeight.Enabled = false;
            this.fasciaHeight.Location = new System.Drawing.Point(204, 52);
            this.fasciaHeight.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.fasciaHeight.Name = "fasciaHeight";
            this.fasciaHeight.Size = new System.Drawing.Size(68, 22);
            this.fasciaHeight.TabIndex = 32;
            // 
            // label2
            // 
            this.structuresExtender.SetAttributeName(this.label2, null);
            this.structuresExtender.SetAttributeTypeName(this.label2, null);
            this.label2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label2, null);
            this.label2.Location = new System.Drawing.Point(11, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 31;
            this.label2.Text = "Fascia Box Height:";
            // 
            // groupBox15
            // 
            this.structuresExtender.SetAttributeName(this.groupBox15, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox15, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox15, null);
            this.groupBox15.Controls.Add(this.tabControl4);
            this.groupBox15.Controls.Add(this.FlashingsEnabled);
            this.groupBox15.Controls.Add(this.ManualFlashDim);
            this.groupBox15.Controls.Add(this.AutoFlashDim);
            this.groupBox15.Controls.Add(this.FlashingThickness);
            this.groupBox15.Controls.Add(this.FlashingThicknessLabel);
            this.groupBox15.Controls.Add(this.FlashingColour);
            this.groupBox15.Controls.Add(this.label40);
            this.groupBox15.Location = new System.Drawing.Point(1115, 16);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox15.Size = new System.Drawing.Size(576, 427);
            this.groupBox15.TabIndex = 27;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Flashings";
            // 
            // tabControl4
            // 
            this.structuresExtender.SetAttributeName(this.tabControl4, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl4, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl4, null);
            this.tabControl4.Controls.Add(this.TopFlashingTab);
            this.tabControl4.Controls.Add(this.BottomFlashingTab);
            this.tabControl4.Controls.Add(this.SideFlashingTab);
            this.tabControl4.Location = new System.Drawing.Point(15, 158);
            this.tabControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(545, 250);
            this.tabControl4.TabIndex = 36;
            // 
            // TopFlashingTab
            // 
            this.structuresExtender.SetAttributeName(this.TopFlashingTab, null);
            this.structuresExtender.SetAttributeTypeName(this.TopFlashingTab, null);
            this.structuresExtender.SetBindPropertyName(this.TopFlashingTab, null);
            this.TopFlashingTab.Controls.Add(this.FlashingDimK);
            this.TopFlashingTab.Controls.Add(this.FlashingDimJ);
            this.TopFlashingTab.Controls.Add(this.FlashingDimM);
            this.TopFlashingTab.Controls.Add(this.FlashingDimL);
            this.TopFlashingTab.Controls.Add(this.FlashingDimC);
            this.TopFlashingTab.Controls.Add(this.FlashingDimB);
            this.TopFlashingTab.Controls.Add(this.FlashingDimA);
            this.TopFlashingTab.Controls.Add(this.pictureBox4);
            this.TopFlashingTab.Location = new System.Drawing.Point(4, 25);
            this.TopFlashingTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TopFlashingTab.Name = "TopFlashingTab";
            this.TopFlashingTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TopFlashingTab.Size = new System.Drawing.Size(537, 221);
            this.TopFlashingTab.TabIndex = 0;
            this.TopFlashingTab.Text = "Top";
            this.TopFlashingTab.UseVisualStyleBackColor = true;
            // 
            // FlashingDimK
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimK, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimK, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimK, null);
            this.FlashingDimK.Enabled = false;
            this.FlashingDimK.Location = new System.Drawing.Point(5, 39);
            this.FlashingDimK.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimK.Name = "FlashingDimK";
            this.FlashingDimK.Size = new System.Drawing.Size(61, 22);
            this.FlashingDimK.TabIndex = 35;
            this.FlashingDimK.TextChanged += new System.EventHandler(this.FlashingDimK_TextChanged);
            // 
            // FlashingDimJ
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimJ, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimJ, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimJ, null);
            this.FlashingDimJ.Enabled = false;
            this.FlashingDimJ.Location = new System.Drawing.Point(5, 75);
            this.FlashingDimJ.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimJ.Name = "FlashingDimJ";
            this.FlashingDimJ.Size = new System.Drawing.Size(61, 22);
            this.FlashingDimJ.TabIndex = 34;
            this.FlashingDimJ.TextChanged += new System.EventHandler(this.FlashingDimJ_TextChanged);
            // 
            // FlashingDimM
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimM, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimM, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimM, null);
            this.FlashingDimM.Enabled = false;
            this.FlashingDimM.Location = new System.Drawing.Point(453, 127);
            this.FlashingDimM.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimM.Name = "FlashingDimM";
            this.FlashingDimM.Size = new System.Drawing.Size(65, 22);
            this.FlashingDimM.TabIndex = 33;
            this.FlashingDimM.TextChanged += new System.EventHandler(this.FlashingDimM_TextChanged);
            // 
            // FlashingDimL
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimL, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimL, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimL, null);
            this.FlashingDimL.Enabled = false;
            this.FlashingDimL.Location = new System.Drawing.Point(456, 165);
            this.FlashingDimL.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimL.Name = "FlashingDimL";
            this.FlashingDimL.Size = new System.Drawing.Size(63, 22);
            this.FlashingDimL.TabIndex = 32;
            this.FlashingDimL.TextChanged += new System.EventHandler(this.FlashingDimL_TextChanged);
            // 
            // FlashingDimC
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimC, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimC, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimC, null);
            this.FlashingDimC.Enabled = false;
            this.FlashingDimC.Location = new System.Drawing.Point(291, 175);
            this.FlashingDimC.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimC.Name = "FlashingDimC";
            this.FlashingDimC.Size = new System.Drawing.Size(67, 22);
            this.FlashingDimC.TabIndex = 31;
            this.FlashingDimC.TextChanged += new System.EventHandler(this.FlashingDimC_TextChanged);
            // 
            // FlashingDimB
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimB, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimB, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimB, null);
            this.FlashingDimB.Enabled = false;
            this.FlashingDimB.Location = new System.Drawing.Point(157, 90);
            this.FlashingDimB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FlashingDimB.Name = "FlashingDimB";
            this.FlashingDimB.Size = new System.Drawing.Size(68, 22);
            this.FlashingDimB.TabIndex = 30;
            this.FlashingDimB.TextChanged += new System.EventHandler(this.FlashingDimB_TextChanged);
            // 
            // FlashingDimA
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimA, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimA, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimA, null);
            this.FlashingDimA.Enabled = false;
            this.FlashingDimA.Location = new System.Drawing.Point(157, 9);
            this.FlashingDimA.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FlashingDimA.Name = "FlashingDimA";
            this.FlashingDimA.Size = new System.Drawing.Size(68, 22);
            this.FlashingDimA.TabIndex = 29;
            this.FlashingDimA.TextChanged += new System.EventHandler(this.FlashingDimA_TextChanged);
            // 
            // pictureBox4
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox4, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox4, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox4, null);
            this.pictureBox4.Image = global::BeamApplication.Properties.Resources.Flashings_drawio;
            this.pictureBox4.Location = new System.Drawing.Point(73, 30);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(377, 160);
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // BottomFlashingTab
            // 
            this.structuresExtender.SetAttributeName(this.BottomFlashingTab, null);
            this.structuresExtender.SetAttributeTypeName(this.BottomFlashingTab, null);
            this.structuresExtender.SetBindPropertyName(this.BottomFlashingTab, null);
            this.BottomFlashingTab.Controls.Add(this.FlashingDimR);
            this.BottomFlashingTab.Controls.Add(this.FlashingDimS);
            this.BottomFlashingTab.Controls.Add(this.FlashingDimH);
            this.BottomFlashingTab.Controls.Add(this.FlashingDimI);
            this.BottomFlashingTab.Controls.Add(this.FlashingDimG);
            this.BottomFlashingTab.Controls.Add(this.pictureBox6);
            this.BottomFlashingTab.Location = new System.Drawing.Point(4, 25);
            this.BottomFlashingTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BottomFlashingTab.Name = "BottomFlashingTab";
            this.BottomFlashingTab.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BottomFlashingTab.Size = new System.Drawing.Size(537, 221);
            this.BottomFlashingTab.TabIndex = 1;
            this.BottomFlashingTab.Text = "Bottom";
            this.BottomFlashingTab.UseVisualStyleBackColor = true;
            // 
            // FlashingDimR
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimR, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimR, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimR, null);
            this.FlashingDimR.Enabled = false;
            this.FlashingDimR.Location = new System.Drawing.Point(357, 177);
            this.FlashingDimR.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimR.Name = "FlashingDimR";
            this.FlashingDimR.Size = new System.Drawing.Size(63, 22);
            this.FlashingDimR.TabIndex = 41;
            this.FlashingDimR.TextChanged += new System.EventHandler(this.FlashingDimR_TextChanged);
            // 
            // FlashingDimS
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimS, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimS, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimS, null);
            this.FlashingDimS.Enabled = false;
            this.FlashingDimS.Location = new System.Drawing.Point(357, 127);
            this.FlashingDimS.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimS.Name = "FlashingDimS";
            this.FlashingDimS.Size = new System.Drawing.Size(63, 22);
            this.FlashingDimS.TabIndex = 40;
            this.FlashingDimS.TextChanged += new System.EventHandler(this.FlashingDimS_TextChanged);
            // 
            // FlashingDimH
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimH, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimH, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimH, null);
            this.FlashingDimH.Enabled = false;
            this.FlashingDimH.Location = new System.Drawing.Point(196, 116);
            this.FlashingDimH.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimH.Name = "FlashingDimH";
            this.FlashingDimH.Size = new System.Drawing.Size(68, 22);
            this.FlashingDimH.TabIndex = 39;
            this.FlashingDimH.TextChanged += new System.EventHandler(this.FlashingDimH_TextChanged);
            // 
            // FlashingDimI
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimI, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimI, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimI, null);
            this.FlashingDimI.Enabled = false;
            this.FlashingDimI.Location = new System.Drawing.Point(45, 64);
            this.FlashingDimI.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimI.Name = "FlashingDimI";
            this.FlashingDimI.Size = new System.Drawing.Size(61, 22);
            this.FlashingDimI.TabIndex = 38;
            this.FlashingDimI.TextChanged += new System.EventHandler(this.FlashingDimI_TextChanged);
            // 
            // FlashingDimG
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimG, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimG, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimG, null);
            this.FlashingDimG.Enabled = false;
            this.FlashingDimG.Location = new System.Drawing.Point(196, 17);
            this.FlashingDimG.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimG.Name = "FlashingDimG";
            this.FlashingDimG.Size = new System.Drawing.Size(68, 22);
            this.FlashingDimG.TabIndex = 37;
            this.FlashingDimG.TextChanged += new System.EventHandler(this.FlashingDimG_TextChanged);
            // 
            // pictureBox6
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox6, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox6, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox6, null);
            this.pictureBox6.Image = global::BeamApplication.Properties.Resources.Flashings_drawio__1_;
            this.pictureBox6.Location = new System.Drawing.Point(113, 39);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(251, 155);
            this.pictureBox6.TabIndex = 1;
            this.pictureBox6.TabStop = false;
            // 
            // SideFlashingTab
            // 
            this.structuresExtender.SetAttributeName(this.SideFlashingTab, null);
            this.structuresExtender.SetAttributeTypeName(this.SideFlashingTab, null);
            this.structuresExtender.SetBindPropertyName(this.SideFlashingTab, null);
            this.SideFlashingTab.Controls.Add(this.FlashingDimO);
            this.SideFlashingTab.Controls.Add(this.FlashingDimN);
            this.SideFlashingTab.Controls.Add(this.FlashingDimQ);
            this.SideFlashingTab.Controls.Add(this.FlashingDimP);
            this.SideFlashingTab.Controls.Add(this.FlashingDimF);
            this.SideFlashingTab.Controls.Add(this.FlashingDimE);
            this.SideFlashingTab.Controls.Add(this.FlashingDimD);
            this.SideFlashingTab.Controls.Add(this.pictureBox5);
            this.SideFlashingTab.Location = new System.Drawing.Point(4, 25);
            this.SideFlashingTab.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SideFlashingTab.Name = "SideFlashingTab";
            this.SideFlashingTab.Size = new System.Drawing.Size(537, 221);
            this.SideFlashingTab.TabIndex = 2;
            this.SideFlashingTab.Text = "Sides";
            this.SideFlashingTab.UseVisualStyleBackColor = true;
            // 
            // FlashingDimO
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimO, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimO, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimO, null);
            this.FlashingDimO.Enabled = false;
            this.FlashingDimO.Location = new System.Drawing.Point(5, 39);
            this.FlashingDimO.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimO.Name = "FlashingDimO";
            this.FlashingDimO.Size = new System.Drawing.Size(61, 22);
            this.FlashingDimO.TabIndex = 36;
            this.FlashingDimO.TextChanged += new System.EventHandler(this.FlashingDimO_TextChanged);
            // 
            // FlashingDimN
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimN, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimN, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimN, null);
            this.FlashingDimN.Enabled = false;
            this.FlashingDimN.Location = new System.Drawing.Point(5, 75);
            this.FlashingDimN.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimN.Name = "FlashingDimN";
            this.FlashingDimN.Size = new System.Drawing.Size(63, 22);
            this.FlashingDimN.TabIndex = 35;
            this.FlashingDimN.TextChanged += new System.EventHandler(this.FlashingDimN_TextChanged);
            // 
            // FlashingDimQ
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimQ, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimQ, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimQ, null);
            this.FlashingDimQ.Enabled = false;
            this.FlashingDimQ.Location = new System.Drawing.Point(457, 127);
            this.FlashingDimQ.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimQ.Name = "FlashingDimQ";
            this.FlashingDimQ.Size = new System.Drawing.Size(60, 22);
            this.FlashingDimQ.TabIndex = 39;
            this.FlashingDimQ.TextChanged += new System.EventHandler(this.FlashingDimQ_TextChanged);
            // 
            // FlashingDimP
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimP, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimP, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimP, null);
            this.FlashingDimP.Enabled = false;
            this.FlashingDimP.Location = new System.Drawing.Point(457, 165);
            this.FlashingDimP.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimP.Name = "FlashingDimP";
            this.FlashingDimP.Size = new System.Drawing.Size(60, 22);
            this.FlashingDimP.TabIndex = 38;
            this.FlashingDimP.TextChanged += new System.EventHandler(this.FlashingDimP_TextChanged);
            // 
            // FlashingDimF
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimF, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimF, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimF, null);
            this.FlashingDimF.Enabled = false;
            this.FlashingDimF.Location = new System.Drawing.Point(299, 175);
            this.FlashingDimF.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.FlashingDimF.Name = "FlashingDimF";
            this.FlashingDimF.Size = new System.Drawing.Size(67, 22);
            this.FlashingDimF.TabIndex = 37;
            this.FlashingDimF.TextChanged += new System.EventHandler(this.FlashingDimF_TextChanged);
            // 
            // FlashingDimE
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimE, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimE, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimE, null);
            this.FlashingDimE.Enabled = false;
            this.FlashingDimE.Location = new System.Drawing.Point(165, 90);
            this.FlashingDimE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FlashingDimE.Name = "FlashingDimE";
            this.FlashingDimE.Size = new System.Drawing.Size(68, 22);
            this.FlashingDimE.TabIndex = 36;
            this.FlashingDimE.TextChanged += new System.EventHandler(this.FlashingDimE_TextChanged);
            // 
            // FlashingDimD
            // 
            this.structuresExtender.SetAttributeName(this.FlashingDimD, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingDimD, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingDimD, null);
            this.FlashingDimD.Enabled = false;
            this.FlashingDimD.Location = new System.Drawing.Point(165, 9);
            this.FlashingDimD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FlashingDimD.Name = "FlashingDimD";
            this.FlashingDimD.Size = new System.Drawing.Size(68, 22);
            this.FlashingDimD.TabIndex = 35;
            this.FlashingDimD.TextChanged += new System.EventHandler(this.FlashingDimD_TextChanged);
            // 
            // pictureBox5
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox5, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox5, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox5, null);
            this.pictureBox5.Image = global::BeamApplication.Properties.Resources.Flashings_drawio;
            this.pictureBox5.Location = new System.Drawing.Point(75, 30);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(377, 160);
            this.pictureBox5.TabIndex = 34;
            this.pictureBox5.TabStop = false;
            // 
            // FlashingsEnabled
            // 
            this.structuresExtender.SetAttributeName(this.FlashingsEnabled, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingsEnabled, null);
            this.FlashingsEnabled.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.FlashingsEnabled, null);
            this.FlashingsEnabled.Location = new System.Drawing.Point(13, 22);
            this.FlashingsEnabled.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FlashingsEnabled.Name = "FlashingsEnabled";
            this.FlashingsEnabled.Size = new System.Drawing.Size(133, 20);
            this.FlashingsEnabled.TabIndex = 35;
            this.FlashingsEnabled.Text = "Enable Flashings";
            this.FlashingsEnabled.UseVisualStyleBackColor = true;
            this.FlashingsEnabled.CheckedChanged += new System.EventHandler(this.FlashingsEnabled_CheckedChanged);
            // 
            // ManualFlashDim
            // 
            this.structuresExtender.SetAttributeName(this.ManualFlashDim, null);
            this.structuresExtender.SetAttributeTypeName(this.ManualFlashDim, null);
            this.ManualFlashDim.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.ManualFlashDim, null);
            this.ManualFlashDim.Enabled = false;
            this.ManualFlashDim.Location = new System.Drawing.Point(152, 121);
            this.ManualFlashDim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManualFlashDim.Name = "ManualFlashDim";
            this.ManualFlashDim.Size = new System.Drawing.Size(72, 20);
            this.ManualFlashDim.TabIndex = 34;
            this.ManualFlashDim.Text = "Manual";
            this.ManualFlashDim.UseVisualStyleBackColor = true;
            // 
            // AutoFlashDim
            // 
            this.structuresExtender.SetAttributeName(this.AutoFlashDim, null);
            this.structuresExtender.SetAttributeTypeName(this.AutoFlashDim, null);
            this.AutoFlashDim.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.AutoFlashDim, null);
            this.AutoFlashDim.Checked = true;
            this.AutoFlashDim.Enabled = false;
            this.AutoFlashDim.Location = new System.Drawing.Point(13, 121);
            this.AutoFlashDim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AutoFlashDim.Name = "AutoFlashDim";
            this.AutoFlashDim.Size = new System.Drawing.Size(55, 20);
            this.AutoFlashDim.TabIndex = 33;
            this.AutoFlashDim.TabStop = true;
            this.AutoFlashDim.Text = "Auto";
            this.AutoFlashDim.UseVisualStyleBackColor = true;
            this.AutoFlashDim.CheckedChanged += new System.EventHandler(this.AutoFlashDim_CheckedChanged);
            // 
            // FlashingThickness
            // 
            this.structuresExtender.SetAttributeName(this.FlashingThickness, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingThickness, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingThickness, null);
            this.FlashingThickness.Enabled = false;
            this.FlashingThickness.Location = new System.Drawing.Point(152, 82);
            this.FlashingThickness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FlashingThickness.Name = "FlashingThickness";
            this.FlashingThickness.Size = new System.Drawing.Size(148, 22);
            this.FlashingThickness.TabIndex = 32;
            this.FlashingThickness.TextChanged += new System.EventHandler(this.FlashingThickness_TextChanged);
            // 
            // FlashingThicknessLabel
            // 
            this.structuresExtender.SetAttributeName(this.FlashingThicknessLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingThicknessLabel, null);
            this.FlashingThicknessLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.FlashingThicknessLabel, null);
            this.FlashingThicknessLabel.Location = new System.Drawing.Point(9, 82);
            this.FlashingThicknessLabel.Name = "FlashingThicknessLabel";
            this.FlashingThicknessLabel.Size = new System.Drawing.Size(72, 16);
            this.FlashingThicknessLabel.TabIndex = 31;
            this.FlashingThicknessLabel.Text = "Thickness:";
            // 
            // FlashingColour
            // 
            this.structuresExtender.SetAttributeName(this.FlashingColour, null);
            this.structuresExtender.SetAttributeTypeName(this.FlashingColour, null);
            this.structuresExtender.SetBindPropertyName(this.FlashingColour, null);
            this.FlashingColour.Enabled = false;
            this.FlashingColour.FormattingEnabled = true;
            this.FlashingColour.Items.AddRange(new object[] {
            "Basalt",
            "Cove",
            "Dune",
            "Evening Haze",
            "Gully",
            "Ironstone",
            "Jasper",
            "Mangrove",
            "Monument",
            "Shale Grey",
            "Surfmist",
            "Terrain",
            "Wallaby",
            "Windspray"});
            this.FlashingColour.Location = new System.Drawing.Point(152, 50);
            this.FlashingColour.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.FlashingColour.Name = "FlashingColour";
            this.FlashingColour.Size = new System.Drawing.Size(148, 24);
            this.FlashingColour.TabIndex = 29;
            this.FlashingColour.SelectedIndexChanged += new System.EventHandler(this.FlashingColour_SelectedIndexChanged);
            // 
            // label40
            // 
            this.structuresExtender.SetAttributeName(this.label40, null);
            this.structuresExtender.SetAttributeTypeName(this.label40, null);
            this.label40.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label40, null);
            this.label40.Location = new System.Drawing.Point(11, 54);
            this.label40.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(49, 16);
            this.label40.TabIndex = 30;
            this.label40.Text = "Colour:";
            // 
            // GH_panel
            // 
            this.structuresExtender.SetAttributeName(this.GH_panel, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_panel, null);
            this.structuresExtender.SetBindPropertyName(this.GH_panel, null);
            this.GH_panel.Controls.Add(this.NoGalHole);
            this.GH_panel.Controls.Add(this.GH_manualSelector);
            this.GH_panel.Controls.Add(this.GH_autoSelector);
            this.GH_panel.Controls.Add(this.GH_offset1);
            this.GH_panel.Controls.Add(this.GH_holeSize);
            this.GH_panel.Controls.Add(this.GH_offset2);
            this.GH_panel.Controls.Add(this.GH_label_offset1);
            this.GH_panel.Controls.Add(this.GH_label_offset2);
            this.GH_panel.Controls.Add(this.pictureBox7);
            this.GH_panel.Location = new System.Drawing.Point(693, 330);
            this.GH_panel.Margin = new System.Windows.Forms.Padding(4);
            this.GH_panel.Name = "GH_panel";
            this.GH_panel.Padding = new System.Windows.Forms.Padding(4);
            this.GH_panel.Size = new System.Drawing.Size(415, 348);
            this.GH_panel.TabIndex = 26;
            this.GH_panel.TabStop = false;
            this.GH_panel.Text = "Galvanising Holes";
            // 
            // NoGalHole
            // 
            this.structuresExtender.SetAttributeName(this.NoGalHole, null);
            this.structuresExtender.SetAttributeTypeName(this.NoGalHole, null);
            this.NoGalHole.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.NoGalHole, null);
            this.NoGalHole.Location = new System.Drawing.Point(235, 21);
            this.NoGalHole.Margin = new System.Windows.Forms.Padding(4);
            this.NoGalHole.Name = "NoGalHole";
            this.NoGalHole.Size = new System.Drawing.Size(61, 20);
            this.NoGalHole.TabIndex = 31;
            this.NoGalHole.Text = "None";
            this.NoGalHole.UseVisualStyleBackColor = true;
            this.NoGalHole.CheckedChanged += new System.EventHandler(this.NoGalHole_CheckedChanged);
            // 
            // GH_manualSelector
            // 
            this.structuresExtender.SetAttributeName(this.GH_manualSelector, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_manualSelector, null);
            this.GH_manualSelector.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.GH_manualSelector, null);
            this.GH_manualSelector.Checked = true;
            this.GH_manualSelector.Location = new System.Drawing.Point(117, 21);
            this.GH_manualSelector.Margin = new System.Windows.Forms.Padding(4);
            this.GH_manualSelector.Name = "GH_manualSelector";
            this.GH_manualSelector.Size = new System.Drawing.Size(72, 20);
            this.GH_manualSelector.TabIndex = 30;
            this.GH_manualSelector.TabStop = true;
            this.GH_manualSelector.Text = "Manual";
            this.GH_manualSelector.UseVisualStyleBackColor = true;
            // 
            // GH_autoSelector
            // 
            this.structuresExtender.SetAttributeName(this.GH_autoSelector, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_autoSelector, null);
            this.GH_autoSelector.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.GH_autoSelector, null);
            this.GH_autoSelector.Location = new System.Drawing.Point(13, 21);
            this.GH_autoSelector.Margin = new System.Windows.Forms.Padding(4);
            this.GH_autoSelector.Name = "GH_autoSelector";
            this.GH_autoSelector.Size = new System.Drawing.Size(55, 20);
            this.GH_autoSelector.TabIndex = 29;
            this.GH_autoSelector.Text = "Auto";
            this.GH_autoSelector.UseVisualStyleBackColor = true;
            this.GH_autoSelector.CheckedChanged += new System.EventHandler(this.GH_autoSelector_CheckedChanged);
            // 
            // GH_offset1
            // 
            this.structuresExtender.SetAttributeName(this.GH_offset1, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_offset1, null);
            this.structuresExtender.SetBindPropertyName(this.GH_offset1, null);
            this.GH_offset1.Location = new System.Drawing.Point(155, 181);
            this.GH_offset1.Margin = new System.Windows.Forms.Padding(5);
            this.GH_offset1.Name = "GH_offset1";
            this.GH_offset1.Size = new System.Drawing.Size(41, 22);
            this.GH_offset1.TabIndex = 2;
            this.GH_offset1.Text = "10";
            // 
            // GH_holeSize
            // 
            this.structuresExtender.SetAttributeName(this.GH_holeSize, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_holeSize, null);
            this.structuresExtender.SetBindPropertyName(this.GH_holeSize, null);
            this.GH_holeSize.Location = new System.Drawing.Point(277, 130);
            this.GH_holeSize.Margin = new System.Windows.Forms.Padding(5);
            this.GH_holeSize.Name = "GH_holeSize";
            this.GH_holeSize.Size = new System.Drawing.Size(45, 22);
            this.GH_holeSize.TabIndex = 12;
            this.GH_holeSize.Text = "16";
            // 
            // GH_offset2
            // 
            this.structuresExtender.SetAttributeName(this.GH_offset2, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_offset2, null);
            this.structuresExtender.SetBindPropertyName(this.GH_offset2, null);
            this.GH_offset2.Location = new System.Drawing.Point(277, 89);
            this.GH_offset2.Margin = new System.Windows.Forms.Padding(5);
            this.GH_offset2.Name = "GH_offset2";
            this.GH_offset2.Size = new System.Drawing.Size(45, 22);
            this.GH_offset2.TabIndex = 3;
            this.GH_offset2.Text = "2";
            // 
            // GH_label_offset1
            // 
            this.structuresExtender.SetAttributeName(this.GH_label_offset1, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_label_offset1, null);
            this.GH_label_offset1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.GH_label_offset1, null);
            this.GH_label_offset1.Location = new System.Drawing.Point(75, 162);
            this.GH_label_offset1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.GH_label_offset1.Name = "GH_label_offset1";
            this.GH_label_offset1.Size = new System.Drawing.Size(102, 16);
            this.GH_label_offset1.TabIndex = 4;
            this.GH_label_offset1.Text = "Open-end offset";
            // 
            // GH_label_offset2
            // 
            this.structuresExtender.SetAttributeName(this.GH_label_offset2, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_label_offset2, null);
            this.GH_label_offset2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.GH_label_offset2, null);
            this.GH_label_offset2.Location = new System.Drawing.Point(196, 68);
            this.GH_label_offset2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.GH_label_offset2.Name = "GH_label_offset2";
            this.GH_label_offset2.Size = new System.Drawing.Size(112, 16);
            this.GH_label_offset2.TabIndex = 5;
            this.GH_label_offset2.Text = "Closed-end offset";
            // 
            // pictureBox7
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox7, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox7, null);
            this.pictureBox7.BackgroundImage = global::BeamApplication.Properties.Resources.GH_image;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.structuresExtender.SetBindPropertyName(this.pictureBox7, null);
            this.pictureBox7.Location = new System.Drawing.Point(13, 58);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(391, 254);
            this.pictureBox7.TabIndex = 29;
            this.pictureBox7.TabStop = false;
            // 
            // cameraArm
            // 
            this.structuresExtender.SetAttributeName(this.cameraArm, null);
            this.structuresExtender.SetAttributeTypeName(this.cameraArm, null);
            this.structuresExtender.SetBindPropertyName(this.cameraArm, null);
            this.cameraArm.Controls.Add(this.Cameracentre);
            this.cameraArm.Controls.Add(this.noArm);
            this.cameraArm.Controls.Add(this.TopArm);
            this.cameraArm.Controls.Add(this.BotArm);
            this.cameraArm.Controls.Add(this.ArmLeftOffset);
            this.cameraArm.Controls.Add(this.LeftOffset);
            this.cameraArm.Controls.Add(this.ArmLengthBox);
            this.cameraArm.Controls.Add(this.VertArmLength);
            this.cameraArm.Controls.Add(this.ArmAngle);
            this.cameraArm.Controls.Add(this.label52);
            this.cameraArm.Controls.Add(this.label54);
            this.cameraArm.Controls.Add(this.label53);
            this.cameraArm.Location = new System.Drawing.Point(3, 16);
            this.cameraArm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cameraArm.Name = "cameraArm";
            this.cameraArm.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cameraArm.Size = new System.Drawing.Size(309, 218);
            this.cameraArm.TabIndex = 23;
            this.cameraArm.TabStop = false;
            this.cameraArm.Text = "Camera Arm";
            // 
            // Cameracentre
            // 
            this.structuresExtender.SetAttributeName(this.Cameracentre, null);
            this.structuresExtender.SetAttributeTypeName(this.Cameracentre, null);
            this.Cameracentre.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.Cameracentre, null);
            this.Cameracentre.Checked = true;
            this.Cameracentre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Cameracentre.Location = new System.Drawing.Point(20, 80);
            this.Cameracentre.Margin = new System.Windows.Forms.Padding(4);
            this.Cameracentre.Name = "Cameracentre";
            this.Cameracentre.Size = new System.Drawing.Size(142, 20);
            this.Cameracentre.TabIndex = 21;
            this.Cameracentre.Text = "Camera Arn Centre";
            this.Cameracentre.UseVisualStyleBackColor = true;
            this.Cameracentre.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            this.Cameracentre.Click += new System.EventHandler(this.cameraarmcentre_click);
            // 
            // noArm
            // 
            this.structuresExtender.SetAttributeName(this.noArm, null);
            this.structuresExtender.SetAttributeTypeName(this.noArm, null);
            this.noArm.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.noArm, null);
            this.noArm.Location = new System.Drawing.Point(223, 25);
            this.noArm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.noArm.Name = "noArm";
            this.noArm.Size = new System.Drawing.Size(61, 20);
            this.noArm.TabIndex = 20;
            this.noArm.TabStop = true;
            this.noArm.Text = "None";
            this.noArm.UseVisualStyleBackColor = true;
            this.noArm.CheckedChanged += new System.EventHandler(this.noArm_CheckedChanged);
            // 
            // TopArm
            // 
            this.structuresExtender.SetAttributeName(this.TopArm, null);
            this.structuresExtender.SetAttributeTypeName(this.TopArm, null);
            this.TopArm.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.TopArm, null);
            this.TopArm.Checked = true;
            this.TopArm.Location = new System.Drawing.Point(12, 25);
            this.TopArm.Margin = new System.Windows.Forms.Padding(5);
            this.TopArm.Name = "TopArm";
            this.TopArm.Size = new System.Drawing.Size(84, 20);
            this.TopArm.TabIndex = 0;
            this.TopArm.TabStop = true;
            this.TopArm.Text = "Top Side";
            this.TopArm.UseVisualStyleBackColor = true;
            this.TopArm.CheckedChanged += new System.EventHandler(this.TopArm_CheckedChanged);
            // 
            // BotArm
            // 
            this.structuresExtender.SetAttributeName(this.BotArm, null);
            this.structuresExtender.SetAttributeTypeName(this.BotArm, null);
            this.BotArm.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BotArm, null);
            this.BotArm.Location = new System.Drawing.Point(112, 25);
            this.BotArm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BotArm.Name = "BotArm";
            this.BotArm.Size = new System.Drawing.Size(101, 20);
            this.BotArm.TabIndex = 1;
            this.BotArm.TabStop = true;
            this.BotArm.Text = "Bottom Side";
            this.BotArm.UseVisualStyleBackColor = true;
            this.BotArm.CheckedChanged += new System.EventHandler(this.BotArm_CheckedChanged);
            // 
            // ArmLeftOffset
            // 
            this.structuresExtender.SetAttributeName(this.ArmLeftOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.ArmLeftOffset, null);
            this.structuresExtender.SetBindPropertyName(this.ArmLeftOffset, null);
            this.ArmLeftOffset.Location = new System.Drawing.Point(204, 54);
            this.ArmLeftOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ArmLeftOffset.Name = "ArmLeftOffset";
            this.ArmLeftOffset.Size = new System.Drawing.Size(68, 22);
            this.ArmLeftOffset.TabIndex = 3;
            this.ArmLeftOffset.Text = "0";
            // 
            // LeftOffset
            // 
            this.structuresExtender.SetAttributeName(this.LeftOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.LeftOffset, null);
            this.LeftOffset.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.LeftOffset, null);
            this.LeftOffset.Location = new System.Drawing.Point(8, 54);
            this.LeftOffset.Name = "LeftOffset";
            this.LeftOffset.Size = new System.Drawing.Size(174, 16);
            this.LeftOffset.TabIndex = 7;
            this.LeftOffset.Text = "Camera offset from left side: ";
            // 
            // ArmLengthBox
            // 
            this.structuresExtender.SetAttributeName(this.ArmLengthBox, null);
            this.structuresExtender.SetAttributeTypeName(this.ArmLengthBox, null);
            this.structuresExtender.SetBindPropertyName(this.ArmLengthBox, null);
            this.ArmLengthBox.Location = new System.Drawing.Point(204, 112);
            this.ArmLengthBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ArmLengthBox.Name = "ArmLengthBox";
            this.ArmLengthBox.Size = new System.Drawing.Size(68, 22);
            this.ArmLengthBox.TabIndex = 4;
            this.ArmLengthBox.Text = "1000";
            this.ArmLengthBox.TextChanged += new System.EventHandler(this.ArmLengthBox_TextChanged);
            // 
            // VertArmLength
            // 
            this.structuresExtender.SetAttributeName(this.VertArmLength, null);
            this.structuresExtender.SetAttributeTypeName(this.VertArmLength, null);
            this.structuresExtender.SetBindPropertyName(this.VertArmLength, null);
            this.VertArmLength.Location = new System.Drawing.Point(204, 145);
            this.VertArmLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VertArmLength.Name = "VertArmLength";
            this.VertArmLength.Size = new System.Drawing.Size(68, 22);
            this.VertArmLength.TabIndex = 5;
            this.VertArmLength.Text = "200";
            // 
            // ArmAngle
            // 
            this.structuresExtender.SetAttributeName(this.ArmAngle, null);
            this.structuresExtender.SetAttributeTypeName(this.ArmAngle, null);
            this.structuresExtender.SetBindPropertyName(this.ArmAngle, null);
            this.ArmAngle.Location = new System.Drawing.Point(203, 181);
            this.ArmAngle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ArmAngle.Name = "ArmAngle";
            this.ArmAngle.Size = new System.Drawing.Size(68, 22);
            this.ArmAngle.TabIndex = 8;
            this.ArmAngle.Text = "10";
            // 
            // label52
            // 
            this.structuresExtender.SetAttributeName(this.label52, null);
            this.structuresExtender.SetAttributeTypeName(this.label52, null);
            this.label52.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label52, null);
            this.label52.Location = new System.Drawing.Point(11, 114);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(143, 16);
            this.label52.TabIndex = 9;
            this.label52.Text = "Horizontal Arm Length: ";
            // 
            // label54
            // 
            this.structuresExtender.SetAttributeName(this.label54, null);
            this.structuresExtender.SetAttributeTypeName(this.label54, null);
            this.label54.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label54, null);
            this.label54.Location = new System.Drawing.Point(43, 185);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(115, 16);
            this.label54.TabIndex = 11;
            this.label54.Text = "Angle From Level:";
            this.label54.Click += new System.EventHandler(this.label54_Click);
            // 
            // label53
            // 
            this.structuresExtender.SetAttributeName(this.label53, null);
            this.structuresExtender.SetAttributeTypeName(this.label53, null);
            this.label53.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label53, null);
            this.label53.Location = new System.Drawing.Point(27, 149);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(128, 16);
            this.label53.TabIndex = 10;
            this.label53.Text = "Vertical Arm Length: ";
            // 
            // WW_panel
            // 
            this.structuresExtender.SetAttributeName(this.WW_panel, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_panel, null);
            this.structuresExtender.SetBindPropertyName(this.WW_panel, null);
            this.WW_panel.Controls.Add(this.WW_tabControl);
            this.WW_panel.Controls.Add(this.WW_label);
            this.WW_panel.Controls.Add(this.WW_list);
            this.WW_panel.Controls.Add(this.WW_count);
            this.WW_panel.Location = new System.Drawing.Point(408, 353);
            this.WW_panel.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_panel.Name = "WW_panel";
            this.WW_panel.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_panel.Size = new System.Drawing.Size(269, 348);
            this.WW_panel.TabIndex = 24;
            this.WW_panel.TabStop = false;
            this.WW_panel.Text = "Walkway position";
            // 
            // WW_tabControl
            // 
            this.structuresExtender.SetAttributeName(this.WW_tabControl, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_tabControl, null);
            this.structuresExtender.SetBindPropertyName(this.WW_tabControl, null);
            this.WW_tabControl.Controls.Add(this.WW_tab);
            this.WW_tabControl.Controls.Add(this.WW_tab2);
            this.WW_tabControl.Location = new System.Drawing.Point(16, 36);
            this.WW_tabControl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_tabControl.Name = "WW_tabControl";
            this.WW_tabControl.SelectedIndex = 0;
            this.WW_tabControl.Size = new System.Drawing.Size(245, 156);
            this.WW_tabControl.TabIndex = 19;
            // 
            // WW_tab
            // 
            this.structuresExtender.SetAttributeName(this.WW_tab, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_tab, null);
            this.structuresExtender.SetBindPropertyName(this.WW_tab, null);
            this.WW_tab.Controls.Add(this.WW_add_label);
            this.WW_tab.Controls.Add(this.WW_box);
            this.WW_tab.Controls.Add(this.WW_add);
            this.WW_tab.Location = new System.Drawing.Point(4, 25);
            this.WW_tab.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_tab.Name = "WW_tab";
            this.WW_tab.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_tab.Size = new System.Drawing.Size(237, 127);
            this.WW_tab.TabIndex = 0;
            this.WW_tab.Text = "Add";
            this.WW_tab.UseVisualStyleBackColor = true;
            // 
            // WW_add_label
            // 
            this.structuresExtender.SetAttributeName(this.WW_add_label, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_add_label, null);
            this.WW_add_label.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.WW_add_label, null);
            this.WW_add_label.Location = new System.Drawing.Point(9, 17);
            this.WW_add_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WW_add_label.Name = "WW_add_label";
            this.WW_add_label.Size = new System.Drawing.Size(137, 16);
            this.WW_add_label.TabIndex = 35;
            this.WW_add_label.Text = "Distance from Bottom:";
            // 
            // WW_box
            // 
            this.structuresExtender.SetAttributeName(this.WW_box, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_box, null);
            this.structuresExtender.SetBindPropertyName(this.WW_box, null);
            this.WW_box.Location = new System.Drawing.Point(12, 48);
            this.WW_box.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_box.Name = "WW_box";
            this.WW_box.Size = new System.Drawing.Size(141, 22);
            this.WW_box.TabIndex = 0;
            // 
            // WW_add
            // 
            this.structuresExtender.SetAttributeName(this.WW_add, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_add, null);
            this.structuresExtender.SetBindPropertyName(this.WW_add, null);
            this.WW_add.Location = new System.Drawing.Point(12, 86);
            this.WW_add.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_add.Name = "WW_add";
            this.WW_add.Size = new System.Drawing.Size(143, 31);
            this.WW_add.TabIndex = 1;
            this.WW_add.Text = "Add";
            this.WW_add.UseVisualStyleBackColor = true;
            this.WW_add.Click += new System.EventHandler(this.WW_add_Click);
            // 
            // WW_tab2
            // 
            this.structuresExtender.SetAttributeName(this.WW_tab2, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_tab2, null);
            this.structuresExtender.SetBindPropertyName(this.WW_tab2, null);
            this.WW_tab2.Controls.Add(this.label33);
            this.WW_tab2.Controls.Add(this.WW_removeAll);
            this.WW_tab2.Controls.Add(this.WW_remove);
            this.WW_tab2.Controls.Add(this.WW_box2);
            this.WW_tab2.Controls.Add(this.WW_edit);
            this.WW_tab2.Location = new System.Drawing.Point(4, 25);
            this.WW_tab2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_tab2.Name = "WW_tab2";
            this.WW_tab2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.WW_tab2.Size = new System.Drawing.Size(237, 127);
            this.WW_tab2.TabIndex = 1;
            this.WW_tab2.Text = "Edit";
            this.WW_tab2.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            this.structuresExtender.SetAttributeName(this.label33, null);
            this.structuresExtender.SetAttributeTypeName(this.label33, null);
            this.label33.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label33, null);
            this.label33.Location = new System.Drawing.Point(9, 17);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(137, 16);
            this.label33.TabIndex = 36;
            this.label33.Text = "Distance from Bottom:";
            // 
            // WW_removeAll
            // 
            this.structuresExtender.SetAttributeName(this.WW_removeAll, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_removeAll, null);
            this.structuresExtender.SetBindPropertyName(this.WW_removeAll, null);
            this.WW_removeAll.Location = new System.Drawing.Point(163, 84);
            this.WW_removeAll.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_removeAll.Name = "WW_removeAll";
            this.WW_removeAll.Size = new System.Drawing.Size(143, 31);
            this.WW_removeAll.TabIndex = 5;
            this.WW_removeAll.TabStop = false;
            this.WW_removeAll.Text = "Remove All";
            this.WW_removeAll.UseVisualStyleBackColor = true;
            this.WW_removeAll.Click += new System.EventHandler(this.WW_removeAll_Click);
            // 
            // WW_remove
            // 
            this.structuresExtender.SetAttributeName(this.WW_remove, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_remove, null);
            this.structuresExtender.SetBindPropertyName(this.WW_remove, null);
            this.WW_remove.Location = new System.Drawing.Point(12, 84);
            this.WW_remove.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_remove.Name = "WW_remove";
            this.WW_remove.Size = new System.Drawing.Size(143, 31);
            this.WW_remove.TabIndex = 4;
            this.WW_remove.Text = "Remove";
            this.WW_remove.UseVisualStyleBackColor = true;
            this.WW_remove.Click += new System.EventHandler(this.WW_remove_Click);
            // 
            // WW_box2
            // 
            this.structuresExtender.SetAttributeName(this.WW_box2, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_box2, null);
            this.structuresExtender.SetBindPropertyName(this.WW_box2, null);
            this.WW_box2.Location = new System.Drawing.Point(12, 48);
            this.WW_box2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_box2.Name = "WW_box2";
            this.WW_box2.Size = new System.Drawing.Size(141, 22);
            this.WW_box2.TabIndex = 2;
            // 
            // WW_edit
            // 
            this.structuresExtender.SetAttributeName(this.WW_edit, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_edit, null);
            this.structuresExtender.SetBindPropertyName(this.WW_edit, null);
            this.WW_edit.Location = new System.Drawing.Point(163, 46);
            this.WW_edit.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_edit.Name = "WW_edit";
            this.WW_edit.Size = new System.Drawing.Size(143, 31);
            this.WW_edit.TabIndex = 3;
            this.WW_edit.Text = "Edit";
            this.WW_edit.UseVisualStyleBackColor = true;
            this.WW_edit.Click += new System.EventHandler(this.WW_edit_Click);
            // 
            // WW_label
            // 
            this.structuresExtender.SetAttributeName(this.WW_label, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_label, null);
            this.WW_label.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.WW_label, null);
            this.WW_label.Location = new System.Drawing.Point(7, 322);
            this.WW_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WW_label.Name = "WW_label";
            this.WW_label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WW_label.Size = new System.Drawing.Size(44, 16);
            this.WW_label.TabIndex = 19;
            this.WW_label.Text = "Count:";
            // 
            // WW_list
            // 
            this.WW_list.AllowDrop = true;
            this.structuresExtender.SetAttributeName(this.WW_list, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_list, null);
            this.structuresExtender.SetBindPropertyName(this.WW_list, null);
            this.WW_list.FormattingEnabled = true;
            this.WW_list.ItemHeight = 16;
            this.WW_list.Location = new System.Drawing.Point(20, 199);
            this.WW_list.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.WW_list.Name = "WW_list";
            this.WW_list.Size = new System.Drawing.Size(235, 116);
            this.WW_list.TabIndex = 19;
            this.WW_list.SelectedIndexChanged += new System.EventHandler(this.WW_list_SelectedIndexChanged);
            // 
            // WW_count
            // 
            this.structuresExtender.SetAttributeName(this.WW_count, null);
            this.structuresExtender.SetAttributeTypeName(this.WW_count, null);
            this.WW_count.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.WW_count, null);
            this.WW_count.Location = new System.Drawing.Point(65, 322);
            this.WW_count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WW_count.Name = "WW_count";
            this.WW_count.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.WW_count.Size = new System.Drawing.Size(14, 16);
            this.WW_count.TabIndex = 22;
            this.WW_count.Text = "0";
            // 
            // groupBox13
            // 
            this.structuresExtender.SetAttributeName(this.groupBox13, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox13, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox13, null);
            this.groupBox13.Controls.Add(this.ManualOpenArea);
            this.groupBox13.Controls.Add(this.sides);
            this.groupBox13.Controls.Add(this.theSide);
            this.groupBox13.Controls.Add(this.CladOffset);
            this.groupBox13.Controls.Add(this.label3);
            this.groupBox13.Controls.Add(this.OpenArea);
            this.groupBox13.Controls.Add(this.label39);
            this.groupBox13.Controls.Add(this.CladdingColour);
            this.groupBox13.Controls.Add(this.label38);
            this.groupBox13.Controls.Add(this.Thickness);
            this.groupBox13.Controls.Add(this.CladLength);
            this.groupBox13.Controls.Add(this.CladSize);
            this.groupBox13.Controls.Add(this.CladSizeLabel);
            this.groupBox13.Controls.Add(this.CladProfile);
            this.groupBox13.Controls.Add(this.EffectiveWidth);
            this.groupBox13.Controls.Add(this.SheetWidth);
            this.groupBox13.Controls.Add(this.Overlap);
            this.groupBox13.Controls.Add(this.label66);
            this.groupBox13.Controls.Add(this.label65);
            this.groupBox13.Controls.Add(this.label64);
            this.groupBox13.Controls.Add(this.label63);
            this.groupBox13.Controls.Add(this.label62);
            this.groupBox13.Controls.Add(this.label48);
            this.groupBox13.Location = new System.Drawing.Point(693, 16);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Size = new System.Drawing.Size(413, 306);
            this.groupBox13.TabIndex = 20;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Cladding";
            // 
            // ManualOpenArea
            // 
            this.structuresExtender.SetAttributeName(this.ManualOpenArea, null);
            this.structuresExtender.SetAttributeTypeName(this.ManualOpenArea, null);
            this.structuresExtender.SetBindPropertyName(this.ManualOpenArea, null);
            this.ManualOpenArea.Enabled = false;
            this.ManualOpenArea.Location = new System.Drawing.Point(333, 162);
            this.ManualOpenArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ManualOpenArea.Name = "ManualOpenArea";
            this.ManualOpenArea.Size = new System.Drawing.Size(71, 22);
            this.ManualOpenArea.TabIndex = 35;
            this.ManualOpenArea.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // sides
            // 
            this.structuresExtender.SetAttributeName(this.sides, null);
            this.structuresExtender.SetAttributeTypeName(this.sides, null);
            this.sides.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.sides, null);
            this.sides.Location = new System.Drawing.Point(16, 30);
            this.sides.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sides.Name = "sides";
            this.sides.Size = new System.Drawing.Size(38, 16);
            this.sides.TabIndex = 34;
            this.sides.Text = "Side:";
            // 
            // theSide
            // 
            this.structuresExtender.SetAttributeName(this.theSide, null);
            this.structuresExtender.SetAttributeTypeName(this.theSide, null);
            this.structuresExtender.SetBindPropertyName(this.theSide, null);
            this.theSide.FormattingEnabled = true;
            this.theSide.Items.AddRange(new object[] {
            "All",
            "Back",
            "Left",
            "Right",
            "Top",
            "Bottom"});
            this.theSide.Location = new System.Drawing.Point(167, 20);
            this.theSide.Margin = new System.Windows.Forms.Padding(4);
            this.theSide.Name = "theSide";
            this.theSide.Size = new System.Drawing.Size(161, 24);
            this.theSide.TabIndex = 33;
            this.theSide.Text = "All";
            this.theSide.SelectedIndexChanged += new System.EventHandler(this.theSide_SelectedIndexChanged);
            // 
            // CladOffset
            // 
            this.structuresExtender.SetAttributeName(this.CladOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.CladOffset, null);
            this.structuresExtender.SetBindPropertyName(this.CladOffset, null);
            this.CladOffset.Enabled = false;
            this.CladOffset.Location = new System.Drawing.Point(167, 218);
            this.CladOffset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CladOffset.Name = "CladOffset";
            this.CladOffset.Size = new System.Drawing.Size(161, 22);
            this.CladOffset.TabIndex = 32;
            // 
            // label3
            // 
            this.structuresExtender.SetAttributeName(this.label3, null);
            this.structuresExtender.SetAttributeTypeName(this.label3, null);
            this.label3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label3, null);
            this.label3.Location = new System.Drawing.Point(16, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Offset From Top: ";
            // 
            // OpenArea
            // 
            this.structuresExtender.SetAttributeName(this.OpenArea, null);
            this.structuresExtender.SetAttributeTypeName(this.OpenArea, null);
            this.structuresExtender.SetBindPropertyName(this.OpenArea, null);
            this.OpenArea.Enabled = false;
            this.OpenArea.FormattingEnabled = true;
            this.OpenArea.Items.AddRange(new object[] {
            "10",
            "30",
            "49",
            "Custom"});
            this.OpenArea.Location = new System.Drawing.Point(167, 162);
            this.OpenArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenArea.Name = "OpenArea";
            this.OpenArea.Size = new System.Drawing.Size(161, 24);
            this.OpenArea.TabIndex = 30;
            this.OpenArea.SelectedIndexChanged += new System.EventHandler(this.OpenArea_SelectedIndexChanged);
            // 
            // label39
            // 
            this.structuresExtender.SetAttributeName(this.label39, null);
            this.structuresExtender.SetAttributeTypeName(this.label39, null);
            this.label39.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label39, null);
            this.label39.Location = new System.Drawing.Point(16, 174);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(98, 16);
            this.label39.TabIndex = 29;
            this.label39.Text = "Open Area (%):";
            // 
            // CladdingColour
            // 
            this.structuresExtender.SetAttributeName(this.CladdingColour, null);
            this.structuresExtender.SetAttributeTypeName(this.CladdingColour, null);
            this.structuresExtender.SetBindPropertyName(this.CladdingColour, null);
            this.CladdingColour.Enabled = false;
            this.CladdingColour.FormattingEnabled = true;
            this.CladdingColour.Items.AddRange(new object[] {
            "Basalt",
            "Cove",
            "Dune",
            "Evening Haze",
            "Gully",
            "Ironstone",
            "Jasper",
            "Mangrove",
            "Monument",
            "Shale Grey",
            "Surfmist",
            "Terrain",
            "Wallaby",
            "Windspray"});
            this.CladdingColour.Location = new System.Drawing.Point(167, 78);
            this.CladdingColour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CladdingColour.Name = "CladdingColour";
            this.CladdingColour.Size = new System.Drawing.Size(161, 24);
            this.CladdingColour.TabIndex = 27;
            this.CladdingColour.SelectedIndexChanged += new System.EventHandler(this.Colour_SelectedIndexChanged);
            // 
            // label38
            // 
            this.structuresExtender.SetAttributeName(this.label38, null);
            this.structuresExtender.SetAttributeTypeName(this.label38, null);
            this.label38.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label38, null);
            this.label38.Location = new System.Drawing.Point(16, 84);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(49, 16);
            this.label38.TabIndex = 28;
            this.label38.Text = "Colour:";
            // 
            // Thickness
            // 
            this.structuresExtender.SetAttributeName(this.Thickness, null);
            this.structuresExtender.SetAttributeTypeName(this.Thickness, null);
            this.structuresExtender.SetBindPropertyName(this.Thickness, null);
            this.Thickness.Enabled = false;
            this.Thickness.Location = new System.Drawing.Point(167, 132);
            this.Thickness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Thickness.Name = "Thickness";
            this.Thickness.Size = new System.Drawing.Size(161, 22);
            this.Thickness.TabIndex = 27;
            this.Thickness.TextChanged += new System.EventHandler(this.Thickness_TextChanged);
            // 
            // CladLength
            // 
            this.structuresExtender.SetAttributeName(this.CladLength, null);
            this.structuresExtender.SetAttributeTypeName(this.CladLength, null);
            this.structuresExtender.SetBindPropertyName(this.CladLength, null);
            this.CladLength.Enabled = false;
            this.CladLength.Location = new System.Drawing.Point(167, 106);
            this.CladLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CladLength.Name = "CladLength";
            this.CladLength.Size = new System.Drawing.Size(161, 22);
            this.CladLength.TabIndex = 19;
            this.CladLength.TextChanged += new System.EventHandler(this.CladLength_TextChanged);
            // 
            // CladSize
            // 
            this.structuresExtender.SetAttributeName(this.CladSize, null);
            this.structuresExtender.SetAttributeTypeName(this.CladSize, null);
            this.structuresExtender.SetBindPropertyName(this.CladSize, null);
            this.CladSize.Enabled = false;
            this.CladSize.FormattingEnabled = true;
            this.CladSize.Items.AddRange(new object[] {
            "2440 X 1220",
            "3660 X 1220",
            "2440 X 1500",
            "3050 X 1500",
            "3660 X 1500",
            "4000 X 1500",
            "4000 X 2000"});
            this.CladSize.Location = new System.Drawing.Point(167, 191);
            this.CladSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CladSize.Name = "CladSize";
            this.CladSize.Size = new System.Drawing.Size(161, 24);
            this.CladSize.TabIndex = 18;
            this.CladSize.SelectedIndexChanged += new System.EventHandler(this.CladSize_SelectedIndexChanged);
            // 
            // CladSizeLabel
            // 
            this.structuresExtender.SetAttributeName(this.CladSizeLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.CladSizeLabel, null);
            this.CladSizeLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.CladSizeLabel, null);
            this.CladSizeLabel.Location = new System.Drawing.Point(16, 202);
            this.CladSizeLabel.Name = "CladSizeLabel";
            this.CladSizeLabel.Size = new System.Drawing.Size(36, 16);
            this.CladSizeLabel.TabIndex = 2;
            this.CladSizeLabel.Text = "Size:";
            // 
            // CladProfile
            // 
            this.structuresExtender.SetAttributeName(this.CladProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.CladProfile, null);
            this.structuresExtender.SetBindPropertyName(this.CladProfile, null);
            this.CladProfile.FormattingEnabled = true;
            this.CladProfile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CladProfile.Items.AddRange(new object[] {
            "Mini Orb 42",
            "Mini Orb 48",
            "Panel Rib 0.48 (35)",
            "Panel Rib 0.48 (42)",
            "Perforated Sheet",
            "ACM Sheet",
            "No Cladding"});
            this.CladProfile.Location = new System.Drawing.Point(167, 48);
            this.CladProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CladProfile.Name = "CladProfile";
            this.CladProfile.Size = new System.Drawing.Size(161, 24);
            this.CladProfile.TabIndex = 17;
            this.CladProfile.Text = "No Cladding";
            this.CladProfile.SelectedIndexChanged += new System.EventHandler(this.CladProfile_SelectedIndexChanged);
            // 
            // EffectiveWidth
            // 
            this.structuresExtender.SetAttributeName(this.EffectiveWidth, null);
            this.structuresExtender.SetAttributeTypeName(this.EffectiveWidth, null);
            this.EffectiveWidth.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.EffectiveWidth, null);
            this.EffectiveWidth.Location = new System.Drawing.Point(196, 287);
            this.EffectiveWidth.Name = "EffectiveWidth";
            this.EffectiveWidth.Size = new System.Drawing.Size(14, 16);
            this.EffectiveWidth.TabIndex = 14;
            this.EffectiveWidth.Text = "0";
            // 
            // SheetWidth
            // 
            this.structuresExtender.SetAttributeName(this.SheetWidth, null);
            this.structuresExtender.SetAttributeTypeName(this.SheetWidth, null);
            this.SheetWidth.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.SheetWidth, null);
            this.SheetWidth.Location = new System.Drawing.Point(196, 249);
            this.SheetWidth.Name = "SheetWidth";
            this.SheetWidth.Size = new System.Drawing.Size(14, 16);
            this.SheetWidth.TabIndex = 13;
            this.SheetWidth.Text = "0";
            // 
            // Overlap
            // 
            this.structuresExtender.SetAttributeName(this.Overlap, null);
            this.structuresExtender.SetAttributeTypeName(this.Overlap, null);
            this.Overlap.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.Overlap, null);
            this.Overlap.Location = new System.Drawing.Point(196, 267);
            this.Overlap.Name = "Overlap";
            this.Overlap.Size = new System.Drawing.Size(14, 16);
            this.Overlap.TabIndex = 12;
            this.Overlap.Text = "0";
            // 
            // label66
            // 
            this.structuresExtender.SetAttributeName(this.label66, null);
            this.structuresExtender.SetAttributeTypeName(this.label66, null);
            this.label66.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label66, null);
            this.label66.Location = new System.Drawing.Point(16, 142);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(72, 16);
            this.label66.TabIndex = 6;
            this.label66.Text = "Thickness:";
            // 
            // label65
            // 
            this.structuresExtender.SetAttributeName(this.label65, null);
            this.structuresExtender.SetAttributeTypeName(this.label65, null);
            this.label65.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label65, null);
            this.label65.Location = new System.Drawing.Point(16, 287);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(137, 16);
            this.label65.TabIndex = 5;
            this.label65.Text = "Effective Cover Width:";
            // 
            // label64
            // 
            this.structuresExtender.SetAttributeName(this.label64, null);
            this.structuresExtender.SetAttributeTypeName(this.label64, null);
            this.label64.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label64, null);
            this.label64.Location = new System.Drawing.Point(16, 267);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(58, 16);
            this.label64.TabIndex = 4;
            this.label64.Text = "Overlap:";
            // 
            // label63
            // 
            this.structuresExtender.SetAttributeName(this.label63, null);
            this.structuresExtender.SetAttributeTypeName(this.label63, null);
            this.label63.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label63, null);
            this.label63.Location = new System.Drawing.Point(16, 249);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(128, 16);
            this.label63.TabIndex = 3;
            this.label63.Text = "Overall Sheet Width:";
            // 
            // label62
            // 
            this.structuresExtender.SetAttributeName(this.label62, null);
            this.structuresExtender.SetAttributeTypeName(this.label62, null);
            this.label62.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label62, null);
            this.label62.Location = new System.Drawing.Point(16, 114);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(50, 16);
            this.label62.TabIndex = 1;
            this.label62.Text = "Length:";
            // 
            // label48
            // 
            this.structuresExtender.SetAttributeName(this.label48, null);
            this.structuresExtender.SetAttributeTypeName(this.label48, null);
            this.label48.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label48, null);
            this.label48.Location = new System.Drawing.Point(16, 57);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(48, 16);
            this.label48.TabIndex = 0;
            this.label48.Text = "Profile:";
            // 
            // groupBox12
            // 
            this.structuresExtender.SetAttributeName(this.groupBox12, null);
            this.structuresExtender.SetAttributeTypeName(this.groupBox12, null);
            this.structuresExtender.SetBindPropertyName(this.groupBox12, null);
            this.groupBox12.Controls.Add(this.TopLPCount);
            this.groupBox12.Controls.Add(this.BottomLPCount);
            this.groupBox12.Controls.Add(this.tabControl3);
            this.groupBox12.Controls.Add(this.label49);
            this.groupBox12.Controls.Add(this.topList);
            this.groupBox12.Controls.Add(this.bottomList);
            this.groupBox12.Controls.Add(this.label59);
            this.groupBox12.Location = new System.Drawing.Point(325, 12);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox12.Size = new System.Drawing.Size(355, 310);
            this.groupBox12.TabIndex = 19;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Lifting Points";
            // 
            // TopLPCount
            // 
            this.structuresExtender.SetAttributeName(this.TopLPCount, null);
            this.structuresExtender.SetAttributeTypeName(this.TopLPCount, null);
            this.TopLPCount.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.TopLPCount, null);
            this.TopLPCount.Location = new System.Drawing.Point(65, 282);
            this.TopLPCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TopLPCount.Name = "TopLPCount";
            this.TopLPCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TopLPCount.Size = new System.Drawing.Size(14, 16);
            this.TopLPCount.TabIndex = 22;
            this.TopLPCount.Text = "0";
            // 
            // BottomLPCount
            // 
            this.structuresExtender.SetAttributeName(this.BottomLPCount, null);
            this.structuresExtender.SetAttributeTypeName(this.BottomLPCount, null);
            this.BottomLPCount.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.BottomLPCount, null);
            this.BottomLPCount.Location = new System.Drawing.Point(236, 282);
            this.BottomLPCount.Name = "BottomLPCount";
            this.BottomLPCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.BottomLPCount.Size = new System.Drawing.Size(14, 16);
            this.BottomLPCount.TabIndex = 23;
            this.BottomLPCount.Text = "0";
            // 
            // tabControl3
            // 
            this.structuresExtender.SetAttributeName(this.tabControl3, null);
            this.structuresExtender.SetAttributeTypeName(this.tabControl3, null);
            this.structuresExtender.SetBindPropertyName(this.tabControl3, null);
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Controls.Add(this.tabPage5);
            this.tabControl3.Location = new System.Drawing.Point(15, 27);
            this.tabControl3.Margin = new System.Windows.Forms.Padding(5);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(331, 153);
            this.tabControl3.TabIndex = 19;
            // 
            // tabPage3
            // 
            this.structuresExtender.SetAttributeName(this.tabPage3, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage3, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage3, null);
            this.tabPage3.Controls.Add(this.AddLPBoth);
            this.tabPage3.Controls.Add(this.AddLPBottom);
            this.tabPage3.Controls.Add(this.AddLPTop);
            this.tabPage3.Controls.Add(this.AddLPTextBox);
            this.tabPage3.Controls.Add(this.AddLP);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage3.Size = new System.Drawing.Size(323, 124);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Add";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // AddLPBoth
            // 
            this.structuresExtender.SetAttributeName(this.AddLPBoth, null);
            this.structuresExtender.SetAttributeTypeName(this.AddLPBoth, null);
            this.AddLPBoth.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.AddLPBoth, null);
            this.AddLPBoth.Location = new System.Drawing.Point(220, 10);
            this.AddLPBoth.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.AddLPBoth.Name = "AddLPBoth";
            this.AddLPBoth.Size = new System.Drawing.Size(55, 20);
            this.AddLPBoth.TabIndex = 9;
            this.AddLPBoth.TabStop = true;
            this.AddLPBoth.Text = "Both";
            this.AddLPBoth.UseVisualStyleBackColor = true;
            // 
            // AddLPBottom
            // 
            this.structuresExtender.SetAttributeName(this.AddLPBottom, null);
            this.structuresExtender.SetAttributeTypeName(this.AddLPBottom, null);
            this.AddLPBottom.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.AddLPBottom, null);
            this.AddLPBottom.Location = new System.Drawing.Point(108, 10);
            this.AddLPBottom.Margin = new System.Windows.Forms.Padding(5);
            this.AddLPBottom.Name = "AddLPBottom";
            this.AddLPBottom.Size = new System.Drawing.Size(70, 20);
            this.AddLPBottom.TabIndex = 3;
            this.AddLPBottom.TabStop = true;
            this.AddLPBottom.Text = "Bottom";
            this.AddLPBottom.UseVisualStyleBackColor = true;
            // 
            // AddLPTop
            // 
            this.structuresExtender.SetAttributeName(this.AddLPTop, null);
            this.structuresExtender.SetAttributeTypeName(this.AddLPTop, null);
            this.AddLPTop.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.AddLPTop, null);
            this.AddLPTop.Checked = true;
            this.AddLPTop.Location = new System.Drawing.Point(13, 10);
            this.AddLPTop.Margin = new System.Windows.Forms.Padding(5);
            this.AddLPTop.Name = "AddLPTop";
            this.AddLPTop.Size = new System.Drawing.Size(53, 20);
            this.AddLPTop.TabIndex = 2;
            this.AddLPTop.TabStop = true;
            this.AddLPTop.Text = "Top";
            this.AddLPTop.UseVisualStyleBackColor = true;
            this.AddLPTop.CheckedChanged += new System.EventHandler(this.AddLPTop_CheckedChanged);
            // 
            // AddLPTextBox
            // 
            this.structuresExtender.SetAttributeName(this.AddLPTextBox, null);
            this.structuresExtender.SetAttributeTypeName(this.AddLPTextBox, null);
            this.structuresExtender.SetBindPropertyName(this.AddLPTextBox, null);
            this.AddLPTextBox.Location = new System.Drawing.Point(11, 44);
            this.AddLPTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.AddLPTextBox.Name = "AddLPTextBox";
            this.AddLPTextBox.Size = new System.Drawing.Size(144, 22);
            this.AddLPTextBox.TabIndex = 0;
            // 
            // AddLP
            // 
            this.structuresExtender.SetAttributeName(this.AddLP, null);
            this.structuresExtender.SetAttributeTypeName(this.AddLP, null);
            this.structuresExtender.SetBindPropertyName(this.AddLP, null);
            this.AddLP.Location = new System.Drawing.Point(11, 84);
            this.AddLP.Margin = new System.Windows.Forms.Padding(5);
            this.AddLP.Name = "AddLP";
            this.AddLP.Size = new System.Drawing.Size(148, 31);
            this.AddLP.TabIndex = 1;
            this.AddLP.Text = "Add";
            this.AddLP.UseVisualStyleBackColor = true;
            this.AddLP.Click += new System.EventHandler(this.AddLP_Click);
            // 
            // tabPage5
            // 
            this.structuresExtender.SetAttributeName(this.tabPage5, null);
            this.structuresExtender.SetAttributeTypeName(this.tabPage5, null);
            this.structuresExtender.SetBindPropertyName(this.tabPage5, null);
            this.tabPage5.Controls.Add(this.ClearLP);
            this.tabPage5.Controls.Add(this.RemoveLP);
            this.tabPage5.Controls.Add(this.EditLPBottom);
            this.tabPage5.Controls.Add(this.EditLPTop);
            this.tabPage5.Controls.Add(this.EditLPTextBox);
            this.tabPage5.Controls.Add(this.EditLP);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage5.Size = new System.Drawing.Size(323, 124);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Edit";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // ClearLP
            // 
            this.structuresExtender.SetAttributeName(this.ClearLP, null);
            this.structuresExtender.SetAttributeTypeName(this.ClearLP, null);
            this.structuresExtender.SetBindPropertyName(this.ClearLP, null);
            this.ClearLP.Location = new System.Drawing.Point(164, 81);
            this.ClearLP.Margin = new System.Windows.Forms.Padding(5);
            this.ClearLP.Name = "ClearLP";
            this.ClearLP.Size = new System.Drawing.Size(143, 31);
            this.ClearLP.TabIndex = 5;
            this.ClearLP.TabStop = false;
            this.ClearLP.Text = "Remove All";
            this.ClearLP.UseVisualStyleBackColor = true;
            this.ClearLP.Click += new System.EventHandler(this.ClearLP_Click);
            // 
            // RemoveLP
            // 
            this.structuresExtender.SetAttributeName(this.RemoveLP, null);
            this.structuresExtender.SetAttributeTypeName(this.RemoveLP, null);
            this.structuresExtender.SetBindPropertyName(this.RemoveLP, null);
            this.RemoveLP.Location = new System.Drawing.Point(11, 81);
            this.RemoveLP.Margin = new System.Windows.Forms.Padding(5);
            this.RemoveLP.Name = "RemoveLP";
            this.RemoveLP.Size = new System.Drawing.Size(145, 31);
            this.RemoveLP.TabIndex = 4;
            this.RemoveLP.Text = "Remove";
            this.RemoveLP.UseVisualStyleBackColor = true;
            this.RemoveLP.Click += new System.EventHandler(this.RemoveLP_Click);
            // 
            // EditLPBottom
            // 
            this.structuresExtender.SetAttributeName(this.EditLPBottom, null);
            this.structuresExtender.SetAttributeTypeName(this.EditLPBottom, null);
            this.EditLPBottom.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.EditLPBottom, null);
            this.EditLPBottom.Location = new System.Drawing.Point(107, 10);
            this.EditLPBottom.Margin = new System.Windows.Forms.Padding(5);
            this.EditLPBottom.Name = "EditLPBottom";
            this.EditLPBottom.Size = new System.Drawing.Size(70, 20);
            this.EditLPBottom.TabIndex = 1;
            this.EditLPBottom.Text = "Bottom";
            this.EditLPBottom.UseVisualStyleBackColor = true;
            // 
            // EditLPTop
            // 
            this.structuresExtender.SetAttributeName(this.EditLPTop, null);
            this.structuresExtender.SetAttributeTypeName(this.EditLPTop, null);
            this.EditLPTop.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.EditLPTop, null);
            this.EditLPTop.Checked = true;
            this.EditLPTop.Location = new System.Drawing.Point(12, 10);
            this.EditLPTop.Margin = new System.Windows.Forms.Padding(5);
            this.EditLPTop.Name = "EditLPTop";
            this.EditLPTop.Size = new System.Drawing.Size(53, 20);
            this.EditLPTop.TabIndex = 0;
            this.EditLPTop.TabStop = true;
            this.EditLPTop.Text = "Top";
            this.EditLPTop.UseVisualStyleBackColor = true;
            this.EditLPTop.CheckedChanged += new System.EventHandler(this.EditLPTop_CheckedChanged);
            // 
            // EditLPTextBox
            // 
            this.structuresExtender.SetAttributeName(this.EditLPTextBox, null);
            this.structuresExtender.SetAttributeTypeName(this.EditLPTextBox, null);
            this.structuresExtender.SetBindPropertyName(this.EditLPTextBox, null);
            this.EditLPTextBox.Location = new System.Drawing.Point(11, 44);
            this.EditLPTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.EditLPTextBox.Name = "EditLPTextBox";
            this.EditLPTextBox.Size = new System.Drawing.Size(144, 22);
            this.EditLPTextBox.TabIndex = 2;
            // 
            // EditLP
            // 
            this.structuresExtender.SetAttributeName(this.EditLP, null);
            this.structuresExtender.SetAttributeTypeName(this.EditLP, null);
            this.structuresExtender.SetBindPropertyName(this.EditLP, null);
            this.EditLP.Location = new System.Drawing.Point(164, 44);
            this.EditLP.Margin = new System.Windows.Forms.Padding(5);
            this.EditLP.Name = "EditLP";
            this.EditLP.Size = new System.Drawing.Size(143, 31);
            this.EditLP.TabIndex = 3;
            this.EditLP.Text = "Edit";
            this.EditLP.UseVisualStyleBackColor = true;
            this.EditLP.Click += new System.EventHandler(this.EditLP_Click);
            // 
            // label49
            // 
            this.structuresExtender.SetAttributeName(this.label49, null);
            this.structuresExtender.SetAttributeTypeName(this.label49, null);
            this.label49.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label49, null);
            this.label49.Location = new System.Drawing.Point(7, 281);
            this.label49.Name = "label49";
            this.label49.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label49.Size = new System.Drawing.Size(48, 16);
            this.label49.TabIndex = 19;
            this.label49.Text = "Upper:";
            // 
            // topList
            // 
            this.topList.AllowDrop = true;
            this.structuresExtender.SetAttributeName(this.topList, null);
            this.structuresExtender.SetAttributeTypeName(this.topList, null);
            this.structuresExtender.SetBindPropertyName(this.topList, null);
            this.topList.FormattingEnabled = true;
            this.topList.ItemHeight = 16;
            this.topList.Location = new System.Drawing.Point(8, 188);
            this.topList.Margin = new System.Windows.Forms.Padding(4);
            this.topList.Name = "topList";
            this.topList.Size = new System.Drawing.Size(163, 84);
            this.topList.TabIndex = 19;
            this.topList.SelectedIndexChanged += new System.EventHandler(this.topList_SelectedIndexChanged);
            // 
            // bottomList
            // 
            this.bottomList.AllowDrop = true;
            this.structuresExtender.SetAttributeName(this.bottomList, null);
            this.structuresExtender.SetAttributeTypeName(this.bottomList, null);
            this.structuresExtender.SetBindPropertyName(this.bottomList, null);
            this.bottomList.FormattingEnabled = true;
            this.bottomList.ItemHeight = 16;
            this.bottomList.Location = new System.Drawing.Point(179, 188);
            this.bottomList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bottomList.Name = "bottomList";
            this.bottomList.Size = new System.Drawing.Size(160, 84);
            this.bottomList.TabIndex = 20;
            this.bottomList.SelectedIndexChanged += new System.EventHandler(this.bottomList_SelectedIndexChanged);
            // 
            // label59
            // 
            this.structuresExtender.SetAttributeName(this.label59, null);
            this.structuresExtender.SetAttributeTypeName(this.label59, null);
            this.label59.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label59, null);
            this.label59.Location = new System.Drawing.Point(176, 282);
            this.label59.Name = "label59";
            this.label59.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label59.Size = new System.Drawing.Size(46, 16);
            this.label59.TabIndex = 21;
            this.label59.Text = "Lower:";
            // 
            // button1
            // 
            this.structuresExtender.SetAttributeName(this.button1, null);
            this.structuresExtender.SetAttributeTypeName(this.button1, null);
            this.structuresExtender.SetBindPropertyName(this.button1, null);
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(868, 942);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 82);
            this.button1.TabIndex = 24;
            this.button1.Text = "Build";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.BuildTypeSelection_Button_Click);
            // 
            // ValidateButton
            // 
            this.structuresExtender.SetAttributeName(this.ValidateButton, null);
            this.structuresExtender.SetAttributeTypeName(this.ValidateButton, null);
            this.structuresExtender.SetBindPropertyName(this.ValidateButton, null);
            this.ValidateButton.Location = new System.Drawing.Point(691, 942);
            this.ValidateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ValidateButton.Name = "ValidateButton";
            this.ValidateButton.Size = new System.Drawing.Size(168, 82);
            this.ValidateButton.TabIndex = 23;
            this.ValidateButton.Text = "Validate";
            this.ValidateButton.UseVisualStyleBackColor = true;
            this.ValidateButton.Click += new System.EventHandler(this.ValidateButton_Click);
            // 
            // label58
            // 
            this.structuresExtender.SetAttributeName(this.label58, null);
            this.structuresExtender.SetAttributeTypeName(this.label58, null);
            this.label58.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label58, null);
            this.label58.Location = new System.Drawing.Point(12, 381);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(156, 25);
            this.label58.TabIndex = 15;
            this.label58.Text = "Current Angle: ";
            // 
            // GH_count
            // 
            this.structuresExtender.SetAttributeName(this.GH_count, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_count, null);
            this.GH_count.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.GH_count, null);
            this.GH_count.Location = new System.Drawing.Point(476, 46);
            this.GH_count.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GH_count.Name = "GH_count";
            this.GH_count.Size = new System.Drawing.Size(24, 25);
            this.GH_count.TabIndex = 14;
            this.GH_count.Text = "0";
            // 
            // GH_button
            // 
            this.structuresExtender.SetAttributeName(this.GH_button, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_button, null);
            this.structuresExtender.SetBindPropertyName(this.GH_button, null);
            this.GH_button.Location = new System.Drawing.Point(220, 338);
            this.GH_button.Margin = new System.Windows.Forms.Padding(6);
            this.GH_button.Name = "GH_button";
            this.GH_button.Size = new System.Drawing.Size(282, 62);
            this.GH_button.TabIndex = 11;
            this.GH_button.Text = "Set Dimensions";
            this.GH_button.UseVisualStyleBackColor = true;
            // 
            // GH_countX
            // 
            this.structuresExtender.SetAttributeName(this.GH_countX, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_countX, null);
            this.GH_countX.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.GH_countX, null);
            this.GH_countX.Location = new System.Drawing.Point(476, 127);
            this.GH_countX.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GH_countX.Name = "GH_countX";
            this.GH_countX.Size = new System.Drawing.Size(24, 25);
            this.GH_countX.TabIndex = 10;
            this.GH_countX.Text = "0";
            // 
            // GH_countY
            // 
            this.structuresExtender.SetAttributeName(this.GH_countY, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_countY, null);
            this.GH_countY.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.GH_countY, null);
            this.GH_countY.Location = new System.Drawing.Point(476, 206);
            this.GH_countY.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GH_countY.Name = "GH_countY";
            this.GH_countY.Size = new System.Drawing.Size(24, 25);
            this.GH_countY.TabIndex = 9;
            this.GH_countY.Text = "0";
            // 
            // GH_countZ
            // 
            this.structuresExtender.SetAttributeName(this.GH_countZ, null);
            this.structuresExtender.SetAttributeTypeName(this.GH_countZ, null);
            this.GH_countZ.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.GH_countZ, null);
            this.GH_countZ.Location = new System.Drawing.Point(476, 277);
            this.GH_countZ.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.GH_countZ.Name = "GH_countZ";
            this.GH_countZ.Size = new System.Drawing.Size(24, 25);
            this.GH_countZ.TabIndex = 8;
            this.GH_countZ.Text = "0";
            // 
            // angelLabel
            // 
            this.structuresExtender.SetAttributeName(this.angelLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.angelLabel, null);
            this.angelLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.angelLabel, null);
            this.angelLabel.Location = new System.Drawing.Point(330, 381);
            this.angelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.angelLabel.Name = "angelLabel";
            this.angelLabel.Size = new System.Drawing.Size(36, 25);
            this.angelLabel.TabIndex = 19;
            this.angelLabel.Text = "10";
            // 
            // vertLabel
            // 
            this.structuresExtender.SetAttributeName(this.vertLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.vertLabel, null);
            this.vertLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.vertLabel, null);
            this.vertLabel.Location = new System.Drawing.Point(330, 292);
            this.vertLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vertLabel.Name = "vertLabel";
            this.vertLabel.Size = new System.Drawing.Size(48, 25);
            this.vertLabel.TabIndex = 18;
            this.vertLabel.Text = "200";
            // 
            // armOffsetLabel
            // 
            this.structuresExtender.SetAttributeName(this.armOffsetLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.armOffsetLabel, null);
            this.armOffsetLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.armOffsetLabel, null);
            this.armOffsetLabel.Location = new System.Drawing.Point(330, 129);
            this.armOffsetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.armOffsetLabel.Name = "armOffsetLabel";
            this.armOffsetLabel.Size = new System.Drawing.Size(24, 25);
            this.armOffsetLabel.TabIndex = 16;
            this.armOffsetLabel.Text = "0";
            // 
            // label55
            // 
            this.structuresExtender.SetAttributeName(this.label55, null);
            this.structuresExtender.SetAttributeTypeName(this.label55, null);
            this.label55.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label55, null);
            this.label55.Location = new System.Drawing.Point(16, 129);
            this.label55.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(158, 25);
            this.label55.TabIndex = 12;
            this.label55.Text = "Current Offset: ";
            // 
            // label56
            // 
            this.structuresExtender.SetAttributeName(this.label56, null);
            this.structuresExtender.SetAttributeTypeName(this.label56, null);
            this.label56.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label56, null);
            this.label56.Location = new System.Drawing.Point(16, 208);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(270, 25);
            this.label56.TabIndex = 13;
            this.label56.Text = "Current Horizontal Length: ";
            // 
            // armLengthLabel
            // 
            this.structuresExtender.SetAttributeName(this.armLengthLabel, null);
            this.structuresExtender.SetAttributeTypeName(this.armLengthLabel, null);
            this.armLengthLabel.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.armLengthLabel, null);
            this.armLengthLabel.Location = new System.Drawing.Point(330, 208);
            this.armLengthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.armLengthLabel.Name = "armLengthLabel";
            this.armLengthLabel.Size = new System.Drawing.Size(60, 25);
            this.armLengthLabel.TabIndex = 17;
            this.armLengthLabel.Text = "1000";
            // 
            // label50
            // 
            this.structuresExtender.SetAttributeName(this.label50, null);
            this.structuresExtender.SetAttributeTypeName(this.label50, null);
            this.label50.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label50, null);
            this.label50.Location = new System.Drawing.Point(7, 59);
            this.label50.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(103, 13);
            this.label50.TabIndex = 8;
            this.label50.Text = "Offset from left side: ";
            // 
            // label51
            // 
            this.structuresExtender.SetAttributeName(this.label51, null);
            this.structuresExtender.SetAttributeTypeName(this.label51, null);
            this.label51.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label51, null);
            this.label51.Location = new System.Drawing.Point(7, 84);
            this.label51.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(99, 13);
            this.label51.TabIndex = 11;
            this.label51.Text = "Current arm length: ";
            // 
            // EditAddSplit
            // 
            this.structuresExtender.SetAttributeName(this.EditAddSplit, null);
            this.structuresExtender.SetAttributeTypeName(this.EditAddSplit, null);
            this.structuresExtender.SetBindPropertyName(this.EditAddSplit, null);
            this.EditAddSplit.Location = new System.Drawing.Point(0, 0);
            this.EditAddSplit.Name = "EditAddSplit";
            this.EditAddSplit.Size = new System.Drawing.Size(75, 23);
            this.EditAddSplit.TabIndex = 0;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "json";
            this.saveFileDialog.Filter = "JSON files|*.json|All files|*.*";
            this.saveFileDialog.Title = "Save Parameters";
            // 
            // LoadButton
            // 
            this.structuresExtender.SetAttributeName(this.LoadButton, null);
            this.structuresExtender.SetAttributeTypeName(this.LoadButton, null);
            this.structuresExtender.SetBindPropertyName(this.LoadButton, null);
            this.LoadButton.Location = new System.Drawing.Point(1229, 942);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(168, 82);
            this.LoadButton.TabIndex = 26;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.structuresExtender.SetAttributeName(this.SaveButton, null);
            this.structuresExtender.SetAttributeTypeName(this.SaveButton, null);
            this.structuresExtender.SetBindPropertyName(this.SaveButton, null);
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(1049, 942);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(168, 82);
            this.SaveButton.TabIndex = 27;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "json";
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.Filter = "JSON files|*.json|All files|*.*";
            // 
            // label41
            // 
            this.structuresExtender.SetAttributeName(this.label41, null);
            this.structuresExtender.SetAttributeTypeName(this.label41, null);
            this.label41.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label41, null);
            this.label41.Location = new System.Drawing.Point(88, 975);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(67, 16);
            this.label41.TabIndex = 28;
            this.label41.Text = "Part Prefix";
            // 
            // label42
            // 
            this.structuresExtender.SetAttributeName(this.label42, null);
            this.structuresExtender.SetAttributeTypeName(this.label42, null);
            this.label42.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.label42, null);
            this.label42.Location = new System.Drawing.Point(55, 1008);
            this.label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(103, 16);
            this.label42.TabIndex = 28;
            this.label42.Text = "Assembly Prefix";
            // 
            // partPrefix
            // 
            this.structuresExtender.SetAttributeName(this.partPrefix, null);
            this.structuresExtender.SetAttributeTypeName(this.partPrefix, null);
            this.structuresExtender.SetBindPropertyName(this.partPrefix, null);
            this.partPrefix.Location = new System.Drawing.Point(172, 972);
            this.partPrefix.Margin = new System.Windows.Forms.Padding(4);
            this.partPrefix.Name = "partPrefix";
            this.partPrefix.Size = new System.Drawing.Size(100, 22);
            this.partPrefix.TabIndex = 29;
            this.partPrefix.Text = "M";
            this.partPrefix.TextChanged += new System.EventHandler(this.partPrefix_TextChanged);
            // 
            // assemblyPrefix
            // 
            this.structuresExtender.SetAttributeName(this.assemblyPrefix, null);
            this.structuresExtender.SetAttributeTypeName(this.assemblyPrefix, null);
            this.structuresExtender.SetBindPropertyName(this.assemblyPrefix, null);
            this.assemblyPrefix.Location = new System.Drawing.Point(171, 1004);
            this.assemblyPrefix.Margin = new System.Windows.Forms.Padding(4);
            this.assemblyPrefix.Name = "assemblyPrefix";
            this.assemblyPrefix.Size = new System.Drawing.Size(104, 22);
            this.assemblyPrefix.TabIndex = 30;
            this.assemblyPrefix.Text = "A";
            this.assemblyPrefix.TextChanged += new System.EventHandler(this.assemblyPrefix_TextChanged);
            // 
            // programBindingSource
            // 
            this.programBindingSource.DataSource = typeof(TeklaBillboardAid.Program);
            // 
            // Curved_Check
            // 
            this.Curved_Check.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.structuresExtender.SetAttributeName(this.Curved_Check, null);
            this.structuresExtender.SetAttributeTypeName(this.Curved_Check, null);
            this.Curved_Check.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.Curved_Check, null);
            this.Curved_Check.Location = new System.Drawing.Point(275, 14);
            this.Curved_Check.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Curved_Check.Name = "Curved_Check";
            this.Curved_Check.Size = new System.Drawing.Size(72, 20);
            this.Curved_Check.TabIndex = 14;
            this.Curved_Check.Text = "Curved";
            this.Curved_Check.UseVisualStyleBackColor = true;
            this.Curved_Check.CheckedChanged += new System.EventHandler(this.Curved_Check_CheckedChanged);
            // 
            // Form1
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(1731, 959);
            this.Controls.Add(this.assemblyPrefix);
            this.Controls.Add(this.partPrefix);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.ValidateButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tekla Billboard Aid";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.ledCabinets.ResumeLayout(false);
            this.ledCabinets.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.CabinetControl.ResumeLayout(false);
            this.CabinetAddTab.ResumeLayout(false);
            this.CabinetAddTab.PerformLayout();
            this.CabinetEditTab.ResumeLayout(false);
            this.CabinetEditTab.PerformLayout();
            this.MaterialAndProfile.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.BillboardDimensions.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.StructureControl.ResumeLayout(false);
            this.StructureAddTab.ResumeLayout(false);
            this.StructureAddTab.PerformLayout();
            this.StructureEditTab.ResumeLayout(false);
            this.StructureEditTab.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.RailingInfo.ResumeLayout(false);
            this.RailingInfo.PerformLayout();
            this.ScreenProfile.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.RearDoorGroup.ResumeLayout(false);
            this.RearDoorGroup.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.LadderBuilder.ResumeLayout(false);
            this.LadderBuilder.PerformLayout();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.tabControl4.ResumeLayout(false);
            this.TopFlashingTab.ResumeLayout(false);
            this.TopFlashingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.BottomFlashingTab.ResumeLayout(false);
            this.BottomFlashingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.SideFlashingTab.ResumeLayout(false);
            this.SideFlashingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.GH_panel.ResumeLayout(false);
            this.GH_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.cameraArm.ResumeLayout(false);
            this.cameraArm.PerformLayout();
            this.WW_panel.ResumeLayout(false);
            this.WW_panel.PerformLayout();
            this.WW_tabControl.ResumeLayout(false);
            this.WW_tab.ResumeLayout(false);
            this.WW_tab.PerformLayout();
            this.WW_tab2.ResumeLayout(false);
            this.WW_tab2.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.tabControl3.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.programBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void LEDProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(LEDProfile.Text))
            {
                errorProvider.SetError(LEDProfile, "Profile required");
            }
            else if (!Regex.IsMatch(LEDProfile.Text, @"^PLT\d+(?:\.\d+)?$"))
            {
                errorProvider.SetError(LEDProfile, "Profile invalid");
            }
            else
            {
                errorProvider.SetError(LEDProfile, null);
            }
        }

        private void B1Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(B1Profile);
        }

        private void B2Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(B2Profile);
        }
        private void B5Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(B5Profile);
        }

        private void B3Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(B3Profile);
        }

        private void C1Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(C1Profile);
        }

        private void BR1Profile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(BR1Profile);
        }

        private void C1SplitProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(C1SplitBeamProfile);
        }
        private void B1SplitProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(B1SplitBeamProfile);
        }
        private void B2SplitProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(B2SplitBeamProfile);
        }
        private void B5SplitProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(B5SplitBeamProfile);
        }

        private void WalerProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(WalerProfile);
        }

        private void SeatingPlateProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(SeatingPlateProfile.Text))
            {
                errorProvider.SetError(SeatingPlateProfile, "Profile required");
            }
            else if (!Regex.IsMatch(SeatingPlateProfile.Text, @"^(FL)\d+(?:\.\d+)?$"))
            {
                errorProvider.SetError(SeatingPlateProfile, "Profile invalid - Only FL profile");
            }
            else
            {
                errorProvider.SetError(SeatingPlateProfile, null);
            }
        }

        private void HatchBeamProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateProfileWithWarning(HatchBeamProfile);
        }

        private void Welding_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(Welding);
        }

        private void MeshThickness_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(MeshThickness);
        }
        private void RailingSpace1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(RailingSpace1);
        }

        private void RailingSpace2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(RailingSpace2);
        }

        private void HoleHorizontalOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(HoleHorizontalOffset);
        }

        private void HoleVerticalOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(HoleVerticalOffset);
        }

        private void HeightOffsetTop_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(HeightOffsetTop);
        }

        private void HeightOffsetBottom_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(HeightOffsetBottom);
        }

        private void CornerOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(CornerOffset);
        }

        private void DiagonalTopOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(DiagonalTopOffset);
        }

        private void DiagonalBottomOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(DiagonalBottomOffset);
        }

        private void BoltDiameter_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(BoltDiameter);
        }

        private void SeatingPlateOffset_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(SeatingPlateOffset);
        }

        private void TrimmerBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(TrimmerBox);
        }

        private void HandRailingBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(HandRailingBox);
        }
        private void KneeRailingBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(KneeRailingBox);
        }
        private void Radius_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(Radius_Text);
        }
        private void ExtrusionLength_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(ExtrusionLength);
        }

        private void EAProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(EAProfile.Text))
            {
                errorProvider.SetError(EAProfile, "Profile required");
            }
            else if (!Regex.IsMatch(EAProfile.Text, @"^EA\d{2,3}\*\d{2,3}\*\d{1,2}$"))
            {
                errorProvider.SetError(EAProfile, "Profile invalid");
            }
            else
            {
                errorProvider.SetError(EAProfile, null);
            }
        }

        private void ZBracketProfile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(ZBracketProfile.Text))
            {
                errorProvider.SetError(ZBracketProfile, "Profile required");
            }
            else if (!Regex.IsMatch(ZBracketProfile.Text, @"^PLT\d{1,}(?:\.\d{1,})?(\*)?(?(1)\d{1,}(?:\.\d{1,})?$|$)"))
            {
                errorProvider.SetError(ZBracketProfile, "Profile invalid");
            }
            else
            {
                errorProvider.SetError(ZBracketProfile, null);
            }
        }

        private void LowerWalerSpacing_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(LowerWalerSpacing);
        }

        private void UpperWalerSpacing_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(UpperWalerSpacing);
        }

        private void EAClearance_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(EAClearance);
        }

        private void ZbracketSpacingA_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(ZbracketSpacingA);
        }

        private void ZbracketSpacingB_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(ZbracketSpacingB);
        }
        private void ZbracketEndSpacing_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(ZbracketEndSpacing);
        }
        private void WalkwayClearance_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(WalkwayClearance);
        }
        private void WalkwayWidth_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ValidateDoubleWithWarning(WalkwayWidth);
        }
        private void BracketBoltDiameter_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(BracketBoltDiameter);
        }

        private void LEDDensity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(LEDDensity);
        }

        private void BracketSpacerThickness_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ValidateDoubleWithWarning(BracketSpacerThickness);
        }

        private bool ValidateDoubleWithWarning(System.Windows.Forms.TextBox textbox)
        {
            if (string.IsNullOrEmpty(textbox.Text))
            {
                errorProvider.SetError(textbox, "Cannot be empty");
            }
            else if (!Regex.IsMatch(textbox.Text, @"^\d+(?:\.\d+)?$"))
            {
                errorProvider.SetError(textbox, "Invalid input");
            }
            else
            {
                errorProvider.SetError(textbox, null);
                return true;
            }
            return false;
        }

        // Profile string validation
        private bool ValidateProfileWithWarning(System.Windows.Forms.TextBox textbox)
        {
            if (string.IsNullOrEmpty(textbox.Text))
            {
                errorProvider.SetError(textbox, "Profile required");
            }
            else if (!Regex.IsMatch(textbox.Text, @"^[SR]{1}HS\d{2,3}\*\d{2,3}\*\d{1,2}\.\d{1}$"))
            {
                errorProvider.SetError(textbox, "Profile invalid");
            }
            else
            {
                errorProvider.SetError(textbox, null);
                return true;
            }
            return false;
        }

        #endregion
        private System.Windows.Forms.GroupBox ledCabinets;
        private System.Windows.Forms.ListBox rowList;
        private System.Windows.Forms.Button cabinetValueAddButton;
        private System.Windows.Forms.TextBox cabinetAddValue;
        private System.Windows.Forms.BindingSource programBindingSource;
        private System.Windows.Forms.Label columnSumLabel;
        private System.Windows.Forms.Label columnLabel;
        private System.Windows.Forms.Label rowSumLabel;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.ListBox columnList;
        private System.Windows.Forms.RadioButton ColumnAddRadioButton;
        private System.Windows.Forms.RadioButton RowAddRadioButton;
        private System.Windows.Forms.TabControl CabinetControl;
        private System.Windows.Forms.TabPage CabinetAddTab;
        private System.Windows.Forms.TabPage CabinetEditTab;
        private System.Windows.Forms.Button CabinetRemoveButton;
        private System.Windows.Forms.RadioButton ColumnEditRadioButton;
        private System.Windows.Forms.RadioButton RowEditRadioButton;
        private System.Windows.Forms.TextBox CabinetEditValue;
        private System.Windows.Forms.Button CabinetEditButton;
        private System.Windows.Forms.Button CabinetResetButton;
        private System.Windows.Forms.GroupBox MaterialAndProfile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox B5Profile;
        private System.Windows.Forms.TextBox B5Material;
        private System.Windows.Forms.TextBox B2Profile;
        private System.Windows.Forms.TextBox B2Material;
        private System.Windows.Forms.TextBox B1Profile;
        private System.Windows.Forms.TextBox B1Material;
        private System.Windows.Forms.TextBox C1Profile;
        private System.Windows.Forms.TextBox LEDProfile;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label B5;
        private System.Windows.Forms.Label B2;
        private System.Windows.Forms.Label LED;
        private System.Windows.Forms.Label C1;
        private System.Windows.Forms.Label B1;
        private System.Windows.Forms.TextBox LEDMaterial;
        private System.Windows.Forms.TextBox C1Material;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HoleVerticalOffset;
        private System.Windows.Forms.TextBox HoleHorizontalOffset;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox BillboardDimensions;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox BoltDiameter;
        private System.Windows.Forms.Label BillBoardLength;
        private System.Windows.Forms.Label BillBoardHeight;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox HeightOffsetBottom;
        private System.Windows.Forms.TextBox HeightOffsetTop;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label B3;
        private System.Windows.Forms.TextBox B3Material;
        private System.Windows.Forms.TextBox B3Profile;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox RailingSpace2;
        private System.Windows.Forms.TextBox RailingSpace1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabControl StructureControl;
        private System.Windows.Forms.TabPage StructureAddTab;
        private System.Windows.Forms.RadioButton StructureManualRadio;
        private System.Windows.Forms.TextBox HorizontalBeamsAddValue;
        private System.Windows.Forms.Button HorizontalBeamsAddButton;
        private System.Windows.Forms.RadioButton StructureAutoRadio;
        private System.Windows.Forms.TabPage StructureEditTab;
        private System.Windows.Forms.Button HorizontalBeamsResetButton;
        private System.Windows.Forms.Button HorizontalBeamsRemoveButton;
        private System.Windows.Forms.TextBox HorizontalBeamsEditValue;
        private System.Windows.Forms.Button HorizontalBeamsEditButton;
        private System.Windows.Forms.Label BeamsSumLabel;
        private System.Windows.Forms.Label BeamsLabel;
        private System.Windows.Forms.ListBox HorizontalBeamsList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label CabinetLengthLabel;
        private System.Windows.Forms.Label CabinetHeightLabel;
        private System.Windows.Forms.Label CabinetLengthSumLabel;
        private System.Windows.Forms.Label CabinetHeightSumLabel;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox CornerOffset;
        private System.Windows.Forms.Label CornerOffsetLabel;
        private System.Windows.Forms.TextBox DiagonalTopOffset;
        private System.Windows.Forms.Label TopOffsetLabel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label MeshThickLabel;
        private System.Windows.Forms.TextBox MeshThickness;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox Welding;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox DiagonalBottomOffset;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label Waler;
        private System.Windows.Forms.TextBox BR1Profile;
        private System.Windows.Forms.TextBox BR1Material;
        private System.Windows.Forms.Label BR1;
        private System.Windows.Forms.TextBox WalerMaterial;
        private System.Windows.Forms.TextBox WalerProfile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.TextBox LowerWalerSpacing;
        private System.Windows.Forms.TextBox UpperWalerSpacing;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton WalerManualRadio;
        private System.Windows.Forms.TextBox WalerAddValue;
        private System.Windows.Forms.Button WalerAddButton;
        private System.Windows.Forms.RadioButton WalerAutoRadio;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button WalerResetButton;
        private System.Windows.Forms.Button WalerRemoveButton;
        private System.Windows.Forms.TextBox WalerEditValue;
        private System.Windows.Forms.Button WalerEditButton;
        private System.Windows.Forms.Label WalersSumLabel;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ListBox WalersList;
        private System.Windows.Forms.Label WalerNumberLabel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label SeatingplateoffsetLabel;
        private System.Windows.Forms.TextBox SeatingPlateOffset;
        private System.Windows.Forms.TextBox ExtrusionLength;
        private System.Windows.Forms.Label seatingplateextrusionlengthLabel;
        private System.Windows.Forms.Label SeatingPlate;
        private System.Windows.Forms.TextBox SeatingPlateMaterial;
        private System.Windows.Forms.TextBox SeatingPlateProfile;
        private System.Windows.Forms.RadioButton SeatingPlateOffButton;
        private System.Windows.Forms.RadioButton SeatingPlateOnButton;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.TextBox EAClearance;
        private System.Windows.Forms.Label EAclearanceLabel;
        private System.Windows.Forms.TextBox WalkwayMaterial;
        private System.Windows.Forms.Label MeshMaterialLabel;
        private System.Windows.Forms.Label EASupport;
        private System.Windows.Forms.TextBox EAMaterial;
        private System.Windows.Forms.TextBox EAProfile;
        private System.Windows.Forms.Label ZBracketLabel;
        private System.Windows.Forms.TextBox ZBracketMaterial;
        private System.Windows.Forms.TextBox ZBracketProfile;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TextBox ZbracketSpacingA;
        private System.Windows.Forms.Label ZbracketSpacingALabel;
        private System.Windows.Forms.TextBox ZbracketSpacingB;
        private System.Windows.Forms.Label ZbracketSpacingBLabel;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.TextBox ZbracketEndSpacing;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label WalkwayWidthLabel;
        private System.Windows.Forms.Label WalkwayClearanceLabel;
        private System.Windows.Forms.TextBox WalkwayClearance;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label BillBoardDepth;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.TextBox BracketBoltDiameter;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox BracketBoltStandard;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button ValidateButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListBox bottomList;
        private System.Windows.Forms.ListBox topList;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton AddLPBoth;
        private System.Windows.Forms.RadioButton AddLPBottom;
        private System.Windows.Forms.RadioButton AddLPTop;
        private System.Windows.Forms.TextBox AddLPTextBox;
        private System.Windows.Forms.Button AddLP;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button ClearLP;
        private System.Windows.Forms.Button RemoveLP;
        private System.Windows.Forms.RadioButton EditLPBottom;
        private System.Windows.Forms.RadioButton EditLPTop;
        private System.Windows.Forms.TextBox EditLPTextBox;
        private System.Windows.Forms.Button EditLP;
        private System.Windows.Forms.Label BottomLPCount;
        private System.Windows.Forms.Label TopLPCount;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TextBox CladLength;
        private System.Windows.Forms.ComboBox CladSize;
        private System.Windows.Forms.ComboBox CladProfile;
        private System.Windows.Forms.Label EffectiveWidth;
        private System.Windows.Forms.Label SheetWidth;
        private System.Windows.Forms.Label Overlap;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label CladSizeLabel;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.GroupBox WW_panel;
        private System.Windows.Forms.TabControl WW_tabControl;
        private System.Windows.Forms.TabPage WW_tab;
        private System.Windows.Forms.TextBox WW_box;
        private System.Windows.Forms.Button WW_add;
        private System.Windows.Forms.TabPage WW_tab2;
        private System.Windows.Forms.Button WW_removeAll;
        private System.Windows.Forms.Button WW_remove;
        private System.Windows.Forms.TextBox WW_box2;
        private System.Windows.Forms.Button WW_edit;
        private System.Windows.Forms.Label WW_label;
        private System.Windows.Forms.ListBox WW_list;
        private System.Windows.Forms.Label WW_count;
        private System.Windows.Forms.Label GH_count;
        private System.Windows.Forms.Button GH_button;
        private System.Windows.Forms.Label GH_countX;
        private System.Windows.Forms.Label GH_countY;
        private System.Windows.Forms.Label GH_countZ;
        private System.Windows.Forms.GroupBox cameraArm;
        private System.Windows.Forms.RadioButton noArm;
        private System.Windows.Forms.RadioButton TopArm;
        private System.Windows.Forms.RadioButton BotArm;
        private System.Windows.Forms.TextBox ArmLeftOffset;
        private System.Windows.Forms.Label LeftOffset;
        private System.Windows.Forms.TextBox ArmLengthBox;
        private System.Windows.Forms.TextBox VertArmLength;
        private System.Windows.Forms.TextBox ArmAngle;
        private System.Windows.Forms.Label armLengthLabel;
        private System.Windows.Forms.Label angelLabel;
        private System.Windows.Forms.Label vertLabel;
        private System.Windows.Forms.Label armOffsetLabel;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TextBox Thickness;
        private System.Windows.Forms.ComboBox CladdingColour;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox OpenArea;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.ComboBox FlashingColour;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox FlashingThickness;
        private System.Windows.Forms.Label FlashingThicknessLabel;
        private System.Windows.Forms.RadioButton ManualFlashDim;
        private System.Windows.Forms.RadioButton AutoFlashDim;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TextBox B5SplitBeamProfile;
        private System.Windows.Forms.TextBox B2SplitBeamProfile;
        private System.Windows.Forms.TextBox B2SplitBeamMaterial;
        private System.Windows.Forms.TextBox B5SplitBeamMaterial;
        private System.Windows.Forms.TextBox B1SplitBeamProfile;
        private System.Windows.Forms.TextBox B1SplitBeamMaterial;
        private System.Windows.Forms.TextBox C1SplitBeamProfile;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label B5Split;
        private System.Windows.Forms.Label B2Split;
        private System.Windows.Forms.Label C1Split;
        private System.Windows.Forms.Label B1Split;
        private System.Windows.Forms.TextBox C1SplitBeamMaterial;
        private System.Windows.Forms.CheckBox FlashingsEnabled;
        private System.Windows.Forms.Button EditAddSplit;
        private System.Windows.Forms.Button AddSplit;
        private System.Windows.Forms.Button EditRemoveSplit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox enableFascia;
        private System.Windows.Forms.TextBox fasciaHeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CladOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton ThreeDButton;
        private System.Windows.Forms.RadioButton TwoDButton;
        private System.Windows.Forms.Label sides;
        private System.Windows.Forms.ComboBox theSide;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage TopFlashingTab;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TabPage BottomFlashingTab;
        private System.Windows.Forms.TabPage SideFlashingTab;
        private System.Windows.Forms.TextBox FlashingDimM;
        private System.Windows.Forms.TextBox FlashingDimL;
        private System.Windows.Forms.TextBox FlashingDimC;
        private System.Windows.Forms.TextBox FlashingDimB;
        private System.Windows.Forms.TextBox FlashingDimA;
        private System.Windows.Forms.TextBox FlashingDimQ;
        private System.Windows.Forms.TextBox FlashingDimP;
        private System.Windows.Forms.TextBox FlashingDimF;
        private System.Windows.Forms.TextBox FlashingDimE;
        private System.Windows.Forms.TextBox FlashingDimD;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.TextBox FlashingDimR;
        private System.Windows.Forms.TextBox FlashingDimS;
        private System.Windows.Forms.TextBox FlashingDimH;
        private System.Windows.Forms.TextBox FlashingDimI;
        private System.Windows.Forms.TextBox FlashingDimG;
        private System.Windows.Forms.GroupBox ScreenProfile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox LEDThickness;
        private System.Windows.Forms.TextBox LEDDensity;
        private System.Windows.Forms.Label BillboardWeight;
        private System.Windows.Forms.TextBox FlashingDimJ;
        private System.Windows.Forms.TextBox FlashingDimK;
        private System.Windows.Forms.TextBox FlashingDimO;
        private System.Windows.Forms.TextBox FlashingDimN;
        private System.Windows.Forms.TextBox ManualOpenArea;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label galDepth;
        private System.Windows.Forms.Label galWidth;
        private System.Windows.Forms.Label galLength;
        private System.Windows.Forms.Label galDepthLabel;
        private System.Windows.Forms.Label galWidthLabel;
        private System.Windows.Forms.Label galLengthLabel;
        private System.Windows.Forms.ComboBox galLocSelect;
        private System.Windows.Forms.Label galLocation;
        private System.Windows.Forms.GroupBox GH_panel;
        private System.Windows.Forms.Label GH_label_offset2;
        private System.Windows.Forms.Label GH_label_offset1;
        private System.Windows.Forms.TextBox GH_offset2;
        private System.Windows.Forms.TextBox GH_offset1;
        private System.Windows.Forms.TextBox GH_holeSize;
        private System.Windows.Forms.RadioButton GH_autoSelector;
        private System.Windows.Forms.RadioButton GH_manualSelector;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.TextBox BracketSpacerThickness;
        private System.Windows.Forms.Label BracketSpacer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox EASplitBoltOffset;
        private System.Windows.Forms.TextBox EACabinetBoltHoleSize;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label WW_add_label;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label ZBracketHoleDiameter;
        private System.Windows.Forms.TextBox BracketHoleDiameter;
        private System.Windows.Forms.RadioButton NoGalHole;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox Cameracentre;
        private System.Windows.Forms.Label LEDWidthlable;
        private System.Windows.Forms.TextBox LEDWidth;
        private System.Windows.Forms.TextBox LEDHeight;
        private System.Windows.Forms.Label LEDHeightLable;
        private System.Windows.Forms.Label LEDWeightLable;
        private System.Windows.Forms.TextBox LEDWeight;
        private System.Windows.Forms.Button button3;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog1;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog2;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog3;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog4;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog5;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog6;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog7;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog8;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog9;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog13;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog10;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog11;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog profileCatalog12;
        private System.Windows.Forms.TextBox assemblyPrefix;
        private System.Windows.Forms.TextBox partPrefix;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.ComboBox WalkwayWidth;
        private System.Windows.Forms.CheckBox SpacerPlateSwitch;
        private System.Windows.Forms.GroupBox LadderBuilder;
        private System.Windows.Forms.RadioButton RightLadder;
        private System.Windows.Forms.RadioButton LeftLadder;
        private System.Windows.Forms.RadioButton NoLadder;
        private System.Windows.Forms.TextBox LadderOffsetBackText;
        private System.Windows.Forms.Label LadderOffsetBack;
        private System.Windows.Forms.TextBox LadderOffsetSideText;
        private System.Windows.Forms.Label LadderOffsetfromSide;
        private System.Windows.Forms.TextBox LadderRungMaterialText;
        private System.Windows.Forms.Label LadderRungSpacing;
        private System.Windows.Forms.TextBox LadderRungSpacingText;
        private System.Windows.Forms.TextBox LadderPlateMaterialText;
        private System.Windows.Forms.TextBox LadderPlateHeightText;
        private System.Windows.Forms.Label LadderPlateHeight;
        private System.Windows.Forms.TextBox LadderWidthText;
        private System.Windows.Forms.Label LadderWidth;
        private System.Windows.Forms.TextBox LadderSideRailMaterialText;
        private System.Windows.Forms.GroupBox RearDoorGroup;
        private System.Windows.Forms.CheckBox RearDoorEnable;
        private System.Windows.Forms.Label DoorFramePanelDistance;
        private System.Windows.Forms.Label DoorrMinHeight;
        private System.Windows.Forms.TextBox DoorPanelFrameDistanceText;
        private System.Windows.Forms.TextBox DoorMinHeightText;
        private System.Windows.Forms.TextBox DoorWidthText;
        private System.Windows.Forms.Label DoorWidth;
        private System.Windows.Forms.TextBox DoorOffsetText;
        private System.Windows.Forms.Label DoorOffset;
        private System.Windows.Forms.Label DoorMaterial;
        private System.Windows.Forms.Label DoorPanelBeam;
        private System.Windows.Forms.Label DoorFrameBeam;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog DoorFrameBeamSelect;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog DoorPanelBeamSelect;
        private System.Windows.Forms.TextBox DoorPanelProfileText;
        private System.Windows.Forms.TextBox DoorPanelMaterialText;
        private System.Windows.Forms.TextBox DoorFrameProfileText;
        private System.Windows.Forms.TextBox DoorFrameMaterialText;
        private System.Windows.Forms.Label DoorProfile;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog LadderRailSelect;
        private System.Windows.Forms.TextBox LadderRailProfileText;
        private System.Windows.Forms.Label LadderPlate;
        private System.Windows.Forms.Label LadderRung;
        private System.Windows.Forms.Label LadderSideRail;
        private System.Windows.Forms.TextBox LadderPlateProfileText;
        private System.Windows.Forms.TextBox LadderRungProfileText;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog LadderPlateSelect;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog LadderRungSelect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.TextBox HatchBeamProfile;
        private System.Windows.Forms.Label LadderHatchProfileName;
        private System.Windows.Forms.Label LadderHatchMaterialName;
        private System.Windows.Forms.Label HatchBeamMaterialName;
        private System.Windows.Forms.TextBox HatchBeamMaterial;
        private Tekla.Structures.Dialog.UIControls.ProfileCatalog HatchBeamProfileSelector;
        private System.Windows.Forms.TextBox HatchWidthValue;
        private System.Windows.Forms.Label HatchWidthName;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.GroupBox RailingInfo;
        private System.Windows.Forms.TextBox HandRailingBox;
        private System.Windows.Forms.TextBox KneeRailingBox;
        private System.Windows.Forms.Label KneeRail;
        private System.Windows.Forms.TextBox TrimmerBox;
        private System.Windows.Forms.Label HandRail;
        private System.Windows.Forms.Label Trimmer;
        private System.Windows.Forms.TextBox Radius_Text;
        private System.Windows.Forms.CheckBox Curved_Check;
    }
}