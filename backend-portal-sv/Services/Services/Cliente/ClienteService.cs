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
        public ClienteService(IClienteRepository clienteRepository, ILogger logs)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _logs = logs ?? throw new ArgumentNullException(nameof(logs));
        }

        public async Task Add(ClienteDTO cliente)
        {
            try
            {
                await _clienteRepository.Add(cliente.toEntity());
                _logs.Information("Cliente: '{cliente}' - adicionado com sucesso", cliente.nome);
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
                _logs.Information("Cliente: '{cliente}' - deletado com sucesso", cliente.nome);
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

        public async Task<List<ClienteDTO>> GetAll(int numero_pagina, int quantidade_p_pagina)
        {
            try
            {
                var listaClientes = await _clienteRepository.GetAll(numero_pagina, quantidade_p_pagina);
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
                _logs.Information("Cliente: '{cliente}' - atualizado com sucesso", cliente.nome);
            }
            catch (Exception e)
            {
                _logs.Error(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}
