using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AppControleMantec.Domain.Interfaces;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppFuncionario.Commands;

namespace AppControleMantec.Application.AppFuncionario.Handlers
{
    public class FuncionarioCreateCommandHandler : IRequestHandler<FuncionarioCreateCommand, bool>
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioCreateCommandHandler(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<bool> Handle(FuncionarioCreateCommand request, CancellationToken cancellationToken)
        {
            var funcionario = new Funcionario
            {
                Nome = request.Nome,
                Cargo = request.Cargo,
                Telefone = request.Telefone,
                Email = request.Email,
                DataContratacao = request.DataContratacao,
                Ativo = request.Ativo
            };

            await _funcionarioRepository.InsertFuncionarioAsync(funcionario);
            return true;
        }
    }
}
