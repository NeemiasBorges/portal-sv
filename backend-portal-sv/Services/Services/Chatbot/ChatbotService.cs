using Infra.Repository.Interfaces;
using Services.Services.Chatbot.Interface;

namespace Services.Services.Chatbot
{
    public class ChatbotService : IChatbotService
    {
        private readonly IChatbotRepository _chatbotRepository;
        public ChatbotService(IChatbotRepository chatbotRepository)
        {
            _chatbotRepository = chatbotRepository ?? throw new ArgumentNullException(nameof(chatbotRepository));
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
