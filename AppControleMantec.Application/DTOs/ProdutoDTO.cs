using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AppControleMantec.Application.DTOs
{
    public class ProdutoDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Nome")]
        public string? Nome { get; set; }

        [BsonElement("Descricao")]
        public string? Descricao { get; set; }

        [BsonElement("Quantidade")]
        public int Quantidade { get; set; }

        [BsonElement("Preco")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Preco { get; set; }

        [BsonElement("Fornecedor")]
        public string? Fornecedor { get; set; }

        [BsonElement("DataEntrada")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataEntrada { get; set; }

        [BsonElement("ImagemURL")]
        public string? ImagemURL { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }
    }
}
