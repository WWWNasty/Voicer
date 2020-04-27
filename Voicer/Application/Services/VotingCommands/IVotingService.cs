using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands
{
    public interface IVotingService
    {
        Task<GetVotingDto> GetVotingAsync(int id);
        
        Task<UpdateVotingDto> GetVotingForUpdateAsync(int id);
        
        Task<GetAllVotingDto> GetAllVotingAsync();
        
        Task<int> AddAsync(CreateVotingDto dto, ClaimsPrincipal user);

        Task UpdateAsync(UpdateVotingDto dto);

        Task InviteAsync(InviteUserDto dto);

        Task DeleteAsync(DeleteVotingDto dto);
    }
}