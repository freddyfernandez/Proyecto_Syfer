using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;

        //comunicacion con FrmLogin
        public string Idtrabajador="";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";



        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoria frm = new FrmCategoria();
            frm.MdiParent = this;
            frm.Show();

        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPresentacion frm = new FrmPresentacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulo frm = FrmArticulo.GetInstancia();
            frm.MdiParent = this;
            frm.Show();


          
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveeedor frm = new FrmProveeedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIngreso frm = FormIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.idtrabajador = Convert.ToInt32(this.Idtrabajador);


        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente frm = new FrmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrabajador frm = new FrmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();

        }

        private void GestionUsuario()
        {
            //Controlar los Accesos

            if (Acceso == "Administrador")
            {
                this.MnAlmacen.Enabled = true;
                this.MnCompras.Enabled = true;
                this.MnConsultas.Enabled = true;
                this.MnMantenimiento.Enabled = true;
                this.MnVentas.Enabled = true;
                this.MnHerramientas.Enabled = true;
                this.toolStripCompras.Enabled = true;
                this.toolStripVentas.Enabled = true;



            }
            else if (Acceso == "Vendedor")
            {
                this.MnAlmacen.Enabled = false;
                this.MnCompras.Enabled = false;
                this.MnConsultas.Enabled = true;
                this.MnMantenimiento.Enabled = false;
                this.MnVentas.Enabled = true;
                this.MnHerramientas.Enabled = true;
                this.toolStripCompras.Enabled = false;
                this.toolStripVentas.Enabled = true;
            }
            else if (Acceso == "Almacenero")
            {
                this.MnAlmacen.Enabled = true;
                this.MnCompras.Enabled = true;
                this.MnConsultas.Enabled = true;
                this.MnMantenimiento.Enabled = false;
                this.MnVentas.Enabled = false;
                this.MnHerramientas.Enabled = true;
                this.toolStripCompras.Enabled = true;
                this.toolStripVentas.Enabled = false;
            }

            else
            {
                this.MnAlmacen.Enabled = false;
                this.MnCompras.Enabled = false;
                this.MnConsultas.Enabled = false;
                this.MnMantenimiento.Enabled = false;
                this.MnVentas.Enabled = false;
                this.MnHerramientas.Enabled = false;
                this.toolStripCompras.Enabled = false;
                this.toolStripVentas.Enabled = false;
            }


        }

        private void TootipVentas_Click(object sender, EventArgs e)
        {
            FrmVenta frm = FrmVenta.GetInstancia();
            frm.MdiParent=this;//este formulario abierto se ejecute permanentemente
            frm.Show();
            frm.IdTrabajador = Convert.ToInt32(this.Idtrabajador);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
