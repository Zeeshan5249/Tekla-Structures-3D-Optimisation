using System.Windows.Forms;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using System;
using System.Collections.Generic;


namespace TeklaBillboardAid
{

    public class LadderBuilder
    {
        
        ModelParameters modelParameters;
        

        /// <summary>
        /// Constructor for the LadderBuilder class that takes ModelParameters as a parameter.
        /// </summary>
        /// <param name="modelparameter">The ModelParameters object containing necessary data for ladder construction.</param>

        public LadderBuilder(ModelParameters modelparameter)
        {
            this.modelParameters = modelparameter;
            
        }

        /// <summary>
        /// Builds a ladder based on the provided start and end points and a list of railing heights.
        /// </summary>
        /// <param name="startpoint">The starting point of the ladder.</param>
        /// <param name="endpoint">The ending point of the ladder.</param>
        /// <param name="RailingHeights">A list containing the heights of each railing for the construction of connection plate.</param>
        public List<Part> BuildLadder(TSG.Point startpoint, TSG.Point endpoint, List<double> RailingHeights)
        {

            // Extracting C1 Beam parameters from the ModelParameters object
            string[] C1Beamparameter = modelParameters.C1Profile.Split('*');
            double C1BeamWidth = double.Parse(C1Beamparameter[1]);

            // Adjusting start and end points by adding an offset
            startpoint.X += (C1BeamWidth/2 );
            endpoint.X += (C1BeamWidth/2);

            // Extracting B3 Beam parameters from the ModelParameters object
            string[] B3Beamparameter = modelParameters.B3Profile.Split('S')[2].Split('*');
            double B3BeamHeight = double.Parse(B3Beamparameter[0]);
            double B3BeamWidth = double.Parse(B3Beamparameter[1]);

            // Adjusting railing heights to account for B3 Beam height
            for (int i = 0; i < RailingHeights.Count; i++)
            {
                RailingHeights[i] -= B3BeamHeight / 2;
            }
            
            // Adjusting Connection plate Y position
            double ConnectionPlateY = modelParameters.BillboardDepth - B3BeamWidth;

            // Creating side rail, rung, and plates list
            Beam sideRail = CreateSideRail(startpoint,endpoint);
            Beam rung = CreateRung(startpoint);
            List<ContourPlate> plates = CreatePlate(startpoint, RailingHeights,ConnectionPlateY);

            // Inserting the side rail, rung and plate into the model
            List<Part> LadderPart = ConnectLadder(sideRail, rung,plates);
            return LadderPart;
        }

        /// <summary>
        /// Creates a side rail for the ladder based on the given start and end points.
        /// </summary>
        /// <param name="startpoint">The starting point of the side rail.</param>
        /// <param name="endpoint">The ending point of the side rail.</param>
        /// <returns>A new instance of the Beam class representing the side rail.</returns>
        private Beam CreateSideRail(TSG.Point startpoint, TSG.Point endpoint)
        {
            // Setting properties for the side rail
            Beam SideRail = new Beam();
            SideRail.Name = "Side Rail";
            SideRail.Profile.ProfileString = modelParameters.LadderRailProfile;
            SideRail.Material.MaterialString = modelParameters.LadderRailMaterial;
            SideRail.Class = "Ladder";
            SideRail.StartPoint = new TSG.Point(startpoint.X,startpoint.Y,startpoint.Z);
            SideRail.EndPoint = new TSG.Point(endpoint.X,endpoint.Y,endpoint.Z);
            SideRail.Position.Rotation = Position.RotationEnum.FRONT;
            SideRail.Position.Plane = Position.PlaneEnum.MIDDLE;
            SideRail.Position.Depth = Position.DepthEnum.MIDDLE;
            SideRail.Class = "1";
            return SideRail;
        }

