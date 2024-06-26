using MediatR;
using AppControleMantec.Domain.Entities;
using System;

namespace AppControleMantec.Application.AppCliente.Queries
{
    public class ClienteGetByIdQuery : IRequest<Cliente>
    {
        public Guid Id { get; set; }

        public ClienteGetByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
