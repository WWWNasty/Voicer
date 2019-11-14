using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Models.Votes
{
    public class VotingOption : Entity<int>
    {
        public string Name { get; set; }
    }
}