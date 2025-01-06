using Domain.Entity;
using Domain.Entity.Chatbot;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Conection
{
    public class ConnectionContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Chat> Chat { get; set; }
        public ConnectionContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string strConexao = _configuration.GetConnectionString("DefaultConnection") ?? "";
                optionsBuilder.UseSqlServer(strConexao);
            }
        }
    }
}
