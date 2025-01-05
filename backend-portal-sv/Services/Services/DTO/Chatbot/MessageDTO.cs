
namespace Services.Services.DTO.Chatbot
{
    public class MessageDTO
    {
        public MessageDTO() {}
        public string role { get; set; }
        public string content { get; set; }

        public MessageDTO(string role, string content)
        {
            this.role = role ?? throw new ArgumentNullException(nameof(role));
            this.content = content ?? throw new ArgumentNullException(nameof(content));
        }
    }
}
