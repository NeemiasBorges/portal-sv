using Services.Services.DTO.Cliente;

namespace Services.Services.Cliente.Interfaces
{
    public interface IClienteService
    {
        Task Add(ClienteDTO cliente);
        Task<List<ClienteDTO>> GetAll();
        Task Delete(ClienteDTO cliente);
        Task Update(ClienteDTO cliente);
        Task<ClienteDTO> Get(int id);
    }
}
