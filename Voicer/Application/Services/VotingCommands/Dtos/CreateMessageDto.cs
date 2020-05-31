using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands
{
    public class CreateMessageDto
    {
        [Required(ErrorMessage = "Не введен текст сообщения!")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Длина сообщения должна быть от 1 до 500 символов")]
        public string Text { get; set; }

        public string UserId { get; set; }

        public int ChatId { get; set; }

        public string UserName { get; set; }
    }
}