using System;
using System.Linq;
using System.Windows.Forms;
using FormMethods;

namespace _3.DualSimplexMethod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var a = new double[,] { { 2, 5, -1, 0 }, { 4, 1, 0, -1 } };
            var b = new double[] { 20, 20 };
            var c = new double[] { -19, -21, 0, 0 };
            var jB = new[] { 0, 1 };
            /*var a = new double[,] { { 1, 1, 1,0,0 }, { 1, -1, 0, -1,0 }, { 1, 1, 0, 0, -1 } };
            var b = new double[] { 20, 20 };
            var c = new double[] { 1, 1, 0, 0 };
            var jB = new[] { 0, 1 };
             var a = new double[,] { { 2, 5, -1, 0 }, { 4, 1, 0, -1}};
              var b = new double[] { 20, 20 };
              var c = new double[] { -19, -21,0,0};
              var jB = new[] { 0, 1};

              var a = new double[,] {{1, -2, 0, 1, 0, 0}, {1, -2, -3, 0, 1, 0}, {0, 0, 2, 0, 0, 1}};
              var b = new double[] { 5, 4, 8 };
              var c = new double[] { -6, 1, -1, 0, 0, 0 };
              var jB = new[] { 0, 1, 2 };*/

            rowsTextBox.Text = a.GetLength(0).ToString();
            columnsTextBox.Text = a.GetLength(1).ToString();

            Helper.FillDataGridView(matrixAdataGridView, a);
            Helper.FillDataGridView(vectorBdataGridView, b);
            Helper.FillDataGridView(vectorCdataGridView, c);
            Helper.FillDataGridView(jBdataGridView, jB);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = Helper.GetMatrix<double>(matrixAdataGridView);
            var b = Helper.GetVector<double>(vectorBdataGridView);
            var c = Helper.GetVector<double>(vectorCdataGridView);
            var jB = Helper.GetVector<int>(jBdataGridView).ToList();


            var sm = new DualSimplexMethod(a, b, c, jB);

            var result = sm.Solve();
            if (result.Item1 != null)
            {
                Helper.FillDataGridView(xResultDataGridView, result.Item1);
                Helper.FillDataGridView(yResultDataGridView, result.Item2);
                reportRichTextBox.Text = sm.Report;
            }
            else
            {
                MessageBox.Show("Решений нет!");
            }

        }



        private void rowsTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            int rowCount;
            if (int.TryParse(text, out rowCount))
            {
                Helper.ChangeRowCount<int>(matrixAdataGridView, rowCount);
                Helper.ChangeRowCount<int>(vectorBdataGridView, rowCount);
                Helper.ChangeRowCount<int>(jBdataGridView, rowCount);
            }
        }

        private void columnsTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            int columnCount;
            if (int.TryParse(text, out columnCount))
            {
                Helper.ChangeColumnCount<int>(matrixAdataGridView, columnCount);
                Helper.ChangeRowCount<int>(vectorCdataGridView, columnCount);
            }
        }
    }
}
