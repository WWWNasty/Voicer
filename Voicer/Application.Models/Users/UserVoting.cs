using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Votes;

namespace DataAccessLayer.Models.Users
{
    public class UserVoting
    {
        public User User { get; set; }

        public Voting Voting { get; set; }

        [Required]
        public int VotingId { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}