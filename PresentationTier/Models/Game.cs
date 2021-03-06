#nullable enable
using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;

namespace PresentationTier.Models
{
    public class Game
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a number between 1 and 3.")]
        [Range(1,3, ErrorMessage = "Complexity must be between 1 and 3.")]
        public int Complexity { get; set; }

        [Required(ErrorMessage = "Please enter a number between 1 and 3.")]
        [Range(1,3, ErrorMessage = "Estimated time must be between 1 and 3.")]
        public int TimeEstimation { get; set; }

        [Required(ErrorMessage = "A minimum amount of players is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Minimum amount of players must be greater than 0.")]
        public int MinNumberOfPlayers { get; set; }

        [Required(ErrorMessage = "A maximum amount of players is required.")]
        [AssertThat("MaxNumberOfPlayers > MinNumberOfPlayers", 
            ErrorMessage = "Maximum amount of players must be greater than minimum amount.")]
        public int MaxNumberOfPlayers { get; set; }

        public string? ShortDescription { get; set; }
        
        public string? NeededEquipment { get; set; }

        [Range(0,int.MaxValue)]
        public int MinAge { get; set; }
        
        [Range(0,int.MaxValue)]
        public int MaxAge { get; set; }

        [Url(ErrorMessage = "Please enter a valid tutorial link.")]
        public string? Tutorial { get; set; }

        public bool Approved { get; set; }
    }
}