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
            VotingDbContext dbContext)
        {
            UserRepository = userRepository;
            VotingRepository = votingRepository;
            _dbContext = dbContext;
        }

        public IUserRepository UserRepository { get; }
        public IVotingRepository VotingRepository { get; }
        
        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}