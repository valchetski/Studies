using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyUninstaller.Controls
{
    /// <summary>
    /// Interaction logic for myButton.xaml
    /// </summary>
    public partial class ToolBarButton : Button
    {
        public ImageSource ImageSource
        {
            get { return Image.Source; }
            set { Image.Source = value; }
        }

        public string Text
        {
            get { return TextBlock.Text; }
            set { TextBlock.Text = value; }
        }
        public ToolBarButton()
        {
            InitializeComponent();
        }
    }
}
