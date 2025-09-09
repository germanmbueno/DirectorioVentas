using DirectorioVentas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioVentas.Application
{
    public interface IDirectorioService
    {
        Task<Persona?> FindPersonaByIdentificacion(string identificacion);
        Task<IReadOnlyList<Persona>> FindPersonas();
        Task StorePersona(Persona persona);
        Task DeletePersonaByIdentificacion(string identificacion);
    }
}
