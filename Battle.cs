using System;
namespace mis321_pa2_Dnsavage
{
    public class Battle
    {
        //Fulfills damage and defense deliveries
        public static int ActionFulfill(Player[] players, int actionPower, int selectedAction, int currentPlayer, int defenseStrength)
        {
            int dmgDone = 0;
            int aggDefense = 0;
            if (currentPlayer == 0)
            {
                if (selectedAction == 1)
                {
                    if (actionPower < players[1].PlayerChar.DefensePower)
                    {
                        actionPower = players[1].PlayerChar.DefensePower;
                    }
                    dmgDone = (int)(Math.Round(((actionPower - players[1].PlayerChar.DefensePower) * (players[0].PlayerChar.AttackMult)), MidpointRounding.AwayFromZero));
                    players[1].PlayerChar.Health -= dmgDone;
                    players[0].PlayerChar.DefensePower = defenseStrength;
                }
                else
                {
                    aggDefense = AggDefenseCalc(actionPower, defenseStrength);
                    if (aggDefense > actionPower)
                    {
                        aggDefense = actionPower;
                    }
                    players[0].PlayerChar.DefensePower = AggDefenseCalc(actionPower, defenseStrength);
                }
                
            }
            else
            {
                if (selectedAction == 1)
                {
                    if (actionPower < players[0].PlayerChar.DefensePower)
                    {
                        actionPower = players[0].PlayerChar.DefensePower;
                    }
                    dmgDone = (int)(Math.Round(((actionPower - players[0].PlayerChar.DefensePower) * (players[1].PlayerChar.AttackMult)), MidpointRounding.AwayFromZero));
                    players[0].PlayerChar.Health -= dmgDone;
                    players[1].PlayerChar.DefensePower = defenseStrength;
                }
                else
                {
                    aggDefense = AggDefenseCalc(actionPower, defenseStrength);
                    if (aggDefense > actionPower)
                    {
                        aggDefense = actionPower;
                    }
                    players[1].PlayerChar.DefensePower = AggDefenseCalc(actionPower, defenseStrength);
                }
            }
            return dmgDone;
        }
        //Changes the active player at the end of a turn
        public static int NewTurn(Player[] players, int currentPlayer)
        {
            if (currentPlayer == 0)
            {
                Displays.DisplayNewTurn(players, 1);
                ResetDefense(players, 1);
                return 1;
            }
            else
            {
                Displays.DisplayNewTurn(players, 0);
                ResetDefense(players, 0);
                return 0;
            }
        }
        //Calculates total aggregate defense (sum of passive defense plus active defense, when applicable)
        private static int AggDefenseCalc(int actionPower, int defenseStrength)
        {
            return actionPower + defenseStrength;
        }
        //Reset players defense after opponent's turn
        private static void ResetDefense(Player[] players, int toReset)
        {
            players[toReset].PlayerChar.DefensePower = 0;
        }
    }
}