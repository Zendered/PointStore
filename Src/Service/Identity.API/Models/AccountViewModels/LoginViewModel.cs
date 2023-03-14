using System.ComponentModel.DataAnnotations;

namespace Identity.API.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The field {0} its obligatory")]
        [EmailAddress(ErrorMessage = "The field {0} its in a invalid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field {0} its obligatory")]
        [StringLength(100, ErrorMessage = "The field need to be between {2} and {1} characters long", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
