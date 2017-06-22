using System;
using System.Windows.Forms;
using Extensions;

namespace AssignmentProblem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var cost = new[,]
            {
                {2, 10, 9, 7},
                {15, 4, 14, 8},
                {13, 14, 16, 11},
                {4, 15, 13, 19}
            };

            /*var cost = new[,]
            {
                { 9, 6, 4, 9, 3, 8, 0 },
                { 5, 8, 6, 8, 8, 3, 5 },
                { 5, 2, 1, 1, 8, 6, 8 },
                { 1, 0, 9, 2, 5, 9, 2 },
                { 9, 2, 3, 3, 0, 3, 0 },
                { 7, 3, 0, 9, 4, 5, 6 },
                { 0, 9, 6, 0, 8, 8, 9 }
            };*/

            UiHelper.FillDataGridView(CostdataGridView, cost);
            NTextBox.Text = cost.GetLength(0).ToString();
        }

        private void Solvebutton_Click(object sender, EventArgs e)
        {
            var cost = UiHelper.GetMatrix<int>(CostdataGridView);
            var n = Convert.ToInt32(NTextBox.Text);

            var problem = new AssignmentProblems
            {
                C = cost,
                N = n
            };
            var result = problem.Solve();

            problem.DetailedSolutionAssignment += "\nResult:\nMatrix C:\n";
            for (var i = 0; i < problem.N; i++) {
                for (var j = 0; j < problem.N; j++)
                {
                    problem.DetailedSolutionAssignment += $"{problem.C[i, j]} ";
                }
                problem.DetailedSolutionAssignment += "\n";
            }
            
			var c = 0;
			for (var i = 0; i < problem.N; i++)
            {
                problem.DetailedSolutionAssignment += $"{i + 1} -> {result[i] + 1}\n";
				c += problem.C[i, result[i]];
			}

            problem.DetailedSolutionAssignment += c;
            DetailedSolutionrichTextBox.Text = problem.DetailedSolutionAssignment;
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
