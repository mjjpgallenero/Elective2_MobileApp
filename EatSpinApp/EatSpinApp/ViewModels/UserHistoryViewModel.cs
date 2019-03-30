using System.Collections.ObjectModel;
using EatSpinApp.Models;
using GalaSoft.MvvmLight;

namespace EatSpinApp.ViewModels
{
    public class UserHistoryViewModel : ObservableObject
    {
        //private readonly MainPageViewModel _mainPageViewModel;
        private readonly INavigationService _navigationService;

        public UserHistoryViewModel(INavigationService navigationService)
        {
            //_mainPageViewModel = mainPageViewModel;
            _navigationService = navigationService;
        }

        public ObservableCollection<Restaurant> ConfirmedRestaurants { get; } = new ObservableCollection<Restaurant>();


    }
}