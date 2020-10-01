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
    public partial class FrmVenta : Form
    {

        private bool IsNuevo = false;
        public int IdTrabajador;
        private DataTable dtDetalle;

        private decimal totalPagado = 0;

        private static FrmVenta _Instancia;

        public static FrmVenta GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmVenta();

            }
            return _Instancia;
        }

        public void setCliente(string idcliente,string cliente)
        {
            this.txtIdCliente.Text = idcliente;
            this.txtCliente.Text = cliente;
        }

        public void setArticulo(string iddetalle_ingreso,string nombre,
            decimal precio_compra,decimal precio_venta,int stock,
            DateTime fecha_vencimiento)
        {
            this.txtIdarticulo.Text = iddetalle_ingreso;
            this.txtProducto.Text = nombre;
            this.txtpreciocompra.Text = Convert.ToString(precio_compra);
            this.txtPrecioVenta.Text = Convert.ToString(precio_venta);
            this.txtStockActual.Text = Convert.ToString(stock);
            this.dateTimePickerFV.Value = fecha_vencimiento;


        }





        public FrmVenta()
        {
            InitializeComponent();
        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.CrearTabla();
        }

        private void FrmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVista_Cliente_Venta vista = new FrmVista_Cliente_Venta();
            vista.ShowDialog();

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmVista_Articulo_Venta vista = new FrmVista_Articulo_Venta();
            vista.ShowDialog();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();
            

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

            this.txtIdVenta.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
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
            this.txtStockActual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtpreciocompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtIdVenta.ReadOnly = !valor;
            this.txtSerie.ReadOnly = !valor;

            this.txtCorrelativo.ReadOnly = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.dateTimePickerF.Enabled = valor;
            this.cbnComprobante.Enabled = valor;
            this.txtCantidad.ReadOnly = !valor;
            this.txtStockActual.ReadOnly = !valor;
            this.txtpreciocompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
   
            this.dateTimePickerFV.Enabled = valor;

            //habilitamos los botones de busqueda
            this.btnBuscarProducto.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            //el codigo del articulo de solo lectura 
            this.txtIdarticulo.ReadOnly = !valor;


        }

        //Habilitat botones

        private void Botones()
        {
            if (this.IsNuevo) //alt + 124
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
            this.DataListadoVenta.Columns[0].Visible = false;
            this.DataListadoVenta.Columns[1].Visible = false;

        }

        //metodo mostrar
        private void Mostrar()
        {
            this.DataListadoVenta.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(DataListadoVenta.Rows.Count);

        }

        //Metodo buscar por parametro de Fechas
        private void BuscarFechas()
        {
            this.DataListadoVenta.DataSource = NVenta.BuscarFechas(this.dateTimePickerFI.Value.ToString("dd/MM/yyyy"),
                this.dateTimePickerFA.Value.ToString("dd/MM/yyyy"));

            this.OcultarColumnas();
            lbltotal.Text = "Total de Registros " + Convert.ToString(DataListadoVenta.Rows.Count);
        }



        //Metodo buscar detalle
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NVenta.MostrarDetalle(this.txtIdVenta.Text);


        }

        private void CrearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Impuesto", System.Type.GetType("System.Decimal"));

            //Relacionar nuestro DataGridView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;





        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtIdarticulo.Text == string.Empty || this.txtCantidad.Text == string.Empty ||
                    this.txtDescuento.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar datos, seran remarcados");
                    errorProviderIcono.SetError(txtIdarticulo, "Ingrese Valor");
                    errorProviderIcono.SetError(txtCantidad, "Ingrese Valor");
                    errorProviderIcono.SetError(txtDescuento, "Ingrese Valor");
                    errorProviderIcono.SetError(txtPrecioVenta, "Ingrese Valor");

                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(this.txtIdarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("ya se encuentra el articulo en el detalle");
                        }
                    }
                    if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStockActual.Text))
                    {
                        decimal subtotal = Convert.ToDecimal(this.txtCantidad.Text) *
                        Convert.ToDecimal(this.txtPrecioVenta.Text) - Convert.ToDecimal(this.txtDescuento.Text);
                        totalPagado = totalPagado + subtotal;
                        //formato de salida del total
                        this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                        //Agregar el detalle al Datalistadodetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["articulo"] = this.txtProducto.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["subtotal"] = subtotal;

                        //A nuestro datatable le agregamos los detalles generados
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();
                    }
                    else
                    {
                        MensajeError("No hay stock suficiente");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in DataListadoVenta.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NVenta.Eliminar(Convert.ToInt32(Codigo));

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

        private void DataListadoVenta_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdVenta.Text = Convert.ToString(this.DataListadoVenta.CurrentRow.Cells["idventa"].Value);
            this.txtCliente.Text = Convert.ToString(this.DataListadoVenta.CurrentRow.Cells["cliente"].Value);
            this.dateTimePickerF.Value = Convert.ToDateTime(this.DataListadoVenta.CurrentRow.Cells["fecha"].Value);
            this.cbnComprobante.Text = Convert.ToString(this.DataListadoVenta.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.DataListadoVenta.CurrentRow.Cells["serie"].Value);
            this.txtCorrelativo.Text = Convert.ToString(this.DataListadoVenta.CurrentRow.Cells["correlativo"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.DataListadoVenta.CurrentRow.Cells["total"].Value);
            this.txtIgv.Text= Convert.ToString(this.DataListadoVenta.CurrentRow.Cells["Impuesto"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                //se lanza un evento interactivo que hace visible a una columna
                this.DataListadoVenta.Columns[0].Visible = true;

            }
            else

            {
                //evento interactivo que esconde la columna
                this.DataListadoVenta.Columns[0].Visible = false;
            }
        }

        private void DataListadoVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DataListadoVenta.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkAnular = (DataGridViewCheckBoxCell)DataListadoVenta.Rows[e.RowIndex].Cells["Eliminar"];
                ChkAnular.Value = !Convert.ToBoolean(ChkAnular.Value);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
            this.txtSerie.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtIdCliente.Text == string.Empty || this.txtSerie.Text == string.Empty ||
                    this.txtCorrelativo.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar datos, seran remarcados");
                    errorProviderIcono.SetError(txtIdCliente, "Ingrese el Codigo de Proveedor");
                    errorProviderIcono.SetError(txtSerie, "Ingrese la Serie");
                    errorProviderIcono.SetError(txtCorrelativo, "Ingrese el Correlativo");
                    errorProviderIcono.SetError(txtIgv, "Ingrese el IGV");

                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = NVenta.Insertar(Convert.ToInt32(this.txtIdCliente.Text), IdTrabajador,
                            dateTimePickerF.Value, cbnComprobante.Text, txtSerie.Text,
                            txtCorrelativo.Text, Convert.ToDecimal(txtIgv.Text),
                            dtDetalle);
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

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int IndiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[IndiceFila];

                //Para Diminuir el Total Pagado
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay Fila para Remover");
            }
        }

    }
}
