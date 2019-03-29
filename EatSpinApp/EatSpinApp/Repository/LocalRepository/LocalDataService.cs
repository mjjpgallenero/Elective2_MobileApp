using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq.Expressions;
using EatSpinApp.Models;
using SQLite;

namespace EatSpinApp.Repository.LocalRepository
{
    public class LocalDataService<T> : IDataService<T> where T : class, new()
    {
        protected static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Restaurants.db3");
        //private SQLiteConnection db = new SQLiteConnection(dbPath);

        public void Add(T record)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.Insert(record);
            }
        }

        public T Get(Expression<Func<T, bool>> condition)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                return db.Table<T>().FirstOrDefault(condition);
            }
        }

        public List<T> GetRange(Expression<Func<T, bool>> condition = null)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                if(condition == null)  return db.Table<T>().ToList();
                else return db.Table<T>().Where(condition).ToList();
            }
        }

        public int Update(T record)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                return db.Update(record);
            }
        }

        public int Delete(T record)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                return db.Delete(record);
            }
        }
    }
}