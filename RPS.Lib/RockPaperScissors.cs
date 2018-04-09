using RPS.Lib.AI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS.Lib
{
	public class RockPaperScissors : IGame
	{
		private Bot bot = new Bot(new RandomBot());
		public Gesture Player1Gesture { get; private set; }
		public Gesture Player2Gesture { get; private set; }
		public Result Player1Result { get; private set; }
		public Result Player2Result { get; private set; }
		public int GameCount { get; private set; }
		public int Player1Score { get; private set; }
		public int Player2Score { get; private set; }
		public IBotAI botAI { get; set; } 

		public RockPaperScissors()
		{
		}

		public void SetBotAI(IBotAI botAI)
		{
			bot = new Bot(botAI);
		}

		public RockPaperScissors PlayBotVsBot()
		{
			Player1Gesture = bot.GetGesture(Player2Gesture);
			Player2Gesture = bot.GetGesture(Player1Gesture);

			return playGame();
		}

		public RockPaperScissors PlaySinglePlayerGame(Gesture player1Gesture)
		{

			Player1Gesture = player1Gesture;
			Player2Gesture = bot.GetGesture(player1Gesture);

			return playGame();
		}

		public RockPaperScissors PlayMultiplayerGame(Gesture player1Gesture, Gesture player2Gesture)
		{
			Player1Gesture = player1Gesture;
			Player2Gesture = player2Gesture;

			return playGame();
		}

		private RockPaperScissors playGame()
		{
			GameCount++;

			if (Player1Gesture == Player2Gesture)
			{
				Player1Result = Result.Draw;
				Player2Result = Result.Draw;
			}

			if (Player1Gesture == Gesture.Paper)
			{
				if (Player2Gesture == Gesture.Rock)
				{
					Player1Result = Result.Win;
					Player2Result = Result.Lose;
					Player1Score++;
				}
				if (Player2Gesture == Gesture.Scissors)
				{
					Player1Result = Result.Lose;
					Player2Result = Result.Win;
					Player2Score++;
				}
			}

			if (Player1Gesture == Gesture.Rock)
			{
				if (Player2Gesture == Gesture.Scissors)
				{
					Player1Result = Result.Win;
					Player2Result = Result.Lose;
					Player1Score++;
				}
				if (Player2Gesture == Gesture.Paper)
				{
					Player1Result = Result.Lose;
					Player2Result = Result.Win;
					Player2Score++;
				}
			}

			if (Player1Gesture == Gesture.Scissors)
			{
				if (Player2Gesture == Gesture.Paper)
				{
					Player1Result = Result.Win;
					Player2Result = Result.Lose;
					Player1Score++;
				}
				if (Player2Gesture == Gesture.Rock)
				{
					Player1Result = Result.Lose;
					Player2Result = Result.Win;
					Player2Score++;
				}
			}

			return this;
		}

		public void Reset()
		{
			Player1Score = 0;
			Player2Score = 0;
			GameCount = 0;
			Player1Gesture = Gesture.None;
			Player2Gesture = Gesture.None;
		}
	}

	public enum Gesture
	{
		Rock,
		Paper,
		Scissors,
		None
	}

	public enum Result
	{
		Draw,
		Win,
		Lose
	}
}
