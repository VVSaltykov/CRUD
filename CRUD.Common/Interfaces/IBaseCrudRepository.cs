using CRUD.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Common.Interfaces
{
    public interface IBaseCrudRepository<T> where T : BaseEntity
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        void Delete(string entityId);
        Task<IEnumerable<T>> GetAll(GetRequest<T>? request);
        Task<T>? GetById(string entityId);
    }
}
