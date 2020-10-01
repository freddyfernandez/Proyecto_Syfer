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
    public partial class FrmVistaProveedor_Ingreso : Form
    {
        public FrmVistaProveedor_Ingreso()
        {
            InitializeComponent();
        }

        private void FrmVistaProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        //Metodo para ocultar Columnas

        private void OcultarColumnas()
        {
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Visible = false;
        }

        //metodo mostrar
        private void Mostrar()
        {
            this.dataGridView1.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(dataGridView1.Rows.Count);

        }

        //Metodo buscar Razon Social
        private void BuscarRazonSocial()
        {
            this.dataGridView1.DataSource = NProveedor.BuscarRazonSocial(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(dataGridView1.Rows.Count);
        }

        //Metodo buscar Numero de Documento
        private void BuscarNumDocumento()
        {
            this.dataGridView1.DataSource = NProveedor.BuscarNumDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(dataGridView1.Rows.Count);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cbnDocumento.Text.Equals("Razon social"))
            {
                this.BuscarRazonSocial();
            }
            else if (cbnDocumento.Text.Equals("Documento"))
            {
                this.BuscarNumDocumento();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FormIngreso form = FormIngreso.GetInstancia();
            string par1, par2;
            par1=Convert.ToString(this.dataGridView1.CurrentRow.Cells["idproveedor"].Value);
            par2 = Convert.ToString(this.dataGridView1.CurrentRow.Cells["razon_social"].Value);

            form.setProveedor(par1,par2);

            this.Hide();

        }
    }
}
