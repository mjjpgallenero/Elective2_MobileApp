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
            SimpleIoc.Default.Register<AddRestaurantTagPopupViewModel>();
            SimpleIoc.Default.Register<UserHistoryViewModel>();
        }

        public MainPageViewModel MainPageViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }
        public SetRestaurantFiltersViewModel SetRestaurantFiltersViewModel
        {
            get { return ServiceLocator.Current.GetInstance<SetRestaurantFiltersViewModel>(); }
        }

        public AddRestaurantTagPopupViewModel AddRestaurantTagPopupViewModel
        {
            get { return ServiceLocator.Current.GetInstance<AddRestaurantTagPopupViewModel>(); }
        }

        public UserHistoryViewModel UserHistoryViewModel
        {
            get { return ServiceLocator.Current.GetInstance<UserHistoryViewModel>(); }
        }
    }
}