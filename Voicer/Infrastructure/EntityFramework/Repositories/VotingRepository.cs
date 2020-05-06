using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Votes;
using Infrastructure.EntityFramework.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories
{
    public class VotingRepository : BaseRepository<Voting, int>, IVotingRepository

    {
        public VotingRepository(VotingDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Task<List<VotingDto>> GetAllVotingDtosAsync(string userId)
        {
            return GetDbSet()
                .Where(voting => voting.User.Id == userId)
                .Include(voting => voting.Participants.Where(votingParticipant => votingParticipant.UserId == userId))
                .ProjectTo<VotingDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public Task<GetVotingDto> GetVotingDtoAsync(int id)
        {
            return GetDto<GetVotingDto>(id);
        }

        public Task<UpdateVotingDto> GetVotingForUpdateAsync(int id)
        {
            return GetDto<UpdateVotingDto>(id);
        }

        public override async Task<ICollection<Voting>> GetAllAsync(string userId)
        {
            return await GetDbSet()
                .Include(voting => voting.Participants)
                .Include(voting => voting.Votes)
                .Where(voting =>
                    voting.User.Id == userId || voting.Participants.Any(participant => participant.UserId == userId))
                .ToListAsync();
        }
    }
}