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
    public partial class FrmCliente : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmCliente()
        {
            InitializeComponent();
            this.toolTipMensaje.SetToolTip(this.txtNombre,"Ingrese nombre del cliente");
            this.toolTipMensaje.SetToolTip(this.txtApellidos, "Ingrese nombre del cliente");
            this.toolTipMensaje.SetToolTip(this.txtDireccion, "Ingrese nombre del cliente");
            this.toolTipMensaje.SetToolTip(this.txtNDoc, "Ingrese numero de documento del cliente");

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

            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNDoc.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
         
            this.txtEmail.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;


        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbnDocumento.Enabled = valor;
            this.cbnTDoc.Enabled = valor;
            this.txtNDoc.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
          
            this.txtEmail.ReadOnly = !valor;
            this.txtIdcliente.ReadOnly = !valor;



        }

        //Habilitat botones

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //alt + 124
            {
                this.Habilitar(true);
                this.BtnNuevo.Enabled = false;
                this.BtnGuardar.Enabled = true;
                this.BtnEditar.Enabled = false;
                this.BtnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.BtnNuevo.Enabled = true;
                this.BtnGuardar.Enabled = false;
                this.BtnEditar.Enabled = true;
                this.BtnCancelar.Enabled = false;
            }
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
            this.dataGridView1.DataSource = NCliente.Mostrar();
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(dataGridView1.Rows.Count);

        }

        //Metodo buscar Razon Social
        private void BuscarApellidos()
        {
            this.dataGridView1.DataSource = NCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(dataGridView1.Rows.Count);
        }

        //Metodo buscar Numero de Documento
        private void BuscarNumDocumento()
        {
            this.dataGridView1.DataSource = NCliente.BuscarNumDocumento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(dataGridView1.Rows.Count);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
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

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea Eliminar los registros?");
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NCliente.Eliminar(Convert.ToInt32(Codigo));

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

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                //se lanza un evento interactivo que hace visible a una columna
                this.dataGridView1.Columns[0].Visible = true;

            }
            else

            {
                //evento interactivo que esconde la columna
                this.dataGridView1.Columns[0].Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdcliente.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["idcliente"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["apellidos"].Value);
            this.cbnSexo.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["sexo"].Value);
            this.dateTimePickerFN.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["fecha_nacimiento"].Value);
            this.cbnTDoc.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNDoc.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["telefono"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["email"].Value);

            this.tabControl1.SelectedIndex = 1;
         

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
                if (this.txtNombre.Text == string.Empty
                     || this.txtApellidos.Text == string.Empty || this.txtNDoc.Text == string.Empty
                     || this.txtDireccion.Text == string.Empty
                   )
                {
                    MensajeError("Falta ingresar datos, seran remarcados");
                    errorProviderIcono.SetError(txtNombre, "Ingrese un valor");
                    errorProviderIcono.SetError(txtNDoc, "Ingrese un valor");
                    errorProviderIcono.SetError(txtApellidos, "Ingrese un valor");
                    errorProviderIcono.SetError(txtDireccion, "Ingrese un valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NCliente.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                            txtApellidos.Text,
                            this.cbnSexo.Text,dateTimePickerFN.Value, cbnTDoc.Text, txtNDoc.Text,
                            txtDireccion.Text, txtTelefono.Text, txtEmail.Text);

                    }
                    else
                    {
                        rpta = NCliente.Editar(Convert.ToInt32(this.txtIdcliente.Text),
                            this.txtNombre.Text.Trim().ToUpper(), txtApellidos.Text,
                            this.cbnSexo.Text,dateTimePickerFN.Value, cbnTDoc.Text, txtNDoc.Text,
                            txtDireccion.Text, txtTelefono.Text, txtEmail.Text);

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
            if (!this.txtIdcliente.Text.Equals(""))
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
            this.txtIdcliente.Text = string.Empty;
        }
    }
}
