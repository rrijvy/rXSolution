using DemoLibrary.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> installedApps = GetInstalledApps();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Name", DataPropertyName = "Name" });
            dataGridView1.Columns.Add(new DataGridViewButtonColumn() { HeaderText = "Button" });


            foreach (var app in installedApps)
            {
                var button = new Button();
                button.Text = "Start";
                button.Click += StartButton_Click;

                dataGridView1.Rows.Add(app.Key, button);
            }
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CLICKED");

            if (((Button)sender).Tag is string appPath) Process.Start(appPath);
        }
        private Dictionary<string, string> GetInstalledApps()
        {
            Dictionary<string, string> appsList = new Dictionary<string, string>();

            RegistryKey appsKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths");

            if (appsKey == null) return appsList;

            string[] appNames = appsKey.GetSubKeyNames();

            foreach (string appName in appNames)
            {
                RegistryKey appKey = appsKey.OpenSubKey(appName);

                var appPath = appKey?.GetValue(null);

                if(appPath == null) continue;

                appsList.Add(appName, appPath.ToString());
            }

            appsKey.Close();

            return appsList;
        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
