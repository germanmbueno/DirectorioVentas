using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DirectorioVentas.Domain
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        [JsonIgnore]
        public int PersonaId { get; set; }

        [JsonIgnore]
        public Persona? Persona { get; set; } = default!;
    }
}
