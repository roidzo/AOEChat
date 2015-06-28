using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace AOEChat.Server.Core.Specifications
{
    interface ISpecification<T>
    {
        Expression<Func<T, bool>> Predicate { get; }

        bool IsSatisfiedBy(T entity);

    }
}
