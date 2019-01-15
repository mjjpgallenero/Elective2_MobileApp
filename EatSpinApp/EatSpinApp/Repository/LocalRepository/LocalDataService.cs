using System;
using System.IO;
using EatSpinApp.Models;
using SQLite;

namespace EatSpinApp.Repository.LocalRepository
{
    public class LocalDataService<T> : IDataService<T> where T : class, new()
    {
        //private static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
        //private SQLiteConnection db = new SQLiteConnection(dbPath);

        public void Add(T record)
        {
            throw new NotImplementedException();
            //db.CreateTable<Restaurant>();
        }
        public T Get()
        {
            throw new NotImplementedException();
        }

        public int Update(T record)
        {
            throw new NotImplementedException();
        }

        public int Delete(T record)
        {
            throw new NotImplementedException();
        }
    }
}