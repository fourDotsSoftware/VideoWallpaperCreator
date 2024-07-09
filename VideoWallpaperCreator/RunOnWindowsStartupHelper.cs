using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace VideoWallpaperCreator
{
    public class RunOnWindowsStartupHelper
    {
        public static bool GetRunOnWindowsStartup()
        {
            return GetRunOnWindowsStartup(Module.ApplicationName);
        }

        public static bool GetRunOnWindowsStartup(string application)
        {
            RegistryKey key = Registry.CurrentUser;

            try
            {
                key = key.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", false);

                if (key == null)
                {
                    return false;
                }

                if (key.GetValue(application) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Module.ShowError("Error could not get run at Windows Startup value !", ex);
            }

            return false;
        }

        public static bool SetRunAtWindowsStartup(bool enabled,string args)
        {
            return SetRunAtWindowsStartup(Module.ApplicationName, Application.ExecutablePath, args, enabled);
        }

        public static bool SetRunAtWindowsStartup(string applicationName, string exefilepath, string args, bool enabled)
        {
            return RunAdminAction("-runstartupcu \"" + enabled.ToString() + "\" \"" + applicationName + "\" \"" +
             exefilepath + "\" \"" + args + "\"");
        }

        public static bool RunAdminAction(string args)
        {
            try
            {
                System.Diagnostics.Process pr = new System.Diagnostics.Process();
                pr.StartInfo.FileName = Application.StartupPath + "\\4dotsAdminActions.exe";
                pr.StartInfo.Arguments = args;
                pr.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                pr.Start();

                System.Threading.Thread.Sleep(300);

                while (!pr.HasExited)
                {
                    Application.DoEvents();
                }

                if (pr.ExitCode != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
