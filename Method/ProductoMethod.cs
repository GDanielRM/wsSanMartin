using System.Collections.Generic;
using System.Data;
using wsSanMartin.Models;

namespace wsSanMartin.Method
{
    public class ProductoMethod
    {
        public static List<ProductoModel> GetAll()
        {
            string query = "sp_productos_leer 0";
            DataTable responce = Tools.ExecuteQuery(query);

            List<ProductoModel> productos = new List<ProductoModel>();  
            foreach (DataRow item in responce.Rows)
            {
                ProductoModel producto = new ProductoModel(item);
                productos.Add(producto);
            }

            return productos;
        }

        public static ProductoModel GetById(int id)
        {
            string query = string.Format("sp_productos_leer {0}", id);
                DataTable responce = Tools.ExecuteQuery(query);

            ProductoModel producto = new ProductoModel(responce.Rows[0]);

            return producto;
        }

        public static string Create(ProductoEntity producto)
        {
            string query = string.Format("sp_productos_crear '{0}','{1}',{2},{3},{4}",
                producto.NombreProducto, 
                producto.DescripcionProducto, 
                producto.Precio, 
                producto.Existencia, 
                producto.IdTipoProducto
            );
            DataTable responce = Tools.ExecuteQuery(query);

            return (string)responce.Rows[0].ItemArray[1];
        }

        public static string Update(ProductoEntity producto)
        {
            string query = string.Format("sp_productos_actualizar {0},'{1}','{2}',{3},{4},{5}",
                producto.Id,
                producto.NombreProducto,
                producto.DescripcionProducto,
                producto.Precio,
                producto.Existencia,
                producto.IdTipoProducto);
            DataTable responce = Tools.ExecuteQuery(query);

            return (string)responce.Rows[0].ItemArray[1];
        }

        public static string Delete(int id)
        {
            string query = string.Format("sp_productos_eliminar {0}", id);
            DataTable responce = Tools.ExecuteQuery(query);

            return (string)responce.Rows[0].ItemArray[1];
        }

        public static List<TipoProductoModel> GetProductType()
        {
            string query = "SELECT * FROM TipoProducto;";
            DataTable responce = Tools.ExecuteQuery(query);

            List<TipoProductoModel> types = new List<TipoProductoModel>();
            foreach (DataRow item in responce.Rows)
            {
                TipoProductoModel type = new TipoProductoModel(item);
                types.Add(type);
            }

            return types;
        }
    }
}