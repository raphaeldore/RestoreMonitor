using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RestoreMonitor
{
    class RestoreMontiorPowerManagement
    {
        // Private so we have a singletone
        private RestoreMontiorPowerManagement() { }

        // static used for singleton
        private static RestoreMontiorPowerManagement restoreMontior = null;

        // Static method to return a singleton
        public static RestoreMontiorPowerManagement GetRestoreMontiorInstance()
        {
            if (restoreMontior == null)
            {
                restoreMontior = new RestoreMontiorPowerManagement();
            }

            return restoreMontior;
        }

        private void Initialize()
        {
            // Hook up the power mode changed to save the windows and restore them
            SystemEvents.PowerModeChanged += OnPowerModeChanged;
        }

        // Reacts to changes in powermode
        private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs powerModeChangedEventArgs)
        {
            switch (powerModeChangedEventArgs.Mode)
            {
                case PowerModes.Suspend:
                    SaveWindowsState();
                    break;
                case PowerModes.Resume:
                    RestoreWindowsState();
                    break;
                case PowerModes.StatusChange:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RestoreWindowsState()
        {
            var form = (RestoreMonitorForm)Form.ActiveForm;

            // Restore monitor state
            form?.RestoreState("Resume restore state: ");
        }

        private void SaveWindowsState()
        {
            var form = (RestoreMonitorForm)Form.ActiveForm;

            // Restore monitor state
            form?.SaveState("Sleep save state: ");
        }
    }
}
