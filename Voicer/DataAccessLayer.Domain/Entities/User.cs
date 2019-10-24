using System.Collections.Generic;

namespace DataAccessLayer.Models.Entities
{
    public class User: Entity<int>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Voting> CreatedVoting { get; set; }
        
        public ICollection<UserVoting> UserVoting { get; set; }
    }
}