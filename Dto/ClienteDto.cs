namespace ComercialClienteAPI.Dto
{
    public class ClienteDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Apellido1 { get; set; } = string.Empty;
        public string? Apellido2 { get; set; }
        public string Ciudad { get; set; } = string.Empty;
        public int? Categoria { get; set; }

        // Método de conversión a entidad Cliente
        public ComercialClienteAPI.Models.Cliente ToCliente()
        {
            return new ComercialClienteAPI.Models.Cliente
            {
                Nombre = this.Nombre,
                Apellido1 = this.Apellido1,
                Apellido2 = this.Apellido2,
                Ciudad = this.Ciudad,
                Categoria = this.Categoria
            };
        }
    }
}
