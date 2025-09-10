using DirectorioVentas.Application;
using DirectorioVentas.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioVentas.Infrastructure
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly AppDbContext _db;
        public FacturaRepository(AppDbContext db) => _db = db;

        public Task AddAsync(Factura factura) => _db.Facturas.AddAsync(factura).AsTask();

        public Task<IReadOnlyList<Factura>> FindByPersonaIdentificacionAsync(string identificacion)
            => Task.FromResult<IReadOnlyList<Factura>>(
                _db.Facturas.Include(f => f.Persona)
                            .Where(f => f.Persona.Identificacion == identificacion)
                            .ToList());

        public Task SaveChangesAsync() => _db.SaveChangesAsync();
    }
}
