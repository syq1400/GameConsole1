using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	internal class Program
	{
		static Random rand = new Random();
		
		static void Main()
		{
			// user, don't save the user but save the name
			Console.WriteLine("Please enter username:");
			string firstName = Console.ReadLine();
			Console.Clear();

			// Menue
			while (true)
			{
				//refresh screen
				Console.Clear();

				//a
				Console.WriteLine("Hello," + firstName + "!");
				Console.WriteLine("Enter 1 to play Rock Paper Scissors");
				Console.WriteLine("Enter 2 to play TIc Tac Toe");

				//save user under a name for this
				Console.WriteLine("Enter 3 to see Leaderboard");
				Console.WriteLine("Enter 4 to see settings");


				//choice
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
						leader();
						break;

					case "4":
						settings();
						break;

					default:
						Console.WriteLine("choose smth else");
						Console.WriteLine("---");
						break;

				}

			}

		}

		static void rock()
		{
			//refresh screen
			Console.Clear();

			// select the rock paper sciccors
			string[] choices = { "rock", "scissors", "paper" };

			Console.WriteLine("Enter rock, scissors or paper");
			string userChoice = Console.ReadLine().ToLower();

			// check
			if (choices.Contains(userChoice))
			{
				Console.WriteLine("\nYou chose " + userChoice + "!");	
			}
			else
			{
				Console.WriteLine("Invalid option, type your choice correctly.\nEnter to continue;");
				Console.ReadLine();
				rock();
			}

			//comupter select
			Random rand = new Random();
			string computerChoice = choices[rand.Next(choices.Length)];
			Console.WriteLine("The computer chose " + computerChoice + "!");

			//suspense
			Console.WriteLine("\n ... \n");

			//check
			if (userChoice == computerChoice)
			{
				Console.WriteLine("tie");
			}
			else if (
				(userChoice == "rock" && computerChoice == "scissors") ||
				(userChoice == "scissors" && computerChoice == "paper") ||
				(userChoice == "paper" && computerChoice == "rock"))
			{
				Console.WriteLine("win");
			}
			else
			{
			Console.WriteLine("lose lmao");
			}
			Console.WriteLine(" ");

			//go back, or stay
			Console.WriteLine("1 to stay, any key to go back to menu");
			string choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					rock();
					break;

				default:
					Console.Clear();
					break;
			}
		}
		

		static void ttt()
		{
			//refresh screen
			Console.Clear();

			//ttt
			Console.WriteLine("You are player X.\nYour friend is player O.\nPlayer O goes first!");

			//ttt array tiles
			string[,] board =
			{
				{ "1", "2", "3" },
				{ "4", "5", "6" },
				{ "7", "8", "9"}
			};

			//see the tiles visible
			Console.WriteLine(board[0, 0] + board[0, 1] + board[0, 2]);
			Console.WriteLine(board[1, 0] + board[1, 1] + board[1, 2]);
			Console.WriteLine(board[2, 0] + board[2, 1] + board[2, 2]);

			// select the ttt tile
			Console.WriteLine("select tile, x's turn:");
			string playerXinput = Console.ReadLine();

			Console.WriteLine("select tile, O's turn:");
			string playerOinput = Console.ReadLine();

			//go back, or stay
			Console.Clear();
			Console.WriteLine("1 to stay, any key to go back to menu");
			string choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					ttt();
					break;

				default:
					Console.Clear();
					break;
			}
		}

		static void leader()
        {
			//clear screen
			Console.Clear();

			Console.WriteLine("l");

			// Leave
			Console.WriteLine("press enter to leave:");
			string b = Console.ReadLine();

		}

		static void settings()
        {
			//clear screen
			Console.Clear();

			Console.WriteLine("ssss");

			// Leave
			Console.WriteLine("press enter to leave:");
			string b = Console.ReadLine();
		}

	}
}
