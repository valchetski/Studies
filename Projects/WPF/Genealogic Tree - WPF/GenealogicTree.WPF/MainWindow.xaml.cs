namespace GenealogicTree.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private void MainWindow_OnSizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            if (DetailsControl.Tree.TreeBorder.ActualWidth < DetailsControl.ColumnDefinition.ActualWidth)
            {
                DetailsControl.Tree.Width = DetailsControl.ColumnDefinition.ActualWidth;
            }
        }

    }

}
