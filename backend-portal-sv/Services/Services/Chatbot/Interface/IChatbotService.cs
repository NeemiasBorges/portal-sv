namespace Services.Services.Chatbot.Interface
{
    public interface IChatbotService
    {
        Task<string> SendMessage(string message);
    }
}
