using System;

namespace Battleship
{
    public static class Program
    {
        public static int[] EnterInArray()
        {
            string input;
            input = Console.ReadLine();
            while (input == null)
            {
                Console.WriteLine("Null was entered!");
                input = Console.ReadLine();
            }
            string[] creation = input.Split(' ');
            int[] arr = new int[creation.Length];
            for(int i = 0; i < creation.Length; i++)
                arr[i] = Int32.Parse(creation[i]);
            return arr;
        }
        
        public static void Main()
        {
            Board player1 = new Board(), player2 = new Board();
            Game game = new Game();
            Console.WriteLine("Enter 2 parameters of size of board like '10 10':");
            int[] sizeOfBoard = EnterInArray();
            while (sizeOfBoard.Length != 2)
            {
                Console.WriteLine("Not 2 parameters were entered, enter size of board like '10 10':");
                sizeOfBoard = EnterInArray();
            }
            Console.WriteLine("Enter sizes of ships, that will be in the game like '1 2 3 4':");
            int[] sizeOfShips = EnterInArray();
            Console.WriteLine("Enter amount of ships, that will be in the game like '4 3 2 1':");
            int[] amountOfShips = EnterInArray();
            Console.Clear();
            try
            {
                game.NewGame(sizeOfBoard[0],sizeOfBoard[1], sizeOfShips, amountOfShips);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Input input1 = new Input();
            player1.NewBoard(game);
            player1.Filling(1, game, input1);
            Console.Clear();
            player2.NewBoard(game);
            player2.Filling(1, game, input1);
        }
    }
}
