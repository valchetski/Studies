using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using BusinessLayer;
using BusinessLayer.Uninstaller;
using MyUninstaller.Controls;
using MyUninstaller.UninstallerViews.ResidualFilesViews;

namespace MyUninstaller.UninstallerViews
{
    /// <summary>
    /// Interaction logic for Uninstaller.xaml
    /// </summary>
    public partial class UninstallerControl : BaseUserControl
    {

        public UninstallerControl()
        {
            InitializeComponent();
        }

        public void Refresh()
        {
            RefreshThread(FillProgramsListView);

        }

        private void FillProgramsListView()
        {
            Dispatcher.Invoke(() => { RefreshControls(true); });
            var programs = Uninstaller.GetAllPrograms().Where(p => p.IsSystemComponent == false).ToList();
            Dispatcher.Invoke(() =>
            {
                //костыль!!
                SizeStringConverter s = new SizeStringConverter();
                TotalSizeTextBlock.Text = s.Convert(programs.Sum(p => p.Size), typeof(string), null, null).ToString();

                int selectedIndex = programsListView.SelectedIndex != -1 ? programsListView.SelectedIndex : 0;
                programsListView.ItemsSource = null;
                programsListView.Items.Clear();
                programsListView.ItemsSource = programs;
                programsListView.SelectedIndex = selectedIndex < programsListView.Items.Count ? selectedIndex : 0;

                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(programsListView.ItemsSource);
                view.Filter = UserFilter;

                RefreshControls(false);
            });
        }


        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (programsListView.SelectedItem != null)
            {
                var uninstallPath = RegistryWork.ExtractPath(((InstalledApp)programsListView.SelectedItem).UninstallString);

                string fileName = uninstallPath, arguments = "";
                if (uninstallPath.ToLower().Contains("msiexec.exe"))
                {
                    var a = uninstallPath.Split(' ');
                    fileName = a[0];
                    arguments = a[1];
                }

                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = fileName,
                        Arguments = arguments
                    }
                };
                process.Start();
                int id = process.Id;
                process.WaitForExit();
                int exitCode = process.ExitCode;
                int exitCode1 = WaitChildProcesses(id);

                if (IsDeleted(fileName, exitCode, exitCode1))
                {
                    FindResidualFiles();
                    Refresh();
                }
            }
        }

        public int WaitChildProcesses(int processId)
        {
            int exitCode = 0;
            ManagementObjectSearcher mos = new ManagementObjectSearcher(String.Format("Select * From Win32_Process Where ParentProcessID={0}", processId));

            foreach (ManagementObject mo in mos.Get())
            {
                var p = Process.GetProcessById(Convert.ToInt32(mo["ProcessID"]));
                p.EnableRaisingEvents = true;
                p.Exited += (s, e) => {
                    var process = s as Process;
                    if (process != null)
                    {
                        exitCode = process.ExitCode;
                    }
                };
                p.WaitForExit();
            }
            return exitCode;
        }

        private bool IsDeleted(string fileName, int exitCode, int exitCode1)
        {
            if (fileName.ToLower().Contains("msiexec.exe"))
            {
                return exitCode == 0 && exitCode1 == 0;
            }
            else
            {
                return File.Exists(fileName) == false;
            }
        }
        

        private void programsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            var selectedProgram = listView.SelectedItem as InstalledApp;

            if (selectedProgram != null)
            {
                ProgramNameTextBlock.Text = selectedProgram.Name;
                VersionLabel.Content = selectedProgram.Version;
                PublisherLabel.Content = selectedProgram.Publisher;
                LocationTextBlock.Text = Directory.Exists(selectedProgram.Location) ? selectedProgram.Location : "";
            }
        }


        private void ProgramsListViewHeader_OnClick(object sender, RoutedEventArgs e)
        {
            SortColumn(sender as GridViewColumnHeader);
        }

        public void SortColumn(GridViewColumnHeader columnHeader)
        {
            GridViewColumnHeader column = columnHeader;
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                programsListView.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            programsListView.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        GridViewColumnHeader listViewSortCol;
        SortAdorner listViewSortAdorner;


        public class SortAdorner : Adorner
        {
            private static Geometry ascGeometry =
                    Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                    Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                    : base(element)
            {
                Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                        (
                                AdornedElement.RenderSize.Width - 15,
                                (AdornedElement.RenderSize.Height - 5) / 2
                        );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var i = programsListView.Width;
            var b = programsListView.ActualWidth;
        }

        private void FindResidualFiles()
        {
            FindResidualFiles f = new FindResidualFiles(programsListView.SelectedItem as InstalledApp);
            f.ShowDialog();
        }


        private void LocationHyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            string path = LocationTextBlock.Text;
            if (Directory.Exists(path))
            {
                Process.Start(path);
            }
        }


        public void Search(string pattern)
        {
            SearchInListView(pattern, programsListView);
        }
    }
}
