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
    public partial class FrmVistaProducto_Ingreso : Form
    {
        public FrmVistaProducto_Ingreso()
        {
            InitializeComponent();
        }

        private void FrmVistaProducto_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        //Metodo para ocultar Columnas

        private void OcultarColumnas()
        {
            this.DtProductos.Columns[0].Visible = false;
            this.DtProductos.Columns[1].Visible = false;
            this.DtProductos.Columns[6].Visible = false;
            this.DtProductos.Columns[8].Visible = false;


        }

        //metodo mostrar
        private void Mostrar()
        {
            this.DtProductos.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(DtProductos.Rows.Count);

        }

        //Metodo buscar por nombre
        private void BuscarNombre()
        {
            this.DtProductos.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(DtProductos.Rows.Count);
        }

        

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void DtProductos_DoubleClick(object sender, EventArgs e)
        {
            FormIngreso form = FormIngreso.GetInstancia();
            string part1, part2;
            part1 = Convert.ToString(this.DtProductos.CurrentRow.Cells["idarticulo"].Value);
            part2 = Convert.ToString(this.DtProductos.CurrentRow.Cells["nombre"].Value);

            form.setArticulo(part1,part2);
            this.Hide();

        }
    }
}
