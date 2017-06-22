using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Lab4.TableElements;
using ZedGraph;

namespace Lab4
{
    public partial class Form1 : Form
    {
        int n1;
        int n2;
        int n3;
        private const double mx = 3;
        private const double dx = 3;

        public Form1()
        {
            InitializeComponent();

            label1.Hide();
            label5.Hide();
            label6.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == String.Empty || !Int32.TryParse(textBox1.Text, out n1)
                || textBox6.Text == String.Empty || !Int32.TryParse(textBox6.Text, out n2)
                || textBox9.Text == String.Empty || !Int32.TryParse(textBox9.Text, out n3))
            {
                return;
            }

            // Критерий хи-квадрат
            List<GroupTableElement> dataList1 = GroupElements(GetElements(n1));
            double xiSquareMeasure = XiSquareMeasure(dataList1);
            textBox4.Text = xiSquareMeasure.ToString();
            textBox5.Text = (dataList1.Count - 1).ToString();

            //k=10
            //alpha=0.01
            label1.Show();
            label1.ForeColor = Color.Red;
            label1.Text = String.Format("Measure is {0} satisfied", xiSquareMeasure < 23.20 ? "" : "not");
            
            DensityChart(graphControl2, dataList1, Color.Blue, Color.Red);

            var dataList1Render = dataList1.Select(t => new GroupTableElementRender
            {
                Pi = t.Pit, nPi = t.Npi, Interval = t.I, mi = t.Mi
            }).ToList();
            dataGridView1.DataSource = dataList1Render;
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.Visible = true;

            // Критерий Колмогорова
            List<TableElement> dataList2 = GetElements(n2);
            double kolmogorovMeasure = KolmogorovMeasure(dataList2);
            textBox7.Text = kolmogorovMeasure.ToString();
            textBox8.Text = (kolmogorovMeasure / Math.Sqrt(dataList2.Count)).ToString();

            //доверит. вероятность=0.75
            label5.Show();
            label5.ForeColor = Color.Red;
            label5.Text = String.Format("Measure is {0} satisfied", kolmogorovMeasure < 1.02 ? "" : "not");

            FunctionChart(graphControl1, dataList2, Color.Green, Color.Red);

            var dataList2Render = dataList2.Select(t => new TableElementRender
            {
                X = t.X,
                Y = t.Y,
                i = t.I,
            }).ToList();
            
            dataGridView2.DataSource = dataList2Render;
            dataGridView2.ScrollBars = ScrollBars.Both;
            dataGridView2.Visible = true;

            // Критерий Мизеса
            List<TableElement> dataList3 = GetElements(n3);
            double misesMeasure = MisesMeasure(dataList3);
            textBox10.Text = misesMeasure.ToString();
            //уровень значимости=0.1
            label6.Show();
            label6.ForeColor = Color.Red;
            label6.Text = String.Format("Measure is {0} satisfied", misesMeasure < 0.347 ? "" : "not");
            FunctionChart(graphControl3, dataList3, Color.Green, Color.Red);

            var dataList3Render = dataList3.Select(t => new TableElementRender
            {
                X = t.X,
                Y = t.Y,
                i = t.I,
            }).ToList();

            dataGridView3.DataSource = dataList3Render;
            dataGridView3.ScrollBars = ScrollBars.Both;
            dataGridView3.Visible = true;
        }

        private List<TableElement> GetElements(int n)
        {
            var dataList = new List<TableElement>(n);

            var random = new Random();
            double b = mx + Math.Sqrt(3 * dx);
            double a = 2 * mx - b;

            for (int i = 0; i < n; i++)
            {
                dataList.Add(new TableElement());

                dataList[i].E = random.NextDouble();
                dataList[i].X = dataList[i].E * (b - a) + a;
                dataList[i].Y = dataList[i].X * dataList[i].X;
                dataList[i].Ni = Math.Pow(n, -1);
            }

            dataList = dataList.OrderBy(x => x.X).ToList();

            for (int i = 0; i < n; i++)
            {
                dataList[i].Fy = 0;
                dataList[i].I = i;
                for (int j = 0; j < i; j++)
                {
                    dataList[i].Fy += dataList[j].Ni;
                }
            }

            return dataList;
        }

        private double GetNumberOfElementsPerInterval(int n)
        {
            double m = (n <= 100) ? Math.Sqrt(n) : (2 * Math.Log(n));
            return n / m;
        }

