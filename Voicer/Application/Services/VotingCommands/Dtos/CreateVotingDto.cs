using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class CreateVotingDto
    {
        public const int VotingOptionsCount = 5;
        
        [Required (ErrorMessage = "Не указано название!")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 100 символов")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Длина строки должна быть от 1 до 100 символов")]
        public string Description { get; set; }
        
        [Required]
        //[Display(Name = "старт")]
        //[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        
        [Required]
        public DateTime EndDate { get; set; }

        [MinLength(1)]
        public VotingOptionDto[] VotingOptions { get; set; } = new VotingOptionDto[VotingOptionsCount];

    }
}