using AutoMapper;
using BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos;
using DataAccessLayer.Models.Chats;
using DataAccessLayer.Models.Users;
using DataAccessLayer.Models.Votes;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands
{
    public class VotingMappingProfile : Profile
    {
        public VotingMappingProfile()
        {
            CreateMap<Voting, VotingDto>();
            CreateMap<UserVoting, UserVotingDto>();
            CreateMap<User, UserDto>();
            CreateMap<Vote, VoteDto>();
            CreateMap<Voting, GetVotingDto>()
                .ForMember(dto => dto.VotingStatus, options => options
                    .MapFrom(voting => voting.GetVotingStatus()));
            CreateMap<CreateVotingDto, Voting>();
            CreateMap<Voting, DeleteVotingDto>();
            CreateMap<UpdateVotingDto, Voting>().ReverseMap();
            CreateMap<VotingOptionDto, VotingOption>().ReverseMap();
            CreateMap<Message, MessageDto>();
            CreateMap<CreateMessageDto, Message>()
                .ForMember(message => message.User, opt => opt.Ignore());
        }
    }
}