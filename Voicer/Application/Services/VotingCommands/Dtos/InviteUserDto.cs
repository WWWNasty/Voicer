using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class InviteUserDto
    {
        [Required] public int VotingId { get; set; }

        public ICollection<UserVotingDto> Participants { get; set; }


        public string UserId { get; set; }

        [Required(ErrorMessage = "Не указан пользователь!")]
        //[MaxLength(200)]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 200 символов")]
        public string SerchUser { get; set; }
    }
}