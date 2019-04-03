using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;

namespace _3.Readers
{
    /// <summary>
    /// Interaction logic for AbortEditForcibly.xaml
    /// </summary>
    public partial class AbortEditForciblyWindow
    {
        private readonly DispatcherTimer dispatcherTimer;

        private TimeSpan remainingTime;
        private readonly TimeSpan maxRemainingTime;

        public delegate void NoTimeHandler(object sender, EventArgs args);

        public event NoTimeHandler TimeIsEnd;

        public event NoTimeHandler ContinueWork;

        #region No close button
        private const int gwlStyle = -16;
        private const int wsSysmenu = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        #endregion

        public AbortEditForciblyWindow()
        {
            InitializeComponent();

            maxRemainingTime = new TimeSpan(0, 0, Convert.ToInt32(AppSettings.ReadSetting("remainingTime")));
            remainingTime = maxRemainingTime;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += DispatcherTimer_OnTick;
            dispatcherTimer.Interval = TimeSpan.Zero;
        }

        private void DispatcherTimer_OnTick(object sender, EventArgs e)
        {
            if (dispatcherTimer.Interval == TimeSpan.Zero)
            {
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            }
            RemainingTimeLabel.Content = String.Format("{0}с.", remainingTime);
            remainingTime -= TimeSpan.FromSeconds(1);
            if (remainingTime == TimeSpan.Zero)
            {
                OnTimeIsEnd(new EventArgs());
            }
        }

        private void OnTimeIsEnd(EventArgs e)
        {
            NoTimeHandler handler = TimeIsEnd;
            if (handler != null)
            {
                handler(this, e);
            }
            Hide();
        }

        private void OnContinueWork(EventArgs e)
        {
            NoTimeHandler handler = ContinueWork;
            if (handler != null)
            {
                handler(this, e);
            }
            dispatcherTimer.Stop();
            Hide();
        }

        private void AbortEditForciblyWindow_OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool) e.NewValue)
            {
                remainingTime = maxRemainingTime;
                dispatcherTimer.Interval = TimeSpan.Zero;
                dispatcherTimer.Start();
            }
        }

        private void AbortEditForciblyWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            OnContinueWork(new EventArgs());
        }

        private void AbortEditForciblyWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, gwlStyle, GetWindowLong(hwnd, gwlStyle) & ~wsSysmenu);
        }
    }

}
