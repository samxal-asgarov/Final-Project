using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToySolution.Models.Entities.Membership;

namespace ToySolution.Models.FormModels
{
    public class LoginFormModel
    {
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

      

    }
}
