using System.Threading.Tasks;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using DataAccessLayer.Models.Votes;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IVoteRepository: IBaseRepository<Vote, int>
    {
       Task<bool> UserHasVotedAsync(int votingId, string userId);
    }
}