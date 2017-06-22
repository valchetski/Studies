using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using BusinessLayer;
using BusinessLayer.Autorun;
using Microsoft.Win32;
using MyUninstaller.AutorunViews;

namespace MyUninstaller
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            UninstallerControl.Refreshing += WaitItemVisibilityChange;
            UninstallerControl.Refresh();
            AutorunControl.Refresh();

            AddToContextMenu();
            StartedFromContextMenu();

            MainWindow_OnSizeChanged(null, null);
        }

        private void WaitItemVisibilityChange(bool isVisible)
        {
            UninstallerTabItem.IsSelected = !isVisible;
            RefreshButton.IsEnabled = !isVisible;
            SearchTextBox.IsReadOnly = isVisible;
            WaitTabItem.IsSelected = isVisible;

            if (AutorunControl.DidRefreshingSet == false)
            {
                AutorunControl.Refreshing += WaitItemVisibilityChange1;
                AutorunControl.DidRefreshingSet = true;
            }
        }

        private void WaitItemVisibilityChange1(bool isVisible)
        {
            AutorunTabItem.IsSelected = !isVisible;
            RefreshButton.IsEnabled = !isVisible;
            SearchTextBox.IsReadOnly = isVisible;
            WaitTabItem.IsSelected = isVisible;
        }

        private void StartedFromContextMenu()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string path = args[1];
                string commandType = args[2];
                switch (commandType)
                {
                    case "add":
                        var addNewProgramWindow = new AddNewProgramWindow(true) { ExePathTextBox = { Text = path } };
                        addNewProgramWindow.ShowDialog();
                        break;
                    case "remove":
                        string name = RegistryWork.GetNameExe(path);
                        bool? result = Autorun.RemoveProgramFromAutorun(name);
                        if (result == true)
                        {
                            MessageBox.Show("The program was removed from autorun successfully");
                        }
                        else if (result == null)
                        {
                            MessageBox.Show("The program wasn't be in autorun");
                        }
                        break;
                }
                
                Environment.Exit(0);
            }
        }

        private void AddToContextMenu()
        {
            string pathToExe = Assembly.GetExecutingAssembly().Location;
            const string addToAutorunMenu = "exefile\\shell\\addToAutorun";
            const string removeFromAutorunMenu = "exefile\\shell\\removeFromAutorun";
            const string command1 = addToAutorunMenu + "\\command";
            const string command2 = removeFromAutorunMenu + "\\command";
            RegistryKey regmenu = null;
            RegistryKey regcmd = null;
            try
            {
                regmenu = Registry.ClassesRoot.CreateSubKey(addToAutorunMenu);
                regmenu?.SetValue("", "Add to autorun");

                regcmd = Registry.ClassesRoot.CreateSubKey(command1);
                regcmd?.SetValue("", $"\"{pathToExe}\" \"%1\" \"add\"");



                regmenu = Registry.ClassesRoot.CreateSubKey(removeFromAutorunMenu);
                regmenu?.SetValue("", "Remove from autorun");

                regcmd = Registry.ClassesRoot.CreateSubKey(command2);
                regcmd?.SetValue("", $"\"{pathToExe}\" \"%1\" \"remove\"");
            }
            catch (Exception)
            {
                
            }
            finally
            {
                if (regmenu != null)
                    regmenu.Close();
                if (regcmd != null)
                    regcmd.Close();
            }
        }

        private void UninstallerButton_OnClick(object sender, RoutedEventArgs e)
        {
            UninstallerTabItem.IsSelected = true;
        }

        private void AutoRunButton_OnClick(object sender, RoutedEventArgs e)
        {
            AutorunTabItem.IsSelected = true;
        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (UninstallerTabItem.IsSelected)
            {
                UninstallerControl.Refresh();
            }
            else if (AutorunTabItem.IsSelected)
            {
                AutorunControl.Refresh();
            }
        }

        private void SearchTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (UninstallerTabItem.IsSelected)
            {
                UninstallerControl.Search(SearchTextBox.Text);
            }
            else if (AutorunTabItem.IsSelected)
            {
                AutorunControl.Search(SearchTextBox.Text);
            }
        }

        private void ButtonsToolBar_OnLoaded(object sender, RoutedEventArgs e)
        {
            ToolBar toolBar = sender as ToolBar;
            var overflowGrid = toolBar.Template.FindName("OverflowGrid", toolBar) as FrameworkElement;
            if (overflowGrid != null)
            {
                overflowGrid.Visibility = Visibility.Collapsed;
            }

            var mainPanelBorder = toolBar.Template.FindName("MainPanelBorder", toolBar) as FrameworkElement;
            if (mainPanelBorder != null)
            {
                mainPanelBorder.Margin = new Thickness(0);
            }
        }

        private void TabControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            var selectionColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#AFEEEE"));
            var nonSelectionColor = FindResource(ToolBar.ButtonStyleKey) as Brush;
            switch (tabControl.SelectedIndex)
            {
                case 0:
                    UninstallerButton.Background = selectionColor;
                    AutoRunButton.Background = nonSelectionColor;
                    break;
                case 1:
                    UninstallerButton.Background = nonSelectionColor;
                    AutoRunButton.Background = selectionColor;
                    break;
            }
            
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {

        }

        private void MainWindow_OnContentRendered(object sender, EventArgs e)
        {

        }

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
        }
    }
}
