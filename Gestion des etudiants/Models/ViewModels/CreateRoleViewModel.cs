using System.ComponentModel.DataAnnotations;

namespace Gestion_des_etudiants.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "Role")]
        public string RoleName{  get; set; }
        }
}
