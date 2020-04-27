using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Models.Votes
{
    public class VotingOption : IEntity<int>
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        public Voting Voting { get; set; }
    }
}