using MediatR;

namespace AppControleMantec.Application.AppEstoque.Commands
{
    public class EstoqueCreateCommand : IRequest<bool>
    {
        public int ProdutoID { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    }
}
