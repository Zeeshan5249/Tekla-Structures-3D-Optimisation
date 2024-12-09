using System;
using System.Windows.Forms;
using Tekla.Structures.Model;
using TSG = Tekla.Structures.Geometry3d;


namespace TeklaBillboardAid
{
    /// <summary>
    /// Class containing functions for gal-hole insertion
    /// </summary>
    public class GalHole
    {

        /// <summary>
        /// Function to insert gal-holes into a given beam
        /// </summary>
        /// <param name="beam">Beam to insert holes into</param>
        /// <param name="modelParameters">Model parameters, used to check if gal-holes should be inserted</param>
        /// <param name="enums">Rotation enums for holes</param>
        /// <param name="parentProfile">Profile of the parent beam</param>
        // Technique used: Set first pos as start point and end pos as end point.
        // Set second pos as first pos and add a direction in the form of a new TSG.Point to the second pos. Trail and error required with the direction and always set as big numbers.
        public static void galHole(Beam beam, ModelParameters modelParameters, int[] enums, string parentProfile = "")
        {
            if (modelParameters.NoGalHole) { return; }

            // This is used to get the automatic gal hole size from the dictionary in ModelParameters.cs depending on beam profile.
            string key = string.IsNullOrEmpty(parentProfile)
                ? beam.Profile.ProfileString.Substring(0, beam.Profile.ProfileString.LastIndexOf("*"))
                : parentProfile.Substring(0, beam.Profile.ProfileString.LastIndexOf("*"));

            double a = modelParameters.GalHoleOffset1;
            double b = modelParameters.GalHoleOffset2;
            // Generating correct offsets. For example, offsetFB1 represents the gal hole at the starting side of the front and back beams. 2 means the other size i.e second hole.
            //TSG.Point( 0, closed end offset, open end offset). Logic: Tahsin.
            TSG.Point offsetFB1 = new TSG.Point(0, -ModelParameters.BeamDimensions(beam.Profile.ProfileString)[0] / 2
                + ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2] + b + modelParameters.GalHoleSizes[key] / 2, a + modelParameters.GalHoleSizes[key] / 2);
            TSG.Point offsetFB2 = new TSG.Point(0, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[0] / 2
                - ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2] - b - modelParameters.GalHoleSizes[key] / 2, -a - modelParameters.GalHoleSizes[key] / 2);

