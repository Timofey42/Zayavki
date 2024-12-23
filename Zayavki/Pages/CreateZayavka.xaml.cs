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
    public partial class CreateZayavka : Page
    {
        public CreateZayavka()
        {
            InitializeComponent();
            LoadZayavki(); // Загружаем список всех заявок
        }

        // Метод для загрузки всех заявок из базы данных
        private void LoadZayavki()
        {
            try
            {
                using (var context = new ZayavkaContext()) // Используем правильный контекст
                {
                    var zayavki = context.Zayavka.ToList(); // Загружаем заявки
                    DataGridZayavka.ItemsSource = zayavki; // Привязываем к DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var zayavka = button?.DataContext as Zayavka;

            if (zayavka != null)
            {
                using (var context = new ZayavkaContext())
                {
                    var zayavkaEntity = context.Zayavka.FirstOrDefault(z => z.ID == zayavka.ID);
                    if (zayavkaEntity != null)
                    {
                        NavigationService.Navigate(new Pages.AddZayavka(zayavkaEntity));
                    }
                    else
                    {
                        MessageBox.Show("Заявка не найдена в базе данных.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Не удалось получить данные для редактирования.");
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddZayavka(null)); // Переход на добавление заявки
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var selectedZayavki = DataGridZayavka.SelectedItems.Cast<Zayavka>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить записи в количестве {selectedZayavki.Count} элементов?",
                                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new ZayavkaContext())
                    {
                        foreach (var zayavka in selectedZayavki)
                        {
                            var zayavkaToRemove = context.Zayavka.Find(zayavka.ID);
                            if (zayavkaToRemove != null)
                            {
                                context.Zayavka.Remove(zayavkaToRemove);
                            }
                        }
                        context.SaveChanges();
                        MessageBox.Show("Данные успешно удалены!");
                        LoadZayavki();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}");
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                LoadZayavki(); // Загружаем данные снова
            }
        }
    }
}
