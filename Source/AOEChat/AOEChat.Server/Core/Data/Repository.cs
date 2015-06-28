using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AOEChat.Server.Data;
using System.Linq.Expressions;

namespace AOEChat.Server.Core.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private AOEChatEntities db = null;
        private DbSet<T> table = null;
        //protected Table<T> DataTable;

        public Repository()
        {
            this.db = new AOEChatEntities();
            table = db.Set<T>();
        }

        public Repository(AOEChatEntities db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            //return table;
            return table.ToList();
        }

        public T SelectByID(object id)
        {
            return table.Find(id);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return table.Where(predicate);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public IQueryable<T> Items()
        {
            return table;
        }
    }
}


         //#region IRepository<T> Members

         //   public void Insert(T entity)
         //   {
         //       DataTable.InsertOnSubmit(entity);
         //   }

         //   public void Delete(T entity)
         //   {
         //       DataTable.DeleteOnSubmit(entity);
         //   }

         //   public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
         //   {
         //       return DataTable.Where(predicate);
         //   }

         //   public IQueryable<T> GetAll()
         //   {
         //       return DataTable;
         //   }

         //   public T GetById(int id)
         //   {
         //       // Sidenote: the == operator throws NotSupported Exception!
         //       // 'The Mapping of Interface Member is not supported'
         //       // Use .Equals() instead
         //       return DataTable.Single(e => e.ID.Equals(id));
         //   }

         //   #endregion

