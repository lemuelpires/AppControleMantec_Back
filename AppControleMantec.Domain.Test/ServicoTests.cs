using System;
using Xunit;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Tests
{
    public class ServicoTests
    {
        [Fact]
        public void Servico_CriarServicoValido_DeveSerValido()
        {
            // Arrange
            var nome = "Serviço Teste";
            var descricao = "Descrição do serviço teste";
            var preco = 99.99m;

            // Act
            var servico = new Servico(nome, descricao, preco);

            // Assert
            Assert.NotNull(servico);
            Assert.Equal(nome, servico.Nome);
            Assert.Equal(descricao, servico.Descricao);
            Assert.Equal(preco, servico.Preco);
            Assert.True(servico.Ativo);
        }

        [Fact]
        public void Servico_CriarServicoComNomeInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Se"; // Nome inválido com menos de 3 caracteres
            var descricao = "Descrição do serviço teste";
            var preco = 99.99m;

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Servico(nome, descricao, preco));
            Assert.Equal("Nome inválido. O nome deve conter no mínimo 3 caracteres.", exception.Message);
        }

        [Fact]
        public void Servico_CriarServicoComPrecoInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Serviço Teste";
            var descricao = "Descrição do serviço teste";
            var preco = -1m; // Preço inválido

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Servico(nome, descricao, preco));
            Assert.Equal("Preço inválido. O preço não pode ser negativo.", exception.Message);
        }

        [Fact]
        public void Servico_Desativar_DeveDesativarServico()
        {
            // Arrange
            var nome = "Serviço Teste";
            var descricao = "Descrição do serviço teste";
            var preco = 99.99m;
            var servico = new Servico(nome, descricao, preco);

            // Act
            servico.Desativar();

            // Assert
            Assert.False(servico.Ativo);
        }
    }
}
