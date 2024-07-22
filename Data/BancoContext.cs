using Microsoft.EntityFrameworkCore;
using WebApplication1.Enums;
using WebApplication1.Models;

namespace mysql.context
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<UsuarioModel> usuarios {get; set;}
        public DbSet<ContatoModel> contatos {get; set;}
    }
}