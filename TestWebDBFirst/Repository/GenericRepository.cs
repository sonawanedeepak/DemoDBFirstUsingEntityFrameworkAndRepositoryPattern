using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestWebDBFirst.Models;

namespace TestWebDBFirst.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DBFirstPracticeEntities empDBContext = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            empDBContext = new DBFirstPracticeEntities();
            table = empDBContext.Set<T>();
        }
        public void Delete(T obj)
        {
            //T existing = table.Find(obj);
            table.Remove(obj);
        }

        public IQueryable<T> GetAll()
        {
            return table;
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void save()
        {
            empDBContext.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            empDBContext.Entry(obj).State = EntityState.Modified;
        }
    }
}