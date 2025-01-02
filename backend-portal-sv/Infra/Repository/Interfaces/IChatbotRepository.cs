namespace Infra.Repository.Interfaces
{
    public interface IChatbotRepository
    {
        Task<string> SendMessage(string message);
        Task<string> CreatePrompt(string userMessage);
        Task<object> CreateRequestPayload(string prompt);
        Task<string> ResponseHandler(HttpResponseMessage response);
    }
}
