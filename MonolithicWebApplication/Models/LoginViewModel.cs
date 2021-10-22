using System.ComponentModel.DataAnnotations;

namespace MonolithicWebApplication.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is required")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { set; get; }
    }
}
