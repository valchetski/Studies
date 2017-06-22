using System;
using System.Linq;
using System.Windows.Forms;
using Extensions;
using MathNet.Numerics.LinearAlgebra.Double;

namespace BranchandBound
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var a = new double[,]
            {
                { 1, -5, 3, 1, 0, 0 },
                { 4, -1, 1, 0, 1, 0 },
                { 2, 4, 2, 0, 0, 1 }
            };
            var b = new double[] { -8, 22, 30 };
            var c = new double[] { 7, -2, 6, 0, 5, 2 };
            var baseIndexes = new[] { 3, 4, 5 };
            var dMin = new double[] { 2, 1, 0, 0, 1, 1 };
            var dMax = new double[] { 6, 6, 5, 2, 4, 6 };

            /* var a = new double[,]
             {
                 { -2, 1, 1, 0 },
                 { 1, -3, 0, 1 }
             };
             var b = new double[] { -4, -3 };
             var c = new double[] { -4, 0, 1, 0 };
             var baseIndexes = new[] { 0, 1 };
             var dMin = new double[] { 0, 0, 0, 0 };
             var dMax = new double[] { 4, 5, 6, 7 };*/

            RowstextBox.Text = a.GetLength(0).ToString();
            ColumnstextBox.Text = a.GetLength(1).ToString();

            UiHelper.FillDataGridView(MatrixAdataGridView, a);
            UiHelper.FillDataGridView(VectorBdataGridView, b);
            UiHelper.FillDataGridView(VectorCdataGridView, c);
            UiHelper.FillDataGridView(BaseIndexesdataGridView, baseIndexes);
            UiHelper.FillDataGridView(dminVectordataGridView, dMin);
            UiHelper.FillDataGridView(dmaxVectordataGridView, dMax);
        }

        private void Solvebutton_Click(object sender, EventArgs e)
        {
            var a = UiHelper.GetMatrix<double>(MatrixAdataGridView);
            var b = UiHelper.GetVector<double>(VectorBdataGridView);
            var c = UiHelper.GetVector<double>(VectorCdataGridView);
            var baseIndexes = UiHelper.GetVector<int>(BaseIndexesdataGridView).ToList();
            var dMin = UiHelper.GetVector<double>(dminVectordataGridView);
            var dMax = UiHelper.GetVector<double>(dmaxVectordataGridView);

            var sm = new BranchandBound(a, b, c, baseIndexes, dMin, dMax);

            var result = sm.SolveByBranching();
            if (result != null)
            {
                UiHelper.FillDataGridView(XdataGridView, result.ToArray());
                sm.DetailedSolutionBB += $"Target function: {DenseVector.OfArray(c) * result}";
                DetailedSolutionrichTextBox.Text = sm.DetailedSolutionBB;
            }
            else
            {
                DetailedSolutionrichTextBox.Text = sm.DetailedSolutionBB;
                MessageBox.Show(@"Solution doesn't exists");
            }
        }

        private void RowstextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int rowCount;
            if (int.TryParse(text, out rowCount))
            {
                UiHelper.ChangeRowCount<int>(MatrixAdataGridView, rowCount);
                UiHelper.ChangeRowCount<int>(VectorBdataGridView, rowCount);
                UiHelper.ChangeRowCount<int>(BaseIndexesdataGridView, rowCount);
            }
        }

        private void ColumnstextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int columnCount;
            if (int.TryParse(text, out columnCount))
            {
                UiHelper.ChangeColumnCount<int>(MatrixAdataGridView, columnCount);
                UiHelper.ChangeRowCount<int>(VectorCdataGridView, columnCount);
                UiHelper.ChangeRowCount<int>(dminVectordataGridView, columnCount);
                UiHelper.ChangeRowCount<int>(dmaxVectordataGridView, columnCount);
            }
        }
    }
}
