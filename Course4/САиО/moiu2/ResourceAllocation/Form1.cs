using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extensions;


namespace ResourceAllocation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            /* var N = 3;
             var C = 6;        
             var F = new int[,]
             {
                 { 0, 3, 4, 5, 8, 9, 10 },
                 { 0, 2, 3, 7, 9, 12, 13 },
                 { 0, 1, 2, 6, 11, 11, 13 }
             };*/

            /* var N = 3;
             var C = 6;
             var F = new int[,]
             {
                 { 0, 1, 2, 2, 4, 5, 6  },
                 { 0, 2, 3, 5, 7, 7, 8 },
                 { 0, 2, 4, 5, 6, 7, 7 }
             };*/

            /*var N = 3;
            var C = 6;
            var F = new int[,]
            {
                { 0, 1, 1, 3, 6, 10, 11  },
                { 0, 2, 3, 5, 6, 7, 13 },
                { 0, 1, 4, 4, 7, 8, 9 }
            };*/

            var N = 4;
            var C = 11;
            var F = new int[,]
            {
                { 0, 1, 3, 4, 5, 8, 9, 9, 11, 12, 12, 14  },
                { 0, 1, 2, 3, 3, 3, 7, 12, 13, 14, 17, 19 },
                { 0, 4, 4, 7, 7, 8, 12, 14, 14, 16, 18, 22 },
                { 0, 5, 5, 5, 7, 9, 13, 13, 15, 15, 19, 24 }
            };

           /* var N = 6;
            var C = 10;
            var F = new int[,]
            {
                { 0, 1, 2, 2, 2, 3, 5, 8, 9, 13, 14  },
                { 0, 1, 3, 4, 5, 5, 7, 7, 10, 12, 12 },
                { 0, 2, 2, 3, 4, 6, 6, 8, 9, 11, 17 },
                { 0, 1, 1, 1, 2, 3, 9, 9, 11, 12, 15 },
                { 0, 2, 7, 7, 7, 9, 9, 10, 11, 12, 13 },
                { 0, 2, 5, 5, 5, 6, 6, 7, 12, 18, 22 }
            };*/

            UiHelper.FillDataGridView(InitialDataGridView, F);

            InitialDataGridView.RowHeadersDefaultCellStyle.Font = new Font(InitialDataGridView.Font, FontStyle.Bold);
            InitialDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(InitialDataGridView.Font, FontStyle.Bold);

            CapacityTextBox.Text = C.ToString();
            ProcessesTextBox.Text = N.ToString();

            InitialDataGridView.TopLeftHeaderCell.Value = "x";
            foreach (DataGridViewColumn column in InitialDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            var F = UiHelper.GetMatrix<int>(InitialDataGridView);
            var N = Convert.ToInt32(ProcessesTextBox.Text);
            var C = Convert.ToInt32(CapacityTextBox.Text);


            var task = new ResourceTask
            {
                N = N,
                C = C,
                F = F
            };
            DetailedSolutionrichTextBox.Text = task.SolveBellman().ToString();
        }

        private void ProcessesTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int rowCount;
            if (int.TryParse(text, out rowCount))
            {
                UiHelper.ChangeRowCount<int>(InitialDataGridView, rowCount);

                for (var i = 0; i < rowCount; i++)
                {
                    InitialDataGridView.Rows[i].HeaderCell.Value = $"f{i}(x)";
                }               
            }
        }

        private void CapacityTextBox_TextChanged(object sender, EventArgs e)
        {
            var text = (sender as TextBox)?.Text;
            int columnCount;
            if (int.TryParse(text, out columnCount))
            {
                UiHelper.ChangeColumnCount<int>(InitialDataGridView, columnCount + 1);
                for (var i = 0; i < columnCount + 1; i++)
                {
                    InitialDataGridView.Columns[i].HeaderCell.Value = $"{i}";
                }
            }
        }
    }
}
