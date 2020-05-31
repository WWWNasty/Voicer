using System.Collections.Generic;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Votes;
using Microsoft.AspNetCore.Identity;

namespace DataAccessLayer.Models.Users
{
    public class User : IdentityUser, IEntity<string>
    {
        // [Required]
        // [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 100 символов")]
        // public string Name { get; set; }

        public ICollection<Voting> CreatedVoting { get; set; }

        public ICollection<UserVoting> UserVoting { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}