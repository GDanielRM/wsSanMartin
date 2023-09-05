using System;
using System.Data;

namespace wsSanMartin.Models
{
    public class TipoProductoModel
    {
        public int Id { get; set; }
        public string NombreTipoProducto { get; set; }
        public string DescripcionTipoProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEliminado { get; set; }

        public TipoProductoModel(DataRow data)
        {
            Id = (int)data.ItemArray[0];
            NombreTipoProducto = (string)data.ItemArray[1];
            DescripcionTipoProducto = (string)data.ItemArray[2];
            FechaRegistro = (DateTime)data.ItemArray[3];
        }
    }
}