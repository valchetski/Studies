using System;
using System.Collections.Generic;
using ZedGraph;

namespace labwork1
{
	class Helper
	{
	    private const double a = 0; 
	    private const double b = Math.PI / 4;

	    private List<double> x; 
		public List<double> X 
        {
		    get
		    {
                x = new List<double>();
                var random = new Random();
                for (int i = 0; i < n; i++)
                {
                    x.Add(random.NextDouble() * (b - a) + a);
                }
                x.Sort();
		        return x;
		    }
        }

	    private List<double> y;
	    public List<double> Y
	    {
	        get
	        {
                y = new List<double>();
                foreach (var item in X)
                {
                    y.Add(Math.Tan(item));

                }
                y.Sort();
	            return y;
	        }
	    }
        private readonly List<double> ft;
        private readonly List<double> fe;
		private readonly int n;

		public Helper(int n)
		{
			ft = new List<double>();
            fe = new List<double>();
			if (n > 0)
				this.n = n;
		}

		public List<double> GetFt()
        {
            for (int i = 0; i < n; i++)
                ft.Add(GetTheoreticalFunction(Y[i]));
            return ft;
        }

        public List<double> GetFe()
        {
            for (int i = 0; i < Y.Count; i++)
            {
                fe.Add((1.0 + i) / n);
            }
            return fe;
        }

		public PointPairList GetEmpiricPoints()
		{
			var result = new PointPairList {{a, 0}};
		    for (int i = 0; i < Y.Count; i++)
		    {
                result.Add(Y[i], (1.0 + i) / n);
		    }
			result.Add(1, 1);
			return result;
		}

		private double GetTheoreticalFunction(double value)
		{
            return (4/Math.PI)*Math.Atan(value);
		}

		public PointPairList GetTheoreticalPoints()
		{
			var result = new PointPairList {{a, 0}};
		    for (int i = 0; i < n; i++)
				result.Add(Y[i], GetTheoreticalFunction(Y[i]));
			result.Add(1, 1);
			return result;
		}
	}
}
