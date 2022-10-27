using AutoMapper;
using CL.Core.Domain;
using CL.Core.InputModel;
using CL.Manager.Interfaces;

namespace CL.Manager.Implementation;

public class ClienteManager : IClienteManager
{
    private readonly IClienteRepository clienteRepository;
    private readonly Mapper mapper;

    public ClienteManager(IClienteRepository clienteRepository, Mapper mapper)
    {
        this.clienteRepository = clienteRepository;
        this.mapper = mapper;
    }
    public async Task<Cliente> DeleteClienteAsync(int id)
    {
        return await clienteRepository.DeleteClienteAsync(id);
    }

    public async Task<Cliente> GetClienteAsync(int id)
    {
        return await clienteRepository.GetClienteAsync(id);
    }

    public async Task<IEnumerable<Cliente>> GetClientesAsync()
    {
        return await clienteRepository.GetClientesAsync();
    }

    public async Task<Cliente> InsertClienteAsync(NovoCliente novoCliente)
    {
        var cliente = mapper.Map<Cliente>(novoCliente);
        return await clienteRepository.InsertClienteAsync(cliente);
    }

    public async Task<Cliente> UpdateClienteAsync(AlteraCliente clienteAlterado)
    {
        var cliente = mapper.Map<Cliente>(clienteAlterado);
        return await clienteRepository.UpdateClienteAsync(cliente);
    }
}
