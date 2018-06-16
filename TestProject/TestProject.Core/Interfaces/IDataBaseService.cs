using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.Models;

namespace TestProject.Core.Interfaces
{
    public interface IDataBaseService
    {
        IEnumerable<Item> GetAllItems();
        Item GetItem(int id);
        void CreateItem(Item item);
        void ClearTable();
        void UpdateItem(Item item);
        void UpdateTable();
        void InsertItem(Item obj);
        void DeleteItem(Item obj);
    }
}
