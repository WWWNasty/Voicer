using AutoMapper;

namespace BusinessLogicLayer.Abstraction.Services.Voting
{
    public class VotingProfile: Profile
    {
        public VotingProfile()
        {
            CreateMap<DataAccessLayer.Models.Entities.Voting, VotingDto>().ReverseMap();
        }
    }
}