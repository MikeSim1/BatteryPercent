namespace BatteryPercent
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            // TODO: Save values to properties

            // Recreate the form with new parameters
            Program.instance.reloadFromProperties();
            this.Close();
        }
    }
}
