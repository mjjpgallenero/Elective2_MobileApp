using System;
using System.IO;
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
                navigationService.Configure(AppPages.RestaurantDatabaseView, typeof(RestaurantDatabaseView));
                navigationService.Configure(AppPages.AddNewRestaurantView, typeof(AddNewRestaurantView));
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
                db.CreateTable<Restaurant>();
                var restaurants = db.Table<Restaurant>();
                var restaurantList = restaurants.ToList();

                if (restaurantList.Count == 0)
                {
                    var repo = new LocalRepository();
                    repo.Restaurant.Add(new Restaurant{RestaurantName = "Test2", RestaurantType = "Fine Dining", CuisineType = "Japanese", ContactNumber = "1234"});
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
