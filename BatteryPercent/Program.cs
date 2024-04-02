using System.Diagnostics;
using System.Runtime.InteropServices;
// using Gma.System.MouseKeyHook;

namespace BatteryPercent
{
    class Program
    {
        public static Properties.Settings props = Properties.Settings.Default;
        public static bool applySettings = false;

        public static AsusACPI acpi;

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
        private Boolean firstUpdate = true;
        // private IKeyboardMouseEvents m_GlobalHook;

        const int GWL_EXSTYLE = -20;
        const int WS_EX_TRANSPARENT = 0x20;
        const int WS_EX_LAYERED = 0x80000;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        // Enables overlay to show over non-fullscreen applications
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        public OverlayForm()
        {
            Program.acpi = new AsusACPI();

            this.FormBorderStyle = FormBorderStyle.None;

            reloadFromProperties();
            updateInterface();

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

            // Percentage based opacity
            this.Opacity = (float)Program.props.OverallOpacity / 100;
            Debug.WriteLine("opacity: " + this.Opacity.ToString());

            if (Program.props.NoFlicker)
            {
                // Using a regular label prevents flickering, but text opacity can't be changed
                systemInfoLabel = new Label();
            }
            else
            {
                systemInfoLabel = new CustomLabel();
            }

            systemInfoLabel.AutoSize = true;

            // TODO: Adjust this based on the current resolution for automatic setting
            // The below properties only apply when we use a regular label (AKA non flicker mode)
            //  (* 2) for 1080p, (+ 3) seems to be a good size for 900p
            int overlaySize = Program.props.OverlaySize * 2;
            float fontSize = systemInfoLabel.Font.Size + overlaySize;

            systemInfoLabel.Font = new Font(systemInfoLabel.Font.FontFamily, fontSize);
            systemInfoLabel.ForeColor = Color.White;
            this.Controls.Add(systemInfoLabel);

            int initialStyle = GetWindowLong(this.Handle, GWL_EXSTYLE);
            SetWindowLong(this.Handle, GWL_EXSTYLE, initialStyle | WS_EX_TRANSPARENT | WS_EX_LAYERED);

            // Add the drag listener class
            MouseDragger mouseDragger = new MouseDragger(this);

            // TODO: Add an update interval setting
            System.Windows.Forms.Timer updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 5000; //UPDATE_INTERVAL;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();

            UpdateOverlaySizeAndPosition();
        }

        // TODO: Fix the hotkey feature
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
            updateInterface();
        }

        private void updateInterface()
        {
            string systemInfo = GetSystemInfo();
            systemInfoLabel.Text = systemInfo;
            Debug.WriteLine(systemInfo);

            UpdateOverlaySizeAndPosition();
            this.Invalidate();
        }

        private string GetSystemInfo()
        {
            string stringToDisplay = "";

            bool isCharging = SystemInformation.PowerStatus.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Charging);

            if (Program.props.ShowClock)
            {
                string time = DateTime.Now.ToString(getTimeFormat());
                stringToDisplay += $"{time}";

                // Some nicer formatting if we're showing anything other than time
                if (Program.props.ShowBatteryPercent || Program.props.ShowBatteryTime)
                {
                    stringToDisplay += " | ";
                }
            }

            if (Program.props.ShowBatteryPercent)
            {
                string batteryStatus = SystemInformation.PowerStatus.BatteryLifePercent.ToString("P0");
                stringToDisplay += $"Battery: {batteryStatus} ";

                if (isCharging)
                {
                    // Just shows a unicode lightning bolt symbol instead of "charging"
                    stringToDisplay += "\U0001F5F2";
                }
            }

            if (Program.props.ShowBatteryTime && !isCharging)
            {
                int batteryLifeInSeconds = SystemInformation.PowerStatus.BatteryLifeRemaining;
                int batteryHours = batteryLifeInSeconds / 3600;
                int batteryMinutes = (batteryLifeInSeconds % 3600) / 60;

                stringToDisplay += $"{batteryHours} hrs {batteryMinutes} mins";
            }

            // FIXME: ??? Does this get the device mode? Looking for "Silent", "Balanced", "Eco", etc.
            stringToDisplay += $" Mode: {Program.acpi.GetCurrentASUSMode}";

            // Temperatures for CPU and GPU
            Debug.WriteLine(Program.acpi.DeviceGet(AsusACPI.Temp_CPU));
            Debug.WriteLine(Program.acpi.DeviceGet(AsusACPI.Temp_GPU));


            return stringToDisplay;
        }

        private void UpdateOverlaySizeAndPosition()
        {
            Size textSize = TextRenderer.MeasureText(systemInfoLabel.Text, systemInfoLabel.Font);
            this.Size = textSize + new Size(10, 5);

            // Only set the position if the overlay was just started
            if (firstUpdate)
            {
                firstUpdate = false;
                this.Location = new Point(10, 10);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Program.props.NoFlicker)
            {
                base.OnPaint(e);
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), this.ClientRectangle);
            }
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

        private string getTimeFormat()
        {
            if (Program.props.ShowClockFormat)
            {
                // Show time in 24 hr time
                return "HH:mm";
            }

            // Show time in 12 hr time
            return "h:mm tt";
        }
    }
}
