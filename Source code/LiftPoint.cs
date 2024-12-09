using System;
using System.Collections;
using System.Windows.Forms;
using TSG = Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Class to support modeling of lifting points for billboard frames in Tekla Structures.
    /// </summary>
    public class LiftPoint
    {
        private const double PlateWidth = 75;
        /// <value>
        /// Modeled as a 75 x 75 x 10 mm plate as per the engineering drawing.
        /// </value>
        public Plate Plate;

        /// <value>
        /// Modeled as a 24 mm standard bolt. Placeholder only.
        /// </value>
        public BoltArray EyeBolt;

        /// <value>
        /// The profile of the lifting point plate.
        /// </value>
        public string Profile { get; set; }

        /// <value>
        /// The material of the lifting point plate.
        /// </value>
        public string Material { get; set; }

        /// <value>
        /// Whether the lifting point is on the top or bottom B1 member.
        /// </value>
        public bool IsTop;

        /// <summary>
        /// Constructor for a single lifting point.
        /// <param name="beam"> B1 member to insert the lifting point on </param>
        /// <param name="position"> 3D coordinates of the point to insert the lifting point </param>
        /// <param name="isTop"> True if beam refers to the top B1 member, False otherwise </param>
        /// <param name="width"></param>
        /// <param name="profile"></param>
        /// <param name="material"></param>
        /// <param name="heightOffset"></param>
        /// <param name="boltStandard"></param>
        /// </summary>
        public LiftPoint(Beam beam, TSG.Point position, double width, bool isTop, string profile, string material, double heightOffset, string boltStandard)
        {
            this.IsTop = isTop;
            this.Profile = profile;
            this.Material = material;
            double[] beamDim = ModelParameters.BeamDimensions(beam.Profile.ProfileString);

            if (isTop) // Top lift points
            {
                this.Plate = new Plate(position + new TSG.Point(0, 0, -beamDim[1]),
                    Profile,
                    Material,
                    depth: Position.DepthEnum.BEHIND,
                    xOffset: width / 2,
                    yOffset: width / 2);
            }
            else // Bottom lift points
            {
                this.Plate = new Plate(position + new TSG.Point(0, 0, -heightOffset),//beamDim[0] + modelParameters.WeldOffset),
                    Profile,
                    Material,
                    depth: Position.DepthEnum.FRONT,
                    xOffset: width / 2,
                    yOffset: width / 2);
            }
            
            this.EyeBolt = new BoltArray
            {
                Bolt = true,
                BoltSize = 24.0,
                BoltStandard = boltStandard,
                CutLength = 500,
                FirstPosition = position,
                SecondPosition = position + new TSG.Point(500, 0, 0),
                PartToBoltTo = beam,
                PartToBeBolted = this.Plate.ContourPlate,
                ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES,
            };

            this.EyeBolt.Position.Plane = Position.PlaneEnum.LEFT;
            this.EyeBolt.Washer1 = false;
            this.EyeBolt.Washer2 = false;
            this.EyeBolt.Washer3 = false;
            this.EyeBolt.Nut1 = true;
            this.EyeBolt.Nut2 = false;

            this.EyeBolt.Hole1 = false;
            this.EyeBolt.Hole2 = false;
            this.EyeBolt.Hole3 = false;
            this.EyeBolt.Hole4 = false;
            this.EyeBolt.Hole5 = false;

            // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)                      
            this.EyeBolt.AddBoltDistY(0);

            // Add the distance between two bolts (set to 0 because we want one)
            this.EyeBolt.AddBoltDistX(0);

            // Insert bolts
            if (!this.EyeBolt.Insert()) { MessageBox.Show("Insertion of bolt failed."); }

            BoltArray hole = new BoltArray
            {
                Bolt = false,
                BoltSize = 24.0,
                BoltStandard = boltStandard,
                CutLength = 0,
                FirstPosition = position,
                SecondPosition = position + new TSG.Point(500, 0, 0),
                PartToBoltTo = this.Plate.ContourPlate,
                PartToBeBolted = this.Plate.ContourPlate,
                ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES,
            };

            hole.Position.Plane = Position.PlaneEnum.LEFT;
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

            // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)                      
            hole.AddBoltDistY(0);

            // Add the distance between two bolts (set to 0 because we want one)
            hole.AddBoltDistX(0);

            // Insert bolts
            if (!hole.Insert()) { MessageBox.Show("Insertion of hole failed."); }
        }

        /// <summary>
        /// Verifies the lifting point can be inserted at a valid point without collisions
        /// </summary>
        /// <param name="x"> x coordinate to insert the new lifting point at</param>
        /// <param name="colWidth"></param>
        /// <param name="isTop"> True if the parent is the top B1 member, false otherwise</param>
        /// <param name="killMe"> List of (relative) column x coordinates (mm) </param>
        /// <param name="liftList"> List of (absolute) x coordinates of existing lifting points (mm) </param>
        /// <param name="xOld"> The old x value of the lifting point if 'Edit' is selected (mm) </param>
        /// <returns> True if insertion is possible, false otherwise</returns>
        public static bool ValidateLiftPoint(double x, double colWidth, bool isTop, IList killMe, IList liftList, double xOld = 0)
        {
            // check whether lift point coincides with a column - allowance of 20mm in case of box splitting
            if (x < (PlateWidth + colWidth) / 2 + 20) //modelParameters.BillboardLength)
            {
                MessageBox.Show("Lift Point cannot be inserted on a column.");
                return false;
            }

            double xCoord = 0;
            foreach (string xRel in killMe) //modelParameters.XCoordinates)
            {
                xCoord += Convert.ToDouble(xRel.Replace("*", ""));
                if (Math.Abs(x - xCoord) < (PlateWidth + colWidth) / 2 + 20)
                {
                    MessageBox.Show("Lift Point cannot be inserted on a column.");
                    return false;
                }
            }

            // check whether the lifting point clashes with an existing one
            foreach (double point in liftList)
            {
                if (Math.Abs(point - xOld) < Double.Epsilon) { continue; }
                if (Math.Abs(x - point) < PlateWidth)
                {
                    MessageBox.Show($"Lift point will clash with x = {point} along the " + (isTop ? "top" : "bottom"));
                    return false;
                }
            }

            return true;
        }
    };
}
