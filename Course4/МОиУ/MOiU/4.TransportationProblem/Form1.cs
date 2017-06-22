using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormMethods;

namespace _4.TransportationProblem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /*var a = new double[] { 200, 180, 190 };
            var b = new double[] { 150, 130, 150, 140 };
            var c = new double[,]
            {
                {7, 8, 1, 2},
                {4, 5, 9, 8},
                {9, 2, 3, 6 },
               
            };*/

            var a = new double[] { 60, 40, 70, 30 };
            var b = new double[] { 60, 40, 40, 30, 30 };
            var c = new double[,]
            {
                { 5, 2, 0, 7, 3},
                { 6, 1, 4, 2, 8 },
                {7, 4, 3, 6, 1 },
                { 3, 5, 6, 4, 2 }
            };

            /*var a = new double[] { 70, 50, 20, 30 };
            var b = new double[] { 50, 40, 10, 15, 25, 30 };
            var c = new double[,]
            {
                {6, 3, 1, 5, 7, 4},
                {8, 4, 2, 4, 3, 6},
                {3, 5, 5, 6, 2, 4},
                {5, 1, 1, 3, 6, 2}
            };*/

            /*var a = new double[] { 20, 40, 30 };
            var b = new double[] { 30, 40, 20 };
            var c = new double[,]
            {
                {4, 5, 3},
                {2, 7, 1},
                {3, 2, 4}
            };*/

            Helper.FillDataGridView(cDataGridView, c);
            Helper.FillDataGridView(aDataGridView, a);
            Helper.FillDataGridView(bDataGridView,b);

            cDataGridView.RowHeadersDefaultCellStyle.Font = new Font(cDataGridView.Font, FontStyle.Bold);
            cDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(cDataGridView.Font, FontStyle.Bold);

            aTextBox.Text = a.Length.ToString();
            bTextBox.Text = b.Length.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = Helper.GetVector<double>(aDataGridView).ToList();
            var b = Helper.GetVector<double>(bDataGridView).ToList();
            var c = Helper.GetMatrix<double>(cDataGridView);
            var trProblem = new TransportationProblem(a, b, c);

            Dictionary<Tuple<int, int>, double> sol;
            var flag = trProblem.Solve(out sol);

            string report = trProblem.Report;

            report += string.Format("Решение: {0}", flag);
            double targetFunc = 0;
            var resPath = "";
            foreach (var d in sol)
            {
                targetFunc = targetFunc + c[d.Key.Item1, d.Key.Item2] * d.Value;
                resPath += $"({d.Key.Item1}; {d.Key.Item2}); \n";
            }
            report += string.Format("\nСтоимость перевозок: {0}\n", targetFunc);

            reportRichTextBox.Text = report;
            planRichTextBox.Text = resPath;
        }

        private void aTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            int rowCount;
            if (int.TryParse(text, out rowCount))
            {
                Helper.ChangeRowCount<int>(cDataGridView, rowCount);
                Helper.ChangeRowCount<int>(aDataGridView, rowCount);
            }
        }

        private void bTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = (sender as TextBox).Text;
            int rowCount;
            if (int.TryParse(text, out rowCount))
            {
                Helper.ChangeColumnCount<int>(cDataGridView, rowCount);
                Helper.ChangeRowCount<int>(bDataGridView, rowCount);
            }
        }

        private void aDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            object value = (sender as DataGridView)[e.ColumnIndex, e.RowIndex].Value;
            cDataGridView.Rows[index].HeaderCell.Value = string.Format("a{0} = {1}", index, value);
        }

        private void bDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            object value = (sender as DataGridView)[e.ColumnIndex, e.RowIndex].Value;
            cDataGridView.Columns[index].HeaderCell.Value = string.Format("b{0} = {1}", index, value);
        }
    }
}
