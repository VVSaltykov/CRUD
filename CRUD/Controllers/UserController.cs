using CRUD.Common.Interfaces;
using CRUD.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseCrudController<User>
    {
        public UserController(IBaseCrudRepository<User> repository) : base(repository)
        {
        }
    }
}
