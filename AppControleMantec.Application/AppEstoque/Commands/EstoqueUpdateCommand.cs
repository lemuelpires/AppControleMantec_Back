using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AppControleMantec.Application.AppEstoque.Commands
{
    public class EstoqueUpdateCommand : IRequest<bool>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ProdutoID")]
        [BsonRepresentation(BsonType.String)]
        public string? ProdutoID { get; set; }

        [BsonElement("Quantidade")]
        public int Quantidade { get; set; }

        [BsonElement("DataAtualizacao")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataAtualizacao { get; set; }

        [BsonElement("Ativo")]
        public bool Ativo { get; set; }
    }
}
