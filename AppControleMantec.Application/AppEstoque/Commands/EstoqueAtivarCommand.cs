using MediatR;

namespace AppControleMantec.Application.AppEstoque.Commands
{
    public class EstoqueAtivarCommand : IRequest<bool>
    {
        public string? Id { get; set; }
    }
}
