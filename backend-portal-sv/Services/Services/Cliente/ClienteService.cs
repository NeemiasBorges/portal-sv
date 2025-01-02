using Infra.Repository;
using Infra.Repository.Interfaces;
using Services.Services.Cliente.Interfaces;
using Services.Services.DTO.Cliente;
using Serilog;

namespace Services.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger _logs;

        public ClienteService(
            ClienteRepository clienteRepository,
            ILogger logger)
        {
            _logs = logger;
            _clienteRepository = clienteRepository;
        }
        public async Task Add(ClienteDTO cliente)
        {
            try
            {
                await _clienteRepository.Add(cliente.toEntity());
            }
            catch (Exception e)
            {
                _logs.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task Delete(ClienteDTO cliente)
        {
            try
            {
                await _clienteRepository.Delete(cliente.toEntity());  
            }
            catch (Exception e)
            {
                _logs.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task<ClienteDTO> Get(int id)
        {
            try
            {
                var cliente = await _clienteRepository.Get(id);
                return new ClienteDTO(cliente);
            }
            catch (Exception e)
            {
                _logs.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ClienteDTO>> GetAll()
        {
            try
            {
                var listaClientes = await _clienteRepository.GetAll();
                return listaClientes.Select(cliente => new ClienteDTO(cliente)).ToList();
            }
            catch (Exception e)
            {
                _logs.Error(e.Message);
                throw new Exception(e.Message);
            }
        }

        public async Task Update(ClienteDTO cliente)
        {
            try
            {
                await _clienteRepository.Update(cliente.toEntity());
            }
            catch (Exception e)
            {
                _logs.Error(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
