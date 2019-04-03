using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Shedule.BusinessLayer;

namespace Shedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly BusinessController businessController;

        private bool isUserChanged;

        public MainWindow()
        {
            InitializeComponent();
            isUserChanged = false;
            businessController = new BusinessController();
        }

        private void ToDataGridView()
        {
            if (DatePicker.SelectedDate != null)
            {
                List<Period> sheduleToday = businessController.GetSheduleForSelectedDay(DatePicker.SelectedDate.Value,
                    NumberSubgroupButton.Content.ToString());
                int delta = (DatePicker.SelectedDate.Value - DateTime.Now.Date).Days;
                if ((isUserChanged == false) && (delta <= 7) &&
                    (businessController.IsTherePeriods(sheduleToday, DatePicker.SelectedDate.Value) == false))
                {
                    IncrementCurrentDay(true);
                }

                CurrentWeekLabel.Content = String.Format("{0} нед. {1}",
                    businessController.GetWeek(DatePicker.SelectedDate.Value),
                    ConvertTo.Day(DatePicker.SelectedDate.Value.DayOfWeek));

                if (sheduleToday == null)
                {
                    ScrollViewer.Visibility = Visibility.Collapsed;
                    NoPeriodsLabel.Visibility = Visibility.Visible;
                    NoPeriodsLabel.Content = "Для загрузки расписания\nвоспользуйтесь поиском";
                }
                else if (sheduleToday.Count > 0)
                {
                    ScrollViewer.Visibility = Visibility.Visible;
                    NoPeriodsLabel.Visibility = Visibility.Collapsed;
                    SheduleListView.ItemsSource = sheduleToday;
                }
                else
                {
                    ScrollViewer.Visibility = Visibility.Collapsed;
                    NoPeriodsLabel.Visibility = Visibility.Visible;
                    NoPeriodsLabel.Content = "Сегодня занятий нет";
                }
            }
        }


        #region Increment/DecrementDate
        private void PreviousDayButton_OnClick(object sender, RoutedEventArgs e)
        {
            isUserChanged = true;
            IncrementCurrentDay(false);
            isUserChanged = false;
        }

        private void NextDayButton_OnClick(object sender, RoutedEventArgs e)
        {
            isUserChanged = true;
            IncrementCurrentDay(true);
            isUserChanged = false;
        }

        private void IncrementCurrentDay(bool isPlus)
        {
            int increment = isPlus ? 1 : -1;
            DatePicker.SelectedDate = DatePicker.SelectedDate != null
                ? DatePicker.SelectedDate.Value.AddDays(increment)
                : DateTime.Now.AddDays(1);
        }

        #endregion

        #region Events

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.SubGroup != "1" && Properties.Settings.Default.SubGroup != "2")
            {
                businessController.SaveOptions("1");
            }
            NumberSubgroupButton.Content = Properties.Settings.Default.SubGroup;
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void PrintTodaySheduleButton_OnClick(object sender, RoutedEventArgs e)
        {
            isUserChanged = true;
            DatePicker.SelectedDate = DateTime.Now;
            isUserChanged = false;
        }

        private void DatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ToDataGridView();
        }

        private void NumberSubgroupButton_Click(object sender, RoutedEventArgs e)
        {
            NumberSubgroupButton.Content = (string)NumberSubgroupButton.Content == "1" ? "2" : "1";
            businessController.SaveOptions(NumberSubgroupButton.Content.ToString());
            ToDataGridView();
        }

        private void GroupNumberTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            const string acceptableSymbols = "0123456789";
            e.Handled = acceptableSymbols.IndexOf(e.Text) < 0;
        }

        private void GroupNumberTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchSheduleButton != null)
            {
                SearchSheduleButton.IsEnabled = GroupNumberTextBox.Text.Length == 6;
            }
        }

        private void GroupNumberTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (SearchSheduleButton.IsEnabled && e.Key == Key.Enter)
            {
                SearchSheduleButton_OnClick(sender, e);
            }
        }


        private void SearchSheduleButton_OnClick(object sender, RoutedEventArgs e)
        {
            int groupNumber = Convert.ToInt32(GroupNumberTextBox.Text);
            string adress = String.Format("http://www.bsuir.by/schedule/schedule.xhtml?id={0}",
                groupNumber);
            List<Period> shedule;
            try
            {
                shedule = businessController.GetShedule(adress);
            }
            catch (WebException)
            {
                MessageBox.Show("У вас нету связи с Интернетом", "Ошибка", MessageBoxButton.OK);
                return;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Данная группа не найдена", "Ошибка", MessageBoxButton.OK);
                return;
            }
            businessController.Save(shedule);
            DatePicker.SelectedDate = DateTime.Now;//после этого вызовется событие DatePicker_OnSelectedDateChanged
        }

        #endregion
    }
}