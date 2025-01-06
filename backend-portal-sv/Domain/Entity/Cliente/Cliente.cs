
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        public int Id { get; private set; }
        public string? nome { get; private set; }
        [EmailAddress]
        public string? email { get; private set; }
        public string? cpf { get; private set; }
        public string? telefone { get; private set; }

        [AllowedValues("M", "F")]
        public string? sexo { get; private set; }
        public string? cep { get; private set; }
        public DateTime datacriacao { get; private set; }
        public Cliente() { }
        public Cliente(int id,
            string nome,
            string email,
            string cpf, 
            string telefone, 
            string sexo,
            string cep,
            DateTime datacriacao)
        {
            Id = id;
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
            this.telefone = telefone ?? throw new ArgumentNullException(nameof(telefone));
            this.sexo = sexo ?? throw new ArgumentNullException(nameof(sexo));
            this.cep = cep ?? throw new ArgumentNullException(nameof(cep));
            this.datacriacao = datacriacao;
        }
    }
}
