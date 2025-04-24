using System;
namespace Battleship
{
    public class Input
    {
        public string Value;
        public string NiceEnter(int x)
        {
            if (x == 1)
                return String.Empty;
            return "s";
        }
        public Ship TransformInputToShip(int size)
        {
            Ship res = new Ship();
            int[][] location = new int[size][];
            for (int k = 0; k < size; k++)
            {
                location[k]= new []{ Value[3 * k] - 'A', Value[3 * k + 1] - '1'};
            }
            try
            {
                res.NewShip(size, location);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return res;
        }
        
        public bool IsEnterCorrect(int size, int sizeWidth, int sizeHeight)
        {
            int pos = 0;
            int sizeCur = 1;
            for (int i = 0; i < Value.Length; i++)
            {
                if (pos == 0 && ((Value[i] - 'A' >= sizeWidth) || (Value[i] - 'A' < 0)))
                    return false;
                if (pos == 1 && ((Value[i] - '1' >= sizeHeight) || (Value[i] - '1' < 0)))
                    return false;
                if (pos == 2 && Value[i] != ' ')
                    return false;
                pos++;
                if (pos > 2)
                    sizeCur ++;
                   
                pos %= 3;
            }

            if (pos != 2)
                return false;

            if (sizeCur != size)
                return false;
            
            return true;
        }

    }
}