using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace AppControleMantec.Application.AppProduto.Commands
{
    public class ProdutoUpdateCommand : IRequest<bool>
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
