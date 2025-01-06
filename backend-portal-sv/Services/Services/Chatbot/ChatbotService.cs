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

        public async Task AtualizaHistorico(ChatDto chat)
        {
            try
            {
                await _chatbotRepository.AtualizaHistorico(chat.ToEntity());
            }
            catch (Exception e)
            {
                _logger.Error(e, "Erro ao atualizar histórico para o chat com ID {ChatId}", chat.Id);
                throw;
            }
        }

        public async Task CriaHistorico(ChatDto chat)
        {
            try
            {
                var chatEntity = chat.ToEntity();
                await _chatbotRepository.CriaHistorico(chatEntity);

                chatEntity.AtualizarCategoria(await validateCategoria(chat.ResumoConversa ?? ""));
                await _chatbotRepository.AtualizaHistorico(chatEntity);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Erro ao criar histórico para o chat com ID {ChatId}", chat.ToEntity());
                throw; 
            }
        }

        public async Task<CategoriaConversa> validateCategoria(string resumoConversa)
        {
            try
            {
                if (String.IsNullOrEmpty(resumoConversa))
                    throw new ArgumentNullException(nameof(resumoConversa), "O resumo da conversa não pode ser nulo ou vazio.");

                return (CategoriaConversa)await _chatbotRepository.validaCategoriaComLLM(resumoConversa);
            }
            catch (Exception e)
            {
                _logger.Error(e, "Erro ao validar categoria para o resumo: {ResumoConversa}", resumoConversa);
                throw;
            }
        }

        public async Task<List<ChatDto>> PegaHistoricos()
        {
            try
            {
                var chatlist = new List<ChatDto>();
                var listChatEntity = await _chatbotRepository.PegaHistoricos();
                foreach (var item in listChatEntity)
                    chatlist.Add(new ChatDto(item));

                return chatlist;

            }
            catch (Exception e)
            {
                _logger.Error(e, "Erro ao pegar todos os históricos.");
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

                _logger.Error(e, "Erro ao enviar mensagem ao LLM: {Mensagem}", message);
                throw;
            }
        }
    }
}
