using System;
using System.Collections.Generic;

namespace mis321_pa2_Dnsavage
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }
        //Gets the main menu choice and passes it along for routing
        static void MainMenu()
        {
            NewGame playerInfo = new NewGame();

            Displays.DisplayMainMenu();
            int menuChoice = playerInfo.GetValidChoice(3);
            while (menuChoice < 1)
            {
                Displays.DisplayMainMenu();
                menuChoice = playerInfo.GetValidChoice(3);
            }
            RouteMainMenu(playerInfo, menuChoice);
        }
        static void RouteMainMenu(NewGame playerInfo, int menuChoice)
        {
            Player[] players = new Player[2];

            switch (menuChoice)
            {
                case 1:
                    PlayerFile.GetUserNames(playerInfo, players);
                    PlayerFile.SelectCharacters(playerInfo, players);
                    Character.InitializeCharacters(playerInfo, players);
                    InitializeBattle(playerInfo, players);
                    break;
                case 2:
                    AboutFile.DisplayAbout();
                    MainMenu();
                    break;
                case 3:
                    Displays.ThankUser();
                    Environment.Exit(0);
                    break;
            }
        }
        //Initializes both players' for the game
        static void InitializeBattle(NewGame playerInfo, Player[] players)
        {
            int currentPlayer = 0;
            Displays.DeclareFirstPlayer(players, ref currentPlayer);
            Character.InitOppDefense(players, currentPlayer);
            SelectionPhase(playerInfo, players, currentPlayer);
        }
        //Primary selection phase: This is where players will select their preferred action during the game
        static void SelectionPhase(NewGame playerInfo, Player[] players, int currentPlayer)
        {
            Displays.PromptSelection(players, currentPlayer);
            int selectedAction = playerInfo.GetValidChoice(5);
            while (selectedAction < 1)
            {
                Displays.PromptSelection(players, currentPlayer);
                selectedAction = playerInfo.GetValidChoice(5);
            }
            RouteSelection(playerInfo, players, currentPlayer, selectedAction);
        }
        static void RouteSelection(NewGame playerInfo, Player[] players, int currentPlayer, int selectedAction)
        {
            if (selectedAction == 1 || selectedAction == 2)
            {
                ActionPhase(playerInfo, players, currentPlayer, selectedAction);
            }
            else if (selectedAction == 3 || selectedAction == 4)
            {
                RouteStatsView(playerInfo, players, currentPlayer, selectedAction);
            }
            else
            {
                RouteSurrender(playerInfo, players, currentPlayer, selectedAction);
            }
        }
        //Routes the flow of control to the action calculator, followed by a report of what happened
        static void ActionPhase(NewGame playerInfo, Player[] players, int currentPlayer, int selectedAction)
        {
            ReportPhase(playerInfo, players, Character.ActionCalc(players, currentPlayer, selectedAction), selectedAction, currentPlayer);
        }
        //Displays the outcome of the current turn
        static void ReportPhase(NewGame playerInfo, Player[] players, int actionPower, int selectedAction, int currentPlayer)
        {
            Displays.ActionDialogue(players, currentPlayer, 
                Battle.ActionFulfill(players, actionPower, selectedAction, currentPlayer, 
                Character.DefenseCalc(players, currentPlayer)), actionPower, selectedAction);
            CheckWinCondition(players);
            SelectionPhase(playerInfo, players, Battle.NewTurn(players, currentPlayer));
        }
        //Checks if either player has won
        static void CheckWinCondition(Player[] players)
        {
            if (players[0].PlayerChar.Health <= 0)
            {
                Displays.GameOver(players, 1);
                MainMenu();
            }
            else if (players[1].PlayerChar.Health <= 0)
            {
                Displays.GameOver(players, 0);
                MainMenu();
            }
        }
        //Determines which stats to show the current player based off their action selection
        static void RouteStatsView(NewGame playerInfo, Player[] players, int currentPlayer, int selectedAction)
        {
            if (selectedAction == 3)
            {
                Displays.DisplayStats(players, currentPlayer);
            }
            else if (selectedAction == 4)
            {
                if (currentPlayer == 0)
                {
                    Displays.DisplayStats(players, 1);
                }
                else
                {
                    Displays.DisplayStats(players, 0);
                }
            }
            SelectionPhase(playerInfo, players, currentPlayer);
        }
        //EXTRA: Checks if the current player selected to surrender and routes the player appropriately
        static void RouteSurrender(NewGame playerInfo, Player[] players, int currentPlayer, int selectedAction)
        {
            ConfirmSurrender(playerInfo, players, currentPlayer, selectedAction);
            SelectionPhase(playerInfo, players, currentPlayer);
        }
        //EXTRA: Confirms that a given player wants to surrender
        static void ConfirmSurrender(NewGame playerInfo, Player[] players, int currentPlayer, int selectedAction)
        {
            Displays.PromptSurrender(players, currentPlayer);
            int surrenderSelect = playerInfo.GetValidChoice(2);
            while (surrenderSelect < 1)
            {
                Displays.PromptSurrender(players, currentPlayer);
                surrenderSelect = playerInfo.GetValidChoice(2);
            }
            RouteConfirmSurrender(players, currentPlayer, surrenderSelect);
        }
        //Returns to main menu if a player chooses to surrender
        static void RouteConfirmSurrender(Player[] players, int currentPlayer, int surrenderSelect)
        {
            if (surrenderSelect == 1)
            {
                Displays.DisplayFinalizeSurrender(players, currentPlayer);
                MainMenu();
            }
        }
    }
}
