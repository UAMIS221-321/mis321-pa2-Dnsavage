using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis321_pa2_Dnsavage
{
    public class Player
    {
        public string PlayerName {get; set;}
        public int CharacterID {get; set;}
        public Character PlayerChar {get; set;}

        //Selects the player that will begin the game
        public static string ChooseFirstPlayer(Player[] players, ref int currentPlayer)
        {
            Random player = new Random();
            int randomPlayer = player.Next(2);//Either 0 or 1
            if (randomPlayer > 0)
            {
                currentPlayer = 1;
                return players[1].PlayerName;
            }
            return players[0].PlayerName;
        }
    }
}