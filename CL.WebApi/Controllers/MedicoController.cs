using CL.Core.ModelViews.Medico;
using CL.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoManager medicoManager;

        public MedicoController(IMedicoManager medicoManager)
        {
            this.medicoManager = medicoManager;
        }
        /// <summary>
        /// Retorna todos os médicos
        /// </summary>
        /// <remarks>Retorna todos os médicos, com suas especialidades, cadastrados na base de dados</remarks>
        // GET: api/<MedicoController>
        [HttpGet]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails),StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            var medicos = await medicoManager.GetMedicosAsync();
            if (medicos is null)
            {
                return NotFound();
            }
            return Ok(medicos);
        }
        /// <summary>
        /// Retorna um médico identificado pelo Id
        /// </summary>
        /// <param name="id" example="1">Id do médico</param>
        // GET api/<MedicoController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get(int id)
        {
            var medico = await medicoManager.GetMedicoAsync(id);
            if (medico is null) return NotFound();
            return Ok(medico);
        }
        /// <summary>
        /// Coleta de dados para regustrar um médico
        /// </summary>
        // POST api/<MedicoController>
        [HttpPost]
        [ProducesResponseType(typeof(MedicoView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(NovoMedico novoMedico)
        {
            var medico = await medicoManager.InsertMedicoAsync(novoMedico);
            return CreatedAtAction(nameof(Get), new { id = medico.Id }, medico);
        }
        /// <summary>
        /// Altera um médico
        /// </summary>
        // PUT api/<MedicoController>/5
        [HttpPut]
        [ProducesResponseType(typeof(MedicoView),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(AlteraMedico medicoAlterado)
        {
            var medico = await medicoManager.UpdateMedicoAsync(medicoAlterado);
            if (medico is null) return NotFound();
            return Ok(medico);
        }
        /// <summary>
        /// Deleta um médico
        /// </summary>
        /// <param name="id" example="1">Id do médico</param>
        /// <remarks>Lembrando que essa operação escluí permanentemente o médico da base de dados</remarks>
        // DELETE api/<MedicoController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteMedicoAsync(int id)
        {
            await medicoManager.DeleteMedicoAsync(id);
            return NoContent();

        }
    }
}
