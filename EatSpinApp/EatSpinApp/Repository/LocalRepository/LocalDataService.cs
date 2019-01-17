﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using EatSpinApp.Models;
using SQLite;

namespace EatSpinApp.Repository.LocalRepository
{
    public class LocalDataService<T> : IDataService<T> where T : class, new()
    {
        private static readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal));
        //private SQLiteConnection db = new SQLiteConnection(dbPath);

        public void Add(T record)
        {
            using (var db = new SQLiteConnection(dbPath))
            {
                db.CreateTable<Restaurant>();
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
                return db.Table<T>().Where(condition).ToList();
            }
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