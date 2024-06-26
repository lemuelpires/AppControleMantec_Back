using MediatR;

namespace AppControleMantec.Application.AppOrdemDeServico.Commands
{
    public class OrdemDeServicoAtivarCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
