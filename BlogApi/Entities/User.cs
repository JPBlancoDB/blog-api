using System;

namespace BlogApi.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? LastLoggedAt { get; set; }        
    }
}