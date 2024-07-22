using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O email do usuário é obrigatório")]
        [EmailAddress(ErrorMessage = "O formato do email não é válido")]
        public string Email {get; set;}

         [Required(ErrorMessage = "A senha do usuário é obrigatório")]
        public string Senha {get; set;}
    }
}