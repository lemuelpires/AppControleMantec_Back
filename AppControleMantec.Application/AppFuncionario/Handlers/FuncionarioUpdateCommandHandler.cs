using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Application.AppFuncionario.Commands;

namespace AppControleMantec.Application.AppFuncionario.Handlers
{
    public class FuncionarioUpdateCommandHandler : IRequestHandler<FuncionarioUpdateCommand, bool>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioUpdateCommandHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<bool> Handle(FuncionarioUpdateCommand request, CancellationToken cancellationToken)
        {
            var funcionario = await _funcionarioRepository.GetFuncionarioByIdAsync(request.Id.ToString());
            if (funcionario == null) return false;

            funcionario.Nome = request.Nome;
            funcionario.Cargo = request.Cargo;
            funcionario.Telefone = request.Telefone;
            funcionario.Email = request.Email;
            funcionario.DataContratacao = request.DataContratacao;
            funcionario.Ativo = request.Ativo;

            await _funcionarioRepository.UpdateFuncionarioAsync(funcionario);
            return true;
        }
    }
}
