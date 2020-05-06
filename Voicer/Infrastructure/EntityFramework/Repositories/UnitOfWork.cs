using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Repositories;

namespace Infrastructure.EntityFramework.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly VotingDbContext _dbContext;

        public UnitOfWork(
            IUserRepository userRepository,
            IVotingRepository votingRepository, 
            VotingDbContext dbContext, IVotingOptionRepository votingOptionRepository, IVoteRepository voteRepository)
        {
            UserRepository = userRepository;
            VotingRepository = votingRepository;
            _dbContext = dbContext;
            VotingOptionRepository = votingOptionRepository;
            VoteRepository = voteRepository;
        }

        public IUserRepository UserRepository { get; }
        public IVotingOptionRepository VotingOptionRepository { get; }
        public IVoteRepository VoteRepository { get; }
        public IVotingRepository VotingRepository { get; }
        
        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}