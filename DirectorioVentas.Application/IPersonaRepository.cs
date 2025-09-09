using DirectorioVentas.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectorioVentas.Application
{
    public interface IPersonaRepository
    {
        Task<Persona?> FindByIdentificacionAsync(string identificacion);
        Task<IReadOnlyList<Persona>> GetAllAsync();
        Task AddAsync(Persona persona);
        Task DeleteByIdentificacionAsync(string identificacion);
        Task SaveChangesAsync();
    }
}
