using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.Abstraction.Repositories;
using DataAccessLayer.Models.Entities;
using VotingApp.Infrastructure.DataAccess;

namespace Infrastructure.EntityFramework.Repositories
{
    public class VotingRepository: IVotingRepository
    
    {
        private readonly VotingDbContext _dbcontext;
        

            public VotingRepository(VotingDbContext dbcontext)
            {
                _dbcontext = dbcontext;
            }

            public ICollection<Voting> GetVoting()
            {
                return _dbcontext.Voting.ToList();
            }
            
        
    
    }
}