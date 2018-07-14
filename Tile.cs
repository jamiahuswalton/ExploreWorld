using System;
using System.Collections.Generic;
using System.Text;

namespace ExploreWorld
{
    class Tile
    {
        //This class is used for the different tiles in the world
        private TerrainTypes terrain; // This will tell what the type of terrain is
        private float speedModifer; // This will be used as a multiplier
        private int healthModifer; // This will be used to add to the health (a negative number will reduce health)
        private bool isPassable; // This will be used to determine whether you can occupy this tile

        //Class constructor
        public Tile(TerrainTypes myTerrain, float mySpeedModifer, int myHealthModifer, bool myIsPassable)
        {
            terrain = myTerrain;
            speedModifer = mySpeedModifer;
            healthModifer = myHealthModifer;
            isPassable = myIsPassable;
        }

        //Add enums for title types
        public enum TerrainTypes{
            Unknown,
            Water,
            Fire,
            Rock,
            Grass
        }

        public TerrainTypes getTerrain()
        {
            return terrain;
        }

        public bool getIsPassable()
        {
            return isPassable;
        }

        public int getHealthModifer()
        {
            return healthModifer;
        }
    }
}
