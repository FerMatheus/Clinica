using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Repository;

public class EspecialidadeRepository : IEspecialidadeRepository
{
    private readonly ClinicaContext context;

    public EspecialidadeRepository(ClinicaContext context)
    {
        this.context = context;
    }
    public async Task<IEnumerable<Especialidade>> GetEspecialidadesAsync()
    {
        return await context.Especialidades.AsNoTracking().ToListAsync();
    }
    public async Task<IEnumerable<Especialidade>> GetEspecialidadesMedicosAsync()
    {
        return await context.Especialidades.Include(m => m.Medicos).AsNoTracking().ToListAsync();
    }
    public async Task<Especialidade> GetEspecialidadeAsync(int id)
    {
        return await context.Especialidades.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }
    public async Task<Especialidade> GetEspecialidadeMedicoAsync(int id)
    {
        return await context.Especialidades.Include(m => m.Medicos).AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
    }
    public async Task<Especialidade> InsertEspecialidade(Especialidade especialidade)
    {
        if (especialidade is null) return null;
        await context.Especialidades.AddAsync(especialidade);
        await context.SaveChangesAsync();
        return especialidade;
    }
    public async Task<Especialidade> DeleteEspecialidadeAsync(int id)
    {
        var especialidade = await context.Especialidades.FirstOrDefaultAsync(e => e.Id == id);
        if (especialidade is null) return null;
        context.Especialidades.Remove(especialidade);
        await context.SaveChangesAsync();
        return especialidade;
    }
}
