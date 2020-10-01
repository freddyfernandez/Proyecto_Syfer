using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace CapaDatos
{
    public class DTrabajador
    {
        //Variables

        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Tipo_Documento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _password;
        private string _TextoBuscar;

        //Propiedades
        public int Idtrabajador { get => _Idtrabajador; set => _Idtrabajador = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime Fecha_Nacimiento { get => _Fecha_Nacimiento; set => _Fecha_Nacimiento = value; }
        public string Tipo_Documento { get => _Tipo_Documento; set => _Tipo_Documento = value; }
        public string Num_Documento { get => _Num_Documento; set => _Num_Documento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _password; set => _password = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructores
        public DTrabajador() { 

        }


        public DTrabajador(int idtrabajador,string nombre, string apellidos,string sexo, DateTime fecha_nacimiento,
            string num_documento,string direccion,string telefono, string email,
            string acceso,string usuario, string password,string textobuscar) {

            this.Idtrabajador = idtrabajador;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Num_Documento = num_documento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar = textobuscar;

        }

        //Metodo Insertar

        public string Insertar(DTrabajador Trabajador)
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
                sqlcmd.CommandText = "spinsertar_trabajador";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Direction = ParameterDirection.Output;
                sqlcmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Trabajador.Nombre;
                sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = Trabajador.Apellidos;
                sqlcmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Trabajador.Sexo;
                sqlcmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.DateTime;
                ParFecha_Nacimiento.Size = 50;
                ParFecha_Nacimiento.Value = Trabajador.Fecha_Nacimiento;
                sqlcmd.Parameters.Add(ParFecha_Nacimiento);

             

                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Trabajador.Num_Documento;
                sqlcmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Trabajador.Direccion;
                sqlcmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Trabajador.Telefono;
                sqlcmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Trabajador.Email;
                sqlcmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 50;
                ParAcceso.Value = Trabajador.Acceso;
                sqlcmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Trabajador.Usuario;
                sqlcmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Trabajador.Password;
                sqlcmd.Parameters.Add(ParPassword);




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
        public string Editar(DTrabajador Trabajador
            )
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
                sqlcmd.CommandText = "speditar_trabajador";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value =Trabajador.Idtrabajador;
                sqlcmd.Parameters.Add(ParIdTrabajador);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Trabajador.Nombre;
                sqlcmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 50;
                ParApellidos.Value = Trabajador.Apellidos;
                sqlcmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Trabajador.Sexo;
                sqlcmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.DateTime;
                ParFecha_Nacimiento.Size = 50;
                ParFecha_Nacimiento.Value = Trabajador.Fecha_Nacimiento;
                sqlcmd.Parameters.Add(ParFecha_Nacimiento);



                SqlParameter ParNum_Documento = new SqlParameter();
                ParNum_Documento.ParameterName = "@num_documento";
                ParNum_Documento.SqlDbType = SqlDbType.VarChar;
                ParNum_Documento.Size = 11;
                ParNum_Documento.Value = Trabajador.Num_Documento;
                sqlcmd.Parameters.Add(ParNum_Documento);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Trabajador.Direccion;
                sqlcmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Trabajador.Telefono;
                sqlcmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Trabajador.Email;
                sqlcmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 50;
                ParAcceso.Value = Trabajador.Acceso;
                sqlcmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Trabajador.Usuario;
                sqlcmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Trabajador.Password;
                sqlcmd.Parameters.Add(ParPassword);


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
        public string Eliminar(DTrabajador Trabajador)
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
                sqlcmd.CommandText = "speliminar_trabajador";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdTrabajador = new SqlParameter();
                ParIdTrabajador.ParameterName = "@idtrabajador";
                ParIdTrabajador.SqlDbType = SqlDbType.Int;
                ParIdTrabajador.Value = Trabajador.Idtrabajador;
                sqlcmd.Parameters.Add(ParIdTrabajador);




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
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spmostrar_trabajador";
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


        public DataTable BuscarApellidos(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscar_trabajador_apellidos";
                Sqlcmd.CommandType = CommandType.StoredProcedure;


                SqlParameter PartextoBuscar = new SqlParameter();
                PartextoBuscar.ParameterName = "@textobuscar";
                PartextoBuscar.SqlDbType = SqlDbType.VarChar;
                PartextoBuscar.Size = 50;
                PartextoBuscar.Value = Trabajador.TextoBuscar;
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

        public DataTable BuscarNumDocumento(DTrabajador trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "spbuscar_trabajador_num_documento";
                Sqlcmd.CommandType = CommandType.StoredProcedure;


                SqlParameter PartextoBuscar = new SqlParameter();
                PartextoBuscar.ParameterName = "@textobuscar";
                PartextoBuscar.SqlDbType = SqlDbType.VarChar;
                PartextoBuscar.Size = 20;
                PartextoBuscar.Value = trabajador.TextoBuscar;
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

        public DataTable Login(DTrabajador trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = Conexion.Cn;
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = Sqlcon;
                Sqlcmd.CommandText = "splogin";
                Sqlcmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = trabajador.Usuario;
                Sqlcmd.Parameters.Add(ParUsuario);

                SqlParameter ParPasword = new SqlParameter();
                ParPasword.ParameterName = "@password";
                ParPasword.SqlDbType = SqlDbType.VarChar;
                ParPasword.Size = 20;
                ParPasword.Value = trabajador.Password;
                Sqlcmd.Parameters.Add(ParPasword);

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
