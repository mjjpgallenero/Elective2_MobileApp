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
        }

        public MainPageViewModel MainPageViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }
    }
}