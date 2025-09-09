using DirectorioVentas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioVentas.Application
{
    public class VentasService : IVentasService
    {
        private readonly IFacturaRepository _facturas;
        private readonly IPersonaRepository _personas;

        public VentasService(IFacturaRepository facturas, IPersonaRepository personas)
        {
            _facturas = facturas;
            _personas = personas;
        }

        public Task<IReadOnlyList<Factura>> FindFacturasByPersona(string identificacion)
            => _facturas.FindByPersonaIdentificacionAsync(identificacion);

        public async Task StoreFactura(string identificacion, Factura factura)
        {
            var persona = await _personas.FindByIdentificacionAsync(identificacion);
            if (persona == null) throw new InvalidOperationException("Persona no existe.");

            factura.PersonaId = persona.Id;
            if (factura.Fecha == default) factura.Fecha = DateTime.UtcNow;

            await _facturas.AddAsync(factura);
            await _facturas.SaveChangesAsync();
        }
    }
}
