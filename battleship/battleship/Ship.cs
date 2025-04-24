using System;

namespace Battleship
{
    public class Ship
    {
        public int Size;
        public int[][] Location;
        public bool[] Damage;

        public void NewShip(int size, int[][] location)
        {
            if (location.Length != size)
                throw new Exception("Not right size");
            Size = size;
            Location = location;
            Damage = new bool[size];
        }

        public bool IsLocationCorrect()
        {
            for (int i = 1; i < Size; i++)
                if ((Math.Abs(Location[i][0] - Location[i - 1][0]) +
                    Math.Abs(Location[i][1] - Location[i - 1][1])) != 1)
                    return false;
            return true;
        }

        public bool IsSink()
        {
            bool t = true;
            foreach (bool i in Damage)
            {
                t = t && i;
            }
            return t;
        }

        
        
            
           
        
    }
}