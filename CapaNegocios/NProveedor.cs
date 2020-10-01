using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using CapaDatos;

namespace CapaNegocios
{
    public class NProveedor
    {
        //Método insertar que llame al metodo insertar de la clase DProveedor

        public static string Insertar(string razon_proveedor, string sector_comercial,
            string tipo_documento,string num_documento,string direccion,string telefono,
            string email,string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.RazonSocial = razon_proveedor;
            Obj.SectorComercial = sector_comercial;
            Obj.TipoDocumento = tipo_documento;
            Obj.NumDocumento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;


            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llame al metodo Editar de la clase Dcategoria

        public static string Editar(int idproveedor, string razon_proveedor, string sector_comercial,
            string tipo_documento, string num_documento, string direccion, string telefono,
            string email, string url)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;
            Obj.RazonSocial = razon_proveedor;
            Obj.SectorComercial = sector_comercial;
            Obj.TipoDocumento = tipo_documento;
            Obj.NumDocumento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Url = url;

            return Obj.Editar(Obj);
        }

        //Metodo Eliminar que llama al eliminar de la clase DProveedor
        public static string Eliminar(int idproveedor)
        {
            DProveedor Obj = new DProveedor();
            Obj.Idproveedor = idproveedor;


            return Obj.Eliminar(Obj);
        }
        //Metodo Mostrar que llama al metodo mostrar de la clase Dcategoria de la Capadatos
        public static DataTable Mostrar()
        {


            return new DProveedor().Mostrar();
        }

        //Metodo BuscarNumDocumento que llama al metodo de la clase DProveedor
        public static DataTable BuscarRazonSocial(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarRazonSocial(Obj);



        }

        //Metodo BuscarNumDocumento que llama al metodo de la clase DProveedor
        public static DataTable BuscarNumDocumento(string textobuscar)
        {
            DProveedor Obj = new DProveedor();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNumDocumento(Obj);



        }
    }
}
