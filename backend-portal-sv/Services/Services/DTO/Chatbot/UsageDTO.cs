namespace Services.Services.DTO.Chatbot
{
    public class UsageDTO
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
}
