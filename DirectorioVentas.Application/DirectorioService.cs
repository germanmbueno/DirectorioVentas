using DirectorioVentas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioVentas.Application
{
    public class DirectorioService : IDirectorioService
    {
        private readonly IPersonaRepository _personas;

        public DirectorioService(IPersonaRepository personas) => _personas = personas;

        public Task<Persona?> FindPersonaByIdentificacion(string identificacion)
            => _personas.FindByIdentificacionAsync(identificacion);

        public Task<IReadOnlyList<Persona>> FindPersonas()
            => _personas.GetAllAsync();

        public async Task StorePersona(Persona persona)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre) ||
                string.IsNullOrWhiteSpace(persona.ApellidoPaterno) ||
                string.IsNullOrWhiteSpace(persona.Identificacion))
                throw new ArgumentException("Nombre, ApellidoPaterno e Identificación son obligatorios.");

            var exists = await _personas.FindByIdentificacionAsync(persona.Identificacion);
            if (exists != null) throw new InvalidOperationException("Identificación ya existe.");

            await _personas.AddAsync(persona);
            await _personas.SaveChangesAsync();
        }

        public async Task DeletePersonaByIdentificacion(string identificacion)
        {
            await _personas.DeleteByIdentificacionAsync(identificacion);
            await _personas.SaveChangesAsync();
        }
    }
}
