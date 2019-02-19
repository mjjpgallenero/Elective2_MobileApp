using System;
using System.IO;
using EatSpinApp.Models;
using EatSpinApp.Repository.LocalRepository;
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
		    using (var db = new SQLiteConnection(dbPath))
		    {
		        db.CreateTable<Restaurant>();
		    }

            INavigationService navigationService;

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                // Setup navigation service:
                navigationService = new NavigationService();

                // Configure pages:
                navigationService.Configure(AppPages.MainPage, typeof(MainPage));
                navigationService.Configure(AppPages.TestPage, typeof(TestPage));

                // Register NavigationService in IoC container:
                SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            }

            else
                navigationService = SimpleIoc.Default.GetInstance<INavigationService>();

            // Create new Navigation Page and set MainPage as its default page:
            var firstPage = new NavigationPage(new MainPage());
            // Set Navigation page as default page for Navigation Service:
            navigationService.Initialize(firstPage);
            // You have to also set MainPage property for the app:
            MainPage = firstPage;

        }
	    protected static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Restaurants.db3");

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
