namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class UserVotingDto
    {
        public UserDto User { get; set; }

        public VotingDto Voting { get; set; }

        public int VotingId { get; set; }

        public string UserId { get; set; }
    }
}