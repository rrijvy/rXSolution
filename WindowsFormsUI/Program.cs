using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Dashboard());
        }


        static void LaunchApplication(string selectedApp)
        {

            var path = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\" + "ubuntu" + ".exe");

            if (path != null)
            {
                if (path != null)
                {
                    string address = path.GetValue(null) as string;

                    if (!string.IsNullOrEmpty(address))
                    {
                        Process.Start(address);
                    }
                    else
                    {
                        // Path not found
                    }
                }
                else
                {
                    // Registry key not found
                }
            }
            else
            {
                // Application not found
            }

        }
    }
}
