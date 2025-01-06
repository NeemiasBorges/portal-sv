namespace Services.Services.DTO.Chatbot
{
    public class UsageDTO
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
        public UsageDTO() {}

        public UsageDTO(int prompt_tokens, int completion_tokens, int total_tokens)
        {
            this.prompt_tokens = prompt_tokens;
            this.completion_tokens = completion_tokens;
            this.total_tokens = total_tokens;
        }
    }
}
