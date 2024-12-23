using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;




namespace Zayavki.Pages
{
    public partial class Navigation : Page
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void CreateZayavkaButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CreateZayavka());
        }

        private void HistoryZayavkaButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HistoryZayavka());
        }
    }
}
