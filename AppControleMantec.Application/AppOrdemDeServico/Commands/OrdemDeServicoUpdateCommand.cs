using System;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class OrdemDeServicoUpdateCommand : IRequest<bool>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ClienteID")]
        [BsonRepresentation(BsonType.String)]
        public string? ClienteID { get; set; }

        [BsonElement("FuncionarioID")]
        [BsonRepresentation(BsonType.String)]
        public string? FuncionarioID { get; set; }

        [BsonElement("ProdutoID")]
        [BsonRepresentation(BsonType.String)]
        public string? ProdutoID { get; set; }

        [BsonElement("ServicoID")]
        [BsonRepresentation(BsonType.String)]
        public string? ServicoID { get; set; }

        [BsonElement("DataEntrada")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataEntrada { get; set; }

        [BsonElement("DataConclusao")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime? DataConclusao { get; set; }

        [BsonElement("Status")]
        public string? Status { get; set; }

        [BsonElement("Observacoes")]
        public string? Observacoes { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }
    }
}
