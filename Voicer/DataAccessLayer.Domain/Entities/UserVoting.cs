namespace DataAccessLayer.Models.Entities
{
    public class UserVoting
    {
        public User User { get; set; }

        public Voting Voting { get; set; }
    }
}