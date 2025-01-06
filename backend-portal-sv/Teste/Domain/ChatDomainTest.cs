using Domain.Entity.Chatbot;
using Domain.Entity.Chatbot.Enums;

namespace Test.Domain
{
    /// <summary>
    /// Classe de testes para o domínio de chat.
    /// </summary>
    public class ChatDomainTest
    {
        /// <summary>
        /// Verifica se a criação de uma instância de <see cref="Chat"/> ocorre corretamente.
        /// </summary>
        [Fact]
        public void Chat_CriacaoValida_DeveCriarInstancia()
        {
            var id = Guid.NewGuid();
            var data = DateTime.Now;
            var resumo = "Teste de conversa";
            var email = "teste@email.com";
            var categoria = CategoriaConversa.Outros;
            var satisfacao = "5";

            var chat = new Chat(id, data, resumo, true, email, categoria, satisfacao);

            Assert.Equal(id, chat.Id);
            Assert.Equal(data, chat.dataMensagem);
            Assert.Equal(resumo, chat.ResumoConversa);
            Assert.True(chat.conversaConcluida);
            Assert.Equal(email, chat.EmailCliente);
            Assert.Equal(categoria, chat.Categoria);
            Assert.Equal(satisfacao, chat.Satisfacao);
        }

        /// <summary>
        /// Testa se uma exceção é lançada ao tentar criar um <see cref="Chat"/> com o resumo nulo.
        /// </summary>
        [Fact]
        public void Chat_ResumoConversaNulo_DeveLancarExcecao()
        {
            var id = Guid.NewGuid();

            Assert.Throws<ArgumentNullException>(() =>
                new Chat(id, DateTime.Now, null, true, "email@test.com", CategoriaConversa.Outros, "5"));
        }

        /// <summary>
        /// Testa se uma exceção é lançada ao tentar criar um <see cref="Chat"/> com um email de cliente invalido
        /// </summary>
        [Fact]
        public void Chat_EmailClienteInvalido_DeveLancarExcecao()
        {
            var id = Guid.NewGuid();

            Assert.Throws<ArgumentNullException>(() =>
                new Chat(id, DateTime.Now, "resumo", true, null, CategoriaConversa.Outros, "5"));
        }

        /// <summary>
        /// Testa a atualização da categoria em uma instância de <see cref="Chat"/>
        /// </summary>
        [Fact]
        public void AtualizarCategoria_DeveAtualizarCorretamente()
        {
            var chat = new Chat(Guid.NewGuid(), DateTime.Now, "resumo", true, "email@test.com",
                CategoriaConversa.Outros, "5");

            chat.AtualizarCategoria((CategoriaConversa)5);

            Assert.Equal((CategoriaConversa)5, chat.Categoria);
        }
    }
}
