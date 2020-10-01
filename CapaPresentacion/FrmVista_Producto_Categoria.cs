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
    public partial class FrmVista_Producto_Categoria : Form
    {
        public FrmVista_Producto_Categoria()
        {
            InitializeComponent();
        }

        //Metodo para ocultar Columnas

        private void OcultarColumnas()
        {
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Visible = true;
        }

        //metodo mostrar
        private void Mostrar()
        {
            this.dataGridView1.DataSource = NCategoria.Mostrar();
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(dataGridView1.Rows.Count);

        }

        //Metodo buscar por nombre
        private void BuscarNombre()
        {
            this.dataGridView1.DataSource = NCategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(dataGridView1.Rows.Count);
        }

        private void FrmVista_Producto_Categoria_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmArticulo form = FrmArticulo.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataGridView1.CurrentRow.Cells["idcategoria"].Value);
            par2 = Convert.ToString(this.dataGridView1.CurrentRow.Cells["nombre"].Value);

            form.setCategoria(par1, par2);
        
            this.Hide();
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
