using BusinessLogicLayer.Abstraction.Repositories.Base;
using DataAccessLayer.Models.Votes;

namespace BusinessLogicLayer.Abstraction.Repositories
{
    public interface IVotingOptionRepository: IBaseRepository<VotingOption, int>
    {
        
    }
}