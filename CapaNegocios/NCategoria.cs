using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;


namespace CapaNegocios
{
    public class NCategoria
    {
        //Método insertar que llame al metodo insertar de la clase Dcategoria

        public static string Insertar(String nombre, String descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llame al metodo Editar de la clase Dcategoria

        public static string Editar(int idcategora, string nombre, string descripcion)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategora;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Editar(Obj);
        }

        //Metodo Eliminar que llama al eliminar de la clase Dcategoria
        public static string Eliminar(int idcategora)
        {
            DCategoria Obj = new DCategoria();
            Obj.Idcategoria = idcategora;
           

            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo mostrar de la clase Dcategoria de la Capadatos
        public static DataTable Mostrar()
        {


            return new DCategoria().Mostrar();
        }

        //Metodo BuscarNombre que llama al metodo de la clase Dcategoria
        public static DataTable BuscarNombre(string textobuscar)
        {
            DCategoria Obj = new DCategoria();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNombre(Obj);



        }




    }
}
