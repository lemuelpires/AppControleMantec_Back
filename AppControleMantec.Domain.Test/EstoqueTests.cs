using System;
using Xunit;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Tests
{
    public class EstoqueTests
    {
        [Fact]
        public void Estoque_CriarEstoqueValido_DeveSerValido()
        {
            // Arrange
            var produtoID = 1;
            var quantidade = 10;
            var dataAtualizacao = DateTime.UtcNow;

            // Act
            var estoque = new Estoque(produtoID, quantidade, dataAtualizacao);

            // Assert
            Assert.NotNull(estoque);
            Assert.Equal(produtoID, estoque.ProdutoID);
            Assert.Equal(quantidade, estoque.Quantidade);
            Assert.Equal(dataAtualizacao, estoque.DataAtualizacao);
            Assert.True(estoque.Ativo);
        }

        [Fact]
        public void Estoque_CriarEstoqueComProdutoIDInvalido_DeveLancarExcecao()
        {
            // Arrange
            var produtoID = 0; // ProdutoID inválido
            var quantidade = 10;
            var dataAtualizacao = DateTime.UtcNow;

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Estoque(produtoID, quantidade, dataAtualizacao));
            Assert.Equal("Produto inválido. Selecione um produto válido.", exception.Message);
        }

        [Fact]
        public void Estoque_CriarEstoqueComQuantidadeInvalida_DeveLancarExcecao()
        {
            // Arrange
            var produtoID = 1;
            var quantidade = -1; // Quantidade inválida
            var dataAtualizacao = DateTime.UtcNow;

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Estoque(produtoID, quantidade, dataAtualizacao));
            Assert.Equal("Quantidade inválida. A quantidade não pode ser negativa.", exception.Message);
        }

        [Fact]
        public void Estoque_AtualizarQuantidade_DeveAtualizarCorretamente()
        {
            // Arrange
            var produtoID = 1;
            var quantidadeInicial = 10;
            var dataAtualizacaoInicial = DateTime.UtcNow;
            var estoque = new Estoque(produtoID, quantidadeInicial, dataAtualizacaoInicial);

            var novaQuantidade = 20;
            var novaDataAtualizacao = DateTime.UtcNow.AddMinutes(5);

            // Act
            estoque.AtualizarQuantidade(novaQuantidade, novaDataAtualizacao);

            // Assert
            Assert.Equal(novaQuantidade, estoque.Quantidade);
            Assert.Equal(novaDataAtualizacao, estoque.DataAtualizacao);
        }

        [Fact]
        public void Estoque_Desativar_DeveEstarInativo()
        {
            // Arrange
            var produtoID = 1;
            var quantidade = 10;
            var dataAtualizacao = DateTime.UtcNow;
            var estoque = new Estoque(produtoID, quantidade, dataAtualizacao);

            // Act
            estoque.Desativar();

            // Assert
            Assert.False(estoque.Ativo);
        }
    }
}
