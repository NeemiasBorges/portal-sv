using Microsoft.AspNetCore.Mvc;
using Services.Services.Cliente.Interfaces;

[ApiController]
[Route("api/v1/cliente")]
[Produces("application/json")]
[Tags("Clientes")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    /// <summary>
    /// Retorna todos os clientes cadastrados
    /// </summary>
    /// <response code="200">Lista de clientes retornada com sucesso</response>
    /// <response code="500">Erro interno do servidor</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Cliente()
    {
        try
        {
            return Ok(await _clienteService.GetAll());
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}