using CRUD.Common;
using CRUD.Common.Interfaces;
using CRUD.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class BaseCrudController<T> : ControllerBase, IBaseCrudController<T> where T : BaseEntity
    {
        private readonly IBaseCrudRepository<T> _repository;

        public BaseCrudController(IBaseCrudRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpPost("GetAll")]
        public async Task<IEnumerable<T>>? GetAll([FromBody] GetRequest<T>? request = null)
        {
            return await _repository.GetAll(request);
        }

        [HttpGet("{id}")]
        public async Task<T>? Get(string id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost]
        public async Task<T> Post(T entity)
        {
            return await _repository.Add(entity);
        }

        [HttpPut]
        public async Task<T>? Put(T entity)
        {
            return await _repository.Update(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _repository.Delete(id);
        }
    }
}
