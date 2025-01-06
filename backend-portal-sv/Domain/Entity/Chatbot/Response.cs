
namespace Domain.Entity
{
    public class Response
    {
        public string? @object { get; set; } = "";
        public string? id { get; set; } = "";
        public int created { get; set; }
        public string? model { get; set; } = "";
        public string? system_fingerprint { get; set; } = "";
        public List<Choice> choices { get; set; } = new List<Choice>();
        public Usage usage { get; set; } = new Usage();

        public Response(){}
        public Response(string @object, string id, int created, string model, string system_fingerprint, List<Choice> choices, Usage usage)
        {
            this.@object = @object ?? throw new ArgumentNullException(nameof(@object));
            this.id = id ?? throw new ArgumentNullException(nameof(id));
            this.created = created;
            this.model = model ?? throw new ArgumentNullException(nameof(model));
            this.system_fingerprint = system_fingerprint ?? throw new ArgumentNullException(nameof(system_fingerprint));
            this.choices = choices ?? new List<Choice>();
            this.usage = usage ?? new Usage();
        }
    }
}
