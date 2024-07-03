using MediatR;

namespace AppControleMantec.Application.AppEstoque.Commands
{
    public class EstoqueDesativarCommand : IRequest<bool>
    {
        public string? Id { get; set; }
    }
}
