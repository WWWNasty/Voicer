using AutoMapper;
using BusinessLogicLayer.Abstraction.Repositories;
using DataAccessLayer.Models.Votes;
using Infrastructure.EntityFramework.Repositories.Base;

namespace Infrastructure.EntityFramework.Repositories
{
    public class VotingOptionRepository : BaseRepository<VotingOption, int>, IVotingOptionRepository
    {
        public VotingOptionRepository(VotingDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}