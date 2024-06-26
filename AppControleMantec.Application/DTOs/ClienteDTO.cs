using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppControleMantec.Application.DTOs
{
    public class ClienteDTO
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