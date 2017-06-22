using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Lab3.Models.Helpers;
using Lab3.Models.Solver;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Lab3
{
    public partial class MainWindow : Window
    {
        private static int _size = 3;
        private static string _format = "{0:0.###}";
        private static double _accuracy = 0.0001;
        private static readonly DanilevskyMethodSolver DanilevskyMethodSolver = new DanilevskyMethodSolver();
        private static readonly JacobiMethoSolver JacobiMethoSolver = new JacobiMethoSolver();

        public MainWindow()
        {
            InitializeComponent();
            ResizeMatrix();
        }

        private void ChangedSizeMatrix(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            int value;
            if (int.TryParse(textBox.Text, out value))
            {
                if (_size == value)
                    return;

                _size = value;
                ResizeMatrix();
            }
        }

        private void ChangedFormat(object sender, RoutedEventArgs e)
        {
            var decimals = int.Parse((sender as TextBox).Text);
            _format = "{0:0.";
            for (int i = 0; i < decimals; i++)
                _format += "#";
            _format += "}";
        }

        private void ChangedAccuracy(object sender, RoutedEventArgs e)
        {
            var text = (sender as TextBox).Text;
            _accuracy = Double.Parse(text.Replace('.', ','));
        }

        private void GenerateMatrix(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            for (int y = 0; y < _size; y++)
            {
                for (int x = 0; x < _size; x++)
                    ((MatrixA.Children[x] as StackPanel).Children[y] as TextBox).Text = random.Next(-10, 10).ToString();
            }
        }

        private void GenerateSymmetricMatrix(object sender, RoutedEventArgs e)
        {
            var random = new Random();
            for (int y = 0; y < _size; y++)
            {
                for (int x = y; x < _size; x++)
                {
                    var value = random.Next(-10, 10).ToString();
                    ((MatrixA.Children[x] as StackPanel).Children[y] as TextBox).Text = value;
                    ((MatrixA.Children[y] as StackPanel).Children[x] as TextBox).Text = value;
                }
            }
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

        private void ResizeMatrix()
        {
            MatrixA.Children.Clear();

            for (int y = 0; y < _size; y++)
            {
                MatrixA.Children.Add(CreateStackPanel(24 * _size));
                for (int x = 0; x < _size; x++)
                {
                    (MatrixA.Children[y] as StackPanel).Children.Add(CreateTextBox());
                }
            }
        }

        private DenseMatrix ReadMatrixA()
        {
            var resultList = new List<double>();
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    var value = ((MatrixA.Children[x] as StackPanel).Children[y] as TextBox).Text.Replace('.', ',');
                    resultList.Add(double.Parse(value));
                }
            }
            return new DenseMatrix(_size, _size, resultList.ToArray());
        }

        private StackPanel MatrixToElement(DenseMatrix matrix)
        {
            var element = CreateStackPanel(24 * _size);
            element.Orientation = Orientation.Horizontal;
            for (int colIndex = 0; colIndex < matrix.ColumnCount; colIndex++)
            {
                element.Children.Add(CreateStackPanel(24 * _size));
                (element.Children[colIndex] as StackPanel).Margin = new Thickness(0, 0, 5, 0);
                for (int rowIndex = 0; rowIndex < _size; rowIndex++)
                {
                    (element.Children[colIndex] as StackPanel).Children.Add(CreateLabel(matrix[rowIndex, colIndex].StringFormat(_format)));
                }
            }
            return element;
        }

        private StackPanel VectorToElement(DenseVector vector)
        {
            var element = CreateStackPanel(24 * _size);
            for (int rowIndex = 0; rowIndex < _size; rowIndex++)
            {
                element.Children.Add(CreateLabel(vector[rowIndex].StringFormat(_format)));
            }
            return element;
        }

        private void WritePoly(DenseMatrix matrix)
        {
            Poly.Visibility = Visibility.Visible;
            var minus = matrix.RowCount%2 != 0;

            Poly.Content = minus ? "-L^" + matrix.RowCount : "L ^" + matrix.RowCount;

            for (var i = 0; i < matrix.RowCount; i++)
            {
                if (matrix[0, i].IsZero())
                    continue;

                var value = matrix[0, i] * -1;
                if (minus)
                    value *= -1;

                Poly.Content += value.ToString("+#;-#;0");

                if (matrix.RowCount - i - 1 != 0)
                    Poly.Content += "*L^" + (matrix.RowCount - i - 1) + " ";
            }

            Poly.Content += " = 0";
        }

        private void HidePoly()
        {
            Poly.Visibility = Visibility.Collapsed;
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

        private void ShowIteration(int iteration)
        {
            IterationReport.Content = "Количество итераций: " + iteration;
            IterationReport.Visibility = Visibility.Visible;
        }

        private void HideIteration()
        {
            IterationReport.Visibility = Visibility.Collapsed;
        }

        private void SetSolverTitle(string title)
        {
            SolutionHeader.Header = title;
        }

        private void ShowResult(IList<double> eigenvalues, IList<DenseVector> eigenvectors, IList<DenseMatrix> matrixAList,
            string title = "Ответ", string message = null)
        {
            HideResult();

            if (message != null)
                ShowMessage(message);
            else
                HideMessage();

            SetSolverTitle(title);

            var eigenValuesContent = new StringBuilder("Собственные значения: ");
            foreach (var value in eigenvalues)
            {
                eigenValuesContent.Append(value.StringFormat(_format) + ",   ");
            }
            eigenValuesContent = eigenValuesContent.Remove(eigenValuesContent.Length - 4, 4);
            EigenValues.Visibility = Visibility.Visible;
            EigenValues.Content = eigenValuesContent.ToString();

            if (eigenvectors != null && eigenvectors.Any())
            {
                EigenVectors.Children.Clear();
                EigenVectors.Visibility = Visibility.Visible;
                EigenVectorsTitle.Visibility = Visibility.Visible;
                foreach (var vector in eigenvectors)
                {
                    var elem = VectorToElement(vector);
                    elem.Margin = new Thickness(0, 0, 20, 0);
                    EigenVectors.Children.Add(elem);
                }
            }

            if (matrixAList != null && matrixAList.Any())
            {
                WritePoly(matrixAList.Last());

                if (matrixAList.Count > 1)
                {
                    MatrixAList.Children.Clear();
                    MatrixAList.Visibility = Visibility.Visible;
                    MatrixAListTitle.Visibility = Visibility.Visible;
                    int i = 1;
                    foreach (var matrix in matrixAList)
                    {
                        var titleElem = new Label { Content = "A(" + i.ToString() + ")" };
                        MatrixAList.Children.Add(titleElem);

                        var elem = MatrixToElement(matrix);
                        elem.Margin = new Thickness(0, 0, 0, 20);
                        MatrixAList.Children.Add(elem);
                        i++;
                    }  
                }
            }
        }

        private void HideResult()
        {
            EigenValues.Visibility = Visibility.Collapsed;
            EigenVectors.Visibility = Visibility.Collapsed;
            MatrixAList.Visibility = Visibility.Collapsed;

            EigenVectorsTitle.Visibility = Visibility.Collapsed;
            MatrixAListTitle.Visibility = Visibility.Collapsed;
            HidePoly();
        }

        private void DanilevskyMethodOnClick(object sender, RoutedEventArgs e)
        {
            var matrixA = ReadMatrixA();
            IList<DenseMatrix> matrixAList;
            IList<double> eigenvalues;
            
            var eigenvectors = DanilevskyMethodSolver.Solve(matrixA, out matrixAList, out eigenvalues);
            ShowResult(eigenvalues, eigenvectors, matrixAList, "Ответ (метод Данилевского)");
            HideIteration();
        }

        private void JacobiMethodOnClick(object sender, RoutedEventArgs e)
        {
            var matrixA = ReadMatrixA();
            IList<DenseMatrix> matrixAList;
            IList<double> eigenvalues;
            int iteration;

            try
            {
                var eigenvectors = JacobiMethoSolver.Solve(matrixA, _accuracy, out matrixAList, out eigenvalues, out iteration);
                ShowResult(eigenvalues, eigenvectors, matrixAList, "Ответ (метод вращения Якоби)");
                ShowIteration(iteration);
            }
            catch (Exception)
            {
                HideResult();
                SetSolverTitle("Ответ (метод вращения Якоби)");
                ShowMessage("Матрица не симметрична");
            }

        }
    }
}
