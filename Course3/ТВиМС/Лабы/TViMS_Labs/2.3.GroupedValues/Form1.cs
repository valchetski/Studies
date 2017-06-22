using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace labwork1
{
	public partial class Form1 : Form
	{
		private int n;

		public Form1()
		{
			InitializeComponent();
		}

		private void SetValues()
		{
			var helper = new Helper(n);
			WriteXy(helper);
			var theor = helper.GetTheoreticalPoints();
			var emp = helper.GetEmpiricPoints(true);
			zgcFunctions.GraphPane.AddCurve("Эмпирическая (равноинт.)", DrawEmpiric(emp, Color.Blue), Color.Blue, SymbolType.None);

            emp = helper.GetEmpiricPoints(false);
            zgcFunctions.GraphPane.AddCurve("Эмпирическая (равновероятн.)", DrawEmpiric(emp, Color.Red), Color.Red, SymbolType.None);

			zgcFunctions.GraphPane.AddCurve("Теоретическая ф-я", theor, Color.Black, SymbolType.None);
			
			zgcInterval.GraphPane.AddCurve("Гистограмма", helper.PrepareIntervalHistogramm(), Color.YellowGreen, SymbolType.None);
			zgcInterval.GraphPane.AddCurve("Плотность", helper.GetDensityPoints(), Color.Red, SymbolType.None);
			Helper.GetHistogramm hist = helper.PrepareIntervalHistogramm;
			zgcInterval.GraphPane.AddCurve("Полигон", helper.GetPolygon(hist), Color.RoyalBlue, SymbolType.None);		
			
			zgcProbability.GraphPane.AddCurve("Гистограмма", helper.PrepareProbabilisticHistogramm(), Color.YellowGreen, SymbolType.None);
			zgcProbability.GraphPane.AddCurve("Плотность", helper.GetDensityPoints(), Color.Red, SymbolType.None);
			hist = helper.PrepareProbabilisticHistogramm;
			zgcProbability.GraphPane.AddCurve("Полигон", helper.GetPolygon(hist), Color.RoyalBlue, SymbolType.None);
			FinishSettings();
		}

		private void FinishSettings()
		{
			zgcInterval.AxisChange();
			zgcInterval.Invalidate();
			zgcFunctions.AxisChange();
			zgcFunctions.Invalidate();
			zgcProbability.AxisChange();
			zgcProbability.Invalidate();
		}

		private void WriteXy(Helper helper)
		{
			var x = helper.GetX();
			var y = helper.GetY();
			for (int i = 0; i < x.Count; i++)
			{				
				lbxX.Items.Add(i + 1 + ". " + Math.Round(x[i], 6) + "\n");
				lbxY.Items.Add(i + 1 + ". " +Math.Round(y[i], 6) + "\n");
			}
		}

		private PointPairList DrawEmpiric(PointPairList emp, Color color)
		{
            var list = new PointPairList();
            for (double i = -1.0; i < 0.0; i += 0.1)
            {
                list.Add(i, 0);
            }
            zgcFunctions.GraphPane.AddCurve(null, list, color, SymbolType.None);
            var emplist = new PointPairList();
            for (int i = 1; i < emp.Count; i++)
            {
                emplist.Add(emp[i].X, emp[i - 1].Y);
                emplist.Add(emp[i]);

            }
            for (int i = 1; i < emplist.Count; i++)
            {
                if (emplist[i].Y.Equals(emplist[i - 1].Y))
                {
                    var vt = new PointPairList {emplist[i - 1]};
                    var result = new PointPairList {emplist[i - 1], emplist[i]};
                    if (i != emplist.Count - 1)
                        zgcFunctions.GraphPane.AddCurve(null, vt, color, SymbolType.Circle);
                    zgcFunctions.GraphPane.AddCurve(null, result, color, SymbolType.None);
                }
            }

            list = new PointPairList();
            for (double i = 1.0; i < 3.0; i++)
            {
                list.Add(i, 1);
            }
            zgcFunctions.GraphPane.AddCurve(null, list, color, SymbolType.None);

		    return list;
		}

	    private void Clear()
		{
			zgcFunctions.GraphPane.CurveList.Clear();
			zgcFunctions.Refresh();
			zgcInterval.GraphPane.CurveList.Clear();
			zgcInterval.Refresh();
			zgcProbability.GraphPane.CurveList.Clear();
			zgcProbability.Refresh();
			lbxY.Items.Clear();
			lbxX.Items.Clear();
		}

		private void btnSolve_Click(object sender, EventArgs e)
		{
			Clear();
			if (!String.IsNullOrEmpty(tbxN.Text))
				n = Convert.ToInt32(tbxN.Text);
			SetValues();
		}
	}
}
