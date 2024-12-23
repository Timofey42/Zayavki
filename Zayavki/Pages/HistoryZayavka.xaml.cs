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
    public partial class HistoryZayavka : Page
    {
        public HistoryZayavka()
        {
            InitializeComponent();
            LoadZayavkas();
        }

        // Метод для загрузки заявок из базы данных
        private void LoadZayavkas()
        {
            using (var context = new ZayavkaContext())
            {
                // Получаем все записи из таблицы Zayavka
                var zayavkas = context.Zayavka.ToList();

                // Привязываем данные к DataGrid
                ZayavkaDataGrid.ItemsSource = zayavkas;
            }
        }
    }
}