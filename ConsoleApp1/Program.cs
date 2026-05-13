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
			Task.Delay(300).Wait(200);
			Console.Clear();

			// Menue
			while (true)
			{
				//refresh screen
				Console.Clear();

				//a
				Console.WriteLine("Hello," + firstName + "!");
				Task.Delay(300).Wait(200);
				Console.WriteLine("1 rockps");
				Task.Delay(300).Wait(200);
				Console.WriteLine("2 tictactoe");
				Task.Delay(300).Wait(200);

				//save user under a name for this
				Console.WriteLine("3 leaderboard");
				Task.Delay(300).Wait(200);
				Console.WriteLine("4 settings or smth");


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
						Task.Delay(600);
						break;

				}

			}

		}

		static void rock()
		{
			//refresh screen
			Console.Clear();

			// select the rock paper sciccors
			Task.Delay(300).Wait(200);
			Console.WriteLine("1 pr rock 2 for s 3 for paper");
			string RPS = Console.ReadLine();

			//the thing actual


			//go back, or stay
			Console.Clear();
			Task.Delay(300).Wait(200);
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

			// select the ttt tile
			Task.Delay(300).Wait(200);
			Console.WriteLine("select tile, x's turn:");
			string playerX = Console.ReadLine();

			Task.Delay(300).Wait(200);
			Console.WriteLine("select tile, O's turn:");
			string playerO = Console.ReadLine();

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
