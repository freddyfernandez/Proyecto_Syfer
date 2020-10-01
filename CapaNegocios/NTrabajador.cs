using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NTrabajador
    {
        //Método insertar que llame al metodo insertar de la clase DTrabajador

        public static string Insertar(string nombre, string apellidos,
            string sexo, DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono,
            string email,string acceso,string usuario,string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llame al metodo Editar de la clase Dcategoria

        public static string Editar(int idtrabajador, string nombre, string apellidos,
            string sexo, DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono,
            string email,string acceso, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Nombre = nombre;
            Obj.Apellidos = apellidos;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Editar(Obj);
        }

        //Metodo Eliminar que llama al eliminar de la clase DProveedor
        public static string Eliminar(int idtrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;


            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo mostrar de la clase Dcategoria de la Capadatos
        public static DataTable Mostrar()
        {


            return new DTrabajador().Mostrar();
        }

        //Metodo BuscarApellido que llama al metodo de la clase DCliente
        public static DataTable BuscarApellidos(string textobuscar)
        {

            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarApellidos(Obj);




        }

        //Metodo BuscarNumDocumento que llama al metodo de la clase DProveedor
        public static DataTable BuscarNumDocumento(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNumDocumento(Obj);

        }

        //Metodo Login
        public static DataTable Login(string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;
            return Obj.Login(Obj);

        }


    }
}
