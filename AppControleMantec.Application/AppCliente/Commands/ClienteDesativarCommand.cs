using MediatR;

namespace AppControleMantec.Application.AppCliente.Commands
{
    public class ClienteDesativarCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public ClienteDesativarCommand(string id)
        {
            Id = id;
        }
    }
}
