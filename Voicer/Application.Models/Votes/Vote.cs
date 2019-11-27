using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Users;

namespace DataAccessLayer.Models.Votes
{
    public class Vote: Entity<int>
    {
        public VotingOption VotingOption { get; set; }

        public User User { get; set; }

        public Voting Voting { get; set; }
    }
}