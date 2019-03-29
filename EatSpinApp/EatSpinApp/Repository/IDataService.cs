using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using EatSpinApp.Models;

namespace EatSpinApp.Repository
{
    public interface IDataService<T> where T: class
    {
        void Add(T record);
        T Get(Expression<Func<T, bool>> condition = null);
        List<T> GetRange(Expression<Func<T, bool>> condition = null);
        int Update(T record);
        int Delete(T record);

    }
}