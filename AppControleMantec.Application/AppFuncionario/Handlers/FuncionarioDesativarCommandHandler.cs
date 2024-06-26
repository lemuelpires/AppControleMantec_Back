using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppFuncionario.Commands;

namespace AppControleMantec.Application.AppFuncionario.Handlers
{
    public class FuncionarioDesativarCommandHandler : IRequestHandler<FuncionarioDesativarCommand, bool>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioDesativarCommandHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<bool> Handle(FuncionarioDesativarCommand request, CancellationToken cancellationToken)
        {
            var funcionario = await _funcionarioRepository.GetFuncionarioByIdAsync(request.Id.ToString());
            if (funcionario == null) return false;

            await _funcionarioRepository.DesativarFuncionarioAsync(request.Id.ToString());
            return true;
        }
    }
}
