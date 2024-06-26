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
        public int ClienteID { get; set; }

        [BsonElement("FuncionarioID")]
        public int FuncionarioID { get; set; }

        [BsonElement("ProdutoID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ProdutoID { get; set; }

        [BsonElement("ServicoID")]
        public int ServicoID { get; set; }

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
