using System;
using System.Linq;
using System.Windows.Controls;
using RWC2007.Plays;

namespace RWC2007
{
    /// <summary>
    /// Interaction logic for PlayoffCouple.xaml
    /// </summary>
    public partial class PlayoffCouple
    {
        private PlayoffCouple previousGame1;

        public PlayoffCouple PreviousGame1
        {
            get { return previousGame1; }
            set
            {
                previousGame1 = value;
                SetTeam(previousGame1, FirstTeamLabel);
            }
        }

        private PlayoffCouple previousGame2;

        public PlayoffCouple PreviousGame2
        {
            get { return previousGame2; }
            set
            {
                previousGame2 = value;
                SetTeam(previousGame2, SecondTeamLabel);
            }
        }

        private string firstPool;

        public string FirstPool
        {
            get { return firstPool; }
            set
            {
                firstPool = value;
                SetTeam(firstPool, true, FirstTeamLabel);
            }
        }

        private string secondPool;

        public string SecondPool
        {
            get { return secondPool; }
            set
            {
                secondPool = value;
                SetTeam(secondPool, false, SecondTeamLabel);
            }
        }

        public string FirstTeamName => FirstTeamLabel.Content.ToString();

        public string SecondTeamName => SecondTeamLabel.Content.ToString();

        public int? FirstTeamGoals
        {
            get
            {
                int goals;
                return int.TryParse(FirstTeamGoalsTextBox.Text, out goals) ? (int?) goals : null;
            }
        }

        public int? SecondTeamGoals
        {
            get
            {
                int goals;
                return int.TryParse(SecondTeamGoalsTextBox.Text, out goals) ? (int?)goals : null;
            }
        }

        public string Id { get; set; }

        public PlayoffCouple()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            if (PreviousGame1 != null && PreviousGame2 != null)
            {
                SetTeam(PreviousGame1, FirstTeamLabel);
                SetTeam(PreviousGame2, SecondTeamLabel);
            }
            else
            {
                SetTeam(FirstPool, true, FirstTeamLabel);
                SetTeam(SecondPool, false, SecondTeamLabel);
            }
        }

        public void FillCouple(int firstTeamGoals, int secondTeamGoals)
        {
            FirstTeamGoalsTextBox.Text = firstTeamGoals.ToString();
            SecondTeamGoalsTextBox.Text = secondTeamGoals.ToString();
        }

        public void SetEditable(bool isEditable)
        {
            FirstTeamGoalsTextBox.IsEnabled = isEditable;
            SecondTeamGoalsTextBox.IsEnabled = isEditable;
        }



        private void SetTeam(string pool, bool isFirstTeamFromGroup, Label label)
        {
            var teamsAndPoints = Game.GetTeamsAndPoints(pool);
            string team = teamsAndPoints.FirstOrDefault().Key;
            if (isFirstTeamFromGroup == false)
            {
                team = teamsAndPoints.FirstOrDefault(t => t.Key != team).Key;
            }

            label.Content = team;
        }

        private void SetTeam(PlayoffCouple previousGame, Label label)
        {
            label.Content = Name == "ForThirdPlace" ? previousGame.GetLostTeam() : previousGame.GetWonTeam();
        }

        private string GetWonTeam()
        {
            int goals1;
            bool result1 = int.TryParse(FirstTeamGoalsTextBox.Text, out goals1);

            int goals2;
            bool result2 = int.TryParse(SecondTeamGoalsTextBox.Text, out goals2);

            string wonTeam = "";
            if (result1 && result2)
            {
                wonTeam = Convert.ToString(goals1 > goals2 ? FirstTeamLabel.Content : SecondTeamLabel.Content);
            }
            return wonTeam;
        }

        private string GetLostTeam()
        {
            int goals1;
            bool result1 = int.TryParse(FirstTeamGoalsTextBox.Text, out goals1);

            int goals2;
            bool result2 = int.TryParse(SecondTeamGoalsTextBox.Text, out goals2);

            string wonTeam = "";
            if (result1 && result2)
            {
                wonTeam = Convert.ToString(goals1 < goals2 ? FirstTeamLabel.Content : SecondTeamLabel.Content);
            }
            return wonTeam;
        }
    }
}
