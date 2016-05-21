using System;
using System.Net.Http;
using System.Windows;

namespace AsyncWPF
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

        private async void buttonGetHtml_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri(textBoxUrl.Text);

                textBoxHtml.Text = "Please wait...";

                var html = await client.GetStringAsync(url);

                textBoxHtml.Text = html;
            }
        }
    }
}
