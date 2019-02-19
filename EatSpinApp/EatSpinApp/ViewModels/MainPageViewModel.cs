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
        private IRepository repository;
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            repository = new LocalRepository();
            var restaurants = repository.Restaurant.GetRange();
            foreach (var restaurant in restaurants)
            {
                TestList.Add(restaurant);
            }
            _navigationService = navigationService;
        }
        public string TestEntry { get; set; }
        public string TestSpinItem { get; set; }
        public ObservableCollection<Restaurant> TestList { get; } = new ObservableCollection<Restaurant>();
        public ICommand TestCommand => new Command(OpenTestCommand);
        private void OpenTestCommand()
        {
            TestList.Clear();
            repository.Restaurant.Add(new Restaurant { RestaurantName = TestEntry });
            var restaurants = repository.Restaurant.GetRange();
            foreach (var restaurant in restaurants)
            {
                TestList.Add(restaurant);
            }
            //TestList.Add(new Restaurant{RestaurantName = TestEntry});
        }
        public ICommand TestDelete => new Command(DeleteTestCommand);
        private void DeleteTestCommand()
        {
            var restaurant = TestList.LastOrDefault();
            repository.Restaurant.Delete(restaurant);
            TestList.Clear();
            var restos = repository.Restaurant.GetRange();
            foreach (var resto in restos)
            {
                TestList.Add(resto);
            }
        }

        public ICommand TestNavigate => new Command(TestNavigateCommand);
        private void TestNavigateCommand()
        {
            _navigationService.NavigateTo(AppPages.TestPage);
        }
    }
}