using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AOEChat.Server.Core.Specifications;
using System.Linq.Expressions;


namespace AOEChat.Server.Core.Data
{
    public interface IRepository<T> where T : class
    {
        //IEnumerable<T> Find(params Specification<T>[] specifications);
        //void Add(T item);
        //void Update(T item);
        //void Remove(T item);
        //void ClearCache(T item);

        IEnumerable<T> SelectAll();
        T SelectByID(object id);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();

    }
}
