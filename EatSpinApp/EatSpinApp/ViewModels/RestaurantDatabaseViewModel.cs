using System.Collections.ObjectModel;
using System.Windows.Input;
using EatSpinApp.Models;
using EatSpinApp.Repository;
using EatSpinApp.Repository.LocalRepository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace EatSpinApp
{
    public class RestaurantDatabaseViewModel : ObservableObject
    {
        private IRepository repository;
        private readonly INavigationService _navigationService;
        private string _restaurantNameEntry;
        private Restaurant _selectedRestaurant;

        public RestaurantDatabaseViewModel(INavigationService navigationService)
        {
            repository = new LocalRepository();
            var restaurants = repository.Restaurant.GetRange();
            foreach (var restaurant in restaurants)
            {
                RestaurantList.Add(restaurant);
            }

            _navigationService = navigationService;
            RestaurantNameEntry = null;
            SelectedRestaurant = null;
        }

        public ObservableCollection<Restaurant> RestaurantList { get; } = new ObservableCollection<Restaurant>();

        public string RestaurantNameEntry
        {
            get { return _restaurantNameEntry; }
            set
            {
                _restaurantNameEntry = value;
                RaisePropertyChanged(nameof(RestaurantNameEntry));
            }
        }

        public Restaurant SelectedRestaurant
        {
            get { return _selectedRestaurant; }
            set
            {
                _selectedRestaurant = value; 
                RaisePropertyChanged(nameof(SelectedRestaurant));
            }
        }

        public ICommand AddRestaurantCommand => new Command(AddRestaurantProc);

        private void AddRestaurantProc()
        {
            if (RestaurantNameEntry != null)
            {
                RestaurantList.Clear();
                repository.Restaurant.Add(new Restaurant {RestaurantName = RestaurantNameEntry});
                var restaurants = repository.Restaurant.GetRange();
                foreach (var restaurant in restaurants)
                {
                    RestaurantList.Add(restaurant);
                }

                RestaurantNameEntry = null;
                SelectedRestaurant = null;
            }
        }

        public ICommand DeleteRestaurantCommand => new Command(DeleteRestaurantProc);

        private void DeleteRestaurantProc()
        {
            if (SelectedRestaurant != null)
            { 
                repository.Restaurant.Delete(SelectedRestaurant);
                RestaurantList.Clear();
                var restaurants = repository.Restaurant.GetRange();
                foreach (var restaurant in restaurants)
                {
                    RestaurantList.Add(restaurant);
                }

                RestaurantNameEntry = null;
                SelectedRestaurant = null;
            }
        } 

    }
}