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
    public partial class FrmArticulo : Form
    {

        private bool IsNuevo;
        private bool IsEditar;


        private static FrmArticulo _Instancia;
        public static FrmArticulo GetInstancia() 
        { 
            if(_Instancia == null)
            {
               _Instancia = new FrmArticulo();
            }
            return _Instancia;

         
        }

        public void setCategoria(string idcategoria,string nombre)
        {
            this.txtIdCategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;
        }


        public FrmArticulo()
        {
            InitializeComponent();
            this.toolTipMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del producto");
            this.toolTipMensaje.SetToolTip(this.pxImagen, "Seleccione la imagen del producto");
            this.toolTipMensaje.SetToolTip(this.txtIdCategoria, "Seleccione la categoria del producto");
            this.toolTipMensaje.SetToolTip(this.cbnIdPresentacion, "Seleccione la presentacion del producto");

            this.txtIdarticulo.ReadOnly = true;
            this.txtIdCategoria.ReadOnly = true;
            this.txtCategoria.ReadOnly = true;
            this.llenarcombopresentacion();
        }

        //Mostrar mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } 
        //Mostrar un mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //metodo para limpiar los controles del formulario
        private void limpiar()
        {

            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdarticulo.Text = string.Empty;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;


        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
           
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
          
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscarCategoria.Enabled = valor;
    
            this.cbnIdPresentacion.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
           
            

        }

        private void leerCodigo(bool valor)
        {
            this.txtIdarticulo.ReadOnly = valor;
        }

        //Habilitat botones

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //alt + 124
            {
                this.Habilitar(true);
                this.leerCodigo(true);
                this.BtnNuevo.Enabled = false;
                this.BtnGuardar.Enabled = true;
                this.BtnEditar.Enabled = false;
                this.BtnCancelar.Enabled = true;

           

            }
            else
            {
                this.Habilitar(false);
                this.leerCodigo(true);
                this.BtnNuevo.Enabled = true;
                this.BtnGuardar.Enabled = false;
                this.BtnEditar.Enabled = true;
                this.BtnCancelar.Enabled = false;
            }
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

        private void llenarcombopresentacion()
        {
            cbnIdPresentacion.DataSource = NPresentacion.Mostrar();
            cbnIdPresentacion.ValueMember = "idpresentacion";
            cbnIdPresentacion.DisplayMember = "nombre";
        }

        

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void FrmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);   
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        private void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtIdCategoria.Text == string.Empty || this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar datos, seran remarcados");
                    errorProviderIcono.SetError(txtNombre, "Ingrese un nombre");
                    errorProviderIcono.SetError(txtCodigo, "Ingrese un Codigo");
                    errorProviderIcono.SetError(txtCategoria, "Ingrese un Categoria");

                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Png);
                    
                    byte[] imagen = ms.GetBuffer();

                    if (this.IsNuevo)
                    {
                        rpta = NArticulo.Insertar(this.txtCodigo.Text,this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim(),imagen, Convert.ToInt32(this.txtIdCategoria.Text)
                            , Convert.ToInt32(this.cbnIdPresentacion.SelectedValue));
                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(this.txtIdarticulo.Text), this.txtCodigo.Text, this.txtNombre.Text.Trim().ToUpper()
                            ,
                            this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.txtIdCategoria.Text)
                            , Convert.ToInt32(this.cbnIdPresentacion.SelectedValue));



                    } 
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto correctamente");
                        }
                        else
                        {
                            this.MensajeOk("se actualizo correctamente");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.limpiar();
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdarticulo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe seleccionar primero un registro a Modificar");
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.limpiar();
            this.Habilitar(false);
        }

        private void DtProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DtProductos.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DtProductos.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

    

       

        private void DtProductos_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdarticulo.Text = Convert.ToString(this.DtProductos.CurrentRow.Cells["idarticulo"].Value);
            this.txtCodigo.Text = Convert.ToString(this.DtProductos.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.DtProductos.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.DtProductos.CurrentRow.Cells["descripcion"].Value);

            byte[] imagenBuffer = (byte[])this.DtProductos.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdCategoria.Text = Convert.ToString(this.DtProductos.CurrentRow.Cells["idcategoria"].Value);
            this.txtCategoria.Text = Convert.ToString(this.DtProductos.CurrentRow.Cells["Categoria"].Value);
            this.cbnIdPresentacion.SelectedValue = Convert.ToString(this.DtProductos.CurrentRow.Cells["idpresentacion"].Value);


            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                //se lanza un evento interactivo que hace visible a una columna
                this.DtProductos.Columns[0].Visible = true;

            }
            else

            {
                //evento interactivo que esconde la columna
                this.DtProductos.Columns[0].Visible = false;
            }
        }

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea Eliminar los registros?");
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in DtProductos.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                //este metodo contiene el mensaje de tipo messagebox confirmacion 
                                this.MensajeOk("Se Elimino correctamente el registro");
                            }
                            else
                            {
                                //este metodo contiene el mensaje de tipo messagebox error
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmVista_Producto_Categoria form = new FrmVista_Producto_Categoria();
            form.ShowDialog();
        }

       
    }
}
