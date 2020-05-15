using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class CreateVotingDto
    {
        [Required(ErrorMessage = "Не указано название!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 100 символов")]
        public string Name { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 100 символов")]
        public string Description { get; set; }

        [Required]
        //[Display(Name = "старт")]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [MinLength(1)] [MaxLength(15)] public VotingOptionDto[] VotingOptions { get; set; } = new VotingOptionDto[1];
    }
}