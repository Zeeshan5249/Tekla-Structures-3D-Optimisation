using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace TeklaBillboardAid
{

    /// <summary>
    /// Class for storing all parameters required to generate a Tekla Structures model based on user input.
    /// </summary>
    public class ModelParameters
    {
        public const double InvalidValue = -1;

        /// <value>
        /// Relative x coordinates dividing the cabinets vertically (mm)
        /// </value>
        public List<double> XCoordinates { get; set; }

        /// <value>
        /// Relative z coordinates dividing the cabinets horizontally (mm)
        /// </value>
        public List<double> ZCoordinates { get; set; }

        /// <summary>
        /// A list which stores the indices at which a box ends in XCoordinates
        /// </summary>
        public List<int> XSplits { get; set; }

        /// <summary>
        /// A list which stores the indices at which a box ends in ZCoordinates
        /// </summary>
        public List<int> ZSplits { get; set; }

        // Walers
        /// <value>
        /// Distance of the top waler beam (mm)
        /// </value>
        public double UpperWalerSpacing { get; set; }

        /// <value>
        /// Distance of the lower waler beam (mm)
        /// </value>
        public double LowerWalerSpacing { get; set; }

        /// <value>
        /// List of distance offsets between each waler (mm)
        /// </value>
        public List<double> WalersCoordinates { get; set; }

        /// <value>
        /// Number of waler beams to add if auto is selected
        /// </value>
        public int WalersNumber { get; set; }

        /// <value>
        /// Whether walers are automatically spaced
        /// </value>
        public bool WalerAuto { get; set; }

        // Railings & Horizontal Back Beams
        /// <value>
        /// Distance of the bottom railing centre from the top of the walkway mesh (mm)
        /// </value>
        public double RailingSpace1 { get; set; }

        /// <value>
        /// Distance of the top railing centre from the bottom railing centre (mm)
        /// </value>
        public double RailingSpace2 { get; set; }

        /// <value>
        /// List of distance offsets between each railing (mm)
        /// </value>
        public List<double> RailingCoordinates { get; set; }

        /// <value>
        /// Whether back horizontal beams are automatically spaced
        /// </value>
        public bool AutoSpacing { get; set; }

        // Material
        /// <value>
        /// Material for the LED cabinet
        /// </value> 
        public string LEDMaterial { get; set; }

        /// <value>
        /// Material for the C1 beam
        /// </value>
        public string C1Material { get; set; }

        /// <value>
        /// Material for the B1 beam
        /// </value>
        public string B1Material { get; set; }

        /// <value>
        /// Material for the B2 beam
        /// </value>
        public string B2Material { get; set; }

        /// <value>
        /// Material for the B3 beam
        /// </value>
        public string B3Material { get; set; }

        /// <value>
        /// Material for the B5 beam
        /// </value>
        public string B5Material { get; set; }

        /// <value>
        /// Material for the BR1 beam
        /// </value>
        public string BR1Material { get; set; }

        /// <value>
        /// Material for the LED cabinet seating plate
        /// </value>
        public string SeatingPlateMaterial { get; set; }

        /// <value>
        /// Material for the waler beam
        /// </value>
        public string WalerMaterial { get; set; }

        /// <value>
        /// Material for the EA support bracket
        /// </value>
        public string EAMaterial { get; set; }

        /// <value>
        /// Material for the Z-bracket
        /// </value>
        public string BracketMaterial { get; set; }

        /// <value>
        /// Material for the walkway mesh
        /// </value>
        public string MeshMaterial { get; set; }

        /// <value>
        /// Material for the lifting point plate
        /// </value>
        public string LugPlateMaterial { get; set; }

        // Profile
        /// <value>
        /// Profile for the LED cabinet
        /// </value>
        public string LEDProfile { get; set; }

        /// <value>
        /// Profile for the C1 beam
        /// </value>
        public string C1Profile { get; set; }

        /// <value>
        /// Depth of the C1 beam (mm)
        /// </value>
        public double C1BeamDepth { get; set; }

        /// <value>
        /// Width of the C1 beam (mm)
        /// </value>
        public double C1BeamWidth { get; set; }

        /// <value>
        /// Profile for the B1 beam
        /// </value>
        public string B1Profile { get; set; }

        /// <value>
        /// Depth of the B1 beam (mm)
        /// </value>
        public double B1BeamDepth { get; set; }

        /// <value>
        /// Width of the B1 beam (mm)
        /// </value>
        public double B1BeamWidth { get; set; }
        /// <summary>
        /// Thickness of B1 Beam
        /// </summary>
        public double B1BeamThickness { get; set; }

        /// <value>
        /// Profile for the B2 beam
        /// </value>
        public string B2Profile { get; set; }

        /// <value>
        /// Depth of the B2 beam (mm)
        /// </value>
        public double B2BeamDepth { get; set; }

        /// <value>
        /// Width of the B2 beam (mm)
        /// </value>
        public double B2BeamWidth { get; set; }

        /// <value>
        /// Thickness of the B2 beam (mm)
        /// </value>
        public double B2BeamThickness { get; set; }

        /// <value>
        /// Profile for the B3 beam
        /// </value>
        public string B3Profile { get; set; }

        /// <value>
        /// Depth of the B3 beam (mm)
        /// </value>
        public double B3BeamDepth { get; set; }

        /// <value>
        /// Width of the B3 beam (mm)
        /// </value>
        public double B3BeamWidth { get; set; }

        /// <value>
        /// Profile for the B5 beam
        /// </value>
        public string B5Profile { get; set; }

        /// <value>
        /// Depth of the B5 beam (mm)
        /// </value>
        public double B5BeamDepth { get; set; }

        /// <value>
        /// Width of the B5 beam (mm)
        /// </value>
        public double B5BeamWidth { get; set; }

        /// <value>
        /// Profile for the BR1 beam
        /// </value>
        public string BR1Profile { get; set; }

        /// <value>
        /// Depth of the BR1 beam (mm)
        /// </value>
        public double BR1BeamDepth { get; set; }

        /// <value>
        /// Width of the BR1 beam (mm)
        /// </value>
        public double BR1BeamWidth { get; set; }

        /// <value>
        /// Profile for the seating plate
        /// </value>
        public string SeatingPlateProfile { get; set; }

        /// <value>
        /// Profile for the waler beam
        /// </value>
        public string WalerProfile { get; set; }

        /// <value>
        /// Depth of the waler beam (mm)
        /// </value>
        public double WalerBeamDepth { get; set; }

        /// <value>
        /// Width of the waler beam (mm)
        /// </value>
        public double WalerBeamWidth { get; set; }

        /// <value>
        /// Profile for the EA support bracket
        /// </value>
        public string EAProfile { get; set; }

        /// <value>
        /// Depth of the EA support bracket
        /// </value>
        public double EABeamDepth { get; set; }

        /// <value>
        /// Width of the EA support bracket
        /// </value>
        public double EABeamWidth { get; set; }

        /// <value>
        /// Profile for the Z-bracket
        /// </value>
        public string ZBracketProfile { get; set; }

        /// <value>
        /// Thickness of the Z-bracket (mm)
        /// </value>
        public double ZBracketThickness { get; set; }

        /// <value>
        /// Width of the Z-bracket (mm)
        /// </value>
        public double ZBracketWidth { get; set; }
        /// <value>
        /// The ZBracket Spacer Profile
        /// </value>
        public string ZBracketSpacerProfile { get; set; }
        /// <value>
        /// The Thickness of the Z Bracket spacer.
        /// </value>
        public double ZBracketSpacerThickness { get; set; }
        /// <value>
        /// Boolean Spacer Z Bracket, if the user wants one.
        /// </value>
        public bool ZBracketSpacer { get; set; }

        /// <value>
        /// The profile of beams which are used at horizontal splits, can be either EA or RHS.
        /// </value>
        public string B1SplitProfile { get; set; }

        /// <value>
        /// The material of beams used at horizontal splits.
        /// </value>
        public string B1SplitMaterial { get; set; }
        
        /// <value>
        /// The depth of beams at horizontal splits.
        /// </value>
        public double B1SplitBeamDepth { get; set; }

        /// <value>
        /// The width of beams at horizontal splits.
        /// </value>
        public double B1SplitBeamWidth { get; set; }

        /// <value>
        /// The thickness of beams at horizontal splits.
        /// </value>
        public double B1SplitBeamThickness { get; set; }

        /// <value>
        /// The offset for the bolts connecting the horizontal split EA's at splits.
        /// </value>
        public double EASplitBoltOffset { get; set; }
        /// <value>
        /// The size of the hole in the Horizontla EA Split beam which accomidates the cabinet bolts.
        /// </value>
        public double EASplitCabinetBoltHoleSize { get; set; }

        /// <value>
        /// The profile of C1 beams which are used at vertical splits.
        /// </value>
        public string C1SplitProfile { get; set; }
        /// <value>
        /// The material of C1 beams which are used at vertical splits.
        /// </value>
        public string C1SplitMaterial { get; set; }
        /// <value>
        /// The width of C1 beams which are used at vertical splits.
        /// </value>
        public double C1SplitBeamWidth { get; set; }
        /// <value>
        /// The depth of C1 beams which are used at vertical splits.
        /// </value>
        public double C1SplitBeamDepth { get; set; }

        /// <value>
        /// The profile of B2 beams which are used at vertical splits.
        /// </value>
        public string B2SplitProfile { get; set; }
        /// <value>
        /// The material of B2 beams which are used at vertical splits.
        /// </value>
        public string B2SplitMaterial { get; set; }
        /// <value>
        /// The width of B2 beams which are used at vertical splits.
        /// </value>
        public double B2SplitBeamWidth { get; set; }
        /// <value>
        /// The depth of B2 beams which are used at vertical splits.
        /// </value>
        public double B2SplitBeamDepth { get; set; }

        /// <value>
        /// The profile of B5 beams which are used at vertical splits.
        /// </value>
        public string B5SplitProfile { get; set; }
        /// <value>
        /// The material of B5 beams which are used at vertical splits.
        /// </value>
        public string B5SplitMaterial { get; set; }
        /// <value>
        /// The width of B5 beams which are used at vertical splits.
        /// </value>
        public double B5SplitBeamWidth { get; set; }
        /// <value>
        /// The depth of B5 beams which are used at vertical splits.
        /// </value>
        public double B5SplitBeamDepth { get; set; }

        /// <value>
        /// Profile for the lifting point plate
        /// </value>
        public string LugPlateProfile { get; set; }

        /// <value>
        /// Profile for the beams a part of the hatches.
        /// </value>
        public string HatchBeamProfile { get; set; }

        /// <value>
        /// Material of the hatch beams.
        /// </value>
        public string HatchBeamMaterial { get; set; }

        /// <value>
        /// Width of the hatch beams.
        /// </value>
        public double HatchBeamWidth { get; set; }

        /// <value>
        /// Depth of the hatch beams.
        /// </value>
        public double HatchBeamDepth { get; set; }



        // Cabinets

        /// <value>
        /// Bolt size diameter (mm)
        /// </value>
        public double BoltSize { get; set; }
        /// <value>
        /// Horizontal offset of the cabinet positions
        /// </value>
        public double CabinetXOffset { get; set; }

        /// <value>
        /// Horizontal offset of the bolt (mm)
        /// </value>
        public double BoltOffsetDx { get; set; }

        /// <value>
        /// Vertical offset of the bolt (mm)
        /// </value>
        public double BoltOffsetDz { get; set; }

        /// <value>
        /// The gap size between the top B1 beam and top of the LED cabinets
        /// </value>
        public double HeightOffsetTop { get; set; }

        /// <value>
        /// The gap size between the bottom B! beam and top of the LED cabinets
        /// </value>
        public double HeightOffsetBottom { get; set; }

        // Walkways
        /// <value>
        /// A list indicating the relative position of the walkways to the bottom of the billboard.
        /// </value>
        public List<double> WalkwayList { get; set; }

        /// <value>
        /// Thickness of the walkway mesh (mm)
        /// </value>
        public double MeshThickness { get; set; }

        /// <value>
        /// Width of the walkway mesh (mm)
        /// </value>
        public double WalkwayWidth { get; set; }

        /// <value>
        /// Gap between the walkway mesh and B1 beam (mm)
        /// </value>
        public double WalkwayClearance { get; set; }

        /// <value>
        /// Distance between EA support and adjacent members (mm)
        /// </value>
        public double EASupportClearance { get; set; }

        // Diagonals
        /// <value>
        /// Distance offset for the top diagonal beams away from the top of the structure (mm)
        /// </value>
        public double DiagonalTopOffset { get; set; }

        /// <value>
        /// Distance offset for the bottom diagonal beams away from the bottom of the beam (mm)
        /// </value>
        public double DiagonalBottomOffset { get; set; }

        /// <value>
        /// Distance offset for the diagonal beams from the corner of B1 and B2/B5 beams (mm)
        /// </value>
        public double CornerOffset { get; set; }

        // Seating Plates
        /// <value>
        /// Distance between the edge of the seating plate and the adjacent column (mm)
        /// </value>
        public double SeatingPlateOffset { get; set; }

        /// <value>
        /// Distance between the edge of the bottom beam to the outer edge of the seating plate (mm)
        /// </value>
        public double SeatingPlateExtrusionLength { get; set; }

        /// <value>
        /// Whether to model the seating plate
        /// </value>
        public bool BuildSeatingPlate { get; set; }

        // Z Brackets
        /// <value>
        /// Distance between the outer edge of the waler and middle Z-bracket (mm)
        /// </value>
        public double BracketASpacing { get; set; }

        /// <value>
        /// Distance between the lower edge of the waler and middle Z-bracket (mm)
        /// </value>
        public double BracketBSpacing { get; set; }

        /// <value>
        /// Distance between the lower edge of the waler and end Z-bracket (mm)
        /// </value>
        public double EndBracketSpacing { get; set; }

        /// <value>
        /// Standard of bolts on the Z-bracket
        /// </value>
        public string BracketBoltStandard { get; set; }

        /// <value>
        /// Diameter of bolts on the Z-bracket (mm)
        /// </value>
        public double BracketBoltDiameter { get; set; }

        /// <summary>
        /// Diameter of Hole on the Z-Bracket (mm)
        /// </summary>
        public double BracketHoleDiameter { get; set; }

        /// <value>
        /// Diameter of bolts on Z-brackets positioned at vertical splits (mm)
        /// </value>
        public double BracketSplitBoltDiameter { get; set; }

        // Others
        /// <value>
        /// Welding offset to include for all beam connections (mm)
        /// </value>
        public double WeldOffset { get; set; }

        /// <value>
        /// Overall height of the billboard structural beam frame (mm)
        /// </value>
        public double BillboardHeight { get; set; }

        /// <value>
        /// Overall length of the billboard structural beam frame (mm)
        /// </value>
        public double BillboardLength { get; set; }

        /// <value>
        /// Overall depth of the billboard structural beam frame (mm)
        /// </value>
        public double BillboardDepth { get; set; }

        /// <value>
        /// Overall length of the billboard screen (mm)
        /// </value>
        public double ScreenLength { get; set; }

        /// <value>
        /// Overall height of the billboard screen (mm)
        /// </value>
        public double ScreenHeight { get; set; }

        /// <value>
        /// Density of the screen cabinet
        /// </value>
        public double ScreenDensity { get; set; }

        /// <value>
        /// The Gap between box splits
        /// </value>
        public double BoxGap { get; set; }

        // Galvanizing Bath Dimensions
        /// <value>
        /// Length of the selected galvanising bath (mm)
        /// </value>
        public double GalBathLength { get; set; }

        /// <value>
        /// Height of the selected galvanising bath (mm)
        /// </value>
        public double GalBathHeight { get; set; }

        /// <value>
        /// Width of the selected galvanising bath (mm)
        /// </value>
        public double GalBathWidth { get; set; }

        // Camera arm

        /// <value>
        /// Horizontal position of the camera arm, distance from the left side of the billboard (mm)
        /// </value>
        public double ArmOffset { get; set; }

        /// <value>
        /// Length of the camera arm (mm)
        /// </value>
        public double SetArmLength { get; set; }

        /// <value>
        /// Whether the camera arm is positioned on the top or bottom, true if top
        /// </value>
        public bool ArmAtTop { get; set; }

        /// <value>
        /// Whether a camera arm is included or not, true if no arm
        /// </value>
        public bool NoArm { get; set; }

        /// <value>
        /// Length of the vertical arm support member (mm)
        /// </value>
        public double VertArmLength { get; set; }

        /// <value>
        /// Angle between vertical and arm members (degrees)
        /// </value>
        public double ArmAngle { get; set; }

        // Camera arm/plate items
        /// <value>
        /// The material of the camera arm support plates
        /// </value>
        public string CamPlateMaterial { get; set; }

        /// <value>
        /// The profile of the camera arm support plates
        /// </value>
        public string CamPlateProfile { get; set; }

        // Lifting points
        /// <value>
        /// List of x coordinates to insert lifting points along the top B1 member (mm)
        /// </value>
        public List<double> LiftPointsTopX { get; set; }

        /// <value>
        /// List of x coordinates to insert lifting points along the bottom B1 member (mm)
        /// </value>
        public List<double> LiftPointsBottomX { get; set; }

        /// <value>
        /// Width of the lifting point plate (mm)
        /// </value>
        public double LugPlateWidth { get; set; }

        /// <value>
        /// Standard of lifting point bolts (placeholder for eye bolts)
        /// </value>
        public string LiftBoltStandard { get; set; }

        // Cladding
        /// <value>
        /// Type of cladding material
        /// </value>
        public List<CladdingType> CladdingTypes { get; set; }

        /// <value>
        /// Length of a single cladding sheet (mm)
        /// </value>
        public List<double> CladdingLengths { get; set; }

        /// <value>
        /// Width of a single cladding sheet (mm)
        /// </value>
        public List<double> CladdingWidths { get; set; }

        /// <value>
        /// Overlap between adjacent cladding sheets (mm)
        /// </value>
        public List<double> CladdingOverlaps { get; set; }

        /// <value>
        /// User input, indicates offset from top of billboard
        /// </value>
        public List<double> TopCladdingOffsets { get; set; }

        /// <value>
        /// Width covered by a single cladding sheet, discounting overlap (mm)
        /// </value>
        public List<double> EffectiveCoverWidths { get; set; }

        /// <value>
        /// Thickness of cladding sheet (mm)
        /// </value>
        public List<double> CladdingThicknesses { get; set; }

        /// <value>
        /// Colour of cladding sheet
        /// </value>
        public List<Colour> CladdingColours { get; set; }

        /// <value>
        /// Only applicable for perforated sheets
        /// </value>
        public List<double> CladdingPercentsOpenArea { get; set; }

        public int CladIndex { get; set; }

        /// <value>
        /// Whether flashing is placed on the billboard
        /// </value>
        public bool FlashingEnabled { get; set; }

        /// <value>
        /// Colour of flashing
        /// </value>
        public Colour FlashingColour { get; set; }

        /// <value>
        /// Thickness of flashing (mm)
        /// </value>
        public double FlashingThickness { get; set; }

        /// <value>
        /// Values of all flashing dimensions (mm).
        /// </value>
        public double[] FlashingDimensions { get; set; }

        /// <value>
        /// Whether to insert gal holes.
        /// </value>
        public bool NoGalHole { get; set; }

        /// <value>
        /// Whether to automatically size gal holes.
        /// </value>
        public bool IsAutoGalHoleSize { get; set; }
        /// <value>
        /// Distance of the galvanizing hole from the edge .
        /// </value>
        public double GalHoleOffset1 { get; set; }

        /// <value>
        /// Distance of the galvanizing hole from the inside thickness.
        /// </value>
        public double GalHoleOffset2 { get; set; }

        /// <value>
        /// Distance of the galvanizing hole from the edge .
        /// </value>
        public Dictionary<string, double> GalHoleSizes { get; set; }

        /// <value>
        /// Gal hole size
        /// </value>
        public double GalHoleSize { get; set; }

        /// <value>
        /// Indicates the height of the Fascia box
        /// </value>
        public double FasciaBoxHeight { get; set; }

        /// <value>
        /// Indicates if a fascia box is to be included, true if Fascia box to be added
        /// </value>
        public bool FasciaEnabled { get; set; }

        /// <value>
        /// Indicates if the Fascia box is 2D or 3D, true if 2D
        /// </value>
        public bool isTwoD { get; set; }

        /// <value>
        /// Indicates if the ladder is left(0), right(1) or none(2).
        /// </value>
        public int LadderMode { get; set; }

        /// <value>
        /// From front view, indicate the Ladder offset from back beam.
        /// </value>
        public double LadderOffsetBack { get; set; }

        /// <value>
        /// From front view, indicate the Ladder offset from either left or right side beam depend on user input.
        /// </value>
        public double LadderOffsetSide { get; set; }

        /// <value>
        /// Indicates the ladder rung's diameter.
        /// </value>
        public double LadderRungDiameter { get; set; }

        /// <value>
        /// Indicates the ladder rung's material.
        /// </value>
        public string LadderRungMaterial { get; set; }

        /// <value>
        /// Indicates the ladder Rail's Width.
        /// </value>
        public double LadderRailWidth { get; set; }

        /// <value>
        /// Indicates the ladder Rail's Length.
        /// </value>
        public double LadderRailLength{ get; set; }

        /// <value>
        /// Indicates the ladder Rail's material.
        /// </value>
        public string LadderRailMaterial { get; set; }

        /// <value>
        /// Indicates the ladder connection plate's thickness.
        /// </value>
        public double LadderPlateThickness { get; set; }

        /// <value>
        /// Indicates the ladder connection plate's diameter.
        /// </value>
        public string LadderPlateMaterial { get; set; }

        /// <value>
        /// Indicates the ladder connection plate's profile.
        /// </value>
        public string LadderPlateProfile { get; set; }

        /// <value>
        /// Indicates the ladder rail's profile.
        /// </value>
        public string LadderRailProfile { get; set; }

        /// <value>
        /// Indicates the ladder Rung's profile.
        /// </value>
        public string LadderRungProfile { get; set; }

        /// <value>
        /// Indicates the ladder rung's spacing.
        /// </value>
        public double LadderPlateHeight { get; set; }

        /// <value>
        /// Indicates the ladder overall length.
        /// </value>
        public double LadderWidth { get; set; }

        /// <value>
        /// Indicates the ladder rung's spacing.
        /// </value>
        public double LadderRungSpacing { get; set; }

        /// <value>
        /// Indicates the door frame material
        /// </value>
        public string DoorFrameMaterial{ get; set; }

        /// <value>
        /// Indicates the door frame profile
        /// </value>
        public string DoorFrameProfile { get; set; }

        /// <value>
        /// Indicates the door frame beam width
        /// </value>
        public double DoorFrameWidth { get; set; }

        /// <value>
        /// Indicates the door frame beam height
        /// </value>
        public double DoorFrameHeight { get; set; }

        /// <value>
        /// Indicates the door panel material
        /// </value>
        public string DoorPanelMaterial { get; set; }

        /// <value>
        /// Indicates the door panel profile
        /// </value>
        public string DoorPanelProfile { get; set; }

        /// <value>
        /// Indicates the door frame material
        /// </value>
        public double DoorPanelWidth { get; set; }

        /// <value>
        /// Indicates the door frame profile
        /// </value>
        public double DoorPanelHeight { get; set; }

        /// <value>
        /// Indicates the door offset from left front view
        /// </value>
        public double DoorOffsetLeft { get; set; }

        /// <value>
        /// Indicates the door width
        /// </value>
        public double DoorWidth { get; set; }

        /// <value>
        /// Indicates the distance between panel and frame
        /// </value>
        public double DoorPanelFrameSpacing { get; set; }

        /// <value>
        /// Indicates the door minmum height
        /// </value>
        public double DoorHeight { get; set; }
        /// <bool>
        /// Indicates the door minmum height
        /// </bool>
        public bool DoorON { get; set; }

        /// <summary>
        /// THe width of the hatch.
        /// </summary>
        public double HatchWidth { get; set; }

        /// <value>
        /// Indicate if back bracing feature is enabled 
        /// </value>
        public bool EnableBackBracing { get; set; }

        /// <value>
        /// Indicate if Circular BillBoard feature is enabled 
        /// </value>
        public bool IsCircularBill { get; set; }

        /// <value>
        /// The Radius of the BillBoard 
        /// </value>
        public double Radius { get; set; }

        /// <value>
        /// The trimmer distance value. It is between 900 and 1200
        /// </value>
        public double TrimmerDistance { get; set; }

        /// <value>
        /// The distance between the front face and the back face of the BillBoard
        /// </value>
        public double Distance { get; set; }

        /// <summary>
        /// Initialises default values for the billboard model.
        /// </summary>
        public ModelParameters()
        {
            // Initial coordinate 0
            XCoordinates = new List<double>() { 0 };
            ZCoordinates = new List<double>() { 0 };

            // Walers
            UpperWalerSpacing = 350;
            LowerWalerSpacing = 350;
            WalersCoordinates = new List<double>();
            WalersNumber = 0;
            WalerAuto = true;

            // Railings & Horizontal Back Beams
            RailingSpace1 = 450;
            RailingSpace2 = 550;
            RailingCoordinates = new List<double> { RailingSpace1, RailingSpace2 };
            AutoSpacing = true;

            // Cabinets
            BoltSize = 10;
            BoltOffsetDz = 60;
            BoltOffsetDx = 65;
            HeightOffsetTop = 8;
            HeightOffsetBottom = 8;

            // Walkways
            MeshThickness = 14;
            WalkwayWidth = 750;
            WalkwayClearance = 15;
            EASupportClearance = 75;
            WalkwayList = new List<double>() { };

            // Diagonals
            DiagonalTopOffset = 0;
            DiagonalBottomOffset = 0;
            CornerOffset = 10;

            // Seating plates
            SeatingPlateOffset = 10;
            SeatingPlateExtrusionLength = 75;
            BuildSeatingPlate = true;

            // Z Brackets
            BracketASpacing = 10;
            BracketBSpacing = 20;
            EndBracketSpacing = 10;
            BracketBoltStandard = "8.8S";
            BracketBoltDiameter = 12.0;
            BracketSplitBoltDiameter = 6.0;
            ZBracketSpacerThickness = 0;
            ZBracketSpacer = true;

            // Others
            WeldOffset = 1;
            BillboardHeight = 0;
            BillboardLength = 0;
            ScreenLength = 0;
            BoxGap = 1;
            EASplitBoltOffset = 100;

            // Galvanizing Bath Dimensions
            GalBathLength = 13500;
            GalBathHeight = 1850;
            GalBathWidth = 2700;

            // Plane Splits list of indices of XCoordinates and ZCoordinates
            XSplits = new List<int>() { };
            ZSplits = new List<int>() { };

            // Camera arm
            ArmOffset = 0;
            SetArmLength = 1000;
            ArmAtTop = true;
            VertArmLength = 200;
            ArmAngle = 6 * Math.PI/180;
            NoArm = false;

            // Lift Points
            LiftPointsTopX = new List<double>();
            LiftPointsBottomX = new List<double>();
            LiftBoltStandard = "UNDEFINED_STUD";
            LugPlateWidth = 75;

            // Cladding
            CladIndex = 0;
            CladdingTypes = new List<CladdingType>() { };
            CladdingLengths = new List<double>() { };
            CladdingWidths = new List<double>() { };
            CladdingOverlaps = new List<double>() { };
            EffectiveCoverWidths = new List<double>() { };
            CladdingThicknesses = new List<double>() { };
            CladdingPercentsOpenArea = new List<double>() { };
            CladdingColours = new List<Colour>();
            TopCladdingOffsets = new List<double>();
            for (int i = 0; i < 5; i++)
            {
                CladdingTypes.Add(CladdingType.None);
                CladdingLengths.Add(0);
                CladdingWidths.Add(0);
                CladdingOverlaps.Add(0);
                EffectiveCoverWidths.Add(0);
                CladdingThicknesses.Add(0);
                CladdingColours.Add(Colour.Monument);
                CladdingPercentsOpenArea.Add(0); ;
                TopCladdingOffsets.Add(0);
            }
            
            // Flashing
            FlashingEnabled = false;
            FlashingColour = Colour.Monument;
            FlashingThickness = 10;
            FlashingDimensions = new double[19];

            // Gal Holes
            GalHoleOffset1 = 20;
            GalHoleOffset2 = 20;
            GalHoleSize = 14;
            NoGalHole = false;
            IsAutoGalHoleSize = false;
            DefaultGalHoleSizes();

            // Fascia Box
            FasciaBoxHeight = 0;
            FasciaEnabled = false;
            isTwoD = true;

            // Material
            LEDMaterial = "digital1.0";
            C1Material = "C350L0";
            B1Material = "C350L0";
            B2Material = "C350L0";
            B3Material = "C350L0";
            B5Material = "C350L0";
            BR1Material = "C350L0";
            SeatingPlateMaterial = "250";
            WalerMaterial = "C350L0";
            EAMaterial = "C350L0";
            BracketMaterial = "250";
            MeshMaterial = "FM14";
            CamPlateMaterial = "250";
            LugPlateMaterial = "250";
            HatchBeamMaterial = "C350L0";

            B1SplitMaterial = B1Material;
            B2SplitMaterial = B2Material;
            C1SplitMaterial = C1Material;
            B5SplitMaterial = B5Material;

            LadderRungMaterial = "C350L0";
            LadderRailMaterial = "C350L0";
            LadderPlateMaterial = "C350L0";

            DoorFrameMaterial = "C350L0";
            DoorPanelMaterial = "C350L0";

            // Profile
            LEDProfile = "PLT170";
            C1Profile = "RHS75*50*4.0";
            B1Profile = "SHS75*75*4.0";
            B2Profile = "RHS75*50*4.0";
            B3Profile = "SHS50*50*3.0";
            B5Profile = "SHS65*65*4.0";
            BR1Profile = "SHS50*50*3.0";
            SeatingPlateProfile = "FL8";
            WalerProfile = "SHS75*75*4.0";
            EAProfile = "EA50*50*5";
            ZBracketProfile = "PLT12*75";
            ZBracketSpacerProfile = "PLT" + ZBracketSpacerThickness.ToString() + "75";
             
            CamPlateProfile = "PLT10";
            LugPlateProfile = "PLT10";

            HatchBeamProfile = "RHS50*30*4.0";

            C1SplitProfile = "RHS75*25*2.5";
            B2SplitProfile = "RHS75*25*2.5";
            B5SplitProfile = "RHS65*35*4.0";
            B1SplitProfile = "RHS75*25*2.5";

            LadderPlateProfile = "PLT10";
            LadderRungProfile = "D20";
            LadderRailProfile = "FL65*12";

            DoorFrameProfile = "SHS75*75*3.0";
            DoorPanelProfile = "SHS25*25*3.0";

            //Ladder
            LadderMode = 2;
            LadderOffsetBack = 165;
            LadderOffsetSide = 165;
            LadderRungDiameter = 20; 
            LadderRailLength = 65; 
            LadderRailWidth = 12; 
            LadderPlateThickness = 10; 
            LadderWidth = 450;
            LadderRungSpacing = 280;
            LadderPlateHeight = 50;

            //Door
            DoorFrameHeight = 75;
            DoorFrameWidth = 75;
            DoorPanelHeight = 25;
            DoorPanelWidth = 25;
            DoorOffsetLeft = 0;
            DoorHeight = 1900;
            DoorWidth = 650;
            DoorPanelFrameSpacing = 10;
            DoorON = false;

            // Back bracing
            EnableBackBracing = true;

            // Circluar BillBoard
            IsCircularBill = false;
            Radius = 0;
            TrimmerDistance = 1200;
            Distance = 770 - 75 - 75; // Total Distance = The Require distance - 2* C1BeamWidth
        }

        /// <summary>
        /// Validates the model can be built based on current model parameters.
        /// </summary>
        /// <returns> True if all user inputs are valid, False otherwise </returns>
        public bool ValidateInputs()
        {
            string message = "";
            if (XCoordinates.Count == 1 || ZCoordinates.Count == 1) { message += "There needs to be at least 1 LED Cabinet\n"; }
            
            if (!(IsValid(BoltOffsetDz) && IsValid(BoltOffsetDx))) { message += "Bolt offsets must be greater than 0\n"; }
            
            if (!IsValid(BoltSize)) { message += "Invalid Bolt Size\n"; }
            
            if (!(IsValid(RailingSpace1) && IsValid(RailingSpace2))) { message += "Upper/Lower railing spacing must be greater than 0\n"; }
            
            if (!(IsValid(DiagonalTopOffset) && IsValid(DiagonalBottomOffset) && IsValid(CornerOffset))) { message += "Diagonals offset cannot be smaller than 0\n"; }
            
            if (!(IsValid(HeightOffsetTop) && IsValid(HeightOffsetBottom))) { message += "Invalid Screen Gap\n"; }
            
            if (!IsValid(MeshThickness)) { message += "Invalid Walkway Thickness\n"; }
            
            if (!IsValid(WeldOffset)) { message += "Invalid Welding offset\n"; }
            
            if (!IsValid(SeatingPlateOffset) && BuildSeatingPlate) { message += "Invalid Seating Plate offset\n"; }
            
            if (!IsValid(SeatingPlateExtrusionLength) && BuildSeatingPlate) { message += "Invalid Seating Plate extrusion length\n"; }

            if (!IsValid(EASupportClearance)){ message += "Walkway EA bracket cannot be smaller than 0\n"; }
            
            if (!IsValid(WalkwayClearance)) { message += "Invalid walkway offset\n"; }
            
            if (!IsValid(WalkwayWidth)) { message += "Invalid walkway width\n"; }

            double totalRailingHeight = 0;
            foreach (var item in RailingCoordinates) { totalRailingHeight += item; }

            double totalWalerHeight = 0;
            foreach (var item in WalersCoordinates) { totalWalerHeight += item; }

            if (!(IsValid(UpperWalerSpacing) && IsValid(LowerWalerSpacing))) { message += "Upper/Lower waler spacings must be greater than 0\n"; }
            
            if (!WalerAuto && UpperWalerSpacing + totalWalerHeight + LowerWalerSpacing > BillboardHeight) { message += "Waler must be within the billboard height\n"; }
            
            if (AutoSpacing)
            {
                // Check if height can include the two railings
                if ((RailingSpace1 + RailingSpace2) > BillboardHeight) { message += "Not enough height to accomodate railings\n"; }
            }
            else
            {
                // Check if height can include the two railings
                if (totalRailingHeight > BillboardHeight) { message += "Not enough height to accomodate railings\n"; }
            }
            
            if (!(IsValid(BracketASpacing) && IsValid(BracketBSpacing))) { message += "Invalid middle bracket spacing\n"; }
            
            if (!IsValid(EndBracketSpacing)) { message += "Invalid middle bracket spacing\n"; }
            
            if (!IsValid(BracketBoltDiameter)) { message += "Invalid bracket bolt diameter\n"; }
            
            // Profile validation
            if (!RegexValidateProfile(C1Profile)) { message += "Invalid C1 profile\n"; }
            if (!RegexValidateProfile(B1Profile)) { message += "Invalid B1 profile\n"; }
            if (!RegexValidateProfile(B2Profile)) { message += "Invalid B2 profile\n"; }
            if (!RegexValidateProfile(B3Profile)) { message += "Invalid B3 profile\n"; }
            if (!RegexValidateProfile(B5Profile)) { message += "Invalid B5 profile\n"; }
            if (!RegexValidateProfile(BR1Profile)) { message += "Invalid BR1 profile\n"; }
            if (!RegexValidateProfile(WalerProfile)) { message += "Invalid Waler profile\n"; }
            if (!Regex.IsMatch(LEDProfile, @"^PLT\d+(?:\.\d+)?$")) { message += "Invalid LED profile\n"; }
            if (!Regex.IsMatch(SeatingPlateProfile, @"^(FL)\d+(?:\.\d+)?$")) { message += "Invalid Plate profile\n"; }
            
            if (!RegexValidateProfile(EAProfile)) { message += "Invalid EA profile\n"; }
            else
            {
                // Remove first three characters in string and split string into an array from * points 
                string[] dimensions = EAProfile.Substring(2).Split('*');

                // Convert the first. second and third string to a double that represents the depth and width of the beam 
                double beamDepth = Convert.ToDouble(dimensions[0]);
                double beamWidth = Convert.ToDouble(dimensions[1]);

                if (Math.Abs(beamDepth - beamWidth) > Double.Epsilon) { message += "Equal Angled beam must have the same depth and width\n"; }
            }

            if (!Regex.IsMatch(ZBracketProfile, @"^PLT\d{1,}(?:\.\d{1,})?(\*)?(?(1)\d{1,}(?:\.\d{1,})?$|$)")) { message += "Invalid plate profile\n"; }
            
            if (ZBracketSpacer && ZBracketSpacerThickness <= 0) { message += "Invalid Z bracket spacer plate thickness. (positive number only)\n"; }

            if (!NoArm && !IsValid(ArmOffset)) { message += "Arm offset must lie within the billboard.\n"; }

            if(!NoArm && !IsValid(SetArmLength)) { message += "Arm length must be greater than 100mm.\n"; }

            if(!NoArm && !IsValid(VertArmLength)) { message += "Vertical arm length must be greater than 100mm.\n"; }

            if(!NoArm && !IsValid(ArmAngle)) { message += "Arm angle must be between 0 and 30 degrees.\n"; }

            //if (LadderOffsetBack > 250 || LadderOffsetBack < 0) { message += "Ladder offset from back must be between 0 and 250\n"; }

            //if (LadderOffsetSide > 250 || LadderOffsetBack < 0) { message += "Ladder offset from side must be between 0 and 250\n"; }

            //if (LadderOffsetBack > 250) { message += "Ladder offset from back must be between 0 and 250\n"; }

            //if (LadderOffsetSide > 250) { message += "Ladder offset from side must be between 0 and 250\n"; }

            for (int j = 0; j < 5; j++)
            {
                if (CladdingTypes[j] != CladdingType.ACM && CladdingTypes[j] != CladdingType.PerfSheet && CladdingTypes[j] != CladdingType.None && !IsValid(CladdingLengths[j])) { message += "Invalid cladding length\n"; }

                if (CladdingTypes[j] == CladdingType.ACM && !IsValid(CladdingLengths[j])) { message += "Please select an ACM cladding sheet size\n"; }

                if (CladdingTypes[j] == CladdingType.PerfSheet && !IsValid(CladdingThicknesses[j])) { message += "Invalid cladding thickness\n"; }

                if (CladdingTypes[j] == CladdingType.PerfSheet && !IsValid(CladdingPercentsOpenArea[j])) { message += "Invalid open area percentage\n"; }
            }

            if (FlashingEnabled && !IsValid(FlashingThickness)) { message += "Invalid flashing thickness\n"; }

            if (FasciaEnabled && !IsValid(FasciaBoxHeight)) { message += "Invalid fascia box height.\n"; }

            bool validFlashingDim = true;
            foreach (double x in FlashingDimensions) { validFlashingDim = validFlashingDim && IsValid(x); }

            if (FlashingEnabled && !validFlashingDim) { message += "Invalid flashing profile dimensions.\n"; }

            if (!IsAutoGalHoleSize && !NoGalHole)
            {
                if (!IsValid(GalHoleSize))
                {
                    message += "Invalid gal hole dimensions\n";
                }
                else
                {
                    foreach (string key in new List<string>(GalHoleSizes.Keys)) { GalHoleSizes[key] = GalHoleSize; }
                }
            }
            else if (IsAutoGalHoleSize && !NoGalHole)
            {
                DefaultGalHoleSizes();
            }

            if (!NoGalHole && !(IsValid(GalHoleOffset1) && IsValid(GalHoleOffset2))) { message += "Invalid gal hole offsets\n"; }
            if (!(RegexValidateProfile_SHS(DoorFrameProfile) || RegexValidateProfile_RHS(DoorFrameProfile))) { message += "Invalid Door Frame Profile\n"; }
            if (!(RegexValidateProfile_RHS(DoorPanelProfile) || RegexValidateProfile_SHS(DoorPanelProfile))) { message += "Invalid Door Panel Profile\n"; }
            if (!RegexValidateProfile_D(LadderRungProfile)) { message += "Invalid Ladder Rung Profile\n"; }
            if (!RegexValidateProfile_FL(LadderRailProfile)) { message += "Invalid Ladder Side Rail Profile\n"; }
            if (!RegexValidateProfile_PLT(LadderPlateProfile)) { message += "Invalid Ladder Plate Profile\n"; }




            // Hatch
            if (LadderMode != 2 && !IsValid(HatchWidth))
            {
                message += "Invalid hatch width value. \n";
            }else if (LadderMode != 2 && HatchWidth < LadderOffsetSide + 447) // Ladder width is fixed with 447 mm.
            {
                message += "The hatch is too narrow to fit the ladder.\n";
            }

            if (LadderMode != 2)
            {
                if (XSplits.Count > 0)
                {
                    //List<double> test = XCoordinates.GetRange(0, XSplits[0] + 1);
                    //double testsum = test.Sum();
                    //List<double> test2 = XCoordinates.GetRange(XSplits[XSplits.Count - 1] + 1, XCoordinates.Count - XSplits[XSplits.Count - 1] - 1);
                    if (LadderMode == 0 && HatchWidth >= XCoordinates.GetRange(0, XSplits[0] + 1).Sum())
                    {
                        message += "The hatch is too wide, exceeding the box length. \n";
                    }
                    else if (LadderMode == 1 && HatchWidth >= XCoordinates.GetRange(XSplits[XSplits.Count - 1] + 1, XCoordinates.Count - XSplits[XSplits.Count - 1] - 1).Sum())
                    {
                        message += "The hatch is too wide, exceeding the box length. \n";
                    }
                } else if (HatchWidth >= XCoordinates.Sum())
                {
                    message += "The hatch is too wide, exceeding the box length. \n";
                }
            }

            if (!RegexValidateProfile(HatchBeamProfile))
            {
                message += "Invalid hatch beam profile.\n";
            }


            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message.Remove(message.Length-1, 1));
                return false;
            }
            

            if (!ArmAtTop && !NoArm && VertArmLength < FasciaBoxHeight) { MessageBox.Show("Warning: Vertical camera arm length may be insufficient."); }
            


            return true;
        }

        /// <summary>
        /// Validates that a profile string matches the correct format.
        /// </summary>
        /// <param name="text">The input string.</param>
        /// <returns>True if text is a valid profile string.</returns>
        public static bool RegexValidateProfile(string text)
        {
            return Regex.IsMatch(text, @"^[SR]{1}HS\d{2,3}\*\d{2,3}\*\d{1,2}\.\d{1}$") || Regex.IsMatch(text, @"^EA\d{2,3}\*\d{2,3}\*\d{1,2}$");
        }
        public static bool RegexValidateProfile_SHS(string text)
        {
            return Regex.IsMatch(text, @"^SHS(\d{1,3})\*\1\*\d{1,2}\.\d{1}$");
        }

        public static bool RegexValidateProfile_RHS(string text)
        {
            return Regex.IsMatch(text, @"^RHS\d{1,3}\*\d{1,3}\*\d{1,2}\.\d{1}$");
        }
        public static bool RegexValidateProfile_D(string text)
        {
            return Regex.IsMatch(text, @"^D\d{1,3}$");
        }
        public static bool RegexValidateProfile_PLT(string text)
        {
            return Regex.IsMatch(text, @"^PLT\d{1,3}$");
        }
        public static bool RegexValidateProfile_FL(string text)
        {
            return Regex.IsMatch(text, @"^FL\d{1,3}\*\d{1,3}$");
        }

        /// <summary>
        /// Converts a beam profile string into dimensions. 
        /// </summary>
        /// <param name="dimensionString">A beam profile string.</param>
        /// <returns>Array of beam dimensions in the order of [depth, width, thickness]</returns>
        public static double[] BeamDimensions(string dimensionString)
        {
            string[] FinalDimensions;
            if (dimensionString.Contains("EA"))
            {
                // Remove first Two characters in string and split string into an array from * points 
                FinalDimensions = dimensionString.Substring(2).Split('*');

                // Convert the first. second and third string to a double that represents the depth, width and thickness of the beam 
                double beamDepth = Convert.ToDouble(FinalDimensions[0]);
                double beamWidth = Convert.ToDouble(FinalDimensions[1]);
                double beamThicccness = Convert.ToDouble(FinalDimensions[2]);
                return new double[] { beamDepth, beamWidth, beamThicccness };
            }
            else if (dimensionString.Contains("PLT"))
            {
                // Remove first three characters in string and split string into an array from * points 
                FinalDimensions = dimensionString.Substring(3).Split('*');

                // Convert the first. second and third string to a double that represents the depth, width and thickness of the beam 
                double beamThickness = Convert.ToDouble(FinalDimensions[0]);

                if (FinalDimensions.Length == 2)
                {
                    double beamWidth = Convert.ToDouble(FinalDimensions[1]);
                    return new double[] { beamThickness, beamWidth };
                }
                return new double[] { beamThickness };
            }
            else if (dimensionString.Contains("UA"))
            {
                // Remove first Two characters in string and split string into an array from * points 
                FinalDimensions = dimensionString.Substring(2).Split('*');

                // Convert the first. second and third string to a double that represents the depth, width and thickness of the beam 
                double beamDepth = Convert.ToDouble(FinalDimensions[0]);
                double beamWidth = Convert.ToDouble(FinalDimensions[1]);
                double beamThicccness = Convert.ToDouble(FinalDimensions[2]);
                return new double[] { beamDepth, beamWidth, beamThicccness };
            }
            else if (dimensionString.Contains("D"))
            {
                FinalDimensions = dimensionString.Substring(1).Split('D');
                double beamdiameter = Convert.ToDouble(FinalDimensions[0]);
                return new double[] { beamdiameter};
            }
            else if (dimensionString.Contains("FL")) 
            {
                FinalDimensions = dimensionString.Substring(2).Split('*');
                double beamheight = Convert.ToDouble(FinalDimensions[0]);
                double beamwidth = Convert.ToDouble(FinalDimensions[1]);
                return new[] { beamheight, beamwidth };
            }
            else
            {
                // Remove first three characters in string and split string into an array from * points 
                FinalDimensions = dimensionString.Substring(3).Split('*');

                // Convert the first. second and third string to a double that represents the depth, width and thickness of the beam 
                double beamDepth = Convert.ToDouble(FinalDimensions[0]);
                double beamWidth = Convert.ToDouble(FinalDimensions[1]);
                double beamThicccness = Convert.ToDouble(FinalDimensions[2]);
                return new double[] { beamDepth, beamWidth, beamThicccness };
            }
        }

        private void DefaultGalHoleSizes()
        {
            GalHoleSizes = new Dictionary<string, double>();

            // SHS sizes
            GalHoleSizes.Add("SHS20*20", 10);
            GalHoleSizes.Add("SHS25*25", 10);
            GalHoleSizes.Add("SHS30*30", 10);
            GalHoleSizes.Add("SHS35*35", 10);
            GalHoleSizes.Add("SHS40*40", 10);
            GalHoleSizes.Add("SHS50*50", 13);
            GalHoleSizes.Add("SHS65*65", 16);
            GalHoleSizes.Add("SHS75*75", 19);
            GalHoleSizes.Add("SHS89*89", 22);
            GalHoleSizes.Add("SHS90*90", 25);
            GalHoleSizes.Add("SHS100*100", 25);
            GalHoleSizes.Add("SHS125*125", 35);
            GalHoleSizes.Add("SHS150*150", 40);
            GalHoleSizes.Add("SHS200*200", 50);
            GalHoleSizes.Add("SHS250*250", 65);
            GalHoleSizes.Add("SHS300*300", 75);
            GalHoleSizes.Add("SHS350*350", 90);
            GalHoleSizes.Add("SHS400*400", 100);

            // RHS sizes
            GalHoleSizes.Add("RHS50*25", 10);
            GalHoleSizes.Add("RHS65*35", 13);
            GalHoleSizes.Add("RHS75*25", 14);
            GalHoleSizes.Add("RHS75*50", 16);
            GalHoleSizes.Add("RHS100*50", 20);
            GalHoleSizes.Add("RHS125*75", 30);
            GalHoleSizes.Add("RHS150*50", 30);
            GalHoleSizes.Add("RHS150*100", 35);
            GalHoleSizes.Add("RHS200*100", 40);
            GalHoleSizes.Add("RHS250*150", 55);
            GalHoleSizes.Add("RHS300*200", 65);
            GalHoleSizes.Add("RHS350*250", 80);
            GalHoleSizes.Add("RHS400*200", 80);
            GalHoleSizes.Add("RHS400*300", 90);
        }

        /// <summary>
        /// Converts an input value to a string.
        /// </summary>
        /// <param name="x">The input parameter.</param>
        /// <returns>The value as a string if valid, else an empty string.</returns>
        public static string DimToString(double x) { return IsValid(x) ? $"{x}" : ""; }

        /// <summary>
        /// Checks if x is not InvalidValue, the value which represents that input into the UI was invalid.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsValid(double x) { return Math.Abs(x - InvalidValue) > Double.Epsilon; }
    }
}