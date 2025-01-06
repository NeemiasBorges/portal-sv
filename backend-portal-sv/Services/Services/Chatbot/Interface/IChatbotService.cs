using Domain.Entity.Chatbot.Enums;
using Services.Services.DTO.Chatbot;

namespace Services.Services.Chatbot.Interface
{
    public interface IChatbotService
    {
        Task<string> SendMessage(string message);
        Task CriaHistorico(ChatDto chat);
        Task AtualizaHistorico(ChatDto chat);
        Task<List<ChatDto>> PegaHistoricos();
        Task<CategoriaConversa> validateCategoria(string resumoConversa);

    }
}
