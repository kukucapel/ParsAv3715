using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.NetworkInformation;
using System.Net;



namespace ParsAv3715
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected string path = "./config.txt";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Downloader(object sender, RoutedEventArgs e)
        {
            //Process.Start(new ProcessStartInfo { FileName = @"http://google.com", UseShellExecute = true });
            //var numberSession = 1;
            string numberSession = File.ReadAllText(path);
            var ping = new System.Net.NetworkInformation.Ping();
            //string numberSession = "52893943";
            string[] urls = Urls.Text.Split('\n');
            var result = ping.Send("av3715.ru");
            if (result.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                for (int i = 0; i < urls.Length; i++)
                { 
                    string url = "https://mk.av3715.ru:443/КНИГИ/" + numberSession + "/" + urls[i].Replace(" ", "%20") + ".rar";
                    Process.Start(new ProcessStartInfo { FileName = @url, UseShellExecute = true });
                    MessageBox.Show(url);
                    
                }
            }
            else
            {
                MessageBox.Show("Нет соединения с av3715.ru");
            }
        }
    }
}