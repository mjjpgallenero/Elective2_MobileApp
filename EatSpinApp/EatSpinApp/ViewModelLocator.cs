using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace EatSpinApp
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider((() => SimpleIoc.Default));
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<RestaurantDatabaseViewModel>();
            SimpleIoc.Default.Register<NewRestaurantViewModel>();
        }

        public MainPageViewModel MainPageViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }
        public RestaurantDatabaseViewModel RestaurantDatabaseViewModel
        {
            get { return ServiceLocator.Current.GetInstance<RestaurantDatabaseViewModel>(); }
        }

        public NewRestaurantViewModel NewRestaurantViewModel
        {
            get { return ServiceLocator.Current.GetInstance<NewRestaurantViewModel>(); }
        }
    }
}