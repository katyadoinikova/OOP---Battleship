using System;
using System.Linq;

namespace Battleship
{
    public class Game
    {
        public int BoardWidth;
        public int BoardHeight;
        public int[] SizeOfShips;
        public int[] AmountOfShips;

        public void NewGame (int boardWidth, int boardHeight, int[] sizeOfShips, int[] amountOfShips)
        {
            if (sizeOfShips.Length != amountOfShips.Length)
                throw new Exception("Not right size or amount of boards");
            SizeOfShips = sizeOfShips;
            AmountOfShips = amountOfShips;
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;
        }

        public void Move(Board boardOfShips, Board Known, int player)
        {
            Console.WriteLine("Player {0}, enter your shot:", player);
            Input input1 = new Input();
            input1.Value = Console.ReadLine();
            while (!input1.IsEnterCorrect(1, boardOfShips.SizeWidth, boardOfShips.SizeHeight))
            {
                Console.WriteLine("Your shot wasn't correct, enter it again:");
                input1.Value = Console.ReadLine();
            }
            int[] location;
            location= new []{input1.Value[0] - 'A', input1.Value[1] - '1'};
            while (Known.Board1[location[0], location[1]] == 1)
            {
                Console.WriteLine("Your shot pointless, enter it again:");
                input1.Value = Console.ReadLine(); 
            }

            if (boardOfShips.Board1[location[0], location[1]] == 1)
            {
                int isIn;
                Ship hurtShip = new Ship();
                foreach (Ship i in boardOfShips.ListOfShips)
                {
                    isIn = Array.IndexOf(location, i.Location);
                    if (isIn > -1)
                    {
                        i.Damage[isIn] = true;
                        hurtShip = i;
                    }
                }

                if (hurtShip.IsSink())
                    Console.WriteLine("Your shot was successful, you drown ship");
                else
                    Console.WriteLine("Your shot was successful, you hit ship");
                Known.Board1[location[0], location[1]] = 0;
                boardOfShips.Board1[location[0], location[1]] = 2;
                Move(boardOfShips, Known, player);
            }
            else
            {
                Console.WriteLine("You missed");
            }
        }
        
    }
}