using System.ComponentModel.DataAnnotations;

namespace Presentation_Layer.Models
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
        public int MinNumberOfPlayers { get; set; }

        public int MaxNumberOfPlayers { get; set; }

        public string ShortDescription { get; set; }
        
        public string NeededEquipment { get; set; }

        [Required(ErrorMessage = "Minimum age is required.")]
        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public string Tutorial { get; set; }

        public bool Approved { get; set; }
    }
}