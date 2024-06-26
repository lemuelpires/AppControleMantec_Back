using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace AppControleMantec.Application.AppServico.Commands
{
    public class ServicoUpdateCommand : IRequest<bool>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string? Nome { get; set; }

        [BsonElement("Descricao")]
        public string? Descricao { get; set; }

        [BsonElement("Preco")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Preco { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }
    }
}
