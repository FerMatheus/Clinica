using AutoMapper;
using CL.Core.Domain;
using CL.Core.ModelViews.Especialidade;
using CL.Core.ModelViews.Medico;

namespace CL.Manager.Mapping;

public class MedicoMappingProfile : Profile
{
	public MedicoMappingProfile()
	{
		CreateMap<NovoMedico, Medico>();
		CreateMap<Medico,MedicoView>();
		CreateMap<Especialidade, ReferenceEspecialidade>().ReverseMap();
		CreateMap<Especialidade, EspecialidadeView>().ReverseMap();
        CreateMap<Medico, AlteraMedico>().ReverseMap();
    }
}
