using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComercialClienteAPI.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [Column("id_cliente")]
        public int IdCliente { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Apellido1 { get; set; } = string.Empty;
        public string? Apellido2 { get; set; }
        public string? Ciudad { get; set; }
        public int? Categoria { get; set; }

        public ICollection<Pedido>? Pedidos { get; set; }
    }
}
