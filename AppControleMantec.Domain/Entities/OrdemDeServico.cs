using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using AppControleMantec.Domain.Validation;

namespace AppControleMantec.Domain.Entities
{
    public class OrdemDeServico
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("ClienteID")]
        [BsonRepresentation(BsonType.String)]
        public string ClienteID { get; set; }

        [BsonElement("FuncionarioID")]
        [BsonRepresentation(BsonType.String)]
        public string FuncionarioID { get; set; }

        [BsonElement("ProdutoID")]
        [BsonRepresentation(BsonType.String)]
        public string ProdutoID { get; set; }

        [BsonElement("ServicoID")]
        [BsonRepresentation(BsonType.String)]
        public string ServicoID { get; set; }

        [BsonElement("DataEntrada")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataEntrada { get; set; }

        [BsonElement("DataConclusao")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? DataConclusao { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("Observacoes")]
        public string Observacoes { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnore]
        public virtual Cliente Cliente { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnore]
        public virtual Funcionario Funcionario { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnore]
        public virtual Produto Produto { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnore]
        public virtual Servico Servico { get; set; }

        #region Construtores
        // Construtor padrão necessário para o MongoDB Driver
        public OrdemDeServico()
        {
        }

        public OrdemDeServico(string clienteID, string funcionarioID, string servicoID, DateTime dataEntrada, string status, string observacoes)
        {
            ValidateDomain(clienteID, funcionarioID, servicoID, dataEntrada, status, observacoes);
            ClienteID = clienteID;
            FuncionarioID = funcionarioID;
            ServicoID = servicoID;
            DataEntrada = dataEntrada;
            Status = status;
            Observacoes = observacoes;
            Ativo = true;
        }

        public OrdemDeServico(string id, string clienteID, string funcionarioID, string produtoID, string servicoID, DateTime dataEntrada, DateTime? dataConclusao, string status, string observacoes, bool ativo)
        {
            Id = id;
            ClienteID = clienteID;
            FuncionarioID = funcionarioID;
            ProdutoID = produtoID;
            ServicoID = servicoID;
            DataEntrada = dataEntrada;
            DataConclusao = dataConclusao;
            Status = status;
            Observacoes = observacoes;
            Ativo = ativo;
        }
        #endregion

        #region Métodos Públicos
        public void ConcluirOrdem(DateTime dataConclusao)
        {
            DataConclusao = dataConclusao;
            Status = "Concluída";
        }

        public void CancelarOrdem()
        {
            Status = "Cancelada";
            Ativo = false;
        }
        #endregion

        #region Métodos Privados de Validação
        private void ValidateDomain(string clienteID, string funcionarioID, string servicoID, DateTime dataEntrada, string status, string observacoes)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(clienteID) || clienteID == "0", "Cliente inválido. Selecione um cliente válido.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(funcionarioID), "Funcionário inválido. Selecione um funcionário válido.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(servicoID), "Serviço inválido. Selecione um serviço válido.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(status), "Status inválido. O status é obrigatório.");
            DomainExceptionValidation.When(status.Length > 50, "Status inválido. O status deve ter no máximo 50 caracteres.");

            // Aqui você pode adicionar validações adicionais conforme necessário

            Status = status;
            Observacoes = observacoes;
        }
        #endregion
    }
}
