using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAccessLayer.Models.Chats;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Models.Votes.Enums;

namespace DataAccessLayer.Models.Votes
{
    public class Voting : IEntity<int>
    {
        public int Id { get; set; }

        [Required] [MaxLength(100)] public string Name { get; set; }

        [Required] [MaxLength(500)] public string Description { get; set; }

        [Required] public DateTime? StartDate { get; set; }

        [Required] public DateTime? EndDate { get; set; }


        [MinLength(1)] public ICollection<VotingOption> VotingOptions { get; set; }

        public ICollection<UserVoting> Participants { get; set; } = new List<UserVoting>();

        public ICollection<Vote> Votes { get; set; } = new List<Vote>();

        [Required] public string UserId { get; set; }

        public User User { get; set; }

        [Required] public Chat Chat { get; set; }

        public VotingStatus GetVotingStatus()
        {
            var currentDate = DateTime.UtcNow;

            if (StartDate > currentDate)
            {
                return VotingStatus.Upcoming;
            }

            if (currentDate >= EndDate || (Participants.Count > 0 && Participants.Count == Votes.Count))
            {
                return VotingStatus.Ended;
            }

            return VotingStatus.Active;
        }
    }
}