using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using BusinessLayer;
using BusinessLayer.Uninstaller;

namespace MyUninstaller.Controls
{
    /// <summary>
    /// Interaction logic for BaseUserControl.xaml
    /// </summary>
    public partial class BaseUserControl : UserControl
    {
        public event Action<bool> Refreshing;

        public  string FilterText { get; protected set; }

        public BaseUserControl()
        {
        }

        public void RefreshThread(ThreadStart threadStart)
        {
            var thread = new Thread(threadStart) { IsBackground = true };
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        protected bool UserFilter(object item)
        {
            return string.IsNullOrEmpty(FilterText) ||
                   (item as BaseApp).Name.IndexOf(FilterText, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        protected void RefreshControls(bool isSomething)
        {
            Refreshing?.Invoke(isSomething);
        }

        protected void SearchInListView(string pattern, ListView listView)
        {
            FilterText = pattern;
            CollectionViewSource.GetDefaultView(listView.ItemsSource).Refresh();
            listView.SelectedIndex = 0;
        }


        protected void ListView_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listview = sender as ListView;
            double width = listview.ActualWidth;
            GridView gv = listview.View as GridView;
            //0-ой столбец пропускаем, т.к. его будем растягивать
            for (int i = 1; i < gv.Columns.Count; i++)
            {
                width -= gv.Columns[i].Width;
            }
            width = width - 23;

            gv.Columns[0].Width = width >= 0 ? width : 0; 

        }

    }
}
