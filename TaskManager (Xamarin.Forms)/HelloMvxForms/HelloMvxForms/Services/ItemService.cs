using HelloMvxForms.Constants;
using HelloMvxForms.Interfaces;
using HelloMvxForms.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloMvxForms.Services
{
    class ItemService : IDataBaseService<Item>
    {
        private static SQLiteConnection db = null;

        static ItemService()
        {
            var dbPath = Constant.DbFilePath;
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Item>();
        }

        public ItemService()
        {

        }

        public IEnumerable<Item> GetAllInstances()
        {
            var table = db.Table<Item>();
            foreach (var x in table)
            {
                yield return x;
            }
        }

        public IEnumerable<Item> GetInstances(int id)
        {
            var table = db.Table<Item>().Where(x => x.UserId == id);
            foreach (var x in table)
            {
                yield return x;
            }
        }

        public Item GetInstance(int id)
        {
            var table = db.Table<Item>();
            return table.Where(p => p.Id == id).FirstOrDefault();
        }


        public void CreateInstance(Item item)
        {
            db.Insert(item);
        }

        public void UpdateInstance(Item item)
        {
            db.Update(item);
        }

        public void InsertInstance(Item item)
        {
            db.Insert(item);
        }

        public void DeleteInstance(Item item)
        {
            db.Delete(item);
        }

        public Item FindInstance(int id)
        {
            var table = db.Table<Item>().ToList();
            return table.Where(x => x.Id == id).FirstOrDefault();
        }


        public void UpdateTable()
        {
            var table = db.Table<Item>();
            db.UpdateAll(table);
        }

        public void ClearTable()
        {
            db.DeleteAll<Item>();
        }
    }
}
