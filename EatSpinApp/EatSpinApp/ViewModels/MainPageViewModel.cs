using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using EatSpinApp.Annotations;
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
        private string _testSpinItem;
        static Random random = new Random();
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            repository = new LocalRepository();
        }

        public string TestSpinItem
        {
            get { return _testSpinItem; }
            set
            {
                _testSpinItem = value;
                RaisePropertyChanged(nameof(TestSpinItem));
            }
        }

        public ICommand TestSpin => new Command(TestSpinProc);

        private void TestSpinProc()
        {
            var restaurants = repository.Restaurant.GetRange();
            if (restaurants.Count > 0)
            {
                int r = random.Next(restaurants.Count);
                TestSpinItem = restaurants[r].RestaurantName;
            }
        }

        public ICommand TestNavigate => new Command(TestNavigateCommand);
        private void TestNavigateCommand()
        {
            _navigationService.NavigateTo(AppPages.RestaurantDatabaseView);
        }
    }
}