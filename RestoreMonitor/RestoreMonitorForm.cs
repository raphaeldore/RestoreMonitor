using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestoreMonitor
{
    public partial class RestoreMonitorForm : Form
    {
        public RestoreMonitorForm()
        {
            InitializeComponent();
        }

        private void RestoreMonitorForm_Load(object sender, EventArgs e)
        {
            SaveState("Application Start State of Windows:");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveState("Save state button - current window state");
        }

        private void restoreButton_Click(object sender, EventArgs e)
        {
            RestoreState("Restore state button:");
        }


        public void RestoreState(string caption)
        {
            logTextBox.Text = caption + "\n";
            logTextBox.Text += "===================================\n";
            logTextBox.Text += "\n";

            // Restore the state of windows across monitors
            string log;
            MonitorState.RestoreMointorState(out log);

            logTextBox.Text += log;
        }


        public void SaveState(string caption)
        {
            logTextBox.Text = caption + "\n";
            logTextBox.Text += "===================================\n";
            logTextBox.Text += "\n";

            // Save monitor state
            string log;
            MonitorState.SaveMonitorState(out log);

            // Display log
            logTextBox.Text += log;
        }

    }
}
