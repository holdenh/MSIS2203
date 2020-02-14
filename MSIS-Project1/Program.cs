﻿using System;

namespace MSIS_Project1
{
    class Program
    {
        /* method that will ask user for input about the number of roudns. */
        public static int getRoundLimit()
        {
            int limit = 1;
            Console.Write("Would you like to play a best of(1)one, (3)three, or(5)five ? : ");
            limit = Convert.ToInt32(Console.ReadLine());

            /* check if input is a 1, 3, or 5. If not retry user input. */
            if (limit != 1 && limit != 3 && limit != 5)
            {
                Console.WriteLine("Invalid input please try again.");
                limit = getRoundLimit();
            }

            return limit;
        }
        /* method that will take a given number of rounds, and return the number of rounds needed to win in a best of match of that number. */
        public static int setWinLimit(int num)
        {
            int limit = 0;
            /* set the value of limit based on the different possible values of the number passed in.  */
            switch (num)
            {
                case 1:
                    limit = 1;
                    break;
                case 3:
                    limit = 2;
                    break;
                case 5:
                    limit = 3;
                    break;
            }

            return limit;
        }
        /* method that asks user for input, and returns a string */
        public static string getUserSelection()
        {
            string selection = "";
            /* take user input */
            Console.Write("(r)ock, (p)aper, (s)cissors, (l)izard, or spoc(k) : ");
            selection = Console.ReadLine();
            /* test whether user input is valid, if not retry user entry. */
            if (selection.ToLower() != "r" && selection.ToLower() != "p" && selection.ToLower() != "s" && selection.ToLower() != "l"
               && selection.ToLower() != "k")
            {
                selection = getUserSelection();
            }
            /* if valid, transplate input to full word selection. */
            if (selection == "r")
            {
                selection = "rock";
            }
            else if (selection == "p")
            {
                selection = "paper";
            }
            else if (selection == "s")
            {
                selection = "scissors";
            }
            else if (selection == "l")
            {
                selection = "lizard";
            }
            else
            {
                selection = "spock";
            }

            return selection;
        }
        /* method that will take two string parameters, and will return the string word "player" or "comp" */
        public static string getRoundWinner(string uSelection, string cSelection)
        {
            string roundWinner = "";
            string compSelectionLower = cSelection.ToLower();
            /* game logic */
            switch (uSelection.ToLower())
            {
                /* Rock beats Scissors/Lizard, and loses to Paper/Spock. */
                case "rock":
                    /* check for winner. */
                    if (compSelectionLower == "scissors" || compSelectionLower == "lizard")
                    {
                        roundWinner = "Player";
                    }
                    else if (compSelectionLower == uSelection.ToLower())
                    {
                        roundWinner = "tie";
                    }
                    else
                    { /* player lost round. */
                        roundWinner = "Computer";
                    }
                    break;
                /* Paper beats Rock/Spock, and loses to Scissors/Lizard */
                case "paper":
                    /* check for winner. */
                    if (compSelectionLower == "rock" || compSelectionLower == "spock")
                    {
                        roundWinner = "Player";
                    }
                    else if (compSelectionLower == uSelection.ToLower())
                    {
                        roundWinner = "tie";
                    }
                    else
                    { /* player lost round. */
                        roundWinner = "Computer";
                    }
                    break;
                /* Scissors beats Paper/Lizard, and loses to Rock/Spock */
                case "scissors":
                    /* check for winner. */
                    if (compSelectionLower == "paper" || compSelectionLower == "lizard")
                    {
                        roundWinner = "Player";
                    }
                    else if (compSelectionLower == uSelection.ToLower())
                    {
                        roundWinner = "tie";
                    }
                    else
                    { /* player lost round. */
                        roundWinner = "Computer";
                    }
                    break;
                /* Lizard beats Paper/Spock, and loses to Rock/Scissors */
                case "lizard":
                    /* check for winner. */
                    if (compSelectionLower == "paper" || compSelectionLower == "spock")
                    {
                        roundWinner = "Player";
                    }
                    else if (compSelectionLower == uSelection.ToLower())
                    {
                        roundWinner = "tie";
                    }
                    else
                    { /* player lost round. */
                        roundWinner = "Computer";
                    }
                    break;
                /* Spockj beats Rock/Scissors, and loses to Paper/Lizard */
                case "spock":
                    /* check for winner. */
                    if (compSelectionLower == "rock" || compSelectionLower == "scissors")
                    {
                        roundWinner = "Player";
                    }
                    else if (compSelectionLower == uSelection.ToLower())
                    {
                        roundWinner = "tie";
                    }
                    else
                    { /* player lost round. */
                        roundWinner = "Computer";
                    }
                    break;
            }

            return roundWinner;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /* variables. */
            bool quit = false;
            string[] selections = { "rock", "paper", "scissors", "lizard", "spock" };
            string uSelection;
            string cSelection;
            int playerWins;
            int compWins;
            int numRounds;
            int currentRound;
            int winLimit;
            Random rand = new Random();

            /* play game */
            while (!quit)
            {
                playerWins = 0;
                compWins = 0;
                numRounds = 0;
                currentRound = 0;
                /* Ask user for number of rounds. */
                Console.Write("WELCOME TO ROCK PAPER SCISSOR LIZARD SPOCK!\n\n ");
                numRounds = getRoundLimit();
                winLimit = setWinLimit(numRounds);
                Console.Clear();
                while (currentRound < numRounds)
                {
                    /* take user and computer selections */
                    Console.WriteLine("ROUND {0}!\n", currentRound + 1);
                    uSelection = getUserSelection();
                    cSelection = selections[rand.Next(0, selections.Length)];
                    /* find the winner of the round, and add the round point. */
                    string winner = getRoundWinner(uSelection, cSelection);
                    Console.WriteLine("You played {0}. Computer played {1}.", uSelection, cSelection);
                    if (winner == "tie")
                    {
                        Console.WriteLine("This line was a tie.");
                        continue;
                    }
                    else if (winner == "Player")

                    {
                        /* increment player win count */
                        playerWins++;
                    }
                    else
                    {
                        /* increment computer win count */
                        compWins++;
                    }

                    /* print output and increment round. */
                    Console.WriteLine(winner + " wins round {0}!", currentRound + 1);
                    currentRound++;
                    /* check if the win limit as been reached. */
                    if (playerWins == winLimit && currentRound != numRounds)
                    {
                        Console.WriteLine("Player has won {0} out of {1} rounds. No need to play to {2}.", playerWins, currentRound, numRounds);
                        break;
                    }
                    else if (compWins == winLimit && currentRound != numRounds)
                    {
                        Console.WriteLine("Computer has won {0} out of {1} rounds. No need to play to {2}.", compWins, currentRound, numRounds);
                        break;
                    }
                }
                /* Ask if play want to retry. */
                Console.Write("Play again(y/Y or anything else for no.)? : ");
                string retry = Console.ReadLine();
                if (retry == "y" || retry == "Y")
                {
                    Console.Clear();
                }
                else
                {
                    quit = true;
                }
            }
        }
    }
}