            // Generating correct offsets. Firstly for top beam then bottom beam.
            //TSG.Point( 0, open end offset, closed end offset). Logic: Tahsin.
            TSG.Point offsetT1 = new TSG.Point(0, a + modelParameters.GalHoleSizes[key] / 2, -ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2] - b - modelParameters.GalHoleSizes[key] / 2);
            TSG.Point offsetT2 = new TSG.Point(0, -a - modelParameters.GalHoleSizes[key] / 2, -ModelParameters.BeamDimensions(beam.Profile.ProfileString)[0] + ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2] + b + modelParameters.GalHoleSizes[key] / 2);
            TSG.Point offsetB1 = new TSG.Point(0, a + modelParameters.GalHoleSizes[key] / 2, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[0] - ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2] - b - modelParameters.GalHoleSizes[key] / 2);
            TSG.Point offsetB2 = new TSG.Point(0, -a - modelParameters.GalHoleSizes[key] / 2, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2] + b + modelParameters.GalHoleSizes[key] / 2);

            // FAKE PLACEEHOLDER. Generating correct offsets for br1 diagonal beams.
            TSG.Point offsetD1 = new TSG.Point(0, a + modelParameters.GalHoleSizes[key] / 2, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2] + b + modelParameters.GalHoleSizes[key] / 2);
            TSG.Point offsetD2 = new TSG.Point(0, -a - modelParameters.GalHoleSizes[key] / 2, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2] + b + modelParameters.GalHoleSizes[key] / 2);

            TSG.Point firstPosition = beam.StartPoint, secondPosition = beam.EndPoint, thirdPosition = beam.StartPoint, fourthPosition = beam.EndPoint;
            // Bottom 
            if (enums[0] == 0 && enums[1] == 1 && enums[2] == 2)
            {
                firstPosition = beam.StartPoint + offsetB1;
                secondPosition = firstPosition + new TSG.Point(0, 0, 500);
                thirdPosition = beam.EndPoint + offsetB2;
                fourthPosition = thirdPosition + new TSG.Point(0, 0, 500);
            }
            // Front/back
            if (enums[0] == 0 && enums[1] == 0 && enums[2] == 3 || enums[0] == 0 && enums[1] == 0 && enums[2] == 0)
            {
                firstPosition = beam.StartPoint + offsetFB1;
                secondPosition = firstPosition + new TSG.Point(0, 0, 500);
                thirdPosition = beam.EndPoint + offsetFB2;
                fourthPosition = thirdPosition + new TSG.Point(0, 0, 500);
            }

            // Top
            if (enums[0] == 0 && enums[1] == 2 && enums[2] == 2)
            {
                firstPosition = beam.StartPoint + offsetT1;
                secondPosition = firstPosition + new TSG.Point(0, 0, 500);
                thirdPosition = beam.EndPoint + offsetT2;
                fourthPosition = thirdPosition + new TSG.Point(0, 0, 500);
            }
            if (enums[0] == 2 && enums[1] == 0 && enums[2] == 0)
            {   
                //Logic: Steven
                TSG.Point xoff1 = new TSG.Point(10 + modelParameters.GalHoleSizes[key] / 2, 0, 0);
                TSG.Point yoff1 = new TSG.Point(0, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[1] / 2, 0);
                TSG.Point zoff1 = new TSG.Point(0, 0, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2] + 2 + modelParameters.GalHoleSizes[key] / 2);
                firstPosition = beam.StartPoint + yoff1 + xoff1 - zoff1;
                secondPosition = firstPosition + new TSG.Point(0, 1, -7000);
                thirdPosition = beam.EndPoint - xoff1 + yoff1 - zoff1 - new TSG.Point(0, 0, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[0] / 2);
                fourthPosition = thirdPosition + new TSG.Point(0, 1, -7000);
            }

            // Horizontal railing beams
            if (enums[0] == 2 && enums[1] == 0 && enums[2] == 2)
            {   
                TSG.Point diff = new TSG.Point(beam.StartPoint - beam.EndPoint);
                //NOTE: Can change to TSG.Point diff = beam.EndPoint - beam.StartPoint; and remove math.abs()
                // HR beams that span the Y-axis. Logic: Steven.
                if (Math.Abs(diff.X) > diff.Y && Math.Abs(diff.X) > diff.Z)
                {
                    TSG.Point xoff1 = new TSG.Point(a + modelParameters.GalHoleSizes[key] / 2, 0, 0);
                    TSG.Point yoff1 = new TSG.Point(0, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[1] / 2, 0);
                    TSG.Point zoff1 = new TSG.Point(0, 0, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2] + 2 + modelParameters.GalHoleSizes[key] / 2);
                    firstPosition = beam.StartPoint + yoff1 + xoff1 + zoff1;
                    secondPosition = firstPosition + new TSG.Point(0, 1, -7000);
                    thirdPosition = beam.EndPoint - xoff1 + yoff1 + zoff1 - new TSG.Point(0, 0, ModelParameters.BeamDimensions(beam.Profile.ProfileString)[0] / 2);
                    fourthPosition = thirdPosition + new TSG.Point(0, 1, -7000);
                }
                else if (Math.Abs(diff.Y) > diff.X && Math.Abs(diff.Y) > diff.Z)
                {
                    // Teal beams that span the X-axis. Logic: Steven.
                    TSG.Point xoff1 = new TSG.Point(ModelParameters.BeamDimensions(beam.Profile.ProfileString)[1], 0, 0);
                    TSG.Point yoff1 = new TSG.Point(0, modelParameters.GalHoleSizes[key] / 2 + 10, 0);
                    TSG.Point zoff1 = new TSG.Point(0, 0, modelParameters.GalHoleSizes[key] / 2 + 2 + ModelParameters.BeamDimensions(beam.Profile.ProfileString)[2]);
                    firstPosition = beam.StartPoint + yoff1 - xoff1 + zoff1;
                    secondPosition = firstPosition + new TSG.Point(0, 0, 7000);
                    thirdPosition = beam.EndPoint - xoff1 - yoff1 - zoff1 - new TSG.Point(0, 0, 0);
                    fourthPosition = thirdPosition + new TSG.Point(0, 0, 7000);

                }
            }
            // Bolt set to false to create a hole. Bolt to the beam variable itself. Cut length can be anything. Thread enabled.
            // Create First gal hole
            BoltArray galBolt1 = new BoltArray
            {
                Bolt = false,
                BoltSize = modelParameters.GalHoleSizes[key],
                //bolt.Length
                //BoltStandard = ModelParameters.BracketBoltStandard,
                CutLength = 250,
                FirstPosition = firstPosition,
                SecondPosition = secondPosition,
                PartToBoltTo = beam,
                PartToBeBolted = beam,
                ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
            };

            // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)
            galBolt1.AddBoltDistY(0);

            // Add the distance between two bolts (set to 0 because we want one)
            galBolt1.AddBoltDistX(0);

            // Insert bolts
            if (!galBolt1.Insert())
            {
                MessageBox.Show("Insertion of bolt failed.");
            }

            // Create second Gal hole
            BoltArray galBolt2 = new BoltArray
            {
                Bolt = false,
                BoltSize = modelParameters.GalHoleSizes[key],
                //bolt.Length
                //BoltStandard = ModelParameters.BracketBoltStandard,
                CutLength = 250,
                FirstPosition = thirdPosition,
                SecondPosition = fourthPosition,
                PartToBoltTo = beam,
                PartToBeBolted = beam,
                ThreadInMaterial = BoltGroup.BoltThreadInMaterialEnum.THREAD_IN_MATERIAL_YES
            };

            // Add the distance between two bolts on the same horizontal line (set it to 0 because we only want one line)
            galBolt2.AddBoltDistY(0);

            // Add the distance between two bolts (set to 0 because we want one)
            galBolt2.AddBoltDistX(0);

            // Insert bolts
            if (!galBolt2.Insert())
            {
                MessageBox.Show("Insertion of bolt failed.");
            }
        }
    }

}
