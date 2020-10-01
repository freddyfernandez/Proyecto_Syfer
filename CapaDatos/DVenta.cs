using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
namespace CapaDatos
{
    public class DVenta
    {
        private int _IdVenta;
        private int _Idcliente;
        private int _Idtrabajador;
        private DateTime _Fecha;
        private string _Tipo_Comprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;

        public int IdVenta { get => _IdVenta; set => _IdVenta = value; }
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }

        public DVenta()
        {
            
        }

        public DVenta(int idventa, int idcliente, int idtrabajador, DateTime fecha, string tipo_comprobante,

            string serie, string correlativo, decimal igv)
        {
            this.IdVenta = idventa;
            this.Idcliente = idcliente;
            this.Idtrabajador = idtrabajador;
            this.Fecha = fecha;
            this.Tipo_Comprobante = tipo_comprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;



        }
        //Metodos

        public string DisminuirStock(int iddetalle_ingreso, int cantidad)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //Codigo
                Sqlcon.ConnectionString = Conexion.Cn;
                Sqlcon.Open();

                //Establecer comando
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = Sqlcon;
                sqlcmd.CommandText = "spdisminuir_stock";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalle_ingreso = new SqlParameter();
                ParIddetalle_ingreso.ParameterName = "@iddetalle_ingreso";
                ParIddetalle_ingreso.SqlDbType = SqlDbType.Int;
                ParIddetalle_ingreso.Value = iddetalle_ingreso;
                sqlcmd.Parameters.Add(ParIddetalle_ingreso);



                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                sqlcmd.Parameters.Add(ParCantidad);




                //Ejecutamos comando

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "no se Actualizo el stock";






                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;

                    }
                    finally
                    {
                        if (Sqlcon.State == ConnectionState.Open) Sqlcon.Close();

                    }
                    return rpta;

                }

        public string Insertar(DVenta Venta, List<DDetalleVenta> Detalle)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //Abri conexion
                Sqlcon.ConnectionString = Conexion.Cn;
                Sqlcon.Open();

                //Establecer transaccion
                SqlTransaction Sqltran = Sqlcon.BeginTransaction();
                //Establecer comando
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = Sqlcon;
                sqlcmd.Transaction = Sqltran;
                sqlcmd.CommandText = "spinsertar_venta";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idventa";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(ParIdVenta);

                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@idcliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.Idcliente;
                sqlcmd.Parameters.Add(ParIdCliente);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Venta.Idtrabajador; //(clase->)categoria.nombre(->metodo)= es un valor instaciado de la clase categoria

                sqlcmd.Parameters.Add(ParIdTrabajador);

                

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha;
                sqlcmd.Parameters.Add(ParFecha);

                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipo_comprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Venta.Tipo_Comprobante;
                sqlcmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Venta.Serie;
                sqlcmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Venta.Correlativo;
                sqlcmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Size = 2;
                ParIgv.Value = Venta.Igv;
                sqlcmd.Parameters.Add(ParIgv);



                //Escribimos la sentencia para insertar los detalles

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "no se ingreso registro";
                if (rpta.Equals("OK"))
                {
                    //Obtener codigo ingreso generado
                    this.IdVenta = Convert.ToInt32(sqlcmd.Parameters["@idventa"].Value);
                    foreach (DDetalleVenta det in Detalle)
                    {
                        det.IdVenta = this.IdVenta;

                        //llamar al metodo insertar de la clase DDetalle_ingreso
                        rpta = det.Insertar(det, ref Sqlcon, ref Sqltran);
                        if (!rpta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //actualizar el stock
                            rpta = DisminuirStock(det.IdDetalle_ingreso,det.Cantidad);
                            if (!rpta.Equals("OK"))
                            {
                                break;
                            }
                        }

                    }
                }
                if (rpta.Equals("OK"))
                {
                    Sqltran.Commit();
                }
                else
                {
                    
                    Sqltran.Rollback();
                }





            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open) Sqlcon.Close();

            }
            return rpta;
        }

        public string Eliminar(DVenta Venta)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                //Codigo
                Sqlcon.ConnectionString = Conexion.Cn;
                Sqlcon.Open();

                //Establecer comando
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = Sqlcon;
                sqlcmd.CommandText = "speliminar_venta";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@idventa";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.IdVenta;
                sqlcmd.Parameters.Add(ParIdVenta);




                //Ejecutamos comando

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "no se elimino registro";






            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open) Sqlcon.Close();

            }
            return rpta;
        }

        //Método Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spmostrar_venta";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }

        public DataTable BuscarFechas(String textobuscar1, String textobuscar2)
        {
            DataTable DtResultado = new DataTable("venta");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscar_venta_fecha";
                Sqlcmd.CommandType = CommandType.StoredProcedure;


                SqlParameter PartextoBuscar1 = new SqlParameter();
                PartextoBuscar1.ParameterName = "@textobuscar";
                PartextoBuscar1.SqlDbType = SqlDbType.VarChar;
                PartextoBuscar1.Size = 50;
                PartextoBuscar1.Value = textobuscar1;
                Sqlcmd.Parameters.Add(PartextoBuscar1);

                SqlParameter PartextoBuscar2 = new SqlParameter();
                PartextoBuscar2.ParameterName = "@textobuscar2";
                PartextoBuscar2.SqlDbType = SqlDbType.VarChar;
                PartextoBuscar2.Size = 50;
                PartextoBuscar2.Value = textobuscar2;
                Sqlcmd.Parameters.Add(PartextoBuscar2);

                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }

        //Metodo Mostrar Detalle de las ventas

        public DataTable MostrarDetalle(String textobuscar)
        {
            DataTable DtResultado = new DataTable("detalle_venta");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spmostrar_detalle_venta";
                Sqlcmd.CommandType = CommandType.StoredProcedure;


                SqlParameter PartextoBuscar1 = new SqlParameter();
                PartextoBuscar1.ParameterName = "@textobuscar";
                PartextoBuscar1.SqlDbType = SqlDbType.VarChar;
                PartextoBuscar1.Size = 50;
                PartextoBuscar1.Value = textobuscar;
                Sqlcmd.Parameters.Add(PartextoBuscar1);



                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }

        //Mostrar Articulo por nombre
        public DataTable MostrarArticulo_venta_nombre(String textobuscar)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscararticulo_venta_nombre";
                Sqlcmd.CommandType = CommandType.StoredProcedure;


                SqlParameter PartextoBuscar1 = new SqlParameter();
                PartextoBuscar1.ParameterName = "@textobuscar";
                PartextoBuscar1.SqlDbType = SqlDbType.VarChar;
                PartextoBuscar1.Size = 50;
                PartextoBuscar1.Value = textobuscar;
                Sqlcmd.Parameters.Add(PartextoBuscar1);



                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }

        //Mostrar Articulo por nombre
        public DataTable MostrarArticulo_venta_codigo(String textobuscar)
        {
            DataTable DtResultado = new DataTable("articulo");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscararticulo_venta_codigo";
                Sqlcmd.CommandType = CommandType.StoredProcedure;


                SqlParameter PartextoBuscar1 = new SqlParameter();
                PartextoBuscar1.ParameterName = "@textobuscar";
                PartextoBuscar1.SqlDbType = SqlDbType.VarChar;
                PartextoBuscar1.Size = 50;
                PartextoBuscar1.Value = textobuscar;
                Sqlcmd.Parameters.Add(PartextoBuscar1);



                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }
    }


}
