using System;
using System.Collections.Generic;
using DataAccessLayer.Models.Votes.Enums;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class GetVotingDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public VotingOptionDto[] VotingOptions { get; set; }

        public UserDto User { get; set; }

        public ICollection<UserVotingDto> Participants { get; set; }

        public ICollection<VoteDto> Votes { get; set; }

        public VotingStatus VotingStatus { get; set; }

        public VoteCountByVotingOptionDto VoteCountByVotingOptionDto { get; set; }

        public bool UserVoted { get; set; }

        public int ChatId { get; set; }
    }
}