using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EatSpinApp.Annotations;
using EatSpinApp.Models;
using EatSpinApp.Repository;
using EatSpinApp.Repository.LocalRepository;
using GalaSoft.MvvmLight.Command;

namespace EatSpinApp
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private IRepository repository;
        public void Test()
        {
            repository = new LocalRepository();
        }

        public string TestEntry { get; set; }
        public RelayCommand OpenTest => new RelayCommand(OpenTestCommand);

        private void OpenTestCommand()
        {
            repository.Restaurant.Add(new Restaurant{RestaurantName = TestEntry});
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}