using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Win32;
using _3.Readers.Files;
using _3.Readers.ipc;
using _3.Readers.ipc.ClientProIPC;
using _3.Readers.Watchers;

namespace _3.Readers
{
    public partial class MainWindow
    {
        /// <summary>
        /// Таймер для отображения надписи, сигнализирующей, что произошло сохранение файла
        /// </summary>
        private readonly DispatcherTimer dispatcherTimer;

        private readonly FileChangeTimeWatcher fileChangeTimeWatchThread;
        private AccessWatcher accessWatcherThread;
        private readonly FileIsChangedWatcher fileIsChangedWatcherThread;

        private readonly Thread checkServerThread;

        private readonly AbortEditForciblyWindow abortEditForciblyWindow;

        private bool isEditMode;

        private const string title = "Редактор";
        private const string readonlyMode = "Чтение";
        private const string editingMode = "Редактирование";
        private const string queueStatus = "в очереди";

        private FileBase file;
        private Control fileViewControl;

        public static IPC ipc;

        public MainWindow()
        {
            InitializeComponent();

            SetTitle(title);

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_OnTick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0);

            fileChangeTimeWatchThread =
                new FileChangeTimeWatcher(Convert.ToInt32(AppSettings.ReadSetting("noWorkTimePermission")));
            fileChangeTimeWatchThread.FileIsNotChangedLong += FileChangeTimerWatch_OnFileIsNotChangedLong;

            accessWatcherThread = new AccessWatcher();
            accessWatcherThread.FileIsFree += AccessWatcherThread_OnFileIsFree;

            fileIsChangedWatcherThread = new FileIsChangedWatcher();
            fileIsChangedWatcherThread.FileIsChanged += FileIsChangedWatcherThread_OnFileIsChanged;

            abortEditForciblyWindow = new AbortEditForciblyWindow();
            abortEditForciblyWindow.TimeIsEnd += AbortEditForciblyWindow_OnTimeIsEnd;
            abortEditForciblyWindow.ContinueWork += AbortEditForciblyWindow_OnContinueWork;

            switch (AppSettings.ReadSetting("typeIPC"))
            {
                case "file":
                    ipc = new FileIPC();
                    break;
                case "server":
                    ipc = new ClientIPC();
                    checkServerThread = new Thread(CheckServer);
                    break;
                case "noserver":
                    ipc = new ClientProIPC();
                    break;
            }
        }

        private void CheckServer()
        {
            while (true)
            {
                if (ipc.IsOk() == false)
                {
                    ChangeControlsThreadSafe(delegate
                    {
                        OpenFileButton.IsEnabled = false;
                        SaveFileButton.IsEnabled = false;
                        EditModeRadioButton.IsEnabled = false;
                        ReadonlyModeRadioButton.IsEnabled = false;
                        if (fileViewControl != null)
                        {
                            fileViewControl.IsEnabled = false;
                        }
                    });
                    Thread.Sleep(1000);
                }
                else
                {
                    ChangeControlsThreadSafe(delegate
                    {
                        OpenFileButton.IsEnabled = true;
                        EditModeRadioButton.IsEnabled = true;
                        ReadonlyModeRadioButton.IsEnabled = true;
                        if (fileViewControl != null)
                        {
                            fileViewControl.IsEnabled = true;
                        }
                    });
                    checkServerThread.Suspend();
                }
            }
        }

        #region Button clicks

