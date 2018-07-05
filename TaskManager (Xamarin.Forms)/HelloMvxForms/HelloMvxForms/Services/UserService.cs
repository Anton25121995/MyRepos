using HelloMvxForms.Constants;
using HelloMvxForms.Interfaces;
using HelloMvxForms.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace HelloMvxForms.Services
{

    class UserService : IDataBaseService<User>
    {
        private static SQLiteConnection db = null;

        static UserService()
        {
            var dbPath = Constant.DbFilePath;
            db = new SQLiteConnection(dbPath);
            db.CreateTable<User>();
        }

        public UserService()
        {

        }

        public IEnumerable<User> GetAllInstances()
        {
            var table = db.Table<User>();
            foreach (var x in table)
            {
                yield return x;
            }
        }

        public IEnumerable<User> GetInstances(int id)
        {
            var table = db.Table<User>().Where(x=>x.Id==id);
            foreach (var x in table)
            {
                yield return x;
            }
        }
        
        public User GetInstance(int id)
        {
            var table = db.Table<User>();
            return table.Where(p => p.Id == id).FirstOrDefault();
        }

        
        public void CreateInstance(User user)
        {
            db.Insert(user);
        }

        public void UpdateInstance(User user)
        {
            db.Update(user);
        }

        public void InsertInstance(User user)
        {
            db.Insert(user);
        }

        public void DeleteInstance(User user)
        {
            db.Delete(user);
        }

        public User FindInstance(int id)
        {
            var table = db.Table<User>().ToList();
            return table.Where(x => x.Id == id).FirstOrDefault();
        }


        public void UpdateTable()
        {
            var table = db.Table<User>();
            db.UpdateAll(table);
        }

        public void ClearTable()
        {
            db.DeleteAll<User>();
        }
    }
}
