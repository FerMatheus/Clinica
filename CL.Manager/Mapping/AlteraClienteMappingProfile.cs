using AutoMapper;
using CL.Core.Domain;
using CL.Core.InputModel;
using CL.Manager.Validation;

namespace CL.Manager.Mapping;

public class AlteraClienteMappingProfile : Profile
{
    public AlteraClienteMappingProfile()
    {
        CreateMap<AlteraCliente, Cliente>()
            .ForMember(clienteAlterado => clienteAlterado.Nascimento, op => op.MapFrom(cliente => cliente.Nascimento.Date))
            .ForMember(clienteAlterado => clienteAlterado.UltimaAtualizacao, op => op.MapFrom(cliente => DateTime.Now));
    }
}
