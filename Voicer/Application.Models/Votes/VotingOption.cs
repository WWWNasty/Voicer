using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Entities;

namespace DataAccessLayer.Models.Votes
{
    public class VotingOption : IEntity<int>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int? VotingId { get; set; }

        [Required]
        public Voting Voting { get; set; }
    }
}