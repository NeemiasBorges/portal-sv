using Domain.Entity.Chatbot;
using Domain.Entity.Chatbot.Enums;
using Services.Services.DTO.Chatbot;

namespace Tests.DTO
{
    /// <summary>
    /// Testes unitários para validar o comportamento do ChatDTO,
    /// incluindo conversões entre entidade e DTO e validações de campos
    /// </summary>
    public class ChatDTOTests
    {

        /// <summary>
        /// Testes para o mapeamento - ChatDTO converter de Entidade <see cref="Chat"/>.
        /// </summary>
        [Fact]
        public void ChatDTO_ConverterDeEntity_DeveMapearCorretamente()
        {
            var chat = new Chat(Guid.NewGuid(), DateTime.Now, "resumo", true,
                "email@test.com", CategoriaConversa.AlteracoesNaApolice, "5");

            var dto = new ChatDto(chat);

            Assert.Equal(chat.Id, dto.Id);
            Assert.Equal(chat.dataMensagem, dto.DataMensagem);
            Assert.Equal(chat.ResumoConversa, dto.ResumoConversa);
            Assert.Equal(chat.conversaConcluida, dto.ConversaConcluida);
            Assert.Equal(chat.EmailCliente, dto.EmailCliente);
            Assert.Equal(chat.Categoria, dto.Categoria);
            Assert.Equal(chat.Satisfacao, dto.Satisfacao);
        }


        /// <summary>
        /// Testes para o mapeamento - Entidade deve converter para DTO <see cref="ChatDto"/>.
        /// </summary>
        [Fact]
        public void ChatDto_ConverterParaEntity_DeveMapearCorretamente()
        {
            var dto = new ChatDto
            {
                Id = Guid.NewGuid(),
                DataMensagem = DateTime.Now,
                ResumoConversa = "resumo",
                ConversaConcluida = true,
                EmailCliente = "email@test.com",
                Categoria = CategoriaConversa.AlteracoesNaApolice,
                Satisfacao = "5"
            };

            var entity = dto.ToEntity();

            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.DataMensagem, entity.dataMensagem);
            Assert.Equal(dto.ResumoConversa, entity.ResumoConversa);
            Assert.Equal(dto.ConversaConcluida, entity.conversaConcluida);
            Assert.Equal(dto.EmailCliente, entity.EmailCliente);
            Assert.Equal(dto.Categoria, entity.Categoria);
            Assert.Equal(dto.Satisfacao, entity.Satisfacao);
        }

        [Fact]
        public void ChatDTO_EntityNula_DeveLancarExcecao()
        {
            Assert.Throws<ArgumentNullException>(() => new ChatDto(null));
        }
    }
}
