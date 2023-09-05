using System;

namespace wsSanMartin
{
    public class ProductoEntity
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal Precio { get; set; }
        public decimal Existencia { get; set; }
        public int IdTipoProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaEliminado { get; set; }
    }
}