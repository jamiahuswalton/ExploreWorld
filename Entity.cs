﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExploreWorld
{
    class Entity
    {
        public string name; // name of the entity
        public int healthPoints; // health of entity
        public bool isCollidable; // can you make contact with it
        public bool isMovable; // can move entity
        public bool isAbleToReceiveDamage; // can damage entity
        
        public Entity(string myName, int myHealthPoints, bool myIsCollidable, bool myIsMovable, bool myIsAbleToReceiveDamage)
        {
            //This means that when ever this object is constructed, these properties will need to be given a value
            name = myName;
            healthPoints = myHealthPoints;
            isCollidable = myIsCollidable;
            isMovable = myIsMovable;
            isAbleToReceiveDamage = myIsAbleToReceiveDamage;
        }

        public void ApplyDamage(int damageToBeApplied)
        {
            if (isAbleToReceiveDamage)
            {
                if (healthPoints > damageToBeApplied)
                {
                    healthPoints = healthPoints - damageToBeApplied;
                }
                else
                {
                    //The entity is destroyed!
                    healthPoints = 0;
                }
            }
        }

        public int getHealth() {
            return healthPoints;
        }
    }
}
