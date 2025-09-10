using DirectorioVentas.Application;
using DirectorioVentas.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DirectorioVentas.API.Controllers
{
    [ApiController]
    [Route("api/ventas")]
    public class FacturaRestServiceController : ControllerBase
    {
        private readonly IVentasService _ventas;
        public FacturaRestServiceController(IVentasService ventas) => _ventas = ventas;

        [HttpGet("facturas/{identificacion}")]
        public async Task<IActionResult> GetFacturas(string identificacion)
            => Ok(await _ventas.FindFacturasByPersona(identificacion));

        [HttpPost("facturas")]
        public async Task<IActionResult> StoreFactura([FromBody] Factura factura, [FromQuery] string identificacion)
        {
            await _ventas.StoreFactura(identificacion, factura);
            return Ok(factura);
        }
    }
}
