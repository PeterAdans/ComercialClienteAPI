using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComercialClienteAPI.Models
{
    [Table("pedidos")]
    public class Pedido
    {
        [Key]
        [Column("id_pedido")]
        public int IdPedido { get; set; }

        public double Importe { get; set; }

        public DateTime? Fecha { get; set; }

        [ForeignKey("Cliente")]
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;  // ⚠️ le avisamos al compilador

        [ForeignKey("Comercial")]
        [Column("id_comercial")]
        public int IdComercial { get; set; }
        public Comercial Comercial { get; set; } = null!; // ⚠️ le avisamos al compilador
    }
}
