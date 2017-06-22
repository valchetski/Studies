using System.Windows.Input;
using System.Windows.Media;

namespace GenealogicTree.WPF.Tree
{
    /// <summary>
    /// Interaction logic for Vertex.xaml
    /// </summary>
    public partial class Vertex
    {
        private static Brush checkColor;

        public bool IsChecked
        {
            get
            {
                return (Equals(VertexRectangle.Stroke, checkColor));
            }
            set
            {
                if (value)
                {
                   Check();
                }
                else
                {
                    Uncheck();
                }
            }
        }
        public Vertex()
        {
            InitializeComponent();
            checkColor = Brushes.Green;
            Width = 100;
            Height = 50;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Check();
        }

        private void Check()
        {
            VertexRectangle.Stroke = checkColor;
            VertexRectangle.StrokeThickness = 2;
        }

        private void Uncheck()
        {
            VertexRectangle.Stroke = null;
            VertexRectangle.StrokeThickness = 0;
        }
    }
}
