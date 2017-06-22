using System.IO;
using System.Windows;
using System.Windows.Controls;
using BusinessLayer;
using BusinessLayer.Autorun;
using Microsoft.Win32;

namespace MyUninstaller.AutorunViews
{
    public partial class AddNewProgramWindow
    {
        private readonly bool isFromContextMenu;
        public AddNewProgramWindow()
        {
            InitializeComponent();
        }

        public AddNewProgramWindow(bool isFromContextMenu) : this()
        {
            this.isFromContextMenu = isFromContextMenu;
        }

        private void BrowseButton_OnClick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog {Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*"};
            if (fileDialog.ShowDialog() == true)
            {
                ExePathTextBox.Text = fileDialog.FileName;
            }

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = RegistryWork.GetNameExe(ExePathTextBox.Text);
            Autorun.AddProgramToAutorun(name, (AutorunTypeComboBox.SelectedItem as ComboBoxItem).Content.ToString(), ExePathTextBox.Text);
            if (isFromContextMenu)
            {
                MessageBox.Show("The program was added to autorun correctly");
            }
            Close();
        }

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ExePathTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            AddButton.IsEnabled = File.Exists(ExePathTextBox.Text);
        }
    }
}
