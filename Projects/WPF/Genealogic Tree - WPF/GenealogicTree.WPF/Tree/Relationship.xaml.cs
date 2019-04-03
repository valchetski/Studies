using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GenealogicTree.WPF.Tree
{
    /// <summary>
    /// Interaction logic for Relationship.xaml
    /// </summary>
    public partial class Relationship : UserControl
    {
        public  Vertex firstVertex;
        public  Vertex secondVertex;
        
        public Relationship(Vertex firstVertex, Vertex secondVertex)
        {
            InitializeComponent();
            this.firstVertex = firstVertex;
            this.secondVertex = secondVertex;
        }
    }
}
