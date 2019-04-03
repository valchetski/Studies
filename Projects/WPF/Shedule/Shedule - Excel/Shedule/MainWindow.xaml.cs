using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

namespace Shedule
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            NumberSubgroupButton.Content = Convert.ToString(RunOptions.MySubgroup);

            DatePicker.SelectedDate = DateTime.Now;
            DatePicker.DisplayDateStart = DateTime.Now.AddDays(-1);
        }

        public static int GetWeek(DateTime? choiceDate)
        {
            var date = choiceDate != null ? choiceDate.Value : DateTime.Now;
            int numberOfWeek = 1;
            const int daysInOneWeek = 7;
            for (var currentDate = GetFirstSeptemberDate(); currentDate < date; currentDate = currentDate.AddDays(daysInOneWeek))
            {
                numberOfWeek++;
                if (numberOfWeek > 4)
                {
                    numberOfWeek = 1;
                }
            }
            return numberOfWeek;
        }

        /// <summary>
        /// Возвращает день начала занятий в текущем учебном году
        /// </summary>
        /// <returns></returns>
        public static DateTime GetFirstSeptemberDate()
        {
            return new DateTime(DateTime.Now.Year - (DateTime.Now.Month < 9 ? 1 : 0), 9, 1);
        }

        private List<Period> GetSheduleForSelectedDay()
        {
            var dayOfWeek = ConvertTo.DayOfWeek(DatePicker.SelectedDate);
            int currentWeek = GetWeek(DatePicker.SelectedDate);
            CurrentWeekLabel.Content = String.Format("{0} неделя", currentWeek);
            int mySubgroup = Convert.ToInt32(NumberSubgroupButton.Content);
            var dictionary = new Dictionary<string, string>
            {
                {"1", dayOfWeek}, {"2", Convert.ToString(currentWeek) },
                {"4", ConvertTo.Subgroup(mySubgroup)}
            };
            var shedule = XML.Search(dictionary);
            if ((IsLoaded == false) && (shedule != null) && (IsTherePeriods(shedule) == false))
            {
                DatePicker.SelectedDate = DatePicker.SelectedDate != null
                    ? DatePicker.SelectedDate.Value.AddDays(1)
                    : DateTime.Now.AddDays(1);

            }
            return shedule;
        }

        /// <summary>
        /// Проверяет, будут или есть сегодня занятия
        /// Если их сегодня не было или не будет позже текущего времени
        /// то будет выводится расписание на следующий день
        /// </summary>
        public bool IsTherePeriods(List<Period> sheduleToday)
        {
            try
            {
                if ((EndStudyTime(sheduleToday) < DateTime.Now) || (sheduleToday.Count == 0))
                {
                    return false;
                }
            }
            catch (NullReferenceException){}
            return true;
        }

        /// <summary>
        /// Возвращает время конца последней пары--часы и минуты
        /// </summary>
        /// <param name="periods"></param>
        /// <returns></returns>
        public DateTime EndStudyTime(List<Period> periods)
        {
            var lastPeriod = periods.LastOrDefault();
            var endLastPeriod = lastPeriod != null ? lastPeriod.Time : "";
            var beginAndEndPeriod = endLastPeriod.Split('-', ':').ToList();
            if (beginAndEndPeriod.Count == 4)
            {
                beginAndEndPeriod.RemoveRange(0, 2);
            }
            else
            {
                beginAndEndPeriod.Clear();
                beginAndEndPeriod.Add("23");
                beginAndEndPeriod.Add("59");
            }

            var timeNow = DatePicker.SelectedDate != null ? DatePicker.SelectedDate.Value : DateTime.Now;
            timeNow = new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            return new DateTime(timeNow.Year, timeNow.Month, timeNow.Day, Convert.ToInt32(beginAndEndPeriod[0]), Convert.ToInt32(beginAndEndPeriod[1]), 0);
        }

        public void ToDataGridView()
        {
            var sheduleToday = GetSheduleForSelectedDay();
            if (sheduleToday == null)
            {
                SheduleListView.Visibility = Visibility.Collapsed;
                NoPeriodsLabel.Visibility = Visibility.Visible;
                NoPeriodsLabel.Content = "Для загрузки расписания\nвоспользуйтесь поиском";
            }
            else if (sheduleToday.Count > 0)
            {
                SheduleListView.Visibility = Visibility.Visible;
                NoPeriodsLabel.Visibility = Visibility.Collapsed;
                SheduleListView.ItemsSource = sheduleToday;
            }
            else
            {
                SheduleListView.Visibility = Visibility.Collapsed;
                NoPeriodsLabel.Visibility = Visibility.Visible;
                NoPeriodsLabel.Content = "Сегодня занятий нет";
            }
        }


        #region Increment/DecrementDate
        private void PreviousDayButton_OnClick(object sender, RoutedEventArgs e)
        {
            IncrementCurrentDay(false);
        }

        private void NextDayButton_OnClick(object sender, RoutedEventArgs e)
        {
           IncrementCurrentDay(true);
        }

        private void IncrementCurrentDay(bool isPlus)
        {
            int increment = isPlus ? 1 : -1;
            if (DatePicker.SelectedDate != null)
            {
                DatePicker.SelectedDate = DatePicker.SelectedDate.Value.AddDays(increment);
            }
        }
        #endregion

        private void PrintTodaySheduleButton_OnClick(object sender, RoutedEventArgs e)
        {
            DatePicker.SelectedDate = DateTime.Now;
        }

        private void DatePicker_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ToDataGridView();
        }

        private void NumberSubgroupButton_Click(object sender, RoutedEventArgs e)
        {
            ToDataGridView();
            NumberSubgroupButton.Content = (string)NumberSubgroupButton.Content == "1" ? "2" : "1";
            RunOptions.SaveOptions(Convert.ToInt32(NumberSubgroupButton.Content));
        }

        private void GroupNumberTextBox_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            const string acceptableSymbols = "0123456789";
            e.Handled = acceptableSymbols.IndexOf(e.Text) < 0;
        }

        private void GroupNumberTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchSheduleButton.IsEnabled = GroupNumberTextBox.Text.Length == 6;
        }

        private void SearchSheduleButton_OnClick(object sender, RoutedEventArgs e)
        {
            string fileName;
            using (var сlient = new WebClient())
            {
                try
                {
                    int groupNumber = Convert.ToInt32(GroupNumberTextBox.Text);
                    string adress = String.Format("http://www.bsuir.by/psched/schedulegroup.excelbuild/{0}?group={0}",
                        groupNumber);
                    fileName = String.Format("{0}.xls", groupNumber);
                    сlient.DownloadFile(adress, fileName);
                }
                catch (WebException)
                {
                    MessageBox.Show("Такой группы не существует или у вас нету связи с Интернетом", "Ошибка",
                        MessageBoxButton.OK);
                    return;
                }

            }
            string path = String.Format("{0}\\{1}", Environment.CurrentDirectory, fileName);
            Excel.OpenShedule(path);
            File.Delete(path);
            Close();

            ToDataGridView();
        }
    }
}
