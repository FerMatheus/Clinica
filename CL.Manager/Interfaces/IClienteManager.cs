using CL.Core.Domain;
using CL.Core.ModelViews.Cliente;

namespace CL.Manager.Interfaces;

public interface IClienteManager
{
    Task<Cliente> DeleteClienteAsync(int id);
    Task<Cliente> GetClienteAsync(int id);
    Task<IEnumerable<Cliente>> GetClientesAsync();
    Task<Cliente> InsertClienteAsync(NovoCliente novoCliente);
    Task<Cliente> UpdateClienteAsync(AlteraCliente clienteAlterado);
}
