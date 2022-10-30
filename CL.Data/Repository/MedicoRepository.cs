using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Repository;

public class MedicoRepository : IMedicoRepository
{
	private readonly ClinicaContext context;

	public MedicoRepository(ClinicaContext context)
	{
		this.context = context;
	}
	public async Task<IEnumerable<Medico>> GetMedicosAsync()
	{
		return await context.Medicos
			 .AsNoTracking()
			 .Include(e => e.Especialidades)
			 .AsNoTracking()
			 .ToListAsync();
	}
	public async Task<Medico> GetMedicoAsync(int id)
	{
		return await context.Medicos
			.AsNoTracking()
			.Include(e => e.Especialidades)
			.AsNoTracking()
			.SingleOrDefaultAsync(c => c.Id == id);
	}
	public async Task<Medico> InsertMedicoAsync(Medico medico)
	{
		await context.Medicos.AddRangeAsync(medico);
		foreach (var especialidade in medico.Especialidades)
		{
			var especialidadeConsultada = await context.Especialidades.AsNoTrackingWithIdentityResolution().SingleAsync(m => m.Id == especialidade.Id);
			context.Entry(especialidade).CurrentValues.SetValues(especialidadeConsultada);
		}
		await context.BulkSaveChangesAsync();
		return medico;
	}
	
	public async Task<Medico> UpdateMedicoAsync(Medico medico)
	{
		var medicoConsultado = await context.Medicos.Include(e => e.Especialidades).SingleOrDefaultAsync(m => m.Id == medico.Id);

		if (medicoConsultado is null)
		{
			return null;
		}
		context.Entry(medicoConsultado).CurrentValues.SetValues(medico);
		await UpdateMedicoEspecialidades(medico, medicoConsultado);
		await context.SaveChangesAsync();
		return medicoConsultado;
	}

	private async Task UpdateMedicoEspecialidades(Medico medico, Medico medicoConsultado)
	{
        medicoConsultado.Especialidades.Clear();
        foreach (var especialidade in medico.Especialidades)
		{
			var especialidadeConsultada = await context.Especialidades.FindAsync(especialidade.Id);
			medicoConsultado.Especialidades.Add(especialidadeConsultada);
		}
	}
	public async Task DeleteMedicoAsync(int id)
	{
		var medicoConsultado = await context.Medicos.FindAsync(id);
		context.Medicos.Remove(medicoConsultado);
		await context.SaveChangesAsync();
	}
}
