using AutoMapper;
using CL.Core.Domain;
using CL.Core.ModelViews.Especialidade;
using CL.Core.ModelViews.Medico;

namespace CL.Manager.Mapping;

public class EspecialidadeMappingProfile : Profile
{
    public EspecialidadeMappingProfile()
    {
        CreateMap<NovaEspecialidade, Especialidade>();
        CreateMap<Especialidade, EspecialidadeView>();
        CreateMap<Especialidade, EspecialidadeMedico>();
        CreateMap<Medico, MedicoEspecialidade>();
    }
}
