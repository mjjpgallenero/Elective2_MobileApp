using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EatSpinApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RestaurantDatabaseView : ContentPage
	{
		public RestaurantDatabaseView ()
		{
			InitializeComponent ();
            BindingContext = App.Locator.RestaurantDatabaseViewModel;
        }
	}
}