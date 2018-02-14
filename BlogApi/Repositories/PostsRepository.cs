using System;
using System.Collections.Generic;
using System.Linq;
using BlogApi.Entities;
using BlogApi.Repositories.Contracts;

namespace BlogApi.Repositories
{
    public class PostsRepository : IRepository<Post>
    {
        private readonly BlogDbContext _dbContext;

        public PostsRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Post> GetAll()
        {
            return _dbContext.Posts.ToList();
        }

        public Post Get(object search)
        {
            return _dbContext.Posts.FirstOrDefault(post => post.Slug == search.ToString());
        }

        public Post Create(Post postRequest)
        {
            postRequest.CreatedAt = DateTime.Now;

            _dbContext.Posts.Add(postRequest);

            _dbContext.SaveChanges();

            return postRequest;
        }
    }
}