        /// <summary>
        /// Creates a rung for the ladder based on the given start point.
        /// </summary>
        /// <param name="startpoint">The starting point of the rung.</param>
        /// <returns>A new instance of the Beam class representing the rung.</returns>
        private Beam CreateRung(TSG.Point startpoint)
        {
            // Setting properties for the rung
            Beam Rung = new Beam();
            Rung.Name = "Rung";
            Rung.Profile.ProfileString =modelParameters.LadderRungProfile;
            Rung.Material.MaterialString = modelParameters.LadderRungMaterial;
            Rung.Class = "Ladder";
            Rung.Class = "1";
            Rung.Position.Rotation = Position.RotationEnum.FRONT;
            Rung.Position.Plane = Position.PlaneEnum.MIDDLE;
            Rung.Position.Depth = Position.DepthEnum.MIDDLE;
            return Rung;
        }

        /* Figure 1. Representation of a single plate of the connction plate (side view)
                            
              Point 3  _________________  Point 4
                      |                 | 
                      |                 |   
                      |_________________|
              Point 2                    Point 1
                           
        */
        /// <summary>
        /// Creates plates for ladder connections based on the given start point, railing heights, and ConnectionPlateY value.
        /// </summary>
        /// <param name="startpoint">The starting point of the plates.</param>
        /// <param name="RailingHeights">A list containing the heights of each railing.</param>
        /// <param name="ConnectionPlateY">The Y coordinate for the connection plates.</param>
        /// <returns>A list of ContourPlate instances representing the ladder connection plates.</returns>
        private List<ContourPlate> CreatePlate(TSG.Point startpoint, List<double> RailingHeights, double ConnectionPlateY)
        {
            
            List<ContourPlate> PlateList = new List<ContourPlate>();
            
            //Creating the connection plate according to heights
            foreach (double RailingHeight in RailingHeights)
            {
                // Creating right and left plates for each railing height
                // Adding ContourPoints and setting properties for the plates
                ContourPlate RightPlate = new ContourPlate();
                RightPlate.Profile.ProfileString = modelParameters.LadderPlateProfile;
                RightPlate.Material.MaterialString = modelParameters.LadderPlateMaterial;
                RightPlate.Class = "1";

                ContourPoint RightPoint1 = new ContourPoint(new TSG.Point(startpoint.X  , startpoint.Y + modelParameters.LadderRailLength/2 + modelParameters.WeldOffset , RailingHeight), null);
                ContourPoint RightPoint2 = new ContourPoint(new TSG.Point(startpoint.X , ConnectionPlateY  - modelParameters.WeldOffset, RailingHeight), null);
                ContourPoint RightPoint3 = new ContourPoint(new TSG.Point(startpoint.X , ConnectionPlateY  - modelParameters.WeldOffset, RailingHeight + modelParameters.LadderPlateHeight), null);
                ContourPoint RightPoint4 = new ContourPoint(new TSG.Point(startpoint.X, startpoint.Y + modelParameters.LadderRailLength / 2 + modelParameters.WeldOffset, RailingHeight + modelParameters.LadderPlateHeight), null);
                RightPlate.AddContourPoint(RightPoint1);
                RightPlate.AddContourPoint(RightPoint2);
                RightPlate.AddContourPoint(RightPoint3);
                RightPlate.AddContourPoint(RightPoint4);

                ContourPlate LeftPlate = new ContourPlate();
                LeftPlate.Profile.ProfileString = "PLT" + modelParameters.LadderPlateThickness;
                LeftPlate.Material.MaterialString = modelParameters.LadderPlateMaterial;
                LeftPlate.Class = "1";
                
                ContourPoint LeftPoint1 = new ContourPoint(new TSG.Point(startpoint.X + modelParameters.LadderWidth - modelParameters.LadderRailWidth , startpoint.Y + modelParameters.LadderRailLength / 2 + modelParameters.WeldOffset, RailingHeight), null);
                ContourPoint LeftPoint2 = new ContourPoint(new TSG.Point(startpoint.X + modelParameters.LadderWidth - modelParameters.LadderRailWidth , ConnectionPlateY - modelParameters.WeldOffset, RailingHeight), null);
                ContourPoint LeftPoint3 = new ContourPoint(new TSG.Point(startpoint.X + modelParameters.LadderWidth - modelParameters.LadderRailWidth , ConnectionPlateY - modelParameters.WeldOffset, RailingHeight + modelParameters.LadderPlateHeight), null);
                ContourPoint LeftPoint4 = new ContourPoint(new TSG.Point(startpoint.X + modelParameters.LadderWidth - modelParameters.LadderRailWidth , startpoint.Y + modelParameters.LadderRailLength / 2 + modelParameters.WeldOffset, RailingHeight + modelParameters.LadderPlateHeight), null);
                LeftPlate.AddContourPoint(LeftPoint1);
                LeftPlate.AddContourPoint(LeftPoint2 );
                LeftPlate.AddContourPoint(LeftPoint3);
                LeftPlate.AddContourPoint(LeftPoint4);
                
                // Adding the plate to the plate list
                PlateList.Add(RightPlate);
                PlateList.Add(LeftPlate);
            }
            
            return PlateList;
        }

