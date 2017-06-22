using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Extensions;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CuttingPlaneMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /* var a = new double[,]
             {
                 { 5, -1, 1, 0, 0 },
                 { -1, 2, 0, 1, 0 },
                 { -7, 2, 0, 0, 1 }
             };
             var b = new double[] { 15, 6, 0 };
             var c = new double[] { -3.5, 1, 0, 0, 0 };
             //var baseIndexes = new[] { 0, 0, 0 };
             var dMin = new double[] { 0.0, 0, 0, 0, 0 };
             var dMax = new double[] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };*/


            /*var a = new double[,]
            {
                {1, -5, 3, 1, 0, 0},
                {4, -1, 1, 0, 1, 0},
                {2, 4, 2, 0, 0, 1}
            };
            var b = new double[] { -8, 22, 30 };
            var c = new double[] { 7, -2, 6, 0, 5, 2 };
            var dMin = new double[] { 0, 0, 0, 0, 0, 0 };
            var dMax = new double[] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };*/

            //var a = new double[,]
            //{
            //    { 5, 3, 1, 0, 0 },
            //    { -1, 2, 0, 1, 0 },
            //    {1, -2, 0, 0, 1 }
            //};
            //var b = new double[] { 4, 3, 7 };
            //var c = new double[] { 1, -1, 0, 0, 0 };
            ////var baseIndexes = new[] { 0, 1 };
            //var dMin = new double[] { 0, 0, 0, 0, 0 };
            //var dMax = new double[] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };

            var a = new double[,]
           {
               {2, 1, -1, -3, 4, 7},
               {0, 1, 1, 1, 2, 4},
               {6, -3, -2, 1, 1, 1}
           };
           var b = new double[] { 7, 16, 6 };
           var c = new double[] { 1, 2, 1, -1, 2, 3 };
           var dMin = new double[] { 0, 0, 0, 0, 0, 0 };
           var dMax = new double[] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };

            RowstextBox.Text = a.GetLength(0).ToString();
            ColumnstextBox.Text = a.GetLength(1).ToString();

            UiHelper.FillDataGridView(MatrixAdataGridView, a);
            UiHelper.FillDataGridView(VectorBdataGridView, b);
            UiHelper.FillDataGridView(VectorCdataGridView, c);
            //UiHelper.FillDataGridView(BaseIndexesdataGridView, baseIndexes);
            UiHelper.FillDataGridView(dminVectordataGridView, dMin);
            UiHelper.FillDataGridView(dmaxVectordataGridView, dMax);
        }

        private void Solvebutton_Click(object sender, EventArgs e)
        {
            var a = UiHelper.GetMatrix<double>(MatrixAdataGridView);
            var b = UiHelper.GetVector<double>(VectorBdataGridView);
            var c = UiHelper.GetVector<double>(VectorCdataGridView);
            var baseIndexes = new List<int>(b.Length);
            var dMin = UiHelper.GetVector<double>(dminVectordataGridView);
            var dMax = UiHelper.GetVector<double>(dmaxVectordataGridView);

            var sm = new Gomory(a, b, c, baseIndexes, dMin, dMax);

            var result = sm.SolveByGomory();

            if (result != null)
            {
                for (var i = 0; i < result.Count; i++)
                {
                    result[i] = Math.Round(result[i]);
                }
                UiHelper.FillDataGridView(XdataGridView, result.ToArray());
                sm.DetailedSolutionGomory += $"Target function: {DenseVector.OfEnumerable(c) * result}";
                DetailedSolutionrichTextBox.Text = sm.DetailedSolutionGomory;
            }
            else
            {
                DetailedSolutionrichTextBox.Text = sm.DetailedSolutionGomory;
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
                //UiHelper.ChangeRowCount<int>(BaseIndexesdataGridView, rowCount);
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
