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
        }

        public MainPageViewModel MainPageViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }
        public RestaurantDatabaseViewModel RestaurantDatabaseViewModel
        {
            get { return ServiceLocator.Current.GetInstance<RestaurantDatabaseViewModel>(); }
        }
    }
}