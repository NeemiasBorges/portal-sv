using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Conection
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=localhost;Database=Teste;User Id=sa;Password=123456;");
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=teste_tecnico;Username=postgres;Password=@Cesso2024");
        }
    }
}
