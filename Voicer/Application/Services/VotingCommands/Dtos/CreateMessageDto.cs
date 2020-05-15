namespace BusinessLogicLayer.Abstraction.Services.VotingCommands
{
    public class CreateMessageDto
    {
        public string Text { get; set; }

        public string UserId { get; set; }

        public int ChatId { get; set; }

        public string Email { get; set; }
    }
}