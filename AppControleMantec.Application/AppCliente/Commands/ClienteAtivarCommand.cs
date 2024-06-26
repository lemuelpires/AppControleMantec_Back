using MediatR;

namespace AppControleMantec.Application.AppCliente.Commands
{
    public class ClienteAtivarCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public ClienteAtivarCommand(string id)
        {
            Id = id;
        }
    }
}
