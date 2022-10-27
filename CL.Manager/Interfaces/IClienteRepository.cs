using CL.Core.Domain;

namespace CL.Manager.Interfaces;

public interface IClienteRepository
{
    Task<Cliente> DeleteClienteAsync(int id);
    Task<Cliente> GetClienteAsync(int id);
    Task<IEnumerable<Cliente>> GetClientesAsync();
    Task<Cliente> InsertClienteAsync(Cliente cliente);
    Task<Cliente> UpdateClienteAsync(Cliente clienteAlterado);
}
