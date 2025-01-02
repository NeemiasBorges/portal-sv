namespace Services.Services.DTO.Chatbot
{
    public class ChoiceDTO
    {
        public int index { get; set; }
        public MessageDTO message { get; set; }
        public object logprobs { get; set; }
        public string finish_reason { get; set; }
    }
}
