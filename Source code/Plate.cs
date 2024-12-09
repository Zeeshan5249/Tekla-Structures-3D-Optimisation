using System;
using Tekla.Structures.Model;
using System.Collections.Generic;
using TSG = Tekla.Structures.Geometry3d;

namespace TeklaBillboardAid
{
    /// <summary>
    /// Class to support modeling of plates on Tekla Structures. 
    /// </summary>
    public class Plate
    {
        
        /// <value>
        /// Points used to form the plate (mm)
        /// </value>
        public List<TSG.Point> Points { get; set; }

        /// <value>
        /// Object storing the modeled plate to interact with Tekla Open API
        /// </value>
        public ContourPlate ContourPlate { get; set; }

        /// <summary>
        /// The profile of the plate
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// The material of the plate
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// Constructor to create a plate.
        /// </summary>
        /// <param name="points"> List of 3D coordinates in the cross section. Points must be provided in clockwise/counter-clockwise order. </param>
        /// <param name="profile"> Profile of the plate. </param>
        /// <param name="material"> Material of the plate.</param>
        /// <param name="depth"> Depth enumeration to position the plate. </param>
        /// <param name="plateClass"> Changes colour of part. </param>
        /// <param name="plateName"> Name field of plate. </param>
        /// <param name="plateFinish"> Finish field of plate. </param>
        public Plate(List<TSG.Point> points, string profile, string material, Position.DepthEnum depth = Position.DepthEnum.MIDDLE, string plateClass = "1", string plateName = "", string plateFinish = "", string partprefix = "PL", string assprefix = "")
        {
            this.Points = points;
            this.Profile = profile;
            this.Material = material;
          
            this.ContourPlate = CreatePlate(depth, plateClass, plateName, plateFinish, partprefix, assprefix);

        }
        /// <summary>
        /// Overloaded constructor to create a rectangular plate in the XY, XZ or YZ plane using a centre point and x/y/z dimensions. Exactly two of xOffset, yOffset and zOffset must be set.
        /// </summary>
        /// <param name="centre"> 3D coordinates of the plate's centre (mm) </param>
        /// <param name="profile"> Profile of the plate. </param>
        /// <param name="material"> Material of the plate.</param>
        /// <param name="depth"> Depth enumeration to position the plate. </param>
        /// <param name="xOffset"> Offset of corners in the x direction from the centre (mm)</param>
        /// <param name="yOffset"> Offset of corners in the y direction from the centre (mm)</param>
        /// <param name="zOffset"> Offset of corners in the z direction from the centre (mm)</param>
        /// <param name="plateClass"> Changes colour of part. </param>
        /// <param name="plateName"> Name field of plate. </param>
        /// <param name="plateFinish"> Finish field of plate. </param>
        public Plate(TSG.Point centre, string profile, string material, Position.DepthEnum depth = Position.DepthEnum.BEHIND, double xOffset = 0, double yOffset = 0, double zOffset = 0,
            string plateClass = "1", string plateName = "", string plateFinish = "")
        {
            this.Points = FindCorners(centre, xOffset, yOffset, zOffset);
            this.Profile = profile;
            this.Material = material;
            this.ContourPlate = CreatePlate(depth, plateClass, plateName, plateFinish);
        }

        /// <summary>
        /// Helper method to insert the plate.
        /// </summary>
        /// <param name="depth"> Depth enumeration to position the plate. </param>
        /// <param name="plateClass"> Changes colour of part. </param>
        /// <param name="plateName"> Name field of plate. </param>
        /// <param name="plateFinish"> Finish field of plate. </param>
        /// <returns></returns>
        private ContourPlate CreatePlate(Position.DepthEnum depth = Position.DepthEnum.MIDDLE, string plateClass = "1", string plateName = "", string plateFinish = "", string partprefix ="PL", string assprefix = "LP")
        {
            ContourPlate plate = new ContourPlate();

            foreach (TSG.Point point in Points)
            {
                plate.AddContourPoint(new ContourPoint(point, null));
            }
            plate.Profile.ProfileString = Profile;
            plate.Material.MaterialString = Material;
            plate.Position.Depth = depth;
            plate.Class = plateClass;
            plate.PartNumber = new NumberingSeries(partprefix, 1);
            plate.AssemblyNumber = new NumberingSeries(assprefix, 1);


            if (!String.IsNullOrEmpty(plateName)) { plate.Name = plateName; }
            plate.Finish = plateFinish;

            if (!plate.Insert()) { Console.WriteLine("Failed to insert plate"); }

            return plate;
        }

        /// <summary>
        /// Overloaded method to find corners of a rectangular plate in the XY, XZ or YZ planes given the centre and dimensions in (two of) the x, y and z directions.
        /// </summary>
        /// <param name="centre"> Coordinates of the plate's centre (mm) </param>
        /// <param name="xOffset"> Distance from the centre to corner in the x direction (mm) </param>
        /// <param name="yOffset"> Distance from the centre to corner in the y direction (mm)</param>
        /// <param name="zOffset"> Distance from the centre to corner in the z direction (mm)</param>
        /// <returns> Plate object storing the created plate. </returns>
        private static List<TSG.Point> FindCorners(TSG.Point centre, double xOffset = 0, double yOffset = 0, double zOffset = 0)
        {
            TSG.Point point1, point2, point3, point4;
            
            // XY Plane
            if (xOffset > 0 && yOffset > 0 && zOffset == 0)
            {
                point1 = new TSG.Point(centre.X - xOffset, centre.Y + yOffset, centre.Z);
                point2 = new TSG.Point(centre.X - xOffset, centre.Y - yOffset, centre.Z);
                point3 = new TSG.Point(centre.X + xOffset, centre.Y - yOffset, centre.Z);
                point4 = new TSG.Point(centre.X + xOffset, centre.Y + yOffset, centre.Z);
            }
            // XZ Plane
            else if (xOffset > 0 && yOffset == 0 && zOffset > 0)
            {
                point1 = new TSG.Point(centre.X - xOffset, centre.Y, centre.Z + zOffset);
                point2 = new TSG.Point(centre.X - xOffset, centre.Y, centre.Z - zOffset);
                point3 = new TSG.Point(centre.X + xOffset, centre.Y, centre.Z - zOffset);
                point4 = new TSG.Point(centre.X + xOffset, centre.Y,  centre.Z + zOffset);
            }
            // YZ Plane
            else if (xOffset == 0 && yOffset > 0 && zOffset > 0)
            {
                point1 = new TSG.Point(centre.X, centre.Y - yOffset, centre.Z + zOffset);
                point2 = new TSG.Point(centre.X, centre.Y - yOffset, centre.Z - zOffset);
                point3 = new TSG.Point(centre.X, centre.Y + yOffset, centre.Z - zOffset);
                point4 = new TSG.Point(centre.X, centre.Y + yOffset, centre.Z + zOffset);
            }
            else
            {
                throw new Exception();
            }

            return new List<TSG.Point>{point1, point2, point3, point4};
        }
    }
}