using Infra.Repository.Interfaces;
using Services.Services.Chatbot.Interface;
using Services.Services.DTO.Chatbot;

namespace Services.Services.Chatbot
{
    public class ChatbotService : IChatbotService
    {
        private readonly IChatbotRepository _chatbotRepository;
        public ChatbotService(IChatbotRepository chatbotRepository)
        {
            _chatbotRepository = chatbotRepository ?? throw new ArgumentNullException(nameof(chatbotRepository));
        }

        public async Task AtualizaHistorico(ChatDTO chat)
        {
            try
            {
                await _chatbotRepository.AtualizaHistorico(chat.ToEntity());
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task CriaHistorico(ChatDTO chat)
        {
            try
            {
                await _chatbotRepository.CriaHistorico(chat.ToEntity());
            }
            catch (Exception e)
            {
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
                throw;
            }
        }

        public async Task<string> SendMessage(string message)
        {
            try
            {
                var returnMessageFromApi = await _chatbotRepository.SendMessage(message);
                return returnMessageFromApi;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
