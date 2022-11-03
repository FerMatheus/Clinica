using AutoMapper;
using CL.Core.Domain;
using CL.Core.ModelViews.Especialidade;
using CL.Manager.Interfaces;

namespace CL.Manager.Implementation;

public class EspecialidadeManager : IEspecialidadeManager
{
    private readonly IEspecialidadeRepository especialidadeRepository;
    private readonly IMapper mapper;

    public EspecialidadeManager(IEspecialidadeRepository especialidadeRepository, IMapper mapper)
    {
        this.especialidadeRepository = especialidadeRepository;
        this.mapper = mapper;
    }
    public async Task<EspecialidadeView> DeleteEspecialidadeAsync(int id)
    {
        return mapper.Map<EspecialidadeView>(await especialidadeRepository.DeleteEspecialidadeAsync(id));
    }

    public async Task<EspecialidadeView> GetEspecialidade(int id)
    {
        return mapper.Map<EspecialidadeView>(await especialidadeRepository.GetEspecialidadeAsync(id));
    }

    public async Task<EspecialidadeMedico> GetEspecialidadeMedicoAsync(int id)
    {
        return mapper.Map<EspecialidadeMedico>(await especialidadeRepository.GetEspecialidadeMedicoAsync(id));
    }

    public async Task<IEnumerable<EspecialidadeView>> GetEspecialidadesAsync()
    {
        return mapper.Map<IEnumerable<Especialidade>, IEnumerable<EspecialidadeView>>(await especialidadeRepository.GetEspecialidadesAsync());
    }

    public async Task<IEnumerable<EspecialidadeMedico>> GetEspecialidadesMedicosAsync()
    {
        return mapper.Map<IEnumerable<Especialidade>, IEnumerable<EspecialidadeMedico>>(await especialidadeRepository.GetEspecialidadesMedicosAsync());
    }

    public async Task<EspecialidadeView> InsertEspecialidadeAsync(NovaEspecialidade novaEspecialidade)
    {
        var especialidade = mapper.Map<Especialidade>(novaEspecialidade);
        return mapper.Map<EspecialidadeView>(await especialidadeRepository.InsertEspecialidade(especialidade));
    }
}
