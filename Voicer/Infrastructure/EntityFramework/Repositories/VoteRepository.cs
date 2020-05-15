using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Votes;
using Infrastructure.EntityFramework.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories
{
    public class VoteRepository : BaseRepository<Vote, int>, IVoteRepository
    {
        public VoteRepository(VotingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> UserHasVotedAsync(int votingId, string userId)
        {
            bool userHasVoted = await GetDbSet().AnyAsync(vote => vote.UserId == userId && vote.VotingId == votingId);

            return userHasVoted;
        }


        public async Task<VoteCountByVotingOptionDto> GetCountVoteAsync(int id)
        {
            var array = await GetDbSet().Include(voting => voting.VotingOption)
                .Where(vote => vote.VotingId == id)
                .ToArrayAsync();


            Dictionary<int, int> votingOptionCount = array
                .GroupBy(option => option.VotingOption)
                .ToDictionary(groupVotesByVotingOption => groupVotesByVotingOption.Key.Id,
                    groupVotesByVotingOption => groupVotesByVotingOption.Count());

            return new VoteCountByVotingOptionDto
            {
                VotingId = id,
                VotingOptionCount = votingOptionCount
            };
// сгрупировать по вотингоптион айди и вызвать селект моих воутинг оптион сгруппированых и вызвать коунт и записать в проперти коунт
        }
    }
}