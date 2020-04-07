using AsyncDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void normalExecute_ButtonClick(object sender, RoutedEventArgs e)
        {
            resultWindow.Text = string.Empty;

            var watch = Stopwatch.StartNew();

            RunDownload(ReportWebsiteInfo);

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;

            resultWindow.Text += $"Total execution time: {elapsedMs}. {Environment.NewLine}";
        }

        private async void asyncExecute_ButtonClick(object sender, RoutedEventArgs e)
        {
            resultWindow.Text = string.Empty;

            var watch = Stopwatch.StartNew();

            Progress<ProgressReport> progress = new Progress<ProgressReport>();
            progress.ProgressChanged += ReportProgress;

            await RunDownloadAsync(ReportWebsiteInfo, progress);

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;

            resultWindow.Text += $"Total execution time: {elapsedMs}";
        }

        private void ReportProgress(object sender, ProgressReport e)
        {
            progressOfWork.Value = e.DownloadPercent;
        }

        private async void parallelAsyncExecute_Click(object sender, RoutedEventArgs e)
        {
            resultWindow.Text = string.Empty;

            var watch = Stopwatch.StartNew();

            await RunDownloadParallelAsync(ReportWebsiteInfo);

            watch.Stop();

            var elapsedMs = watch.ElapsedMilliseconds;

            resultWindow.Text += $"Total execution time: {elapsedMs}";
        }

        private void progressOfWork_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
        }

        private static List<string> PrepData()
        {
            List<string> websites = new List<string>();

            websites.Add("https://www.yahoo.com");
            websites.Add("https://www.google.com");
            websites.Add("https://www.stackoverflow.com");

            return websites;
        }

        private void RunDownload(Action<Website> ReportWebsiteInfo)
        {
            List<string> websites = PrepData();

            foreach (var item in websites)
            {
                Website website = DownloadWebsite(item);

                ReportWebsiteInfo(website);
            }
        }

        private async Task RunDownloadAsync(Action<Website> ReportWebsiteInfo, IProgress<ProgressReport> progress)
        {
            List<string> websites = PrepData();

            List<Task<Website>> tasks = new List<Task<Website>>();

            ProgressReport report = new ProgressReport();

            foreach (var item in websites)
            {
                //Website website = await Task.Run(() => DownloadWebsite(item));

                Website website = await DownloadWebsiteAsync(item);

                report.DownloadedWebsites.Add(website);
                report.DownloadPercent = (report.DownloadedWebsites.Count * 100) / websites.Count;

                progress.Report(report);

                ReportWebsiteInfo(website);
            }
        }

        private async Task RunDownloadParallelAsync(Action<Website> ReportWebsiteInfo)
        {
            List<string> websites = PrepData();

            List<Task<Website>> tasks = new List<Task<Website>>();

            foreach (var item in websites)
            {
                //tasks.Add(Task.Run(() => DownloadWebsite(item)));

                tasks.Add(DownloadWebsiteAsync(item));
            }

            Website[] results = await Task.WhenAll(tasks);

            foreach (var item in results)
            {
                ReportWebsiteInfo(item);
            }
        }

        private Website DownloadWebsite(string weburl)
        {
            Website website = new Website();

            WebClient client = new WebClient();

            website.Url = weburl;
            website.Content = client.DownloadString(weburl);


            return website;
        }

        private async Task<Website> DownloadWebsiteAsync(string weburl)
        {
            Website website = new Website();

            WebClient client = new WebClient();

            website.Url = weburl;
            website.Content = await client.DownloadStringTaskAsync(weburl);

            return website;
        }

        private void ReportWebsiteInfo(Website website)
        {
            resultWindow.Text += $"{website.Url} downloaded: {website.Content.Length} charecter. {Environment.NewLine}";
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
