using System;
using System.Windows.Forms;
using Extensions;

namespace TravellingSalesmanProblem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*var cost = new[,]
            {
                {2, 999, 3, 4, 5},
                {-5, 8, -1, 0, 0},
                {2, 8, 2, 1, 3},
                {2, 8, 4, 3, 1},
                {1, 999, 1, 2, 1}
            };*/

            var cost = new[,]
            {
                { 0, 10, 25, 25, 10 },
                { 1, 0, 10, 15, 2 },
                { 8, 9, 0, 20, 10 },
                { 14, 10, 24, 0, 15 },
                { 10, 8, 25, 27, 0 }
            };

            UiHelper.FillDataGridView(CostdataGridView, cost);
            NTextBox.Text = cost.GetLength(0).ToString();
        }

        private void Solvebutton_Click(object sender, EventArgs e)
        {
            var cost = UiHelper.GetMatrix<int>(CostdataGridView);
            var n = Convert.ToInt32(NTextBox.Text);

            var problem = new TravellingSalesmanProblem
            {
                N = n,
                C = cost
            };

            var result = problem.SolveProblemByBranching();
            DetailedSolutionrichTextBox.Text = problem.DetailedSolutionTravellingSalesman;
            DetailedSolutionrichTextBox.Text += problem.ToStringCycle(result);
        }

        private void NTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int nCount;
            if (int.TryParse(text, out nCount))
            {
                UiHelper.ChangeRowCount<int>(CostdataGridView, nCount);
                UiHelper.ChangeColumnCount<int>(CostdataGridView, nCount);
            }
            else if (!string.IsNullOrEmpty(text))
            {
                ((TextBox)sender).Text = UiHelper.GetMatrix<int>(CostdataGridView).GetLength(0).ToString();
            }
        }
    }
}
