using System.Linq;
using BlogApi.Entities;
using BlogApi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IRepository<User> _usersRepository;

        public UsersController(IRepository<User> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _usersRepository.GetAll();

            if (!users.Any())
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _usersRepository.Get(id);

            if (user == null)
            {
                return NotFound(id);
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User userRequest)
        {
            var user = _usersRepository.Create(userRequest);

            return CreatedAtRoute("GetUserById", new {id = user.Id}, user);
        }
    }
}