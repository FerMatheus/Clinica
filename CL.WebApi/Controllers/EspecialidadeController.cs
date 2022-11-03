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
        /// <summary>
        /// Retorna uma lista com todas as especialidades
        /// </summary>
        // GET: api/<EspecialidadeController>
        [HttpGet]
        [ProducesResponseType(typeof(EspecialidadeView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get()
        {
            return Ok(await especialidadeManager.GetEspecialidadesAsync());
        }
        /// <summary>
        /// Retorna uma especialidade identificada pelo id
        /// </summary>
        /// <param name="id" example="1">Id da especialidade</param>
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
        /// <summary>
        /// Retorna uma lista com todas as especialidades, com seus médicos
        /// </summary>
        [HttpGet("medico")]
        [ProducesResponseType(typeof(EspecialidadeView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get2()
        {
            return Ok(await especialidadeManager.GetEspecialidadesMedicosAsync());
        }
        /// <summary>
        /// Retorna uma especialidade identificada pelo id, com seus médicos
        /// </summary>
        /// <param name="id" example="1">Id da especialidade</param>
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
        /// <summary>
        /// Cadastro de uma especialidade
        /// </summary>
        /// <param name="novaEspecialidade"></param>
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
        /// <summary>
        /// Remoção de uma especialidade
        /// </summary>
        /// <param name="id" example="1"></param>
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
