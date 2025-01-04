using Services.Services.DTO.Chatbot;

namespace Services.Services.Chatbot.Interface
{
    public interface IChatbotService
    {
        Task<string> SendMessage(string message);
        Task CriaHistorico(ChatDTO chat);
        Task AtualizaHistorico(ChatDTO chat);
        Task<List<ChatDTO>> PegaHistoricos();
    }
}
