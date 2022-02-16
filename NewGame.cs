using System;

namespace mis321_pa2_Dnsavage
{
    public class NewGame
    {
        public string GetPlayerName()
        {
            //Console.WriteLine($"Player {playerNum}: Enter your name:");
            string playerName = Console.ReadLine();
            while (playerName.Length < 1)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Error: Please enter a valid name: ");
                playerName = Console.ReadLine();
            }
            Console.ResetColor();
            return playerName;
        }
        public int GetValidChoice(int numOptions)
        {
            //May can use this method for int validation throughout
            int option = 0;
            string userChoice = Console.ReadLine();
            bool goodInput = (int.TryParse(userChoice, out option));
            while (goodInput != true || (option < 1 || option > numOptions))
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Error: Please make a valid selection: ");
                Console.ResetColor();
                return -1;
            }
            Console.Clear();
            return option;
        }
    }
}