using System;
using System.Windows.Forms;
using Extensions;

namespace MaximalLengthWay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*var graph = new[,]
            {
                { "0", "5", "6", "4", "1", "*", "*", "*" },
                { "*", "0", "4", "3", "2", "*", "*", "*" },
                { "*", "*", "0", "*", "5", "*", "3", "*" },
                { "*", "*", "*", "0", "*", "4", "7", "3" },
                { "*", "*", "*", "*", "0", "*", "*", "4" },
                { "*", "*", "*", "*", "*", "0", "2", "5" },
                { "*", "*", "*", "*", "2", "*", "0", "1" },
                { "*", "*", "*", "*", "*", "*", "*", "0" }
            };*/

            /*var graph = new[,]
            {
                { "0", "3", "4", "5", "3", "*", "*" },
                { "*", "0", "*", "2", "*", "*", "*" },
                { "*", "1", "0", "6", "*", "3", "*" },
                { "*", "*", "*", "0", "4", "1", "4" },
                { "*", "*", "*", "*", "0", "2", "5" },
                { "*", "*", "*", "*", "*", "0", "1" },
                { "*", "*", "*", "*", "*", "*", "0" }
            };*/

            /*var graph = new[,]
            {
                { "0", "4", "1", "3", "*", "2", "7", "*" },
                { "*", "0", "1", "5", "*", "*", "*", "*" },
                { "*", "*", "0", "4", "6", "5", "*", "*" },
                { "*", "*", "*", "0", "2", "*", "*", "*" },
                { "*", "*", "*", "*", "0", "*", "3", "1" },
                { "*", "*", "*", "4", "*", "0", "2", "7" },
                { "*", "*", "*", "*", "*", "*", "0", "6" },
                { "*", "*", "*", "*", "*", "*", "*", "0" }
            };*/

            var graph = new[,]
            {
                { "0", "1", "*", "1" },
                { "*", "0", "3", "1" },
                { "*", "*", "0", "*" },
                { "*", "*", "1", "0" }
            };

            UiHelper.FillDataGridView(GraphdataGridView, graph);
            VerticiesCountTextBox.Text = graph.GetLength(0).ToString();
        }

        private void Solvebutton_Click(object sender, EventArgs e)
        {
            var distances = UiHelper.GetMatrix<int>(GraphdataGridView);
            var n = Convert.ToInt32(VerticiesCountTextBox.Text);

            var algorithm = new MaximalLengthTask(n, distances);
            int maxDistance = algorithm.Solve();

            DetailedSolutionrichTextBox.Text = algorithm.DetailedSolution;

        }

        private void VerticiesCountTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int verticiesCount;
            if (int.TryParse(text, out verticiesCount))
            {
                UiHelper.ChangeRowCount<int>(GraphdataGridView, verticiesCount);
                UiHelper.ChangeColumnCount<int>(GraphdataGridView, verticiesCount);
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ((TextBox)sender).Text = UiHelper.GetMatrix<int>(GraphdataGridView).GetLength(0).ToString();
            }
        }
    }
}
