using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MyUninstaller.UninstallerViews.ResidualFilesViews
{
    public class Node : INotifyPropertyChanged
    {
        public Node()
        {
            Id = Guid.NewGuid().ToString();
        }

        private string text;
        private bool? isChecked = true;
        private bool isExpanded;

        public ObservableCollection<Node> Children { get; } = new ObservableCollection<Node>();

        public Node Parent { get; set; } 

        public bool? IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                RaisePropertyChanged("Text");
            }
        }

        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                RaisePropertyChanged("IsExpanded");
            }
        }

        public string Id { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            int countCheck = 0;
            if (propertyName == "IsChecked")
            {
                if (Id == CheckBoxId.checkBoxId && Parent == null && this.Children.Count != 0)
                {
                    CheckedTreeParent(this.Children, this.IsChecked);
                }
                if (this.Id == CheckBoxId.checkBoxId && this.Parent != null && this.Children.Count > 0)
                {
                    CheckedTreeChildMiddle(this.Parent, this.Children, this.IsChecked);
                }
                if (this.Id == CheckBoxId.checkBoxId && this.Parent != null && this.Children.Count == 0)
                {
                    CheckedTreeChild(this.Parent, countCheck);
                }
            }
        }

        private void CheckedTreeChildMiddle(Node itemsParent, ObservableCollection<Node> itemsChild, bool? isChecked)
        {
            int countCheck = 0;
            CheckedTreeParent(itemsChild, isChecked);
            CheckedTreeChild(itemsParent, countCheck);
        }

        private void CheckedTreeParent(ObservableCollection<Node> items, bool? isChecked)
        {
            foreach (Node item in items)
            {
                item.IsChecked = isChecked;
                if (item.Children.Count != 0) CheckedTreeParent(item.Children, isChecked);
            }
        }

        private void CheckedTreeChild(Node paren, int countCheck)
        {
            bool isNull = false;
                foreach (Node child in paren.Children)
                {
                    if (child.IsChecked == true || child.IsChecked == null)
                    {
                        countCheck++;
                        if (child.IsChecked == null)
                            isNull = true;
                    }
                }
                if (countCheck != paren.Children.Count && countCheck != 0) paren.IsChecked = null;
                else if (countCheck == 0) paren.IsChecked = false;
                else if (countCheck == paren.Children.Count && isNull) paren.IsChecked = null;
                else if (countCheck == paren.Children.Count && !isNull) paren.IsChecked = true;
                if (paren.Parent != null) CheckedTreeChild(paren.Parent, 0);
        }

        public string GetNodeType()
        {
            Node node = Parent;
            while (node != null && node.Text != "Registry" && node.Text != "File system")
            {
                node = node.Parent;
            }
            return node?.Text;
        }

        private readonly List<Node> checkedItems = new List<Node>();

        public List<Node> GetCheckedNodes()
        {
            GetChecked(this);
            return checkedItems;
        }

        private void GetChecked(Node node)
        {
            if (node.IsChecked != false)
            {
                if (node.IsChecked == true)
                {
                    checkedItems.Add(node);
                }

                foreach (var child in node.Children)
                {
                    GetChecked(child);
                }
            }
        }
    }

    public struct CheckBoxId
    {
        public static string checkBoxId;
    }
}
