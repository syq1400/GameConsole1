using System;
using System.Collections.Generic;
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
            // user, don't save the user but save the name
            System.Threading.Thread.Sleep(100);
            Console.WriteLine("Please enter username:");
			string firstName = Console.ReadLine();
            System.Threading.Thread.Sleep(200);


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
						pet();
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
            Console.WriteLine("\nType 1 to stay and play again, Enter to go back to menu.");
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
            bool tttPlaying = true;

            while (tttPlaying)
            {
                //ttt array tiles
                string[] playerChoices = { "X", "O" };

                //see the tiles visible
                tttBoard();

                //random the current player
                Random rand = new Random();
                string currentPlayer = playerChoices[rand.Next(playerChoices.Length)];
                Console.WriteLine("\nPlayer: " + currentPlayer + " is going first");

                // select the ttt tile
                if (currentPlayer == "X")
                {
                    Console.WriteLine("X's Turn");
                    string tttInputX = Console.ReadLine();

                    currentPlayer = "O";
                }
                else
                {
                    Console.WriteLine("O's Turn");
                    string tttInputY = Console.ReadLine();

                    currentPlayer = "X";
                }
                break;
            }

            //go back, or stay
            Console.WriteLine("Type 1 to stay and play again, Enter to go back to menu.");
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

		static void tttBoard()
		{
            string[,] board =
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9"}
            };

            Console.WriteLine(board[0, 0] + board[0, 1] + board[0, 2]);
            Console.WriteLine(board[1, 0] + board[1, 1] + board[1, 2]);
            Console.WriteLine(board[2, 0] + board[2, 1] + board[2, 2]);
        }

		static void pet()
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
            string[] fishMood = { "Happy", "Lonely", "Sad", "Annoyed", "Hungry", "Hopeful", "much nothing"};
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
            Console.WriteLine("\nEnter to go back to the main menu.");
            string choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                default:
                    break;

                case "let go":
                    System.Threading.Thread.Sleep(100);
                    Console.WriteLine("\nAre you sure? This will completly shut down the game,\nType yes or no\n");
                    string quitDecision = Console.ReadLine().ToLower();

                    System.Threading.Thread.Sleep(100);
                    if (quitDecision == "yes")
                    {
                        Console.WriteLine("\nShutting down");
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
