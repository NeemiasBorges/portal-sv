using Services.Services.DTO.Cliente;

using System.ComponentModel.DataAnnotations;

namespace Test.Domain
{
    /// <summary>
    /// Testes unitários para validar o comportamento do ClienteDTO
    /// incluindo validações de dados e restrições de campos
    /// </summary>
    public class ClienteDTOTests
    {
        private readonly ClienteDTO validDTO = new()
        {
            Id = 1,
            Nome = "João Silva",
            Email = "joao@email.com",
            Cpf = "12345678901",
            Telefone = "11999999999",
            Sexo = "M",
            Cep = "12345678",
            DataCriacao = DateTime.Now
        };

        /// <summary>
        /// ClienteDTO Dados validos deve passar validacao
        /// </summary>
        [Fact]
        public void ClienteDTO_DadosValidos_DevePassarValidacao()
        {
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(validDTO,
                new ValidationContext(validDTO), validationResults, true);

            Assert.True(isValid);
            Assert.Empty(validationResults);
        }


        /// <summary>
        /// ClienteDTO nome invalido deve falhar validacao
        /// </summary>
        [Theory]
        [InlineData("ab")]
        [InlineData("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz")]
        public void ClienteDTO_NomeInvalido_DeveFalharValidacao(string nome)
        {
            var dto = validDTO;
            dto.Nome = nome;

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dto,
                new ValidationContext(dto), validationResults, true);

            Assert.False(isValid);
        }

        /// <summary>
        /// ClienteDTO email invalido deve falhar validacao
        /// </summary>
        [Theory]
        [InlineData("invalido")]
        [InlineData("teste@")]
        [InlineData("@teste.com")]
        public void ClienteDTO_EmailInvalido_DeveFalharValidacao(string email)
        {
            var dto = validDTO;
            dto.Email = email;

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dto,
                new ValidationContext(dto), validationResults, true);

            Assert.False(isValid);
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("123456789012")]
        /// <summary>
        /// ClienteDTO cpf invalido deve falhar validacao
        /// </summary>
        public void ClienteDTO_CpfInvalido_DeveFalharValidacao(string cpf)
        {
            var dto = validDTO;
            dto.Cpf = cpf;

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dto,
                new ValidationContext(dto), validationResults, true);

            Assert.False(isValid);
        }

        [Theory]
        [InlineData("X")]
        [InlineData("A")]
        /// <summary>
        /// ClienteDTO sexo invalido deve falhar validacao
        /// </summary>
        public void ClienteDTO_SexoInvalido_DeveFalharValidacao(string sexo)
        {
            var dto = validDTO;
            dto.Sexo = sexo;

            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(dto,
                new ValidationContext(dto), validationResults, true);

            Assert.False(isValid);
        }
    }
}