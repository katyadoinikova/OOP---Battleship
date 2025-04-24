using System;
using System.Linq;

namespace Battleship
{
    public class Board
    {
        public int SizeWidth;
        public int SizeHeight;
        public int[,] Board1;
        public Ship[] ListOfShips;

        public void NewBoard(Game game)
        {
            SizeWidth = game.BoardWidth;
            SizeHeight = game.BoardHeight;
            Board1 = new int[SizeHeight, SizeWidth];
            ListOfShips = new Ship [game.AmountOfShips.Sum()];
        }

        public void Filling(int player, Game game, Input input1)
        {
            Ship current;
            int k = 0;
            Console.WriteLine("Enter ships of player {0}, the ships shouldn't touch each other. If you want to enter ships again, write 'Again'", player);
            for (int i = 0; i < game.AmountOfShips.Length; i++)
            {
                Console.WriteLine("Enter {0} position{2} of {1} ship{3} like 'A4 A5 A6 A7':",
                    game.SizeOfShips[i], game.AmountOfShips[i], 
                    input1.NiceEnter(game.SizeOfShips[i]), input1.NiceEnter(game.AmountOfShips[i]));

                for (int j = 0; j < game.AmountOfShips[i]; j++)
                {
                    input1.Value = Console.ReadLine();
                    if (input1.Value == "Again")
                        Filling(player, game, input1);
                    while (!input1.IsEnterCorrect( game.SizeOfShips[i], SizeWidth, SizeHeight))
                    {
                        Console.WriteLine("On line {0} input wasn't correct, enter this line again:", j + 1);
                        input1.Value = Console.ReadLine();
                    }

                    current = input1.TransformInputToShip(game.SizeOfShips[i]);
                    while (!input1.IsEnterCorrect(game.SizeOfShips[i], SizeWidth, SizeHeight) 
                           || !current.IsLocationCorrect() || !AddShip(current, k))
                    {
                        if (!input1.IsEnterCorrect(game.SizeOfShips[i], SizeWidth, SizeHeight))
                            Console.WriteLine("On line {0} input wasn't correct, enter this line again:", j + 1);
                        else if (!current.IsLocationCorrect())
                            Console.WriteLine("On line {0} positions of ships aren't next to each other", j + 1);
                        else
                            Console.WriteLine("You can't enter ship on line {0}, it's next to another one", j + 1);
                            
                        input1.Value = Console.ReadLine();
                        if (input1.IsEnterCorrect(game.SizeOfShips[i], SizeWidth, SizeHeight))
                            current = input1.TransformInputToShip(game.SizeOfShips[i]);
                    }
                    k++;

                }
            }
            Output();

        }

        
        public bool AddShip(Ship new1, int k)
        {
            for (int i = 0; i < new1.Size; i++)
                if (IsNextToShip(new1.Location[i]))
                    return false;
            if (new1.IsLocationCorrect())
            {
                for (int i = 0; i < new1.Size; i++)
                    Board1[new1.Location[i][0], new1.Location[i][1]] = 1;
                ListOfShips[k] = new1;
                k++;
            }

            return true;
        }

        public bool IsNextToShip(int[] pos)
        {
            int[] shiftX = { -1, 0, 1 }, shiftY = { -1, 0, 1 };
            foreach (int i in shiftX)
                foreach (int j in shiftY)
                    if (pos[0] + i >= 0 && pos[0] + i < SizeWidth && pos[1] + j >= 0 && pos[1] + j < SizeHeight)
                        if (Board1[pos[0] + i, pos[1] + j] != 0)
                            return true;
            return false;
        }

        public void Output()
        {
            Console.Write("   ");
            for (int i = 0; i < SizeWidth; i++)
            {
                Console.Write((char)('A' + i)); //номера столбцов
                Console.Write(" ");

            }

            Console.WriteLine();
            for (int i = 0; i < SizeHeight; i++)
            {
                Console.Write(SizeHeight - i); //номера строк снизу вверх
                Console.Write("  ");
                for (int j = 0; j < SizeWidth; j++)
                {
                    Console.Write(Board1[j, SizeHeight - i]); //значения таблицы слева направо, но сверху вниз
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}