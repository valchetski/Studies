using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using GenealogicTree.BusinessLayer;
using GenealogicTree.Entities;
using Microsoft.Win32;

namespace GenealogicTree.WPF
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details
    {
        public Details()
        {
            InitializeComponent();
                
            AddNewPersonCombobox.Items.Add("папу");
            AddNewPersonCombobox.Items.Add("маму");
            AddNewPersonCombobox.Items.Add("брата");
            AddNewPersonCombobox.Items.Add("сестру");
            AddNewPersonCombobox.Items.Add("мужа");
            AddNewPersonCombobox.Items.Add("жену");
            AddNewPersonCombobox.SelectedIndex = 0;

            AddMonthsInCombobox(MonthsComboBox);
            AddMonthsInCombobox(MonthsDeadComboBox);
            AddMonthsInCombobox(MonthsEditComboBox);
            AddMonthsInCombobox(MonthsDeadEditComboBox);

            AliveOrDead();

            AddStackPanel.DataContext = new Person();

            Replace();
            AdvancedSearchBorder.Visibility = Visibility.Collapsed;
        }

        private void AddMonthsInCombobox(ComboBox comboBox)
        {
            comboBox.Items.Add("Январь");
            comboBox.Items.Add("Февраль");
            comboBox.Items.Add("Март");
            comboBox.Items.Add("Апрель");
            comboBox.Items.Add("Май");
            comboBox.Items.Add("Июнь");
            comboBox.Items.Add("Июль");
            comboBox.Items.Add("Август");
            comboBox.Items.Add("Сентябрь");
            comboBox.Items.Add("Октябрь");
            comboBox.Items.Add("Ноябрь");
            comboBox.Items.Add("Декабрь");
        }

        private void Replace()
        {
            NewPerson.Visibility = Visibility.Collapsed;
            Edit.Visibility = Visibility.Collapsed;
            CurrentPerson.Visibility = Visibility.Visible;
            ButtonsStackPanel.Visibility = Visibility.Visible;
            AddNewPersonCombobox.SelectedIndex = 0;
            DaysDeadEditComboBox.SelectedIndex = 0;
            DaysEditComboBox.SelectedIndex = 0;
            DaysOfMonthComboBox.SelectedIndex = 0;
            DaysOfMonthDeadComboBox.SelectedIndex = 0;
            MonthsComboBox.SelectedIndex = 0;
            MonthsDeadComboBox.SelectedIndex = 0;
            MonthsEditComboBox.SelectedIndex = 0;
            MonthsDeadEditComboBox.SelectedIndex = 0;
            YearTextBox.Text = "";
            YearEditTextBox.Text = "";
            YearDeadTextBox.Text = "";
            YearDeadEditTextBox.Text = "";
        }

        private void AddNewPersonCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddNewPerson.Content = String.Format("Добавить {0}", AddNewPersonCombobox.SelectedItem);
            if (IsLoaded)
            {
                ShowAddUserControl();
            }
        }

        private void AddNewPerson_Click(object sender, RoutedEventArgs e)
        {
            ShowAddUserControl();
        }

        private void ShowAddUserControl()
        {
            CurrentPerson.Visibility = Visibility.Collapsed;
            ButtonsStackPanel.Visibility = Visibility.Collapsed;
            Edit.Visibility = Visibility.Collapsed;
            NewPerson.Visibility = Visibility.Visible;
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPerson.Visibility = Visibility.Collapsed;
            ButtonsStackPanel.Visibility = Visibility.Collapsed;
            NewPerson.Visibility = Visibility.Collapsed;
            Edit.Visibility = Visibility.Visible;

            var person = (Person) CurrentPersonStackPanel.DataContext;
            EditStackPanel.DataContext = person;
            PhotoNameEditTextBlock.Text = person.Photo != "noPhoto.gif" ? person.Photo : null;

            DaysEditComboBox.SelectedIndex = person.BirthDay != null ? person.BirthDay.Value.Day - 1 : 0;
            MonthsEditComboBox.SelectedIndex = person.BirthDay != null ? person.BirthDay.Value.Month - 1 : 0;
            YearEditTextBox.Text = person.BirthDay != null ? Convert.ToString(person.BirthDay.Value.Year) : "";

            DaysDeadEditComboBox.SelectedIndex = person.DeadDay != null ? person.DeadDay.Value.Day - 1 : 0;
            MonthsDeadEditComboBox.SelectedIndex = person.DeadDay != null ? person.DeadDay.Value.Month - 1 : 0;
            YearDeadEditTextBox.Text = person.DeadDay != null ? Convert.ToString(person.DeadDay.Value.Year) : "";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var person = (Person)AddStackPanel.DataContext;
            person.Photo = PhotoNameTextBlock.Text;

            int year;
            if (int.TryParse(YearTextBox.Text, out year))
            {
                person.BirthDay =
                    new DateTime(Convert.ToInt32(YearTextBox.Text), Convert.ToInt32(MonthsComboBox.SelectedIndex) + 1,
                        Convert.ToInt32(DaysOfMonthComboBox.SelectedItem));
            }

            if ((IsAliveCheckBox.IsChecked == false) && (int.TryParse(YearDeadTextBox.Text, out year)))
            {
                person.DeadDay =
                    new DateTime(Convert.ToInt32(YearDeadTextBox.Text),
                        Convert.ToInt32(MonthsDeadComboBox.SelectedIndex) + 1,
                        Convert.ToInt32(DaysOfMonthDeadComboBox.SelectedItem));
                if ((person.BirthDay != null) && (person.BirthDay > person.DeadDay))
                {
                    person.DeadDay = null;
                    MessageBox.Show("Год смерти не может быть раньше года рождения\n" +
                                    "Если не знаете года смерти--оставьте поле пустым", "Ошибка при вводе даты");
                    return;
                }
            }
            else
            {
                person.DeadDay = null;
            }
            BusinessComponent.Add(person);

            var relative = new Relative
            {
                PersonId = ((Person) CurrentPersonStackPanel.DataContext).Id,
                RelativeOfPersonId = person.Id,
                KindOfRelative = ConvertTo.String(ConvertTo.KindOfRelative((string) AddNewPersonCombobox.SelectedItem))
            };

            AddStackPanel.DataContext = new Person();
            
            Replace();

            string resultOfAdd = BusinessComponent.Add(relative);
            if (resultOfAdd != null)
            {
                MessageBox.Show(resultOfAdd, "Ошибка при добавлении родственника");
                return;
            }
            Tree.AddNewFamilyMember(person, ConvertTo.KindOfRelative(relative.KindOfRelative));
            AllPersonDataGrid.ItemsSource = BusinessComponent.GetAll();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPersonStackPanel.DataContext = AllPersonDataGrid.SelectedItem;
            AddStackPanel.DataContext = new Person();
            Replace();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var person = (Person) EditStackPanel.DataContext;
            int year;
            if (int.TryParse(YearEditTextBox.Text, out year))
            {
                person.BirthDay =
                    new DateTime(Convert.ToInt32(YearEditTextBox.Text),
                        Convert.ToInt32(MonthsEditComboBox.SelectedIndex) + 1,
                        Convert.ToInt32(DaysEditComboBox.SelectedItem));
            }
            
            person.DeadDay = null;
            if (int.TryParse(YearDeadEditTextBox.Text, out year))
            {
                person.DeadDay =
                    new DateTime(Convert.ToInt32(YearDeadEditTextBox.Text),
                        Convert.ToInt32(MonthsDeadEditComboBox.SelectedIndex) + 1,
                        Convert.ToInt32(DaysDeadEditComboBox.SelectedItem));
                if ((person.BirthDay != null) && (person.BirthDay > person.DeadDay))
                {
                    person.DeadDay = null;
                    MessageBox.Show("Год смерти не может быть раньше года рождения\n" +
                                    "Если не знаете года смерти--оставьте поле пустым", "Ошибка при вводе даты");
                    return;
                }
            }

            Replace();

            BusinessComponent.Update(person);
            Tree.UpdateFamilyMember(person);
            AllPersonDataGrid.ItemsSource = BusinessComponent.GetAll();
        }

        private void CancelFromEditButton_Click(object sender, RoutedEventArgs e)
        {
            Replace();
        }

        private void IsAliveCheckBox_Click(object sender, RoutedEventArgs e)
        {
            AliveOrDead();
        }

        private void AliveOrDead()
        {
            if (IsAliveCheckBox.IsChecked == true)
            {
                AddDeadDayStackPanel.Visibility = Visibility.Collapsed;
                InputDeadDateLabel.Visibility = Visibility.Collapsed;
            }
            else
            {
                AddDeadDayStackPanel.Visibility = Visibility.Visible;
                InputDeadDateLabel.Visibility = Visibility.Visible;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DrawMyRelatives();
            AllPersonDataGrid.ItemsSource = BusinessComponent.GetAll();
        }


        public void DrawMyRelatives()
        {
            var me = BusinessComponent.SearchMe();
            if(me != null)
            {
                DrawAllRelatives(me);
            }
        }

        private void DrawAllRelatives(Person person)
        {
            var queue = new Queue<Person>();
            queue.Enqueue(person);
            //в этом списке будет храниться каждый родственник
            var visitedPoints = new List<Person> { person }; //добавляю себя туда

            Tree.AddNewFamilyMember(person, KindOfRelative.Me);

            Person point;
            Dictionary<Person, KindOfRelative> immediateRelatives;
            var allRelatives = new Dictionary<Person, List<KindOfRelative>>();
            var addingRelatives = new Dictionary<Person, List<KindOfRelative>>();
            var relationsList = new List<KindOfRelative>();
            Person relative;
            while (queue.Count > 0)//здесь получаем с помощью обхода графа в ширину путь каждом родственнику
            {
                point = queue.Dequeue();
                Tree.Check(point);
                immediateRelatives = BusinessComponent.GetImmediateRelatives(point.Id);
                foreach (var immediateRelative in immediateRelatives)
                {
                    relative = immediateRelative.Key;
                    queue.Enqueue(relative);
                    visitedPoints.Add(relative);
                    relationsList.Add(immediateRelative.Value);
                    if (allRelatives.ContainsKey(point))
                    {
                        var list = allRelatives[point];
                        relationsList.AddRange(list);
                    }
                    allRelatives.Add(relative, relationsList);
                    addingRelatives.Add(relative, relationsList);
                    relationsList = new List<KindOfRelative>();
                }
                Tree.AddNewFamilyMembers(addingRelatives);
                addingRelatives = new Dictionary<Person, List<KindOfRelative>>();
            }
        }

        private void MonthsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeDaysInMonthComboBox(DaysOfMonthComboBox, MonthsComboBox, YearTextBox);
        }

        private void MonthsDeadComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           ChangeDaysInMonthComboBox(DaysOfMonthDeadComboBox, MonthsDeadComboBox, YearDeadTextBox);
        }

        private void MonthsEditComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeDaysInMonthComboBox(DaysEditComboBox, MonthsEditComboBox, YearEditTextBox);
        }

        private void MonthsDeadEditComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeDaysInMonthComboBox(DaysDeadEditComboBox, MonthsDeadEditComboBox, YearDeadEditTextBox);
        }

        private void ChangeDaysInMonthComboBox(ComboBox daysOfMonthComboBox, ComboBox monthComboBox, TextBox yearTextBox)
        {
            int year;
            if (!int.TryParse(yearTextBox.Text, out year))
            {
                year = DateTime.Now.Year;
            }

            if (monthComboBox.SelectedIndex == -1)
            {
                monthComboBox.SelectedIndex = 0;
            }
            int daysInThisMonth = DateTime.DaysInMonth(year, monthComboBox.SelectedIndex + 1);
            while ((daysInThisMonth > daysOfMonthComboBox.Items.Count) && (daysOfMonthComboBox.Items.Count < 31))
            {
                daysOfMonthComboBox.Items.Add(daysOfMonthComboBox.Items.Count + 1);
            }

            while (daysInThisMonth < daysOfMonthComboBox.Items.Count)
            {
                daysOfMonthComboBox.Items.Remove(daysOfMonthComboBox.Items.Count);
            }

            if (daysOfMonthComboBox.SelectedIndex == -1)
            {
                daysOfMonthComboBox.SelectedIndex = 0;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (
                (MessageBox.Show("Вы действительно хотите удалить выбранного человека?", "Удаление",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes) && (AllPersonDataGrid.SelectedIndex != -1))
            {
                var persons = AllPersonDataGrid.SelectedItems.Cast<Person>().ToList();
                while (persons.Count != 0)
                {
                    string resultOfDelete = BusinessComponent.Delete(persons[0]);

                    if (resultOfDelete != null)
                    {
                        MessageBox.Show(resultOfDelete, "Ошибка удаления");
                        return;
                    }
                    Tree.RemoveFamilyMember(persons[0]);
                    persons.Remove(persons[0]);
                }
            }
            AllPersonDataGrid.ItemsSource = BusinessComponent.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdvancedSearchBorder.Visibility = Visibility.Collapsed;
        }

        private void AdvancedSearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            AllPersonDataGrid.ItemsSource =
                BusinessComponent.SearchByAllParametrsAdvanced(AdvancedSearchTextBox.Text.Split(' ').ToList());
        }

        private void AllPersonDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllPersonDataGrid.SelectedIndex == -1)
            {
                AllPersonDataGrid.SelectedIndex = 0;
            }
            var person = (Person)AllPersonDataGrid.SelectedItem;
            if (person != null)
            {
                string path = Environment.CurrentDirectory + "\\Photos\\" + person.Photo;
                if (String.IsNullOrEmpty(person.Photo) || !File.Exists(path))
                {
                    person.Photo = "noPhoto.gif";
                }
                PhotoImage.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Photos\\" + person.Photo));

                BirthDayLabel.Content = person.BirthDay != null ? String.Format("{0:dd.MM.yyyy}", person.BirthDay.Value) : null;
                DeadDayLabel.Content = person.DeadDay != null ? String.Format("{0:dd.MM.yyyy}", person.DeadDay.Value) : null;

                Tree.Check((Person)AllPersonDataGrid.SelectedItem);
                CurrentPersonStackPanel.DataContext = person;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            AdvancedSearchBorder.Visibility = AdvancedSearchBorder.IsVisible ? Visibility.Collapsed : Visibility.Visible;
            AdvancedSearchTextBox.Text = null;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPhoto(PhotoNameTextBlock);
        }

        private void BrowseEditButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPhoto(PhotoNameEditTextBlock);
        }

        private void LoadPhoto(TextBlock textBlock)
        {
            var openFileDialog = new OpenFileDialog { Filter = "Фото (*.bmp, *.jpg)|*.bmp;*.jpg" };
            string shortFileName = null;
            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;
                int index = fileName.LastIndexOf('\\') + 1;
                int length = fileName.Length - index;
                shortFileName = fileName.Substring(index, length);
                if (!File.Exists(Environment.CurrentDirectory + "\\Photos\\" + shortFileName))
                {
                    File.Copy(fileName, "Photos\\" + shortFileName);
                }
            }
            if (shortFileName != null)
            {
                textBlock.Text = shortFileName;
            }
        }

        private void YearTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            YearTextBoxTextChanged(YearTextBox);
        }

        private void YearDeadTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            YearTextBoxTextChanged(YearDeadTextBox);
        }

        private void YearEditTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            YearTextBoxTextChanged(YearEditTextBox);
        }

        private void YearDeadEditTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            YearTextBoxTextChanged(YearDeadEditTextBox);
        }

        private void YearTextBoxTextChanged(TextBox textBox)
        {
            int year;
            if ((!int.TryParse(textBox.Text, out year)) || (year > DateTime.Now.Year))
            {
                textBox.Text = null;
            }
        }

        private void Tree_OnMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var checkedVertex = Tree.GetCheckedVertex();
            if (checkedVertex != null)
            {
                var person = (Person)checkedVertex.DataContext;

               // AllPersonDataGrid.SelectedIndex = AllPersonDataGrid.Items.IndexOf(AllPersonDataGrid.Items);
                foreach (var item in AllPersonDataGrid.Items)
                {
                    if (((Person)item).Id == person.Id)
                    {
                        AllPersonDataGrid.SelectedIndex = AllPersonDataGrid.Items.IndexOf(item);
                    }
                }
            }
        }
    }
}
