using System.Collections.Generic;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Votes;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models.Users
{
    public class User: IdentityUser, IEntity<string>
    {
        public string Name { get; set; }

        public ICollection<Voting> CreatedVoting { get; set; }
        
        public ICollection<UserVoting> UserVoting { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}