using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FormMethods;

namespace _2.SimplexMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var startingmatrix = new double[,]
            {
                {-1, 1, 1},
                {2, -1, 1},
                {3, 1, 1}
            };
            var conditions = new List<string> { ">=", "<=", ">=" };
            var b = new double[] { 4, 16, 18 };
            var c = new double[] { 2, -5, -3 };
            var xBase = new[] { 1.2, 0.6, 0.6, 0, 0, 0 };

            rowsTextBox.Text = startingmatrix.GetLength(0).ToString();
            columnsTextBox.Text = startingmatrix.GetLength(1).ToString();

            Helper.FillDataGridView(equationDataGridView, startingmatrix);
            FillDataGridView(conditionDataGridView, conditions);
            Helper.FillDataGridView(VectorBdataGridView, b);
            Helper.FillDataGridView(vectorCdataGridView, c);
            Helper.FillDataGridView(vectorXdataGridView, xBase);
        }

        private void MakeCanonicForm()
        {
            var matrixA = DenseMatrix.OfArray(Helper.GetMatrix<double>(equationDataGridView));

            var conditions = GetConditions(conditionDataGridView);

            for (var i = 0; i < conditions.GetLength(0); i++)
            {
                var col = new DenseVector(conditions.GetLength(0));
                switch (conditions[i])
                {
                    case ">=":
                        col[i] = -1;
                        break;
                    case "<=":
                        col[i] = 1;
                        break;
                    default:
                        continue;

                }
                matrixA = (DenseMatrix)matrixA.InsertColumn(matrixA.ColumnCount, col);
            }
            Helper.FillDataGridView(MatrixAdataGridView, matrixA.ToArray());

            var temp = DenseVector.OfArray(Helper.GetVector<double>(vectorCdataGridView));
            var c = new double[matrixA.ColumnCount];
            for (var i = 0; i < temp.Count; i++)
            {
                c[i] = temp[i];
            }
            Helper.FillDataGridView(vectorCdataGridView, c);
        }

        private static string[] GetConditions(DataGridView dataGridView)
        {
            var conditions = new string[dataGridView.RowCount];
            for (var i = 0; i < conditions.GetLength(0); i++)
            {
                conditions[i] = dataGridView[0, i].Value.ToString();
            }
            return conditions;
        }

        private void rowsTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            int rowCount;
            if (int.TryParse(text, out rowCount))
            {
                Helper.ChangeRowCount<int>(equationDataGridView, rowCount);
                Helper.ChangeRowCount<int>(VectorBdataGridView, rowCount);
                Helper.ChangeRowCount<string>(conditionDataGridView, rowCount);
                Helper.ChangeRowCount<int>(vectorXdataGridView, rowCount + equationDataGridView.ColumnCount);
            }
        }

        private void columnsTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            int colCount;
            if (int.TryParse(text, out colCount))
            {
                Helper.ChangeColumnCount<int>(equationDataGridView, colCount);
                Helper.ChangeRowCount<int>(vectorCdataGridView, colCount);
                Helper.ChangeRowCount<int>(vectorXdataGridView, colCount + equationDataGridView.ColumnCount);
            }
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            MakeCanonicForm();

            var a = Helper.GetMatrix<double>(MatrixAdataGridView);
            var c = Helper.GetVector<double>(vectorCdataGridView);
            var xBase = Helper.GetVector<double>(vectorXdataGridView);           

            List<int> baseIndexes = new List<int>();
            for (int i = 0; i < xBase.GetLength(0); i++)
            {
                if (xBase[i] != 0)
                {
                    baseIndexes.Add(i);
                }
            }
            var sm = new SimplexMethod(a, c, xBase, baseIndexes);
            double[] ans = null;
            try
            {
                ans = sm.Solve();                
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            } 
            if(ans != null)
            {
                Helper.FillDataGridView(resultDataGridView, ans);
                reportRichTextBox.Text = sm.Report;
            }   
            else
            {
                Helper.FillDataGridView(resultDataGridView, new double[resultDataGridView.RowCount, resultDataGridView.ColumnCount]);
                reportRichTextBox.Text = "Нет решения";
            }      
        }

        #region FillDataGridView
        

        

        private static void FillDataGridView(DataGridView dataGridView, List<string> conditions)
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            var rowsCount = conditions.Count;

            dataGridView.Columns.Add("", "");
            dataGridView.Rows.Add(rowsCount);

            for (var i = 0; i < rowsCount; i++)
            {
                dataGridView[0, i].Value = conditions[i];
            }
        }
        #endregion

        
    }
}
