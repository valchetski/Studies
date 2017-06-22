using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BusinessLayer.Autorun;
using BusinessLayer.Uninstaller;
using MyUninstaller.Controls;

namespace MyUninstaller.AutorunViews
{
    /// <summary>
    /// Interaction logic for AutorunControl.xaml
    /// </summary>
    public partial class AutorunControl : BaseUserControl
    {
        public bool DidRefreshingSet { get; set; }
        public AutorunControl() 
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            RefreshThread(FillAutorunProgramsListView);
        }

        private void FillAutorunProgramsListView()
        {
            Dispatcher.Invoke(() => { RefreshControls(true); });
            var programs = Autorun.GetAllAutorunApps();
            Dispatcher.Invoke(() =>
            {
                int selectedIndex = AutorunProgramsListView.SelectedIndex != -1 ? AutorunProgramsListView.SelectedIndex : 0;
                AutorunProgramsListView.ItemsSource = null;
                AutorunProgramsListView.Items.Clear();
                AutorunProgramsListView.ItemsSource = programs;
                AutorunProgramsListView.SelectedIndex = selectedIndex < AutorunProgramsListView.Items.Count ? selectedIndex : 0;

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(AutorunProgramsListView.ItemsSource);
                view.Filter = UserFilter;

                RefreshControls(false);
            });

            
        }

        private void AutorunProgramsListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            var selectedProgram = listView.SelectedItem as AutorunApp;

            if (selectedProgram != null)
            {
                AutorunProgramNameLabel.Content = selectedProgram.Name;

                DisableButtonTextBlock.Text = selectedProgram.Status != Status.Disabled ? "Disable" : "Enable";
            }
        }

        private void AddProgramButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddNewProgramWindow addNewProgramWindow = new AddNewProgramWindow();
            addNewProgramWindow.ShowDialog();
            Refresh();
        }

        private void DisableButton_OnClick(object sender, RoutedEventArgs e)
        {
            var program = AutorunProgramsListView.SelectedItem as AutorunApp;
            if (DisableButtonTextBlock.Text == "Disable")
            {
                Autorun.RemoveProgramFromAutorun(program);
            }
            else
            {
                Autorun.RemoveProgramFromEverywhere(program);
                Autorun.AddProgramToAutorun(program.RegistryValueName, program.SourceType, program.ExePath);
            }
            
            Refresh();
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var program = AutorunProgramsListView.SelectedItem as AutorunApp;
            Autorun.RemoveProgramFromEverywhere(program);
            Refresh();
        }

        public void Search(string pattern)
        {
            SearchInListView(pattern, AutorunProgramsListView);
        }
    }
}
