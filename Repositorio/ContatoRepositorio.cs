using mysql.context;


namespace WebApplication1.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        
        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.contatos.FirstOrDefault(x => x.Id == id);
        }

    public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);
            if(contatoDb == null) throw new System.Exception("Houve um erro na atualização");
            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;
            _bancoContext.contatos.Update(contatoDb);
            _bancoContext.SaveChanges();
            return contatoDb;
        }

        public bool Apagar(int Id)
        {
            ContatoModel contatoDb = ListarPorId(Id);
            if(contatoDb == null) throw new System.Exception("Houve um erro na exclusão");
            _bancoContext.contatos.Remove(contatoDb);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}