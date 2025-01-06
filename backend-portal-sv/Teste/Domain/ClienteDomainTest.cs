using Domain.Entity;


namespace Test.Domain
{
    /// <summary>
    /// Testes unitários para validar o comportamento da entidade Cliente,
    /// incluindo criação e validação de campos obrigatórios
    /// </summary>
    public class ClienteDomainTest
    {

        /// <summary>
        /// Cria validacao do cliente - Deve Criar a Instancia <see cref="Cliente"/>
        /// </summary>
        [Fact]
        public void Cliente_CriacaoValida_DeveCriarInstancia()
        {
            var now = DateTime.Now;

            var cliente = new Cliente(1, "João Silva", "joao@email.com", "12345678901",
                "11999999999", "M", "12345678", now);

            Assert.Equal(1, cliente.Id);
            Assert.Equal("João Silva", cliente.nome);
            Assert.Equal("joao@email.com", cliente.email);
            Assert.Equal("12345678901", cliente.cpf);
            Assert.Equal("11999999999", cliente.telefone);
            Assert.Equal("M", cliente.sexo);
            Assert.Equal("12345678", cliente.cep);
            Assert.Equal(now, cliente.datacriacao);
        }


        /// <summary>
        /// Validacao do Cliente os campos obrigatorios devem lancar Excecao 
        /// </summary>
        [Theory]
        [InlineData(null, "email@test.com", "12345678901", "11999999999", "M", "12345678")]
        [InlineData("Nome", null, "12345678901", "11999999999", "M", "12345678")]
        [InlineData("Nome", "email@test.com", null, "11999999999", "M", "12345678")]
        [InlineData("Nome", "email@test.com", "12345678901", null, "M", "12345678")]
        [InlineData("Nome", "email@test.com", "12345678901", "11999999999", null, "12345678")]
        [InlineData("Nome", "email@test.com", "12345678901", "11999999999", "M", null)]
        public void Cliente_CamposObrigatoriosNulos_DeveLancarExcecao(string nome, string email,
                string cpf, string telefone, string sexo, string cep)
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Cliente(1, nome, email, cpf, telefone, sexo, cep, DateTime.Now));
        }
    }
}

