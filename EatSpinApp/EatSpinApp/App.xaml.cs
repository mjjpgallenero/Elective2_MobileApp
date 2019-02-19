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
            navigationService = new NavigationService();


            MainPage = new NavigationPage(new MainPage()); 
            
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
