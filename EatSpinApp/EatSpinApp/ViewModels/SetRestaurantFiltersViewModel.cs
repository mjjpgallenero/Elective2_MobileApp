using System.Collections.ObjectModel;
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
        private string _selectedRestaurantTag;

        public SetRestaurantFiltersViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SelectedRestaurantTag = null;
        }

        public ObservableCollection<string> RestaurantTags { get; } = new ObservableCollection<string>();

        public string SelectedRestaurantTag
        {
            get { return _selectedRestaurantTag; }
            set
            {
                _selectedRestaurantTag = value; 
                RaisePropertyChanged(nameof(SelectedRestaurantTag));
            }
        }
        
        public ICommand OpenAddNewRestaurantView => new Command(OpenAddNewRestaurantViewProc);

        private void OpenAddNewRestaurantViewProc()
        {
            PopupNavigation.Instance.PushAsync(new AddRestaurantTagPopupView());
            //_navigationService.NavigateTo(AppPages.AddNewRestaurantFilterView);
            //RefreshRestaurantList();
        }

        public ICommand DeleteRestaurantCommand => new Command(DeleteRestaurantProc);

        private void DeleteRestaurantProc()
        {
            if (SelectedRestaurantTag != null)
            {
                RestaurantTags.Remove(SelectedRestaurantTag);
                SelectedRestaurantTag = null;
            }
        }

        //public void RefreshRestaurantList()
        //{
        //    RestaurantList.Clear();
        //    var restaurants = repository.Restaurant.GetRange();
        //    foreach (var restaurant in restaurants)
        //    {
        //        RestaurantList.Add(restaurant);
        //    }
        //    SelectedRestaurant = null;
        //}

    }
}