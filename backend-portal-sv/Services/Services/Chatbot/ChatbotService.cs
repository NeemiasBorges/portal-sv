using Domain.Entity.Chatbot.Enums;
using Infra.Repository.Interfaces;
using Serilog;
using Services.Services.Chatbot.Interface;
using Services.Services.DTO.Chatbot;

namespace Services.Services.Chatbot
{
    public class ChatbotService : IChatbotService
    {
        private readonly IChatbotRepository _chatbotRepository;
        private readonly ILogger _logger;
        public ChatbotService(IChatbotRepository chatbotRepository, ILogger logger)
        {
            _logger = logger;
            _chatbotRepository = chatbotRepository ?? throw new ArgumentNullException(nameof(chatbotRepository));
        }

        public async Task AtualizaHistorico(ChatDTO chat)
        {
            try
            {
                chat.Satisfacao = chat.Satisfacao.Replace("\"","");
                chat.ResumoConversa = chat.ResumoConversa.Replace("\"","");
                await _chatbotRepository.AtualizaHistorico(chat.ToEntity());
            }
            catch (Exception e)
            {
                _logger.Error("Erro ao atualizar histórico", e);
                throw;
            }
        }

        public async Task CriaHistorico(ChatDTO chat)
        {
            try
            {
                var chatEntity = chat.ToEntity();
                await _chatbotRepository.CriaHistorico(chatEntity);

                chatEntity.AtualizarCategoria(await validateCategoria(chat.ResumoConversa));
                await _chatbotRepository.AtualizaHistorico(chatEntity);
            }
            catch (Exception e)
            {
                _logger.Error("Erro ao criar histórico", e);
                throw; 
            }
        }

        public async Task<CategoriaConversa> validateCategoria(string resumoConversa)
        {
            try
            {
                return (CategoriaConversa)await _chatbotRepository.validaCategoriaComLLM(resumoConversa);
            }
            catch (Exception e)
            {
                _logger.Error("Erro ao validar categoria", e);
                throw;
            }
        }

        public async Task<List<ChatDTO>> PegaHistoricos()
        {
            try
            {
                var chatlist = new List<ChatDTO>();
                var listChatEntity = await _chatbotRepository.PegaHistoricos();
                foreach (var item in listChatEntity)
                    chatlist.Add(new ChatDTO(item));

                return chatlist;

            }
            catch (Exception e)
            {
                _logger.Error("Erro ao pegar todos os hístoricos", e);
                throw;
            }
        }

        public async Task<string> SendMessage(string message)
        {
            try
            {
                var returnMessageFromApi = await _chatbotRepository.SendMessageAsync(message);
                return returnMessageFromApi;
            }
            catch (Exception e)
            {

                _logger.Error("Erro ao enviar mensagem ao LLM", e);
                throw;
            }
        }
    }
}
