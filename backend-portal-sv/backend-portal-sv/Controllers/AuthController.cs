using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Services.Services.DTO.Cliente;
using Services.Services.Interfaces;

namespace backend_portal_sv.Controllers
{
    /// <summary>
    /// Controlador responsável pela autenticação de usuários.
    /// </summary>
    [ApiController]
    [Route("api/v1/auth")]
    [Produces("application/json")]
    [Tags("Autenticação")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Inicializa o AuthController com o serviço de token.
        /// </summary>
        /// <param name="tokenService">Serviço responsável pela geração de tokens JWT.</param>
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Realiza a autenticação de um usuário e retorna um token JWT caso as credenciais sejam válidas.
        /// </summary>
        /// <param name="username">Nome de usuário.</param>
        /// <param name="password">Senha do usuário.</param>
        /// <returns>Token JWT em caso de sucesso ou mensagem de erro em caso de falha.</returns>
        /// <response code="200">Retorna o token JWT gerado com sucesso.</response>
        /// <response code="400">Usuário ou senha inválidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Auth([FromBody] LoginRequest request)
        {
            if (request.Email == "admin@admin.com" && request.Password == "admin")
            {
                var token = await _tokenService.GenerateToken();
                return Ok(new { token });
            }

            //TODO:Asp linhás 41,42,43 e 44 apenas refletem um comportamento que nao é indicado, acabei deixando o login fixo pois a titulo de demonstração, mas o correto seria buscar essas informações no banco de dados.


            return BadRequest("Usuário ou senha inválidos.");
        }
    }
}
