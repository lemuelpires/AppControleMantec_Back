using MediatR;
using AppControleMantec.Application.DTOs;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AppControleMantec.Application.AppServico.Queries
{
    public class ServicoGetByIdQuery : IRequest<ServicoDTO>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}
