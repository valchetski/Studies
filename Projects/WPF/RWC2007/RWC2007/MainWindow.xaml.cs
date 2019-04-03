using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RWC2007.Plays;

namespace RWC2007
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow
    {
        private readonly List<PlayoffCouple> playoffCouples;

        private readonly MouseButtonEventHandler myE;
        public MainWindow()
        {
            InitializeComponent();

            myE += (sender, args) => RefreshCouples();
            PoolA.MouseDoubleClick += myE;
            PoolB.MouseDoubleClick += myE;
            PoolC.MouseDoubleClick += myE;
            PoolD.MouseDoubleClick += myE;

            playoffCouples = new List<PlayoffCouple>
            {
                FirstQF, SecondQF,ThirdQF,FourthQF, FirstSF, SecondSF, Final, ForThirdPlace
            };

            FillCouples();
        }

        private void FillCouples()
        {
            var games = FileOperations.Open();
            foreach (var couple in playoffCouples)
            {
                var game = games.FirstOrDefault(g => g.Pool == couple.Name);
                if (game != null)
                {
                    couple.FillCouple(game.Item1.Goals, game.Item2.Goals);
                }
            }

            FirstSF.PreviousGame1 = FirstQF;
            FirstSF.PreviousGame2 = SecondQF;

            SecondSF.PreviousGame1 = ThirdQF;
            SecondSF.PreviousGame2 = FourthQF;

            Final.PreviousGame1 = FirstSF;
            Final.PreviousGame2 = SecondSF;

            ForThirdPlace.PreviousGame1 = FirstSF;
            ForThirdPlace.PreviousGame2 = SecondSF;
        }

        private void RefreshCouples()
        {
            foreach (var couple in playoffCouples)
            {
                couple.Refresh();
            }
        }

        private void SetEditable(bool isEditable)
        {
            foreach (var couple in playoffCouples)
            {
                couple.SetEditable(isEditable);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button.Content.ToString() == "Edit")
            {
                button.Content = "Save";
                SetEditable(true);
            }
            else
            {
                var games = FileOperations.Open();
                foreach (var couple in playoffCouples)
                {
                    if (couple.FirstTeamGoals != null && couple.SecondTeamGoals != null)
                    {
                        var gameResultForTeam1 = new GameResultForTeam
                        {
                            Name = couple.FirstTeamName,
                            Goals = couple.FirstTeamGoals.Value
                        };
                        var gameResultForTeam2 = new GameResultForTeam
                        {
                            Name = couple.SecondTeamName,
                            Goals = couple.SecondTeamGoals.Value
                        };
                        var newGame = new Game(gameResultForTeam1, gameResultForTeam2) {Pool = couple.Name};

                        var oldGame = games.FirstOrDefault(g => g.Pool == couple.Name);
                        if (oldGame != null)
                        {
                            games[games.IndexOf(oldGame)] = newGame;
                        }
                        else
                        {
                            games.Add(newGame);
                        }
                    }
                    else
                    {
                        var game1 = games.FirstOrDefault(g => g.Pool == couple.Name);
                        games.Remove(game1);
                    }
                }
                FileOperations.Save(games);
                FillCouples();
                
                button.Content = "Edit";
                SetEditable(false);
            }
            
        }

    }
}
