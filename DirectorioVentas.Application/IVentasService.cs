using DirectorioVentas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioVentas.Application
{
    public interface IVentasService
    {
        Task<IReadOnlyList<Factura>> FindFacturasByPersona(string identificacion);
        Task StoreFactura(string identificacion, Factura factura);
    }
}
