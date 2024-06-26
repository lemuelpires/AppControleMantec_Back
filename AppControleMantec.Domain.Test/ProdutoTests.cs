using System;
using Xunit;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_CriarProdutoValido_DeveSerValido()
        {
            // Arrange
            var nome = "Produto Teste";
            var descricao = "Descrição do produto teste";
            var quantidade = 10;
            var preco = 99.99m;
            var fornecedor = "Fornecedor A";
            var dataEntrada = DateTime.UtcNow;
            var imagemURL = "http://example.com/produto.jpg";

            // Act
            var produto = new Produto(nome, descricao, quantidade, preco, fornecedor, dataEntrada, imagemURL);

            // Assert
            Assert.NotNull(produto);
            Assert.Equal(nome, produto.Nome);
            Assert.Equal(descricao, produto.Descricao);
            Assert.Equal(quantidade, produto.Quantidade);
            Assert.Equal(preco, produto.Preco);
            Assert.Equal(fornecedor, produto.Fornecedor);
            Assert.Equal(dataEntrada, produto.DataEntrada);
            Assert.Equal(imagemURL, produto.ImagemURL);
            Assert.True(produto.Ativo);
        }

        [Fact]
        public void Produto_CriarProdutoComNomeInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Pr"; // Nome inválido com menos de 3 caracteres
            var descricao = "Descrição do produto teste";
            var quantidade = 10;
            var preco = 99.99m;
            var fornecedor = "Fornecedor A";
            var dataEntrada = DateTime.UtcNow;
            var imagemURL = "http://example.com/produto.jpg";

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Produto(nome, descricao, quantidade, preco, fornecedor, dataEntrada, imagemURL));
            Assert.Equal("Nome inválido. O nome deve conter no mínimo 3 caracteres.", exception.Message);
        }

        [Fact]
        public void Produto_CriarProdutoComQuantidadeInvalida_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Produto Teste";
            var descricao = "Descrição do produto teste";
            var quantidade = -1; // Quantidade inválida
            var preco = 99.99m;
            var fornecedor = "Fornecedor A";
            var dataEntrada = DateTime.UtcNow;
            var imagemURL = "http://example.com/produto.jpg";

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Produto(nome, descricao, quantidade, preco, fornecedor, dataEntrada, imagemURL));
            Assert.Equal("Quantidade inválida. A quantidade não pode ser negativa.", exception.Message);
        }

        [Fact]
        public void Produto_CriarProdutoComPrecoInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Produto Teste";
            var descricao = "Descrição do produto teste";
            var quantidade = 10;
            var preco = -1m; // Preço inválido
            var fornecedor = "Fornecedor A";
            var dataEntrada = DateTime.UtcNow;
            var imagemURL = "http://example.com/produto.jpg";

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Produto(nome, descricao, quantidade, preco, fornecedor, dataEntrada, imagemURL));
            Assert.Equal("Preço inválido. O preço não pode ser negativo.", exception.Message);
        }

        [Fact]
        public void Produto_CriarProdutoComFornecedorInvalido_DeveLancarExcecao()
        {
            // Arrange
            var nome = "Produto Teste";
            var descricao = "Descrição do produto teste";
            var quantidade = 10;
            var preco = 99.99m;
            var fornecedor = new string('A', 101); // Fornecedor com mais de 100 caracteres
            var dataEntrada = DateTime.UtcNow;
            var imagemURL = "http://example.com/produto.jpg";

            // Act & Assert
            var exception = Assert.Throws<DomainException>(() => new Produto(nome, descricao, quantidade, preco, fornecedor, dataEntrada, imagemURL));
            Assert.Equal("Fornecedor inválido. O nome do fornecedor deve conter no máximo 100 caracteres.", exception.Message);
        }

        [Fact]
        public void Produto_AtualizarEstoque_DeveAtualizarQuantidade()
        {
            // Arrange
            var nome = "Produto Teste";
            var descricao = "Descrição do produto teste";
            var quantidade = 10;
            var preco = 99.99m;
            var fornecedor = "Fornecedor A";
            var dataEntrada = DateTime.UtcNow;
            var imagemURL = "http://example.com/produto.jpg";
            var produto = new Produto(nome, descricao, quantidade, preco, fornecedor, dataEntrada, imagemURL);
            var novaQuantidade = 20;

            // Act
            produto.AtualizarEstoque(novaQuantidade);

            // Assert
            Assert.Equal(novaQuantidade, produto.Quantidade);
        }

        [Fact]
        public void Produto_AtualizarPreco_DeveAtualizarPreco()
        {
            // Arrange
            var nome = "Produto Teste";
            var descricao = "Descrição do produto teste";
            var quantidade = 10;
            var preco = 99.99m;
            var fornecedor = "Fornecedor A";
            var dataEntrada = DateTime.UtcNow;
            var imagemURL = "http://example.com/produto.jpg";
            var produto = new Produto(nome, descricao, quantidade, preco, fornecedor, dataEntrada, imagemURL);
            var novoPreco = 149.99m;

            // Act
            produto.AtualizarPreco(novoPreco);

            // Assert
            Assert.Equal(novoPreco, produto.Preco);
        }

        [Fact]
        public void Produto_Desativar_DeveDesativarProduto()
        {
            // Arrange
            var nome = "Produto Teste";
            var descricao = "Descrição do produto teste";
            var quantidade = 10;
            var preco = 99.99m;
            var fornecedor = "Fornecedor A";
            var dataEntrada = DateTime.UtcNow;
            var imagemURL = "http://example.com/produto.jpg";
            var produto = new Produto(nome, descricao, quantidade, preco, fornecedor, dataEntrada, imagemURL);

            // Act
            produto.Desativar();

            // Assert
            Assert.False(produto.Ativo);
        }
    }
}
