using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Class to support modelling of Z-brackets on Tekla Structures.
    /// </summary>
    public class ZBracket
    {

        /// <summary>
        /// Populates the billboard model with Z-brackets at given z-coordinates.
        /// </summary>
        /// <param name="planes"> List of frames sorted by x-coordinates to insert the Z-brackets behind </param>
        /// <param name="zCoordinatesForZBrackets"> List of z-coordinates to insert the Z-brackets along (mm) </param>
        /// <param name="modelParameters"> The model's data store </param>
        /// TODO Description for return
        public static List<Part> ZBrackets
            (
                List<double> xSubCoordinates,
                TSG.Point OriginOffset,
                List<Frame> planes,
                List<double> zCoordinatesForZBrackets,
                ModelParameters modelParameters
            )
        {
            List<Part> ZBrackets = new List<Part>();
            List<Part> Bolts = new List<Part>();

            double C1BeamWidth = modelParameters.C1BeamWidth;
            double WalerBeamDepth = modelParameters.WalerBeamDepth;
            double WalerBeamWidth = modelParameters.WalerBeamWidth;
            double ZBracketWidth = modelParameters.ZBracketWidth;
            double BillboardDepth = modelParameters.BillboardDepth;

            List<double> XCoordinates = xSubCoordinates;

            TSG.Point plateSplitOffset = new TSG.Point();
            TSG.Point boltSplitOffset = new TSG.Point();

            // THIS CODE IS FOR THE Z BRACKETS // 
            //              P1
            //              |
            //    Plate 1   |
            //              |
            //           P2 |___________P3
            //                 Plate2   |
            //                          |
            //                          | Plate 3
            //                          |
            //                       P4 \
            //                           \
            //                            \
            //                             \  Plate 4
            //                              P5

            // Insert code for side bracings here //

            // Initialise the x-direction and z-direction spacing for the z-brackets
            double xZBracketSpacing = 0;
            double zZBracketSpacing = 0;

            // Initialise the variables
            // The angle for the extended part of the bracket on the edges of the billboard 
            double angleInDegrees = 45;

            // Converting the angle to radians 
            double angleInRadians = angleInDegrees * (Math.PI / 180);

            // Outer edges bracket plate 4 length 
            double plate4Length = 150; //TODO Maybe user input

            // Finding the y and z components of the length of Plate 4.
            double plate4Y = plate4Length * Math.Cos(angleInRadians);
            double plate4Z = plate4Length * Math.Sin(angleInRadians);

            // Initialise dimensions for all four plates of z bracket
            // double zBracketYOffset = 0.5 zBracketThickness;
            //double  zBracketZOffset =

            // For plate 1:
            double topEdgeToUpperBolt = 30; //TODO Maybe user input
            double spacingBetweenBolts = 100; //TODO user input
            double lowerBoltToTopWaler = 50; // TODO user input

            //Internal Bracket offsets (a and b in the clients documents)   
            double offsetToWalerFaceSides = modelParameters.EndBracketSpacing;
            double offsetToWalerFaceInner = modelParameters.BracketASpacing;
            double offsetToWalerBottom = modelParameters.BracketBSpacing;

            // Loop through the x-coordinates
            for (int indexXcoordinates = 0; indexXcoordinates <= (XCoordinates.Count - 1); indexXcoordinates++)
            {
                // Update the x-spacing (the first value in the XCoordinates list is 0)
                xZBracketSpacing += XCoordinates[indexXcoordinates];

                // Loop through the z-coordinates of the walers (i.e. the z spacings of the brackets)
                for (int indexZcoordinates = 0; indexZcoordinates <= (zCoordinatesForZBrackets.Count - 1); indexZcoordinates++)
                {
                    // Update the z-spacing 
                    zZBracketSpacing = zCoordinatesForZBrackets[indexZcoordinates];

                    // Check if we are in the first x-coordinate (because these have modified z brackets and different alignment)
                    if (planes[indexXcoordinates].PlaneType == 1)
                    {
                        // Build the extended z-brackets
                        List<ContourPoint> contourPoints = new List<ContourPoint>()
                         {
                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth - C1BeamWidth / 2, 
                                 BillboardDepth + modelParameters.ZBracketSpacerThickness, 
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth - C1BeamWidth / 2,
                                 BillboardDepth + modelParameters.ZBracketSpacerThickness, 
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth - C1BeamWidth / 2, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceSides, 
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point
                                 (xZBracketSpacing + ZBracketWidth - C1BeamWidth / 2, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceSides, 
                                 zZBracketSpacing - WalerBeamDepth) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth - C1BeamWidth / 2, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceSides + plate4Y, 
                                 zZBracketSpacing - WalerBeamDepth - plate4Z) + OriginOffset, null),

                         };

                        // Create enums and offsets for the bracket
                        int[] bracketEnums = new int[] { 2, 1, 1 };
                        double[] bracketOffsets = new double[] { 0.0, 0.0, 0.0 };
                        PolyBeam zBracket = CreatePolyBeam(contourPoints, modelParameters.ZBracketProfile, modelParameters.BracketMaterial, bracketEnums, bracketOffsets, "6");
                        ZBrackets.Add(zBracket);

                        // Build the spacer Z-Brackets if they exist
                        ContourPlate zBracketSpacer = new ContourPlate();
                        if (modelParameters.ZBracketSpacer)
                        {
                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth - C1BeamWidth / 2,
                                 BillboardDepth,
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth - C1BeamWidth / 2,
                                 BillboardDepth,
                                 zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth - C1BeamWidth / 2 - modelParameters.ZBracketWidth,
                                 BillboardDepth,
                                 zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth - C1BeamWidth / 2 - modelParameters.ZBracketWidth,
                                 BillboardDepth,
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.Name = "PACKER";
                            zBracketSpacer.Profile.ProfileString = "PLT" + modelParameters.ZBracketSpacerThickness.ToString();
                            zBracketSpacer.Material.MaterialString = modelParameters.BracketMaterial;
                            zBracketSpacer.Position.Depth = Position.DepthEnum.FRONT;
                            zBracketSpacer.PartNumber = new NumberingSeries("PL",1);
                            zBracketSpacer.Name = "PACKER";

                            if (!zBracketSpacer.Insert()) { Console.WriteLine("Failed to insert Z Bracket Spacer Plate"); }
                        }

                        // INSERT THE BOLTS
                        // Create a new bolt array
                        BoltArray Bolt = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = planes[indexXcoordinates].Back,

                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing, BillboardDepth, zZBracketSpacing) + OriginOffset, // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing, BillboardDepth, zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketBoltDiameter,
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard,
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Bolt.Position.Depth = Position.DepthEnum.MIDDLE;
                        Bolt.Position.DepthOffset = 0;
                        Bolt.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Bolt.Position.Rotation = Position.RotationEnum.BELOW;
                        Bolt.Position.RotationOffset = 0;

                        // the following properties determine the shape of bolts
                        // In this case, we set everything to false
                        Bolt.Bolt = true;
                        Bolt.Washer1 = false;
                        Bolt.Washer2 = false;
                        Bolt.Washer3 = true;
                        Bolt.Nut1 = true;
                        Bolt.Nut2 = false;

                        Bolt.Hole1 = false;
                        Bolt.Hole2 = false;
                        Bolt.Hole3 = false;
                        Bolt.Hole4 = false;
                        Bolt.Hole5 = false;

                        // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                        Bolt.AddBoltDistY(0);

                        // Add the distance between two holes 
                        Bolt.AddBoltDistX(spacingBetweenBolts);

                        // Specify the offset to the first bolt 
                        Bolt.StartPointOffset.Dx = lowerBoltToTopWaler;

                        // Add the spacer bolt if applicable
                        if (modelParameters.ZBracketSpacer)
                        {
                            Bolt.AddOtherPartToBolt(zBracketSpacer);
                        }

                        // Insert bolts
                        if (!Bolt.Insert()) { MessageBox.Show("Insertion of Bolt failed."); }

                        // INSERT THE BOLT HOLE ON WALER
                        // Create a new bolt array
                        BoltArray Hole = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = zBracket,

                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing, BillboardDepth + WalerBeamWidth + modelParameters.ZBracketSpacerThickness, zZBracketSpacing) + OriginOffset, // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing, BillboardDepth + modelParameters.ZBracketSpacerThickness, zZBracketSpacing) + OriginOffset, // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketHoleDiameter,
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard,
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Hole.Position.Depth = Position.DepthEnum.MIDDLE;
                        Hole.Position.DepthOffset = 0;
                        Hole.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Hole.Position.PlaneOffset = 0;
                        Hole.Position.Rotation = Position.RotationEnum.FRONT;
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

                        // Specify the offset to the first bolt 
                        Hole.StartPointOffset.Dx = 0.5 * WalerBeamWidth;


                        // Insert bolts
                        if (!Hole.Insert()) { MessageBox.Show("Insertion of Bolt failed."); }
                    }
                    // Check if we are at the finalx-coordinate (because these have modified z brackets and different alignment)
                    else if (planes[indexXcoordinates].PlaneType == 2)
                    {
                        // Build the extended z-brackets
                        List<ContourPoint> contourPoints = new List<ContourPoint>()
                         {
                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + C1BeamWidth / 2,
                                 BillboardDepth + modelParameters.ZBracketSpacerThickness, 
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts +lowerBoltToTopWaler) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + C1BeamWidth / 2,
                                 BillboardDepth + modelParameters.ZBracketSpacerThickness, 
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + C1BeamWidth / 2, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceSides, 
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + C1BeamWidth / 2, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceSides, 
                                 zZBracketSpacing - WalerBeamDepth) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + C1BeamWidth / 2, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceSides + plate4Y, 
                                 zZBracketSpacing - WalerBeamDepth - plate4Z) + OriginOffset, null),

                         };

                        // Create enums and offsets for the bracket
                        int[] bracketEnums = new int[] { 2, 1, 1 };
                        double[] bracketOffsets = new double[] { 0.0, 0.0, 0.0 };
                        PolyBeam zBracket = CreatePolyBeam(contourPoints, modelParameters.ZBracketProfile, modelParameters.BracketMaterial, bracketEnums, bracketOffsets, "6");
                        ZBrackets.Add(zBracket);

                        // Build the spacer Z-Brackets if they exist
                        ContourPlate zBracketSpacer = new ContourPlate();
                        if (modelParameters.ZBracketSpacer)
                        {
                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + C1BeamWidth / 2,
                                 BillboardDepth,
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + C1BeamWidth / 2,
                                 BillboardDepth,
                                 zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + C1BeamWidth / 2 - modelParameters.ZBracketWidth,
                                 BillboardDepth,
                                 zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + C1BeamWidth / 2 - modelParameters.ZBracketWidth,
                                 BillboardDepth,
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.Profile.ProfileString = "PLT" + modelParameters.ZBracketSpacerThickness.ToString();
                            zBracketSpacer.Material.MaterialString = modelParameters.BracketMaterial;
                            zBracketSpacer.Position.Depth = Position.DepthEnum.FRONT;
                            zBracketSpacer.PartNumber = new NumberingSeries("PL", 1);
                            zBracketSpacer.Name = "PACKER";

                            if (!zBracketSpacer.Insert()) { Console.WriteLine("Failed to insert Z Bracket Spacer Plate"); }
                        }

                        // INSERT THE BOLTS
                        // Create a new bolt array
                        BoltArray Bolt = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = planes[indexXcoordinates].Back,


                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing, BillboardDepth, zZBracketSpacing) + OriginOffset, // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing, BillboardDepth, zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketBoltDiameter,
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard,
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Bolt.Position.Depth = Position.DepthEnum.MIDDLE;
                        Bolt.Position.DepthOffset = 0;
                        Bolt.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Bolt.Position.Rotation = Position.RotationEnum.BELOW;
                        Bolt.Position.RotationOffset = 0;

                        // the following properties determine the shape of bolts
                        // In this case, we set everything to false
                        Bolt.Bolt = true;
                        Bolt.Washer1 = false;
                        Bolt.Washer2 = false;
                        Bolt.Washer3 = true;
                        Bolt.Nut1 = true;
                        Bolt.Nut2 = false;

                        Bolt.Hole1 = false;
                        Bolt.Hole2 = false;
                        Bolt.Hole3 = false;
                        Bolt.Hole4 = false;
                        Bolt.Hole5 = false;

                        // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                        Bolt.AddBoltDistY(0);

                        // Add the distance between two holes 
                        Bolt.AddBoltDistX(spacingBetweenBolts);

                        // Specify the offset to the first bolt 
                        Bolt.StartPointOffset.Dx = lowerBoltToTopWaler;

                        // Add the spacer bolt if applicable
                        if (modelParameters.ZBracketSpacer)
                        {
                            Bolt.AddOtherPartToBolt(zBracketSpacer);
                        }

                        // Insert bolts
                        if (!Bolt.Insert()) { MessageBox.Show("Insertion of Bolt failed."); }

                        // INSERT THE BOLT HOLE ON WALER
                        // Create a new bolt array
                        BoltArray Hole = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = zBracket,

                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing, BillboardDepth + WalerBeamWidth + modelParameters.ZBracketSpacerThickness, zZBracketSpacing) + OriginOffset, // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing, BillboardDepth + modelParameters.ZBracketSpacerThickness, zZBracketSpacing) + OriginOffset, // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketHoleDiameter,
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard,
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Hole.Position.Depth = Position.DepthEnum.MIDDLE;
                        Hole.Position.DepthOffset = 0;
                        Hole.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Hole.Position.PlaneOffset = 0;
                        Hole.Position.Rotation = Position.RotationEnum.FRONT;
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

                        // Specify the offset to the first bolt 
                        Hole.StartPointOffset.Dx = 0.5 * WalerBeamWidth;


                        // Insert bolts
                        if (!Hole.Insert()) { MessageBox.Show("Insertion of Bolt failed."); }
                    }
                    // Check if we are at a SPLIT plane (because these have modified z brackets and different alignment)
                    else if (planes[indexXcoordinates].PlaneType == 0)
                    {
                        // If the z bracket is ment to be on the left, then shift it to the left by the box gap length.
                        // If the z bracket is ment to be on the right, then shift it to the right by the zbracket width and box gap length.
                        plateSplitOffset.X = planes[indexXcoordinates].SeatingPlateRight ?
                            ZBracketWidth + modelParameters.BoxGap : -modelParameters.BoxGap;

                        // Similar to the plates.
                        boltSplitOffset.X = planes[indexXcoordinates].SeatingPlateRight ?
                            modelParameters.C1SplitBeamWidth / 2 + modelParameters.BoxGap : -modelParameters.C1SplitBeamWidth / 2 - modelParameters.BoxGap;

                        // Build the extended z-brackets
                        List<ContourPoint> contourPoints = new List<ContourPoint>()
                         {
                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing,
                                 BillboardDepth + modelParameters.ZBracketSpacerThickness, 
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts +lowerBoltToTopWaler) + OriginOffset + plateSplitOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing,
                                 BillboardDepth + modelParameters.ZBracketSpacerThickness, 
                                 zZBracketSpacing) + OriginOffset + plateSplitOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceSides, 
                                 zZBracketSpacing) + OriginOffset + plateSplitOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceSides, 
                                 zZBracketSpacing - WalerBeamDepth) + OriginOffset + plateSplitOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceSides + plate4Y, 
                                 zZBracketSpacing - WalerBeamDepth - plate4Z) + OriginOffset + plateSplitOffset, null),

                         };

                        // Create enums and offsets for the bracket
                        int[] bracketEnums = new int[] { 2, 1, 1 };
                        double[] bracketOffsets = new double[] { 0.0, 0.0, 0.0 };
                        PolyBeam zBracket = CreatePolyBeam(contourPoints, modelParameters.ZBracketProfile, modelParameters.BracketMaterial, bracketEnums, bracketOffsets, "6");
                        ZBrackets.Add(zBracket);

                        // Build the spacer Z-Brackets if they exist
                        ContourPlate zBracketSpacer = new ContourPlate();
                        if (modelParameters.ZBracketSpacer)
                        {
                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing,
                                 BillboardDepth,
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset + plateSplitOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing,
                                 BillboardDepth,
                                 zZBracketSpacing) + OriginOffset + plateSplitOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing - modelParameters.ZBracketWidth,
                                 BillboardDepth,
                                 zZBracketSpacing) + OriginOffset + plateSplitOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 xZBracketSpacing - modelParameters.ZBracketWidth,
                                 BillboardDepth,
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset + plateSplitOffset, null));

                            zBracketSpacer.Profile.ProfileString = "PLT" + modelParameters.ZBracketSpacerThickness.ToString();
                            zBracketSpacer.Material.MaterialString = modelParameters.BracketMaterial;
                            zBracketSpacer.Position.Depth = Position.DepthEnum.FRONT;
                            zBracketSpacer.PartNumber = new NumberingSeries("Spacer Plate", Convert.ToInt32(xZBracketSpacing + zZBracketSpacing));

                            if (!zBracketSpacer.Insert()) { Console.WriteLine("Failed to insert Z Bracket Spacer Plate"); }
                        }

                        // INSERT THE BOLTS
                        // Create a new bolt array
                        BoltArray Bolt = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = planes[indexXcoordinates].Back,


                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing, BillboardDepth, zZBracketSpacing) + OriginOffset + boltSplitOffset, // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing, BillboardDepth, zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset + boltSplitOffset, // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketBoltDiameter,
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard,
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Bolt.Position.Depth = Position.DepthEnum.MIDDLE;
                        Bolt.Position.DepthOffset = 0;
                        Bolt.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Bolt.Position.Rotation = Position.RotationEnum.BELOW;
                        Bolt.Position.RotationOffset = 0;

                        // the following properties determine the shape of bolts
                        // In this case, we set everything to false
                        Bolt.Bolt = true;
                        Bolt.Washer1 = false;
                        Bolt.Washer2 = false;
                        Bolt.Washer3 = true;
                        Bolt.Nut1 = true;
                        Bolt.Nut2 = false;

                        Bolt.Hole1 = false;
                        Bolt.Hole2 = false;
                        Bolt.Hole3 = false;
                        Bolt.Hole4 = false;
                        Bolt.Hole5 = false;

                        // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                        Bolt.AddBoltDistY(0);

                        // Add the distance between two holes 
                        Bolt.AddBoltDistX(spacingBetweenBolts);

                        // Specify the offset to the first bolt 
                        Bolt.StartPointOffset.Dx = lowerBoltToTopWaler;

                        // Add the spacer bolt if applicable
                        if (modelParameters.ZBracketSpacer)
                        {
                            Bolt.AddOtherPartToBolt(zBracketSpacer);
                        }

                        // Insert bolts
                        if (!Bolt.Insert()) { MessageBox.Show("Insertion of Bolt failed."); }

                        // INSERT THE BOLT HOLE ON WALER
                        // Create a new bolt array
                        BoltArray Hole = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = zBracket,

                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing, BillboardDepth + WalerBeamWidth + modelParameters.ZBracketSpacerThickness, zZBracketSpacing) + OriginOffset + boltSplitOffset, // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing, BillboardDepth + modelParameters.ZBracketSpacerThickness, zZBracketSpacing) + OriginOffset + boltSplitOffset, // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketHoleDiameter,
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard,
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Hole.Position.Depth = Position.DepthEnum.MIDDLE;
                        Hole.Position.DepthOffset = 0;
                        Hole.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Hole.Position.PlaneOffset = 0;
                        Hole.Position.Rotation = Position.RotationEnum.FRONT;
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

                        // Specify the offset to the first bolt 
                        Hole.StartPointOffset.Dx = 0.5 * WalerBeamWidth;


                        // Insert bolts
                        if (!Hole.Insert()) { MessageBox.Show("Insertion of Bolt failed."); }
                    }
                    // If we are in the middle of the billboard
                    else
                    {
                        // Build the regular z-brackets
                        // Build the extended z-brackets
                        List<ContourPoint> contourPoints = new List<ContourPoint>()
                         {
                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth / 2,
                                 BillboardDepth + modelParameters.ZBracketSpacerThickness, 
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts +lowerBoltToTopWaler) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth / 2,
                                 BillboardDepth + modelParameters.ZBracketSpacerThickness, 
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth / 2, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceInner, 
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 xZBracketSpacing + ZBracketWidth / 2, 
                                 BillboardDepth + WalerBeamWidth + offsetToWalerFaceInner, 
                                 zZBracketSpacing - WalerBeamDepth + offsetToWalerBottom) + OriginOffset, null),
                         };

                        // Create enums and offsets for the bracket
                        int[] bracketEnums = new int[] { 2, 1, 1 };
                        double[] bracketOffsets = new double[] { 0.0, 0.0, 0.0 };
                        PolyBeam zBracket = CreatePolyBeam(contourPoints, modelParameters.ZBracketProfile, modelParameters.BracketMaterial, bracketEnums, bracketOffsets, "6");
                        ZBrackets.Add(zBracket);

                        // Build the spacer Z-Brackets if they exist
                        ContourPlate zBracketSpacer = new ContourPlate();
                        if (modelParameters.ZBracketSpacer)
                        {
                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                xZBracketSpacing + ZBracketWidth / 2,
                                BillboardDepth,
                                zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                xZBracketSpacing + ZBracketWidth / 2,
                                BillboardDepth,
                                zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                xZBracketSpacing + ZBracketWidth / 2 - modelParameters.ZBracketWidth,
                                BillboardDepth,
                                zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                xZBracketSpacing + ZBracketWidth / 2 - modelParameters.ZBracketWidth,
                                BillboardDepth,
                                zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));
                            
                            zBracketSpacer.Profile.ProfileString = "PLT" + modelParameters.ZBracketSpacerThickness.ToString();
                            zBracketSpacer.Material.MaterialString = modelParameters.BracketMaterial;
                            zBracketSpacer.Position.Depth = Position.DepthEnum.FRONT;
                            zBracketSpacer.PartNumber = new NumberingSeries("PL", 1);
                            zBracketSpacer.Name = "PACKER";

                            if (!zBracketSpacer.Insert()) { Console.WriteLine("Failed to insert Z Bracket Spacer Plate"); }
                        }

                        // INSERT THE BOLTS
                        // Create a new bolt array
                        BoltArray Bolt = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = planes[indexXcoordinates].Back,


                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(
                                xZBracketSpacing,
                                BillboardDepth,
                                zZBracketSpacing) + OriginOffset, // point at bottom of top plate of bracket (point 2)

                            SecondPosition = new TSG.Point(
                                xZBracketSpacing,
                                BillboardDepth,
                                zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketBoltDiameter,
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard,
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Bolt.Position.Depth = Position.DepthEnum.MIDDLE;
                        Bolt.Position.DepthOffset = 0;
                        Bolt.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Bolt.Position.Rotation = Position.RotationEnum.BELOW;
                        Bolt.Position.RotationOffset = 0;

                        // the following properties determine the shape of bolts
                        // In this case, we set everything to false
                        Bolt.Bolt = true;
                        Bolt.Washer1 = false;
                        Bolt.Washer2 = false;
                        Bolt.Washer3 = true;
                        Bolt.Nut1 = true;
                        Bolt.Nut2 = false;

                        Bolt.Hole1 = false;
                        Bolt.Hole2 = false;
                        Bolt.Hole3 = false;
                        Bolt.Hole4 = false;
                        Bolt.Hole5 = false;

                        // Add the distance between two holes on the same horizontal line (set it to 0 because we only want one line)                      
                        Bolt.AddBoltDistY(0);

                        // Add the distance between two holes 
                        Bolt.AddBoltDistX(spacingBetweenBolts);

                        // Specify the offset to the first bolt 
                        Bolt.StartPointOffset.Dx = lowerBoltToTopWaler;

                        // Add the spacer bolt if applicable
                        if(modelParameters.ZBracketSpacer)
                        {
                            Bolt.AddOtherPartToBolt(zBracketSpacer);
                        }

                        // Insert bolts
                        if (!Bolt.Insert()) { MessageBox.Show("Insertion of Bolt failed."); }

                        

                        // INSERT THE BOLT HOLE ON WALER
                        // Create a new bolt array
                        BoltArray Hole = new BoltArray
                        {
                            // Specify the parts that are going to be bolted together
                            PartToBeBolted = zBracket,
                            PartToBoltTo = zBracket,

                            // Set the coordinates for the bolts (i.e. the line between these two points will be used to create the bolt array)
                            FirstPosition = new TSG.Point(xZBracketSpacing, BillboardDepth + WalerBeamWidth + modelParameters.ZBracketSpacerThickness, zZBracketSpacing) + OriginOffset, // point at bottom of top plate of bracket (point 2)
                            SecondPosition = new TSG.Point(xZBracketSpacing, BillboardDepth + modelParameters.ZBracketSpacerThickness, zZBracketSpacing) + OriginOffset, // point at very top of bracket (point 1)

                            // Bolt properties
                            BoltSize = modelParameters.BracketHoleDiameter,
                            Tolerance = 2.00,
                            BoltStandard = modelParameters.BracketBoltStandard,
                            BoltType = BoltGroup.BoltTypeEnum.BOLT_TYPE_SITE,
                            CutLength = 500,
                            Length = 0,
                            ExtraLength = 5,
                            ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
                        };

                        // Bolt offsets
                        Hole.Position.Depth = Position.DepthEnum.MIDDLE;
                        Hole.Position.DepthOffset = 0;
                        Hole.Position.Plane = Position.PlaneEnum.MIDDLE;
                        Hole.Position.PlaneOffset = 0;
                        Hole.Position.Rotation = Position.RotationEnum.FRONT;
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

                        // Specify the offset to the first bolt 
                        Hole.StartPointOffset.Dx = 0.5 * WalerBeamWidth;


                        // Insert bolts
                        if (!Hole.Insert()) { MessageBox.Show("Insertion of Bolt failed."); }
                    }
                }
            }

            return ZBrackets;
        }

        /// <summary>
        /// Populates the curve billboard model with Z-brackets at given z-coordinates.
        /// </summary>
        /// <param name="planes"> List of frames sorted by x-coordinates to insert the Z-brackets behind </param>
        /// <param name="zCoordinatesForZBrackets"> List of z-coordinates to insert the Z-brackets along (mm) </param>
        /// <param name="modelParameters"> The model's data store </param>
        /// TODO Description for return
        public static List<Part> ZBracketsCurve
            (
                List<double> xSubCoordinates,
                TSG.Point OriginOffset,
                List<Curve_Frame> planes,
                List<double> zCoordinatesForZBrackets,
                ModelParameters modelParameters
            )
        {
            List<Part> ZBrackets = new List<Part>();

            double C1BeamWidth = modelParameters.C1BeamWidth;
            double WalerBeamDepth = modelParameters.WalerBeamDepth;
            double WalerBeamWidth = modelParameters.WalerBeamWidth;
            double ZBracketWidth = modelParameters.ZBracketWidth;

            List<double> XCoordinates = xSubCoordinates;

            // THIS CODE IS FOR THE Z BRACKETS // 
            //              P1
            //              |
            //    Plate 1   |
            //              |
            //           P2 |___________P3
            //                 Plate2   |
            //                          |
            //                          | Plate 3
            //                          |
            //                       P4 \
            //                           \
            //                            \
            //                             \  Plate 4
            //                              P5

            // Insert code for side bracings here //

            // Initialise the x-direction and z-direction spacing for the z-brackets
            double xZBracketSpacing = 0;
            double zZBracketSpacing = 0;

            // Initialise the variables
            // The angle for the extended part of the bracket on the edges of the billboard 
            double angleInDegrees = 45;

            // Converting the angle to radians 
            double angleInRadians = angleInDegrees * (Math.PI / 180);

            // Outer edges bracket plate 4 length 
            double plate4Length = 150; //TODO Maybe user input

            // Finding the y and z components of the length of Plate 4.
            double plate4Y = plate4Length * Math.Cos(angleInRadians);
            double plate4Z = plate4Length * Math.Sin(angleInRadians);

            // Initialise dimensions for all four plates of z bracket
            // double zBracketYOffset = 0.5 zBracketThickness;
            //double  zBracketZOffset =

            // For plate 1:
            double topEdgeToUpperBolt = 30; //TODO Maybe user input
            double spacingBetweenBolts = 100; //TODO user input
            double lowerBoltToTopWaler = 50; // TODO user input

            //Internal Bracket offsets (a and b in the clients documents)   
            double offsetToWalerFaceSides = modelParameters.EndBracketSpacing;
            double offsetToWalerFaceInner = modelParameters.BracketASpacing;
            double offsetToWalerBottom = modelParameters.BracketBSpacing;

            // Radius of the Back Circle 2
            double BackCircle_2 = modelParameters.Radius - (2 * modelParameters.B1BeamDepth) - modelParameters.Distance;

            // Loop through the x-coordinates
            for (int indexXcoordinates = 0; indexXcoordinates <= (XCoordinates.Count - 1); indexXcoordinates++)
            {
                // Update the x-spacing (the first value in the XCoordinates list is 0)
                xZBracketSpacing += XCoordinates[indexXcoordinates];

                // Loop through the z-coordinates of the walers (i.e. the z spacings of the brackets)
                for (int indexZcoordinates = 0; indexZcoordinates <= (zCoordinatesForZBrackets.Count - 1); indexZcoordinates++)
                {
                    // Update the z-spacing 
                    zZBracketSpacing = zCoordinatesForZBrackets[indexZcoordinates];

                    // Check if we are in the first x-coordinate (because these have modified z brackets and different alignment)
                    if (planes[indexXcoordinates].PlaneType == 1)
                    {
                        // Build the extended z-brackets
                        List<ContourPoint> contourPoints = new List<ContourPoint>()
                         {
                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth - C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth - C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth - C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + WalerBeamWidth + offsetToWalerFaceSides,
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point
                                 (CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth - C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + WalerBeamWidth + offsetToWalerFaceSides,
                                 zZBracketSpacing - WalerBeamDepth) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth - C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + WalerBeamWidth + offsetToWalerFaceSides + plate4Y,
                                 zZBracketSpacing - WalerBeamDepth - plate4Z) + OriginOffset, null),

                         };

                        // Create enums and offsets for the bracket
                        int[] bracketEnums = new int[] { 2, 1, 1 };
                        double[] bracketOffsets = new double[] { 0.0, 0.0, 0.0 };
                        PolyBeam zBracket = CreatePolyBeam(contourPoints, modelParameters.ZBracketProfile, modelParameters.BracketMaterial, bracketEnums, bracketOffsets, "6");
                        ZBrackets.Add(zBracket);

                        // Build the spacer Z-Brackets if they exist
                        ContourPlate zBracketSpacer = new ContourPlate();
                        if (modelParameters.ZBracketSpacer)
                        {
                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth - C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth - C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                 zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth - C1BeamWidth / 2 - modelParameters.ZBracketWidth,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                 zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth - C1BeamWidth / 2 - modelParameters.ZBracketWidth,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.Name = "PACKER";
                            zBracketSpacer.Profile.ProfileString = "PLT" + modelParameters.ZBracketSpacerThickness.ToString();
                            zBracketSpacer.Material.MaterialString = modelParameters.BracketMaterial;
                            zBracketSpacer.Position.Depth = Position.DepthEnum.FRONT;
                            zBracketSpacer.PartNumber = new NumberingSeries("PL", 1);
                            zBracketSpacer.Name = "PACKER";

                            if (!zBracketSpacer.Insert()) { Console.WriteLine("Failed to insert Z Bracket Spacer Plate"); }
                        }
                    }
                    // Check if we are at the finalx-coordinate (because these have modified z brackets and different alignment)
                    else if (planes[indexXcoordinates].PlaneType == 2)
                    {
                        // Build the extended z-brackets
                        List<ContourPoint> contourPoints = new List<ContourPoint>()
                         {
                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + modelParameters.ZBracketSpacerThickness,
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts +lowerBoltToTopWaler) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + modelParameters.ZBracketSpacerThickness,
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + WalerBeamWidth + offsetToWalerFaceSides,
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + WalerBeamWidth + offsetToWalerFaceSides,
                                 zZBracketSpacing - WalerBeamDepth) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + WalerBeamWidth + offsetToWalerFaceSides + plate4Y,
                                 zZBracketSpacing - WalerBeamDepth - plate4Z) + OriginOffset, null),

                         };

                        // Create enums and offsets for the bracket
                        int[] bracketEnums = new int[] { 2, 1, 1 };
                        double[] bracketOffsets = new double[] { 0.0, 0.0, 0.0 };
                        PolyBeam zBracket = CreatePolyBeam(contourPoints, modelParameters.ZBracketProfile, modelParameters.BracketMaterial, bracketEnums, bracketOffsets, "6");
                        ZBrackets.Add(zBracket);

                        // Build the spacer Z-Brackets if they exist
                        ContourPlate zBracketSpacer = new ContourPlate();
                        if (modelParameters.ZBracketSpacer)
                        {
                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + C1BeamWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                 zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + C1BeamWidth / 2 - modelParameters.ZBracketWidth,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                 zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + C1BeamWidth / 2 - modelParameters.ZBracketWidth,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.Profile.ProfileString = "PLT" + modelParameters.ZBracketSpacerThickness.ToString();
                            zBracketSpacer.Material.MaterialString = modelParameters.BracketMaterial;
                            zBracketSpacer.Position.Depth = Position.DepthEnum.FRONT;
                            zBracketSpacer.PartNumber = new NumberingSeries("PL", 1);
                            zBracketSpacer.Name = "PACKER";

                            if (!zBracketSpacer.Insert()) { Console.WriteLine("Failed to insert Z Bracket Spacer Plate"); }
                        }
                    }
                    // If we are in the middle of the billboard
                    else
                    {
                        // Build the regular z-brackets
                        // Build the extended z-brackets
                        List<ContourPoint> contourPoints = new List<ContourPoint>()
                         {
                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + modelParameters.ZBracketSpacerThickness,
                                 zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts +lowerBoltToTopWaler) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + modelParameters.ZBracketSpacerThickness,
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + WalerBeamWidth + offsetToWalerFaceInner,
                                 zZBracketSpacing) + OriginOffset, null),

                             new ContourPoint(new TSG.Point(
                                 CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth / 2,
                                 CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters) + WalerBeamWidth + offsetToWalerFaceInner,
                                 zZBracketSpacing - WalerBeamDepth + offsetToWalerBottom) + OriginOffset, null),
                         };

                        // Create enums and offsets for the bracket
                        int[] bracketEnums = new int[] { 2, 1, 1 };
                        double[] bracketOffsets = new double[] { 0.0, 0.0, 0.0 };
                        PolyBeam zBracket = CreatePolyBeam(contourPoints, modelParameters.ZBracketProfile, modelParameters.BracketMaterial, bracketEnums, bracketOffsets, "6");
                        ZBrackets.Add(zBracket);

                        // Build the spacer Z-Brackets if they exist
                        ContourPlate zBracketSpacer = new ContourPlate();
                        if (modelParameters.ZBracketSpacer)
                        {
                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth / 2,
                                CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth / 2,
                                CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth / 2 - modelParameters.ZBracketWidth,
                                CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                zZBracketSpacing) + OriginOffset, null));

                            zBracketSpacer.AddContourPoint(new ContourPoint(new TSG.Point(
                                CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters) + ZBracketWidth / 2 - modelParameters.ZBracketWidth,
                                CurveSupport.Circle_Ycoord(CurveSupport.Circle_Xcoord(xZBracketSpacing, BackCircle_2, modelParameters), BackCircle_2, modelParameters),
                                zZBracketSpacing + topEdgeToUpperBolt + spacingBetweenBolts + lowerBoltToTopWaler) + OriginOffset, null));

                            zBracketSpacer.Profile.ProfileString = "PLT" + modelParameters.ZBracketSpacerThickness.ToString();
                            zBracketSpacer.Material.MaterialString = modelParameters.BracketMaterial;
                            zBracketSpacer.Position.Depth = Position.DepthEnum.FRONT;
                            zBracketSpacer.PartNumber = new NumberingSeries("PL", 1);
                            zBracketSpacer.Name = "PACKER";

                            if (!zBracketSpacer.Insert()) { Console.WriteLine("Failed to insert Z Bracket Spacer Plate"); }
                        }
                    }
                }
            }

            return ZBrackets;
        }

        /// <summary>
        /// Method to create a PolyBeam model on Tekla Structures.
        /// </summary>
        /// <param name="points"> List of ContourPoints in clockwise or counterclockwise order in the beam's cross section (mm)</param>
        /// <param name="material"> The beam's material </param>
        /// <param name="profile"> The beam's profile </param>
        /// <param name="beamClass"> The beam's class e.g. beamClass : "1" </param>
        /// <param name="bracketEnums"> Array in the form [Position.DepthEnum, Position.PlaneEnum, Position.RotationEnum] </param>
        /// <param name="bracketOffsets"> Offsets in the form [depthOffset, planeOffset, rotationOffset] </param>
        /// <param name="beamFinish"> Finish field of the part </param>
        /// <returns> Part in Tekla Structures. </returns>
        public static PolyBeam CreatePolyBeam(List<ContourPoint> points, string profile, string material, int[] bracketEnums, double[] bracketOffsets, string beamClass, string beamFinish = "")
        {
            PolyBeam polyBeam = new PolyBeam();

            foreach (ContourPoint point in points)
            {
                polyBeam.AddContourPoint(point);
            }

            polyBeam.Profile.ProfileString = profile;
            polyBeam.Material.MaterialString = material;

            polyBeam.Position.Depth = (Position.DepthEnum)bracketEnums[0];
            polyBeam.Position.DepthOffset = bracketOffsets[0];

            polyBeam.Position.Plane = (Position.PlaneEnum)bracketEnums[1];
            polyBeam.Position.PlaneOffset = bracketOffsets[1];

            polyBeam.Position.Rotation = (Position.RotationEnum)bracketEnums[2];
            polyBeam.Position.RotationOffset = bracketOffsets[2];
            polyBeam.Name = "Z-BRACKET";
            polyBeam.PartNumber = new NumberingSeries("PL", 1);
            polyBeam.AssemblyNumber = new NumberingSeries("ZB", 1);
            polyBeam.Class = beamClass;
            polyBeam.Finish = beamFinish;

            if (!polyBeam.Insert()) { MessageBox.Show("Failed to insert beam"); };

            return polyBeam;
        }
    }
}