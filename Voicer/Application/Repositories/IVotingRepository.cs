using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Votes;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IVotingRepository : IBaseRepository<Voting, int>
    {
        Task<List<VotingDto>> GetAllVotingDtosAsync(string userId);

        Task<Voting> GetAsync(GetOptions options);

        Task<GetVotingDto> GetVotingDtoAsync(int id);

        Task<UpdateVotingDto> GetVotingForUpdateAsync(int id);
    }

    public class GetOptions
    {
        public int Id { get; set; }
        public bool IncludeParticipants { get; set; }

        public bool IncludeVotingOptions { get; set; }

        public bool IncludeVotes { get; set; }

        public bool IncludeUser { get; set; }
    }
}