using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using EatSpinApp.Annotations;
using EatSpinApp.Enums;
using EatSpinApp.Models;
using EatSpinApp.Repository;
using EatSpinApp.Repository.LocalRepository;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EatSpinApp
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private IRepository repository;
        private Restaurant _randomizedRestaurant;

        static Random random = new Random();

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            repository = new LocalRepository();
            foreach (var restaurant in repository.Restaurant.GetRange())
            {
                RestaurantList.Add(restaurant);
            }
        }

        public Restaurant RandomizedRestaurant
        {
            get { return _randomizedRestaurant; }
            set
            {
                _randomizedRestaurant = value;
                RaisePropertyChanged(nameof(RandomizedRestaurant));
            }
        }

        public ObservableCollection<Restaurant> RestaurantList { get; } = new ObservableCollection<Restaurant>();

        public ICommand SpinCommand => new Command(SpinProc);

        private void SpinProc()
        {
            if (RestaurantList.Count > 0)
            {
                int r = random.Next(RestaurantList.Count);
                RandomizedRestaurant = RestaurantList[r];
            }
        }

        public ICommand NavigateToSettingsCommand => new Command(NavigateToSettingsProc);

        private void NavigateToSettingsProc()
        {
            _navigationService.NavigateTo(AppPages.SetRestaurantFiltersView);
        }

        public void RefreshRestaurantList()
        {
            RestaurantList.Clear();
            var restaurants = repository.Restaurant.GetRange();
            foreach (var restaurant in restaurants)
            {
                RestaurantList.Add(restaurant);
            }
            RandomizedRestaurant = null;
        }
    }
}