namespace Domain.Entity
{
    public class Response
    {
        public string @object { get; set; }
        public string id { get; set; }
        public int created { get; set; }
        public string model { get; set; }
        public string system_fingerprint { get; set; }
        public List<Choice> choices { get; set; }
        public Usage usage { get; set; }
    }
}
