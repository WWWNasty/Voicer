using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Abstraction.Repositories;
using DataAccessLayer.Models.Entities;

namespace BusinessLogicLayer.Abstraction.Services.ListVoting
{
    public class VotingService: IVotingService
    {
        private readonly IVotingRepository _repository;

        public VotingService(IVotingRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<VotingDto> GetVoting()
        {
            return _repository.GetVoting()
                .Select(voting => new VotingDto
            {
                Name = voting.Name,
                Description = voting.Description,
                StartDate = voting.StartDate,
                EndDate = voting.EndDate
            });
            
        }
    }
}