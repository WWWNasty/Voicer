using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class CreateVotingDto
    {
        [Required(ErrorMessage = "Не указано название!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 100 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указано описание!")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 500 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Не указана дата начала!")]
        //[Display(Name = "старт")]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Не указана дата окончания!")]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Не указано описание!")]
        [MaxLength(15)]
        public VotingOptionDto[] VotingOptions { get; set; } = new VotingOptionDto[1];
    }
}