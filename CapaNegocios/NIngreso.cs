using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using CapaDatos;
namespace CapaNegocios
{
    public class NIngreso
    {
        //Método insertar que llame al metodo insertar de la clase Dcategoria

        public static string Insertar(int idtrabajador, int idproveedor, DateTime fecha,
            string tipo_comprobante,string serie,string correlativo,decimal igv,string estado,DataTable datos)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idtrabajador = idtrabajador;
            Obj.Idproveedor = idproveedor;
            Obj.Fecha = fecha;
            Obj.TipoComprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
            Obj.Estado = estado;

            List<DDetalleIngreso> detalles = new List<DDetalleIngreso>();
            foreach(DataRow row in datos.Rows)
            {
                DDetalleIngreso detalle = new DDetalleIngreso();
                detalle.Idarticulo = Convert.ToInt32(row["idarticulo"].ToString());
                detalle.PrecioCompra=Convert.ToInt32(row["precio_compra"].ToString());
                detalle.PrecioVenta = Convert.ToInt32(row["precio_venta"].ToString());
                detalle.StockInicial = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.StockActual = Convert.ToInt32(row["stock_inicial"].ToString());
                detalle.FechaProduccion = Convert.ToDateTime(row["fecha_produccion"].ToString());
                detalle.FechaVencimiento = Convert.ToDateTime(row["fecha_vencimiento"].ToString());
                detalles.Add(detalle);

            }

            return Obj.Insertar(Obj,detalles);
        }

      

        //Metodo Eliminar que llama al eliminar de la clase Dcategoria
        public static string Anular(int idingreso)
        {
            DIngreso Obj = new DIngreso();
            Obj.Idingreso = idingreso;


            return Obj.Anular(Obj);
        }
        //Metodo Mostrar que llama al metodo mostrar de la clase DIngreso de la Capadatos
        public static DataTable Mostrar()
        {


            return new DIngreso().Mostrar();
        }

        //Metodo BuscarFechas que llama al metodo de la clase Dingreso
        public static DataTable BuscarFechas(string textobuscar,string textobuscar2)
        {
            DIngreso Obj = new DIngreso();
            
            return Obj.BuscarFechas(textobuscar,textobuscar2);
        }

        //Metodo MostrarDetalle que llama al metodo de la clase Dingreso
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DIngreso Obj = new DIngreso();

            return Obj.MostrarDetalle(textobuscar);
        }
    }
}
