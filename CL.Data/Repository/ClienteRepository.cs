using CL.Core.Domain;
using CL.Data.Context;
using CL.Manager.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CL.Data.Repository;

public class ClienteRepository : IClienteRepository
{
	private readonly ClinicaContext context;

	public ClienteRepository(ClinicaContext context)
	{
		this.context = context;
	}
	public async Task<IEnumerable<Cliente>> GetClientesAsync()
	{
		return await context.Clientes.AsNoTracking().ToListAsync();
	}
	public async Task<Cliente> GetClienteAsync(int id)
	{
		return await context.Clientes.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
	}
	public async Task<Cliente> InsertClienteAsync(Cliente cliente)
	{
		await context.Clientes.AddAsync(cliente);
		await context.SaveChangesAsync();
		return cliente;
	}
	public async Task<Cliente> UpdateClienteAsync(Cliente clienteAlterado)
	{
		var cliente = await context.Clientes.AsNoTracking().SingleAsync(c => c.Id == clienteAlterado.Id);
		if (cliente is null) return null;
		clienteAlterado.Criacao = cliente.Criacao;
		context.Entry(cliente).CurrentValues.SetValues(clienteAlterado);
		await context.SaveChangesAsync();
		return cliente;
	}
	public async Task<Cliente> DeleteClienteAsync(int id)
	{
		var cliente = await context.Clientes.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);
		if (cliente is null) return null;
		context.Clientes.Remove(cliente);
		await context.SaveChangesAsync();
		return cliente;
	}
}
