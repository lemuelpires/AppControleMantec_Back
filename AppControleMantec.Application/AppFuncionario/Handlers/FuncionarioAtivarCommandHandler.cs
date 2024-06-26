using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppFuncionario.Commands;

namespace AppControleMantec.Application.AppFuncionario.Handlers
{
    public class FuncionarioAtivarCommandHandler : IRequestHandler<FuncionarioAtivarCommand, bool>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioAtivarCommandHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<bool> Handle(FuncionarioAtivarCommand request, CancellationToken cancellationToken)
        {
            var funcionario = await _funcionarioRepository.GetFuncionarioByIdAsync(request.Id.ToString());
            if (funcionario == null) return false;

            await _funcionarioRepository.AtivarFuncionarioAsync(request.Id.ToString());
            return true;
        }
    }
}
