using System.ComponentModel.DataAnnotations;

namespace ToySolution.Models.FormModels
{
    public class RegisterFormModel
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
    }
}
