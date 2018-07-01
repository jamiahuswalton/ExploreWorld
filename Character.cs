using System;
using System.Collections.Generic;
using System.Text;

namespace ExploreWorld
{
    class Character: Entity
    {
        //proterties
        private int power;
        private int team;
        
        //Constructor
        public Character(string myName, int myHealthPoints, bool myIsCollidable, bool myIsMovable, bool myIsAbleToReceiveDamage, int myPower,
            int myTeam) : 
            base(myName, myHealthPoints, myIsCollidable, myIsMovable, myIsAbleToReceiveDamage)
        {
            power = myPower;
            team = myTeam;
        }
        
        public void UpdatePlayerHealth(int amountToChangeHealth)
        {
            healthPoints += amountToChangeHealth;
        }
    }
}