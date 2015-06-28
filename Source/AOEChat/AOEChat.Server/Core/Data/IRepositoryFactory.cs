using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOEChat.Server.Core.Data
{
    public interface IRepositoryFactory<T> where T : class
    {
        IQueryableRepository<T> Repository();
    }
}
