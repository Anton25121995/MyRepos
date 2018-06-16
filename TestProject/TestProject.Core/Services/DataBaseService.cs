using MvvmCross.Core.ViewModels;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TestProject.Core.Interfaces;
using TestProject.Core.Models;

namespace TestProject.Core.Services
{
    class DataBaseService : IDataBaseService
    {
        private static SQLiteConnection db = null;

        static DataBaseService()
        {
            var dbPath = Constant.DbFilePath;
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Item>();
        }

        public DataBaseService()
        {

        }

        public IEnumerable<Item> GetAllItems()
        {
            var table = db.Table<Item>();
            foreach (var x in table)
            {
                yield return x;
            }
        }

        public void ClearTable()
        {
            db.DeleteAll<Item>();
        }

        public Item GetItem(int id)
        {
            return db.Get<Item>(p => p.Id == id);
        }

        public void CreateItem(Item item)
        {
            db.Insert(item);
        }

        public void UpdateItem(Item item)
        {
            db.Update(item);
        }

        public void UpdateTable()
        {
            var table = db.Table<Item>();
            db.UpdateAll(table);
        }

        public void InsertItem(Item item)
        {
            db.Insert(item);
        }

        public void DeleteItem(Item item)
        {
            db.Delete(item);
        }
    }
}
