using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using BusinessLogicLayer.Abstraction.Services.Voting;
using DataAccessLayer.Models.Entities;
using Infrastructure.EntityFramework.Repositories.Base;
using VotingApp.Infrastructure.DataAccess;

namespace Infrastructure.EntityFramework.Repositories
{
    public class  VotingRepository: BaseRepository<Voting,int>, IVotingRepository

    {
        private readonly VotingDbContext _dbContext;
        
        private readonly IMapper _mapper;

            public VotingRepository(VotingDbContext dbContext, IMapper mapper) : base(dbContext)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }
            
            public ICollection<VotingDto> GetVoting()
            {
                return GetDbSet().ProjectTo<VotingDto>(_mapper.ConfigurationProvider).ToList();
                
            }
    }
}