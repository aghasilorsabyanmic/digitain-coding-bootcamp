using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SomeApp
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

        private async void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            buttonLoad.IsEnabled = false;
            var input = textBoxInput.Text;
            
                textBoxOutput.Text = input;
            
            var slowTask = Task<string>.Factory.StartNew(() => SlowFunction(input));
            textBoxOutput.Text += "\nDoing other things while waiting for that slow function...\r\n";
            await slowTask;
            textBoxOutput.Text += slowTask.Result;

            buttonLoad.IsEnabled = true;
        }
        public string SlowFunction(string some)
        {
            Thread.Sleep(5000);
            return some;
        }
    }
}
