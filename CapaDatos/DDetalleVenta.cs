using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleVenta
    {
        private int _IddetalleVenta;
        private int _IdVenta;
        private int _IdDetalle_ingreso;
        private int _Cantidad;
        private decimal _PrecioVenta;
        private decimal _Descuento;

        public int IddetalleVenta { get => _IddetalleVenta; set => _IddetalleVenta = value; }
        public int IdVenta { get => _IdVenta; set => _IdVenta = value; }
        public int IdDetalle_ingreso { get => _IdDetalle_ingreso; set => _IdDetalle_ingreso = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal PrecioVenta { get => _PrecioVenta; set => _PrecioVenta = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }


        public DDetalleVenta()
        {
            
        }
        public DDetalleVenta(int iddetalleventa, int idventa,int iddetalleingreso,int cantidad,decimal precioventa,decimal descuento)
        {
            this._IddetalleVenta = iddetalleventa;
            this.IdVenta = idventa;
            this.IdDetalle_ingreso = iddetalleingreso;
            this.Cantidad = cantidad;
            this.PrecioVenta = precioventa;
            this.Descuento = descuento;
        }

        //Metodo Insertar DDetalleVenta

        public string Insertar(DDetalleVenta DetalleVenta, ref SqlConnection Sqlcon, ref SqlTransaction Sqltran)
        {
            string rpta = "";

            try
            {


                //Establecer comando
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = Sqlcon;
                sqlcmd.Transaction = Sqltran;
                sqlcmd.CommandText = "spinsertar_detalle_venta";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_venta = new SqlParameter();
                ParIddetalle_venta.ParameterName = "@iddetalle_venta";//nuestra variable se va a comunicar con la variable de nuestro procedimiento almacenado
                ParIddetalle_venta.SqlDbType = SqlDbType.Int;
                ParIddetalle_venta.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(ParIddetalle_venta);

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idventa";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = DetalleVenta.IdVenta;
                sqlcmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIddetalle_Ingreso = new SqlParameter();
                ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Value = DetalleVenta.IdDetalle_ingreso;
                sqlcmd.Parameters.Add(ParIddetalle_Ingreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Money;
                ParCantidad.Value =DetalleVenta.Cantidad;
                sqlcmd.Parameters.Add(ParCantidad);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = DetalleVenta.PrecioVenta;
                sqlcmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = DetalleVenta.PrecioVenta;
                sqlcmd.Parameters.Add(ParDescuento);

                

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "no se ingreso registro";






            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }

            return rpta;
        }

    }
}
