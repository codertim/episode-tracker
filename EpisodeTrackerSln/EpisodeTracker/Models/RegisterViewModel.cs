using System.ComponentModel.DataAnnotations;

namespace EpisodeTracker.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Pease enter a username")]
        [StringLength(255)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
