using System;

namespace BlogApi.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public string Slug { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public User Author { get; set; }
    }
}