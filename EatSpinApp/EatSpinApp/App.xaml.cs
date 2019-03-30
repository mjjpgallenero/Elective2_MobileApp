using System;
using System.IO;
using EatSpinApp.Enums;
using EatSpinApp.Models;
using EatSpinApp.Repository.LocalRepository;
using EatSpinApp.Views;
using GalaSoft.MvvmLight.Ioc;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace EatSpinApp
{
	public partial class App : Application
	{
	    private static ViewModelLocator _locator;
	    public static ViewModelLocator Locator
	    {
	        get
	        {
	            return _locator ?? (_locator = new ViewModelLocator());
	        }
	    }
        public App ()
		{
			InitializeComponent();
		    InitializeApp();

            INavigationService navigationService;

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                // Setup navigation service:
                navigationService = new NavigationService();

                // Configure pages:
                navigationService.Configure(AppPages.MainPage, typeof(MainPage));
                navigationService.Configure(AppPages.SetRestaurantFiltersView, typeof(SetRestaurantFiltersView));
                navigationService.Configure(AppPages.UserHistoryView, typeof(UserHistoryView));
                navigationService.Configure(AppPages.MainNavigationPage, typeof(MainNavigationPage));

                // Register NavigationService in IoC container:
                SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            }

            else
                navigationService = SimpleIoc.Default.GetInstance<INavigationService>();

            // Create new Navigation Page and set MainPage as its default page:

            var firstPage = new NavigationPage(new MainNavigationPage());
            navigationService.Initialize(firstPage);
            MainPage = firstPage;

        }
	    protected static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Restaurants.db3");

        private void InitializeApp()
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.DropTable<Restaurant>();
                db.CreateTable<Restaurant>();
                var restaurants = db.Table<Restaurant>();
                var restaurantList = restaurants.ToList();

                if (restaurantList.Count == 0)
                {
                    var repo = new LocalRepository();
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Jollibee", ContactNumber = "#87000", RestaurantTag = "Fast Food", Location = "Downtown", Address = "Gov Duterte Street"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "McDonald's", ContactNumber = "86236", RestaurantTag = "Fast Food", Location = "Downtown", Address = "Quirino Ave."});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Taps", ContactNumber = "300-8277", RestaurantTag = "Fast Food", Location = "Downtown", Address = "Bolton Street"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Mang Inasal", ContactNumber = "297-7004", RestaurantTag = "Diner", Location = "Downtown", Address = "Bolton Street"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Mandarin Tea Garden", ContactNumber = "305-8321", RestaurantTag = "Chinese", Location = "Bolton Street", Address = "Bolton Street"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Junex Tuna & Seafood", ContactNumber = "327-5305", RestaurantTag = "Sea Food", Location = "South", Address = "Bangkal"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Kitsune", ContactNumber = " 0942-049-0846", RestaurantTag = "Japanese", Location = "South", Address = "Juna Subdivision"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Manna", ContactNumber = "297-0472", RestaurantTag = "Korean", Location = "South", Address = "SM City Davao"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Out of Nowhere", ContactNumber = "0933-865-5959", RestaurantTag = "Diner", Location = "South", Address = "Acacia Street"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Davao Famous", ContactNumber = "227-3715", RestaurantTag = "Chinese", Location = "South", Address = "Mac Arthur Highway"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Classio Pizza", ContactNumber = "0942-499-8560", RestaurantTag = "Fast Food", Location = "North", Address = "J.P. Laurel Ave"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Yellow Cab", ContactNumber = "235-3333", RestaurantTag = "Fast Food", Location = "North", Address = "Damosa, Lanang"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Swiss Deli", ContactNumber = "234-0271", RestaurantTag = "Fine Dining", Location = "North", Address = "J.P. Laurel Ave"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Vikings", ContactNumber = "285-3888", RestaurantTag = "Buffet", Location = "North", Address = "SM Lanang"});
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Gangnam", ContactNumber = "233-2115", RestaurantTag = "Korean", Location = "North", Address = "Abreeza Mall"});
                }
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
