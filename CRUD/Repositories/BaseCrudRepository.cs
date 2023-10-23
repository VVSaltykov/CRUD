using CRUD.Common;
using CRUD.Common.Interfaces;
using CRUD.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repositories
{
    public class BaseCrudRepository<T> : IBaseCrudRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext dbContext;

        public BaseCrudRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<T> Add(T entity)
        {
            var addedEntity = (await dbContext.AddAsync(entity)).Entity;
            dbContext.SaveChanges();
            return addedEntity;
        }

        public void Delete(string entityId)
        {
            var entity = dbContext.Find<T>(entityId);
            if (entity != null) dbContext.Remove(entity);
            dbContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll(GetRequest<T> request)
        {
            IQueryable<T> query = dbContext.Set<T>();

            if (request.Filter != null)
            {
                query = query.Where(request.Filter);
            }

            if (request.OrderBy != null)
            {
                query = request.OrderBy(query);
            }

            if (request.Skip.HasValue)
            {
                query = query.Skip(request.Skip.Value);
            }

            if (request.Take.HasValue)
            {
                query = query.Take(request.Take.Value);
            }

            return query.ToList();
        }

        public async Task<T>? GetById(string entityId)
        {
            return await dbContext.FindAsync<T>(entityId);
        }

        public async Task<T> Update(T entity)
        {
            var updatedEntity = dbContext.Update(entity).Entity;
            await dbContext.SaveChangesAsync();
            return updatedEntity;
        }
    }
}
