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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {

        private Entities.Hotel hotel;
        private int _currentPage = 1;
        private int _maxPage = 0;

        public HotelsPage()
        {
            InitializeComponent();
            RefreshHotel();
        }

        public void RefreshHotel()
        {
            DBGrid.ItemsSource = Entities.ToursDBEntities.GetContext().Hotels.OrderBy(h => h.Name).ToList();

            _maxPage = (int)Math.Ceiling(Entities.ToursDBEntities.GetContext().Hotels.ToList().Count * 1.0 / 10);

            var listHotels = Entities.ToursDBEntities.GetContext().Hotels.ToList().Skip((_currentPage - 1) * 10).Take(10).ToList();

            labelTotalPage.Text = "of " + _maxPage.ToString();  
            txtCurrentNumber.Text = _currentPage.ToString();

            DBGrid.ItemsSource = listHotels;
        } 

        private void editData_Click(object sender, RoutedEventArgs e)
        {
            Class.Manager.MainFrame.Navigate(new Pages.AddEditPage((sender as Button).DataContext as Entities.Hotel));
        }

        private void addData_Click(object sender, RoutedEventArgs e)
        {
            Class.Manager.MainFrame.Navigate(new Pages.AddEditPage(null));
        }

        private void deleteData_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemove = DBGrid.SelectedItems.Cast<Entities.Hotel>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemove.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities.ToursDBEntities.GetContext().Hotels.RemoveRange(hotelsForRemove);
                    Entities.ToursDBEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены успешно!");
                    DBGrid.ItemsSource = Entities.ToursDBEntities.GetContext().Hotels.OrderBy(p => p.Name).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                Entities.ToursDBEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DBGrid.ItemsSource = Entities.ToursDBEntities.GetContext().Hotels.OrderBy(p => p.Name).ToList();
            }

        }

        private void GoFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshHotel();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage - 1 < 1)
                return;
            _currentPage--;
            RefreshHotel();
        }

        private void txtCurrentNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_currentPage > 0 && _currentPage < _maxPage)
            {
                _currentPage = int.Parse(txtCurrentNumber.Text);
                RefreshHotel();
            }
        }

        private void GoNext_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage + 1 > _maxPage)
                return;
            _currentPage++;
            RefreshHotel();
        }

        private void GoLast_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPage;
            RefreshHotel();
        }
    }
}
