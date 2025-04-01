namespace ComercialClienteAPI.Models.Dto
{
    public class PedidoDto
    {
        public int IdPedido { get; set; }
        public double Importe { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdCliente { get; set; }
        public int IdComercial { get; set; }
    }
}
