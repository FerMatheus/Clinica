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
        /// <summary>
        /// Retorna todos os clientes cadastrados na base de dados
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var clientes = await clienteManager.GetClientesAsync();
            if (clientes is null) return NotFound();
            return Ok(clientes);
        }

        // GET api/<ClienteController>/5
        /// <summary>
        /// Retorna o cliente identificado pelo id passado.
        /// </summary>
        /// <param name="id" example="1">Id do cliente</param>
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var cliente = await clienteManager.GetClienteAsync(id);
            if (cliente is null) return NotFound();
            return Ok(cliente);
        }

        // POST api/<ClienteController>
        /// <summary>
        /// Realiza o cadastro de um novo cliente
        /// </summary>
        /// <param name="novoCliente"></param>
        [HttpPost]
        public async Task<ActionResult> Post(NovoCliente novoCliente)
        {
            var cliente = await clienteManager.InsertClienteAsync(novoCliente);
            return CreatedAtAction(nameof(Get), new {id = cliente.Id}, cliente);
        }

        // PUT api/<ClienteController>/5
        /// <summary>
        /// Realiza a atualização dos dados de um cliente já existente
        /// </summary>
        /// <param name="clienteAlterado"></param>
        [HttpPut()]
        public async Task<ActionResult> Put(AlteraCliente clienteAlterado)
        {
            var cliente = await clienteManager.UpdateClienteAsync(clienteAlterado);
            if (cliente is null) return NotFound();
            return Ok(cliente);
        }

        // DELETE api/<ClienteController>/5
        /// <summary>
        /// Realiza a remoção do cliente, informado pelo id, da base de dados
        /// </summary>
        /// <param name="id" exaple="1">Id do cliente</param>
        /// <remarks>Após excluido, todos os dados serão perdidos permanentemente</remarks>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await clienteManager.DeleteClienteAsync(id);
            if (cliente is null) return NotFound();
            return Ok(cliente);
        }
    }
}
