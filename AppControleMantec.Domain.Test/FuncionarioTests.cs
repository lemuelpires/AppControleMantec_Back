using System;
using Xunit;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Tests
{
    public class FuncionarioTests
    {
        [Fact]
        public void Funcionario_CriarFuncionarioValido_DeveSerValido()
        {
            // Arrange
            var nome = "Funcionario Teste";
            var cargo = "Cargo Teste";
            var telefone = "1234567890";
            var email = "teste@funcionario.com";
            var dataContratacao = DateTime.UtcNow;

            // Act
            var funcionario = new Funcionario(nome, cargo, telefone, email, dataContratacao);

            // Assert
            Assert.NotNull(funcionario);
            Assert.Equal(nome, funcionario.Nome);
            Assert.Equal(cargo, funcionario.Cargo);
            Assert.Equal(telefone, funcionario.Telefone);
            Assert.Equal(email, funcionario.Email);
            Assert.Equal(dataContratacao, funcionario.DataContratacao);
            Assert.True(funcionario.Ativo);
        }

        [Fact]
        public void Funcionario_CriarFuncionarioComNomeInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Fu"; // Nome inválido com menos de 3 caracteres
            var cargo = "Cargo Teste";
            var telefone = "1234567890";
            var email = "teste@funcionario.com";
            var dataContratacao = DateTime.UtcNow;

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Funcionario(nome, cargo, telefone, email, dataContratacao));
            Assert.Equal("Nome inválido. O nome deve conter no mínimo 3 caracteres.", exception.Message);
        }

        [Fact]
        public void Funcionario_CriarFuncionarioComEmailInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Funcionario Teste";
            var cargo = "Cargo Teste";
            var telefone = "1234567890";
            var email = "emailinvalido"; // Email inválido
            var dataContratacao = DateTime.UtcNow;

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Funcionario(nome, cargo, telefone, email, dataContratacao));
            Assert.Equal("Email inválido. O email deve ser válido.", exception.Message);
        }

        [Fact]
        public void Funcionario_CriarFuncionarioComCargoInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Funcionario Teste";
            var cargo = new string('a', 101); // Cargo inválido com mais de 100 caracteres
            var telefone = "1234567890";
            var email = "teste@funcionario.com";
            var dataContratacao = DateTime.UtcNow;

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Funcionario(nome, cargo, telefone, email, dataContratacao));
            Assert.Equal("Cargo inválido. O cargo deve conter no máximo 100 caracteres.", exception.Message);
        }

        [Fact]
        public void Funcionario_CriarFuncionarioComTelefoneInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Funcionario Teste";
            var cargo = "Cargo Teste";
            var telefone = new string('1', 21); // Telefone inválido com mais de 20 caracteres
            var email = "teste@funcionario.com";
            var dataContratacao = DateTime.UtcNow;

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Funcionario(nome, cargo, telefone, email, dataContratacao));
            Assert.Equal("Telefone inválido. O telefone deve conter no máximo 20 caracteres.", exception.Message);
        }

        [Fact]
        public void Funcionario_Desativar_DeveEstarInativo()
        {
            // Arrange
            var nome = "Funcionario Teste";
            var cargo = "Cargo Teste";
            var telefone = "1234567890";
            var email = "teste@funcionario.com";
            var dataContratacao = DateTime.UtcNow;
            var funcionario = new Funcionario(nome, cargo, telefone, email, dataContratacao);

            // Act
            funcionario.Desativar();

            // Assert
            Assert.False(funcionario.Ativo);
        }
    }
}
