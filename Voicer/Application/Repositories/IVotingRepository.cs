using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Votes;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IVotingRepository: IBaseRepository<Voting, int>
    {
        Task<List<GetAllVotingDto>> GetAllVotingDtosAsync();

        Task<GetVotingDto> GetVotingDtoAsync(int id);
    }
}