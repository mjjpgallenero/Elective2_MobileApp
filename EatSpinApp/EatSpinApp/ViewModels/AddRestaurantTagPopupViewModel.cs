using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using EatSpinApp.Converters;
using EatSpinApp.Enums;
using EatSpinApp.Models;
using EatSpinApp.Repository;
using EatSpinApp.Repository.LocalRepository;
using EatSpinApp.ViewModels;
using GalaSoft.MvvmLight;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EatSpinApp
{
    public class AddRestaurantTagPopupViewModel : ObservableObject
    {
        private IRepository repository;
        private readonly INavigationService _navigationService;
        private string _selectedRestaurantTag;
        private readonly SetRestaurantFiltersViewModel _setRestaurantFiltersViewModel;
        private string _selectedRestaurantLocation;

        public AddRestaurantTagPopupViewModel(INavigationService navigationService, SetRestaurantFiltersViewModel setRestaurantFiltersViewModel)
        {
            repository = new LocalRepository();
            _navigationService = navigationService;
            _setRestaurantFiltersViewModel = setRestaurantFiltersViewModel;
        }

        public string SelectedRestaurantTag
        {
            get { return _selectedRestaurantTag; }
            set
            {
                _selectedRestaurantTag = value;
                RaisePropertyChanged(nameof(SelectedRestaurantTag));
            }
        }

        public string SelectedRestaurantLocation
        {
            get { return _selectedRestaurantLocation; }
            set
            {
                _selectedRestaurantLocation = value;
                RaisePropertyChanged(nameof(SelectedRestaurantLocation));
            }
        }

        public string[] RestaurantTags { get; } = Enum.GetNames(typeof(RestaurantTags)).Select(c => c.SplitCamelCase()).ToArray();
        public string[] RestaurantLocations { get; } = Enum.GetNames(typeof(Locations)).Select(c => c.SplitCamelCase()).ToArray();

        public ICommand AddRestaurantTagCommand => new Command(AddRestaurantTagProc);

        private void AddRestaurantTagProc()
        {
            if (SelectedRestaurantTag == null && SelectedRestaurantLocation == null)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please select at least one field.", "Ok");
            }
            else
            {
                if (SelectedRestaurantTag != null) _setRestaurantFiltersViewModel.RestaurantTags.Add(SelectedRestaurantTag);
                if (SelectedRestaurantLocation != null) _setRestaurantFiltersViewModel.RestaurantLocations.Add(SelectedRestaurantLocation);
                SelectedRestaurantTag = null;
                SelectedRestaurantLocation = null;
                PopupNavigation.Instance.PopAsync();
            }
        }
    }
}