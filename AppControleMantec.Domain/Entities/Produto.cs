using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Entities
{
    public class Produto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("Quantidade")]
        public int Quantidade { get; set; }

        [BsonElement("Preco")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Preco { get; set; }

        [BsonElement("Fornecedor")]
        public string Fornecedor { get; set; }

        [BsonElement("DataEntrada")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataEntrada { get; set; }

        [BsonElement("ImagemURL")]
        public string ImagemURL { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnore]
        public virtual ICollection<OrdemDeServico> OrdensDeServico { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnore]
        public virtual Estoque Estoque { get; set; }

        #region Construtores
        // Construtor padrão necessário para o MongoDB Driver
        public Produto()
        {
        }

        public Produto(string nome, string descricao, int quantidade, decimal preco, string fornecedor, DateTime dataEntrada, string imagemURL)
        {
            ValidateDomain(nome, descricao, quantidade, preco, fornecedor);
            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
            Preco = preco;
            Fornecedor = fornecedor;
            DataEntrada = dataEntrada;
            ImagemURL = imagemURL;
            Ativo = true;
        }

        public Produto(string id, string nome, string descricao, int quantidade, decimal preco, string fornecedor, DateTime dataEntrada, string imagemURL, bool ativo)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
            Preco = preco;
            Fornecedor = fornecedor;
            DataEntrada = dataEntrada;
            ImagemURL = imagemURL;
            Ativo = ativo;
        }
        #endregion

        #region Métodos Públicos
        public void AtualizarEstoque(int novaQuantidade)
        {
            Quantidade = novaQuantidade;
        }

        public void AtualizarPreco(decimal novoPreco)
        {
            Preco = novoPreco;
        }

        public void Desativar()
        {
            Ativo = false;
        }
        #endregion

        #region Métodos Privados de Validação
        private void ValidateDomain(string nome, string descricao, int quantidade, decimal preco, string fornecedor)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido. O nome deve conter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(quantidade < 0, "Quantidade inválida. A quantidade não pode ser negativa.");

            DomainExceptionValidation.When(preco < 0, "Preço inválido. O preço não pode ser negativo.");

            DomainExceptionValidation.When(fornecedor != null && fornecedor.Length > 100, "Fornecedor inválido. O nome do fornecedor deve conter no máximo 100 caracteres.");

            // Aqui você pode adicionar validações adicionais conforme necessário

            Nome = nome;
            Descricao = descricao;
            Quantidade = quantidade;
            Preco = preco;
            Fornecedor = fornecedor;
        }
        #endregion
    }
}