        private void OpenFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            var correctTypes = new List<string> {".txt", ".xlsx", ".xls"};
            var openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel files (*.xlsx)|*.xlsx|Text files (*.txt)|*.txt"
            };
            bool isOk = ipc.IsOk();
            if (ipc.IsOk() && openFileDialog.ShowDialog() == true)
            {
                if (fileViewControl != null && fileViewControl.Visibility == Visibility.Visible)
                {
                    SuggestSave();
                    ipc.Dequeue();
                }

                if (correctTypes.Contains(Path.GetExtension(openFileDialog.FileName)))
                {
                    ipc.SetFileName(openFileDialog.FileName);
                    ChangeFileType(openFileDialog.FileName.Contains("xlsx"));

                    if (EditModeRadioButton.IsChecked == true)
                    {
                        TryEdit(openFileDialog.FileName);
                    }
                    else
                    {
                        ReadOnlyMode(false, openFileDialog.FileName);
                    }
                    
                }
                else
                {
                    ShowInfoMessageBox("Некорректный тип файла", "Ошибка");
                }
            }
            else if(isOk == false)
            {
                ServerError();
            }
        }

        private void SaveFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void CancelEditFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (ShowYesNoMessageBox("Вы действительно хотите закрыть файл?", "Закрытие файла") == MessageBoxResult.Yes)
            {
                SuggestSave();
                DefaultMode();
            }
        }

        private void NoRefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            RefreshDockPanel.Visibility = Visibility.Collapsed;
        }

        private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            SetDataContext(FileBase.CurrentFileName);
            RefreshDockPanel.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Watchers events 

        private void AccessWatcherThread_OnFileIsFree(object sender, EventArgs e)
        {
            ChangeControlsThreadSafe(() => RefreshDockPanel.Visibility = Visibility.Collapsed);
            if (ShowYesNoMessageBox(
                "Вы хотите приступить к редактированию?(при отказе вы будете удалены из очереди ожидания)",
                "Файл свободен") == MessageBoxResult.Yes)
            {
                EditingMode(FileBase.CurrentFileName);
            }
            else
            {
                ReadOnlyMode(false, FileBase.CurrentFileName);
            }
        }

        private void FileIsChangedWatcherThread_OnFileIsChanged(object sender, EventArgs e)
        {
            ChangeControlsThreadSafe(delegate
            {
                if (isEditMode == false && ipc.DidISaveFile() == false && fileViewControl.Visibility == Visibility.Visible) //значит что мы находимся в режиме чтения
                {
                    RefreshDockPanel.Visibility = Visibility.Visible;
                }
            });
        }

        private void FileChangeTimerWatch_OnFileIsNotChangedLong(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                ChangeControlsThreadSafe(() => abortEditForciblyWindow.ShowDialog());
            }
        }

        #endregion

        #region File modes

        private void DefaultMode()
        {
            ChangeMode(false, false, false, false, false, title);

            fileChangeTimeWatchThread.Suspend();
            fileIsChangedWatcherThread.Suspend();
            
            
            accessWatcherThread.Stop();
            accessWatcherThread = new AccessWatcher();
            accessWatcherThread.FileIsFree += AccessWatcherThread_OnFileIsFree;

            ipc.Dequeue();
        }

        private void ReadOnlyMode(bool isInQueue, string fileName)
        {
            if (ipc.IsOk())
            {
                if (isInQueue == false)
                {
                    ipc.Dequeue();
                }

                ChangeMode(false, true, false, true, false, fileName, readonlyMode, isInQueue ? queueStatus : "");

                fileChangeTimeWatchThread.Suspend();
                fileIsChangedWatcherThread.Start();

                ChangeControlsThreadSafe(delegate
                {
                    EditModeRadioButton.IsChecked = false;
                    ReadonlyModeRadioButton.IsChecked = true;
                });
            }
            else
            {
                ServerError();
            }
        }

        private void EditingMode(string fileName)
        {
            ChangeMode(true, true, true, true, true, fileName, editingMode);

            fileChangeTimeWatchThread.LastChangeOfTable = DateTime.Now;
            fileChangeTimeWatchThread.Start();

            ChangeControlsThreadSafe(delegate
            {
                EditModeRadioButton.IsChecked = true;
                ReadonlyModeRadioButton.IsChecked = false;
            });
        }

        private void ChangeMode(bool isEnabledSaveFileButton, bool isEnabledCancelEditFileButton,
            bool isEnabledExcelDataGrid, bool isShowExcelDataGrid, bool isItEditMode, string newTitle, string fileMode = "",
            string newQueueStatus = "")
        {
            ChangeControlsThreadSafe(delegate
            {
                try
                {
                    SaveFileButton.IsEnabled = isEnabledSaveFileButton;
                    CancelEditFileButton.IsEnabled = isEnabledCancelEditFileButton;
                    SetDataContext(newTitle);
                    if (fileViewControl != null)
                    {
                        fileViewControl.IsEnabled = isEnabledExcelDataGrid;
                        fileViewControl.Visibility = isShowExcelDataGrid ? Visibility.Visible : Visibility.Collapsed;
                    }
                    isEditMode = isItEditMode;
                    if (isItEditMode)
                    {
                        
                    }
                    RefreshDockPanel.Visibility = Visibility.Collapsed;
                    SetTitle(newTitle, fileMode, newQueueStatus);
                }
                catch (FileFormatException)
                {
                    ShowInfoMessageBox("Невозможно открыть файл: " + newTitle, "Файл повержден");
                    DefaultMode();
                }
            });
        }

        private void TryEdit(string fileName)
        {
            if (ipc.IsOk())
            {
                if (ipc.CanIEdit() && EditModeRadioButton.IsChecked == true)
                {
                    EditingMode(fileName);
                    ipc.Enqueue();
                }
                else if (EditModeRadioButton.IsChecked == true)
                {
                    ipc.Enqueue();
                    accessWatcherThread.Start();
                    ReadOnlyMode(true, fileName);
                }
            }
            else
            {
                ServerError();
            }
        }

        #endregion

        #region AbortEditForciblyWindow events

        private void AbortEditForciblyWindow_OnTimeIsEnd(object sender, EventArgs e)
        {
            ShowInfoMessageBox("Режим редактирования прерван. Файл слишком долго не редактировался." +
                            "Все несохраненные изменения потеряны. Вы удалены из очереди на редактирование", "Редактирование прервано");
            ReadOnlyMode(false, FileBase.CurrentFileName);
        }

        private void AbortEditForciblyWindow_OnContinueWork(object sender, EventArgs e)
        {
            fileChangeTimeWatchThread.Start();
            fileChangeTimeWatchThread.LastChangeOfTable = DateTime.Now;
        }

        #endregion

        #region Get info from gridview

        private string GetCell(int row, int column)
        {
            DataGridRow rowContainer = GetRow(row);

            if (rowContainer != null && fileViewControl is DataGrid)
            {
                var presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);

                var cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                if (cell == null)
                {
                    (fileViewControl as DataGrid).ScrollIntoView(rowContainer, (fileViewControl as DataGrid).Columns[column]);
                    cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                }
                var textBlock = cell.Content as TextBlock;
                if (textBlock != null)
                {
                    return textBlock.Text;
                }
            }
            return null;
        }

        private DataGridRow GetRow(int index)
        {
            DataGridRow row = null;
            if (fileViewControl is DataGrid)
            {
                row = (DataGridRow)(fileViewControl as DataGrid).ItemContainerGenerator.ContainerFromIndex(index);
                if (row == null && index < (fileViewControl as DataGrid).Items.Count)
                {
                    (fileViewControl as DataGrid).UpdateLayout();
                    (fileViewControl as DataGrid).ScrollIntoView((fileViewControl as DataGrid).Items[index]);
                    row = (DataGridRow)(fileViewControl as DataGrid).ItemContainerGenerator.ContainerFromIndex(index);
                }
            }
            return row;
        }

        private static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                var v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T ?? GetVisualChild<T>(v);
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        #endregion

        #region RadioButtons clicks
        private void EditModeRadioButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (isEditMode == false)
            {
                RadioButtonChecked(EditModeRadioButton, ReadonlyModeRadioButton);
            }
        }

        private void ReadonlyModeRadioButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (isEditMode || ReadonlyModeRadioButton.IsChecked == true)
            {
                RadioButtonChecked(ReadonlyModeRadioButton, EditModeRadioButton);
            }
        }

        private void RadioButtonChecked(RadioButton checkedRadioButton, RadioButton uncheckedRadioButton)
        {
            if (fileViewControl != null && fileViewControl.Visibility == Visibility.Visible)
            {
                if (
                    ShowYesNoMessageBox(
                        String.Format("Вы действительно хотите перейти в режим {0}?", checkedRadioButton.Content),
                        "Смена режима") == MessageBoxResult.Yes)
                {
                    if (Equals(checkedRadioButton, EditModeRadioButton))
                    {
                        TryEdit(FileBase.CurrentFileName);
                    }
                    else
                    {
                        SuggestSave();
                        ReadOnlyMode(false, FileBase.CurrentFileName);
                    }

                }
                else
                {
                    checkedRadioButton.IsChecked = false;
                    uncheckedRadioButton.IsChecked = true;
                }
            }
        }
        #endregion

        #region ExcelDataGrid event hadlers

        private void ExcelDataGrid_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void ExcelDataGrid_OnCurrentCellChanged(object sender, EventArgs e)
        {
            fileChangeTimeWatchThread.LastChangeOfTable = DateTime.Now;
        }

        #endregion

        #region MainWindow event hadlers

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            //DefaultMode();
            ipc.Reset();
            fileChangeTimeWatchThread.Stop();
            accessWatcherThread.Stop();
            fileIsChangedWatcherThread.Stop();
            Environment.Exit(0);
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (ShowYesNoMessageBox("Вы действительно хотите выйти?", "Выход") == MessageBoxResult.Yes)
            {
                if (isEditMode)
                {
                    SuggestSave();
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Save

        private void SuggestSave()
        {
            if (isEditMode && ShowYesNoMessageBox("Вы хотите сохранить изменения в файле?", "Сохранение файла") == MessageBoxResult.Yes)
            {
                Save();
            }
        }

        private void Save()
        {
            if (ipc.IsOk())
            {
                fileChangeTimeWatchThread.LastChangeOfTable = DateTime.Now;

                var table = new string[,] { };
                if (fileViewControl is DataGrid)
                {
                    table =
                        new string[(fileViewControl as DataGrid).Items.Count, (fileViewControl as DataGrid).Columns.Count];
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        for (int j = 0; j < table.GetLength(1); j++)
                        {
                            table[i, j] = GetCell(i, j);
                        }
                    }
                }
                else if (fileViewControl is TextBox)
                {
                    table = new string[(fileViewControl as TextBox).LineCount, 1];
                    for (int i = 0; i < table.GetLength(0); i++)
                    {
                        table[i, 0] = (fileViewControl as TextBox).GetLineText(i);
                    }
                }
                file.Save(table, FileBase.CurrentFileName);

                dispatcherTimer.Start();
            }
            else
            {
                ServerError();
            }
            
        }

        #endregion

        private void DispatcherTimer_OnTick(object sender, EventArgs e)
        {
            if (SavedLabel.Visibility == Visibility.Collapsed)
            {
                SavedLabel.Visibility = Visibility.Visible;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            }
            else if (SavedLabel.Visibility == Visibility.Visible)
            {
                SavedLabel.Visibility = Visibility.Collapsed;
                dispatcherTimer.Interval = TimeSpan.Zero;
                dispatcherTimer.Stop();
            }
        }

        private MessageBoxResult ShowYesNoMessageBox(string messageBoxText, string caption)
        {
            var messageBoxResult = MessageBoxResult.No;
            Dispatcher.Invoke(() =>
            {
                messageBoxResult = MessageBox.Show(this, messageBoxText, caption, MessageBoxButton.YesNo,
                    MessageBoxImage.Question,
                    MessageBoxResult.OK);

            });

            return messageBoxResult;
        }

        private void ShowInfoMessageBox(string info, string messageBoxTitle)
        {
            MessageBox.Show(info, messageBoxTitle);
        }

        private void SetTitle(string newTitle, string fileMode = "", string newQueueStatus = "")
        {
            if (fileMode != "")
            {
                int indexOfSlash = newTitle.LastIndexOf('\\');
                if (indexOfSlash != -1)
                {
                    newTitle = newTitle.Substring(indexOfSlash + 1, newTitle.Length - indexOfSlash - 1);
                }
                newTitle += String.Format("[{0}", fileMode);
                if (newQueueStatus != "")
                {
                    newTitle += String.Format(", {0}", newQueueStatus);
                }
                newTitle += "]";
            }
            Title = newTitle;
        }

        private void ChangeFileType(bool isExcel)
        {
            if (fileViewControl != null)
            {
                fileViewControl.Visibility = Visibility.Collapsed;
            }

            if (isExcel)
            {
                file = new FileExcel(Convert.ToInt32(AppSettings.ReadSetting("maxTableRank")));
                fileIsChangedWatcherThread.file = file;
                fileViewControl = ExcelDataGrid;
            }
            else
            {
                file = new FileTxt();
                fileIsChangedWatcherThread.file = file;
                fileViewControl = TxtTextBox;
            }
        }

        private void SetDataContext(string fileName)
        {
            if (fileViewControl is DataGrid && file is FileExcel)
            {
                fileViewControl.DataContext = (file as FileExcel).ToDataView(file.Open(fileName));
            }
            else if (fileViewControl is TextBox)
            {
                var fileInfo = file.Open(fileName);
                string toTextBox = "";
                foreach (var s in fileInfo)
                {
                    toTextBox += s + "\n";
                }
                if (toTextBox.Length > 0)
                {
                    toTextBox = toTextBox.Remove(toTextBox.Length - 1, 1);
                }
                (fileViewControl as TextBox).Text = toTextBox;
            }

        }

        private void ChangeControlsThreadSafe(Action action)
        {
            if (InterfaceStackPanel.Dispatcher.Thread == Thread.CurrentThread)
            {
                action();
            }
            else
            {
                InterfaceStackPanel.Dispatcher.BeginInvoke(DispatcherPriority.Normal, action);
            }
        }

        private void ServerError()
        {
            ShowInfoMessageBox("Не удается подключиться к серверу. Попробуйте позже", "Ошибка подключения");
            DefaultMode();
            checkServerThread.Start();
        }
    }
}