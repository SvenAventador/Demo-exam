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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TravelToRussia.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Entities.Hotel _currentHotels = new Entities.Hotel();

        public AddEditPage(Entities.Hotel selectedHotel)
        {
            InitializeComponent();
            countryHotel.ItemsSource = Entities.ToursDBEntities.GetContext().Countries.OrderBy(p => p.Name).ToList();

            if (selectedHotel != null)
                _currentHotels = selectedHotel;

            DataContext = _currentHotels;
        }

        private void saveData_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentHotels.Name))
                errors.AppendLine("Укажите название отеля");
            if (_currentHotels.CountOfStars < 1 || _currentHotels.CountOfStars > 5)
                errors.AppendLine("Количество звезд может быть от 1 до 5");
            if (_currentHotels.Country == null)
                errors.AppendLine("Выберите страну");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentHotels.Id == 0)
                Entities.ToursDBEntities.GetContext().Hotels.Add(_currentHotels);

            try
            {
                Entities.ToursDBEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена успешно");
                Class.Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