        /// <summary>
        /// Connects the side rail, rung, and plates to build the ladder.
        /// </summary>
        /// <param name="SideRail">The side rail of the ladder.</param>
        /// <param name="rung">The rung of the ladder.</param>
        /// <param name="plates">The list of connection plates.</param>
        private List<Part> ConnectLadder(Beam SideRail, Beam rung, List<ContourPlate> plates)

        {   
            
            List<Part> LadderParts = new List<Part>();
            // Inserting right side rail from back view
            Beam sideRail_right = CreateSideRail(SideRail.StartPoint,SideRail.EndPoint);
            
            if (!sideRail_right.Insert()) {
                MessageBox.Show("Failed to insert side rail"); 
            }
            LadderParts.Add(sideRail_right);
            
            // Inserting left side rail from back view
            Beam sideRail_left = CreateSideRail(sideRail_right.StartPoint, sideRail_right.EndPoint);
            sideRail_left.StartPoint.X += (modelParameters.LadderWidth - modelParameters.LadderRailWidth);
            sideRail_left.EndPoint.X = sideRail_left.StartPoint.X;
            if (!sideRail_left.Insert()) {
                MessageBox.Show("Failed to insert side rail");
            }
            LadderParts.Add(sideRail_left);

            //Inserting Rungs
            double sideRaillength = SideRail.EndPoint.Z - SideRail.StartPoint.Z; 
            int rungCount = (int)(sideRaillength / modelParameters.LadderRungSpacing) + 2;
            double rungEndPointX = rung.EndPoint.X;
            for (int i = 1; i < rungCount; i++)
            {      
                Beam rung_copy = CreateRung(rung.StartPoint);
                rung_copy.StartPoint = new TSG.Point(
                    sideRail_right.StartPoint.X + modelParameters.LadderRailWidth/2 + modelParameters.WeldOffset, 
                    sideRail_left.StartPoint.Y,
                    sideRail_right.EndPoint.Z);
                rung_copy.EndPoint = new TSG.Point(
                    rung_copy.StartPoint.X + modelParameters.LadderWidth - modelParameters.LadderRailWidth*2 - modelParameters.WeldOffset*2, 
                    rung_copy.StartPoint.Y, 
                    rung_copy.StartPoint.Z);
                rung_copy.StartPoint.Z -= (i - 1) * modelParameters.LadderRungSpacing + 10;
                rung_copy.EndPoint.Z -= (i - 1)* modelParameters.LadderRungSpacing + 10;
                if (!rung_copy.Insert()) { MessageBox.Show("Failed to insert Ladder Rungs."); }
                LadderParts.Add(rung_copy);
            }

            // Inserting connetion plates
            foreach(ContourPlate plate in plates)
            {  
                if (!plate.Insert()) { MessageBox.Show("Failed to insert Ladder connection plate."); }
                LadderParts.Add(plate);
            }
            return LadderParts;
        }


    }
}

