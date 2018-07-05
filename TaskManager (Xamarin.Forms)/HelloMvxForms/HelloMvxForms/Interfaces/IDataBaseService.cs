using HelloMvxForms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloMvxForms.Interfaces
{
    public interface IDataBaseService<T> where T : class
    {
        IEnumerable<T> GetAllInstances();
        IEnumerable<T> GetInstances(int id);
        T GetInstance(int id);

        void CreateInstance(T obj);
        void UpdateInstance(T obj);
        void InsertInstance(T obj);
        void DeleteInstance(T obj);
        T FindInstance(int id);

        void UpdateTable();
        void ClearTable();
    }
}
