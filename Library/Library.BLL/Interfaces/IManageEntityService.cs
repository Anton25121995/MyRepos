using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IManageEntityService<T> where T : class
    {
        IEnumerable<T> GetEntities();
        T GetEntity(int? id);
        void CreateEntity(T entity);
        void SaveEntity();
        void Delete();
    }
}

