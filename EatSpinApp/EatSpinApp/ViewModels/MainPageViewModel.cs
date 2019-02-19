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

namespace EatSpinApp
{
    public class MainPageViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public string TestSpinItem { get; set; }

        public ICommand TestNavigate => new Command(TestNavigateCommand);
        private void TestNavigateCommand()
        {
            _navigationService.NavigateTo(AppPages.RestaurantDatabaseView);
        }
    }
}