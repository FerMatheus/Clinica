using CL.Core.ModelViews.Especialidade;
using CL.Manager.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CL.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeManager especialidadeManager;

        public EspecialidadeController(IEspecialidadeManager especialidadeManager)
        {
            this.especialidadeManager = especialidadeManager;
        }

        // GET: api/<EspecialidadeController>
        [HttpGet]
        [ProducesResponseType(typeof(EspecialidadeView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            return Ok(await especialidadeManager.GetEspecialidadesAsync());
        }

        // GET api/<EspecialidadeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EspecialidadeView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get(int id)
        {
            var especialidade = await especialidadeManager.GetEspecialidadeAsync(id);
            if(especialidade is null) return NotFound();
            return Ok(especialidade);
        }
        [HttpGet("medico")]
        [ProducesResponseType(typeof(EspecialidadeView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get2()
        {
            return Ok(await especialidadeManager.GetEspecialidadesMedicosAsync());
        }

        // GET api/<EspecialidadeController>/5
        [HttpGet("medico/{id}")]
        [ProducesResponseType(typeof(EspecialidadeView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get2(int id)
        {
            var especialidade = await especialidadeManager.GetEspecialidadeMedicoAsync(id);
            if (especialidade is null) return NotFound();
            return Ok(especialidade);
        }

        // POST api/<EspecialidadeController>
        [HttpPost]
        [ProducesResponseType(typeof(EspecialidadeMedico), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post(NovaEspecialidade novaEspecialidade)
        {
            if (novaEspecialidade is null) return BadRequest();
            var especialidade = await especialidadeManager.InsertEspecialidadeAsync(novaEspecialidade);
            return CreatedAtAction(nameof(Get), new { Id = especialidade.Id},especialidade);
        }

        // DELETE api/<EspecialidadeController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EspecialidadeView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(int id)
        {
            var especialidade = await especialidadeManager.DeleteEspecialidadeAsync(id);
            if(especialidade is null) return NotFound();
            return Ok(especialidade);
        }
    }
}
