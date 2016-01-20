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

namespace WpfAsync      
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

        private async void buttonAsync_Click(object sender, RoutedEventArgs e) // guzik działający asynchronicznie
        {
            buttonAsync.IsEnabled = false; // guzik działajacy asynchronicznie ustawiony na wartosc false
            
            var slowTask = Task<string>.Factory.StartNew(() => SlowDude()); // zmienna potrzeba do asynchronicznosci
            
            textBoxResults.Text += "Spokojnie chlopie zaraz odpowiem\r\n"; // Pierwsza odpowiedz po wcisnieciu guzika            
            
            await slowTask;             

            textBoxResults.Text += slowTask.Result.ToString(); //rezultat
            
            buttonAsync.IsEnabled = true;
        }

        private string SlowDude() //zmienna prywatna
        {
            Thread.Sleep(2000); //watek zadziała po 2 sekundach 
            return "Czesc to ja ;) !\r\n"; // odpowiedz
        }      
        
    }
}
