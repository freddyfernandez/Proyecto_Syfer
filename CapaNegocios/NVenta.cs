using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NVenta
    {
        //Método insertar que llame al metodo insertar de la clase Dcategoria

        public static string Insertar(int idcliente, int idtrabajador, DateTime fecha,
            string tipo_comprobante, string serie, string correlativo, decimal igv, DataTable dtdetalles)
        {
            DVenta Obj = new DVenta();

            Obj.Idtrabajador = idtrabajador;
            Obj.Idcliente = idcliente;
            Obj.Fecha = fecha;
            Obj.Tipo_Comprobante = tipo_comprobante;
            Obj.Serie = serie;
            Obj.Correlativo = correlativo;
            Obj.Igv = igv;
        

            List<DDetalleVenta> detalles = new List<DDetalleVenta>();
            foreach (DataRow row in dtdetalles.Rows)
            {
                DDetalleVenta detalle = new DDetalleVenta();
                detalle.IdDetalle_ingreso = Convert.ToInt32(row["iddetalle_ingreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["cantidad"].ToString());
                detalle.PrecioVenta = Convert.ToDecimal(row["precio_venta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["descuento"].ToString());
             
                detalles.Add(detalle);

            }

            return Obj.Insertar(Obj, detalles);
        }



        //Metodo Eliminar que llama al eliminar de la clase Dcategoria
        public static string Eliminar(int idventa)
        {
            DVenta Obj = new DVenta();
            Obj.IdVenta = idventa;


            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo mostrar de la clase DVenta de la Capadatos
        public static DataTable Mostrar()
        {


            return new DVenta().Mostrar();
        }

        //Metodo BuscarFechas que llama al metodo de la clase DVenta
        public static DataTable BuscarFechas(string textobuscar, string textobuscar2)
        {
            DVenta Obj = new DVenta();

            return Obj.BuscarFechas(textobuscar, textobuscar2);
        }

        //Metodo MostrarDetalle que llama al metodo de la clase Dingreso
        public static DataTable MostrarDetalle(string textobuscar)
        {
            DVenta Obj = new DVenta();

            return Obj.MostrarDetalle(textobuscar);
        }

        //Metodo MostrarDetalle que llama al metodo de la clase Dingreso
        public static DataTable Mostrar_Articulo_Venta_Nombre(string textobuscar)
        {
            DVenta Obj = new DVenta();

            return Obj.MostrarArticulo_venta_nombre(textobuscar);
        }
        //Metodo MostrarDetalle que llama al metodo de la clase Dingreso
        public static DataTable Mostrar_Articulo_Venta_Codigo(string textobuscar)
        {
            DVenta Obj = new DVenta();

            return Obj.MostrarArticulo_venta_codigo(textobuscar);
        }


    }
}
