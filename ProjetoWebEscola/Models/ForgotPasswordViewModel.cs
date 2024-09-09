using System.ComponentModel.DataAnnotations;

namespace ProjetoWebEscola.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
