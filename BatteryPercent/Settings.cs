using Microsoft.Win32;
using System.Diagnostics;

namespace BatteryPercent
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            loadProperties();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // Save values to properties
            applyChangesToProperties();

            // Recreate the form with new parameters
            Program.applySettings = true;
            this.Close();
        }

        private void loadProperties()
        {
            // Background
            this.checkBoxAutoBackgroundColor.Checked = Program.props.AutoBackgroundColor;
            this.textBoxBackgroundColor.Text = Program.props.BackgroundColor;

            // Text and Font
            this.checkBoxAutoTextColor.Checked = Program.props.AutomaticTextColor;
            this.textBoxTextColor.Text = Program.props.TextColor;

            // Clock Settings
            this.checkBoxShowClock.Checked = Program.props.ShowClock;
            this.checkBoxClockFormat.Checked = Program.props.ShowClockFormat;

            // Battery Settings
            this.checkBoxBatteryPercentage.Checked = Program.props.ShowBatteryPercent;
            this.checkBoxBatteryTime.Checked = Program.props.ShowBatteryTime;

            // Opacity
            this.trackBarOverallOpacity.Value = Program.props.OverallOpacity;
            this.trackBarBackgroundOpacity.Value = Program.props.BackgroundOpacity;
            this.trackBarTextOpacity.Value = Program.props.TextOpacity;
            this.trackBarOverlaySize.Value = Program.props.OverlaySize;

            // No flicker mode
            this.checkBoxNoFlicker.Checked = Program.props.NoFlicker;
            
            // Auto start setting
            this.checkBoxStartAuto.Checked = Program.props.StartAuto;
        }

        private void applyChangesToProperties()
        {
            // Background
            Program.props.AutoBackgroundColor = this.checkBoxAutoBackgroundColor.Checked;
            Program.props.BackgroundColor = this.textBoxBackgroundColor.Text;

            // Text and Font
            Program.props.AutomaticTextColor = this.checkBoxAutoTextColor.Checked;
            Program.props.TextColor = this.textBoxTextColor.Text;

            // Clock Settings
            Program.props.ShowClock = this.checkBoxShowClock.Checked;
            Program.props.ShowClockFormat = this.checkBoxClockFormat.Checked;

            // Battery Settings
            Program.props.ShowBatteryPercent = this.checkBoxBatteryPercentage.Checked;
            Program.props.ShowBatteryTime = this.checkBoxBatteryTime.Checked;

            // Opacity
            Program.props.OverallOpacity = this.trackBarOverallOpacity.Value;
            Program.props.BackgroundOpacity = this.trackBarBackgroundOpacity.Value;
            Program.props.TextOpacity = this.trackBarTextOpacity.Value;
            Program.props.OverlaySize = this.trackBarOverlaySize.Value;

            // No flicker mode
            Program.props.NoFlicker = this.checkBoxNoFlicker.Checked;

            // Auto start setting
            Program.props.StartAuto = this.checkBoxStartAuto.Checked;
            setAutoStart();

            Program.props.Save();
        }

        private void setAutoStart()
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (Program.props.StartAuto)
            {
                // Add an entry to the application
                rk.SetValue("BatteryPercent", Application.ExecutablePath);
            }
            else
            {
                // Remove the entry to the application
                rk.DeleteValue("BatteryPercent", false);
            }
        }
    }
}
