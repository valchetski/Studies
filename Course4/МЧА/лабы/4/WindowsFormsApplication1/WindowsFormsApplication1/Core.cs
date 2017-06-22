using System;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public class Core
    {
        public Dictionary<double, List<double>> T;
        private double a;
        private double b;
        private double k { get; set; }
        public double h { get { return Math.Round((b - a) / 10, 3); } }
        public double tau { get { return h / 2; } }
        private double t_max;
        public List<double> X;


        public Core()
        {
            a = 0;
            b = Math.PI;
            k = 1;
            t_max = 4;
            T = new Dictionary<double, List<double>>();
            Init();

        }

        public void Init()
        {
            //заполняем массив координат х
            X = new List<double>();
            double i = a;
            while (i <= b)
            {
                X.Add(i);
                i += h;
            }
            // получаем значения температур в началный момент времени
            List<double> temp = new List<double>();
            List<double> temp1 = new List<double>();
            foreach (var x in X)
            {
                var t0 = 0/*Math.Sin(x)*/;
                temp.Add(t0);
                //var t1 = tau * (-k * Math.Cos(x)) + t0;
                var t1 = tau * (2 * Math.Exp(-x) * Math.Sin(x)) + t0;
                temp1.Add(t1);
            }
            T.Add(0, temp);
            T.Add(tau, temp1);

        }

        public void GetNextT(double t, double pr, double prpr)
        {
            var prev = T[pr];
            var prev_prev = T[prpr];
            List<double> tmp = new List<double>() { UA(t) };
            for (int i = 1; i < prev.Count - 1; i++)
            {
                double val = Math.Pow(k * tau / h, 2) * (prev[i - 1] - 2 * prev[i] + prev[i + 1]) + 2 * prev[i] - prev_prev[i];
                tmp.Add(val);
            }
            tmp.Add(UB(t));
            T.Add(t, tmp);
        }


        public double f(double x)
        {
            return 0;
        }

        public double UA(double t)
        {
            return 0;
            //return -Math.Sin(t * k);
        }

        public double UB(double t)
        {
            return 0;
            //return Math.Sin(t * k);
        }

        public void Do()
        {
            double prev = tau;
            double prevprev = 0;
            for (double i = 2 * tau; i <= t_max; i += tau)
            {

                GetNextT(i, prev, prevprev);
                prevprev = prev;
                prev = i;
            }

        }




    }
}
