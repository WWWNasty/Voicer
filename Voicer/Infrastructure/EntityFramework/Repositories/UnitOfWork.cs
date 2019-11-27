using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Repositories;

namespace Infrastructure.EntityFramework.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly VotingDbContext _dbContext;

        public UnitOfWork(
            IVotingRepository votingRepository, 
            VotingDbContext dbContext)
        {
            VotingRepository = votingRepository;
            _dbContext = dbContext;
        }

        public IVotingRepository VotingRepository { get; }
        
        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}