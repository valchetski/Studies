using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tester;
using Generators;
using ZedGraph;

namespace WinFormInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // исследовать метод среднего квадарата
        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            long number;
            if(Int32.TryParse(textBox1.Text, out n) && long.TryParse(textBox2.Text, out number))
            {
                var rand = NeumanGenerator.Generate(n, number);
                var list = UniformityTetser.Test(rand, 5);
                label8.Text = UniformityTetser.GetExpectation(rand).ToString();
                label10.Text = UniformityTetser.GetVariance(rand).ToString();
                zedGraphControl1.GraphPane.CurveList.Clear();
                zedGraphControl1.GraphPane.AddBar("Метод среднего квадрата", null, list, Color.Fuchsia);
                zedGraphControl1.GraphPane.XAxis.Type = AxisType.Text;
                zedGraphControl1.GraphPane.XAxis.Scale.TextLabels = new[] { "[0, 0.2]", "(0.2, 0.4]", "(0.4, 0.6]", "(0.6, 0.8]", "(0.8, 1]" };
                zedGraphControl1.AxisChange();
                zedGraphControl1.Refresh();
            }
            else
            {
                MessageBox.Show("Некорректные значения!");
            }
        }

        // исследовать мультипликативный конгруэнтный способ
        private void button2_Click(object sender, EventArgs e)
        {
            int n, k, m, number;
            if (Int32.TryParse(textBox4.Text, out n) && Int32.TryParse(textBox3.Text, out number) 
                && Int32.TryParse(textBox6.Text, out k) && Int32.TryParse(textBox5.Text, out m))
            {
                var rand = CongruentGenerator.Generate(n, number, k, m);
                var list = UniformityTetser.Test(rand, 5);
                label12.Text = UniformityTetser.GetExpectation(rand).ToString();
                label14.Text = UniformityTetser.GetVariance(rand).ToString();
                zedGraphControl2.GraphPane.CurveList.Clear();
                zedGraphControl2.GraphPane.AddBar("Мультипликативный конгруэнтный способ", null, list, Color.Red);
                zedGraphControl2.GraphPane.XAxis.Type = AxisType.Text;
                zedGraphControl2.GraphPane.XAxis.Scale.TextLabels = new[] { "[0, 0.2]", "(0.2, 0.4]", "(0.4, 0.6]", "(0.6, 0.8]", "(0.8, 1]" };
                zedGraphControl2.AxisChange();
                zedGraphControl2.Refresh();
            }
            else
            {
                MessageBox.Show("Некорректные значения!");
            }
        }
    }
}
