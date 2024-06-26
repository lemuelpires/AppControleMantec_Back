using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppControleMantec.Application.DTOs
{
    public class FuncionarioDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string? Nome { get; set; }

        [BsonElement("Cargo")]
        public string? Cargo { get; set; }

        [BsonElement("Telefone")]
        public string? Telefone { get; set; }

        [BsonElement("Email")]
        public string? Email { get; set; }

        [BsonElement("DataContratacao")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataContratacao { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }
    }
}
