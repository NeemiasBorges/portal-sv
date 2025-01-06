
namespace Domain.Entity
{
    public class Message
    {
        public string role { get; set; } = "";
        public string content { get; set; } = "";

        public Message(){}
        public Message(string role, string content)
        {
            this.role = role ?? throw new ArgumentNullException(nameof(role));
            this.content = content ?? throw new ArgumentNullException(nameof(content));
        }
    }
}
