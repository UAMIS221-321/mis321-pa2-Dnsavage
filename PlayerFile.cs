using System;
namespace mis321_pa2_Dnsavage
{
    public class PlayerFile
    {
        //Gets user player names
        public static void GetUserNames(NewGame playerInfo, Player[] players)
        {
            Console.Clear();
            Displays.PromptName1();
            players[0] = new Player();
            players[0].PlayerName = playerInfo.GetPlayerName();

            Displays.PromptName2();
            players[1] = new Player();
            players[1].PlayerName = playerInfo.GetPlayerName();
        }
        //Gets character selections
        public static void SelectCharacters(NewGame playerInfo, Player[] players)
        {
            for(int i = 0; i < 2; i++)
            {
                Displays.PromptPlayerName(players, i);
                Displays.DisplayCharacters();
                int selectedID = playerInfo.GetValidChoice(3);
                while (selectedID < 1)
                {
                    Displays.PromptPlayerName(players, i);
                    Displays.DisplayCharacters();
                    selectedID = playerInfo.GetValidChoice(3);
                }
                players[i].CharacterID = selectedID;
            }
        }
    }
}