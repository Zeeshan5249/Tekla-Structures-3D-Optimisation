using System.Windows.Forms;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;
using System;
using System.Collections.Generic;

namespace TeklaBillboardAid
{
    public class RearDoor
    {
        ModelParameters modelparameters;
        double DoorFrameBeamWidth;
        double DoorFrameBeamHeight;
        double BoxZ;
        double DoorTopZ;
        bool LeftFrameReplace;
        bool RightFrameReplace;
        double DoorPanelBeamWidth;
        double DoorPanelBeamHeight;
        List<Beam> BeamCutted;

        /// <summary>
        /// Constructor for RearDoor class.
        /// </summary>
        /// <param name="modelparameters">The model parameters.</param>
        /// <param name="BoxZ">The Z-coordinate of the box.</param>
        /// <param name="DoorTopZ">The Z-coordinate of the top of the door.</param>
        /// <param name="BeamCutted">The list of cut beams.</param>
        /// <param name="LeftFrameReplace">True if the left frame should be replaced.</param>
        /// <param name="RightFrameReplace">True if the right frame should be replaced.</param>
        public RearDoor(ModelParameters modelparameters, double BoxZ, double DoorTopZ, List<Beam> BeamCutted, bool LeftFrameReplace, bool RightFrameReplace)
        {
            this.modelparameters = modelparameters;
            this.BoxZ = BoxZ;
            this.DoorTopZ = DoorTopZ;
            
            this.BeamCutted = BeamCutted;
            this.LeftFrameReplace = LeftFrameReplace;
            this.RightFrameReplace = RightFrameReplace;
        
        }

        /// <summary>
        /// Builds the rear door.
        /// </summary>
        /// <param name="StartPointX">The X-coordinate of the start point.</param>
        /// <param name="EndPointX">The X-coordinate of the end point.</param>
        /// <returns>The list of parts composing the rear door.</returns>
        public List<Part> RearDoorBuilder(double StartPointX, double EndPointX)
        {
            List<Part> RearDoorParts = DoorCreator(StartPointX, EndPointX);
            return RearDoorParts;
        }

        private Beam DoorFrameBeam()
        {
            //Set door frame properties
            Beam DoorFrame = new Beam();
            DoorFrame.Name = "DoorFrame";
            DoorFrame.Profile.ProfileString = modelparameters.DoorFrameProfile;
            DoorFrame.Material.MaterialString = modelparameters.DoorFrameMaterial;
            this.DoorFrameBeamWidth = modelparameters.DoorFrameWidth;
            this.DoorFrameBeamHeight = modelparameters.DoorFrameHeight;
            DoorFrame.Class = "11";
            return DoorFrame;
        }

        private Beam DoorPanelBeam()
        {
            //Set door panel properties
            Beam DoorPanel = new Beam();
            DoorPanel.Name = "DoorPanle";
            DoorPanel.Profile.ProfileString = modelparameters.DoorPanelProfile;
            DoorPanel.Material.MaterialString = modelparameters.DoorPanelMaterial;
            DoorPanelBeamHeight = modelparameters.DoorPanelHeight;
            DoorPanelBeamWidth = modelparameters.DoorPanelWidth;
            DoorPanel.Class = "11";
            return DoorPanel;
        }

        private ContourPlate DoorConnection()
        {
            // Set door plate properties
            ContourPlate ConnectionPlate = new ContourPlate();
            ConnectionPlate.Profile.ProfileString = "PLT" + ((DoorFrameBeamWidth - DoorPanelBeamWidth) / 2).ToString();
            ConnectionPlate.Material.MaterialString = "C350L0";
            ConnectionPlate.Class = "1";
            return ConnectionPlate;
        }

        // Filling cutted B3 beam
        private Beam FillingBeam()
        {
            // Set filling B3 beam profile
            Beam FillingBeam = new Beam();
            FillingBeam.Name = "Beam";
            FillingBeam.Class = "5";
            FillingBeam.Profile.ProfileString = modelparameters.B3Profile;
            FillingBeam.Material.MaterialString = modelparameters.B3Material;
            return FillingBeam;
        }

