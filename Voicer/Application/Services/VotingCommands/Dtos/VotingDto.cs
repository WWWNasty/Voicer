using System;
using System.Collections.Generic;
using DataAccessLayer.Models.Users;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class VotingDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }
        
        public UserDto User { get; set; }
        
        public ICollection<UserVotingDto> Participants { get; set; }

    }
}