        private List<GroupTableElement> GroupElements(List<TableElement> elements)
        {
            var dataList = new List<GroupTableElement>();

            if (elements == null || elements.Count == 0)
            {
                return dataList;
            }
            int n = elements.Count;
            var v = (int)GetNumberOfElementsPerInterval(elements.Count);
            int numberOfIntervals = (n - n % v) / v;

            int nn = v * numberOfIntervals;

            GroupTableElement groupElement;
            for (int i = 1; i < numberOfIntervals; i++)
            {
                groupElement = new GroupTableElement
                {
                    I = i,
                    Mi = v,
                    Ai = (i == 1) ? elements[0].Y : (elements[(i - 1)*(v - 1)].Y + elements[(i - 1)*v].Y)/2,
                    Bi = (elements[i*(v - 1)].Y + elements[i*v].Y)/2
                };
                groupElement.DeltaI = groupElement.Bi - groupElement.Ai;
                groupElement.Pi = (double)v / nn;
                groupElement.Fi = (groupElement.DeltaI.Equals(0.0) == false) ? (groupElement.Pi / groupElement.DeltaI) : 0;
                groupElement.Y = (groupElement.Ai + groupElement.Bi) / 2;
                groupElement.Pit =( Math.Sqrt(groupElement.Bi) - Math.Sqrt(groupElement.Ai))/ 6;
                groupElement.Npi = n * groupElement.Pit;
                dataList.Add(groupElement);
            }

            groupElement = new GroupTableElement
            {
                I = numberOfIntervals,
                Mi = v,
                Ai = (elements[(numberOfIntervals - 1)*(v - 1)].Y + elements[(numberOfIntervals - 1)*v].Y)/2,
                Bi = (elements[numberOfIntervals*(v - 1)].Y + elements[elements.Count - 1].Y)/2
            };
            groupElement.DeltaI = groupElement.Bi - groupElement.Ai;
            groupElement.Pi = (double)v / nn;
            groupElement.Fi = (groupElement.DeltaI.Equals(0.0) == false) ? (groupElement.Pi / groupElement.DeltaI) : 0;
            groupElement.Y = (groupElement.Ai + groupElement.Bi) / 2;
            groupElement.Pit = (Math.Sqrt(groupElement.Bi) - Math.Sqrt(groupElement.Ai)) / 6;
            groupElement.Npi = n * groupElement.Pit;
            dataList.Add(groupElement);


            return dataList;
        }

        private void DensityChart(ZedGraphControl graphControl, List<GroupTableElement> dataList, Color barColor, Color densityColor)
        {
            // Общий график
            GraphPane pane = graphControl.GraphPane;
            pane.Title.Text = "Histogram & density";
            pane.XAxis.Scale.Min = -5;
            pane.XAxis.Scale.Max = 40;
            pane.CurveList.Clear();

            //Гистограмма на общем графике
            var pointList = new PointPairList {{0, 0}};
            foreach (GroupTableElement tableElement in dataList)
            {
                pointList.Add(tableElement.Ai, 0);
                pointList.Add(tableElement.Ai, tableElement.Fi);
                pointList.Add(tableElement.Bi, tableElement.Fi);
                pointList.Add(tableElement.Bi, 0);
            }
            pointList.Add(dataList[dataList.Count - 1].Bi, 0);
            pane.AddCurve("histogram", pointList, barColor, SymbolType.None);

            //плотность
            pointList = new PointPairList();
            foreach (GroupTableElement tableElement in dataList)
            {
                double value = 1 / (12 * Math.Sqrt(tableElement.Y));
                pointList.Add(tableElement.Y, value);
            }
            pane.AddCurve("density", pointList, densityColor, SymbolType.None);

            graphControl.AxisChange();
            graphControl.Invalidate();
        }

        private void FunctionChart(ZedGraphControl graphControl, List<TableElement> dataList, Color empiricColor, Color theoreticColor)
        {
            //График эмпирической функции распределения
            GraphPane pane = graphControl.GraphPane;
            pane.Title.Text = "Distribution function";
            pane.XAxis.Title.Text = "Y";
            pane.XAxis.Scale.Min = -5;
            pane.XAxis.Scale.Max = 40;
            pane.YAxis.Title.Text = "F(Y)";
            pane.CurveList.Clear();
            var pointList = new PointPairList
            {
                {-5, 0},
                {0, 0},
                {dataList[0].Y, 0},
                {PointPairBase.Missing, PointPairBase.Missing},
                {PointPairBase.Missing, PointPairBase.Missing}
            };
            for (int i = 1; i < dataList.Count; i++)
            {
                pointList.Add(dataList[i - 1].Y, dataList[i].Fy);
                pointList.Add(dataList[i].Y, dataList[i].Fy);
                pointList.Add(PointPairBase.Missing, PointPairBase.Missing);

                var vt = new PointPairList {{dataList[i - 1].Y, dataList[i].Fy}};
                pane.AddCurve(null, vt, empiricColor, SymbolType.Circle);
            }
            pointList.Add(dataList[dataList.Count - 1].Y, 1);
            pointList.Add(36, 1);
            pointList.Add(41, 1);
            pane.AddCurve("F*(Y)", pointList, empiricColor, SymbolType.None);

            //График теоретической функции распределения
            pointList = new PointPairList {{-5, 0}, {0, 0}};
            foreach (TableElement tableElement in dataList)
            {
                double value = Math.Sqrt(tableElement.Y) / 6;
                pointList.Add(tableElement.Y, value);
            }
            pointList.Add(36, 1);
            pointList.Add(41, 1);
            pane.AddCurve("F(Y)", pointList, theoreticColor, SymbolType.None);
            graphControl.AxisChange();
            graphControl.Invalidate();
        }

        private double XiSquareMeasure(IEnumerable<GroupTableElement> list)
        {
            return list.Sum(element => Math.Pow(element.Mi - element.Npi, 2)/element.Npi);
        }

        private double KolmogorovMeasure(List<TableElement> list)
        {
            double dn = 0;
            for (int i = 1; i < list.Count; i++)
            {
                double d1 = (Math.Abs(list[i].Fy - Math.Sqrt(list[i - 1].Y) / 6));
                if (dn < d1) dn = d1;
            }
            return Math.Sqrt(list.Count) * dn;
        }

        private double MisesMeasure(List<TableElement> list)
        {
            double wi = 0;
            int n = list.Count;
            for (int i = 1; i < n; i++)
            {
                wi += Math.Pow(Math.Sqrt(list[i].Y) / 6 - ((i - 0.5) / n), 2);
            }
            wi = wi + 1.0 / (12 * n);
            return wi;
        }

    }
}