using System.Windows.Forms;
using System.Collections.Generic;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;
using System;
using System.Linq;
using TeklaBillboardAid;
using static Tekla.Structures.Filtering.Categories.PartFilterExpressions;
using Tekla.Structures.Datatype;
using System.Collections;

namespace TeklaBillboardAid
{
    public class Curve_Box
    {
        private Assembly _boxAssembly = new Assembly();

        /* Figure 1. Representation of a single plane of the box (front view)
                            side 3
                       _________________
                    3 |                 | 4
             side 2   |                 |   side 4
                      |_________________|
                    2                     1
                            side 1
        // side == True Means there's a split
        // side == False Means there's an edge
        */
        /// <summary>
        /// The constructor for a box, which generates a model section in the billboard.
        /// </summary>
        /// <param name="xSubCoordinates">The horizontal distances of where vertical columns go</param>
        /// <param name="boxHeight">The height of the box</param>
        /// <param name="OriginOffset">A TSG point reference for the position of the box</param>
        /// <param name="modelParameters">The parameters of the model</param>
        /// TODO Desc for additional hatch related parameters
        public Curve_Box
            (
            List<double> xSubCoordinates,
            double boxHeight,
            TSG.Point OriginOffset,
            ModelParameters modelParameters
            )
        {
            // Create a list of x coordinates for the planes / spacings between the columns from engineering drawings
            List<double> xCoordinates = xSubCoordinates;

            double B1BeamDepth = modelParameters.B1BeamDepth;

            double billboardDepth = modelParameters.BillboardDepth;

            // Figure out the starting and end height of the frame
            double boxZStart;
            double boxZEnd;

            boxZStart = -modelParameters.HeightOffsetBottom;

            boxZEnd = boxHeight + modelParameters.HeightOffsetTop + B1BeamDepth;

            // Create the Bottom Beam with which we're going to cut the front beams. But only if the B1 Split Beam is an EA beam.
            PolyBeam cutBeamBottom = new PolyBeam();
            PolyBeam cutBeamTop = new PolyBeam();

            PolyBeam B1Beam1 = new PolyBeam();
            PolyBeam B1Beam2 = new PolyBeam();
            PolyBeam B1Beam3 = new PolyBeam();
            PolyBeam B1Beam4 = new PolyBeam();

            (B1Beam1, B1Beam2, B1Beam3, B1Beam4) = Curve_HorizontalBeam.CurveHorizontalBeams(
                modelParameters
                );

            // Creating Frames
            List<Curve_Frame> planes = new List<Curve_Frame>(); // Storing each plane (of each x offset)

            // Loop through the indexes of the xCoordinates list to set identifying values for the planeType variable 
            // I.e. loops through integers from 0 to number of inputs in xCoordinates list 

            // New 
            // Plane == 1 -> First Plane
            // Plane == 2 -> Last Plane
            // Plane == 3 -> Middle Plane.
            // initial offset
            double xOffset = 0;
            for (int i = 0; i < xCoordinates.Count; i++)
            {
                bool splitPlaneRight = true;
                int planeType;

                if (i == 0)
                {
                    planeType = 1;
                }
                // Plane on right edge
                else if (i == xCoordinates.Count - 1)
                {
                    planeType = 2;
                }
                // Middle Plane
                else
                {
                    planeType = 3;
                }
                // Total offset for the current plane
                xOffset += xCoordinates[i];

                // The four points of a plane
                TSG.Point point1 = new TSG.Point(xOffset, 0, boxZStart) + OriginOffset;
                TSG.Point point2 = new TSG.Point(xOffset, billboardDepth, boxZStart) + OriginOffset;
                TSG.Point point3 = new TSG.Point(xOffset, billboardDepth, boxZEnd) + OriginOffset;
                TSG.Point point4 = new TSG.Point(xOffset, 0, boxZEnd) + OriginOffset;

                // Create a plane and store this plane
                Curve_Frame plane = null;
                plane = new Curve_Frame(splitPlaneRight, point1, point2, point3, point4, planeType, false, false, modelParameters, cutBeamBottom, cutBeamTop);
                
                planes.Add(plane);

            }


            // Save all the Part objects created in frame generation to the list.
            List<Part> FrameParts = new List<Part>();

            foreach (Curve_Frame Plane in planes)
            {
                if (Plane.Top != null)
                {
                    FrameParts.Add(Plane.Top);
                }

                if (Plane.Bottom != null)
                {
                    FrameParts.Add(Plane.Bottom);
                }

                FrameParts.Add(Plane.Back);
                FrameParts.Add(Plane.Front);

                if (Plane.Seatplate != null)
                {
                    FrameParts.Add(Plane.Seatplate);
                }
            }

            // THIS CODE IS FOR THE WALERS //
            List<Part> Walers = new List<Part>();

            // From the bottom of the billboard to the top of the bottom waler
            double bottomWalerSpacing = modelParameters.LowerWalerSpacing;
            // From the top of the billboard to the top of the uppermost waler
            double topWalerSpacing = modelParameters.UpperWalerSpacing;

            // Spacing is from the top edge of the lower waler to the top edge of the waler above
            List<double> walermiddleSpacings = modelParameters.WalersCoordinates;

            // Initialise a z coordinate fot the middle walers
            double walerZcoordinate = boxZStart + bottomWalerSpacing;

            // Create a list for the z-coordinates of the walers so that they can be used in the insertion of the z-brackets (coordinates from bottom to top)
            List<double> zCoordinatesForZBrackets = new List<double> { walerZcoordinate, boxZEnd - topWalerSpacing };
            // List<double> zCoordinatesForZBrackets = new List<double> { walerZcoordinate, modelParameters.ScreenHeight - topWalerSpacing};

            if (!modelParameters.WalerAuto)
            {
                for (int walerSpacingIndex = 0; walerSpacingIndex <= walermiddleSpacings.Count - 1; walerSpacingIndex++)
                {
                    // Update the z coordinate
                    walerZcoordinate += walermiddleSpacings[walerSpacingIndex];

                    // Add the next waler z-coordinate into the z-coordinate list for the z brackets
                    zCoordinatesForZBrackets.Add(walerZcoordinate);
                }
            }
            else
            {
                // Calculating the distance between the top and bottom waler
                double topBottomWalerSpacing = boxZEnd - boxZStart - bottomWalerSpacing - topWalerSpacing;

                // The number of middle walers to be added
                int numberOfWalers = modelParameters.WalersNumber;

                // Calculate the spacing between the walers
                double walerBeamSpacing = topBottomWalerSpacing / (numberOfWalers + 1);

                // Loop through the number of walers
                for (int i = 0; i < numberOfWalers; i++)
                {
                    // Update the z coordinate
                    walerZcoordinate += walerBeamSpacing;

                    // Add the next waler z-coordinate into the z-coordinate list for the z brackets
                    zCoordinatesForZBrackets.Add(walerZcoordinate);
                }
            }

            Walers.AddRange(Waler.Walers_Curve(zCoordinatesForZBrackets, modelParameters));

            // THIS CODE IS FOR THE Z BRACKETS // 
            List<Part> ZBracketsCurve = new List<Part>();

            ZBracketsCurve.AddRange(ZBracket.ZBracketsCurve(xSubCoordinates, OriginOffset, planes, zCoordinatesForZBrackets, modelParameters));

            // THIS CODE IS FOR THE HORIZONTAL RAILINGS and SIDE BRACING //
            List<Part> HorizontalRailingsBeams = new List<Part>();
            List<Part> SideBracingBeams = new List<Part>();

            var Railings = Curve_HorizontalRailings.CurveHorizontalRailings(modelParameters);

            SideBracingBeams.AddRange(Railings.Item1);
            HorizontalRailingsBeams.AddRange(Railings.Item2);
            
            // THIS CODE IS FOR THE Diagonal BRACING and CameraArm //
            List<Part> TopDiagonalBRACING = new List<Part>(); 
            List<Part> LeftDiagonalBRACING = new List<Part>();
            List<Part> RightDiagonalBRACING = new List<Part>();
            List<Part> BottomDiagonalBRACING = new List<Part>();

            var Diagonal = CurveDiagonal.DiagonalBracing(modelParameters);

            TopDiagonalBRACING.AddRange(Diagonal.Item1);
            LeftDiagonalBRACING.AddRange(Diagonal.Item2);
            RightDiagonalBRACING.AddRange(Diagonal.Item3);
            BottomDiagonalBRACING.AddRange(Diagonal.Item4);

            // ASSEMBLY ASSEMBLING:

            // Add the B1 beams into the assembly.
            _boxAssembly = B1Beam1.GetAssembly();
            _boxAssembly.SetMainPart(B1Beam1);

            Assembly B1Beam2Assembly = B1Beam2.GetAssembly();
            B1Beam2Assembly.SetMainPart(B1Beam2);

            Assembly B1Beam3Assembly = B1Beam3.GetAssembly();
            B1Beam3Assembly.SetMainPart(B1Beam3);

            Assembly B1Beam4Assembly = B1Beam4.GetAssembly();
            B1Beam4Assembly.SetMainPart(B1Beam4);

            _boxAssembly.Add(B1Beam2Assembly);
            _boxAssembly.Add(B1Beam3Assembly);
            _boxAssembly.Add(B1Beam4Assembly);

            // Add the beams created for side bracing to the assembly.
            //AddBeamsToAssembly(SideBraces);

            // Add the frame parts to the assembly.
            AddBeamsToAssembly(FrameParts);
            AddBeamsToAssembly(Walers);
            AddBeamsToAssembly(ZBracketsCurve);
            AddBeamsToAssembly(HorizontalRailingsBeams);
            AddBeamsToAssembly(SideBracingBeams);
            AddBeamsToAssembly(TopDiagonalBRACING);
            AddBeamsToAssembly(LeftDiagonalBRACING);
            AddBeamsToAssembly(RightDiagonalBRACING);
            AddBeamsToAssembly(BottomDiagonalBRACING);

            if (!_boxAssembly.Modify())
            {
                MessageBox.Show("Box assembly failed!");
            }
        }

        private void AddBeamsToAssembly(List<Part> Parts)
        {
            foreach (Part P in Parts)
            {
                Assembly PartAssembly = P.GetAssembly();
                PartAssembly.SetMainPart(P);

                _boxAssembly.Add(PartAssembly);
            }
        }
    }
}