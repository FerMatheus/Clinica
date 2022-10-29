using CL.Core.Domain;
using CL.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Repository;

public class MedicoRepository
{
	private readonly ClinicaContext context;

	public MedicoRepository(ClinicaContext context)
	{
		this.context = context;
	}
	public async Task<IEnumerable<Medico>> GetMedicosAsync()
	{
		return await context.Medicos
			 .Include(e => e.Especialidades)
			 .AsNoTracking()
			 .ToListAsync();
	}
	public async Task<Medico> GetMedicoAsync(int id)
	{
		return await context.Medicos.Include(e => e.Especialidades)
			.AsNoTracking()
			.SingleOrDefaultAsync(c => c.Id == id);
	}
}
