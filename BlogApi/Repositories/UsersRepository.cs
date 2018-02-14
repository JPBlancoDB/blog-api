using System;
using System.Collections.Generic;
using System.Linq;
using BlogApi.Entities;
using BlogApi.Repositories.Contracts;

namespace BlogApi.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private readonly BlogDbContext _blogDbContext;

        public UsersRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        public IList<User> GetAll()
        {
            return _blogDbContext.Users.ToList();
        }

        public User Get(object id)
        {
            return _blogDbContext.Users.Find(id);
        }

        public User Create(User userRequest)
        {
            userRequest.CreatedAt = DateTime.Now;
            
            _blogDbContext.Users.Add(userRequest);

            _blogDbContext.SaveChanges();

            return userRequest;
        }
    }
}