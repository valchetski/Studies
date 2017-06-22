using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MathNet.Numerics.LinearAlgebra.Double;
using _1.Gauss.SolutionMethods;

namespace _1.Gauss
{
    public partial class MainWindow
    {
        private int size;
        private string accuracy;

        private delegate void CreateSolve(Solution solution);

        public MainWindow()
        {
            InitializeComponent();
            size = 3;
            ResizeMatrix();
        }

        private void SetAccuracy()
        {
            accuracy = "{0:0.}";
            //узнаем количество символов после запятой
            int count = (EpsilonTextBox.Text.Length - 1) - EpsilonTextBox.Text.IndexOf('.');
            int startPosition = accuracy.IndexOf('.') + 1;
            for (int i = 0; i < count; i++)
            {
                accuracy = accuracy.Insert(i + startPosition, "#");
            }
        }

        private void GenerateMatrix(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)//заполняем первую матрицу
                {
                    ((MatrixA.Children[x] as StackPanel).Children[y] as TextBox).Text = random.Next(-10, 10).ToString();
                }
                //заполняем вторую матрицу
                ((MatrixB.Children[0] as StackPanel).Children[y] as TextBox).Text = random.Next(-10, 10).ToString();
            }
        }

        #region Change size of matrix

        private void ChangedSizeMatrix(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            int value;
            if (int.TryParse(textBox.Text, out value))
            {
                size = value;
                ResizeMatrix();
            }
        }

        private void ResizeMatrix()
        {
            MatrixA.Children.Clear();
            MatrixB.Children.Clear();
            MatrixX.Children.Clear();

            MatrixB.Children.Add(CreateStackPanel(24 * size));
            MatrixX.Children.Add(CreateStackPanel(10 * size));
            (MatrixX.Children[0] as StackPanel).Orientation = Orientation.Horizontal;
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

        #endregion

        #region CreateControls

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

        #endregion

        #region Get Matrixes from WrapPanels

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

        private DenseMatrix ReadMatrixB()
        {
            var resultList = new double[size, 1];
            for (int y = 0; y < size; y++)
            {
                var value = ((MatrixB.Children[0] as StackPanel).Children[y] as TextBox).Text;
                resultList[y, 0] = double.Parse(value);
            }
            return DenseMatrix.OfArray(resultList);
        }

        #endregion

        #region Create solve
        private void CreateSolve1(Solution sle)
        {
            Solve1.Visibility = Visibility.Visible;
            Solve3.Visibility = Visibility.Collapsed;

            MatrixAs1.Children.Clear();
            MatrixBs1.Children.Clear();

            MatrixBs1.Children.Add(CreateStackPanel(24 * size));
            for (int y = 0; y < size; y++)
            {
                MatrixAs1.Children.Add(CreateStackPanel(24 * size));
                for (int x = 0; x < size; x++)
                {
                    (MatrixAs1.Children[y] as StackPanel).Children.Add(CreateLabel(String.Format(accuracy, sle.matrixA[x, y])));
                }
            }
            for (int x = 0; x < size; x++)
            {
                (MatrixBs1.Children[0] as StackPanel).Children.Add(CreateLabel(String.Format(accuracy, sle.matrixB[x, 0])));
            }
        }

        private void CreateSolve2(Solution sle)
        {
            Solve2.Visibility = Visibility.Visible;

            MatrixBs2.Children.Clear();
            MatrixXs2.Children.Clear();

            MatrixBs2.Children.Add(CreateStackPanel(24*size));
            MatrixXs2.Children.Add(CreateStackPanel(24*size));
            for (int i = 0; i < size; i++)
            {
                (MatrixXs2.Children[0] as StackPanel).Children.Add(CreateLabel("x" + i));
                (MatrixBs2.Children[0] as StackPanel).Children.Add(CreateLabel(GetValueForSolve2(sle, i)));
            }
        }

        private string GetValueForSolve2(Solution sle, int index)
        {
            if (sle.GetSolutionType() == SolutionType.InfinitySolutions)
            {
                string solutionString = "";
                var solution = DenseMatrix.OfMatrix(sle.solution);
                for (int j = 0; j < solution.ColumnCount; j++)
                {
                    if (solution[index, j] != 0.0)
                    {
                        string value = "";
                        
                        if (solutionString != "")
                        {
                            value = solution[index, j] < 0 ? " - " : " + ";
                        }
                        else if (solution[index, j] < 0)
                        {
                            value = "-";
                        }
                        value += Math.Abs(solution[index, j]);

                        if (j != solution.ColumnCount - 1)//когда значение не из столбца своб. членов
                        {
                            value = value.Trim('1');
                            value = String.Format("{0}x{1}", value, j);
                        }
                        solutionString += value;
                    }
                }

                if (solutionString == "")
                {
                    solutionString = "0";
                }

                return solutionString;
            }
            return String.Format(accuracy, sle.solution[index, 0]);
        }

        private void CreateSolve3(Solution sle)
        {
            Solve3.Visibility = Visibility.Visible;

            MatrixAs3.Children.Clear();
            for (int y = 0; y < size; y++)
            {
                MatrixAs3.Children.Add(CreateStackPanel(24 * size));
                for (int x = 0; x < size; x++)
                {
                    (MatrixAs3.Children[y] as StackPanel).Children.Add(CreateLabel(String.Format(accuracy, sle.matrixA[x, y])));
                }
            }
        }

        private void CreateSolve4(Dictionary<Type, long> timeDictionary)
        {
            ResetView();
            Solve4.Visibility = Visibility.Visible;
            Solve4.Children.Clear();

            KeyValuePair<Type, long> value;
            int count = timeDictionary.Count;
            for (int i = 0; i < count; i++)
            {
                value = timeDictionary.FirstOrDefault();
                foreach (var time in timeDictionary)
                {
                    if (time.Value < value.Value)
                    {
                        value = time;
                    }
                }
                timeDictionary.Remove(value.Key);
                Solve4.Children.Add(CreateLabel(String.Format("{0}. {1}. Время: {2}мс", i + 1, value.Key.Name, value.Value)));
            }
        }

        #endregion

        #region Show/Hide information

        private void ShowMessage(string message)
        {
            Message.Content = message;
            Message.Visibility = Visibility.Visible;
        }

        private void HideMessage()
        {
            Message.Visibility = Visibility.Collapsed;
        }

        private void ShowDeterminant(Solution sle)
        {
            Determinant.Content = "|A| = " + String.Format(accuracy, sle.determenantMatrixA);
            Determinant.Visibility = Visibility.Visible;
        }

        private void ResetView()
        {
            HideMessage();
            Determinant.Visibility = Visibility.Collapsed;
            Solve1.Visibility = Visibility.Collapsed;
            Solve2.Visibility = Visibility.Collapsed;
            Solve3.Visibility = Visibility.Collapsed;
            Solve4.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Solution methods of SLE

        private void SolveButton_OnClick(object sender, RoutedEventArgs e)
        {
            switch (SelectMethodComboBox.SelectedIndex)
            {
                case 0:
                    Solution(typeof(GaussSolution), CreateSolve1, CreateSolve2);
                    break;
                case 1:
                    Solution(typeof(GaussLeadingElementSolution), CreateSolve1, CreateSolve2);
                    break;
                case 2:
                    Solution(typeof(GaussJordanSolution), CreateSolve1, CreateSolve2);
                    break;
                case 3:
                    Solution(typeof(MatrixMethodSolution), CreateSolve3, CreateSolve2);
                    break;
                case 4:
                    CompareTime();
                    break;
            }
        }

        private Solution CreateSolution(Type type)
        {
            if (type == typeof (GaussSolution))
            {
                return new GaussSolution(ReadMatrixA(), ReadMatrixB(), Convert.ToDouble(EpsilonTextBox.Text));
            }
            if (type == typeof (GaussLeadingElementSolution))
            {
                return new GaussLeadingElementSolution(ReadMatrixA(), ReadMatrixB(), Convert.ToDouble(EpsilonTextBox.Text));
            }
            if (type == typeof(GaussJordanSolution))
            {
                return new GaussJordanSolution(ReadMatrixA(), ReadMatrixB(), Convert.ToDouble(EpsilonTextBox.Text));
            }
            if (type == typeof(MatrixMethodSolution))
            {
                return new MatrixMethodSolution(ReadMatrixA(), ReadMatrixB(), Convert.ToDouble(EpsilonTextBox.Text));
            }
            return null;
        }

        private void Solution(Type type, CreateSolve createFirstSolve, CreateSolve createSecondSolve)
        {
            var solution = CreateSolution(type);
            SetAccuracy();
            solution.epsilon = Convert.ToDouble(EpsilonTextBox.Text);
            ResetView();
            solution.Solve();
            ShowDeterminant(solution);
            if (solution.forwardTraceSolution != null)
            {
                createFirstSolve(solution.forwardTraceSolution);
            }

            SolutionType solutionType = solution.GetSolutionType();
            if ((solutionType == SolutionType.OneSolution) && (solution.solution != null))
            {
                createSecondSolve(solution);
            }
            else if (solutionType == SolutionType.NoSolution)
            {
                ShowMessage("Нет решений");
            }
            else if (solutionType == SolutionType.InfinitySolutions && (solution.solution != null))
            {
                ShowMessage("Бесконечное множество решений");
                createSecondSolve(solution);
            }
        }

        private void CompareTime()
        {
            var timeDictionary = new Dictionary<Type, long>();
            var types = new List<Type>
            {
                typeof (MatrixMethodSolution),
                typeof (GaussSolution),
                typeof (GaussLeadingElementSolution),
                typeof (GaussJordanSolution)
            };

            foreach (var type in types)
            {
                var solution = CreateSolution(type);
                solution.epsilon = Convert.ToDouble(EpsilonTextBox.Text);

                var stopwatch = new Stopwatch();
                stopwatch.Start();
                solution.Solve();
                stopwatch.Stop();

                timeDictionary.Add(type, stopwatch.ElapsedTicks);
            }

            CreateSolve4(timeDictionary);
        }
        #endregion

        
    }
}