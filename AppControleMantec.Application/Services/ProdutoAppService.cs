using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Domain.Interfaces;
using MongoDB.Bson;

namespace AppControleMantec.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAppService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutosAsync()
        {
            var produtos = await _produtoRepository.GetProdutosAsync();
            var produtoDtos = new List<ProdutoDTO>();

            foreach (var produto in produtos)
            {
                produtoDtos.Add(new ProdutoDTO
                {
                    Id = produto.Id ?? throw new InvalidOperationException("Id do produto não pode ser nulo"),
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Quantidade = produto.Quantidade,
                    Preco = produto.Preco,
                    Fornecedor = produto.Fornecedor,
                    DataEntrada = produto.DataEntrada,
                    ImagemURL = produto.ImagemURL,
                    Ativo = produto.Ativo
                });
            }

            return produtoDtos;
        }

        public async Task<ProdutoDTO> GetProdutoByIdAsync(string id)
        {
            var produto = await _produtoRepository.GetProdutoByIdAsync(id);
            return produto != null ?
                new ProdutoDTO
                {
                    Id = produto.Id ?? throw new InvalidOperationException("Id do produto não pode ser nulo"),
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Quantidade = produto.Quantidade,
                    Preco = produto.Preco,
                    Fornecedor = produto.Fornecedor,
                    DataEntrada = produto.DataEntrada,
                    ImagemURL = produto.ImagemURL,
                    Ativo = produto.Ativo
                } :
                new ProdutoDTO(); // Retorna um ProdutoDTO vazio ou padrão
        }

        public async Task<string> InsertProdutoAsync(ProdutoDTO produtoDto)
        {
            if (produtoDto is null)
            {
                throw new ArgumentNullException(nameof(produtoDto));
            }

            // Verificação e lançamento de exceção para propriedades obrigatórias
            if (string.IsNullOrEmpty(produtoDto.Nome))
            {
                throw new ArgumentException("O nome do produto não pode ser nulo ou vazio.", nameof(produtoDto.Nome));
            }

            if (produtoDto.Fornecedor is null)
            {
                throw new ArgumentNullException(nameof(produtoDto.Fornecedor), "O fornecedor do produto não pode ser nulo");
            }

            var produto = new Produto
            {
                Id = ObjectId.GenerateNewId().ToString(),
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                Quantidade = produtoDto.Quantidade,
                Preco = produtoDto.Preco,
                Fornecedor = produtoDto.Fornecedor,
                DataEntrada = produtoDto.DataEntrada,
                ImagemURL = produtoDto.ImagemURL,
                Ativo = produtoDto.Ativo
            };

            // Inserção do produto no repositório
            await _produtoRepository.InsertProdutoAsync(produto);

            // Retorne o ID do produto criado
            return produto.Id;
        }

        public async Task UpdateProdutoAsync(ProdutoDTO produtoDto)
        {
            if (produtoDto is null)
            {
                throw new ArgumentNullException(nameof(produtoDto));
            }

            // Verificação do Id do produto
            if (produtoDto.Id is null)
            {
                throw new ArgumentNullException(nameof(produtoDto.Id), "O Id do produto não pode ser nulo");
            }

            // Busca do produto no repositório
            var produto = await _produtoRepository.GetProdutoByIdAsync(produtoDto.Id);
            if (produto is null)
            {
                throw new Exception("Produto não encontrado");
            }

            // Atualização das propriedades do produto
            produto.Nome = produtoDto.Nome ?? throw new ArgumentNullException(nameof(produtoDto.Nome), "O nome do produto não pode ser nulo");
            produto.Descricao = produtoDto.Descricao;
            produto.Quantidade = produtoDto.Quantidade;
            produto.Preco = produtoDto.Preco;
            produto.Fornecedor = produtoDto.Fornecedor ?? throw new ArgumentNullException(nameof(produtoDto.Fornecedor), "O fornecedor do produto não pode ser nulo");
            produto.DataEntrada = produtoDto.DataEntrada;
            produto.ImagemURL = produtoDto.ImagemURL;
            produto.Ativo = produtoDto.Ativo;

            // Atualização do produto no repositório
            await _produtoRepository.UpdateProdutoAsync(produto);
        }

        public async Task DesativarProdutoAsync(string id)
        {
            // Desativação do produto no repositório
            await _produtoRepository.DesativarProdutoAsync(id);
        }

        public async Task AtivarProdutoAsync(string id)
        {
            // Ativação do produto no repositório
            await _produtoRepository.AtivarProdutoAsync(id);
        }
    }
}
