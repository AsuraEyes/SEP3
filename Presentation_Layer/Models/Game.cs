#nullable enable
using System;
using System.ComponentModel.DataAnnotations;
using ExpressiveAnnotations.Attributes;

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
        [Range(1, int.MaxValue, ErrorMessage = "Minimum amount of players must be greater than 0.")]
        public int MinNumberOfPlayers { get; set; }

        [Required(ErrorMessage = "A maximum amount of players is required.")]
        [AssertThat("MaxNumberOfPlayers > MinNumberOfPlayers", 
            ErrorMessage = "Maximum amount of players must be greater than minimum amount.")]
        public int MaxNumberOfPlayers { get; set; }

        public string? ShortDescription { get; set; }
        
        public string? NeededEquipment { get; set; }

        [RequiredIf("MinAge < 0", ErrorMessage = "Minimum age of players must be greater than 0.")]
        [Range(0,int.MaxValue)]
        public int? MinAge { get; set; }

        [RequiredIf("MinAge > MaxAge")]
        [Range(0, int.MaxValue)]
        [AssertThat("MaxAge > MinAge", 
            ErrorMessage = "Maximum age of players must be greater than the minimum age.")]
        public int? MaxAge { get; set; }

        [Url(ErrorMessage = "Please enter a valid tutorial link.")]
        public string? Tutorial { get; set; }

        public bool Approved { get; set; }

        protected bool Equals(Game other)
        {
            return Id == other.Id && 
                   Name == other.Name && 
                   Complexity == other.Complexity && 
                   TimeEstimation == other.TimeEstimation && 
                   MinNumberOfPlayers == other.MinNumberOfPlayers && 
                   MaxNumberOfPlayers == other.MaxNumberOfPlayers && 
                   ShortDescription == other.ShortDescription && 
                   NeededEquipment == other.NeededEquipment && 
                   MinAge == other.MinAge && 
                   MaxAge == other.MaxAge && 
                   Tutorial == other.Tutorial && 
                   Approved == other.Approved;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Game) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Name);
            hashCode.Add(Complexity);
            hashCode.Add(TimeEstimation);
            hashCode.Add(MinNumberOfPlayers);
            hashCode.Add(MaxNumberOfPlayers);
            hashCode.Add(ShortDescription);
            hashCode.Add(NeededEquipment);
            hashCode.Add(MinAge);
            hashCode.Add(MaxAge);
            hashCode.Add(Tutorial);
            hashCode.Add(Approved);
            return hashCode.ToHashCode();
        }
    }
}