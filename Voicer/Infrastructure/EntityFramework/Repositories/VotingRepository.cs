using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogicLayer.Abstraction.Repositories;
using BusinessLogicLayer.Abstraction.Repositories.Base;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Votes;
using Infrastructure.EntityFramework.Repositories.Base;
using Microsoft.EntityFrameworkCore;

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
            
            public Task<List<GetAllVotingDto>> GetAllVotingDtosAsync()
            {
                return GetDbSet().ProjectTo<GetAllVotingDto>(_mapper.ConfigurationProvider).ToListAsync();
            }

            public Task<GetVotingDto> GetVotingDtoAsync(int id)
            {
                return GetDbSet().Where(voting => voting.Id == id).ProjectTo<GetVotingDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            }
            
    }
}