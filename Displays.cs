using System;

namespace mis321_pa2_Dnsavage
{
    public class Displays
    {
        public static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Battle of Calypso\n");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1.) New Game\n2.) About\n3.) Exit");
        }

        public static void PromptName1()
        {
            Console.WriteLine("Player 1: Enter your name:");
        }

        public static void PromptName2()
        {
            Console.Clear();
            Console.WriteLine("Player 2: Enter your name:");
        }

        public static void PromptPlayerName(Player[] players, int currentPlayer)
        {
            Console.Clear();
            Console.WriteLine($"{players[currentPlayer].PlayerName}: Choose your character:");
        }

        public static void DisplayCharacters()
        {
            Console.WriteLine("1.) Jack Sparrow | Ability: Distract Opponent");
            Console.WriteLine("2.) Will Turner  | Ability: Sword Slice");
            Console.WriteLine("3.) Davy Jones   | Ability: Canon Fire");
        }

        public static void DeclareFirstPlayer(Player[] players, ref int currentPlayer)
        {
            Console.WriteLine($"{Player.ChooseFirstPlayer(players, ref currentPlayer)} will go first!\n");
        }

        public static void PromptSelection(Player[] players, int currentPlayer)
        {
            Console.WriteLine($"{players[currentPlayer].PlayerName}, what will you do?");
            Console.WriteLine($"1.) Attack\n2.) Defend\n3.) {players[currentPlayer].PlayerChar.SpecialBehavior.Special()}");
            Console.WriteLine("4.) View My Stats\n5.) View Opponent's Stats\n6.) Surrender");
        }

        //Routes action dialogue displays for gameplay
        public static void ActionDialogue(Player[] players, int currentPlayer, int dmgDone, int actionPower, int selectedAction)
        {
            if (selectedAction == 1)
            {
                DisplayAttack(players, currentPlayer, actionPower);
                if (dmgDone == actionPower)
                {
                    DisplayAllHit();
                }
                else if (dmgDone < actionPower)
                {
                    DisplaySomeHit(dmgDone);
                }
                else
                {
                    DisplayBonusHit(dmgDone, actionPower);
                }
            }
            else if (selectedAction == 2)
            {
                DisplayDefense(players, currentPlayer, actionPower);
            }
        }
        //EXTRA: Displays modifier, if any, for the current player's character
        public static void DisplayModifier(Player[] players, int currentPlayer)
        {
            players[currentPlayer].PlayerChar.EffectModifier.Effect();
        }

        public static void DisplayNewTurn(Player[] players, int currentPlayer)
        {
            Console.WriteLine($"It is now {players[currentPlayer].PlayerName}'s turn!\n");
        }

        public static void DisplayAttack(Player[] players, int currentPlayer, int actionPower)
        {
            Console.WriteLine($"{players[currentPlayer].PlayerName} used {players[currentPlayer].PlayerChar.AttackBehavior.Attack()} for {actionPower} damage!");
        }

        public static void DisplayDefense(Player[] players, int currentPlayer, int actionPower)
        {
            Console.Write($"{players[currentPlayer].PlayerName} used {players[currentPlayer].PlayerChar.DefendBehavior.Defend()} for {actionPower} extra defense, totaling {players[currentPlayer].PlayerChar.DefensePower} defense!\n\n");
        }
        //EXTRA: Displays special moves
        public static void DisplaySpecial(Player[] players, int currentPlayer)
        {
            Console.WriteLine($"{players[currentPlayer].PlayerName} used {players[currentPlayer].PlayerChar.SpecialBehavior.Special()}!");
            if (currentPlayer == 0)
            {
                if (players[1].PlayerChar.EffectModifier.Modify() < 0)
                {
                    Console.WriteLine("It was ineffective!\n");
                }
                else
                {
                    Console.WriteLine();
                }
            }
            else
            {
                if (players[0].PlayerChar.EffectModifier.Modify() < 0)
                {
                    Console.WriteLine("It was ineffective!\n");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        public static void DisplayAllHit()
        {
            Console.Write($"All of which reached the opponent!\n\n");
        }

        public static void DisplaySomeHit(int dmgDone)
        {
            Console.Write($"{dmgDone} of which reached the opponent!\n\n");
        }

        public static void DisplayBonusHit(int dmgDone, int actionPower)
        {
            Console.Write($"All of which reached the opponent, plus {dmgDone-actionPower} points of bonus damage!\n\n");
        }

        public static void DisplayWinner(Player[] players, int winner)
        {
            Console.WriteLine($"{players[winner].PlayerName} won!");
        }

        public static void PromptMainMenu()
        {
            Console.WriteLine("Press enter to return to main menu.");
        }

        public static void DisplaySurrenderConfirm(Player[] players, int currentPlayer, int timeAsked)
        {
            if (timeAsked == 1)
            {
                Console.WriteLine($"{players[currentPlayer].PlayerName}, are you sure you wish to surrender?\n\n");
            }
            else
            {
                Console.WriteLine("Do You wish to proceed?\n1.) Yes\n2.) No");
            }
        }

        public static void DisplayFinalizeSurrender(Player[] players, int currentPlayer)
        {
            Console.WriteLine($"{players[currentPlayer].PlayerName} surrendered!");
            Console.WriteLine("Press enter to return to main menu.");
            Console.ReadLine();
        }

        //EXTRA: Power status supplement to the situation report
        public static void DisplayPowerStatus(Player[] players, int currentPlayer, int oppPlayer)
        {
            if (players[currentPlayer].PlayerChar.Power > players[oppPlayer].PlayerChar.Power)
            {
                Console.WriteLine("You are more powerful than your opponent");
            }
            else if (players[currentPlayer].PlayerChar.Power < players[oppPlayer].PlayerChar.Power)
            {
                Console.WriteLine("Your opponent is more powerful than you");
            }
            else
            {
                Console.WriteLine("You and your opponent are evenly matched in terms of power.");
            }
        }
        //EXTRA: Health status supplement to the situation report
        public static void DisplayHealthStatus(Player[] players, int currentPlayer, int oppPlayer)
        {
            if (players[currentPlayer].PlayerChar.Health > players[oppPlayer].PlayerChar.Health)
            {
                Console.WriteLine("You are in better health than your opponent.");
            }
            else if (players[currentPlayer].PlayerChar.Health < players[oppPlayer].PlayerChar.Health)
            {
                Console.WriteLine("Your opponent is in better health than you");
            }
            else
            {
                Console.WriteLine("You and your opponent are the same in terms of health");
            }
        }
        //Displays the requested player's stats
        public static void DisplayStats(Player[] players, int playerNum)
        {
            Console.WriteLine($"{players[playerNum].PlayerName}'s current stats:");
            Console.WriteLine($"Character: {players[playerNum].PlayerChar.Name}");
            Console.WriteLine($"Max Power: {players[playerNum].PlayerChar.Power}");
            Console.WriteLine($"Health: {players[playerNum].PlayerChar.Health}\n");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        //EXTRA: Asks the player if they are sure they wish to surrender
        public static void PromptSurrender(Player[] players, int currentPlayer)
        {
            DisplaySurrenderConfirm(players, currentPlayer, 1);
            if (currentPlayer == 0)
            {
                SitRep(players, 0);
            }
            else
            {
                SitRep(players, 1);
            }
        }
        //EXTRA: Gives the current active player a detailed situation report prior to choosing whether to surrender
        public static void SitRep(Player[] players, int currentPlayer)
        {
            int oppPlayer = -1;

            if (currentPlayer == 0)
            {
                oppPlayer = 1;
            }
            else
            {
                oppPlayer = 0;
            }
            DisplayPowerStatus(players, currentPlayer, oppPlayer);
            DisplayHealthStatus(players, currentPlayer, oppPlayer);
            for (int i = 0; i < 2; i++)
            {
                DisplayStats(players, i);
            }
            DisplaySurrenderConfirm(players, currentPlayer, 2);
        }
        //Displays the winner and prompts for return to main menu
        public static void GameOver(Player[] players, int winner)
        {
            DisplayWinner(players, winner);
            PromptMainMenu();
            Console.ReadLine();
            Console.Clear();
        }

        public static void ThankUser()
        {
            Console.WriteLine("Thanks for playing Battle of Calypso!");
        }
    }
}