using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class LoginVm
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
