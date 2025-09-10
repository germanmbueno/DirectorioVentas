using DirectorioVentas.Application;
using DirectorioVentas.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DirectorioVentas.API.Controllers
{
    [ApiController]
    [Route("api/directorio")]
    public class DirectorioRestServiceController : ControllerBase
    {
        private readonly IDirectorioService _directorio;
        public DirectorioRestServiceController(IDirectorioService directorio) => _directorio = directorio;

        [HttpGet("personas")]
        public async Task<IActionResult> GetAll() => Ok(await _directorio.FindPersonas());

        [HttpGet("personas/{identificacion}")]
        public async Task<IActionResult> GetByIdentificacion(string identificacion)
        {
            var p = await _directorio.FindPersonaByIdentificacion(identificacion);
            return p is null ? NotFound() : Ok(p);
        }

        [HttpPost("personas")]
        public async Task<IActionResult> Store([FromBody] Persona persona)
        {
            try
            {
                await _directorio.StorePersona(persona);
                return Ok(persona);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("personas/{identificacion}")]
        public async Task<IActionResult> Delete(string identificacion)
        {
            await _directorio.DeletePersonaByIdentificacion(identificacion);
            return NoContent();
        }
    }
}
