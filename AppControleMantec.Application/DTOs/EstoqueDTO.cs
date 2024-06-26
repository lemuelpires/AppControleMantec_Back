using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppControleMantec.Application.DTOs
{
    public class EstoqueDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ProdutoID")]
        public int ProdutoID { get; set; }

        [BsonElement("Quantidade")]
        public int Quantidade { get; set; }

        [BsonElement("DataAtualizacao")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataAtualizacao { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }
    }
}
