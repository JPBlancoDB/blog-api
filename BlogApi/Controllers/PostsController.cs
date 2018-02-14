using System.Linq;
using BlogApi.Entities;
using BlogApi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design.Internal;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IRepository<Post> _postsRepository;

        public PostsController(IRepository<Post> postsRepository)
        {
            _postsRepository = postsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postsRepository.GetAll();

            if (!posts.Any())
            {
                return NotFound();
            }

            return Ok(posts);
        }

        [HttpGet("{slug}")]
        public IActionResult Get(string slug)
        {
            var post = _postsRepository.Get(slug);

            if (post == null)
            {
                return NotFound(slug);
            }

            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Post postRequest)
        {
            var post = _postsRepository.Create(postRequest);

            return CreatedAtRoute("GetPostBySlug", new {slug = post.Slug}, post);
        }
    }
}