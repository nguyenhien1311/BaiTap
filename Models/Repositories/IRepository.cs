using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap.Models.Repositories
{
    interface IRepository<T> where T : class
    {
        List<T> Get();
        List<T> Get(Func<T,bool> predicate);
        T Get(int id);
        bool Add(T entity);
        bool Edit(T entity);
        bool Remove(int id);
        void Save();
    }
}
