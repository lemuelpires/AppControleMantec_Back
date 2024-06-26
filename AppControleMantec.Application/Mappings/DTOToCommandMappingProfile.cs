/*using AutoMapper;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Application.AppProduto.Commands;
using AppControleMantec.Application.AppServico.Commands;
using AppControleMantec.Application.AppCliente.Commands;
using AppControleMantec.Application.AppEstoque.Commands;
using AppControleMantec.Application.AppFuncionario.Commands;
using AppControleMantec.Application.AppOrdemDeServico.Commands;
using AppControleMantec.Domain.Entities;

namespace AppControleMantec.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProdutoDTO, ProdutoCreateCommand>();
            CreateMap<ProdutoDTO, ProdutoUpdateCommand>();

            CreateMap<ServicoDTO, ServicoCreateCommand>();
            CreateMap<ServicoDTO, ServicoUpdateCommand>();

            CreateMap<ClienteDTO, ClienteCreateCommand>();
            CreateMap<ClienteDTO, ClienteUpdateCommand>();

            CreateMap<EstoqueDTO, EstoqueCreateCommand>();
            CreateMap<EstoqueDTO, EstoqueUpdateCommand>();

            CreateMap<FuncionarioDTO, FuncionarioCreateCommand>();
            CreateMap<FuncionarioDTO, FuncionarioUpdateCommand>();

            CreateMap<OrdemDeServicoDTO, OrdemDeServicoCreateCommand>();
            CreateMap<OrdemDeServicoDTO, OrdemDeServicoUpdateCommand>();

            // Mapeamento inverso
            CreateMap<ProdutoCreateCommand, ProdutoDTO>();
            CreateMap<ProdutoUpdateCommand, ProdutoDTO>();

            CreateMap<ServicoCreateCommand, ServicoDTO>();
            CreateMap<ServicoUpdateCommand, ServicoDTO>();

            CreateMap<ClienteCreateCommand, ClienteDTO>();
            CreateMap<ClienteUpdateCommand, ClienteDTO>();

            CreateMap<EstoqueCreateCommand, EstoqueDTO>();
            CreateMap<EstoqueUpdateCommand, EstoqueDTO>();

            CreateMap<FuncionarioCreateCommand, FuncionarioDTO>();
            CreateMap<FuncionarioUpdateCommand, FuncionarioDTO>();

            CreateMap<OrdemDeServicoCreateCommand, OrdemDeServicoDTO>();
            CreateMap<OrdemDeServicoUpdateCommand, OrdemDeServicoDTO>();
        }
    }
}
*/

using AutoMapper;
using AppControleMantec.Application.AppCliente.Commands;
using AppControleMantec.Application.DTOs;
using AppControleMantec.Domain.Entities;
using AppControleMantec.Application.AppEstoque.Commands;
using AppControleMantec.Application.AppFuncionario.Commands;
using AppControleMantec.Application.AppOrdemDeServico.Commands;
using AppControleMantec.Application.AppProduto.Commands;
using AppControleMantec.Application.AppServico.Commands;

namespace AppControleMantec.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ClienteCreateCommand, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<ClienteUpdateCommand, Cliente>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<ProdutoCreateCommand, Produto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataEntrada, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<ProdutoUpdateCommand, Produto>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataEntrada, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<ServicoCreateCommand, Servico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<ServicoUpdateCommand, Servico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<EstoqueCreateCommand, Estoque>();
            CreateMap<EstoqueUpdateCommand, Estoque>();

            CreateMap<FuncionarioCreateCommand, Funcionario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataContratacao, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<FuncionarioUpdateCommand, Funcionario>()
                .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignora o mapeamento do Id, pois será gerado pelo banco de dados
                .ForMember(dest => dest.DataContratacao, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));


            CreateMap<OrdemDeServicoCreateCommand, OrdemDeServico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));

            CreateMap<OrdemDeServicoUpdateCommand, OrdemDeServico>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => true));



            CreateMap<Cliente, ClienteDTO>();
            CreateMap<Produto, ProdutoDTO>();
            CreateMap<Servico, ServicoDTO>();
            CreateMap<Estoque, EstoqueDTO>();
            CreateMap<Funcionario, FuncionarioDTO>();
            CreateMap<OrdemDeServico, OrdemDeServicoDTO>();
        }
    }
}
