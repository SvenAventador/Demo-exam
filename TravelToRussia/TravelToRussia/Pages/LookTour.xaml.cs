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
    /// Логика взаимодействия для LookTour.xaml
    /// </summary>
    public partial class LookTour : Page
    {

        private List<Entities.Tour> _tours = new List<Entities.Tour>();
        private string _SelectedType;
        private string _FindName;

        public LookTour()
        {
            InitializeComponent();
            ListTours.ItemsSource = Entities.ToursDBEntities.GetContext().Tours.OrderBy(p => p.Name).ToList();

            List<Entities.Type> types = new List<Entities.Type>();
            types.Add(new Entities.Type() { Name = "Все типы" });
            types.AddRange(Entities.ToursDBEntities.GetContext().Types.OrderBy(t => t.Name).ToList());

            typeBox.ItemsSource = types;

            this._tours = Entities.ToursDBEntities.GetContext().Tours.ToList();

        }

        private void nameTour_TextChanged(object sender, TextChangedEventArgs e)
        {
            _FindName = nameTour.Text;

            _tours = Entities.ToursDBEntities.GetContext().Tours.OrderBy(t => t.Name).ToList();

            RefreshTours();

        }

        /// <summary>
        /// Создание метода для одновременной работы всех 3-х методов фильстрации
        /// </summary>
        private void RefreshTours()
        {
            if (typeBox.SelectedItem != null)
            {
                if ((typeBox.SelectedItem as Entities.Type).Name != "Все типы")
                {
                    Entities.Type type = typeBox.SelectedItem as Entities.Type;

                    _tours = Entities.ToursDBEntities.GetContext().Tours.OrderBy(t => t.Name).ToList();

                    _SelectedType = type.Name;
                    _tours = (from t in _tours from tn in t.Types where tn.Name == _SelectedType select t).ToList();
                }
                else if ((typeBox.SelectedItem as Entities.Type).Name == "Все типы")
                {
                    _tours = Entities.ToursDBEntities.GetContext().Tours.OrderBy(m => m.Name).ToList();
                }
            }


            if (nameTour.Text != "")
            {
                _tours = _tours.OrderBy(n => n.Name).Where(n => n.Name.ToLower().Contains(_FindName)).ToList();
            }

            if ((bool)IsActual.IsChecked)
                _tours = _tours.OrderBy(n => n.Name).Where(n => n.IsActual == true).ToList();

            ListTours.ItemsSource = _tours;
        }

        private void typeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Entities.Type type = typeBox.SelectedItem as Entities.Type;
            _tours = Entities.ToursDBEntities.GetContext().Tours.OrderBy(t => t.Name).ToList();

            RefreshTours();

        }

        private void IsActual_Checked(object sender, RoutedEventArgs e)
        {

            _tours = Entities.ToursDBEntities.GetContext().Tours.OrderBy(t => t.Name).ToList();
            RefreshTours();

        }

        private void IsActual_Unchecked(object sender, RoutedEventArgs e)
        {

            _tours = Entities.ToursDBEntities.GetContext().Tours.OrderBy(t => t.Name).ToList();
            RefreshTours();

        }
    }
}
