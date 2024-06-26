using MediatR;
using AppControleMantec.Application.DTOs;

namespace AppControleMantec.Application.AppOrdemDeServico.Queries
{
    public class OrdemDeServicoGetByIdQuery : IRequest<OrdemDeServicoDTO>
    {
        public string Id { get; set; }

        public OrdemDeServicoGetByIdQuery(string id)
        {
            Id = id;
        }
    }
}
