using AutoMapper;
using CL.Core.Domain;
using CL.Core.ModelViews.Cliente;

namespace CL.Manager.Mapping;

public class NovoClienteMappingProfile : Profile
{
	public NovoClienteMappingProfile()
	{
		CreateMap<NovoCliente, Cliente>().ForMember(novoCliente => novoCliente.Nascimento, op => op.MapFrom(cliente => cliente.Nascimento.Date))
			.ForMember(novoCliente => novoCliente.Criacao, op => op.MapFrom(cliente => DateTime.Now));
	}
}
