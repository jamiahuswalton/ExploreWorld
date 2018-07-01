﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExploreWorld
{
    class Tile
    {
        private string terrain;
        private float speedModifer; // This will be used as a multiplier
        private int healthModifer; // This will be used to add to the health (a negative number will reduce health)
        private bool isPassable;

        //Class constructor
        public Tile(string myTerrain, float mySpeedModifer, int myHealthModifer, bool myIsPassable)
        {
            terrain = myTerrain;
            speedModifer = mySpeedModifer;
            healthModifer = myHealthModifer;
            isPassable = myIsPassable;
        }

        public string getTerrain()
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