using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Users;

namespace DataAccessLayer.Models.Votes
{
    public class Vote: IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        public int VotingOptionId { get; set; }
        
        public VotingOption VotingOption { get; set; }
        
        [Required]
        public string UserId { get; set; }
        
        public User User { get; set; }

        [Required]
        public int VotingId { get; set; }
        
        public Voting Voting { get; set; }

        
    }
}