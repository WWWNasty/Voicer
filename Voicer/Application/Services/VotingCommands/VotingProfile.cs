using AutoMapper;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Votes;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands
{
    public class VotingProfile: Profile
    {
        public VotingProfile()
        {
            CreateMap<Voting, GetAllVotingDto>();
            CreateMap<Voting, GetVotingDto>();
            CreateMap<CreateVotingDto, Voting>();
            CreateMap<Voting, DeleteVotingDto>();
            CreateMap<UpdateVotingDto, Voting>();
            CreateMap<VotingOptionDto, Voting>().ReverseMap();
        }
    }
}