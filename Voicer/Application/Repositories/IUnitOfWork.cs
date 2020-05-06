using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IUnitOfWork
    {
        IVotingRepository VotingRepository { get; }
        IUserRepository UserRepository { get; }
        
        IVotingOptionRepository VotingOptionRepository { get; }
        
        IVoteRepository VoteRepository { get; }

        Task SaveChangesAsync();

    }
}