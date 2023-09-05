using System;
using System.Data;

namespace wsSanMartin.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public decimal Precio { get; set; }
        public decimal Existencia { get; set; }
        public int IdTipoProducto { get; set; }
        public string TipoProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? FechaEliminado { get; set; }

        public ProductoModel(DataRow data) {
            Id = (int)data.ItemArray[0];
            NombreProducto = (string)data.ItemArray[1];
            DescripcionProducto = (string)data.ItemArray[2];
            Precio = (decimal)data.ItemArray[3];
            Existencia = (decimal)data.ItemArray[4];
            IdTipoProducto = (int)data.ItemArray[5];
            TipoProducto = (string)data.ItemArray[6];
            FechaRegistro = (DateTime)data.ItemArray[7];
        }
    }
}