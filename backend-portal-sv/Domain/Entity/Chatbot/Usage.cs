namespace Domain.Entity
{
    public class Usage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }

        public Usage() {}
        public Usage(int prompt_tokens, int completion_tokens, int total_tokens)
        {
            this.prompt_tokens = prompt_tokens;
            this.completion_tokens = completion_tokens;
            this.total_tokens = total_tokens;
        }
    }
}
