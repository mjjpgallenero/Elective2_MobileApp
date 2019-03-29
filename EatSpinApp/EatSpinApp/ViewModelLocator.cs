using CommonServiceLocator;
using EatSpinApp.ViewModels;
using GalaSoft.MvvmLight.Ioc;

namespace EatSpinApp
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider((() => SimpleIoc.Default));
            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<SetRestaurantFiltersViewModel>();
            SimpleIoc.Default.Register<NewRestaurantViewModel>();
        }

        public MainPageViewModel MainPageViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }
        public SetRestaurantFiltersViewModel SetRestaurantFiltersViewModel
        {
            get { return ServiceLocator.Current.GetInstance<SetRestaurantFiltersViewModel>(); }
        }

        public NewRestaurantViewModel NewRestaurantViewModel
        {
            get { return ServiceLocator.Current.GetInstance<NewRestaurantViewModel>(); }
        }
    }
}