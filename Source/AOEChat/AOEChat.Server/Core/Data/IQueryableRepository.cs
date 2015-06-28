using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AOEChat.Server.Data;

namespace AOEChat.Server.Core.Data
{
    public interface IQueryableRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> Items { get; }
    }
}
