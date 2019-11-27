using System.Collections.Generic;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Votes;

namespace DataAccessLayer.Models.Users
{
    public class User: Entity<int>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Voting> CreatedVoting { get; set; }
        
        public ICollection<UserVoting> UserVoting { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}