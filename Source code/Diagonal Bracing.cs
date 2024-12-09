using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Class to support modeling of diagonal bracings in Tekla Structures.
    /// </summary>
    public class Diagonal
    {
        /// <value>
        /// Refers to the beam left of the camera arm
        /// </value>
        public static Beam CameraArmLeft { get; private set; }

        /// <value>
        /// Refers to the beam right of the camera arm
        /// </value>
        public static Beam CameraArmRight { get; private set; }

        /// <value>
        /// Refers to the camera arm itself
        /// </value>
        public static CameraArm CameraArm { get; private set; }

        /// <summary>
        /// The constructor for a diagonal bracing, generating a diagonl beam in the model
        /// </summary>
        /// <param name="xSubCoordinates">A list of doubles, indicating the distances between horizontal beams in the model</param>
        /// <param name="seperatorBeamWidth">A double indicating the beam width of a separator</param>
        /// <param name="seperatorSplitBeamWidth">A double indicating the the beam width of the separator split</param>
        /// <param name="OriginOffset">A TSG point indicating the offset of the diagonal member from the origin</param>
        /// <param name="modelParameters">The parameters of the model</param>
        /// <param name="ZCoordinate">The vertical distance of the beam</param>
        /// <param name="diagonalOffset">A double offset for the diagonal member </param>
        /// <param name="side2">A boolean indicating if the left side of the billboard is being mentioned</param>
        /// <param name="side4">A boolean indicating if the right side of the billboard is being mentioned</param>
        /// <param name="Camera">A boolean indicating if the camera arm is to be inserted</param>
        /// <param name="EASupports">A boolean indicating if an EA support is to be inserted</param>
        /// 
        /// <returns> A list of Beam objects created </returns>
        public static List<Beam> DiagonalBracing
            (
                List<double> xSubCoordinates,
                double seperatorBeamWidth,
                double seperatorSplitBeamWidth,
                TSG.Point OriginOffset,
                ModelParameters modelParameters,
                double diagonalOffset,
                double ZCoordinate,
                bool side2,
                bool side4,
                bool Camera,
                bool EASupports
            )
        {
            List<Beam> BeamsCreated = new List<Beam>();
            /*
            *                 p
            *     ----------------------
            *     |        (theta)   / |
            *     |              /     |     
            *     |          /         |   q  
            *   | |      /             |    
            *  K| |  /                 |     
            *   | ----------------------
            *
            */
            double B1BeamWidth = modelParameters.B1BeamWidth;
            double B1BeamDepth = modelParameters.B1BeamDepth;
            double BR1BeamDepth = modelParameters.BR1BeamDepth;
            double BR1BeamWidth = modelParameters.BR1BeamWidth;
            double BillboardDepth = modelParameters.BillboardDepth;
            double WeldOffSet = modelParameters.WeldOffset;
            List<double> XCoordinates = xSubCoordinates;

            // THIS CODE IS FOR THE DIAGONALS //
            // Initialise the spacing variables for the diagonal 
            double xCurrentPlane = 0;
            double xNextPlane;

            // Create enums and offsets for diagonals 
            int[] diagonalEnums = new int[] { 2, 1, 2 };
            double[] topDiagonalOffsets = new double[] { 0.0, 0.0, 90 };

            // Create dimensional variables that can be used to calculate the welding offset
            double br1CornerWeldOffset = modelParameters.CornerOffset;

            /*
                             p
                 ----------------------
                 |        (theta)   / |
                 |              /     |     
                 |          /         |   q  
               | |      /             |    
              K| |  /                 |     
               | ----------------------
            
            */

            List<double> zCoordinateDiagonals = new List<double> { 0 - (B1BeamDepth - BR1BeamDepth) - BR1BeamDepth, modelParameters.BillboardHeight - B1BeamDepth - BR1BeamDepth };
            double DiagonalOffset = modelParameters.DiagonalBottomOffset;

            double bottomtopDiagonalOffset = DiagonalOffset;

            //double bottomDiagonalOffset = modelParameters.DiagonalBottomOffset;

            // Loop through the integers 0 to the length of the XCoordinates array less 1 
            for (int indexXCoordinatesNew = 0; indexXCoordinatesNew < (XCoordinates.Count - 1); indexXCoordinatesNew++)
            {
                // Calculate the current x coordinate and the next x coordinate using the spacings 
                xCurrentPlane += XCoordinates[indexXCoordinatesNew];
                xNextPlane = xCurrentPlane + XCoordinates[indexXCoordinatesNew + 1];

                TSG.Point startPos;
                TSG.Point endPos;

                // Insert the BR1 beams at the designated Z plane
                // Check to see if it is the first diagonal, since the first cabinet has smaller dimensions 
                List<Beam> CameraArmBeams = null;
                if (indexXCoordinatesNew == 0)
                {
                    double leftBottomBeamWidth = seperatorBeamWidth;
                    double rightBottomBeamWidth = seperatorBeamWidth;

                    // Check if the left side is a split,
                    if (side2)
                    {
                        leftBottomBeamWidth = seperatorSplitBeamWidth;

                        startPos = new TSG.Point(
                            xCurrentPlane + leftBottomBeamWidth + WeldOffSet + modelParameters.BoxGap,
                            B1BeamWidth + br1CornerWeldOffset,
                            ZCoordinate + diagonalOffset
                        );
                    }
                    else
                    {
                        startPos = new TSG.Point(
                            xCurrentPlane - modelParameters.C1BeamWidth / 2 + leftBottomBeamWidth + WeldOffSet,
                            B1BeamWidth + br1CornerWeldOffset,
                            ZCoordinate + diagonalOffset
                        );
                    }
                    if (side4 && indexXCoordinatesNew == XCoordinates.Count - 2)
                    {
                        rightBottomBeamWidth = seperatorSplitBeamWidth;
                    }

                    TSG.Point otherEnd = new TSG.Point(
                        xNextPlane - rightBottomBeamWidth / 2 - WeldOffSet,
                        modelParameters.BillboardDepth - B1BeamWidth - br1CornerWeldOffset,
                        ZCoordinate + diagonalOffset
                        );

                    double a = Math.Sqrt(Math.Pow(otherEnd.X - startPos.X, 2) + Math.Pow(otherEnd.Y - startPos.Y, 2));
                    double phi = Math.Asin(BR1BeamWidth / a);
                    double theta = Math.Atan((otherEnd.Y - startPos.Y) / (otherEnd.X - startPos.X));
                    double alpha = theta - phi;
                    double deltaX = BR1BeamWidth * Math.Sin(alpha);
                    double deltaY = BR1BeamWidth * Math.Cos(alpha);

                    endPos = otherEnd + new TSG.Point(deltaX, -deltaY, 0);


                    // Generate a plane which will cut the diagonal top beam on the right side.
                    // Allocate an origin to the plane and set the x and y vectors along the side of the B2 beam.
                    CutPlane CutPlaneTop1 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = startPos + OriginOffset,
                            AxisY = new TSG.Vector(0, BillboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, BR1BeamDepth)
                        },
                    };

                    // Generate a plane which will cut the diagonal top beam on the left side.
                    // Allocate an origin to the plane and set the x and y vectors along the side of the B2 beam.
                    CutPlane CutPlaneTop2 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(xNextPlane - rightBottomBeamWidth / 2 - WeldOffSet, 0, 0) + OriginOffset,
                            AxisY = new TSG.Vector(0, BillboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, -1 * BR1BeamDepth)
                        },
                    };

                    // Create the diagonal beam at the top, for the first cabinet
                    Beam br1Top = Box.CreateBeam(Prefix.part, Prefix.assembly,
                        startPos + OriginOffset,
                        endPos + OriginOffset,
                        modelParameters.BR1Material,
                        modelParameters.BR1Profile,
                        "7",
                        diagonalEnums,
                        topDiagonalOffsets
                        );

                    BeamsCreated.Add(br1Top);

                    CutPlaneTop1.Father = br1Top;
                    CutPlaneTop1.Insert();
                    CutPlaneTop2.Father = br1Top;
                    CutPlaneTop2.Insert();

                    // Insert Camera Arm
                    if (modelParameters.ArmOffset >= xCurrentPlane + OriginOffset.X && modelParameters.ArmOffset < xNextPlane + OriginOffset.X && Camera)
                    {
                        CameraArmBeams = CameraFinder
                            (
                                xCurrentPlane,
                                xNextPlane,
                                startPos,
                                endPos,
                                modelParameters,
                                ZCoordinate,
                                diagonalOffset,
                                OriginOffset,
                                BillboardDepth
                            );

                        Diagonal.CameraArm = new CameraArm("SHS75*75*4.0", "C350L0", modelParameters);
                    }
                }

                // Check to see if it is the final diagonal on the final cabinets, similar to the first one. 
                else if (indexXCoordinatesNew == XCoordinates.Count - 2)
                {
                    double leftBottomBeamWidth = seperatorBeamWidth;
                    double rightBottomBeamWidth = seperatorBeamWidth;

                    TSG.Point otherEnd = new TSG.Point();
                    if (side4)
                    {
                        rightBottomBeamWidth = seperatorSplitBeamWidth;

                        otherEnd = new TSG.Point(
                        xNextPlane - rightBottomBeamWidth - WeldOffSet - modelParameters.BoxGap,
                        modelParameters.BillboardDepth - B1BeamWidth - br1CornerWeldOffset,
                        ZCoordinate + diagonalOffset
                        );
                    }
                    else
                    {
                        otherEnd = new TSG.Point(
                        xNextPlane - rightBottomBeamWidth / 2 - WeldOffSet,
                        modelParameters.BillboardDepth - B1BeamWidth - br1CornerWeldOffset,
                        ZCoordinate + diagonalOffset
                        );
                    }
                    if (side2 && indexXCoordinatesNew == 0)
                    {
                        leftBottomBeamWidth = seperatorSplitBeamWidth;
                    }

                    startPos = new TSG.Point(
                        xCurrentPlane + leftBottomBeamWidth / 2 + WeldOffSet,
                        B1BeamWidth + br1CornerWeldOffset,
                        ZCoordinate + diagonalOffset
                        );

                    double a = Math.Sqrt(Math.Pow(otherEnd.X - startPos.X, 2) + Math.Pow(otherEnd.Y - startPos.Y, 2));
                    double phi = Math.Asin(BR1BeamWidth / a);
                    double theta = Math.Atan((otherEnd.Y - startPos.Y) / (otherEnd.X - startPos.X));
                    double alpha = theta - phi;
                    double deltaX = BR1BeamWidth * Math.Sin(alpha);
                    double deltaY = BR1BeamWidth * Math.Cos(alpha);

                    endPos = otherEnd + new TSG.Point(deltaX, -deltaY, 0);

                    // Generate a plane which will cut the diagonal top beam on the right side.
                    // Allocate an origin to the plane and set the x and y vectors along the side of the B2 beam.
                    CutPlane CutPlaneTop1 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = startPos + OriginOffset,
                            AxisY = new TSG.Vector(0, BillboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, BR1BeamDepth)
                        },
                    };

                    // Generate a plane which will cut the diagonal top beam on the left side.
                    // Allocate an origin to the plane and set the x and y vectors along the side of the B2 beam.
                    CutPlane CutPlaneTop2 = new CutPlane();
                    if (side4)
                    {
                        CutPlaneTop2 = new CutPlane
                        {
                            Plane = new Plane
                            {
                                Origin = new TSG.Point(xNextPlane - rightBottomBeamWidth - WeldOffSet - modelParameters.BoxGap, 0, 0) + OriginOffset,
                                AxisY = new TSG.Vector(0, BillboardDepth, 0),
                                AxisX = new TSG.Vector(0, 0, -1 * BR1BeamDepth)
                            },
                        };
                    }
                    else
                    {
                        CutPlaneTop2 = new CutPlane
                        {
                            Plane = new Plane
                            {
                                Origin = new TSG.Point(xNextPlane - rightBottomBeamWidth / 2 - WeldOffSet, 0, 0) + OriginOffset,
                                AxisY = new TSG.Vector(0, BillboardDepth, 0),
                                AxisX = new TSG.Vector(0, 0, -1 * BR1BeamDepth)
                            },
                        };
                    }

                    // Create the diagonal beam at the top, for the first cabinet
                    Beam br1Top = Box.CreateBeam(Prefix.part, Prefix.assembly,
                        startPos + OriginOffset,
                        endPos + OriginOffset,
                        modelParameters.BR1Material,
                        modelParameters.BR1Profile,
                        "7",
                        diagonalEnums,
                        topDiagonalOffsets);

                    BeamsCreated.Add(br1Top);

                    CutPlaneTop1.Father = br1Top;
                    CutPlaneTop1.Insert();
                    CutPlaneTop2.Father = br1Top;
                    CutPlaneTop2.Insert();

                    // Insert Camera Arm
                    if (modelParameters.ArmOffset >= xCurrentPlane + OriginOffset.X && modelParameters.ArmOffset < xNextPlane + OriginOffset.X && Camera)
                    {
                        CameraArmBeams = CameraFinder
                            (
                                xCurrentPlane,
                                xNextPlane,
                                startPos,
                                endPos,
                                modelParameters,
                                ZCoordinate,
                                diagonalOffset,
                                OriginOffset,
                                BillboardDepth
                            );

                        Diagonal.CameraArm = new CameraArm("SHS75*75*4.0", "C350L0", modelParameters);
                    }
                }

                // Check to see if the beams been constructed are the middle diagonals of the billboard
                else
                {
                    // The left and right bottom beams should be the same profile and not a split
                    double bottomBeamWidth = seperatorBeamWidth;

                    startPos = new TSG.Point(
                        xCurrentPlane + bottomBeamWidth / 2 + WeldOffSet,
                        B1BeamWidth + br1CornerWeldOffset,
                        ZCoordinate + diagonalOffset
                        );

                    TSG.Point otherEnd = new TSG.Point(
                        xNextPlane - bottomBeamWidth / 2 - WeldOffSet,
                        modelParameters.BillboardDepth - B1BeamWidth - br1CornerWeldOffset,
                        ZCoordinate + diagonalOffset
                        );

                    double a = Math.Sqrt(Math.Pow(otherEnd.X - startPos.X, 2) + Math.Pow(otherEnd.Y - startPos.Y, 2));
                    double phi = Math.Asin(BR1BeamWidth / a);
                    double theta = Math.Atan((otherEnd.Y - startPos.Y) / (otherEnd.X - startPos.X));
                    double alpha = theta - phi;
                    double deltaX = BR1BeamWidth * Math.Sin(alpha);
                    double deltaY = BR1BeamWidth * Math.Cos(alpha);

                    endPos = otherEnd + new TSG.Point(deltaX, -deltaY, 0);

                    // Generate a plane which will cut the diagonal top beam on the right side.
                    // Allocate an origin to the plane and set the x and y vectors along the side of the B2 beam.
                    CutPlane CutPlaneTop1 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = startPos + OriginOffset,
                            AxisY = new TSG.Vector(0, BillboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, BR1BeamDepth)
                        },
                    };

                    // Generate a plane which will cut the diagonal top beam on the left side.
                    // Allocate an origin to the plane and set the x and y vectors along the side of the B2 beam.
                    CutPlane CutPlaneTop2 = new CutPlane
                    {
                        Plane = new Plane
                        {
                            Origin = new TSG.Point(xNextPlane - bottomBeamWidth / 2 - WeldOffSet, 0, 0) + OriginOffset,
                            AxisY = new TSG.Vector(0, BillboardDepth, 0),
                            AxisX = new TSG.Vector(0, 0, -1 * BR1BeamDepth)
                        },
                    };

                    // Create the diagonal beam at the top, for the first cabinet
                    Beam br1Top = Box.CreateBeam(Prefix.part, Prefix.assembly,
                        startPos + OriginOffset,
                        endPos + OriginOffset,
                        modelParameters.BR1Material,
                        modelParameters.BR1Profile,
                        "7",
                        diagonalEnums,
                        topDiagonalOffsets);

                    BeamsCreated.Add(br1Top);

                    CutPlaneTop1.Father = br1Top;
                    CutPlaneTop1.Insert();
                    CutPlaneTop2.Father = br1Top;
                    CutPlaneTop2.Insert();

                    // Insert Camera Arm
                    if (modelParameters.ArmOffset >= xCurrentPlane + OriginOffset.X && modelParameters.ArmOffset < xNextPlane + OriginOffset.X && Camera)
                    {
                        CameraArmBeams = CameraFinder
                            (
                                xCurrentPlane,
                                xNextPlane,
                                startPos,
                                endPos,
                                modelParameters,
                                ZCoordinate,
                                diagonalOffset,
                                OriginOffset,
                                BillboardDepth
                            );

                        Diagonal.CameraArm = new CameraArm("SHS75*75*4.0", "C350L0", modelParameters);

                    }
                }

                if (CameraArmBeams != null)
                {
                    BeamsCreated.AddRange(CameraArmBeams);
                }

                if (EASupports)
                {
                    BeamsCreated.AddRange(
                        BetterEASupport.BetterEASupports(
                            ZCoordinate + seperatorBeamWidth,
                            xCurrentPlane,
                            xNextPlane,
                            startPos,
                            endPos,
                            br1CornerWeldOffset,
                            OriginOffset,
                            modelParameters
                        )
                    );
                }
            }

            return BeamsCreated;
        }

        /// <summary>
        /// A standalone method separated from the constructor to create one diagaonal beam.
        /// </summary>
        /// <param name="Start"> Start point </param>
        /// <param name="End"> End point </param>
        /// <param name="OriginOffset"> A TSG point indicating the offset of the diagonal member from the origin </param>
        /// <param name="modelParameters"> The parameters of the model </param>
        /// <param name="BeamProfile"> The profile of beam to create </param>
        /// <param name="BeamMaterial"> The material for the beam </param>
        /// <param name="BeamDepth"> The depth of the beam </param>
        /// <param name="BeamWidth"> The width of the beam </param>
        /// <returns> The Beam object created </returns>
        public static Beam CreateDiagonalBeam(TSG.Point Start, TSG.Point End, TSG.Point OriginOffset, ModelParameters modelParameters, String BeamProfile, String BeamMaterial, double BeamDepth, double BeamWidth)
        {
            double xCurrentPlane = Start.X;
            double xNextPlane = End.X;
            double BillboardDepth = modelParameters.BillboardDepth;
            double WeldOffSet = modelParameters.WeldOffset;
            double diagonalOffset = modelParameters.DiagonalBottomOffset;
            double ZCoordinate = Start.Z;

            // Create enums and offsets for diagonals 
            int[] diagonalEnums = new int[] { 0, 1, 0 };
            double[] topDiagonalOffsets = new double[] { 0.0, 0.0, 0.0 };

            // The left and right bottom beams should be the same profile and not a split
            double bottomBeamWidth = 0;

            TSG.Point startPos = new TSG.Point(
                xCurrentPlane + WeldOffSet,
                0 + modelParameters.CornerOffset,
                ZCoordinate + diagonalOffset
                );


            double XLength = End.X - Start.X;
            double YLength = End.Y - Start.Y;
            double theta = Math.Atan(YLength/XLength);

            TSG.Point endPos =  new TSG.Point(
                End.X + BeamDepth * Math.Sin(theta) - WeldOffSet,
                End.Y - BeamDepth * Math.Cos(theta) - WeldOffSet - modelParameters.CornerOffset,
                ZCoordinate
                );

            // Generate a plane which will cut the diagonal top beam on the right side.
            // Allocate an origin to the plane and set the x and y vectors along the side of the B2 beam.
            CutPlane CutPlaneTop1 = new CutPlane
            {
                Plane = new Plane
                {
                    Origin = startPos + OriginOffset,
                    AxisY = new TSG.Vector(0, BillboardDepth, 0),
                    AxisX = new TSG.Vector(0, 0, BeamDepth)
                },
            };

            // Generate a plane which will cut the diagonal top beam on the left side.
            // Allocate an origin to the plane and set the x and y vectors along the side of the B2 beam.
            CutPlane CutPlaneTop2 = new CutPlane
            {
                Plane = new Plane
                {
                    Origin = new TSG.Point(xNextPlane - bottomBeamWidth / 2 - WeldOffSet, 0, 0) + OriginOffset,
                    AxisY = new TSG.Vector(0, BillboardDepth, 0),
                    AxisX = new TSG.Vector(0, 0, -1 * BeamDepth)
                },
            };

            Beam Diagonal = Box.CreateBeam(Prefix.part, Prefix.assembly,
                startPos + OriginOffset,
                endPos,
                BeamMaterial,
                BeamProfile,
                "7",
                diagonalEnums,
                topDiagonalOffsets);

            CutPlaneTop1.Father = Diagonal;
            CutPlaneTop1.Insert();
            CutPlaneTop2.Father = Diagonal;
            CutPlaneTop2.Insert();

            return Diagonal;
        }

        /// <summary>
        /// Finds appropriate location to build the camera arm based on user-input position offset, then constructs the required support beams around that position
        /// </summary>
        /// <param name="xCurrentPlane">X-coordinate of the current frame</param>
        /// <param name="xNextPlane">X-coordinate of the next frame</param>
        /// <param name="startPos">Start position of the diagonal bracing beam between current and next frame</param>
        /// <param name="endPos">End position of the diagonal bracing beam between current and next frame</param>
        /// <param name="modelParameters">Model parameters</param>
        /// <param name="ZCoordinate">Current height Z-coordinate</param>
        /// <param name="diagonalOffset">Offset for diagonal bracings</param>
        /// <param name="OriginOffset">Origin point of the current box</param>
        /// <param name="BillboardDepth">Depth (Y-length) of the billboard</param>
        /// TODO Description for return
        public static List<Beam> CameraFinder(
            double xCurrentPlane,
            double xNextPlane,
            TSG.Point startPos,
            TSG.Point endPos,
            ModelParameters modelParameters,
            double ZCoordinate,
            double diagonalOffset,
            TSG.Point OriginOffset,
            double BillboardDepth
            )
        {
            List<Beam> BeamsCreated = new List<Beam>();

            int[] diagonalEnums = new int[] { 2, 1, 2 };
            double[] topDiagonalOffsets = new double[] { 0.0, 0.0, 90 };

            double theta = Math.Atan((endPos.Y - startPos.Y) / (endPos.X - startPos.X));

            Plane cameraPlane = new Plane
            {
                Origin = startPos + OriginOffset + new TSG.Point(Math.Sin(theta) * modelParameters.WeldOffset, -Math.Cos(theta) * modelParameters.WeldOffset, 0),
                AxisY = new TSG.Vector(0, 0, -1),
                AxisX = new TSG.Vector(Math.Cos(theta), Math.Sin(theta), 0)
            };

            double BeamWidth = modelParameters.ArmAtTop ? modelParameters.B2BeamWidth : modelParameters.B5BeamWidth;

            bool makeRight = true;
            if (modelParameters.ArmOffset < xCurrentPlane + OriginOffset.X + (200 / Math.Tan(theta)) + 100 + BeamWidth / 2 + modelParameters.WeldOffset)
            {
                // Pushes to Right
                modelParameters.ArmOffset = xCurrentPlane + OriginOffset.X + (200 / Math.Tan(theta) + 100 + BeamWidth / 2 + modelParameters.WeldOffset);
            }
            else if (modelParameters.ArmOffset > xNextPlane + OriginOffset.X - 100 - BeamWidth / 2)
            {
                // Pushes to Left
                modelParameters.ArmOffset = xNextPlane + OriginOffset.X - 100 - BeamWidth / 2;
                makeRight = false;
            }

            // Support Beam on the right side.
            if (makeRight)
            {
                Beam right = Box.CreateBeam(Prefix.part, Prefix.assembly,
                    new TSG.Point(
                        modelParameters.ArmOffset + 100 + modelParameters.BR1BeamWidth,
                        modelParameters.B1BeamWidth + modelParameters.WeldOffset,
                        ZCoordinate + diagonalOffset + OriginOffset.Z
                        ),
                    new TSG.Point(
                        modelParameters.ArmOffset + 100 + modelParameters.BR1BeamWidth,
                        modelParameters.B1BeamWidth + modelParameters.WeldOffset + BillboardDepth,
                        ZCoordinate + diagonalOffset + OriginOffset.Z
                        ),
                    modelParameters.BR1Material,
                    modelParameters.BR1Profile,
                    "7",
                    diagonalEnums,
                    topDiagonalOffsets);

                BeamsCreated.Add(right);

                CutPlane CameraCutPlane2 = new CutPlane();
                CameraCutPlane2.Plane = cameraPlane;
                CameraCutPlane2.Father = right;
                CameraCutPlane2.Insert();
                Diagonal.CameraArmRight = right;
            }

            // Support Beam on the left side
            Beam left = Box.CreateBeam(Prefix.part, Prefix.assembly,
                new TSG.Point(
                    modelParameters.ArmOffset - 100,
                    modelParameters.B1BeamWidth + modelParameters.WeldOffset,
                    ZCoordinate + diagonalOffset + OriginOffset.Z
                    ),
                new TSG.Point(
                    modelParameters.ArmOffset - 100,
                    modelParameters.B1BeamWidth + modelParameters.WeldOffset + BillboardDepth,
                    ZCoordinate + diagonalOffset + OriginOffset.Z
                    ),
                modelParameters.BR1Material,
                modelParameters.BR1Profile,
                "7",
                diagonalEnums,
                topDiagonalOffsets);
            Diagonal.CameraArmLeft = left;

            BeamsCreated.Add(left);

            // Support Beam behind the camera base plate.
            Beam behind = Box.CreateBeam(Prefix.part, Prefix.assembly,
                new TSG.Point(
                    modelParameters.ArmOffset - 100 + modelParameters.WeldOffset,
                    modelParameters.B1BeamWidth + modelParameters.WeldOffset + 200,
                    ZCoordinate + diagonalOffset + OriginOffset.Z
                    ),
                new TSG.Point(
                    modelParameters.ArmOffset + 100 - modelParameters.WeldOffset,
                    modelParameters.B1BeamWidth + modelParameters.WeldOffset + 200,
                    ZCoordinate + diagonalOffset + OriginOffset.Z
                    ),
                modelParameters.BR1Material,
                modelParameters.BR1Profile,
                "7",
                diagonalEnums,
                topDiagonalOffsets);

            BeamsCreated.Add(behind);

            CutPlane CameraCutPlane1 = new CutPlane();
            CameraCutPlane1.Plane = cameraPlane;
            CameraCutPlane1.Father = left;
            CameraCutPlane1.Insert();

            CutPlane CameraCutPlane3 = new CutPlane();
            CameraCutPlane3.Plane = cameraPlane;
            CameraCutPlane3.Father = behind;
            CameraCutPlane3.Insert();

            return BeamsCreated;
        }


        /// SIDE BRACING IMPLEMENTATION
        /// <summary>
        /// Install side bracing in uniform style ( same orientation and diagonal for both sides)
        /// Implemented for each box, scan if their sides matches the side position of the bill board - This is implemented in box.cs
        /// </summary> [INPUT PARAMETERS]
        /// ------------------------------------------------------------------------------
        /// <param name="HorizontalRailings">   
        /// <param name="modelParameters">      Model parameters</param>
        /// <param name="BoxHeight">            Height of box </param>
        /// <param name="BoxLength">            Length of box</param>
        /// <param name="BoxOriginPos">         Origin positio of the current box</param>
        /// <param name="SideCoords">           Coordinates of side of billboard on X-Axis </param>
        /// <param name="BottomSplit">          Boolean representing if BOTTOM of box is a split </param>
        /// <param name="TopSplit">             Boolean representing if TOP of box is a split </param>
        /// ------------------------------------------------------------------------------

        /// </summary> [OUTPUT]
        /// ------------------------------------------------------------------------------
        /// <param name="SideBrace">   list of Beam object representing Sidebracing</param>
        /// *This function returns the list to allow the beams added to assembly
        public static List<Beam> InstallSideBracing
            (List<Part> HorizontalRailings,
            ModelParameters modelParameters,
            double BoxLength,
            double BoxHeight,
            TSG.Point BoxOriginPos,
            double SideCoords,
            bool BottomSplit,
            bool TopSplit
            )
        {   // VARIABLES INITIALLISATION + ATTAINMENT
            //--------------------------------------------------------------//
            // List of object beam - Side Bracing - Return List
            List<Beam> SideBraces = new List<Beam>();

            double B2BeamDepth = modelParameters.B2BeamDepth;
            double BillBoardLength = modelParameters.BillboardLength;   // X

            // List of Z-spacing coordinates - Attain from List of Horizonal Ralings and box height 
            List<double> HorizonalEXTRACT = new List<double>();
            HorizonalEXTRACT.Add(BoxOriginPos.Z);               // First element is origin position of Box on Z axis
            List<double> ZSpacing = new List<double>();
            List<Beam> HorizontalBeams = new List<Beam>();

            // Now we loop through the railings list to OBTAIN the Z-SPACING Coordinates
            // Convert part to beam then add
            for (int i = 0; i < (HorizontalRailings.Count); i++)
            {
                HorizontalBeams.Add((Beam)HorizontalRailings[i]);
                HorizonalEXTRACT.Add(HorizontalBeams[i].EndPoint.Z);
            }
            HorizonalEXTRACT.Add(BoxHeight + BoxOriginPos.Z + B2BeamDepth / 2);

            ZSpacing = HorizonalEXTRACT.Distinct().ToList();
            //--------------------------------------------------------------//
            // MAIN PROCESS//
            //Check if the one of the sides of the box matches the X coordinates of the billboard size
            double left = BoxOriginPos.X;
            double right = BoxOriginPos.X + BoxLength;

            
            if (left == SideCoords) // Install on LEFT side
            {
                SideBraces.AddRange(BraceGenerate(ZSpacing, modelParameters, BoxLength, BoxHeight, BoxOriginPos, left, BottomSplit, TopSplit));
            }
            if (right == SideCoords)// Install on RIGHT side
            {
                SideBraces.AddRange(BraceGenerate(ZSpacing, modelParameters, BoxLength, BoxHeight, BoxOriginPos, right, BottomSplit, TopSplit));
            }
            //--------------------------------------------------------------//
            // END OF FUNCTION - RETURN THE LIST
            return SideBraces;
        }


        /// SIDE BRACING GENERATION
        /// <summary>
        /// Install side bracing in uniform style ( same orientation and diagonal for both sides)
        /// Implemented for each box, scan if their sides matches the side position of the bill board - This is implemented in box.cs
        /// </summary> [INPUT PARAMETERS]
        /// ------------------------------------------------------------------------------
        /// <param name="modelParameters">      Model parameters</param>
        /// <param name="BoxHeight">            Height of box </param>
        /// <param name="BoxLength">            Length of box</param>
        /// <param name="BoxOriginPos">         Origin positio of the current box</param>
        /// <param name="Side">                 Coordinates of side of billboard on X-Axis </param>
        /// <param name="BottomSplit">          Boolean representing if BOTTOM of box is a split </param>
        /// <param name="TopSplit">             Boolean representing if TOP of box is a split </param>
        /// ------------------------------------------------------------------------------

        /// </summary> [OUTPUT]
        /// ------------------------------------------------------------------------------
        /// <param name="SideBrace">   list of Beam object representing Sidebracing</param>
        /// *This function returns the list to allow the beams added to assembly
        private static List<Beam> BraceGenerate(List<Double> ZSpacing,
            ModelParameters modelParameters,
            double BoxLength,
            double BoxHeight,
            TSG.Point BoxOriginPos,
            double Side,
            bool BottomSplit,
            bool TopSplit
            )
        {
            //  B2,B3, B5, BR1, C1 and WalkwayMesh properties extraction

            double B2BeamWidth = modelParameters.B2BeamWidth;
            double B2BeamDepth = modelParameters.B2BeamDepth;

            double B3BeamWidth = modelParameters.B3BeamWidth;

            double B5BeamWidth = modelParameters.B5BeamWidth;
            double B5BeamDepth = modelParameters.B5BeamDepth;

            double BR1BeamDepth = modelParameters.BR1BeamDepth;
            double BR1BeamWidth = modelParameters.BR1BeamWidth;

            double C1BeamDepth = modelParameters.C1BeamDepth;
            double C1BeamWidth = modelParameters.C1BeamWidth;

            double br1CornerWeldOffset = modelParameters.CornerOffset;

            // Get Dimensions of the billboard
            double BillBoardLength = modelParameters.BillboardLength;   // X
            double BillBoardDepth = modelParameters.BillboardDepth;     // Y
            double BillBoardHeight = modelParameters.BillboardHeight;   // Z


            // VARIABLES FOR CALCULATIONS and BEAM GENERATION
            double XYBottomPlane = BoxOriginPos.Z;
            double XYTopPlane;

            // Offset calculations for end position
            double Length = 0;
            double phi = 0;
            double theta = 0;
            double alpha = 0;
            double deltaZ = 0;
            double deltaY = 0;

            // Point class for points used for cut planes
            TSG.Point bottomPlaneOffset = new TSG.Point();
            TSG.Point topPlaneOffset = new TSG.Point();

            // Starting and Ending coordinates
            double xStart, yStart, zStart;
            double xEnd, yEnd, zEnd;

            TSG.Point startPos = new TSG.Point();
            TSG.Point endPos = new TSG.Point();
            TSG.Point endPosOffset = new TSG.Point();

            // List of sidebraces to return - used for assembly purposes
            List<Beam> SideBraces2Return = new List<Beam>();

            // Create enums and offsets for diagonals - Use for creating beams
            int[] diagonalEnums = new int[] { 2, 1, 2 };
            double[] topDiagonalOffsets = new double[] { 0.0, 0.0, 0.0 };

            //Iterate ZSpacing
            for (int n = 0; n < (ZSpacing.Count - 1); n++)
            {
                // Get bottom and top planes position along Z- axis 
                //  Z     Y
                //  |    /
                //  |   /
                //  |  /
                //  | /
                //  |/
                //  |___________________X
                XYBottomPlane = ZSpacing[n];
                XYTopPlane = ZSpacing[n + 1];

                if (n == 0)
                {
                    // For first floor, account for splits
                    // For first floor, the bottom beam is always B5 and a walkway plate and top is B3
                    if (BottomSplit ) // Bottom Split               
                    {   
                        xStart = Side - C1BeamWidth / 2 ;
                        yStart = BillBoardDepth - C1BeamDepth - br1CornerWeldOffset - modelParameters.WeldOffset - 11;
                        zStart = XYBottomPlane + modelParameters.MeshThickness + B5BeamDepth;

                        xEnd = xStart;
                        yEnd = C1BeamDepth + br1CornerWeldOffset;
                        zEnd = XYTopPlane - modelParameters.WeldOffset;

                        bottomPlaneOffset.Z = modelParameters.WeldOffset * 3;
                        topPlaneOffset.Z = B3BeamWidth / 2;
                    }
                    else
                    {
                        xStart = Side - C1BeamWidth / 2;
                        yStart = BillBoardDepth - (C1BeamDepth + br1CornerWeldOffset);
                        zStart = XYBottomPlane - B5BeamDepth / 2;

                        xEnd = xStart;
                        yEnd = C1BeamDepth + br1CornerWeldOffset;
                        zEnd = XYTopPlane - modelParameters.WeldOffset;

                        // Offset for cutting planes
                        bottomPlaneOffset.Z = modelParameters.MeshThickness / 2 + modelParameters.HeightOffsetBottom - modelParameters.WeldOffset;
                        topPlaneOffset.Z = B3BeamWidth / 2;
                    }

                }
                else if (n == ZSpacing.Count - 2)
                {
                    // Last floor - Top splits only affects the end position
                    // For last floor, the bottom beam is always the B3 and top is B2
                    // Start Coordinates
                    xStart = Side - C1BeamWidth / 2;
                    yStart = BillBoardDepth - (C1BeamDepth + br1CornerWeldOffset);
                    zStart = XYBottomPlane;
                    bottomPlaneOffset.Z = B3BeamWidth / 2 + modelParameters.WeldOffset;

                    // account for both top and bottom split seperately
                    if (TopSplit && BottomSplit)
                    {
                        xEnd = xStart;
                        yEnd = C1BeamDepth + br1CornerWeldOffset * 2;
                        zEnd = XYTopPlane - B5BeamDepth/2 - modelParameters.MeshThickness - B2BeamDepth/2;
                        topPlaneOffset.Z = B2BeamDepth * 1.5;
                    }

                    else if (BottomSplit )
                    {
                        xEnd = xStart;
                        yEnd = C1BeamDepth + br1CornerWeldOffset * 2;
                        zEnd = XYTopPlane;
                        topPlaneOffset.Z = (B2BeamDepth - B3BeamWidth) + 5 * modelParameters.WeldOffset;
                    }
                    else if (TopSplit)
                    {
                        xEnd = xStart;
                        yEnd = C1BeamDepth + br1CornerWeldOffset * 2;
                        zEnd = XYTopPlane - B5BeamDepth - B2BeamDepth/2;
                        topPlaneOffset.Z = B2BeamDepth + B5BeamDepth/2 + modelParameters.WeldOffset * 5;
                    }
                    else
                    {
                        xEnd = xStart;
                        yEnd = C1BeamDepth + br1CornerWeldOffset;
                        zEnd = XYTopPlane - B2BeamWidth / 2 - modelParameters.WeldOffset;
                        topPlaneOffset.Z = B2BeamWidth / 2 + 4;
                    }


                }
                else // For all other floors 

                {   // All floors - both bottom and top are B3 beams - account for splits
                    // There are few offsets for a box that have either sides with splits
                    if (BottomSplit || TopSplit)
                    {
                        
                        xStart = Side - C1BeamWidth / 2;
                        yStart = BillBoardDepth - (C1BeamDepth + br1CornerWeldOffset);
                        zStart = XYBottomPlane + modelParameters.WeldOffset;

                        xEnd = xStart;
                        yEnd = C1BeamDepth + br1CornerWeldOffset;
                        zEnd = XYTopPlane - modelParameters.WeldOffset;

                        bottomPlaneOffset.Z = B3BeamWidth / 2;
                        topPlaneOffset.Z = B3BeamWidth / 2 + modelParameters.WeldOffset;
                    }
                    else
                    {
                        // All floors
                        // Start Coordinates
                        xStart = Side - C1BeamWidth / 2;
                        yStart = BillBoardDepth - (C1BeamDepth + br1CornerWeldOffset);
                        zStart = XYBottomPlane + modelParameters.WeldOffset;

                        xEnd = xStart;
                        yEnd = C1BeamDepth + br1CornerWeldOffset;
                        zEnd = XYTopPlane - modelParameters.WeldOffset;

                        bottomPlaneOffset.Z = B3BeamWidth / 2;
                        topPlaneOffset.Z = B3BeamWidth / 2 + modelParameters.WeldOffset;
                    }
                    

                }
                // Set the START and END coordinates
                startPos = new TSG.Point(xStart, yStart, zStart);

                // Move end point to an appropriate position ( Same implementation as in DiagonalBracing function)
                TSG.Point OffsetEnd = new TSG.Point(xEnd, yEnd, zEnd);

                // Calculate the offsets
                Length = Math.Sqrt(Math.Pow(OffsetEnd.Y - startPos.Y, 2) + Math.Pow(OffsetEnd.Z - startPos.Z, 2));
                phi = Math.Asin(BR1BeamWidth / Length);
                theta = Math.Atan((OffsetEnd.Y - startPos.Y) / (OffsetEnd.Z - startPos.Z));
                alpha = theta - phi;
                deltaZ = BR1BeamWidth * Math.Sin(alpha);
                deltaY = BR1BeamWidth * Math.Cos(alpha);

                // Get end postion
                endPos = OffsetEnd + new TSG.Point(0, deltaY, -deltaZ);

                // Generate a BOTTOM plane which will cut the bracing
                CutPlane CutPlaneBottom = new CutPlane
                {
                    Plane = new Plane
                    {
                        Origin = startPos + bottomPlaneOffset,
                        AxisY = new TSG.Vector(BillBoardDepth, 0, 0),
                        AxisX = new TSG.Vector(0, BR1BeamDepth, 0)
                    },
                };

                // Generate a TOP plane which will cut the bracing
                CutPlane CutPlaneTop = new CutPlane
                {
                    Plane = new Plane
                    {
                        Origin = new TSG.Point(0, 0, XYTopPlane - topPlaneOffset.Z - modelParameters.WeldOffset),
                        AxisY = new TSG.Vector(BillBoardDepth, 0, 0),
                        AxisX = new TSG.Vector(0, -1 * BR1BeamDepth, 0)
                    },
                };

                // Generate BEAM object for bracing
                Beam br1Top = Box.CreateBeam(Prefix.part, Prefix.assembly,
                    startPos,
                    endPos,
                    modelParameters.BR1Material,
                    modelParameters.BR1Profile,
                    "7",
                    diagonalEnums,
                    topDiagonalOffsets);

                CutPlaneBottom.Father = br1Top;
                CutPlaneBottom.Insert();
                CutPlaneTop.Father = br1Top;
                CutPlaneTop.Insert();
                SideBraces2Return.Add(br1Top);
            }

            return SideBraces2Return;

        }


        /// BACK BRACING BRACING GENERATION
        /// <summary>
        /// Install back bracing with MASSIVE assupmtion
        /// </summary> [INPUT PARAMETERS]
        /// ------------------------------------------------------------------------------
        /// <param name="modelParameters">      Model parameters</param>
        /// ------------------------------------------------------------------------------

        //BACK (SHOT) BRACING INSTALATION
        public static void BackShot(
               Box box,
               ModelParameters modelParameters,
               int index
           )
        {
            // THE NAMING OF THIS FUNCTION IS INTENTIONAL :)))))
            // THIS FUNCTION IS CODED AT THE END OF THE SESSION, WE ARE ALL TIRED AND EXHAUSTED

            // THOMAS WAS HERE 

            // For back bracings, due to the diverse styles of bracing, this feature is onlyat its first stage where...
            // ... only one style is implemented.

            // In the future, this feature should be able to implement more styles depending on the user input ( ask user what kind of bracing)

            // Get total amount of box and the dimensions of splits
            //  B2,B3, B5, BR1, C1 and WalkwayMesh properties extraction
            double B1BeamDepth = modelParameters.B1BeamDepth; 

            double B2BeamWidth = modelParameters.B2BeamWidth;
            double B2BeamDepth = modelParameters.B2BeamDepth;

            double B3BeamWidth = modelParameters.B3BeamWidth;

            double B5BeamWidth = modelParameters.B5BeamWidth;
            double B5BeamDepth = modelParameters.B5BeamDepth;

            double BR1BeamDepth = modelParameters.BR1BeamDepth;
            double BR1BeamWidth = modelParameters.BR1BeamWidth;

            double C1BeamDepth = modelParameters.C1BeamDepth;
            double C1BeamWidth = modelParameters.C1BeamWidth;
            double B1BeamWidth = modelParameters.B1BeamWidth;

            double br1CornerWeldOffset = modelParameters.CornerOffset;

            // Get Dimensions of the billboard
            double BillBoardLength = modelParameters.BillboardLength;   // X
            double BillBoardDepth = modelParameters.BillboardDepth;     // Y
            double BillBoardHeight = modelParameters.BillboardHeight;   // Z


            // Offset calculations for end position
            double Length = 0;
            double phi = 0;
            double theta = 0;
            double alpha = 0;
            double deltaZ = 0;
            double deltaX = 0;

            // Get start and end position 
            double xStart, yStart, zStart, xEnd, yEnd, zEnd;

            TSG.Point startPos = new TSG.Point();
            TSG.Point endPos = new TSG.Point();
            TSG.Point endPosOffset = new TSG.Point();

            // Point class for points used for cut planes
            TSG.Point bottomPlaneOffset = new TSG.Point();
            TSG.Point topPlaneOffset = new TSG.Point();

            // Create enums and offsets for diagonals - Use for creating beams
            int[] diagonalEnums = new int[] { 2, 1, 2 };
            double[] topDiagonalOffsets = new double[] { 0.0, 0.0, 0.0 };

            if (index % 2 == 0)
            {
                // Create condition 
                xStart = box.BoxOrigin.X + modelParameters.WeldOffset;
                yStart = BillBoardDepth - BR1BeamWidth;
                zStart = box.BoxOrigin.Z;

                xEnd = box.BoxOrigin.X + box.Length;
                yEnd = BillBoardDepth - BR1BeamWidth;
                zEnd = box.BoxOrigin.Z + box.Height;

                // Check for LEFT AND RIGHT SPLIT
                if (box.Side2 || box.Side4)
                {
                    if (box.Side2 && !box.Side4) 
                    {
                        xStart += modelParameters.C1SplitBeamWidth;
                        xEnd -= BR1BeamWidth / 2; 
                    } 
                    else if (box.Side4 && !box.Side2)
                    {
                        xStart += BR1BeamWidth / 2;
                        xEnd += -modelParameters.C1SplitBeamWidth;
                    }
                    else if (box.Side2 &&  box.Side4)
                    {
                        xStart += modelParameters.C1SplitBeamWidth + modelParameters.BoxGap;
                        xEnd += -modelParameters.C1SplitBeamWidth;
                    }

                }
                else
                {
                    xStart += BR1BeamWidth / 2;
                    xEnd -= BR1BeamWidth / 2;
                }

                // Check for TOP AND BOTTOM SPLIT
                if (box.Side1 || box.Side3)
                {
                    if (box.Side1 && !box.Side3)
                    {
                        zStart += modelParameters.B1BeamDepth + modelParameters.BoxGap;
                        zEnd += modelParameters.HeightOffsetTop;
                    }
                    else if (box.Side3 && !box.Side1)
                    {
                        zStart += -modelParameters.HeightOffsetBottom ;
                        zEnd += -modelParameters.B1BeamDepth;
                    }
                    else if (box.Side3 && box.Side1)
                    {
                        zStart += B1BeamDepth;
                        zEnd += -B1BeamDepth;
                    }
                }
                else
                {
                    zStart += -modelParameters.HeightOffsetBottom;
                    zEnd += modelParameters.HeightOffsetTop;
                }

                // BEyond this is in progess. Phahse 4 good luck with the calculations and the cut planes.
                // Read the codes for top/ bottom and side bracing to see about cutplanes 
                // Move end point to an appropriate position ( Same implementation as in DiagonalBracing function)
                TSG.Point OffsetEnd = new TSG.Point(xEnd, yEnd, zEnd);

                // Calculate the offsets
                Length = Math.Sqrt(Math.Pow(OffsetEnd.X - startPos.X, 2) + Math.Pow(OffsetEnd.Z - startPos.Z, 2));
                phi = Math.Atan(BR1BeamWidth / Length);
                theta = Math.Atan((OffsetEnd.Z - startPos.Z) / (OffsetEnd.X - startPos.X));
                alpha = theta - phi;
                deltaZ = BR1BeamWidth * Math.Sin(alpha);
                if (deltaZ < 0.0)
                {
                    deltaZ = deltaZ * -1;
                }
                deltaX = BR1BeamWidth * Math.Cos(alpha);

                // Get end postion
                // Set the START and END coordinates
                startPos = new TSG.Point(xStart, yStart, zStart) + new TSG.Point(0, 0, 0);

                // Off set is different per splits 
                endPos = OffsetEnd + new TSG.Point(0,0,0);
                
            }
            else
            {
                // Create condition 
                xStart = box.BoxOrigin.X + modelParameters.C1SplitBeamWidth;
                yStart = BillBoardDepth - BR1BeamWidth;
                zStart = box.BoxOrigin.Z + box.Height;

                xEnd = box.BoxOrigin.X + box.Length;
                yEnd = BillBoardDepth - BR1BeamWidth;
                zEnd = box.BoxOrigin.Z;

                // Now check for splits, u only need to offset X and Z positions depending on splits. No need for Y offset
                // Check for LEFT AND RIGHT SPLIT
                if (box.Side2 || box.Side4)
                {
                    if (box.Side2 && !box.Side4)
                    {
                        xStart += modelParameters.C1SplitBeamWidth;
                        xEnd -= BR1BeamWidth / 2;
                    }
                    else if (box.Side4 && !box.Side2)
                    {
                        xStart += BR1BeamWidth / 2;
                        xEnd += -modelParameters.C1SplitBeamWidth; 
                    }
                    else if (box.Side2 && box.Side4)
                    {
                        xStart += 0;
                        xEnd += -modelParameters.C1SplitBeamWidth;
                    }

                }
                else
                {
                    xStart += BR1BeamWidth / 2;
                    xEnd -= BR1BeamWidth / 2;
                }

                // Check for TOP AND BOTTOM SPLIT
                if (box.Side1 || box.Side3)
                {
                    if (box.Side1 && !box.Side3)
                    {
                        zStart += modelParameters.HeightOffsetTop;
                        zEnd += B1BeamDepth;
                    }
                    else if (box.Side3 && !box.Side1)
                    {
                        zStart += -B1BeamDepth;
                        zEnd += -modelParameters.HeightOffsetBottom;
                    }
                    else if (box.Side3 && box.Side1)
                    {
                        zStart += -B1BeamDepth;
                        zEnd += B1BeamDepth;
                    }
                }
                else
                {
                    zStart += modelParameters.HeightOffsetBottom;
                    zEnd += -modelParameters.HeightOffsetTop;
                }

                // Move end point to an appropriate position ( Same implementation as in DiagonalBracing function)
                TSG.Point OffsetEnd = new TSG.Point(xEnd, yEnd, zEnd);

                // Calculate the offsets
                Length = Math.Sqrt(Math.Pow(OffsetEnd.X - startPos.X, 2) + Math.Pow(OffsetEnd.Z - startPos.Z, 2));
                phi = Math.Asin(BR1BeamDepth / Length);
                theta = Math.Atan((OffsetEnd.X - startPos.X) / (OffsetEnd.Z - startPos.Z));
                alpha = theta - phi;
                deltaZ = BR1BeamWidth * Math.Sin(alpha);
                deltaX = BR1BeamWidth * Math.Cos(alpha);

                // Get end postion
                // Set the START and END coordinates
                startPos = new TSG.Point(xStart, yStart, zStart) + new TSG.Point(0,0,0);
                endPos = OffsetEnd + new TSG.Point(0, 0, 0);
            }

            

            // Generate BEAM object for bracing
            Beam brace = Box.CreateBeam(Prefix.part, Prefix.assembly,
                startPos,
                endPos,
                modelParameters.BR1Material,
                modelParameters.BR1Profile,
                "7",
                diagonalEnums,
                topDiagonalOffsets);

        }
    }
}