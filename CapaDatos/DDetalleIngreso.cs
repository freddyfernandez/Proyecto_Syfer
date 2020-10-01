using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DDetalleIngreso
    {

        //Variables
        private int _Idingreso;
        private int _Iddetalleingreso;
        private int _Idarticulo;
        private decimal _PrecioCompra;
        private decimal _PrecioVenta;
        private int _StockInicial;
        private int _StockActual;
        private DateTime _FechaProduccion;
        private DateTime _FechaVencimiento;

        //Propiedades

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Iddetalleingreso { get => _Iddetalleingreso; set => _Iddetalleingreso = value; }
        public int Idarticulo { get => _Idarticulo; set => _Idarticulo = value; }
        public decimal PrecioCompra { get => _PrecioCompra; set => _PrecioCompra = value; }
        public decimal PrecioVenta { get => _PrecioVenta; set => _PrecioVenta = value; }
        public int StockInicial { get => _StockInicial; set => _StockInicial = value; }
        public int StockActual { get => _StockActual; set => _StockActual = value; }
        public DateTime FechaProduccion { get => _FechaProduccion; set => _FechaProduccion = value; }
        public DateTime FechaVencimiento { get => _FechaVencimiento; set => _FechaVencimiento = value; }

        //Constructores

        public DDetalleIngreso()
        {
            
        }

        public DDetalleIngreso(int idingreso,int idarticulo,decimal preciocompra,
            decimal precioventa,int stockinicial, int stockactual,DateTime fechaproduccion,DateTime fechavencimiento)
        {

            this.Idingreso = idingreso;
            this.Idarticulo = idarticulo;
            this.PrecioCompra = preciocompra;
            this.PrecioVenta = precioventa;
            this.StockInicial = stockinicial;
            this.StockActual = stockactual;
            this.FechaProduccion = fechaproduccion;
            this.FechaVencimiento = fechavencimiento;
        }

        //Metodo Insertar

        public string Insertar(DDetalleIngreso detalleIngreso,ref SqlConnection Sqlcon,ref SqlTransaction Sqltran)
        {
            string rpta = "";
            
            try
            {
                

                //Establecer comando
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = Sqlcon;
                sqlcmd.Transaction = Sqltran;    
                sqlcmd.CommandText = "spinsertar_detalle_ingreso";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_Ingreso = new SqlParameter();
                ParIddetalle_Ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_Ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_Ingreso.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(ParIddetalle_Ingreso);

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.VarChar;
                ParIdingreso.Value = detalleIngreso.Idingreso; 
                sqlcmd.Parameters.Add(ParIdingreso);

                SqlParameter ParIdarticulo = new SqlParameter();
                ParIdarticulo.ParameterName = "@idarticulo";
                ParIdarticulo.SqlDbType = SqlDbType.VarChar;
                ParIdarticulo.Value = detalleIngreso.Idarticulo;
                sqlcmd.Parameters.Add(ParIdarticulo);

                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@precio_compra";
                ParPrecioCompra.SqlDbType = SqlDbType.Money;
                ParPrecioCompra.Value = detalleIngreso.PrecioCompra;
                sqlcmd.Parameters.Add(ParPrecioCompra);

                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@precio_venta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = detalleIngreso.PrecioVenta;
                sqlcmd.Parameters.Add(ParPrecioVenta);

                SqlParameter ParStockInicial = new SqlParameter();
                ParStockInicial.ParameterName = "@stock_inicial";
                ParStockInicial.SqlDbType = SqlDbType.Int;
                ParStockInicial.Value = detalleIngreso.StockInicial;
                sqlcmd.Parameters.Add(ParStockInicial);


                SqlParameter ParStockActual = new SqlParameter();
                ParStockActual.ParameterName = "@stock_actual";
                ParStockActual.SqlDbType = SqlDbType.Int;
                ParStockActual.Value = detalleIngreso.StockActual;
                sqlcmd.Parameters.Add(ParStockActual);


          


                SqlParameter ParFechaProduccion = new SqlParameter();
                ParFechaProduccion.ParameterName = "@fecha_produccion";
                ParFechaProduccion.SqlDbType = SqlDbType.Date;
                ParFechaProduccion.Value = detalleIngreso.FechaProduccion;
                sqlcmd.Parameters.Add(ParFechaProduccion);

                SqlParameter ParFechaVencimiento = new SqlParameter();
                ParFechaVencimiento.ParameterName = "@fecha_vencimiento";
                ParFechaVencimiento.SqlDbType = SqlDbType.Date;
                ParFechaVencimiento.Value = detalleIngreso.FechaVencimiento;
                sqlcmd.Parameters.Add(ParFechaVencimiento);


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
