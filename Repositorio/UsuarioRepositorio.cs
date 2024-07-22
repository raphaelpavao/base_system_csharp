using mysql.context;
using WebApplication1.Enums;



namespace WebApplication1.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        
        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscarTodos()
            {
                return _bancoContext.usuarios.ToList();
            }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);
            if(usuarioDb == null) throw new System.Exception("Houve um erro na atualização");
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Perfil = usuario.Perfil;
            usuarioDb.Senha = usuario.Senha;
            usuarioDb.Email = usuario.Email;
            usuarioDb.DataAtualizacao = DateTime.Now;
            _bancoContext.usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();
            return usuarioDb;
        }

        public bool Apagar(int Id)
        {
            UsuarioModel usuarioDb = ListarPorId(Id);
            if(usuarioDb == null) throw new System.Exception("Houve um erro na exclusão");
            _bancoContext.usuarios.Remove(usuarioDb);
            _bancoContext.SaveChanges();
            return true;
        }

        public UsuarioModel BuscarPorEmail(string email)
        {
            return _bancoContext.usuarios.FirstOrDefault(x => x.Email == email);
        }
    }
}