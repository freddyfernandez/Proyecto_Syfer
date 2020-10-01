using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocios
{
    public class NPresentacion
    {
        //Metodo Insertar que llama al metodo Insertar de la clase DPresentacion de la CapaDatos
        public static string Insertar(String nombre, String descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llame al metodo Editar de la clase Dcategoria

        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Editar(Obj);
        }

        //Metodo Eliminar que llama al eliminar de la clase Dcategoria
        public static string Eliminar(int idpresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.IdPresentacion = idpresentacion;


            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo mostrar de la clase Dcategoria de la Capadatos
        public static DataTable Mostrar()
        {


            return new DPresentacion().Mostrar();
        }

        //Metodo BuscarNombre que llama al metodo de la clase Dcategoria
        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);



        }


    }
}
