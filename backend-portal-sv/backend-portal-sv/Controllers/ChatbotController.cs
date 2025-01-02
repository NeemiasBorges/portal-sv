using Microsoft.AspNetCore.Mvc;
using Services.Services.Chatbot.Interface;

namespace backend_portal_sv.Controllers
{
    [ApiController]
    [Route("api/v1/chatbot")]
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
    }
}
