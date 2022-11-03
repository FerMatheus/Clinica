using CL.Core.ModelViews.Especialidade;

namespace CL.Manager.Interfaces;

public interface IEspecialidadeManager
{
    Task<IEnumerable<EspecialidadeView>> GetEspecialidadesAsync();
    Task<EspecialidadeView> GetEspecialidade(int id);
    Task<IEnumerable<EspecialidadeMedico>> GetEspecialidadesMedicosAsync();
    Task<EspecialidadeMedico> GetEspecialidadeMedicoAsync(int id);
    Task<EspecialidadeView> InsertEspecialidadeAsync(NovaEspecialidade novaEspecialidade);
    Task<EspecialidadeView> DeleteEspecialidadeAsync(int id);
}
