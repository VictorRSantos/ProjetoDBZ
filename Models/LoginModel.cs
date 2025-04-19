using System.ComponentModel.DataAnnotations;

namespace ProjetoDBZ.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Required")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Password Required")]
        public string Password { get; set; } = null!;
    }
}