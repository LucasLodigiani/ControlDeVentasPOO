using System.Collections;

namespace ControlDeVentas
{
    public partial class frmVentas : Form
    {
        //Inicializando arreglo del producto.
        static string[] productos = { "Teclado", "Impresora", "Monitor", "Parlante", "Mouse"};

        //Objeto de la clase ArrayList
        ArrayList aProducto = new ArrayList(productos);

        //Objeto de la clase ventas
        Ventas objVenta = new Ventas();

        //Acumula totales
        double total;

        public frmVentas()
        {
            InitializeComponent();
        }


        private void cobProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            objVenta.Producto = cobProducto.Text;
            //AsignarPrecio devuelve double por ende lo convertimos a string con el parametro "C" de moneda.
            lblPrecio.Text = objVenta.AsignarPrecio().ToString("C");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Enviar datos a la clase ventas
            //Asignando por medio del set
            objVenta.Producto = cobProducto.Text;
            objVenta.Cantidad = int.Parse(txtCantidad.Text);

            //Imprimir resultados
            //Consiguiendo por medio del get
            ListViewItem fila = new ListViewItem(objVenta.Producto);
            fila.SubItems.Add(objVenta.Cantidad.ToString());
            fila.SubItems.Add(objVenta.AsignarPrecio().ToString("C"));
            fila.SubItems.Add(objVenta.CalcularSubTotal().ToString("C"));
            fila.SubItems.Add(objVenta.CalcularDescuento().ToString("C"));
            fila.SubItems.Add(objVenta.CalcularNeto().ToString("C"));

            lvRegistro.Items.Add(fila);

            //Suma de producto
            total += objVenta.CalcularNeto();

            //Imprimir totales
            lblTotalNeto.Text = total.ToString("C");

            //Limpiar campos
            LimpiarCampos();

        }


        private void frmVentas_Load(object sender, EventArgs e)
        {
            MostrarFecha();
            MostrarHora();
            LLenarProducto();
            lblTotalNeto.Text = "0.00";
            LimpiarCampos();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void MostrarFecha()
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void MostrarHora()
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void LimpiarCampos()
        {
            txtCliente.Clear();
            cobProducto.Text = "Seleccione un producto";
            txtCantidad.Clear();
            lblPrecio.Text = "0.00";
            txtCliente.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Desea salir del programa?", "Ventas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                LimpiarCampos();
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void LLenarProducto()
        {
            foreach (var p in aProducto)
            {
                cobProducto.Items.Add(p);
            }
        }

    }
}