using AccesoDatos;
using System;
using System.Windows.Forms;

namespace VentasTransaction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GuardarVenta();
        }

        //Debemos reubicar este metodo 
        private void GuardarVenta()
        {
            try
            {
                Venta venta = new Venta();
                venta.CLienteId = 1;

                VentaDetalle producto1 = new VentaDetalle();
                producto1.ProductoId = 1;
                producto1.Cantidad = 1;
                producto1.Descripcion = "Azucar kg";
                producto1.PrecioUnitario = 27.00m;
                producto1.Importe = producto1.Cantidad * producto1.PrecioUnitario;
                venta.Conceptos.Add(producto1);

                VentaDetalle producto2 = new VentaDetalle();
                producto2.ProductoId = 2;
                producto2.Cantidad = 1;
                producto2.Descripcion = "Jugo Mango";
                producto2.PrecioUnitario = 10.00m;
                producto2.Importe = producto2.Cantidad * producto2.PrecioUnitario;
                venta.Conceptos.Add(producto2);

                venta.Total = producto1.Importe + producto2.Importe;
                venta.Guardar(venta);

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Ocurrio un error al guardar la venta {ex.Message}");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void iconMenuItem4_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes();
            clientes.ShowDialog();
        }

        private void icmExistencias_Click(object sender, EventArgs e)
        {
            frmExistencias existencias = new frmExistencias();
            existencias.ShowDialog();
        }

        private void icmProductos_Click(object sender, EventArgs e)
        {
            frmProductos productos = new frmProductos();
            productos.ShowDialog();
        }

        private void icmVentas_Click(object sender, EventArgs e)
        {
            frmVentas ventas = new frmVentas();
            ventas.ShowDialog();
        }
    }
}
