using System;
using Xunit;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Tests
{
    public class ClienteTests
    {
        [Fact]
        public void Cliente_CriarClienteValido_DeveSerValido()
        {
            // Arrange
            var nome = "Cliente Teste";
            var endereco = "Rua Teste, 123";
            var telefone = "1234567890";
            var email = "teste@cliente.com";
            var dataCadastro = DateTime.UtcNow;

            // Act
            var cliente = new Cliente(nome, endereco, telefone, email);

            // Assert
            Assert.NotNull(cliente);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(endereco, cliente.Endereco);
            Assert.Equal(telefone, cliente.Telefone);
            Assert.Equal(email, cliente.Email);
            Assert.True(cliente.Ativo);
            Assert.True(cliente.DataCadastro <= DateTime.UtcNow);
        }

        [Fact]
        public void Cliente_CriarClienteComNomeInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Cl"; // Nome inválido com menos de 3 caracteres
            var endereco = "Rua Teste, 123";
            var telefone = "1234567890";
            var email = "teste@cliente.com";

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Cliente(nome, endereco, telefone, email));
            Assert.Equal("Nome inválido. O nome deve conter no mínimo 3 caracteres.", exception.Message);
        }

        [Fact]
        public void Cliente_CriarClienteComEmailInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Cliente Teste";
            var endereco = "Rua Teste, 123";
            var telefone = "1234567890";
            var email = "emailinvalido"; // Email inválido

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Cliente(nome, endereco, telefone, email));
            Assert.Equal("Email inválido. O email deve ser válido.", exception.Message);
        }

        [Fact]
        public void Cliente_DesativarCliente_DeveEstarInativo()
        {
            // Arrange
            var nome = "Cliente Teste";
            var endereco = "Rua Teste, 123";
            var telefone = "1234567890";
            var email = "teste@cliente.com";
            var cliente = new Cliente(nome, endereco, telefone, email);

            // Act
            cliente.Desativar();

            // Assert
            Assert.False(cliente.Ativo);
        }
    }
}
