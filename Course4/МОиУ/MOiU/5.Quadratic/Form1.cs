using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormMethods;
using MathNet.Numerics.LinearAlgebra.Double;

namespace _5.Quadratic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var a = new double[,]{
                              {0, 1, 1, 1, -2, 1},
                              {1, 0, 1, 1, 1, -2},
                              {1, 1, 1, 0, -1, 1}};

            var c = new double[] { 0, 0, 0, 0, 0, 0 };

            var xBase = new double[] { 1, 2, 2, 0, 0, 0 };

            /*var jBasis = new List<int>(new[] { 0, 1, 2 });
            var jStar = new List<int>(new[] { 0, 1, 2 });*/

            var d = new double[,]{
                              {1, 0, 0, 0, 0, 0},
                              {0, 1, 0, 0, 0, 0},
                              {0, 0, 1, 0, 0, 0},
                              {0, 0, 0, 1, 2, 1},
                              {0, 0, 0, 2, 4, 2},
                              {0, 0, 0, 1, 2, 1}};

            Helper.FillDataGridView(matrixAdataGridView, a);
            Helper.FillDataGridView(vectorCdataGridView, c);
            Helper.FillDataGridView(vectorXdataGridView, xBase);
            Helper.FillDataGridView(matrixDdataGridView, d);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var a = Helper.GetMatrix<double>(matrixAdataGridView);
            var c = Helper.GetVector<double>(vectorCdataGridView);
            var xBase = Helper.GetVector<double>(vectorXdataGridView);

            List<int> jBasis = new List<int>();
            List<int> jStar = new List<int>();
            for (int i = 0; i < xBase.Length; i++)
            {
                if (xBase[i] != 0)
                {
                    jBasis.Add(i);
                    jStar.Add(i);
                }

            }

            var d = Helper.GetMatrix<double>(matrixDdataGridView);

            var sm = new QuadraticSolve(a, c, d, xBase, jBasis, jStar);
            DenseVector ans;
            string report;
            var isSolved = sm.Solve(out ans, out report);
            report += string.Format("\n\nРешение: {0}\nЦелевая функция: {1}", isSolved, CalculateTargetFunc(ans, c, DenseMatrix.OfArray(d)));

            Helper.FillDataGridView(resultDataGridView, ans.ToArray());
            resultRichTextBox.Text = report;
        }

        static double CalculateTargetFunc(DenseVector x, DenseVector c, DenseMatrix d)
        {
            return c * x + x * d * x * 0.5;
        }
    }
}
