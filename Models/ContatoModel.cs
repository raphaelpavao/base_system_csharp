
using System.ComponentModel.DataAnnotations;

public class ContatoModel
{
    public int Id {get; set;}
    
    [Required(ErrorMessage = "O nome do contato é obrigatório")]
    public required string Nome {get; set;}
   
    [Required(ErrorMessage = "O email do contato é obrigatório")]
    [EmailAddress(ErrorMessage = "O formato do email não é válido")]
    public required string Email {get; set;}

    [Required(ErrorMessage = "O celular do contato é obrigatório")]
    [Phone(ErrorMessage = "O formato do telefone não é válido")]    
    public required string Celular {get; set;}
}
