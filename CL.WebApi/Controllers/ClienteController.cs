using CL.Core.Domain;
using CL.Core.InputModel;
using CL.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteManager clienteManager;

        public ClienteController(IClienteManager clienteManager)
        {
            this.clienteManager = clienteManager;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var clientes = await clienteManager.GetClientesAsync();
            if (clientes is null) return NotFound();
            return Ok(clientes);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var cliente = await clienteManager.GetClienteAsync(id);
            if (cliente is null) return NotFound();
            return Ok(cliente);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<ActionResult> Post(NovoCliente novoCliente)
        {
            var cliente = await clienteManager.InsertClienteAsync(novoCliente);
            return CreatedAtAction(nameof(Get), new {id = cliente.Id}, cliente);
        }

        // PUT api/<ClienteController>/5
        [HttpPut()]
        public async Task<ActionResult> Put(AlteraCliente clienteAlterado)
        {
            var cliente = await clienteManager.UpdateClienteAsync(clienteAlterado);
            if (cliente is null) return NotFound();
            return Ok(cliente);
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await clienteManager.DeleteClienteAsync(id);
            if (cliente is null) return NotFound();
            return Ok(cliente);
        }
    }
}
