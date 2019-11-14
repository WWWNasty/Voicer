using System;
using System.Collections.Generic;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Users;

namespace DataAccessLayer.Models.Votes
{
    public class Voting: Entity<int>
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public ICollection<VotingOption> VotingOption { get; set; }

        public ICollection<UserVoting> Participants { get; set; }

        public ICollection<Vote> Votes { get; set; }

        //public Chat Chat { get; set; }

    }
}