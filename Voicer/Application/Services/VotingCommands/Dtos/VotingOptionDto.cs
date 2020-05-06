using System.ComponentModel.DataAnnotations;

namespace BusinessLogicLayer.Abstraction.Services.VotingCommands.Dtos
{
    public class VotingOptionDto
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

    }
}