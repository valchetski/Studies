using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RWC2007.Plays;

namespace RWC2007
{
    /// <summary>
    /// Interaction logic for GameResult.xaml
    /// </summary>
    public partial class GameResultWindow
    {
        private readonly string firstTeam;
        private readonly string secondTeam;
        private readonly string pool;

        public GameResultWindow(string firstTeam, string secondTeam, string pool)
        {
            InitializeComponent();

            this.firstTeam = firstTeam;
            this.secondTeam = secondTeam;
            this.pool = pool;
            FirstTeamGoalsLabel.Content = $"{this.firstTeam} goals:";
            SecondTeamGoalsLabel.Content = $"{this.secondTeam} goals:";

            FirstTeamTriesLabel.Content = $"{this.firstTeam} tries:";
            SecondTeamTriesLabel.Content = $"{this.secondTeam} tries:";

            var games = FileOperations.Open();
            Game game = games.FirstOrDefault(g => g.Pool == pool && (g.Item1.Name == firstTeam || g.Item1.Name == secondTeam)
                                                    && (g.Item2.Name == secondTeam || g.Item2.Name == firstTeam));
            if (game != null)
            {
                OneButton.Content = "Save";
                RemoveButton.IsEnabled = true;
                if (firstTeam == game.Item1.Name)
                {
                    FirstTeamGoalsTextBox.Text = game.Item1.Goals.ToString();
                    FirstTeamTriesTextBox.Text = game.Item1.Tries.ToString();
                }
                else
                {
                    FirstTeamGoalsTextBox.Text = game.Item2.Goals.ToString();
                    FirstTeamTriesTextBox.Text = game.Item2.Tries.ToString();
                }

                if (secondTeam == game.Item1.Name)
                {
                    SecondTeamGoalsTextBox.Text = game.Item1.Goals.ToString();
                    SecondTeamTriesTextBox.Text = game.Item1.Tries.ToString();
                }
                else
                {
                    SecondTeamGoalsTextBox.Text = game.Item2.Goals.ToString();
                    SecondTeamTriesTextBox.Text = game.Item2.Tries.ToString();
                }
            }
            else
            {
                OneButton.Content = "Add";
                RemoveButton.IsEnabled = false;
            }

            FirstTeamGoalsTextBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var firstTeamGameResult = new GameResultForTeam
                {
                    Name = firstTeam,
                    Goals = Convert.ToInt32(FirstTeamGoalsTextBox.Text),
                    Tries = Convert.ToInt32(FirstTeamTriesTextBox.Text),
                };
                var secondTeamGameResult = new GameResultForTeam
                {
                    Name = secondTeam,
                    Goals = Convert.ToInt32(SecondTeamGoalsTextBox.Text),
                    Tries = Convert.ToInt32(SecondTeamTriesTextBox.Text),
                };
                firstTeamGameResult.Points = GameResultForTeam.GetPoints(firstTeamGameResult.Goals,
                    firstTeamGameResult.Tries, secondTeamGameResult.Goals);

                secondTeamGameResult.Points = GameResultForTeam.GetPoints(secondTeamGameResult.Goals,
                    secondTeamGameResult.Tries, firstTeamGameResult.Goals);


                var newGame = new Game(firstTeamGameResult, secondTeamGameResult) {Pool = pool};

                List<Game> previousGames = FileOperations.Open();
                var oldGame = previousGames.FirstOrDefault(g => g.Pool == pool && (g.Item1.Name == firstTeam || g.Item1.Name == secondTeam)
                                                    && (g.Item2.Name == secondTeam || g.Item2.Name == firstTeam));
                //Add
                if (oldGame == null || previousGames.Count == 0)
                {
                    previousGames.Add(newGame);
                }
                //Save
                else
                {
                    previousGames.Remove(oldGame);
                    previousGames.Add(newGame);
                }
                FileOperations.Save(previousGames);
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Введи данные нормально! Не тупи!");
            }
            
        }

        private void FirstTeamGoalsTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectAllInTextbox(sender);
        }

        private void SecondTeamGoalsTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectAllInTextbox(sender);
        }

        private void FirstTeamTriesTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectAllInTextbox(sender);
        }

        private void SecondTeamTriesTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SelectAllInTextbox(sender);
        }

        private void SelectAllInTextbox(object sender)
        {
            TextBox tb = (sender as TextBox);
            tb?.SelectAll();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            List<Game> previousGames = FileOperations.Open();
            var oldGame = previousGames.FirstOrDefault(g => g.Pool == pool && (g.Item1.Name == firstTeam || g.Item1.Name == secondTeam)
                                                && (g.Item2.Name == secondTeam || g.Item2.Name == firstTeam));
            previousGames.Remove(oldGame);
            FileOperations.Save(previousGames);
            Close();
        }

    }
}
