using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace AppControleMantec.Application.AppCliente.Commands
{
    public class ClienteUpdateCommand : IRequest<bool>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string? Nome { get; set; }

        [BsonElement("Endereco")]
        public string? Endereco { get; set; }

        [BsonElement("Telefone")]
        public string? Telefone { get; set; }

        [BsonElement("Email")]
        public string? Email { get; set; }

        [BsonElement("DataCadastro")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataCadastro { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }
    }
}
