using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int matrixSize = 3;
            for (int i = 0; i < matrixSize; i++)
            {
                MatrixCdataGridView.Columns.Add("", "");
            }
            MatrixCdataGridView.Rows.Add(matrixSize);

            MatrixCdataGridView[0, 0].Value = 0;
            MatrixCdataGridView[0, 1].Value = 0;
            MatrixCdataGridView[0, 2].Value = 1;
            MatrixCdataGridView[1, 0].Value = 2;
            MatrixCdataGridView[1, 1].Value = 1;
            MatrixCdataGridView[1, 2].Value = 1;
            MatrixCdataGridView[2, 0].Value = 1;
            MatrixCdataGridView[2, 1].Value = 1;
            MatrixCdataGridView[2, 2].Value = 1;
        }

        private void matrixSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            int matrixSize;
            Random random = new Random();
            MatrixCdataGridView.Rows.Clear();
            MatrixCdataGridView.Columns.Clear();
            if (int.TryParse(matrixSizeTextBox.Text, out matrixSize))
            {
                for (int i = 0; i < matrixSize; i++)
                {
                    MatrixCdataGridView.Columns.Add("", "");
                }                    
                MatrixCdataGridView.Rows.Add(matrixSize);

                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {                        
                        MatrixCdataGridView[j, i].Value = random.Next(10);
                    }
                }
            }
        }

        private void SolveButton_Click(object sender, EventArgs e)
        {
            int matrixSize = MatrixCdataGridView.ColumnCount;
            double[,] matrix = new double[matrixSize, matrixSize];
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = Convert.ToDouble(MatrixCdataGridView[j, i].Value);
                }
            }

            var solveMatrix = new SolveMatrix();
            matrix = solveMatrix.Solve(matrix);

            if(matrix == null)
            {
                MessageBox.Show("Определитель матрицы С равен нулю. Для матрицы С не существует обратной");
                return;
            }

            inverseMatrixCdataGridView.Rows.Clear();
            inverseMatrixCdataGridView.Columns.Clear();
            for (int i = 0; i < matrixSize; i++)
            {
                inverseMatrixCdataGridView.Columns.Add("", "");
            }
            inverseMatrixCdataGridView.Rows.Add(matrixSize);

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    inverseMatrixCdataGridView[j, i].Value = matrix[i, j];
                }
            }

            resultTextBox.Text = solveMatrix.Report;
        }
    }
}
