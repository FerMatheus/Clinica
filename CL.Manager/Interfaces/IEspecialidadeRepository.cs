using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domain;

namespace CL.Manager.Interfaces
{
    public interface IEspecialidadeRepository
    {
        Task<IEnumerable<Especialidade>> GetEspecialidadesAsync();
        Task<IEnumerable<Especialidade>> GetEspecialidadesMedicosAsync();
        Task<Especialidade> GetEspecialidadeAsync(int id);
        Task<Especialidade> GetEspecialidadeMedicoAsync(int id);
        Task<Especialidade> InsertEspecialidade(Especialidade especialidade);
        Task<Especialidade> DeleteEspecialidadeAsync(int id);
    }
}