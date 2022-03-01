using System;
using System.IO;

namespace mis321_pa2_Dnsavage
{
    public class AboutFile
    {
        //EXTRA: Displays information about the lore of the game and the characters within it
        public static void DisplayAbout()
        {
            Console.Clear();
            StreamReader inFile = new StreamReader("about.txt");

            string line = inFile.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = inFile.ReadLine();
            }
            inFile.Close();
            Displays.PromptMainMenu();
            Console.ReadLine();
            Console.Clear();
        }
    }
}