using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
// using Gma.System.MouseKeyHook;

namespace BatteryPercent
{
    class Program
    {
        public static bool applySettings = false;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OverlayForm());
        }
    }

    class OverlayForm : Form
    {
        private const int UPDATE_INTERVAL = 1000;
        private Label systemInfoLabel;
        private NotifyIcon trayIcon;
        // private IKeyboardMouseEvents m_GlobalHook;

        const int GWL_EXSTYLE = -20;
        const int WS_EX_TRANSPARENT = 0x20;
        const int WS_EX_LAYERED = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public OverlayForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;

            reloadFromProperties();

            this.TopMost = true;
            this.ShowInTaskbar = false;

            trayIcon = new NotifyIcon();
            trayIcon.Text = "Game Overlay App";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.Visible = true;

            trayIcon.ContextMenuStrip = new ContextMenuStrip();
            trayIcon.ContextMenuStrip.Items.Add("Settings", null, OnSettingsClicked);
            trayIcon.ContextMenuStrip.Items.Add("Exit", null, OnExitClicked);

            Subscribe();
        }

        public void reloadFromProperties()
        {
            // TODO: Make background color adjustable
            this.BackColor = Color.Black;

            // TODO: Make opacity adjustable
            this.Opacity = 0.6;

            systemInfoLabel = new Label();
            systemInfoLabel.ForeColor = Color.White;
            systemInfoLabel.AutoSize = true;

            // TODO: Adjust this based on the current resolution
            //  (* 2) for 1080p, (+ 3) seems to be a good size for 900p
            float fontSize = systemInfoLabel.Font.Size;

            systemInfoLabel.Font = new Font(systemInfoLabel.Font.FontFamily, fontSize);
            this.Controls.Add(systemInfoLabel);

            int initialStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, initialStyle | WS_EX_TRANSPARENT | WS_EX_LAYERED);

            System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = UPDATE_INTERVAL;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();

            UpdateOverlaySizeAndPosition();
        }

        private void Subscribe()
        {
            // m_GlobalHook = Hook.GlobalEvents();
            // m_GlobalHook.KeyDown += GlobalHookKeyPress;
        }

        private void GlobalHookKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.L && e.Modifiers == Keys.LWin)
            {
                if (this.Visible)
                    this.Hide();
                else
                    this.Show();

                e.Handled = true;
            }
        }

        private void OnSettingsClicked(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }

        private void OnExitClicked(object sender, EventArgs e)
        {
            Unsubscribe();
            Application.Exit();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (Program.applySettings)
            {
                Application.Restart();
            }

            string systemInfo = GetSystemInfo();
            systemInfoLabel.Text = systemInfo;
            Debug.WriteLine(systemInfo);

            UpdateOverlaySizeAndPosition();
            this.Invalidate();
        }

        private string GetSystemInfo()
        {
            Properties.Settings props = Properties.Settings.Default;
            string stringToDisplay = "";

            bool isCharging = SystemInformation.PowerStatus.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Charging);

            if (props.ShowClock)
            {
                string time = DateTime.Now.ToString("hh:mm tt");
                stringToDisplay += $"{time}";

                // Some nicer formatting if we're showing anything other than time
                if (props.ShowBatteryPercent || props.ShowBatteryTime)
                {
                    stringToDisplay += " | ";
                }
            }

            if (props.ShowBatteryPercent)
            {
                string batteryStatus = SystemInformation.PowerStatus.BatteryLifePercent.ToString("P0");
                stringToDisplay += $"Battery: {batteryStatus} ";

                if (isCharging)
                {
                    // Just shows a unicode lightning bolt symbol instead of "charging"
                    stringToDisplay += "\U0001F5F2";
                }
            }

            if (props.ShowBatteryTime && !isCharging)
            {
                int batteryLifeInSeconds = SystemInformation.PowerStatus.BatteryLifeRemaining;
                int batteryHours = batteryLifeInSeconds / 3600;
                int batteryMinutes = (batteryLifeInSeconds % 3600) / 60;

                stringToDisplay += $"{batteryHours} hrs {batteryMinutes} mins";
            }

            return stringToDisplay;
        }

        private void UpdateOverlaySizeAndPosition()
        {
            Size textSize = TextRenderer.MeasureText(systemInfoLabel.Text, systemInfoLabel.Font);
            this.Size = textSize + new Size(10, 5);
            this.Location = new Point(10, 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), this.ClientRectangle);
        }

        protected override void OnClosed(EventArgs e)
        {
            trayIcon.Dispose();
            Unsubscribe();
            base.OnClosed(e);
        }

        public void Unsubscribe()
        {
            // m_GlobalHook.KeyDown -= GlobalHookKeyPress;
            // m_GlobalHook.Dispose();
        }
    }

    class PerformanceInfo
    {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PERFORMANCE_INFORMATION PerformanceInformation, [In] int Size);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PERFORMANCE_INFORMATION
    {
        public int Size;
        public IntPtr CommitTotal;
        public IntPtr CommitLimit;
        public IntPtr CommitPeak;
        public IntPtr PhysicalTotal;
        public IntPtr PhysicalAvailable;
        public IntPtr SystemCache;
        public IntPtr KernelTotal;
        public IntPtr KernelPaged;
        public IntPtr KernelNonPaged;
        public IntPtr PageSize;
        public int HandlesCount;
        public int ProcessCount;
        public int ThreadCount;
    }
}
