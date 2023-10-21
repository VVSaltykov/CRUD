using CRUD.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Common.Interfaces
{
    public interface IBaseCrudController<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>>? GetAll(GetRequest<T>? request);
        public Task<T>? Get(string id);
        public Task<T> Post(T entity);
        public Task<T>? Put(T entity);
        public void Delete(string id);
    }
}
