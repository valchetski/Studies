using System;
using System.Collections.Generic;
using System.Linq;
using ZedGraph;

namespace labwork1
{
	class Helper
	{
		private const double a = 0;
		private const double b = Math.PI / 4;
		private readonly List<double> x;
		private readonly List<double> y;
		private readonly int n;

		public Helper(int n)
		{
			x = new List<double>();
			y = new List<double>();
			if (n > 0)
				this.n = n;
		}

	    public List<double> GetX()
		{
            var random = new Random();
            for (int i = 0; i < n; i++)
            {
                x.Add(random.NextDouble() * (b - a) + a);
            }
            x.Sort();
			return x;
		}

		public List<double> GetY()
		{
            foreach (var item in x)
            {
                y.Add(Math.Tan(item));
            }

			return y;
		}

		public PointPairList GetEmpiricPoints(bool isEqualIntervals)
		{
			var result = new PointPairList {{a, 0}};

		    int step =  y.Count / GetSections();
		    double deltaI = (y[n - 1] - y[0])/GetSections();
		    double yi = y[0];

		    int v = n/GetSections();
		    int hz = 1;
            for (int i = 1; i <= GetSections(); i++)
            {
                result.Add(yi, ((hz + 0.0) / n));
                hz += step;
			    
                if (isEqualIntervals)
			    {
                    yi += deltaI;
			    }
			    else
                {
                    yi = (i == 1) ? y[0] : (y[(i - 1)*(v - 1)] + y[(i - 1)*v])/2;
                }
			}
			result.Add(1, 1);
			return result;
		}

	    private double GetTheoreticalFunction(double value)
		{
			return  4 / Math.PI * Math.Atan(value);
		}

		public PointPairList GetTheoreticalPoints()
		{
			var result = new PointPairList {{a, 0}};
		    for (int i = 0; i < n; i++)
			{
				result.Add(y[i], GetTheoreticalFunction(y[i]));				
			}
			result.Add(1, 1);
			return result;
		}
		
		private double GetDensity(double yNew)
		{
			return 4 / Math.PI * (1 / (1 + Math.Pow(yNew, 2)));
		}

		public PointPairList GetDensityPoints()
		{
			var result = new PointPairList {{0, GetDensity(0)}};
		    foreach (double t in y)
		    {
		        result.Add(t, GetDensity(t));
		    }
		    return result;
		}

		private int GetSections()
		{
		    return n <= 100 ? (int) Math.Sqrt(n) : (int) (3.322*Math.Log10(n));
		}

	    public delegate PointPairList GetHistogramm();

		public PointPairList PrepareIntervalHistogramm()
		{
			var gist = GetIntervalHistogramm(GetSections());
			var points = new PointPairList();
			double first = 0;
			var step = y[n - 1] / GetSections();
			foreach (double t in gist)
			{
			    points.Add(first, 0);
			    points.Add(first, t / step);
			    points.Add(first + step, t / step);
			    first += step;
			}
			points.Add(first, 0);
			return points;
		}
		
		private IEnumerable<double> GetIntervalHistogramm(int sections)
		{
		    var step = y[n - 1] / sections;
			var temp = step;
			int interval = 0;
			var values = new int[sections];
			for (int i = 0; i < n; i++)
			{
				if (Math.Round(y[i], 6) <= Math.Round(temp, 6))
				{
					values[interval]++;
				}
				else
				{
					temp += step;
					interval++;
					values[interval]++;
				}
			}
		    return values.Select(t => (double) t/n).ToList();
		}

		private List<double> GetProbabilisticHistogramm(int sections)
		{			
			int pointCount = n / sections;
			var values = new List<double> {0};
		    for (int i = 0; i < n; i++)
			{
				if ((i + 1) % pointCount == 0)
				{
					values.Add(y[i]);
				}
			}
			return values;
		}

		public PointPairList PrepareProbabilisticHistogramm()
		{
			List<double> hist = GetProbabilisticHistogramm(GetSections());
			var points = new PointPairList();
			int pointCount = n / GetSections();
			double step;		
			for (int i = 1; i < hist.Count; i++)
			{
				step = hist[i] - hist[i - 1];
				points.Add(hist[i - 1], 0);
				points.Add(hist[i - 1], pointCount / (step * n));
				points.Add(hist[i], pointCount / (step * n));
			}
			points.Add(hist[hist.Count - 1], 0);
			return points;
		}

		public PointPairList GetPolygon(GetHistogramm hist)
		{
			var result = new PointPairList();
			var points = hist();
			for (int i = 1; i < points.Count - 1; i += 3)
			{
				result.Add((points[i + 1].X - points[i].X) / 2 + points[i].X, points[i].Y);
			}
			return result;
		}
	}
}
