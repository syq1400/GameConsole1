using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {
        static Random rand = new Random();

        static void Main()
        {
            // user enter
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Please enter username:");
            string firstName = Console.ReadLine();
            System.Threading.Thread.Sleep(100);

            if (string.IsNullOrEmpty(firstName))
            {
                System.Threading.Thread.Sleep(100);
                Console.WriteLine("\nYour name can't be empty, type it correctly.\nPress any key to try again");
                Console.ReadKey();
                Console.Clear();
                Main();
            }

            // Menue
            while (true)
            {
                //refresh screen
                Console.Clear();

                System.Threading.Thread.Sleep(100);
                //a
                Console.WriteLine("Hello, " + firstName + "!\n");

                System.Threading.Thread.Sleep(100);
                Console.WriteLine("Enter 1 to play Rock Paper Scissors");

                System.Threading.Thread.Sleep(100);
                Console.WriteLine("Enter 2 to play Tic Tac Toe");

                //save user under a name for this or smth else but make it unique
                System.Threading.Thread.Sleep(100);
                Console.WriteLine("Enter 3 to enter your Aquarium");

                //exit  and restart
                System.Threading.Thread.Sleep(100);
                Console.WriteLine("\nEnter 4 to Quit");


                //choice
                System.Threading.Thread.Sleep(100);
                string choice = Console.ReadLine();

                //choice
                switch (choice)
                {
                    case "1":
                        rock();
                        break;

                    case "2":
                        ttt();
                        break;

                    case "3":
                        aquarium();
                        break;

                    default:
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine("\nInvalid option, type your choice correctly.\nEnter to continue;\n");
                        Console.ReadLine();
                        break;

                }

            }

        }

        static void rock()
        {
            //refresh screen
            Console.Clear();

            // display and select rock paper sciccors
            string[] choices = { "rock", "scissors", "paper" };

            Console.WriteLine("Welcome to Rock Paper Scissors!\nEnter in either: Rock, Paper, or Scissors:\n");
            string userChoice = Console.ReadLine().ToLower();

            // check
            System.Threading.Thread.Sleep(100);
            if (choices.Contains(userChoice))
            {
                Console.WriteLine("\nYou chose " + userChoice + "!");
            }
            else
            {
                Console.WriteLine("Invalid option, Type your choice correctly.\nTaking you back to selection");
                System.Threading.Thread.Sleep(700);
                rock();
            }

            //comupter select
            Random rand = new Random();
            string computerChoice = choices[rand.Next(choices.Length)];
            Console.WriteLine("The computer chose " + computerChoice + "!");

            //suspense
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\n  ...\n");
            System.Threading.Thread.Sleep(1000);

            //check
            if (userChoice == computerChoice)
            {
                Console.WriteLine("  tie");
            }
            else if (
                (userChoice == "rock" && computerChoice == "scissors") ||
                (userChoice == "scissors" && computerChoice == "paper") ||
                (userChoice == "paper" && computerChoice == "rock"))
            {
                Console.WriteLine("  win");
            }
            else
            {
                Console.WriteLine("  lose lmao");
            }

            //go back to menu, or stay
            System.Threading.Thread.Sleep(200);
            Console.WriteLine("\nType and enter 1 to stay and play again, Enter to go back to menu.");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    rock();
                    break;

                default:
                    break;
            }
        }


        static void ttt()
        {
            //refresh screen and intro
            Console.Clear();
            Console.WriteLine("Welcome to Tic Tac Toe!\n");
            System.Threading.Thread.Sleep(100);
            bool tttPlaying = true;

            //ttt array tiles
            string[] playerChoices = { "X", "O" };

            //random the current player
            Random rand = new Random();
            string currentPlayer = playerChoices[rand.Next(playerChoices.Length)];
            Console.WriteLine("\nPlayer: " + currentPlayer + " is going first. Any key to begin!");
            Console.ReadKey();

            string[,] playBoard =
                {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9"}
                };

            while (tttPlaying)
            {
                //clear
                Console.Clear();
                System.Threading.Thread.Sleep(100);

                Console.WriteLine(playBoard[0, 0] + " | " + playBoard[0, 1] + " | " + playBoard[0, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(playBoard[1, 0] + " | " + playBoard[1, 1] + " | " + playBoard[1, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(playBoard[2, 0] + " | " + playBoard[2, 1] + " | " + playBoard[2, 2]);
                Console.WriteLine("\n");
                System.Threading.Thread.Sleep(100);

                // select the ttt tile and check

                //X
                if (currentPlayer == "X")
                {
                    Console.WriteLine("X's Turn.\nChoose a spot to place your choice:");
                    string tttInput = Console.ReadLine();

                    if (placeChoice())
                    {
                        if (checkWin())
                        {
                            Console.Clear();
                            System.Threading.Thread.Sleep(100);
                            Console.WriteLine("Loading..\n");
                            System.Threading.Thread.Sleep(400);

                            Console.WriteLine(currentPlayer + " won!\nAny key to leave.");
                            Console.ReadKey();
                        }
                        else if (checkTie())
                        {
                            Console.Clear();
                            System.Threading.Thread.Sleep(100);
                            Console.WriteLine("Loading..\n");
                            System.Threading.Thread.Sleep(400);

                            Console.WriteLine("Its a tie, no one won.\nAny key to leave to leave");
                            Console.ReadKey();
                        }
                        currentPlayer = "O";
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine("\nInvalid input, any key to try again.");
                        Console.ReadKey();
                    }

                    //check if place
                    bool placeChoice()
                    {
                        if (int.TryParse(tttInput, out int tttInputMove))
                        {
                            if (tttInputMove > 9 || tttInputMove < 0) { return false; }

                            int tttRow = (tttInputMove - 1) / 3;
                            int tttCol = (tttInputMove - 1) % 3;

                            if (playBoard[tttRow, tttCol] != "X" && playBoard[tttRow, tttCol] != "O")
                            {
                                playBoard[tttRow, tttCol] = currentPlayer;
                                return true;
                            }
                            else { return false; }
                        }
                        else { return false; }
                    }
                }
                //O
                else
                {
                    Console.WriteLine("O's Turn.\nChoose a spot to place your choice:");
                    string tttInput = Console.ReadLine();

                    if (placeChoice())
                    {
                        if (checkWin())
                        {
                            Console.Clear();
                            System.Threading.Thread.Sleep(100);
                            Console.WriteLine("Loading..\n");
                            System.Threading.Thread.Sleep(400);

                            Console.WriteLine(currentPlayer + " won!\nAny key to leave.");
                            Console.ReadKey();
                        }
                        else if (checkTie())
                        {
                            Console.Clear();
                            System.Threading.Thread.Sleep(100);
                            Console.WriteLine("Loading..\n");
                            System.Threading.Thread.Sleep(400);

                            Console.WriteLine("Its a tie, no one won.\nAny key to leave to leave");
                            Console.ReadKey();
                        }
                        currentPlayer = "X";
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(100);
                        Console.WriteLine("Invalid input, any key to try again.");
                        Console.ReadKey();
                    }
                    
                    //check if place
                    bool placeChoice()
                    {
                        if (int.TryParse(tttInput, out int tttInputMove))
                        {
                            if (tttInputMove > 9 || tttInputMove < 0) { return false; }
                            int tttRow = (tttInputMove - 1) / 3;
                            int tttCol = (tttInputMove - 1) % 3;

                            if (playBoard[tttRow, tttCol] != "X" && playBoard[tttRow, tttCol] != "O")
                            {
                                playBoard[tttRow, tttCol] = currentPlayer;
                                return true;
                            }
                            else { return false; }
                        }
                        else { return false; }
                    }
                }

                //check if win function
                bool checkWin()
                {
                    //right directions
                    for (int theRow = 0; theRow < 3; theRow++)
                    {
                        if (playBoard[theRow, 0] == currentPlayer && playBoard[theRow, 1] == currentPlayer && playBoard[theRow, 2] == currentPlayer)
                        {
                            tttPlaying = false;
                            return true;
                        }
                    }
                    for (int theCol = 0; theCol < 3; theCol++)
                    {
                        if (playBoard[0, theCol] == currentPlayer && playBoard[1, theCol] == currentPlayer && playBoard[2, theCol] == currentPlayer)
                        {
                            tttPlaying = false;
                            return true;
                        }
                    }

                    //diagonal wins
                    if (playBoard[0, 0] == currentPlayer && playBoard[1, 1] == currentPlayer && playBoard[2, 2] == currentPlayer)
                    {
                        tttPlaying = false;
                        return true;
                    }
                    else if (playBoard[0, 2] == currentPlayer && playBoard[1, 1] == currentPlayer && playBoard[2, 0] == currentPlayer)
                    {
                        tttPlaying = false;
                        return true;
                    }
                    else { return false; }
                }

                bool checkTie()
                {
                    for (int tieRow = 0; tieRow < 3; tieRow++)
                    {
                        for (int tieCol = 0; tieCol < 3; tieCol++)
                        {
                            if (playBoard[tieCol, tieRow] != "X" && playBoard[tieCol, tieRow] != "O")
                            {
                                return false;
                            }
                        }
                    }
                    tttPlaying = false;
                    return true;
                }
            }

            //leave
            Console.WriteLine("Enter 1 to stay and play again, Enter to go back to menu.");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ttt();
                    break;

                default:
                    break;
            }
        }

        private static void aquarium()
        {
            //clear screen
            Console.Clear();


            //the tank
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            System.Threading.Thread.Sleep(150);
            Console.WriteLine("Your aquarium:\n\n");

            Console.WriteLine("      +                |+ ");
            Console.WriteLine("     +|     <;鱼《    +-+");
            Console.WriteLine("      |+            +|");
            Console.WriteLine("    ----------------------\n\n");

            //fishes personality
            Random rand = new Random();
            string[] fishMood = { "Happy", "Lonely", "Sad", "Annoyed", "Hungry", "Hopeful", "much nothing" };
            string[] fishThoughts = {
                "thinks you should go play Rock Paper Scissors.",
                "hopes you have friends to play tic tac toe with. It doesn't want to play with you.",
                "is sleeping. Don't disturb it.",
                "wants to be fed.",
                "appreciates you.",
                "wants to be free",
                "is dreaming of the sea.",
                "wants to leave the aquarium. It tells you to type in Let Go before pressing enter to go back home."};

            System.Threading.Thread.Sleep(200);
            Console.WriteLine("Your fish is feeling very " + fishMood[rand.Next(fishMood.Length)] + " today!\n");
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Your fish " + fishThoughts[rand.Next(fishThoughts.Length)]);

            // Leave or let the fish go
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("\nType verbs to interact with the fish, such as: feed, pet, play\nEnter to go back to the main menu.");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                default:
                    break;

                case "feed":
                    Console.WriteLine("\nIt liked that. Enter any key to leave.");
                    Console.ReadKey();
                    break;

                case "pet":
                    Console.WriteLine("\nYou can't pet fish, sorry. Enter any key to leave.");
                    Console.ReadKey();
                    break;

                case "play":
                    string[] playWithFish = { "used a laser pointer", "swished around seaweed", "drove a boat toy", "couldn't find anything to play with"};
                    Console.WriteLine("\nYou " + playWithFish[rand.Next(playWithFish.Length)] + ". It feels " + fishMood[rand.Next(fishMood.Length)] + " now. Enter any key to leave.");
                    Console.ReadKey();
                    break;

                case "let go":
                    System.Threading.Thread.Sleep(100);
                    Console.WriteLine("\nAre you sure? This will completly shut down the game,\nType in and enter yes or no\n");
                    string quitDecision = Console.ReadLine().ToLower();

                    System.Threading.Thread.Sleep(100);
                    if (quitDecision == "yes")
                    {
                        Console.WriteLine("\nShutting down..");
                        System.Threading.Thread.Sleep(500);
                        Environment.Exit(0);
                        break;
                    }
                    else if (quitDecision == "no")
                    {
                        Console.WriteLine("\nOk, going back to the main menu.");
                        System.Threading.Thread.Sleep(500);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input, taking you back to the main menu.");
                        System.Threading.Thread.Sleep(500);
                        break;

                    }
            }
        }
    }
}