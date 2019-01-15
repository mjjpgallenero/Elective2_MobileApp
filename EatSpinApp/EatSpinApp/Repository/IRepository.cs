using EatSpinApp.Models;

namespace EatSpinApp.Repository
{
    public interface IRepository
    {
        IDataService<Restaurant> Restaurant { get; }
    }
}