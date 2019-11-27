using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IUnitOfWork
    {
        IVotingRepository VotingRepository { get; }

        Task SaveChangesAsync();
    }
}