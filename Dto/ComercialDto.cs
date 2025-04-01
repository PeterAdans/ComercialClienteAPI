namespace ComercialClienteAPI.Dto
{
    public class ComercialDto
    {
        public int IdComercial { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido1 { get; set; } = string.Empty;
        public string? Apellido2 { get; set; }

        public ComercialClienteAPI.Models.Comercial ToComercial()
        {
            return new ComercialClienteAPI.Models.Comercial
            {
                IdComercial = this.IdComercial,
                Nombre = this.Nombre,
                Apellido1 = this.Apellido1,
                Apellido2 = this.Apellido2,
                Comision = 0 // o el valor que quieras por defecto si no viene del DTO
            };
        }
    }
}
