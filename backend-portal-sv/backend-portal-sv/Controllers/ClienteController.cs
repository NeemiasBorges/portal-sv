using Microsoft.AspNetCore.Mvc;
using Services.Services.Cliente.Interfaces;

namespace backend_portal_sv.Controllers
{
    [Route("api/v1/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
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
}
