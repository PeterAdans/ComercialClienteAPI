using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComercialClienteAPI.Models
{
    [Table("comerciales")]
    public class Comercial
    {
        [Key]
        [Column("id_comercial")]
        public int IdComercial { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Apellido1 { get; set; } = string.Empty;
        public string? Apellido2 { get; set; }
        public double Comision { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
    }
}

