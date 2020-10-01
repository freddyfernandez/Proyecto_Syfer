using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DProveedor
    {
        //variables
        private int _Idproveedor;
        private string _RazonSocial;
        private string _SectorComercial;
        private string _TipoDocumento;
        private string _NumDocumento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Url;
        private string _TextoBuscar;

        //Propiedades:encapsula la obtencion y asignacion de valor de una instancia de la variable

        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string RazonSocial { get => _RazonSocial; set => _RazonSocial = value; }
        public string SectorComercial { get => _SectorComercial; set => _SectorComercial = value; }
        public string TipoDocumento { get => _TipoDocumento; set => _TipoDocumento = value; }
        public string NumDocumento { get => _NumDocumento; set => _NumDocumento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Url { get => _Url; set => _Url = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }


        //Constructores

        public DProveedor()
        {
            
        }

        public DProveedor( int Idproveedor,
        string RazonSocial,
        string SectorComercial,
        string TipoDocumento,
        string NumDocumento,
        string Direccion,
        string Telefono,
        string Email,
        string Url,
        string TextoBuscar)
        {
            this.Idproveedor = Idproveedor;
            this.RazonSocial = RazonSocial;
            this.SectorComercial = SectorComercial;
            this.TipoDocumento = TipoDocumento;
            this.NumDocumento = NumDocumento;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Email = Email;
            this.Url = Url;
            this.TextoBuscar = TextoBuscar;



        }


        //Metodo Insertar

        public string Insertar(DProveedor Proveedor)
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
                sqlcmd.CommandText = "spinsertar_proveedor";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRSocial = new SqlParameter();
                ParRSocial.ParameterName = "@razon_social";
                ParRSocial.SqlDbType = SqlDbType.VarChar;
                ParRSocial.Size = 150;
                ParRSocial.Value = Proveedor.RazonSocial;
                sqlcmd.Parameters.Add(ParRSocial);

                SqlParameter ParSComercial = new SqlParameter();
                ParSComercial.ParameterName = "@sector_comercial";
                ParSComercial.SqlDbType = SqlDbType.VarChar;
                ParSComercial.Size = 50;
                ParSComercial.Value = Proveedor.SectorComercial;
                sqlcmd.Parameters.Add(ParSComercial);

                SqlParameter ParTDocumento = new SqlParameter();
                ParTDocumento.ParameterName = "@tipo_documento";
                ParTDocumento.SqlDbType = SqlDbType.VarChar;
                ParTDocumento.Size = 20;
                ParTDocumento.Value = Proveedor.TipoDocumento;
                sqlcmd.Parameters.Add(ParTDocumento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 11;
                ParNumDocumento.Value = Proveedor.NumDocumento;
                sqlcmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                sqlcmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Proveedor.Telefono;
                sqlcmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                sqlcmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 150;
                ParUrl.Value = Proveedor.Url;
                sqlcmd.Parameters.Add(ParUrl);



                //Ejecutamos comando

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "no se ingreso registro";






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

        //Metodo Editar
        public string Editar(DProveedor Proveedor)
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
                sqlcmd.CommandText = "speditar_proveedor";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.Idproveedor;
                sqlcmd.Parameters.Add(ParIdProveedor);

                SqlParameter ParRSocial = new SqlParameter();
                ParRSocial.ParameterName = "@razon_social";
                ParRSocial.SqlDbType = SqlDbType.VarChar;
                ParRSocial.Size = 50;
                ParRSocial.Value = Proveedor.RazonSocial; //(clase->)categoria.nombre(->metodo)= es un valor instaciado de la clase categoria

                sqlcmd.Parameters.Add(ParRSocial);

                SqlParameter ParSComercial = new SqlParameter();
                ParSComercial.ParameterName = "@sector_comercial";
                ParSComercial.SqlDbType = SqlDbType.VarChar;
                ParSComercial.Size = 50;
                ParSComercial.Value = Proveedor.SectorComercial;
                sqlcmd.Parameters.Add(ParSComercial);

                SqlParameter ParTDocumento = new SqlParameter();
                ParTDocumento.ParameterName = "@tipo_documento";
                ParTDocumento.SqlDbType = SqlDbType.VarChar;
                ParTDocumento.Size = 20;
                ParTDocumento.Value = Proveedor.TipoDocumento;
                sqlcmd.Parameters.Add(ParTDocumento);

                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@num_documento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 11;
                ParNumDocumento.Value = Proveedor.NumDocumento;
                sqlcmd.Parameters.Add(ParNumDocumento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                sqlcmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Proveedor.Telefono;
                sqlcmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                sqlcmd.Parameters.Add(ParEmail);

                SqlParameter ParUrl = new SqlParameter();
                ParUrl.ParameterName = "@url";
                ParUrl.SqlDbType = SqlDbType.VarChar;
                ParUrl.Size = 50;
                ParUrl.Value = Proveedor.Url;
                sqlcmd.Parameters.Add(ParUrl);


                //Ejecutamos comando

                rpta = sqlcmd.ExecuteNonQuery() == 1 ? "OK" : "no se actualizo registro";






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

        //Metodo Eliminar
        public string Eliminar(DProveedor Proveedor)
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
                sqlcmd.CommandText = "speliminar_proveedor";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@idproveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.Idproveedor;
                sqlcmd.Parameters.Add(ParIdProveedor);




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

        //Método Listar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spmostrar_proveedor";
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


        public DataTable BuscarRazonSocial(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscar_proveedor_razon_social";
                Sqlcmd.CommandType = CommandType.StoredProcedure;


                SqlParameter PartextoBuscar = new SqlParameter();
                PartextoBuscar.ParameterName = "@textobuscar";
                PartextoBuscar.SqlDbType = SqlDbType.VarChar;
                PartextoBuscar.Size = 50;
                PartextoBuscar.Value = Proveedor.TextoBuscar;
                Sqlcmd.Parameters.Add(PartextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;

            }
            return DtResultado;
        }

        public DataTable BuscarNumDocumento(DProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("proveedor");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscar_proveedor_num_documento";
                Sqlcmd.CommandType = CommandType.StoredProcedure;


                SqlParameter PartextoBuscar = new SqlParameter();
                PartextoBuscar.ParameterName = "@textobuscar";
                PartextoBuscar.SqlDbType = SqlDbType.VarChar;
                PartextoBuscar.Size = 20;
                PartextoBuscar.Value = Proveedor.TextoBuscar;
                Sqlcmd.Parameters.Add(PartextoBuscar);

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
