namespace Services.Services.DTO.Chatbot
{
    public class ResponseDTO
    {
        public string? @object { get; set; }
        public string? id { get; set; }
        public int? created { get; set; }
        public string? model { get; set; }
        public string? system_fingerprint { get; set; }
        public List<ChoiceDTO> choices { get; set; } = new List<ChoiceDTO>();
        public UsageDTO usage { get; set; } = new UsageDTO();
    }
}
