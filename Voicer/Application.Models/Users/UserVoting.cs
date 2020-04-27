using DataAccessLayer.Models.Votes;

namespace DataAccessLayer.Models.Users
{
    public class UserVoting
    {
        public User User { get; set; }

        public Voting Voting { get; set; }

        public int VotingId { get; set; }

        public string UserId { get; set; }
    }
}