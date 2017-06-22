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
            WriteFtFe(helper);
            var theor = new PointPairList();
            for (double i = 0.0; i > -1.0; i -= 0.1)
            {
                theor.Add(i, 0);
            }
			var theor1 = helper.GetTheoreticalPoints();
            theor.Add(theor1);
		    for (double i = 1.0; i < 3.0; i++)
		    {
		        theor.Add(i, 1);
		    }
            
			var emp = helper.GetEmpiricPoints();

            GraphPane pane = zgcFunctions.GraphPane;

		    pane.XAxis.Scale.Max = 2;
            pane.XAxis.Scale.Min = -1;


            pane.Title.Text = "Эмпирическая и  Теоретическая ф-и";
            zgcFunctions.GraphPane.AddCurve("Эмпирическая ф-я", null, Color.Blue, SymbolType.Circle);
            DrawNewEmpiric(emp);
			zgcFunctions.GraphPane.AddCurve("Теоретическая ф-я", theor, Color.Red, SymbolType.None);
			FinishSettings();
		}

		private void FinishSettings()
		{
			zgcFunctions.AxisChange();
			zgcFunctions.Invalidate();
		}

        private void WriteFtFe(Helper helper)
        {
            var ft = helper.GetFt();
            var fe = helper.GetFe();
            for (int i = 0; i < ft.Count; i++)
            {
                lbxFt.Items.Add(i + 1 + ". " + Math.Round(ft[i], 6).ToString() + "\n");
                lbxFe.Items.Add(i + 1 + ". " + Math.Round(fe[i], 6).ToString() + "\n");
            }
        }

		private void WriteXy(Helper helper)
		{
			var x = helper.X;
			var y = helper.Y;
			for (int i = 0; i < x.Count; i++)
			{				
				lbxX.Items.Add(i + 1 + ". " + Math.Round(x[i], 6).ToString() + "\n");
				lbxY.Items.Add(i + 1 + ". " +Math.Round(y[i], 6).ToString() + "\n");
			}
		}

		private PointPairList DrawEmpiric(PointPairList emp)
		{
			var result = new PointPairList();
			for (int i = 1; i < emp.Count; i++)
			{
				result.Add(emp[i].X, emp[i - 1].Y);
				result.Add(emp[i]);
			}
			return result;
		}


        private void DrawNewEmpiric(PointPairList emp)
        {
            var list = new PointPairList();
            for (double i = -1.0; i < 0.0; i += 0.1)
            {
                list.Add(i, 0);
            }
            zgcFunctions.GraphPane.AddCurve(null, list, Color.Blue, SymbolType.None);
            PointPairList emplist = DrawEmpiric(emp);
            for (int i = 1; i < emplist.Count; i++)
            {
                if (emplist[i].Y.Equals(emplist[i - 1].Y))
                {
                    var vt = new PointPairList {emplist[i - 1]};
                    var result = new PointPairList {emplist[i - 1], emplist[i]};
                    if (i != emplist.Count - 1) 
                        zgcFunctions.GraphPane.AddCurve(null, vt, Color.Blue, SymbolType.Circle);
                    zgcFunctions.GraphPane.AddCurve(null, result, Color.Blue, SymbolType.None);
                }
            }

            list = new PointPairList();
            for (double i = 1.0; i < 3.0; i++)
            {
                list.Add(i, 1);
            }
            zgcFunctions.GraphPane.AddCurve(null, list, Color.Blue, SymbolType.None);
        }

		private void Clear()
		{
			zgcFunctions.GraphPane.CurveList.Clear();
			zgcFunctions.Refresh();
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