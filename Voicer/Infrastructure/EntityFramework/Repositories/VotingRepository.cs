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

        public async Task<List<VotingDto>> GetAllVotingDtosAsync(string userId)
        {
            return await GetDbSet()
                .Where(voting => voting.User.Id == userId)
                .Include(voting => voting.Participants.Where(votingParticipant => votingParticipant.UserId == userId))
                .ProjectTo<VotingDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<Voting> GetAsync(GetOptions options)
        {
            var allVoting = GetVotingQuery(options);

            return await allVoting.FirstOrDefaultAsync(voting => voting.Id == options.Id);
        }

        private IQueryable<Voting> GetVotingQuery(GetOptions options)
        {
            IQueryable<Voting> allVoting = GetDbSet();

            if (options.IncludeParticipants)
            {
                allVoting = allVoting.Include(voting => voting.Participants);
            }

            if (options.IncludeVotingOptions)
            {
                allVoting = allVoting.Include(voting => voting.VotingOptions);
            }

            if (options.IncludeUser)
            {
                allVoting = allVoting.Include(voting => voting.User);
            }

            return allVoting;
        }

        public async Task<GetVotingDto> GetVotingDtoAsync(int id)
        {
            var allVoting = GetVotingQuery(new GetOptions

            {
                Id = id,
                IncludeParticipants = true,
                IncludeUser = true
            });

            return await allVoting.ProjectTo<GetVotingDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(opt => opt.Id == id);
        }

        public async Task<UpdateVotingDto> GetVotingForUpdateAsync(int id)
        {
            return await GetDto<UpdateVotingDto>(id);
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