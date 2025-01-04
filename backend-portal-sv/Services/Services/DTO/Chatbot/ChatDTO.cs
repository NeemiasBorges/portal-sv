using Domain.Entity.Chatbot;
using Domain.Entity.Chatbot.Enums;

namespace Services.Services.DTO.Chatbot
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public DateTime DataMensagem { get; set; }
        public string ResumoConversa { get; set; }
        public bool ConversaConcluida { get; set; }
        public string EmailCliente { get; set; }
        public CategoriaConversa Categoria { get; set; }
        public string Satisfacao { get; set; }

        public ChatDTO() { }
        public ChatDTO(Chat chatEntity) {
            new ChatDTO(chatEntity.Id,
                          chatEntity.dataMensagem,
                          chatEntity.ResumoConversa,
                          chatEntity.conversaConcluida,
                          chatEntity.EmailCliente,
                          chatEntity.Categoria,
                          chatEntity.Satisfacao);
        }

        public ChatDTO(int id, DateTime dataMensagem, string resumoConversa, bool conversaConcluida, string emailCliente, CategoriaConversa categoria, string satisfacao)
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
