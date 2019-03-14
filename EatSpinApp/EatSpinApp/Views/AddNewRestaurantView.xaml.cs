using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EatSpinApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewRestaurantView : ContentPage
	{
		public AddNewRestaurantView ()
		{
			InitializeComponent ();
		    BindingContext = App.Locator.NewRestaurantViewModel;
		}

	    protected override void OnAppearing()
	    {
	        base.OnAppearing();
	        App.Locator.NewRestaurantViewModel.RestaurantName = null;
	        App.Locator.NewRestaurantViewModel.SelectedRestaurantType = null;
	        App.Locator.NewRestaurantViewModel.SelectedCuisineType = null;
	    }
	}
}