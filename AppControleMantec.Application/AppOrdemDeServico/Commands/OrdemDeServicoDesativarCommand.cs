using MediatR;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class OrdemDeServicoDesativarCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
