
namespace Domain.Entity
{
    public class Choice
    {
        public int index { get; set; }
        public Message? message { get; set; } = new Message();
        public object logprobs { get; set; } = new object();
        public string? finish_reason { get; set; } = "";

        public Choice(){}
        public Choice(int index, Message message, object logprobs, string finish_reason)
        {
            this.index = index;
            this.message = message == null ? throw new ArgumentNullException(nameof(message)) : message;
            this.logprobs = logprobs ?? throw new ArgumentNullException(nameof(logprobs));
            this.finish_reason = finish_reason ?? throw new ArgumentNullException(nameof(finish_reason));
        }
    }
}
