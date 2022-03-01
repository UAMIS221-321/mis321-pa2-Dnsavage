using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_Dnsavage.Interfaces;
namespace mis321_pa2_Dnsavage
{
    public class Character
    {
        public string Name {get; set;}
        public int Health {get; set;}
        public int Power {get; set;}
        public int AttackStrength {get; set;}
        public int DefensePower {get; set;}
        public double AttackMult {get; set;}
        public int ModifyCounter {get; set;}
        public IAttack AttackBehavior {get; set;}
        public IDefend DefendBehavior {get; set;}
        public ISpecial SpecialBehavior {get; set;}
        public IModify EffectModifier {get; set;}

        //Sets the starting stats for each character
        public static void InitializeCharacters(NewGame playerInfo, Player[] players)
        {
            for (int i = 0; i < 2; i++)
            {
                players[i].PlayerChar = new Character();
                players[i].PlayerChar.Name = GetCharName(players, i);
                players[i].PlayerChar.Health = 100;
                players[i].PlayerChar.Power = GenPower();
                players[i].PlayerChar.DefensePower = 0;
                GetCharAbility(players, i);
                players[i].PlayerChar.AttackMult = GetCharMult(players, i);
                players[i].PlayerChar.ModifyCounter = 0;
                players[i].PlayerChar.EffectModifier = new NoModifier();
            }
        }
        //Initializes opponent's defense on first turn of the game
        public static void InitOppDefense(Player[] players, int currentPlayer)
        {
            if (currentPlayer == 0)
            {
                players[1].PlayerChar.DefensePower = DefenseCalc(players, 1);
            }
            else
            {
                players[0].PlayerChar.DefensePower = DefenseCalc(players, 0);
            }
        }

        //Calculates player's passive defense
        public static int DefenseCalc(Player[] players, int currentPlayer)
        {
            Random defense = new Random();
            return defense.Next(players[currentPlayer].PlayerChar.Power) + 1;
        }

        //Calculates player's active action (attack or defend)
        public static int ActionCalc(Player[] players, int currentPlayer, int selectedAction)
        {
            if (selectedAction == 1 && players[currentPlayer].PlayerChar.EffectModifier.Modify() == 1)
            {
                return 0;
            }
            else if (selectedAction == 2 && players[currentPlayer].PlayerChar.EffectModifier.Modify() == 2)
            {
                return 0;
            }
            Random action = new Random();
            int actionStrength = action.Next(players[currentPlayer].PlayerChar.Power) + 1;
            return actionStrength;
        }
        //Gets the selected character's name
        private static string GetCharName(Player[] players, int playerNum)
        {
            switch (players[playerNum].CharacterID)
            {
                case 1: return "Jack Sparrow";
                case 2: return "Will Turner";
                default: break;
            }
            return "Davy Jones";
        }
        //Generates a character's power
        private static int GenPower()
        {
            Random power = new Random();
            return power.Next(100) + 1;
        }
        //Assigns character ability based on character selection
        private static void GetCharAbility(Player[] players, int playerNum)
        {
            switch (players[playerNum].CharacterID)
            {
                case 1: 
                    players[playerNum].PlayerChar.AttackBehavior = new Distract();
                    players[playerNum].PlayerChar.DefendBehavior = new Hide();
                    players[playerNum].PlayerChar.SpecialBehavior = new Jar();
                    break;
                case 2: 
                    players[playerNum].PlayerChar.AttackBehavior = new Sword();
                    players[playerNum].PlayerChar.DefendBehavior = new Rope();
                    players[playerNum].PlayerChar.SpecialBehavior = new Motive();
                    break;
                case 3: 
                    players[playerNum].PlayerChar.AttackBehavior = new Cannon();
                    players[playerNum].PlayerChar.DefendBehavior = new Claw();
                    players[playerNum].PlayerChar.SpecialBehavior = new Servitude();
                    break;
            }
        }
        //Selects the appropriate attack multiplier based on each selected character
        private static double GetCharMult(Player[] players, int playerNum)
        {
            const double BONUS_MULT = 1.2;
            if (playerNum > 0)
            {
                switch (players[1].CharacterID)
                {
                    case 1:
                        if (players[0].CharacterID == 2)
                        {
                            return BONUS_MULT;
                        }
                        else
                        {
                            break;
                        }
                    case 2:
                        if (players[0].CharacterID == 3)
                        {
                            return BONUS_MULT;
                        }
                        else
                        {
                            break;
                        }
                    case 3:
                        if (players[0].CharacterID == 1)
                        {
                            return BONUS_MULT;
                        }
                        else
                        {
                            break;
                        }
                }
            }
            else
            {
                switch (players[0].CharacterID)
                {
                    case 1:
                        if (players[1].CharacterID == 2)
                        {
                            return 1.2;
                        }
                        else
                        {
                            break;
                        }
                    case 2:
                        if (players[1].CharacterID == 3)
                        {
                            return 1.2;
                        }
                        else
                        {
                            break;
                        }
                    case 3:
                        if (players[1].CharacterID == 1)
                        {
                            return 1.2;
                        }
                        else
                        {
                            break;
                        }
                }
            }
            return 1;
        }
    }
}