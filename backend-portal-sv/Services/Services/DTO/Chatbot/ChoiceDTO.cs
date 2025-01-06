
namespace Services.Services.DTO.Chatbot
{
    public class ChoiceDTO
    {
        public int index { get; set; }
        public MessageDTO message { get; set; } = new MessageDTO();
        public object logprobs { get; set; } = new object();
        public string finish_reason { get; set; } = "";

        public ChoiceDTO(){}
        public ChoiceDTO(int index, MessageDTO message, object logprobs, string finish_reason)
        {
            this.index = index;
            this.message = message ?? throw new ArgumentNullException(nameof(message));
            this.logprobs = logprobs ?? throw new ArgumentNullException(nameof(logprobs));
            this.finish_reason = finish_reason ?? throw new ArgumentNullException(nameof(finish_reason));
        }
    }
}
