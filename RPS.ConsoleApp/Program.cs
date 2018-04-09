using RPS.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.ConsoleApp
{
	class Program
	{
		private static RockPaperScissors rps = new RockPaperScissors();

		static void Main(string[] args)
		{
			const int maxMenuItems = 3;
			int selector = 0;
			bool input = false;
			while (selector != maxMenuItems)
			{
				Console.Clear();
				drawTitle();
				drawGameMenu();

				input = int.TryParse(Console.ReadLine(), out selector);
				if (input)
				{
					switch (selector)
					{
						case 1:
							displayResult(rps.PlaySinglePlayerGame(Gesture.Rock));
							break;
						case 2:
							displayResult(rps.PlaySinglePlayerGame(Gesture.Paper));
							break;
						case 3:
							displayResult(rps.PlaySinglePlayerGame(Gesture.Scissors));
							break;
						// possibly more cases here
						default:
							if (selector != maxMenuItems)
							{
								errorMessage();
							}
							break;
					}
				}
				else
				{
					errorMessage();
				}
			}
		}
		private static void drawTitle()
		{
			drawStarLine();
			Console.WriteLine("+++   Rock, Paper, Scissors!   +++");
			drawStarLine();
		}

		private static void drawMenu()
		{
			drawStarLine();
			Console.WriteLine(" 1. Play Against Bot");
			Console.WriteLine(" 2. Play Against Human");
			// more here
			Console.WriteLine(" 0. Exit program");
			drawStarLine();
			Console.WriteLine("Make your choice (0 to exit):  ");
			drawStarLine();
		}

		private static void drawGameMenu()
		{
			drawStarLine();
			Console.WriteLine("\t 1. Rock");
			Console.WriteLine("\t 2. Paper");
			Console.WriteLine("\t 3. Scissors");
			drawStarLine();
			Console.WriteLine("Make your choice (0 to exit):  ");
			drawStarLine();
		}

		private static void drawStarLine()
		{
			Console.WriteLine("************************");
		}

		private static void displayResult(RockPaperScissors rps)
		{
			Console.WriteLine("Player Gesture: {0}, Bot Gesture: {1}", rps.Player1Gesture, rps.Player2Gesture);
			Console.WriteLine("Game Result: {0}!", rps.Player1Result);

			Console.WriteLine("Game Count: {0}", rps.GameCount);
			Console.WriteLine("Player One Score: {0}, Player Two Score: {1}", rps.Player1Score, rps.Player2Score);

			Console.Read();
		}

		private static void errorMessage()
		{
			Console.WriteLine("ERROR");
		}
	}
}
