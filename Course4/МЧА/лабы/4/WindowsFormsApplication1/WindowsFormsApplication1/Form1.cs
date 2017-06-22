using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Core core;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            core = new Core();
            core.Do();
            chart1.Series.Clear();
            foreach (var t in core.T.Keys)
            {
                var ser = new Series();
                for (int i = 0; i < core.T[t].Count; i++)
                {
                    ser.Points.Add(new DataPoint(core.X[i], core.T[t][i]));
                }
                chart1.Series.Add(ser);
                ser.ChartType = SeriesChartType.Line;
            }
            //var ser = new Series();
            //var ser1 = new Series();
            //for (int i = 0; i < core.X.Count; i++)
            //{
            //    ser.Points.Add(new DataPoint(core.X[i], core.T.Last().Value[i]));
            //    ser1.Points.Add(new DataPoint(core.X[i], Math.Sin(core.X[i] - core.T.Last().Key)));
            //}
            //chart1.Series.Add(ser);
            //chart1.Series.Add(ser1);
            //ser.ChartType = SeriesChartType.Line;
            //ser1.ChartType = SeriesChartType.Line;

            chart1.Legends.Clear();

        }

        public void Start(object obj)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
