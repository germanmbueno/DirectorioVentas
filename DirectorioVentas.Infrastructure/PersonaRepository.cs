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
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _db;
        public PersonaRepository(AppDbContext db) => _db = db;

        public async Task AddAsync(Persona persona) => await _db.Personas.AddAsync(persona);

        public async Task DeleteByIdentificacionAsync(string identificacion)
        {
            var p = await _db.Personas.FirstOrDefaultAsync(x => x.Identificacion == identificacion);
            if (p != null) _db.Personas.Remove(p);
        }

        public Task<IReadOnlyList<Persona>> GetAllAsync()
            => Task.FromResult<IReadOnlyList<Persona>>(_db.Personas.Include(p => p.Facturas).ToList());

        public Task<Persona?> FindByIdentificacionAsync(string identificacion)
            => _db.Personas.Include(p => p.Facturas).FirstOrDefaultAsync(p => p.Identificacion == identificacion);

        public Task SaveChangesAsync() => _db.SaveChangesAsync();
    }
}
