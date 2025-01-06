using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Cliente.Interfaces;
using Services.Services.DTO.Cliente;

[ApiController]
[Route("api/v{version:apiVersion}/cliente")]
[Produces("application/json")]
[Tags("Clientes")]
[ApiVersion(1.0)]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    /// <summary>
    /// Inicializa o ClienteController com o serviço de cliente.
    /// </summary>
    /// <param name="clienteService">Serviço responsável pelas operações relacionadas aos clientes.</param>
    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    /// <summary>
    /// Cadastra um novo cliente a base de dados. 
    /// Este endpoint requer autenticação.
    /// </summary>
    /// <returns>Lista de clientes cadastrados.</returns>
    /// <response code="201">Criacao de clientes retorna sucesso.</response>
    /// <response code="401">Usuário não autenticado.</response>
    /// <response code="500">Erro interno do servidor.</response>
    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create(ClienteDTO cliente)
    {
        try
        {
            await _clienteService.Add(cliente);
            return Created();
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    /// <summary>
    /// Retorna todos os clientes cadastrados. 
    /// Este endpoint requer autenticação.
    /// </summary>
    /// <returns>Lista de clientes cadastrados.</returns>
    /// <response code="200">Lista de clientes retornada com sucesso.</response>
    /// <response code="401">Usuário não autenticado.</response>
    /// <response code="500">Erro interno do servidor.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllClientes(int numero_pagina, int quantidade_p_pagina)
    
    {
        try
        {
            var clientes = await _clienteService.GetAll(numero_pagina, quantidade_p_pagina);
            return Ok(clientes);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    /// <summary>
    /// Retorna um cliente específico pelo ID. 
    /// Este endpoint requer autenticação.
    /// </summary>
    /// <param name="id">ID do cliente.</param>
    /// <returns>Dados do cliente correspondente ao ID informado.</returns>
    /// <response code="200">Cliente encontrado com sucesso.</response>
    /// <response code="401">Usuário não autenticado.</response>
    /// <response code="404">Cliente não encontrado.</response>
    /// <response code="500">Erro interno do servidor.</response>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetClienteById(int id)
    {
        try
        {
            var cliente = await _clienteService.Get(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    /// <summary>
    /// Atualiza os dados de um cliente existente. 
    /// Este endpoint requer autenticação.
    /// </summary>
    /// <param name="cliente">Objeto contendo os dados do cliente a serem atualizados.</param>
    /// <response code="204">Cliente atualizado com sucesso.</response>
    /// <response code="401">Usuário não autenticado.</response>
    /// <response code="404">Cliente não encontrado.</response>
    /// <response code="500">Erro interno do servidor.</response>
    [Authorize]
    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateCliente([FromBody] ClienteDTO cliente)
    {
        try
        {
            var existingCliente = await _clienteService.Get(cliente.Id);
            if (existingCliente == null)
                return NotFound("Cliente não encontrado.");

            await _clienteService.Update(cliente);
            return Ok("Cliente atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    /// <summary>
    /// Deleta um cliente específico pelo ID. 
    /// Este endpoint requer autenticação.
    /// </summary>
    /// <param name="id">ID do cliente a ser deletado.</param>
    /// <response code="204">Cliente deletado com sucesso.</response>
    /// <response code="401">Usuário não autenticado.</response>
    /// <response code="404">Cliente não encontrado.</response>
    /// <response code="500">Erro interno do servidor.</response>
    [Authorize]
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        try
        {
            var cliente = await _clienteService.Get(id);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            await _clienteService.Delete(cliente);
            return Ok("Cliente deletado com sucesso.");
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
