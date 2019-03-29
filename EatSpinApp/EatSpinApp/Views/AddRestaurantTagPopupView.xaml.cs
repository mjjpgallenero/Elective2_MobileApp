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
	public partial class AddRestaurantTagPopupView
    {
		public AddRestaurantTagPopupView ()
		{
			InitializeComponent ();
            BindingContext = App.Locator.AddRestaurantTagPopupViewModel;
        }
	}
}