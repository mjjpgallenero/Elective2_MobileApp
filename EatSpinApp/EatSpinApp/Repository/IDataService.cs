namespace EatSpinApp.Repository
{
    public interface IDataService<T> where T: class
    {
        void Add(T record);
        T Get();
        int Update(T record);
        int Delete(T record);

    }
}