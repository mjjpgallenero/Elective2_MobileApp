using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using EatSpinApp.Enums;
using EatSpinApp.Models;
using EatSpinApp.Repository;
using EatSpinApp.Repository.LocalRepository;
using EatSpinApp.Views;
using GalaSoft.MvvmLight;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace EatSpinApp.ViewModels
{
    public class SetRestaurantFiltersViewModel : ObservableObject
    {
        private IRepository repository;
        private readonly INavigationService _navigationService;
        private MainPageViewModel _mainPageViewModel;
        private string _selectedRestaurantTag;
        private string _selectedRestaurantLocation;

        public SetRestaurantFiltersViewModel(INavigationService navigationService, MainPageViewModel mainPageViewModel)
        {
            _navigationService = navigationService;
            _mainPageViewModel = mainPageViewModel;
            SelectedRestaurantTag = null;
        }

        public ObservableCollection<string> RestaurantTags { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> RestaurantLocations { get; } = new ObservableCollection<string>();

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

        public ICommand OpenAddNewRestaurantFilterCommand => new Command(OpenAddNewRestaurantFilterProc);

        private void OpenAddNewRestaurantFilterProc()
        {
            PopupNavigation.Instance.PushAsync(new AddRestaurantTagPopupView());
            //_navigationService.NavigateTo(AppPages.AddNewRestaurantFilterView);
            //RefreshRestaurantList();
        }

        public ICommand DeleteRestaurantFilterCommand => new Command(DeleteRestaurantFilterProc);

        private void DeleteRestaurantFilterProc()
        {
            if (SelectedRestaurantTag != null)
            {
                RestaurantTags.Remove(SelectedRestaurantTag);
                SelectedRestaurantTag = null;
                if (RestaurantTags.Count == 0 && RestaurantLocations.Count == 0)
                    _mainPageViewModel.RefreshRestaurantList();
            }

            if (SelectedRestaurantLocation != null)
            {
                RestaurantLocations.Remove(SelectedRestaurantLocation);
                SelectedRestaurantLocation = null;
                if (RestaurantTags.Count == 0 && RestaurantLocations.Count == 0)
                    _mainPageViewModel.RefreshRestaurantList();
            }
        }

        public ICommand ApplyFiltersCommand => new Command(ApplyFiltersProc);

        private void ApplyFiltersProc()
        {
            if (RestaurantTags.Count == 0)
                Application.Current.MainPage.DisplayAlert("Error", "No filters selected.", "Ok");
            else
            {
                Application.Current.MainPage.DisplayAlert("Confirmation",
                    "Apply filters to randomized search?", "OK",
                    "Cancel").ContinueWith(t =>
                {
                    if (t.Result)
                    {
                        if (RestaurantTags.Count == 0) _mainPageViewModel.RefreshRestaurantList();

                        else
                        {
                            var originalList = _mainPageViewModel.RestaurantList;
                            var filteredListByTag = new List<Restaurant>();
                            var filteredListByLocation = new List<Restaurant>();
                            var list = new List<Restaurant>();

                            foreach (var restaurant in originalList)
                            {
                                foreach (var tag in RestaurantTags)
                                {
                                    if (restaurant.RestaurantTag == tag) filteredListByTag.Add(restaurant);
                                }

                                foreach (var restaurantLocation in RestaurantLocations)
                                {
                                    if (restaurant.Location == restaurantLocation) filteredListByLocation.Add(restaurant);
                                }
                            }

                            if (filteredListByTag.Count != 0 && filteredListByLocation.Count == 0)
                            {
                                list = filteredListByTag;
                                _mainPageViewModel.RestaurantList.Clear();
                                _mainPageViewModel.RandomizedRestaurant = null;
                                foreach (var restaurant in list)
                                {
                                    _mainPageViewModel.RestaurantList.Add(restaurant);
                                }
                            }
                            else if (filteredListByTag.Count == 0 && filteredListByLocation.Count != 0)
                            {
                                list = filteredListByLocation;
                                _mainPageViewModel.RestaurantList.Clear();
                                _mainPageViewModel.RandomizedRestaurant = null;
                                foreach (var restaurant in list)
                                {
                                    _mainPageViewModel.RestaurantList.Add(restaurant);
                                }
                            }
                            else
                            {
                                foreach (var restaurant in filteredListByTag)
                                {
                                    foreach (var restaurant1 in filteredListByLocation)
                                    {
                                        if (restaurant1.Location == restaurant.Location) list.Add(restaurant);
                                    }
                                }
                                _mainPageViewModel.RestaurantList.Clear();
                                _mainPageViewModel.RandomizedRestaurant = null;
                                foreach (var restaurant in list)
                                {
                                    _mainPageViewModel.RestaurantList.Add(restaurant);
                                }
                            }

                        }
                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        public ICommand ClearRestaurantFilterCommand => new Command(ClearRestaurantFilterProc);

        private void ClearRestaurantFilterProc()
        {
            SelectedRestaurantTag = null;
            SelectedRestaurantLocation = null;
            RestaurantTags.Clear();
            RestaurantLocations.Clear();
            _mainPageViewModel.RefreshRestaurantList();
        }
       

    }
}