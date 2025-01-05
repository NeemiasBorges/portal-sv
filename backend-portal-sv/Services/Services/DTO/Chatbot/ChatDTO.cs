using Domain.Entity.Chatbot;
using Domain.Entity.Chatbot.Enums;

namespace Services.Services.DTO.Chatbot
{
    public class ChatDTO
    {
        public Guid Id { get; set; }
        public DateTime DataMensagem { get; set; } = DateTime.Now;
        public string ResumoConversa { get; set; }
        public bool ConversaConcluida { get; set; }
        public string EmailCliente { get; set; }
        public CategoriaConversa Categoria { get; set; } = CategoriaConversa.Outros;
        public string? Satisfacao { get; set; }

        public ChatDTO() { }
        public ChatDTO(Chat chatEntity) {
            this.Id = chatEntity.Id;
            this.DataMensagem = chatEntity.dataMensagem;
            this.ResumoConversa = chatEntity.ResumoConversa;
            this.ConversaConcluida = chatEntity.conversaConcluida;
            this.EmailCliente = chatEntity.EmailCliente;
            this.Categoria = chatEntity.Categoria;
            this.Satisfacao  = chatEntity.Satisfacao;
        }

        public ChatDTO(Guid id, DateTime dataMensagem, string resumoConversa, bool conversaConcluida, string emailCliente, CategoriaConversa categoria, string satisfacao)
        {
            Id = id;
            DataMensagem = dataMensagem;
            ResumoConversa = resumoConversa;
            ConversaConcluida = conversaConcluida;
            EmailCliente = emailCliente;
            Categoria = categoria;
            Satisfacao = satisfacao;
        }

        
        public Chat ToEntity()
        {
            return new Chat(this.Id,
                this.DataMensagem,
                this.ResumoConversa,
                this.ConversaConcluida,
                this.EmailCliente,
                this.Categoria,
                this.Satisfacao);
        }
    }
}
