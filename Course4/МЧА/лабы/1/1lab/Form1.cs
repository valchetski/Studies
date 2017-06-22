using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace _1lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = int.Parse(kTextBox.Text);
            int a = int.Parse(aTextBox.Text);
            int b = int.Parse(bTextBox.Text);

            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            GraphPane pane = zedGraphControl1.GraphPane;

            pane.XAxis.Scale.Max = b;
            pane.XAxis.Scale.Min = a;


            var solve = new Solve();
            var result = solve.MySolve(k, a, b);
            var list = new PointPairList();
            string x = "";
            string y = "";
            for (int i = 0; i < result.Item1.Length; i++)
            {
                list.Add(result.Item1[i], result.Item2[i]);
                x += string.Format("{0} : {1}\n", i, result.Item1[i]);
                y += string.Format("{0} : {1}\n", i, result.Item2[i]);
            }
            string label = "Y(" + k + ")";
            zedGraphControl1.GraphPane.AddCurve("Y(80)", list, Color.Blue, SymbolType.None);

            xRichTextBox.Text = x;
            yRichTextBox.Text = y;


            k = k - 60;
            var result1 = solve.MySolve(k, a, b);
            var list1 = new PointPairList();
            string x1 = "";
            string y1 = "";
            for (int i = 0; i < result1.Item1.Length; i++)
            {
                list1.Add(result1.Item1[i], result1.Item2[i]);
                x1 += string.Format("{0} : {1}\n", i, result1.Item1[i]);
                y1 += string.Format("{0} : {1}\n", i, result1.Item2[i]);
            }
            label = "Y(" + k + ")";
            zedGraphControl1.GraphPane.AddCurve(label, list1, Color.Red, SymbolType.Circle);

            richTextBox1.Text = x1;
            richTextBox2.Text = y1;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }

        private void JustSolve(int k)
        {

        }
    }
}
