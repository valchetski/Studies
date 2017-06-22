using System;
using System.Linq;
using System.Windows.Forms;
using Extensions;

namespace DijkstrasAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*var graph = new[,]
            {
                { "0", "5", "*", "*", "*", "*", "*", "3", "*", "*" },
                { "*", "0", "2", "*", "*", "*", "3", "*", "*", "*" },
                { "*", "*", "0", "*", "5", "*", "*", "*", "*", "*" },
                { "*", "*", "2", "0", "*", "*", "*", "*", "*", "*" },
                { "*", "*", "*", "1", "0", "*", "*", "*", "*", "2" },
                { "*", "*", "4", "*", "1", "0", "*", "6", "2", "*" },
                { "2", "*", "2", "*", "*", "5", "0", "*", "*", "*" },
                { "*", "1", "*", "*", "*", "*", "4", "0", "1", "*" },
                { "*", "*", "*", "*", "*", "*", "*", "*", "0", "5" },
                { "*", "*", "*", "6", "*", "3", "*", "*", "*", "0" }
            };*/

            var graph = new[,]
            {
                { "0", "6", "2", "*", "*", "*", "2", "*", "*"},
                { "*", "0", "5", "*", "*", "6", "*", "*", "*" },
                { "*", "*", "0", "*", "*", "1", "*", "*", "*" },
                { "*", "*", "2", "0", "3", "*", "*", "*", "*" },
                { "*", "*", "*", "*", "0", "*", "*", "4", "*" },
                { "4", "*", "*", "*", "6", "0", "3", "7", "*" },
                { "*", "*", "*", "*", "*", "*", "0", "4", "*" },
                { "*", "1", "*", "*", "*", "*", "*", "0", "1" },
                { "*", "*", "*", "1", "5", "2", "*", "*", "0" }
            };

            UiHelper.FillDataGridView(GraphdataGridView, graph);
            VerticiesCountTextBox.Text = graph.GetLength(0).ToString();
            startVertexTextBox.Text = Convert.ToString(1);
            finishVertexTextBox.Text = Convert.ToString(1);
        }

        private void Solvebutton_Click(object sender, EventArgs e)
        {
            var distances = UiHelper.GetMatrix<int>(GraphdataGridView);
            var n = Convert.ToInt32(VerticiesCountTextBox.Text);
            var startVertex = Convert.ToInt32(startVertexTextBox.Text);
            var finishVertex = Convert.ToInt32(finishVertexTextBox.Text);

            var dijkstra = new DijkstraAlgorithm(n, distances);
            var shortestDistances = dijkstra.GetShortestDistances(startVertex - 1);
            var shortestWay = dijkstra.GetShortestWay(finishVertex - 1).ToArray();

            string detailedSolution = $"Shortest distances FROM vertex {startVertex}:\n";
            for (var i = 0; i < shortestDistances.Length; i++)
            {
                detailedSolution += $"TO vertex {i + 1} = ";
                detailedSolution += shortestDistances[i] == int.MaxValue ? "*" : shortestDistances[i].ToString();
                detailedSolution += "\n";
            }

            detailedSolution += $"Shortest way FROM {startVertex} TO {finishVertex}: ";

            if (shortestDistances[finishVertex - 1] == int.MaxValue)
            {
                detailedSolution += "Way doesn't exist.";
            }
            else
            {
                for (var i = shortestWay.Length - 1; i >= 0; i--)
                {
                    detailedSolution += $" {shortestWay[i] + 1} ";
                }
                detailedSolution += $"\nDistance = {shortestDistances[finishVertex - 1]}";
            }
            DetailedSolutionrichTextBox.Text = detailedSolution;
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

        private void startVertexTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int startVertex;
            if (int.TryParse(text, out startVertex))
            {
                
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ((TextBox)sender).Text = Convert.ToString(1);
            }
        }

        private void finishVertexTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int finishVertex;
            if (int.TryParse(text, out finishVertex))
            {

            }
            else if (!string.IsNullOrEmpty(text))
            {
                ((TextBox)sender).Text = Convert.ToString(1);
            }
        }
    }
}
