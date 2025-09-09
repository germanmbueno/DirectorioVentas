using DirectorioVentas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioVentas.Application
{
    public interface IFacturaRepository
    {
        Task<IReadOnlyList<Factura>> FindByPersonaIdentificacionAsync(string identificacion);
        Task AddAsync(Factura factura);
        Task SaveChangesAsync();
    }
}
