using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace _5.ConfidenceIntervals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly Random random = new Random();

        private readonly InputViewModel viewModel = new InputViewModel
        {
            Count = 20,
            Lambda = 0.95
        };

        private readonly InputViewModel viewModel2 = new InputViewModel
        {
            Count = 20,
            Lambda = 0.95
        };

        public MainWindow()
        {
            InitializeComponent();
            tab1.DataContext = viewModel;
            tab2.DataContext = viewModel2;
        }

        private double Next()
        {
            double x = random.NextDouble() * 2 - 1;
            double result = Math.Pow(Math.Abs(x), 1.0 / 3.0);
            return result * Math.Sign(x);
        }

        private List<double> GetRandomValues(int count)
        {
            var list = new List<double>();
            for (int i = 0; i < count; i++)
            {
                list.Add(Next());
            }
            list.Sort();
            return list;
        }

        private static double PracticalExpectedValue(IReadOnlyCollection<double> values)
        {
            return values.Sum() / values.Count;
        }

        private double PracticalDispersion(IReadOnlyCollection<double> values)
        {
            var expVal = PracticalExpectedValue(values);
            return values.Sum(v => Math.Pow(Math.Abs(v - expVal), 2)) / values.Count;
        }

        private double TheoreticalDispersion()
        {
            return 0.6;
        }

        private double ExpectedValueEstimationAccuracy(int count, double dispersion, double parameter)
        {
            return parameter * dispersion / Math.Sqrt(count);
        }

        private double DispersionEstimationAccuracy(int count, double dispersion, double parameter1, double parameter2)
        {
            return Math.Abs(count * dispersion / parameter1 - count * dispersion / parameter2);
        }

        private static readonly Dictionary<double, double> student20 = new Dictionary<double, double>
                                                                           {
                                                                               {0.8, 1.3253},
                                                                               {0.9, 1.7247},
                                                                               {0.95, 2.086},
                                                                               {0.98, 2.5280},
                                                                               {0.99, 2.8453},
                                                                               {0.995, 3.1534},
                                                                               {0.998, 3.5518},
                                                                               {0.999, 3.8495}
                                                                           };

        private static readonly Dictionary<double, double> laplas = new Dictionary<double, double>
                                                                           {
                                                                               {0.8, 1.28},
                                                                               {0.9, 1.64},
                                                                               {0.95, 1.96},
                                                                               {0.98, 2.32},
                                                                               {0.99, 2.58},
                                                                               {0.995, 2.8},
                                                                               {0.998, 3.10},
                                                                               {0.999, 3.30}
                                                                           };
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var list = GetRandomValues(viewModel.Count);
            viewModel.Expectations = PracticalExpectedValue(list);
            viewModel.Dispersion = PracticalDispersion(list);
            tab1.DataContext = null;
            tab1.DataContext = viewModel;
            var chart1Values =
                student20.Select(
                    t =>
                    new DistributionFunctionPoint
                    {
                        ValueX = t.Key,
                        ValueY = ExpectedValueEstimationAccuracy(viewModel.Count, viewModel.Dispersion, t.Value)
                    }).
                    ToList();
            var chart2Values =
               laplas.Select(
                   t =>
                   new DistributionFunctionPoint
                   {
                       ValueX = t.Key,
                       ValueY = ExpectedValueEstimationAccuracy(viewModel.Count, TheoreticalDispersion(), t.Value)
                   }).
                   ToList();
            chart1.ItemsSource = chart1Values;
            chart2.ItemsSource = chart2Values;
        }

        private static readonly Dictionary<int, double> student095 = new Dictionary<int, double>
                                                                  {
                                                                      {30,2.0423},
                                                                      {50,2.0086},
                                                                      {70,1.9944},
                                                                      {100,1.9840},
                                                                      {150,1.9759}
                                                                  };

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var list = GetRandomValues(150);
            var chart3Values = student095.Select(t =>
                    new DistributionFunctionPoint
                    {
                        ValueX = t.Key,
                        ValueY = 0.2 - ExpectedValueEstimationAccuracy(t.Key, PracticalDispersion(list.GetRange(0, t.Key)), t.Value)
                    }).ToList();
            var chart4Values = student095.Select(t =>
                    new DistributionFunctionPoint
                    {
                        ValueX = t.Key,
                        ValueY = ExpectedValueEstimationAccuracy(t.Key, TheoreticalDispersion(), laplas[viewModel.Lambda])
                    }).ToList();
            chart3.ItemsSource = chart3Values;
            chart4.ItemsSource = chart4Values;
        }

        private static readonly Dictionary<double, double> hiSquare1 = new Dictionary<double, double>
                                                                        {
                                                                            {0.99, 38.58226},
                                                                            {0.98, 36.19087},
                                                                            {0.95, 32.85233},
                                                                            {0.9, 30.14353},
                                                                            {0.8, 27.20357},
                                                                            {0.5, 22.71781}
                                                                        };


        private static readonly Dictionary<double, double> hiSquare2 = new Dictionary<double, double>
                                                                        {
                                                                            {0.99, 6.84397},
                                                                            {0.98, 7.63273},
                                                                            {0.95, 8.90652},
                                                                            {0.9, 10.11701},
                                                                            {0.8, 11.65091},
                                                                            {0.5, 14.56200}
                                                                        };

        private static readonly Dictionary<int, double> hiSquareGamma0951 = new Dictionary<int, double>
                                                                                 {
                                                                                     {10, 3.24697},
                                                                                     {15, 6.26214},
                                                                                     {20, 9.59078},
                                                                                     {25, 13.11972},
                                                                                     {30, 16.79077}
                                                                                 };

        private static readonly Dictionary<int, double> hiSquareGamma0952 = new Dictionary<int, double>
                                                                                 {
                                                                                     {10, 20.48318},
                                                                                     {15, 27.48839},
                                                                                     {20, 34.16961},
                                                                                     {25, 40.64647},
                                                                                     {30, 46.97924}
                                                                                 };

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var list = GetRandomValues(20);
            viewModel2.Expectations = PracticalExpectedValue(list);
            viewModel2.Dispersion = PracticalDispersion(list);
            tab2.DataContext = null;
            tab2.DataContext = viewModel2;
            var chart1Values =
                hiSquare1.Select(
                    t =>
                    new DistributionFunctionPoint
                    {
                        ValueX = t.Key,
                        ValueY = DispersionEstimationAccuracy(20, viewModel2.Dispersion, t.Value, hiSquare2[t.Key])
                    }).Reverse().ToList();
            var chart2Values =
                hiSquare1.Select(
                    t =>
                    new DistributionFunctionPoint
                    {
                        ValueX = t.Key,
                        ValueY = DispersionEstimationAccuracy(20, TheoreticalDispersion(), t.Value, hiSquare2[t.Key])
                    }).Reverse().ToList();
            chart5.ItemsSource = chart1Values;
            chart6.ItemsSource = chart2Values;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var list = GetRandomValues(30);
            var chart1Values =
                hiSquareGamma0951.Select(
                    t =>
                    new DistributionFunctionPoint
                    {
                        ValueX = t.Key,
                        ValueY = 1.4 - DispersionEstimationAccuracy(t.Key, PracticalDispersion(list.GetRange(0, t.Key)), t.Value, hiSquareGamma0952[t.Key])
                    }).ToList();
            var chart2Values =
                hiSquareGamma0951.Select(
                    t =>
                    new DistributionFunctionPoint
                    {
                        ValueX = t.Key,
                        ValueY = DispersionEstimationAccuracy(t.Key, TheoreticalDispersion(), t.Value, hiSquareGamma0952[t.Key])
                    }).ToList();
            chart7.ItemsSource = chart1Values;
            chart8.ItemsSource = chart2Values;
        }
    }
}
