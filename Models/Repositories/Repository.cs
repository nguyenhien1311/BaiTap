using BaiTap.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BaiTap.Models.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MyDbContext db;
        private DbSet<T> tbl;

        public Repository()
        {
            db = new MyDbContext();
            tbl = db.Set<T>();
        }

        public List<T> Get()
        {
            return tbl.ToList();
        }

        public List<T> Get(Func<T, bool> predicate)
        {
            return tbl.Where(predicate).ToList();
        }

        public T Get(int id)
        {
            return tbl.Find(id);
        }

        public bool Add(T entity)
        {
            try
            {
                tbl.Add(entity);
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(T entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                tbl.Remove(Get(id));
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}