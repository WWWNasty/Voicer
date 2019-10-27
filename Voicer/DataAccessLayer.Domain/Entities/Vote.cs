namespace DataAccessLayer.Models.Entities
{
    public class Vote: Entity<int>
    {
        public VotingOption VotingOption { get; set; }

        public User User { get; set; }

        public Voting Voting { get; set; }
    }
}