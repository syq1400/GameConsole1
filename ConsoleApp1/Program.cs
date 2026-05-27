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
            Task.Delay(100).Wait();
            Console.WriteLine("Please enter username:");
            string firstName = Console.ReadLine();
            Task.Delay(100).Wait();

            if (string.IsNullOrEmpty(firstName))
            {
                Task.Delay(100).Wait();
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

                Task.Delay(100).Wait();
                //a
                Console.WriteLine("Hello, " + firstName + "!\n");

                Task.Delay(100).Wait();
                Console.WriteLine("Enter 1 to play Rock Paper Scissors");

                Task.Delay(100).Wait();
                Console.WriteLine("Enter 2 to play Tic Tac Toe");

                //save user under a name for this or smth else but make it unique
                Task.Delay(100).Wait();
                Console.WriteLine("Enter 3 to enter your Aquarium");

                //choice
                Task.Delay(100).Wait();
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
                        Task.Delay(100).Wait();
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
            Task.Delay(100).Wait();
            if (choices.Contains(userChoice))
            {
                Console.WriteLine("\nYou chose " + userChoice + "!");
                
                //comupter select
                Random rand = new Random();
                string computerChoice = choices[rand.Next(choices.Length)];
                Console.WriteLine("The computer chose " + computerChoice + "!");

                //suspense
                Task.Delay(100).Wait();
                Console.WriteLine("\n  ...\n");
                Task.Delay(100).Wait();

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
            }
            else
            {
                Console.WriteLine("Invalid option, Type your choice correctly.\nTaking you back to selection");
                Task.Delay(100).Wait();
                rock();
            }

            //go back to menu, or stay
            Task.Delay(100).Wait();
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
            Task.Delay(100).Wait();
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
                Task.Delay(100).Wait();

                Console.WriteLine(playBoard[0, 0] + " | " + playBoard[0, 1] + " | " + playBoard[0, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(playBoard[1, 0] + " | " + playBoard[1, 1] + " | " + playBoard[1, 2]);
                Console.WriteLine("----------");
                Console.WriteLine(playBoard[2, 0] + " | " + playBoard[2, 1] + " | " + playBoard[2, 2]);
                Console.WriteLine("\n");
                Task.Delay(100).Wait();

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
                            Task.Delay(100).Wait();
                            Console.WriteLine("Loading..\n");
                            Task.Delay(100).Wait();

                            Console.WriteLine(currentPlayer + " won!\nAny key to leave.");
                            Console.ReadKey();
                        }
                        else if (checkTie())
                        {
                            Console.Clear();
                            Task.Delay(100).Wait();
                            Console.WriteLine("Loading..\n");
                            Task.Delay(100).Wait();

                            Console.WriteLine("Its a tie, no one won.\nAny key to leave to leave");
                            Console.ReadKey();
                        }
                        currentPlayer = "O";
                    }
                    else
                    {
                        Task.Delay(100).Wait();
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
                            Task.Delay(100).Wait();
                            Console.WriteLine("Loading..\n");
                            Task.Delay(100).Wait();

                            Console.WriteLine(currentPlayer + " won!\nAny key to leave.");
                            Console.ReadKey();
                        }
                        else if (checkTie())
                        {
                            Console.Clear();
                            Task.Delay(100).Wait();
                            Console.WriteLine("Loading..\n");
                            Task.Delay(100).Wait();

                            Console.WriteLine("Its a tie, no one won.\nAny key to leave to leave");
                            Console.ReadKey();
                        }
                        currentPlayer = "X";
                    }
                    else
                    {
                        Task.Delay(100).Wait();
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
            Task.Delay(100).Wait();
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

            Task.Delay(200).Wait();
            Console.WriteLine("Your fish is feeling very " + fishMood[rand.Next(fishMood.Length)] + " today!\n");
            Task.Delay(100).Wait();
            Console.WriteLine("Your fish " + fishThoughts[rand.Next(fishThoughts.Length)]);

            // Leave or let the fish go
            Task.Delay(100).Wait();
            Console.WriteLine("\nType verbs to interact with the fish, such as: feed, pet, play\nEnter to go back to the main menu.");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                default:
                    break;

                case "feed":
                    Task.Delay(100).Wait();
                    Console.WriteLine("\nIt liked that. Enter any key to leave.");
                    Task.Delay(100).Wait();
                    Console.ReadKey();
                    break;

                case "pet":
                    Task.Delay(100).Wait();
                    Console.WriteLine("\nYou can't pet fish, sorry. Enter any key to leave.");
                    Task.Delay(100).Wait();
                    Console.ReadKey();
                    break;

                case "annoy":
                    Task.Delay(100).Wait();
                    Console.WriteLine("\nIt hates you even more now. Enter any key to leave.");
                    Task.Delay(100).Wait();
                    Console.ReadKey();
                    break;

                case "eat":
                    Task.Delay(100).Wait();
                    Console.WriteLine("\n???");
                    Task.Delay(600).Wait();
                    Environment.Exit(0);
                    break;

                case "stare":
                    Task.Delay(100).Wait();
                    Console.WriteLine("\nIt feels self concious. Enter any key to leave.");
                    Task.Delay(100).Wait();
                    Console.ReadKey();
                    break;

                case "play":
                    string[] playWithFish = { "used a laser pointer", "swished around seaweed", "drove a boat toy", "couldn't find anything to play with"};
                    Task.Delay(100).Wait();
                    Console.WriteLine("\nYou " + playWithFish[rand.Next(playWithFish.Length)] + ". It feels " + fishMood[rand.Next(fishMood.Length)] + " now. Enter any key to leave.");
                    Task.Delay(100).Wait();
                    Console.ReadKey();
                    break;

                case "let go":
                    Task.Delay(100).Wait();
                    Console.WriteLine("\nAre you sure? This will completly shut down the game,\nType in and enter yes or no\n");
                    Task.Delay(100).Wait();
                    string quitDecision = Console.ReadLine().ToLower();

                    Task.Delay(100).Wait();
                    if (quitDecision == "yes")
                    {
                        Console.WriteLine("\nShutting down..");
                        Task.Delay(400).Wait();
                        Environment.Exit(0);
                        break;
                    }
                    else if (quitDecision == "no")
                    {
                        Console.WriteLine("\nOk, going back to the main menu.");
                        Task.Delay(600).Wait();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid input, taking you back to the main menu.");
                        Task.Delay(600).Wait();
                        break;

                    }
            }
        }
    }
}