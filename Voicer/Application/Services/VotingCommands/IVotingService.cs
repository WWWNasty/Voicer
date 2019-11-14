using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands
{
    public interface IVotingService
    {
        Task<GetVotingDto> GetVotingAsync(int id);
        
        Task<List<GetAllVotingDto>> GetAllVotingAsync();

        Task DeleteAsync(DeleteVotingDto dto);

        Task<int> AddAsync(CreateVotingDto dto);

        Task Update(UpdateVotingDto dto);

        Task Invite(InviteUserDto dto);
    }
}