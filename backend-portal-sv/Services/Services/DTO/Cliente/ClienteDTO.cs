using System.ComponentModel.DataAnnotations;

namespace Services.Services.DTO.Cliente
{
    public class ClienteDTO
    {
        public ClienteDTO(Domain.Entity.Cliente cliente)
        {
            this.Id = cliente.Id;
            this.nome = cliente.nome;
            this.id_endereco = cliente.id_endereco;
            this.id_telefone = cliente.id_telefone;
            this.email = cliente.email;
        }

        [Required]
        public int Id { get; private set; }
        
        [MaxLength(100)]
        [MinLength(3)]
        public string nome { get; private set; }
        public int id_endereco { get; private set; }
        public int id_telefone { get; private set; }

        [Required]
        [EmailAddress]
        public string email { get; private set; }

        public Domain.Entity.Cliente toEntity()
        {
            return new Domain.Entity.Cliente(this.Id, 
                this.nome, 
                this.id_endereco, 
                this.id_telefone, 
                this.email
                );
        }
    }
}
