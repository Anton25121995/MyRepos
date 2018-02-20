using Library.BLL.Interfaces;
using Library.DAL.Repositories;
using System.Collections.Generic;

namespace Library.BLL.Services
{
    public abstract class BaseService<T> where T : class
    {
        private BaseRepository<T> repository;

        public virtual BaseRepository<T> Repository
        {
            get { return repository; }
            set {; }
        }

        public IEnumerable<T> GetEntities()
        {
            var entities = Repository.GetAll();
            return entities;
        }

        public T GetEntity(int id)
        {
            var entity = Repository.GetById(id);
            return entity;
        }

        public void CreateEntity(T entity)
        {
            Repository.Add(entity);
        }

        public void Delete(T entity)
        {
            Repository.Delete(entity);
        }
    }
}


