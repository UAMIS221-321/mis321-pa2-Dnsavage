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
            const double SERV_MOD = 0.2;
            if (currentPlayer == 0)
            {
                if (selectedAction == 1)
                {
                    if (actionPower < players[1].PlayerChar.DefensePower)
                    {
                        actionPower = players[1].PlayerChar.DefensePower;
                    }
                    dmgDone = (int)(Math.Round(((actionPower - players[1].PlayerChar.DefensePower) * (players[0].PlayerChar.AttackMult)), MidpointRounding.AwayFromZero));
                    if (players[currentPlayer].PlayerChar.EffectModifier.Modify() == 1)
                    {
                        dmgDone = 0;
                    }
                    players[1].PlayerChar.Health -= dmgDone;
                    players[0].PlayerChar.DefensePower = defenseStrength;
                    if (players[currentPlayer].PlayerChar.EffectModifier.Modify() == 3)
                    {
                        players[currentPlayer].PlayerChar.Health -= (int)(Math.Round((dmgDone * SERV_MOD), MidpointRounding.AwayFromZero));
                    }
                }
                else if (selectedAction == 2)
                {
                    aggDefense = AggDefenseCalc(actionPower, defenseStrength);
                    if (aggDefense > actionPower)
                    {
                        aggDefense = actionPower;
                    }
                    if (players[currentPlayer].PlayerChar.EffectModifier.Modify() == 2)
                    {
                        actionPower = 0;
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
                    if (players[currentPlayer].PlayerChar.EffectModifier.Modify() == 1)
                    {
                        dmgDone = 0;
                    }
                    players[0].PlayerChar.Health -= dmgDone;
                    players[1].PlayerChar.DefensePower = defenseStrength;
                    if (players[currentPlayer].PlayerChar.EffectModifier.Modify() == 3)
                    {
                        players[currentPlayer].PlayerChar.Health -= (int)(Math.Round((dmgDone * SERV_MOD), MidpointRounding.AwayFromZero));
                    }
                }
                else if (selectedAction == 2)
                {
                    aggDefense = AggDefenseCalc(actionPower, defenseStrength);
                    if (aggDefense > actionPower)
                    {
                        aggDefense = actionPower;
                    }
                    if (players[currentPlayer].PlayerChar.EffectModifier.Modify() == 2)
                    {
                        actionPower = 0;
                    }
                    players[1].PlayerChar.DefensePower = AggDefenseCalc(actionPower, defenseStrength);
                }
            }
            return dmgDone;
        }
        //EXTRA: Routes the flow of control to special effects application if a special move was successful
        public static void SpecialMove(NewGame playerInfo, Player[] players, int currentPlayer)
        {
            if (SpecialSuccessCalc(playerInfo, players, currentPlayer) == true)
            {
                ApplySpecialEffect(playerInfo, players, currentPlayer);
            }
        }
        //EXTRA: Calculates whether a special move is successful or not based on the current players power
        public static bool SpecialSuccessCalc(NewGame playerInfo, Player[] players, int currentPlayer)
        {
            Random success = new Random();
            int successChance = success.Next(99)+1;
            if (successChance <= players[currentPlayer].PlayerChar.Power)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //EXTRA: Applies modifier counters to the afflicted player's character
        public static void ApplySpecialEffect(NewGame playerInfo, Player[] players, int currentPlayer)
        {
            if (players[currentPlayer].PlayerChar.Name == "Jack Sparrow")
            {
                if (currentPlayer == 0)
                {
                    players[1].PlayerChar.EffectModifier = new Stunned();
                    if (players[1].PlayerChar.Name == "Davy Jones")
                    {
                        players[1].PlayerChar.ModifyCounter = 2;
                    }
                    else
                    {
                        players[1].PlayerChar.ModifyCounter = 1;
                    }
                }
                else
                {
                    players[0].PlayerChar.EffectModifier = new Stunned();
                    if (players[0].PlayerChar.Name == "Davy Jones")
                    {
                        players[0].PlayerChar.ModifyCounter = 2;
                    }
                    else
                    {
                        players[0].PlayerChar.ModifyCounter = 1;
                    }
                }
            }
            else if (players[currentPlayer].PlayerChar.Name == "Will Turner")
            {
                if (currentPlayer == 0)
                {
                    players[1].PlayerChar.EffectModifier = new Betrayed();
                    if (players[1].PlayerChar.Name == "Jack Sparrow")
                    {
                        players[1].PlayerChar.ModifyCounter = 2;
                    }
                    else
                    {
                        players[1].PlayerChar.ModifyCounter = 1;
                    }
                }
                else
                {
                    players[0].PlayerChar.EffectModifier = new Betrayed();
                    if (players[0].PlayerChar.Name == "Jack Sparrow")
                    {
                        players[0].PlayerChar.ModifyCounter = 2;
                    }
                    else
                    {
                        players[0].PlayerChar.ModifyCounter = 1;
                    }
                }
            }
            else
            {
                if (currentPlayer == 0)
                {
                    players[1].PlayerChar.EffectModifier = new Recruited();
                    if (players[1].PlayerChar.Name == "Will Turner")
                    {
                        players[1].PlayerChar.ModifyCounter = 2;
                    }
                    else
                    {
                        players[1].PlayerChar.ModifyCounter = 1;
                    }
                }
                else
                {
                    players[0].PlayerChar.EffectModifier = new Recruited();
                    if (players[0].PlayerChar.Name == "Will Turner")
                    {
                        players[0].PlayerChar.ModifyCounter = 2;
                    }
                    else
                    {
                        players[0].PlayerChar.ModifyCounter = 1;
                    }
                }
            }
        }
        //Changes the active player at the end of a turn
        public static int NewTurn(Player[] players, int currentPlayer)
        {
            HandleModifier(players, currentPlayer);
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
        //EXTRA: Decerements modifier counters and removes modifiers once the counter reaches 0
        public static void HandleModifier(Player[] players, int currentPlayer)
        {
            if (players[currentPlayer].PlayerChar.ModifyCounter >= 1)
            {
                players[currentPlayer].PlayerChar.ModifyCounter--;
            }
            if (players[currentPlayer].PlayerChar.ModifyCounter == 0)
            {
                players[currentPlayer].PlayerChar.EffectModifier = new NoModifier();
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