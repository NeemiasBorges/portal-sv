using Domain.Entity.Chatbot;

namespace Infra.Repository.Interfaces
{
    public interface IChatbotRepository
    {
        Task<string> SendMessage(string message);
        Task<string> CreatePrompt(string userMessage);
        Task<object> CreateRequestPayload(string prompt);
        Task<string> ResponseHandler(HttpResponseMessage response);
        Task CriaHistorico(Chat chat);
        Task AtualizaHistorico(Chat chat);
        Task<List<Chat>> PegaHistoricos();
    }
}
