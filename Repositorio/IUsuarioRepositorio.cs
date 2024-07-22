using WebApplication1.Enums;

namespace WebApplication1.Repositorio
{
    public interface IUsuarioRepositorio
    {   
        UsuarioModel BuscarPorEmail(string email);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel ListarPorId(int id);        
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        bool Apagar(int Id);
    }
}