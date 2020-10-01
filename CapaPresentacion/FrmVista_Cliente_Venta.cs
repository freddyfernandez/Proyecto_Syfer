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
    public partial class FrmVista_Cliente_Venta : Form
    {
        public FrmVista_Cliente_Venta()
        {
            InitializeComponent();
        }

        private void FrmVista_Cliente_Venta_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        //Metodo para ocultar Columnas

        private void OcultarColumnas()
        {
            this.DataListadoCliente.Columns[0].Visible = false;
            this.DataListadoCliente.Columns[1].Visible = false;
        }

        //metodo mostrar
        private void Mostrar()
        {
            this.DataListadoCliente.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(DataListadoCliente.Rows.Count);

        }

        //Metodo buscar por apellidos
        private void BuscarApellidos()
        {
            this.DataListadoCliente.DataSource = NCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(DataListadoCliente.Rows.Count);
        }

        //Metodo buscar Numero de Documento
        private void BuscarNumDocumento()
        {
            this.DataListadoCliente.DataSource = NCliente.BuscarNumDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(DataListadoCliente.Rows.Count);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cbnDocumento.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (cbnDocumento.Text.Equals("Documento"))
            {
                this.BuscarNumDocumento();
            }
        }

        private void DataListadoCliente_DoubleClick(object sender, EventArgs e)
        {
            FrmVenta form = FrmVenta.GetInstancia();
            string part1, part2;
            part1 = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["idcliente"].Value);
            part2 = Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["apellidos"].Value)+" "+
                    Convert.ToString(this.DataListadoCliente.CurrentRow.Cells["apellidos"].Value);
            form.setCliente(part1,part2);
            this.Hide();

        }
    }
}
