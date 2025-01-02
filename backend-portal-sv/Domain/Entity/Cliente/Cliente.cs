
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    [Table("clientes")]
    public class Cliente
    {
        public Cliente() { }

        [Key]
        public int Id { get; private set; }
        public string nome { get; private set; }
        public int id_endereco { get; private set; }
        public int id_telefone { get; private set; }
        public string email { get; private set; }
        public Cliente(int id, string nome, int id_endereco, int id_telefone, string email)
        {
            Id = id;
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.id_endereco = id_endereco;
            this.id_telefone = id_telefone;
            this.email = email ?? throw new ArgumentNullException(nameof(email));
        }
    }
}
