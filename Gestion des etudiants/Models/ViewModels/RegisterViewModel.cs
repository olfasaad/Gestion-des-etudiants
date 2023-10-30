using System.ComponentModel.DataAnnotations;

namespace Gestion_des_etudiants.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password"
        ,
        ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}