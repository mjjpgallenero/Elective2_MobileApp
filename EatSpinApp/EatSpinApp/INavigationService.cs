using Xamarin.Forms;

namespace EatSpinApp
{
    public interface INavigationService
    {
        void GoBack();
        void NavigateTo(AppPages pageKey);
        void NavigateTo(AppPages pageKey, object parameter);
    }
}