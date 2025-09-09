namespace DirectorioVentas.Domain
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string ApellidoPaterno { get; set; } = default!;
        public string? ApellidoMaterno { get; set; }
        public string Identificacion { get; set; } = default!;

        public List<Factura> Facturas { get; set; } = new();
    }
}
