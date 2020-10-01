using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DIngreso
    {
        //Variables
        private int _Idingreso;
        private int _Idtrabajador;
        private int _Idproveedor;
        private DateTime _Fecha;
        private string _TipoComprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private string _Estado;

        //Propiedades

        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string TipoComprobante { get => _TipoComprobante; set => _TipoComprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }
        public string Estado { get => _Estado; set => _Estado = value; }


        //Constructores
        public DIngreso()
        {
            
        }
        public DIngreso(int idingreso,int idtrabajador,int idproveedor,DateTime fecha,string tipocomprobante
            ,string serie,string correlativo,decimal igv,string estado)
        {
            this.Idingreso = idingreso;
            this.Idtrabajador = idtrabajador;
            this.Idproveedor = idproveedor;
            this.Fecha = fecha;
            this.TipoComprobante = tipocomprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Estado = estado;

        }

        public string Insertar(DIngreso Ingreso,List<DDetalleIngreso> Detalle)
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
                sqlcmd.CommandText = "spinsertar_ingreso";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@idingreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(ParIdIngreso);

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Ingreso.Idtrabajador; //(clase->)categoria.nombre(->metodo)= es un valor instaciado de la clase categoria

                sqlcmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Ingreso.Idproveedor;
                sqlcmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ingreso.Fecha;
                sqlcmd.Parameters.Add(ParFecha);

                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@tipo_comprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Ingreso.TipoComprobante;
                sqlcmd.Parameters.Add(ParTipoComprobante);

                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie;
                sqlcmd.Parameters.Add(ParSerie);

                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Ingreso.Correlativo;
                sqlcmd.Parameters.Add(ParCorrelativo);

                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Size = 2;
                ParIgv.Value = Ingreso.Igv;
                sqlcmd.Parameters.Add(ParIgv);

                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado;
                sqlcmd.Parameters.Add(ParEstado);


                //Escribimos la sentencia para insertar los detalles

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "no se ingreso registro";
                if (rpta.Equals("OK"))
                {
                    //Obtener codigo ingreso generado
                    this.Idingreso = Convert.ToInt32(sqlcmd.Parameters["@idingreso"].Value);
                    foreach (DDetalleIngreso det in Detalle)
                    {
                        det.Idingreso = this.Idingreso;

                        //llamar al metodo insertar de la clase DDetalle_ingreso
                        rpta = det.Insertar(det,ref Sqlcon,ref Sqltran);
                        if (!rpta.Equals("OK"))
                        {
                            break;
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

        public string Anular(DIngreso Ingreso)
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
                sqlcmd.CommandText = "spanular_ingreso";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdingreso = new SqlParameter();
                ParIdingreso.ParameterName = "@idingreso";
                ParIdingreso.SqlDbType = SqlDbType.Int;
                ParIdingreso.Value = Ingreso.Idingreso;
                sqlcmd.Parameters.Add(ParIdingreso);




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
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spmostrar_ingreso";
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

        public DataTable BuscarFechas(String textobuscar1 ,String textobuscar2)
        {
            DataTable DtResultado = new DataTable("ingreso");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscar_ingreso_fecha";
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

        //Metodo Mostrar Detalle

        public DataTable MostrarDetalle(String textobuscar)
        {
            DataTable DtResultado = new DataTable("detalle_ingreso");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spmostrar_detalle_ingreso";
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

