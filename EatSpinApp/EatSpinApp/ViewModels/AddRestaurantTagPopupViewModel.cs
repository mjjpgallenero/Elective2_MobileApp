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
        private SetRestaurantFiltersViewModel _setRestaurantFiltersViewModel;

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

        public string[] RestaurantTags { get; } = Enum.GetNames(typeof(RestaurantTags)).Select(c => c.SplitCamelCase()).ToArray();

        public ICommand AddRestaurantTagCommand => new Command(AddRestaurantTagProc);

        private void AddRestaurantTagProc()
        {
            if (SelectedRestaurantTag == null)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please select a tag.", "Ok");
            }
            else
            {
                _setRestaurantFiltersViewModel.RestaurantTags.Add(SelectedRestaurantTag);
                //_setRestaurantFiltersViewModel.RefreshRestaurantList();
                PopupNavigation.Instance.PopAsync();
            }
        }
    }
}