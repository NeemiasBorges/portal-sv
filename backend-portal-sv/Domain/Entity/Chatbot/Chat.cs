using Domain.Entity.Chatbot.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Chatbot
{
    public class Chat
    {
        public Chat() { }

        [Key]
        [Required]
        public int Id { get; private set; }
        public DateTime dataMensagem { get; private set; }
        public string ResumoConversa { get; private set; }
        public bool conversaConcluida { get; private set; }

        public string EmailCliente { get; private set; }

        [AllowedValues("0","1","2","3","4","5","6","7","8","9")]
        public CategoriaConversa Categoria { get; private set; }
        [AllowedValues("1", "2", "3", "4", "5")]
        public string Satisfacao { get; private set; }

        public Chat(int id, DateTime dataMensagem, string resumoConversa, bool conversaConcluida, string emailCliente, CategoriaConversa categoria, string satisfacao)
        {
            Id = id;
            this.dataMensagem = dataMensagem;
            ResumoConversa = resumoConversa ?? throw new ArgumentNullException(nameof(resumoConversa));
            this.conversaConcluida = conversaConcluida;
            EmailCliente = emailCliente ?? throw new ArgumentNullException(nameof(emailCliente));
            Categoria = categoria;
            Satisfacao = satisfacao ?? throw new ArgumentNullException(nameof(satisfacao));
        }

    }
}