        // Create door
        private List<Part> DoorCreator(double StartPointX, double EndPointX)
        {
            List<Part> DoorParts = new List<Part>();
            double DoorFramePanelSpacing = modelparameters.DoorPanelFrameSpacing;

            //Get B3 beam dimensions
            string[] B3Beamparameter = modelparameters.B3Profile.Split('S')[2].Split('*');
            double B3BeamHeight = double.Parse(B3Beamparameter[0]);
            double B3BeamWidth = double.Parse(B3Beamparameter[1]);

            // Create left door frame beam
            Beam DoorFrameLeft = DoorFrameBeam();
            DoorFrameLeft.StartPoint = new TSG.Point(
                StartPointX,
                modelparameters.BillboardDepth - DoorFrameBeamWidth / 2,
                BoxZ  + modelparameters.WeldOffset);

            DoorFrameLeft.EndPoint = new TSG.Point(
                DoorFrameLeft.StartPoint.X, 
                DoorFrameLeft.StartPoint.Y ,
                DoorTopZ - B3BeamHeight/2 - modelparameters.WeldOffset);
            
            // If the left door's left most point is same as the column left most point then use the column as door's left frame
            // Else insert the created left frame beam
            if (!LeftFrameReplace)
            {
                if (!DoorFrameLeft.Insert()) { MessageBox.Show("Insertion of left door frame failed."); }
                DoorParts.Add(DoorFrameLeft);
            }
            
            // Create right door frame beam
            Beam DoorFrameRight = DoorFrameBeam();
            DoorFrameRight.StartPoint = new TSG.Point(
                EndPointX,
                DoorFrameLeft.StartPoint.Y, 
                BoxZ + modelparameters.WeldOffset);

            DoorFrameRight.EndPoint = new TSG.Point(
                DoorFrameRight.StartPoint.X,
                DoorFrameRight.StartPoint.Y,
                DoorFrameLeft.EndPoint.Z - modelparameters.WeldOffset);

            // If the right door's left most point is same as the column right most point then use the column as door's right frame
            //Else insert the created right frame beam
            if (RightFrameReplace)
            {
                
                DoorFrameRight.StartPoint.X += ( DoorFrameBeamWidth - modelparameters.C1BeamWidth);
                DoorFrameRight.EndPoint.X = DoorFrameLeft.StartPoint.X;

            }
            if (!RightFrameReplace) 
            {
                if (!DoorFrameRight.Insert()) { MessageBox.Show("Insertion of right door frame failed."); }
                DoorParts.Add(DoorFrameRight);
            }
           
            // Create and insert left door panel beam
            Beam DoorPanelLeft = DoorPanelBeam();
            DoorPanelLeft.StartPoint = new TSG.Point(
                DoorFrameLeft.StartPoint.X + DoorFrameBeamHeight + DoorFramePanelSpacing ,
                DoorFrameLeft.StartPoint.Y,
                DoorFrameLeft.StartPoint.Z + DoorFramePanelSpacing + modelparameters.WeldOffset);
            DoorPanelLeft.EndPoint = new TSG.Point(
                DoorPanelLeft.StartPoint.X,
                DoorPanelLeft.StartPoint.Y,
                DoorFrameLeft.EndPoint.Z - DoorFramePanelSpacing - modelparameters.WeldOffset);
            
           
            if (LeftFrameReplace)
            {
                DoorPanelLeft.StartPoint.X -= (DoorFrameBeamHeight - modelparameters.C1BeamWidth);
                DoorPanelLeft.EndPoint.X = DoorPanelLeft.StartPoint.X;
            }

            if (!DoorPanelLeft.Insert()) { MessageBox.Show("Insertion of door panel left failed"); }
            DoorParts.Add(DoorPanelLeft);

            // Create and insert right door panel beam
            Beam DoorPanelRight = DoorPanelBeam();
            DoorPanelRight.StartPoint = new TSG.Point(
                DoorFrameRight.StartPoint.X - DoorPanelBeamHeight - DoorFramePanelSpacing,
                DoorPanelLeft.StartPoint.Y,
                DoorPanelLeft.StartPoint.Z);
            DoorPanelRight.EndPoint = new TSG.Point(
                DoorPanelRight.StartPoint.X,
                DoorPanelRight.StartPoint.Y,
                DoorPanelLeft.EndPoint.Z);
            if (!DoorPanelRight.Insert()) { MessageBox.Show("Insertion of door panel right failed"); }
            DoorParts.Add(DoorPanelRight);


            // Create and insert top door panel beam
            Beam DoorPanelTop = DoorPanelBeam();
            DoorPanelTop.StartPoint = new TSG.Point(
                DoorPanelLeft.StartPoint.X + DoorPanelBeamHeight + modelparameters.WeldOffset,
                DoorPanelLeft.StartPoint.Y,
                DoorPanelLeft.EndPoint.Z);
            DoorPanelTop.EndPoint = new TSG.Point(
                DoorPanelRight.StartPoint.X - modelparameters.WeldOffset ,
                DoorPanelTop.StartPoint.Y,
                DoorPanelTop.StartPoint.Z);
            if (!DoorPanelTop.Insert()) { MessageBox.Show("Insertion of door panel top failed"); }
            DoorParts.Add(DoorPanelTop);

            // Create and insert bottom door panel beam
            Beam DoorPanelBottom = DoorPanelBeam();
            DoorPanelBottom.StartPoint = new TSG.Point(
                DoorPanelTop.StartPoint.X,
                DoorPanelTop.StartPoint.Y,
                DoorPanelLeft.StartPoint.Z + DoorPanelBeamHeight);
            DoorPanelBottom.EndPoint = new TSG.Point(
                DoorPanelTop.EndPoint.X,
                DoorPanelTop.EndPoint.Y,
                DoorPanelBottom.StartPoint.Z);
            if (!DoorPanelBottom.Insert()) { MessageBox.Show("Insertion of door panel bottom failed"); }
            DoorParts.Add(DoorPanelBottom);


            // Create and insert middle door panel beam
            Beam DoorPanelMiddle = DoorPanelBeam();
            DoorPanelMiddle.StartPoint = new TSG.Point(
                DoorPanelTop.StartPoint.X + modelparameters.WeldOffset,
                DoorPanelTop.StartPoint.Y,
                (DoorPanelTop.StartPoint.Z - DoorPanelBottom.StartPoint.Z)/2 + DoorPanelBottom.StartPoint.Z);
            DoorPanelMiddle.EndPoint = new TSG.Point(
                DoorPanelTop.EndPoint.X - modelparameters.WeldOffset,
                DoorPanelMiddle.StartPoint.Y,
                DoorPanelMiddle.StartPoint.Z);
            if (!DoorPanelMiddle.Insert()) { MessageBox.Show("Insertion of door panel middle failed"); }
            DoorParts.Add(DoorPanelMiddle);

            // Calculate xchange and zchange for the panel bracing startpoint
            double alpha = Math.Atan((DoorPanelTop.EndPoint.X - DoorPanelTop.StartPoint.X) / (DoorPanelTop.StartPoint.Z - DoorPanelMiddle.StartPoint.Z + DoorPanelBeamHeight));
            double diaganolL = Math.Sqrt(Math.Pow((DoorPanelTop.EndPoint.X - DoorPanelTop.StartPoint.X), 2) + Math.Pow((DoorPanelTop.StartPoint.Z - DoorPanelMiddle.StartPoint.Z + DoorPanelBeamHeight), 2));
            double belta = Math.Asin(DoorPanelBeamHeight / diaganolL);
            double Xchange = Math.Cos(alpha - belta) * DoorPanelBeamHeight;
            double Zchange = Math.Sin(alpha - belta) * DoorPanelBeamHeight;

            // Create and insert top bracing in door panel
            Beam DoorPanelBrcingtop = DoorPanelBeam();
            DoorPanelBrcingtop.StartPoint = new TSG.Point(
                DoorPanelTop.EndPoint.X - Xchange,
                DoorPanelTop.EndPoint.Y ,
                DoorPanelTop.EndPoint.Z - DoorPanelBeamHeight + Zchange );
            DoorPanelBrcingtop.EndPoint = new TSG.Point(
                DoorPanelMiddle.StartPoint.X,
                DoorPanelMiddle.StartPoint.Y,
                DoorPanelMiddle.StartPoint.Z + modelparameters.WeldOffset);

            if (!DoorPanelBrcingtop.Insert()) { MessageBox.Show("Insertion of door panel bracing failed"); }
            DoorParts.Add(DoorPanelBrcingtop);

            // Create top cutplane for door panel top bracing 
            CutPlane CutPlaneToptop = new CutPlane 
            { 
                Plane = new Plane 
                {
                    Origin = DoorPanelTop.StartPoint - new TSG.Point(0,0,DoorPanelBeamHeight + modelparameters.WeldOffset),
                    AxisY = new TSG.Vector(0,modelparameters.BillboardDepth,0),
                    AxisX = new TSG.Vector(modelparameters.BillboardHeight,0,0)
                }
            };
            CutPlaneToptop.Father = DoorPanelBrcingtop;
            if (!CutPlaneToptop.Insert()) { MessageBox.Show("Door panel upper bracing cut failed"); }

            // Create bottom cutplane for door panel top bracing
            CutPlane CutPlaneTopbottom = new CutPlane
            {
                Plane = new Plane
                {
                    Origin = DoorPanelMiddle.StartPoint + new TSG.Point(0,0,modelparameters.WeldOffset),
                    AxisY = new TSG.Vector(0, modelparameters.BillboardDepth, 0),
                    AxisX = new TSG.Vector(-modelparameters.BillboardHeight, 0, 0)
                }
            };
            CutPlaneTopbottom.Father = DoorPanelBrcingtop;
            if (!CutPlaneTopbottom.Insert()) { MessageBox.Show("Door panel upper bracing cut failed"); }

            // Create and insert bottom bracing in door panel 
            Beam DoorPanelBracingbottom = DoorPanelBeam();
            DoorPanelBracingbottom.StartPoint = new TSG.Point(
                DoorPanelMiddle.StartPoint.X,
                DoorPanelMiddle.StartPoint.Y,
                DoorPanelMiddle.StartPoint.Z - DoorPanelBeamHeight);
            DoorPanelBracingbottom.EndPoint = new TSG.Point(
                DoorPanelBottom.EndPoint.X,
                DoorPanelBottom.EndPoint.Y,
                DoorPanelBottom.EndPoint.Z);

            DoorPanelBracingbottom.StartPoint.X += Xchange;
            DoorPanelBracingbottom.StartPoint.Z += Zchange;

            if (!DoorPanelBracingbottom.Insert()) { MessageBox.Show("Insertion of door panel bracing failed"); }
            DoorParts.Add(DoorPanelBracingbottom);

            CutPlane CutPlaneBottomtop = new CutPlane
            {
                Plane = new Plane
                {
                    Origin = DoorPanelMiddle.StartPoint - new TSG.Point(0, 0, DoorPanelBeamHeight  + modelparameters.WeldOffset),
                    AxisY = new TSG.Vector(0, modelparameters.BillboardDepth, 0),
                    AxisX = new TSG.Vector(modelparameters.BillboardHeight, 0, 0)
                }
            };
            CutPlaneBottomtop.Father = DoorPanelBracingbottom;
            if (!CutPlaneBottomtop.Insert()) { MessageBox.Show("Door panel lower bracing cut failed"); }

            CutPlane CutPlaneBottombottom = new CutPlane
            {
                Plane = new Plane
                {
                    Origin = DoorPanelBottom.EndPoint + new TSG.Point(0, 0, modelparameters.WeldOffset),
                    AxisY = new TSG.Vector(0, modelparameters.BillboardDepth, 0),
                    AxisX = new TSG.Vector(-modelparameters.BillboardHeight, 0, 0)
                }
            };
            CutPlaneBottombottom.Father = DoorPanelBracingbottom;
            if (!CutPlaneBottombottom.Insert()) { MessageBox.Show("Door panel upper bracing cut failed"); }

            ContourPlate DoorConnectionPlate = DoorConnection();
            ContourPoint PlateBottomLeft = new ContourPoint(
                new TSG.Point(
                    DoorFrameRight.StartPoint.X,
                    DoorPanelRight.StartPoint.Y + DoorPanelBeamWidth/2 + (DoorFrameBeamWidth - DoorPanelBeamWidth)/4, 
                    DoorPanelTop.EndPoint.Z - DoorPanelBeamHeight), 
                null);
            ContourPoint PlateBottomRight = new ContourPoint(
                new TSG.Point(
                    DoorPanelRight.EndPoint.X, 
                    PlateBottomLeft.Y, 
                    PlateBottomLeft.Z), 
                null);
            ContourPoint PlateTopRight = new ContourPoint(
                new TSG.Point(
                    PlateBottomRight.X, 
                    PlateBottomRight.Y, 
                    DoorFrameRight.EndPoint.Z), 
                null);
            ContourPoint PlateTopLeft = new ContourPoint(
                new TSG.Point(
                    PlateBottomLeft.X, 
                    PlateBottomLeft.Y, 
                    PlateTopRight.Z), 
                null);
            DoorConnectionPlate.AddContourPoint(PlateBottomLeft);
            DoorConnectionPlate.AddContourPoint(PlateBottomRight);
            DoorConnectionPlate.AddContourPoint(PlateTopRight);
            DoorConnectionPlate.AddContourPoint(PlateTopLeft);

            if (!DoorConnectionPlate.Insert()) { MessageBox.Show("Insertion of door connection plate failed"); }
            DoorParts.Add(DoorConnectionPlate);


            foreach (Beam BeamCut in BeamCutted)
            {
                Beam FillingBeamB3 = FillingBeam();
                FillingBeamB3.StartPoint = new TSG.Point(
                    DoorFrameRight.StartPoint.X + DoorFrameBeamHeight + modelparameters.WeldOffset,
                    modelparameters.BillboardDepth -  B3BeamWidth/2,
                    BeamCut.StartPoint.Z + B3BeamHeight/2);
                FillingBeamB3.EndPoint = BeamCut.EndPoint;
                FillingBeamB3.EndPoint.X -= modelparameters.WeldOffset;
                FillingBeamB3.EndPoint.Y = FillingBeamB3.StartPoint.Y;
                FillingBeamB3.EndPoint.Z += B3BeamHeight/2;
                if (! (RightFrameReplace || LeftFrameReplace))
                {
                    if (!FillingBeamB3.Insert()) { MessageBox.Show("Insertion of filling beam C3 failed"); }
                    DoorParts.Add(FillingBeamB3);
                }
                TSG.Point origin = new TSG.Point();
                TSG.Vector axisy = new TSG.Vector();
                TSG.Vector axisx = new TSG.Vector();
                if (LeftFrameReplace) {
                    origin = DoorFrameRight.StartPoint + new TSG.Point(modelparameters.WeldOffset  + DoorFrameBeamHeight , 0, 0);
                    axisy.X = 0;
                    axisy.Y = modelparameters.BillboardDepth;
                    axisy.Z = 0;
                    axisx.X = 0;
                    axisx.Y = 0;
                    axisx.Z = modelparameters.BillboardDepth;
                }
                else
                {
                    origin = DoorFrameLeft.StartPoint + new TSG.Point(-modelparameters.WeldOffset, 0, 0);
                    axisy.X = 0; 
                    axisy.Y = - modelparameters.BillboardDepth; 
                    axisy.Z = 0;
                    axisx.X = 0; 
                    axisx.Y = 0;
                    axisx.Z = modelparameters.BillboardDepth;
                }
                
                CutPlane CutPlaneB3 = new CutPlane
                {
                    Plane = new Plane
                    {
                        Origin = origin,
                        AxisY = axisy,
                        AxisX = axisx
                    },
                };

                CutPlaneB3.Father = BeamCut;
                if (!CutPlaneB3.Insert()) { MessageBox.Show("Door plane cut failed"); }
            }


            return DoorParts;
        }
    }
}
