using RPS.Lib;
using RPS.Lib.AI;
using RPS.WPFApp.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPS.WPFApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private RockPaperScissors rps = new RockPaperScissors();
		private Gesture player1Gesture = Gesture.None;
		private Gesture player2Gesture = Gesture.None;

		public MainWindow()
		{
			InitializeComponent();
		}

		protected override void OnSourceInitialized(EventArgs e)
		{
			IconHelper.RemoveIcon(this);
		}

		private void btnPlayer1Rock_Click(object sender, RoutedEventArgs e)
		{
			player1Gesture = Gesture.Rock;
			updateImages();
		}

		private void btnPlayer1Paper_Click(object sender, RoutedEventArgs e)
		{
			player1Gesture = Gesture.Paper;
			updateImages();
		}

		private void btnPlayer1Scissors_Click(object sender, RoutedEventArgs e)
		{
			player1Gesture = Gesture.Scissors;
			updateImages();
		}


		private void btnPlayer2Rock_Click(object sender, RoutedEventArgs e)
		{
			player2Gesture = Gesture.Rock;
			updateImages();
		}

		private void btnPlayer2Paper_Click(object sender, RoutedEventArgs e)
		{
			player2Gesture = Gesture.Paper;
			updateImages();
		}

		private void btnPlayer2Scissors_Click(object sender, RoutedEventArgs e)
		{
			player2Gesture = Gesture.Scissors;
			updateImages();
		}

		private void btnPlayerGame_Click(object sender, RoutedEventArgs e)
		{
			playGame();
		}

		private void playGame()
		{
			if (menuSinglePlayer.IsChecked)
			{
				displayResults(rps.PlaySinglePlayerGame(player1Gesture)); //player1 vs bot game
			}

			if (menuMultiplayer.IsChecked)
			{
				displayResults(rps.PlayMultiplayerGame(player1Gesture, player2Gesture));
			}

			if (menuBotVsBot.IsChecked)
			{
				displayResults(rps.PlayBotVsBot()); // bot vs bot
			}
		}

		private void displayResults(RockPaperScissors rps)
		{
			lblGameNumber.Content = string.Format("Game Number: {0}", rps.GameCount);
			lblPlayer1Score.Content = string.Format("P1 SCORE: {0}", rps.Player1Score);
			lblPlayer2Score.Content = string.Format("P2 SCORE: {0}", rps.Player2Score);
			lblPlayer1WinLose.Content = rps.Player1Result.ToString();
			lblPlayer2WinLose.Content = rps.Player2Result.ToString();

			player1Gesture = rps.Player1Gesture;
			player2Gesture = rps.Player2Gesture;

			updateImages();
		}

		private void updateImages()
		{
			imagePlayer1.Source = new BitmapImage(new Uri(string.Format("Resources/{0}.png", player1Gesture.ToString()), UriKind.Relative));
			imagePlayer2.Source = new BitmapImage(new Uri(string.Format("Resources/{0}.png", player2Gesture.ToString()), UriKind.Relative));
		}

		private void enablePlayer1(bool enable)
		{
			imagePlayer1.Source = new BitmapImage(new Uri("Resources/None.png", UriKind.Relative));

			if (enable)
			{
				btnPlayer1Rock.IsEnabled = true;
				btnPlayer1Paper.IsEnabled = true;
				btnPlayer1Scissors.IsEnabled = true;
			}
			else
			{
				btnPlayer1Rock.IsEnabled = false;
				btnPlayer1Paper.IsEnabled = false;
				btnPlayer1Scissors.IsEnabled = false;
			}
		}

		private void enablePlayer2(bool enable)
		{
			imagePlayer2.Source = new BitmapImage(new Uri("Resources/None.png", UriKind.Relative));

			if (enable)
			{
				btnPlayer2Rock.IsEnabled = true;
				btnPlayer2Paper.IsEnabled = true;
				btnPlayer2Scissors.IsEnabled = true;
			}
			else
			{
				btnPlayer2Rock.IsEnabled = false;
				btnPlayer2Paper.IsEnabled = false;
				btnPlayer2Scissors.IsEnabled = false;
			}
		}

		private void menuMultiplayer_Click(object sender, RoutedEventArgs e)
		{
			if (!menuMultiplayer.IsChecked)
			{
				resetGame(true, false, false, true, true);
			}
		}

		private void menuSinglePlayer_Click(object sender, RoutedEventArgs e)
		{
			if (!menuSinglePlayer.IsChecked)
			{
				resetGame(false, true, false, true, false);
			}
		}

		private void menuBotVsBot_Click(object sender, RoutedEventArgs e)
		{
			if (!menuBotVsBot.IsChecked)
			{
				resetGame(false, false, true, false, false);
			}
		}

		private void resetGame(bool isMultiplayerChecked, bool isSinglePlayerChecked, bool isBotvsBotChecked, bool isEnablePlayer1, bool isEnablePlayer2)
		{
			menuMultiplayer.IsChecked = isMultiplayerChecked;
			menuSinglePlayer.IsChecked = isSinglePlayerChecked;
			menuBotVsBot.IsChecked = isBotvsBotChecked;

			enablePlayer1(isEnablePlayer1);
			enablePlayer2(isEnablePlayer2);

			player1Gesture = Gesture.None;
			player2Gesture = Gesture.None;

			rps.Reset();
		}

		private void menuBotRandom_Click(object sender, RoutedEventArgs e)
		{
			if (!menuBotRandom.IsChecked)
			{
				rps.SetBotAI(new RandomBot());

				menuBotMirror.IsChecked = false;
				menuBotRandom.IsChecked = true;
				menuBotDumbRock.IsChecked = false;
				menuBotImpossible.IsChecked = false;
				menuBotRandomAllTechniques.IsChecked = false;
			}
		}

		private void menuBotDumbRock_Click(object sender, RoutedEventArgs e)
		{
			if (!menuBotDumbRock.IsChecked)
			{
				rps.SetBotAI(new DumbAsRockBot());

				menuBotMirror.IsChecked = false;
				menuBotRandom.IsChecked = false;
				menuBotDumbRock.IsChecked = true;
				menuBotImpossible.IsChecked = false;
				menuBotRandomAllTechniques.IsChecked = false;
			}
		}

		private void menuBotMirror_Click(object sender, RoutedEventArgs e)
		{
			if (!menuBotMirror.IsChecked)
			{
				rps.SetBotAI(new MirrrorPlayerBot());

				menuBotMirror.IsChecked = true;
				menuBotRandom.IsChecked = false;
				menuBotDumbRock.IsChecked = false;
				menuBotImpossible.IsChecked = false;
				menuBotRandomAllTechniques.IsChecked = false;
			}
		}

		private void menuBotImpossible_Click(object sender, RoutedEventArgs e)
		{
			if (!menuBotImpossible.IsChecked)
			{
				rps.SetBotAI(new ImpossibleBot());

				menuBotMirror.IsChecked = false;
				menuBotRandom.IsChecked = false;
				menuBotDumbRock.IsChecked = false;
				menuBotImpossible.IsChecked = true;
				menuBotRandomAllTechniques.IsChecked = false;
			}
		}

		private void menuBotRandomAllTechniques_Click(object sender, RoutedEventArgs e)
		{
			if (!menuBotRandomAllTechniques.IsChecked)
			{
				rps.SetBotAI(new RandomAllTechniquesBot());

				menuBotMirror.IsChecked = false;
				menuBotRandom.IsChecked = false;
				menuBotDumbRock.IsChecked = false;
				menuBotImpossible.IsChecked = false;
				menuBotRandomAllTechniques.IsChecked = true;
			}
		}	
	}
}
