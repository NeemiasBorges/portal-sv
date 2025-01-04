using Domain.Entity;
using Domain.Entity.Chatbot;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infra.Conection
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Chat> Chat { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DEVNEMO;Initial Catalog=PORTALSV;User ID=protheus2024;Password=123456;Encrypt=False");
            }
        }
    }
}
