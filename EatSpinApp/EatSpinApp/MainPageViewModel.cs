using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public MainPageViewModel()
        {
            repository = new LocalRepository();
            TestCommand = new Command(async () => await OpenTestCommand());
        }
        public string TestEntry { get; set; }
        public ObservableCollection<Restaurant> TestList { get; } = new ObservableCollection<Restaurant>();
        public ICommand TestCommand { get; private set; }

        private async Task OpenTestCommand()
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

    }
}