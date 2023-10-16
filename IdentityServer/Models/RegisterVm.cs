using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public class RegisterVm
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(4)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [MinLength(4)]
        public string ConfirmPassword { get; set; }
        [Required]
        public bool AdminRole { get; set; }
        public string ReturnUrl { get; set; }
    }
}
