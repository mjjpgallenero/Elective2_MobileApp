using System.Collections.ObjectModel;
using System.Windows.Input;
using EatSpinApp.Enums;
using EatSpinApp.Models;
using EatSpinApp.Repository;
using EatSpinApp.Repository.LocalRepository;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace EatSpinApp.ViewModels
{
    public class SetRestaurantFiltersViewModel : ObservableObject
    {
        private IRepository repository;
        private readonly INavigationService _navigationService;
        private Restaurant _selectedRestaurant;

        public SetRestaurantFiltersViewModel(INavigationService navigationService)
        {
            repository = new LocalRepository();
            var restaurants = repository.Restaurant.GetRange();
            foreach (var restaurant in restaurants)
            {
                RestaurantList.Add(restaurant);
            }

            _navigationService = navigationService;
            SelectedRestaurant = null;
        }

        public ObservableCollection<Restaurant> RestaurantList { get; } = new ObservableCollection<Restaurant>();

        public Restaurant SelectedRestaurant
        {
            get { return _selectedRestaurant; }
            set
            {
                _selectedRestaurant = value; 
                RaisePropertyChanged(nameof(SelectedRestaurant));
            }
        }
        
        public ICommand OpenAddNewRestaurantView => new Command(OpenAddNewRestaurantViewProc);

        private void OpenAddNewRestaurantViewProc()
        {
            _navigationService.NavigateTo(AppPages.AddNewRestaurantView);
            //RefreshRestaurantList();
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

                SelectedRestaurant = null;
            }
        }

        public void RefreshRestaurantList()
        {
            RestaurantList.Clear();
            var restaurants = repository.Restaurant.GetRange();
            foreach (var restaurant in restaurants)
            {
                RestaurantList.Add(restaurant);
            }
            SelectedRestaurant = null;
        }

    }
}