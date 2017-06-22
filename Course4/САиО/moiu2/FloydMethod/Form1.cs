using System;
using System.Linq;
using System.Windows.Forms;
using Extensions;

namespace FloydMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var d = new[,]
            {
                { "0", "9", "*", "3", "*", "*", "*", "*" },
                { "9", "0", "2", "*", "7", "*", "*", "*" },
                { "*", "2", "0", "2", "4", "8", "6", "*" },
                { "3", "*", "2", "0", "*", "*", "5", "*" },
                { "*", "7", "4", "*", "0", "10", "*", "*" },
                { "*", "*", "8", "*", "10", "0", "7", "*" },
                { "*", "*", "6", "5", "*", "7", "0", "*" },
                { "*", "*", "*", "*", "9", "12", "10", "0" }
            };

            UiHelper.FillDataGridView(DdataGridView, d);
            NTextBox.Text = d.GetLength(0).ToString();
            startVertexTextBox.Text = Convert.ToString(1);
            finishVertexTextBox.Text = Convert.ToString(d.GetLength(0).ToString());
        }

        private void Solvebutton_Click(object sender, EventArgs e)
        {
            var d = UiHelper.GetMatrix<int>(DdataGridView);
            var n = Convert.ToInt32(NTextBox.Text);
            var startVertex = Convert.ToInt32(startVertexTextBox.Text);
            var finishVertex = Convert.ToInt32(finishVertexTextBox.Text);

            var algorithm = new FloydAlgorithm(n, d);
            algorithm.Solve();

            DetailedSolutionrichTextBox.Text = $"Dn:\n {ToString(algorithm.ReturnShortestDistances())} \n Rn:\n {ToString(algorithm.ReturnWay())}";
            var way = algorithm.BuildWay(startVertex - 1, finishVertex - 1);
            var buildedway = way.Aggregate("", (current, t) => current + (t + " "));
            DetailedSolutionrichTextBox.Text += $"Way: {buildedway}";
        }

        private void NTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int nCount;
            if (int.TryParse(text, out nCount))
            {
                UiHelper.ChangeRowCount<int>(DdataGridView, nCount);
                UiHelper.ChangeColumnCount<int>(DdataGridView, nCount);
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ((TextBox)sender).Text = UiHelper.GetMatrix<int>(DdataGridView).GetLength(0).ToString();
            }
        }

        public static string ToString(int[,] matrix)
        {
            var result = "";
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    result += matrix[i, j] == int.MaxValue ? "*" : matrix[i, j] + " ";
                }
                result += "\n";
            }
            return result;
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
                ((TextBox)sender).Text = UiHelper.GetMatrix<int>(DdataGridView).GetLength(0).ToString();
            }
        }
    }
}
