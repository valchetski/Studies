using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BusinessLayer;
using BusinessLayer.Uninstaller;
using Microsoft.Win32;

namespace MyUninstaller.UninstallerViews.ResidualFilesViews
{
    public partial class FindResidualFiles
    {
        private readonly InstalledApp installedApp;
        public FindResidualFiles(InstalledApp installedApp)
        {
            InitializeComponent();

            this.installedApp = installedApp;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CheckBox currentCheckBox = (CheckBox)sender;
            CheckBoxId.checkBoxId = currentCheckBox.Uid;
        }

        private void FindResidualFiles_OnContentRendered(object sender, EventArgs e)
        {
            var thread = new Thread(FillTreeView) {IsBackground = true};
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void FillTreeView()
        {
            Dictionary<RegistryKey, string> residualRegistryEntries =
                ResidualFiles.FindResidualFilesRegistry(installedApp);
            List<DirectoryInfo> residualFiles = ResidualFiles.FindResidualFiles(installedApp);

            if (residualFiles.Count > 0)
            {
                Dispatcher.Invoke(() => { OutputTabItem.IsSelected = true; });

                Node level1Item = null;
                if (residualRegistryEntries.Count != 0 && residualFiles.Count != 0)
                {
                    level1Item = new Node() {Text = "All"};
                    AddChild(level1Item, GetNode(residualRegistryEntries));
                    AddChild(level1Item, GetNode(residualFiles));
                }
                else if (residualRegistryEntries.Count != 0)
                {
                    level1Item = GetNode(residualRegistryEntries);
                }
                else if (residualFiles.Count != 0)
                {
                    level1Item = GetNode(residualFiles);
                }

                var nodes = new ObservableCollection<Node> {level1Item};
                ExpandTree(nodes, 2, true);
                Dispatcher.Invoke(() => { ResidualFilesTreeView.ItemsSource = nodes; });
            }
            else
            {
                Dispatcher.Invoke(() => { SelectResultTabItem(true); });
            }
            
        }

        private void ExpandTree(ObservableCollection<Node> nodes, int deep, bool isExpanded)
        {
            foreach (Node item in nodes)
            {
                if (item != null && item.Children.Count != 0 && deep > 0)
                {
                    item.IsExpanded = isExpanded;
                    ExpandTree(item.Children, deep - 1, isExpanded);
                }
            }
        }

        private Node GetNode(Dictionary<RegistryKey, string> residualRegistryEntries)
        {
            Node level1Item = null;
            if (residualRegistryEntries.Count != 0)
            {
                level1Item = new Node() { Text = "Registry" };
                foreach (var entry in residualRegistryEntries)
                {
                    var level2Items = new Node() { Text = entry.Key.Name };
                    AddChild(level1Item, level2Items);
                    //that means we want to remove all key
                    if (entry.Value == null)
                    {
                        foreach (var valueName in entry.Key.GetValueNames())
                        {
                            var level3Items = new Node() { Text = valueName + " [" + entry.Key.GetValue(valueName) + "]" };
                            AddChild(level2Items, level3Items);
                        }
                    }
                    else
                    {
                        var level3Items = new Node() { Text = entry.Value };
                        AddChild(level2Items, level3Items);
                    }
                }
            }
            return level1Item;
        }

        private Node GetNode(List<DirectoryInfo> residualFiles)
        {
            Node level1Item = null;
            if (residualFiles.Count != 0)
            {
                level1Item = new Node() { Text = "File system" };
                foreach (var directory in residualFiles)
                {
                    GetFilesRecursive(directory, level1Item);
                }
            }
            return level1Item;
        }

        private void GetFilesRecursive(DirectoryInfo directory, Node parent)
        {
            var newParent = new Node() { Text = directory.FullName };
            AddChild(parent, newParent);

            foreach (var dir in directory.GetDirectories())
            {
                GetFilesRecursive(dir, newParent);
            }
            
            foreach (var file in directory.GetFiles())
            {
                var child = new Node() { Text = file.Name };
                AddChild(newParent, child);
            }
            
        }


        private void AddChild(Node parent, Node child)
        {
            if (child != null)
            {
                parent.Children.Add(child);
                child.Parent = parent;
            }
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
        {
            WaitTabItem.IsSelected = true;

            bool isRemoveComplete = true;

            var checkedItems = new List<Node>();
            foreach (var item in ResidualFilesTreeView.ItemsSource)
            {
                checkedItems.AddRange(((Node)item).GetCheckedNodes());
            }

            foreach (var checkedItem in checkedItems)
            {
                string type = checkedItem.GetNodeType();
                switch (type)
                {
                    case "Registry":
                        RemoveKey(checkedItem);
                        break;
                    case "File system":
                        string path = GetPath(checkedItem);
                        try
                        {
                            if (File.Exists(path))
                            {
                                File.Delete(path);
                            }
                            else if (Directory.Exists(path))
                            {
                                Directory.Delete(path);
                            }
                        }
                        catch (IOException)
                        {
                            //ошибку выдает, но файл удаляет. It's a kind of maaaagic!
                            isRemoveComplete = true;
                        }
                        catch (UnauthorizedAccessException)
                        {
                            isRemoveComplete = false;
                        }
                        break;
                }
            }

            SelectResultTabItem(isRemoveComplete);
        }

        private void SelectResultTabItem(bool isRemoveComplete)
        {
            ResultTextBlock.Text = isRemoveComplete ?
                "All selected files deleted correctly" :
                "There was error when you have tried to remove selected files." +
                   "\nMaybe you don't have any access rights to this file";
            ResultTabItem.IsSelected = true;
        }

        private void RemoveKey(Node node)
        {
            if (node.Text.Contains("["))
            {
                var keyName = node.Parent.Text;
                var elements = node.Text.Split('[', ']');
                var valueName = elements[0].Trim();
                var value = elements[1].Trim();

                RegistryWork.Remove(keyName, valueName, value);
            }
        }

        private string GetPath(Node node)
        {
            string path = "";
            while (node != null && File.Exists(path) == false && Directory.Exists(path) == false)
            {
                path = node.Text + (path != "" ? "\\" : "") + path;
                node = node.Parent;
            }
            return path;
        }
    }
}
