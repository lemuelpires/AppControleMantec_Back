using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Entities
{
    public class Estoque
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ProdutoID")]
        public int ProdutoID { get; set; }

        [BsonElement("Quantidade")]
        public int Quantidade { get; set; }

        [BsonElement("DataAtualizacao")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataAtualizacao { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnore]
        public Produto Produto { get; set; }

        #region Construtores
        // Construtor padrão necessário para o MongoDB Driver
        public Estoque()
        {
        }

        public Estoque(int produtoID, int quantidade, DateTime dataAtualizacao)
        {
            ValidateDomain(produtoID, quantidade, dataAtualizacao);
            ProdutoID = produtoID;
            Quantidade = quantidade;
            DataAtualizacao = dataAtualizacao;
            Ativo = true;
        }

        public Estoque(string id, int produtoID, int quantidade, DateTime dataAtualizacao, bool ativo)
        {
            Id = id;
            ProdutoID = produtoID;
            Quantidade = quantidade;
            DataAtualizacao = dataAtualizacao;
            Ativo = ativo;
        }
        #endregion

        #region Métodos Públicos
        public void AtualizarQuantidade(int novaQuantidade, DateTime dataAtualizacao)
        {
            ValidateDomain(ProdutoID, novaQuantidade, dataAtualizacao);
            Quantidade = novaQuantidade;
            DataAtualizacao = dataAtualizacao;
        }

        public void Desativar()
        {
            Ativo = false;
        }
        #endregion

        #region Métodos Privados de Validação
        private void ValidateDomain(int produtoID, int quantidade, DateTime dataAtualizacao)
        {
            DomainExceptionValidation.When(produtoID <= 0, "Produto inválido. Selecione um produto válido.");
            DomainExceptionValidation.When(quantidade < 0, "Quantidade inválida. A quantidade não pode ser negativa.");

            // Aqui você pode adicionar validações adicionais conforme necessário

            DataAtualizacao = dataAtualizacao;
        }
        #endregion
    }
}
