namespace EatSpinApp.Repository.LocalRepository
{
    public class LocalDataService<T> : IDataService<T> where T : class, new()
    {
        public void Add(T record)
        {
            throw new System.NotImplementedException();
        }
    }
}