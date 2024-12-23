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
    public partial class AddZayavka : Page
    {
        private Zayavka _currentZayavka;

        public AddZayavka(Zayavka selectedZayavka = null)
        {
            InitializeComponent();
            _currentZayavka = selectedZayavka ?? new Zayavka();
            DataContext = _currentZayavka;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentZayavka.FIO))
                errors.AppendLine("Укажите ФИО!");
            if (string.IsNullOrWhiteSpace(_currentZayavka.phone))
                errors.AppendLine("Укажите телефон!");
            if (string.IsNullOrWhiteSpace(_currentZayavka.email))
                errors.AppendLine("Укажите email!");
            if (!_currentZayavka.date_of_note.HasValue)
                errors.AppendLine("Выберите дату заявки!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            using (var context = new ZayavkaContext())
            {
                try
                {
                    if (_currentZayavka.ID == 0)
                    {
                        context.Zayavka.Add(_currentZayavka);
                    }
                    else
                    {
                        var zayavkaToUpdate = context.Zayavka.Find(_currentZayavka.ID);
                        if (zayavkaToUpdate != null)
                        {
                            zayavkaToUpdate.FIO = _currentZayavka.FIO;
                            zayavkaToUpdate.phone = _currentZayavka.phone;
                            zayavkaToUpdate.email = _currentZayavka.email;
                            zayavkaToUpdate.date_of_note = _currentZayavka.date_of_note;
                        }
                        else
                        {
                            MessageBox.Show("Заявка не найдена в базе данных.");
                            return;
                        }
                    }

                    context.SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}");
                }
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
