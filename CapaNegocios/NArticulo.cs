using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NArticulo
    {
        //Metodo Insertar que llama al metodo Insertar de la clase DArticulo de la CapaDatos
        public static string Insertar(String codigo, String nombre, String descripcion, byte[] imagen, int idcategoria,int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;


            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llame al metodo Editar de la clase Dcategoria

        public static string Editar(int idarticulo, String codigo, String nombre, String descripcion, byte[] imagen, int idcategoria, int idpresentacion)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;
            Obj.Codigo = codigo;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;
            Obj.Imagen = imagen;
            Obj.Idcategoria = idcategoria;
            Obj.Idpresentacion = idpresentacion;

            return Obj.Editar(Obj);
        }

        //Metodo Eliminar que llama al eliminar de la clase Dcategoria
        public static string Eliminar(int idarticulo)
        {
            DArticulo Obj = new DArticulo();
            Obj.Idarticulo = idarticulo;


            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo mostrar de la clase Dcategoria de la Capadatos
        public static DataTable Mostrar()
        {


            return new DArticulo().Mostrar();
        }

        //Metodo BuscarNombre que llama al metodo de la clase Dcategoria
        public static DataTable BuscarNombre(string textobuscar)
        {
            DArticulo Obj = new DArticulo();
            Obj.Textobuscar = textobuscar;
            return Obj.BuscarNombre(Obj);



        }
    }
}
