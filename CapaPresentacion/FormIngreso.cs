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
    public partial class FormIngreso : Form
    {
        public int idtrabajador;

        private bool IsNuevo;
        private DataTable dtDetalles; // para almacenar todos los detalles de un ingreso
        private decimal TotalPagado=0; //acumulador para ir actualizando el total de compras
        private static FormIngreso _Instancia;
        public static FormIngreso GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FormIngreso();

            }
            return _Instancia;
        }
        public void setProveedor(string idproveedor,string nombre ) {
            this.txtIdProveedor.Text = idproveedor;
            this.txtProveedor.Text = nombre;
        }

        public void setArticulo(string idarticulo, string nombre)
        {
            this.txtIdarticulo.Text = idarticulo;
            this.txtProducto.Text = nombre;
            
        }

        public FormIngreso()
        {
            InitializeComponent();
            this.toolTipMensaje.SetToolTip(this.txtIdProveedor,"Selecciones el proveedor");
            this.toolTipMensaje.SetToolTip(this.txtSerie, "Ingrese la Serie del comprobante");

            this.toolTipMensaje.SetToolTip(this.txtCorrelativo, "Ingrese el numero del Comprobante");
            this.toolTipMensaje.SetToolTip(this.txtStockInicial, "Ingrese la cantidad de Compra");
            this.toolTipMensaje.SetToolTip(this.txtIdarticulo, "Seleccione el Producto de Compra");

            //Cuando el formulario se active ocultamos las cajas de texto y sean solo escritura
            this.txtIdProveedor.Visible = false;
            this.txtIdarticulo.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtProducto.ReadOnly = true;
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

            this.txtIdingreso.Text = string.Empty;
            this.txtIdProveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.txtCorrelativo.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblTotalPagado.Text = "0,0";

            this.txtIgv.Text = "18";
            this.CrearTabla();


        }

        //para limpiar solamente los controles referente a los detalles de ingreso
        private void limpiarDetalle()
        {
            this.txtIdarticulo.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtStockInicial.Text = string.Empty;
            this.txtpreciocompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdingreso.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;

            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dateTimePickerF.Enabled = valor;
            this.cbnComprobante.Enabled = valor;
            this.txtStockInicial.ReadOnly = !valor;
            this.txtpreciocompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.dateTimePickerFP.Enabled = valor;
            this.dateTimePickerFV.Enabled = valor;

            //habilitamos los botones de busqueda
            this.btnBuscarProducto.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            //el codigo del articulo de solo lectura 
            this.txtIdarticulo.ReadOnly = !valor;


        }

        //Habilitat botones

        private void Botones()
        {
            if (this.IsNuevo ) //alt + 124
            {
                this.Habilitar(true);
                this.BtnNuevo.Enabled = false;
                this.BtnGuardar.Enabled = true;
              
                this.BtnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.BtnNuevo.Enabled = true;
                this.BtnGuardar.Enabled = false;
           
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
            this.dataGridView1.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(dataGridView1.Rows.Count);

        }

        //Metodo buscar por parametro de Fechas
        private void BuscarFechas()
        {
            this.dataGridView1.DataSource = NIngreso.BuscarFechas(this.dateTimePickerFI.Value.ToString("dd/MM/yyyy"),
                this.dateTimePickerFA.Value.ToString("dd/MM/yyyy"));

            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(dataGridView1.Rows.Count);
        }



        //Metodo buscar detalle
        private void MostrarDetalle()
        {
            this.dataListadoDetalle .DataSource = NIngreso.MostrarDetalle(this.txtIdingreso.Text);
 
           
        }

        private void CrearTabla()
        {
            this.dtDetalles = new DataTable("Detalle");
            this.dtDetalles.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.dtDetalles.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalles.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.dtDetalles.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalles.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalles.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalles.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalles.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));

            //Relacionar nuestro DataGridView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalles;





        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void FormIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();



        }

        private void FormIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVistaProveedor_Ingreso frm = new FrmVistaProveedor_Ingreso();
            frm.ShowDialog();

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmVistaProducto_Ingreso frm = new FrmVistaProducto_Ingreso();
            frm.ShowDialog();
        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }





        private void BtnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Desea Anular los registros?");
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                //este metodo contiene el mensaje de tipo messagebox confirmacion 
                                this.MensajeOk("Se Anulo correctamente el registro");
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

        private void chkAnular_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnular.Checked)
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
            if (e.ColumnIndex == dataGridView1.Columns["Anular"].Index)
            {
                DataGridViewCheckBoxCell ChkAnular = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["Anular"];
                ChkAnular.Value = !Convert.ToBoolean(ChkAnular.Value);
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            //habilitamos los botonoes y cajas de texto
            this.IsNuevo = true;
            this.Botones();
            this.limpiar();
            this.Habilitar(true);

            //Enfoncamos a la Textbox Serie
            this.txtSerie.Focus();

            //Limpiamos despues de agregar todos los valores
            this.limpiarDetalle();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
           
            this.Botones();
            this.limpiar();
            this.Habilitar(false);

            this.limpiarDetalle();
        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdProveedor.Text == string.Empty || this.txtSerie.Text == string.Empty ||
                    this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text==string.Empty)
                {
                    MensajeError("Falta ingresar datos, seran remarcados");
                    errorProviderIcono.SetError(txtIdProveedor, "Ingrese el Codigo de Proveedor");
                    errorProviderIcono.SetError(txtSerie, "Ingrese la Serie");
                    errorProviderIcono.SetError(txtCorrelativo, "Ingrese el Correlativo");
                    errorProviderIcono.SetError(txtIgv, "Ingrese el IGV");

                }
                else
                {
                    
                    if (this.IsNuevo)
                    {
                        rpta = NIngreso.Insertar(idtrabajador, Convert.ToInt32(this.txtIdProveedor.Text),
                            dateTimePickerF.Value, cbnComprobante.Text, txtSerie.Text,
                            txtCorrelativo.Text , Convert.ToDecimal(txtIgv.Text),"EMITIDO",
                            dtDetalles);
                    }
                    
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto correctamente");
                        }
                     
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                   
                    this.Botones();
                    this.limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (this.txtIdarticulo.Text == string.Empty || this.txtStockInicial.Text == string.Empty ||
                    this.txtpreciocompra.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar datos, seran remarcados");
                    errorProviderIcono.SetError(txtIdarticulo, "Ingrese Valor");
                    errorProviderIcono.SetError(txtStockInicial, "Ingrese Valor");
                    errorProviderIcono.SetError(txtpreciocompra, "Ingrese Valor");
                    errorProviderIcono.SetError(txtPrecioVenta, "Ingrese Valor");

                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row  in dtDetalles.Rows)
                    {
                        if (Convert.ToInt32(row["idarticulo"]) == Convert.ToInt32(this.txtIdarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("ya se encuentra el articulo en el detalle");
                        }
                    }
                    if (registrar)
                    {
                        decimal subtotal = Convert.ToDecimal(this.txtStockInicial.Text)*
                        Convert.ToDecimal(this.txtpreciocompra.Text);
                        TotalPagado = TotalPagado + subtotal;
                        //formato de salida del total
                        this.lblTotalPagado.Text = TotalPagado.ToString("#0.00#");
                        //Agregar el detalle al Datalistadodetalle
                        DataRow row = this.dtDetalles.NewRow();
                        row["idarticulo"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["articulo"] = this.txtProducto.Text;
                        row["precio_compra"] = Convert.ToDecimal(this.txtpreciocompra.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["stock_inicial"] = Convert.ToInt32(this.txtStockInicial.Text);
                        row["fecha_produccion"] = dateTimePickerFP.Value;
                        row["fecha_vencimiento"] = dateTimePickerFV.Value;
                        row["subtotal"] = subtotal;

                        //A nuestro datatable le agregamos los detalles generados
                        this.dtDetalles.Rows.Add(row);
                        this.limpiarDetalle();    
                    }
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int IndiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalles.Rows[IndiceFila];

                //Para Diminuir el Total Pagado
                this.TotalPagado = this.TotalPagado-Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotalPagado.Text = TotalPagado.ToString("#0.00#");
                //Removemos la fila
                this.dtDetalles.Rows.Remove(row);
            } 
            catch (Exception ex)
            {
                MensajeError("No hay Fila para Remover");  
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdingreso.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["idingreso"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["proveedor"].Value);
            this.dateTimePickerF.Value = Convert.ToDateTime(this.dataGridView1.CurrentRow.Cells["fecha"].Value);
            this.cbnComprobante.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["correlativo"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells["total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;





        }

        private void dataListadoDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataListadoDetalle_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lblTotalPagado_Click(object sender, EventArgs e)
        {

        }
    }
}
