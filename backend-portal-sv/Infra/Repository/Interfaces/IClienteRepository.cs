using Domain.Entity;

namespace Infra.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task Add(Cliente cliente);
        Task<List<Cliente>> GetAll();
        Task Delete(Cliente cliente);
        Task Update(Cliente cliente);
        Task<Cliente> Get(int id);
    }
}
