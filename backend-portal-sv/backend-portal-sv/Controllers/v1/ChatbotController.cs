using Asp.Versioning;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Chatbot.Interface;
using Services.Services.DTO.Chatbot;

namespace backend_portal_sv.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Tags("ChatBot")]
    public class ChatbotController : ControllerBase
    {
        private readonly IChatbotService _chatbotService;
        public ChatbotController(IChatbotService chatbotService)
        {
            _chatbotService = chatbotService ?? throw new ArgumentNullException(nameof(chatbotService));
        }

        /// <summary>
        /// Se comunica com o LLM e esperaa resposta da API
        /// </summary>
        /// <returns>String de retorno da api LLM.</returns>
        /// <response code="200">Retorna resposta do LLM com sucesso.</response>
        /// <response code="401">Usuário não autenticado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SendMessage(string message)
        {
            try
            {
                var returnMessage = await _chatbotService.SendMessage(message);
                return Ok(returnMessage);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        /// <summary>
        /// Cria o hístorico da conversa no banco de dados
        /// </summary>
        /// <returns>Status 200 vazio.</returns>
        /// <response code="200">Retorna objeto vazio de sucesso.</response>
        /// <response code="401">Usuário não autenticado.</response>
        /// <response code="500">Erro interno do servidor.</response>

        [HttpPost("cria-historico")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriaHistorico(ChatDTO chat){
            try
            {
                await _chatbotService.CriaHistorico(chat);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Atualiza o hístorico da conversa no banco de dados
        /// </summary>
        /// <returns>Status 204 vazio.</returns>
        /// <response code="204">Histórico atualizado com sucesso.</response>
        /// <response code="401">Usuário não autenticado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizaHistorico(ChatDTO chat){
            try
            {
                await _chatbotService.AtualizaHistorico(chat);
                return NoContent();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        /// <summary>
        /// Lista todo o hístorico da conversa no banco de dados
        /// </summary>
        /// <returns>Lista de conversas existente no banco.</returns>
        /// <response code="200">Objeto lista de conversas.</response>
        /// <response code="401">Usuário não autenticado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PegaHistoricos() {
            try
            {
                var returnMessage = await _chatbotService.PegaHistoricos();
                return Ok(returnMessage);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
