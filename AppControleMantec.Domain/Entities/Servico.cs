using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Entities
{
    public class Servico
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("Preco")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Preco { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnore]
        public virtual ICollection<OrdemDeServico> OrdensDeServico { get; set; }

        #region Construtores
        // Construtor padrão necessário para o MongoDB Driver
        public Servico()
        {
            Id = ObjectId.GenerateNewId().ToString(); // Gera um novo ObjectId para o Id
            Nome = string.Empty;
            Descricao = string.Empty;
            Preco = 0;
            Ativo = true;
            OrdensDeServico = new List<OrdemDeServico>();
        }

        public Servico(string nome, string descricao, decimal preco) : this()
        {
            ValidateDomain(nome, descricao, preco);
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public Servico(string id, string nome, string descricao, decimal preco, bool ativo) : this(nome, descricao, preco)
        {
            Id = id;
            Ativo = ativo;
        }
        #endregion

        #region Métodos Públicos
        public void Desativar()
        {
            Ativo = false;
        }
        #endregion

        #region Métodos Privados de Validação
        private void ValidateDomain(string nome, string descricao, decimal preco)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O nome é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido. O nome deve conter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(preco < 0, "Preço inválido. O preço não pode ser negativo.");
        }
        #endregion
    }
}
