using System;
using System.Windows;
using System.Windows.Controls;
using Lab2.ConversionMethods;
using Lab2.Extensions;
using Lab2.SolveMethods;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab2
{
    public partial class MainWindow
    {
        private readonly JacobiConversion jacobiConverter;
        private readonly IdentityMatrixConversion viaIdentityMatrixConverter;
        private readonly RandomConversion randomTransformer;

        private readonly Solver simpleIterationSolver;
        private readonly Solver seidelIterationSolver;

        private int size;
        private double accuracy;
        private int maxIterations;
        private string format;

        public MainWindow()
        {
            InitializeComponent();

            jacobiConverter = new JacobiConversion();
            viaIdentityMatrixConverter = new IdentityMatrixConversion();
            randomTransformer = new RandomConversion();

            simpleIterationSolver = new SimpleIterationSleSolver();
            seidelIterationSolver = new SeidelSleSolver();

            ChangedFormat(NumberOfDecimalPlacesTextBox, new RoutedEventArgs());
            ChangedAccuracy(AccuracyTextBox, new RoutedEventArgs());
            ChangedSizeMatrix(SizeTextBox, new RoutedEventArgs());
            ChangedIterations(IterationsTextBox, new RoutedEventArgs());

            InitializeMatrix();
        }

        private void ChangedSizeMatrix(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            int value;
            if (int.TryParse(textBox.Text, out value))
            {
                if (size == value)
                    return;

                size = value;
                ResizeMatrix();
            }
        }

        private void ChangedFormat(object sender, RoutedEventArgs e)
        {
            var decimals = int.Parse((sender as TextBox).Text);
            format = "{0:0.";
            for (int i = 0; i < decimals; i++)
                format += "#";
            format += "}";
        }

        private void ChangedIterations(object sender, RoutedEventArgs e)
        {
            maxIterations = Int32.Parse((sender as TextBox).Text);
            simpleIterationSolver.maxIteration = maxIterations;
            seidelIterationSolver.maxIteration = maxIterations;
        }

        private void ChangedAccuracy(object sender, RoutedEventArgs e)
        {
            var text = (sender as TextBox).Text;
            accuracy = Double.Parse(text.Replace('.', ','));
        }

        private void GenerateMatrix(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            for (int y = 0; y < size; y++)
            {
                ((MatrixB.Children[0] as StackPanel).Children[y] as TextBox).Text = random.Next(-10, 10).ToString();
                for (int x = 0; x < size; x++)
                {
                    ((MatrixA.Children[x] as StackPanel).Children[y] as TextBox).Text = random.Next(-10, 10).ToString();
                }
            }
        }

        private Conversion GetCurrentConverter()
        {
            if (Jacobi.IsChecked.HasValue && Jacobi.IsChecked.Value)
                return jacobiConverter;
            if (Random.IsChecked.HasValue && Random.IsChecked.Value)
            {
                randomTransformer.firstValue = double.Parse(FirstInt.Text.Replace('.', ','));
                randomTransformer.lastValue = double.Parse(LastInt.Text.Replace('.', ','));
                randomTransformer.step = double.Parse(Step.Text.Replace('.', ','));
                return randomTransformer;
            }
            return viaIdentityMatrixConverter;
        }

        private StackPanel CreateStackPanel(int minHeight)
        {
            var result = new StackPanel
                {
                    MinHeight = minHeight,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                };
            return result;
        }

        private TextBox CreateTextBox(string value = "0")
        {
            var result = new TextBox
                {
                    Width = 35,
                    Text = value
                };
            result.GotFocus += (sender, args) => result.SelectAll();
            return result;
        }

        private Label CreateLabel(string content)
        {
            var result = new Label
                {
                    Content = content,
                    MinWidth = 36,
                    Height = 24,
                    Margin = new Thickness(0, 0, 0, 0),
                    Padding = new Thickness(0, 0, 0, 0),
                    ToolTip = content,
                    HorizontalAlignment = HorizontalAlignment.Right,
                };
            return result;
        }

        private void InitializeMatrix()
        {
            int[,] matrixA = { { 2, 1 }, { 1, 2 } };
            int[] matrixB = { -6, -3 };

            MatrixA.Children.Clear();
            MatrixB.Children.Clear();
            MatrixX.Children.Clear();

            MatrixB.Children.Add(CreateStackPanel(24 * size));
            MatrixX.Children.Add(CreateStackPanel(24 * size));
            for (int y = 0; y < size; y++)
            {
                (MatrixX.Children[0] as StackPanel).Children.Add(CreateLabel("x" + y));
                MatrixA.Children.Add(CreateStackPanel(24 * size));
                for (int x = 0; x < size; x++)
                {
                    (MatrixA.Children[y] as StackPanel).Children.Add(CreateTextBox(matrixA[y, x].ToString()));
                }
            }
            for (int x = 0; x < size; x++)
            {
                (MatrixB.Children[0] as StackPanel).Children.Add(CreateTextBox(matrixB[x].ToString()));
            }
        }

        private void ResizeMatrix()
        {
            MatrixA.Children.Clear();
            MatrixB.Children.Clear();
            MatrixX.Children.Clear();

            MatrixB.Children.Add(CreateStackPanel(24 * size));
            MatrixX.Children.Add(CreateStackPanel(24 * size));
            for (int y = 0; y < size; y++)
            {
                (MatrixX.Children[0] as StackPanel).Children.Add(CreateLabel("x" + y));
                MatrixA.Children.Add(CreateStackPanel(24 * size));
                for (int x = 0; x < size; x++)
                {
                    (MatrixA.Children[y] as StackPanel).Children.Add(CreateTextBox());
                }
            }
            for (int x = 0; x < size; x++)
            {
                (MatrixB.Children[0] as StackPanel).Children.Add(CreateTextBox());
            }
        }

        private DenseMatrix ReadMatrixA()
        {
            var resultList = new double[size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    var value = ((MatrixA.Children[x] as StackPanel).Children[y] as TextBox).Text;
                    resultList[y, x] = double.Parse(value);
                }
            }
            return DenseMatrix.OfArray(resultList);
        }

        private DenseVector ReadMatrixB()
        {
            var resultList = new double[size];
            for (int y = 0; y < size; y++)
            {
                var value = ((MatrixB.Children[0] as StackPanel).Children[y] as TextBox).Text;
                resultList[y] = double.Parse(value);
            }
            return DenseVector.OfArray(resultList);
        }

        private void ShowMessage(string message)
        {
            Message.Content = message;
            Message.Visibility = Visibility.Visible;
        }

        private void HideMessage()
        {
            Message.Visibility = Visibility.Collapsed;
        }

        private void ShowSleIterationForm(Solution sle)
        {
            if (sle == null)
            {
                SleInterationForm.Visibility = Visibility.Collapsed;
                return;
            }

            SleInterationForm.Visibility = Visibility.Visible;

            MatrixBSleIF.Children.Clear();
            MatrixCSleIF.Children.Clear();

            MatrixCSleIF.Children.Add(CreateStackPanel(24 * sle.size));

            for (var row = 0; row < sle.size; row++)
            {
                (MatrixCSleIF.Children[0] as StackPanel).Children.Add(CreateLabel(sle.vectorC[row].StringFormat(format)));

                var s = CreateStackPanel(24 * sle.size);
                if (row + 2 < sle.size)
                    s.Margin = new Thickness(0, 0, 7, 0);

                MatrixBSleIF.Children.Add(s);
                for (var col = 0; col < sle.size; col++)
                {
                    (MatrixBSleIF.Children[row] as StackPanel).Children.Add(
                        CreateLabel(sle.matrixB[col, row].StringFormat(format)));
                }
            }
        }

        private void ShowReport(Solution sle, int iterations, DenseVector solution, string message = null)
        {
            Message.Visibility = Visibility.Collapsed;
            SolutionReport.Visibility = Visibility.Collapsed;
            SleInterationForm.Visibility = Visibility.Collapsed;
            IterationReport.Visibility = Visibility.Collapsed;

            if (message != null)
            {
                ShowMessage(message);
            }
            else
            {
                HideMessage();
            }

            SolutionReport.Visibility = Visibility.Visible;
            ShowSleIterationForm(sle);

            if (solution == null)
            {
                Solution.Visibility = Visibility.Collapsed;
                return;
            }

            IterationReport.Content = "Итераций: " + iterations;
            IterationReport.Visibility = Visibility.Visible;
            ShowSolution(solution);
        }

        private void ShowSolution(DenseVector solution)
        {
            Solution.Visibility = Visibility.Visible;
            MatrixXS1.Children.Clear();
            MatrixXS2.Children.Clear();

            MatrixXS1.Children.Add(CreateStackPanel(24 * size));
            MatrixXS2.Children.Add(CreateStackPanel(24 * size));

            for (var row = 0; row < size; row++)
            {
                (MatrixXS1.Children[0] as StackPanel).Children.Add(CreateLabel("x" + (row + 1)));
                (MatrixXS2.Children[0] as StackPanel).Children.Add(CreateLabel(solution[row].StringFormat(format)));
            }
        }

        private void SolveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SimpleIterationsRadioButton.IsChecked == true)
            {
                Method_SimpleIteration();
            }
            else if (SeidelRadioButton.IsChecked == true)
            {
                Method_SeidelIteration();
            }
        }

        private void Method_SimpleIteration()
        {
            SolveMethod(simpleIterationSolver);
        }

        private void Method_SeidelIteration()
        {
            SolveMethod(seidelIterationSolver);
        }

        private void SolveMethod(Solver solver)
        {
            Solution solution = GetCurrentConverter().Transform(size, ReadMatrixA(), ReadMatrixB());
            int iterations = 0;
            DenseVector answer = null;

            if (solution == null)
            {
                ShowReport(solution, iterations, answer,
                    "Can't convert. Diagonal elements of matrix A must not contain zero elements");
                return;
            }

            if (Relax.IsChecked.HasValue && Relax.IsChecked.Value)
                answer = solver.SolveWithRelaxation(solution, accuracy, out iterations);
            else
                answer = solver.Solve(solution, accuracy, out iterations);

            if (!IsConverges(solution.matrixB))
                ShowReport(solution, iterations, answer, "Sufficient conditions are not met");
            else
                ShowReport(solution, iterations, answer);
        }

        private bool IsConverges(DenseMatrix matrixB)
        {
            return matrixB.AbsMaximumSumOfRows() < 1 || matrixB.SumOfSquares() < 1 || matrixB.AbsMaximumSumOfColumns() < 1;
        }
    }
}
