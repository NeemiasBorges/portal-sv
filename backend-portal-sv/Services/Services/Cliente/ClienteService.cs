using Infra.Repository.Interfaces;
using Serilog;
using Services.Services.Cliente.Interfaces;
using Services.Services.DTO.Cliente;

namespace Services.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly ILogger _logger;
        public ClienteService(IClienteRepository clienteRepository, ILogger logs)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _logger = logs ?? throw new ArgumentNullException(nameof(logs));
        }

        public async Task Add(ClienteDTO cliente)
        {
            try
            {
                await _clienteRepository.Add(cliente.ToEntity());
                _logger.Information("Cliente: '{Cliente}' - Adicionado Com Sucesso", cliente.Nome);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message, e, "Erro ao add Cliente - Message: {Message} ,{Error}");
                throw;
            }
        }

        public async Task Delete(ClienteDTO cliente)
        {
            try
            {
                await _clienteRepository.Delete(cliente.ToEntity());
                _logger.Information("Cliente: '{Cliente}' - Deletado com Sucesso", cliente.Nome);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message, e, "Erro Ao deletar o Cliente - Message: {Message} ,{Error}");
                throw;
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
                _logger.Error(e.Message, e, "Erro Ao Pegar o Cliente - Message: {Message} ,{Error}");
                throw;
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
                _logger.Error(e.Message, e, "Erro Ao Pegar Todos Os Clientes - Message: {Message} ,{Error}");
                throw;
            }
        }

        public async Task Update(ClienteDTO cliente)
        {
            try
            {
                await _clienteRepository.Update(cliente.ToEntity());
                _logger.Information("Cliente: '{Cliente}' - Atualizado Com Sucesso", cliente.Nome);
            }
            catch (Exception e)
            {
                _logger.Error(e.Message, e, "Erro Ao Atualizar o Cliente - Message: {Message} ,{Error}");
                throw;
            }
        }
    }
}
