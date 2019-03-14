using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using EatSpinApp.Converters;
using EatSpinApp.Models;
using EatSpinApp.Repository;
using EatSpinApp.Repository.LocalRepository;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace EatSpinApp
{
    public class NewRestaurantViewModel : ObservableObject
    {
        private IRepository repository;
        private readonly INavigationService _navigationService;
        private string _restaurantName;
        private string _selectedRestaurantType;
        private string _selectedCuisineType;
        private RestaurantDatabaseViewModel _restaurantDatabaseViewModel;

        public NewRestaurantViewModel(INavigationService navigationService, RestaurantDatabaseViewModel restaurantDatabaseViewModel)
        {
            repository = new LocalRepository();
            _navigationService = navigationService;
            _restaurantDatabaseViewModel = restaurantDatabaseViewModel;
        }

        public string RestaurantName
        {
            get { return _restaurantName; }
            set
            {
                _restaurantName = value;
                RaisePropertyChanged(nameof(RestaurantName));
            }
        }

        public string SelectedRestaurantType
        {
            get { return _selectedRestaurantType; }
            set
            {
                _selectedRestaurantType = value;
                RaisePropertyChanged(nameof(SelectedRestaurantType));
            }
        }

        public string[] RestaurantTypes { get; } = Enum.GetNames(typeof(RestaurantType)).Select(c => c.SplitCamelCase()).ToArray();

        public string SelectedCuisineType
        {
            get { return _selectedCuisineType; }
            set
            {
                _selectedCuisineType = value; 
                RaisePropertyChanged(nameof(SelectedCuisineType));
            }
        }

        public string[] CuisineTypes { get; } = Enum.GetNames(typeof(CuisineType)).Select(c => c.SplitCamelCase()).ToArray();
        public ICommand AddNewRestaurant => new Command(AddNewRestaurantProc);

        private void AddNewRestaurantProc()
        {
            if (RestaurantName == null || SelectedRestaurantType == null || SelectedCuisineType == null)
            {
                Application.Current.MainPage.DisplayAlert("Error", "One or more fields is/are missing.", "Ok");
            }
            else
            {
                var newRestaurant = new Restaurant();
                newRestaurant.RestaurantName = RestaurantName;
                newRestaurant.RestaurantType = SelectedRestaurantType;
                newRestaurant.CuisineType = SelectedCuisineType;
                repository.Restaurant.Add(newRestaurant);
                _restaurantDatabaseViewModel.RefreshRestaurantList();
                _navigationService.GoBack();
            }
        }
    }
}