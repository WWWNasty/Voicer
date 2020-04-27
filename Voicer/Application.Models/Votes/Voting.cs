using System;
using System.Collections.Generic;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Models.Votes.Enums;

namespace DataAccessLayer.Models.Votes
{
    public class Voting: IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public ICollection<VotingOption> VotingOptions { get; set; }

        public ICollection<UserVoting> Participants { get; set; } = new List<UserVoting>();

        public ICollection<Vote> Votes { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
        //public Chat Chat { get; set; }
        
        public VotingStatus GetVotingStatus()
        {
            var currentDate = DateTime.UtcNow; 
            
            if (StartDate > currentDate || Participants.Count == 0)
            {
                return VotingStatus.Upcoming;
            }
            if(EndDate >= currentDate || Participants.Count == Votes.Count)
            {
                return VotingStatus.Ended;
            }

            return VotingStatus.Active;
        }

    }
}