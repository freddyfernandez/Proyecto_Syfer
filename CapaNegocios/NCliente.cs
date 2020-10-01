using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos; //nos comunicamos con la capa Datos

namespace CapaNegocios
{
    public class NCliente
    {
        //Método insertar que llame al metodo insertar de la clase DProveedor

        public static string Insertar(string nombre, string apellidos,
            string sexo, DateTime fecha_nacimiento,string tipo_documento,
            string num_documento,string direccion, string telefono,
            string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            


            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llame al metodo Editar de la clase Dcategoria

        public static string Editar(int idcliente,string nombre, string apellidos,
            string sexo, DateTime fecha_nacimiento, string tipo_documento,
            string num_documento, string direccion, string telefono,
            string email)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;

            return Obj.Editar(Obj);
        }

        //Metodo Eliminar que llama al eliminar de la clase DProveedor
        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;


            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo mostrar de la clase Dcategoria de la Capadatos
        public static DataTable Mostrar()
        {


            return new DCliente().Mostrar();
        }

        //Metodo BuscarApellido que llama al metodo de la clase DCliente
        public static DataTable BuscarApellidos(string textobuscar)
        {

            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);




        }

        //Metodo BuscarNumDocumento que llama al metodo de la clase DProveedor
        public static DataTable BuscarNumDocumento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNumDocumento(Obj);



        }
    }

}
