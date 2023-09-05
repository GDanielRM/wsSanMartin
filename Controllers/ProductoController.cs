using Microsoft.AspNetCore.Cors;
using System;
using System.Web.Http;
using wsSanMartin.Method;
using wsSanMartin.Models;

namespace wsSanMartin.Controllers
{
    [RoutePrefix("producto")]
    public class ProductoController : ApiController
    {
        ResultModel result = new ResultModel();

        [HttpGet]
        [Route("")]
        public ResultModel ReadAll()
        {
            try
            {
                result.Data = ProductoMethod.GetAll();
            } catch(Exception e) {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("{id}")]
        public ResultModel Read(int id)
        {
            try
            {
                result.Data = ProductoMethod.GetById(id);
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }

        [HttpPost]
        [Route("")]
        public ResultModel Create([FromBody] ProductoEntity producto)
        {
            try
            {
                string message = ProductoMethod.Create(producto);
                result.Message = message;
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }

        [HttpPut]
        [Route("")]
        public ResultModel Update([FromBody] ProductoEntity producto)
        {
            try
            {
                ProductoModel validProducto = ProductoMethod.GetById(producto.Id);

                if (validProducto == null)
                {
                    throw new Exception("El producto no existe");
                }

                string message = ProductoMethod.Update(producto);
                result.Message = message;
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }

        [HttpDelete]
        [Route("{id}")]
        public ResultModel Delete([FromUri] int id)
        {
            try
            {
                ProductoModel producto = ProductoMethod.GetById(id);

                if (producto == null)
                {
                    throw new Exception("El producto no existe");
                }

                string message = ProductoMethod.Delete(id);
                result.Message = message;
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }

        [HttpGet]
        [Route("tipo")]
        public ResultModel GetProductypes()
        {
            try
            {
                result.Data = ProductoMethod.GetProductType();
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }

            return result;
        }
    }
}