using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Abstraction.Repositories;
using DataAccessLayer.Models.Votes;
using Infrastructure.EntityFramework.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories
{
    public class VoteRepository: BaseRepository<Vote, int>, IVoteRepository
    {
        public VoteRepository(VotingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<bool> UserHasVotedAsync(int votingId, string userId)
        {
            bool userHasVoted = await GetDbSet().AnyAsync(vote => vote.UserId == userId && vote.VotingId == votingId);

            return userHasVoted;
        }
    }
}