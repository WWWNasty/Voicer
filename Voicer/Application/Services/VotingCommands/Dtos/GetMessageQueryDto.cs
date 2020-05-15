namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class GetMessageQueryDto
    {
        public int ChatId { get; set; }

        public int Count { get; set; }

        public int Page { get; set; }
    }
}