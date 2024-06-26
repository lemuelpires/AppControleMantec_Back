using AppControleMantec.Application.DTOs;
using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace AppControleMantec.Application.AppEstoque.Commands
{
    public abstract class EstoqueCommand : IRequest<EstoqueDTO>
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
