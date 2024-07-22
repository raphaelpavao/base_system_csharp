namespace WebApplication1.Enums;
using System.ComponentModel.DataAnnotations;

public class UsuarioModel
{
    public int Id {get; set;}

    [Required(ErrorMessage = "O nome do usuário é obrigatório")]
    public required string Nome {get; set;}

    [Required(ErrorMessage = "O email do usuário é obrigatório")]
    [EmailAddress(ErrorMessage = "O formato do email não é válido")]
    public required string Email {get; set;}
    
    [Required(ErrorMessage = "O perfil do usuário é obrigatório")]
    public required PerfilEnum Perfil {get; set;}
     
    [Required(ErrorMessage = "A senha do usuário é obrigatório")]
    public required string Senha {get; set;}    
    
    public DateTime DataCadastro {get; set;}
    
    public DateTime? DataAtualizacao {get; set;}
}
