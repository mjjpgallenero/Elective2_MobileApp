using EatSpinApp.Models;

namespace EatSpinApp.Repository.LocalRepository
{
    public class LocalRepository : IRepository
    {
        public IDataService<Restaurant> Restaurant { get; } = new LocalDataService<Restaurant>();
    }
}