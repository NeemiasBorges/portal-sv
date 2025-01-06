using Domain.Entity.Chatbot;

namespace Infra.Repository.Interfaces
{
    public interface IChatbotRepository
    {
        Task<string> SendMessageAsync(string userMessage);
        Task<string> CreateChatPrompt(string userMessage, string destinationPrices);
        void ConfigureHttpClient();
        object CreateRequestPayload(string prompt);
        Task<string> HandleResponseAsync(HttpResponseMessage response);
        Task CriaHistorico(Chat chat);
        Task AtualizaHistorico(Chat chat);
        Task<List<Chat>> PegaHistoricos();
        Task<int> validaCategoriaComLLM(string resumoConversa);
    }
}