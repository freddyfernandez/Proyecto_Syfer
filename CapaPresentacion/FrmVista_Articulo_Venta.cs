using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocios;

namespace CapaPresentacion
{
    public partial class FrmVista_Articulo_Venta : Form
    {
        public FrmVista_Articulo_Venta()
        {
            InitializeComponent();
        }

        private void FrmVista_Articulo_Venta_Load(object sender, EventArgs e)
        {

        }

        //Metodo para ocultar Columnas

        private void OcultarColumnas()
        {
            this.DataListadoArticulo.Columns[0].Visible = false;
            this.DataListadoArticulo.Columns[1].Visible = false;

        }


        //Metodo buscar articulo por el nombre
        private void BuscarArticulo_Venta_Nombre()
        {
            this.DataListadoArticulo.DataSource = NVenta.Mostrar_Articulo_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(DataListadoArticulo.Rows.Count);
        }

        //Metodo buscar articulo por el codigo
        private void BuscarArticulo_Venta_Codigo()
        {
            this.DataListadoArticulo.DataSource = NVenta.Mostrar_Articulo_Venta_Codigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(DataListadoArticulo.Rows.Count);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cbnDocumento.Text.Equals("Codigo"))
            {
                this.BuscarArticulo_Venta_Codigo();
            }
            else if (cbnDocumento.Text.Equals("Nombre"))
            {
                this.BuscarArticulo_Venta_Nombre();



            }
        }

        private void DataListadoArticulo_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta form = FrmVenta.GetInstancia();
            string part1, part2;
            decimal part3, part4;
            int part5;
            DateTime part6;

            part1=  Convert.ToString(this.DataListadoArticulo.CurrentRow.Cells["iddetalle_ingreso"].Value);
            part2 = Convert.ToString(this.DataListadoArticulo.CurrentRow.Cells["nombre"].Value);
            part3 = Convert.ToDecimal(this.DataListadoArticulo.CurrentRow.Cells["precio_compra"].Value);
            part4 = Convert.ToDecimal(this.DataListadoArticulo.CurrentRow.Cells["precio_venta"].Value);
            part5 = Convert.ToInt32(this.DataListadoArticulo.CurrentRow.Cells["stock_actual"].Value);
            part6 = Convert.ToDateTime(this.DataListadoArticulo.CurrentRow.Cells["fecha_vencimiento"].Value);

            form.setArticulo(part1,part2,part3,part4,part5,part6);
           
            this.Hide(); //ocultamos este formulario
        }

        private void cbnDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
