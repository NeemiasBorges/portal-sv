using System.ComponentModel.DataAnnotations;

namespace Services.Services.DTO.Cliente
{
    public class ClienteDTO
    {
        public ClienteDTO() { }

        public ClienteDTO(Domain.Entity.Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "O cliente não pode ser nulo.");

            this.Id = cliente.Id;
            this.Nome = cliente.nome;
            this.Email = cliente.email;
            this.Cpf = cliente.cpf;
            this.Telefone = cliente.telefone;
            this.Sexo = cliente.sexo;
            this.Cep = cliente.cep;
            this.DataCriacao = cliente.datacriacao;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter exatamente 11 caracteres.")]
        public string Cpf { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [Required]
        [RegularExpression("M|F", ErrorMessage = "Sexo deve ser 'M' ou 'F'.")]
        public string Sexo { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve conter exatamente 8 caracteres.")]
        public string Cep { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        public Domain.Entity.Cliente ToEntity()
        {
            return new Domain.Entity.Cliente(
                this.Id,
                this.Nome,
                this.Email,
                this.Cpf,
                this.Telefone,
                this.Sexo,
                this.Cep,
                this.DataCriacao
            );
        }
    }
}
