using CRUD.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Common
{
    public class GetRequest<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Filter { get; set; } = null;
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; set; } = null;
        public int? Skip { get; set; } = null;
        public int? Take { get; set; } = null;
    }
}
