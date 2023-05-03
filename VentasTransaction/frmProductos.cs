using AccesoDatos;
using System;
using System.Windows.Forms;

namespace VentasTransaction
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
            LlenaGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDescripcion.Text)) { throw new Exception("Se debe especificar el nombre del nvo producto"); }

                Producto producto = new Producto();
                producto.Descripcion = txtDescripcion.Text;
                producto.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);

                producto.Agregar(producto);

                txtDescripcion.Text = "";
                txtPrecioUnitario.Text = "";
                LlenaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlenaGrid()
        {
            try
            {
                Producto producto = new Producto();
                dtvProductos.DataSource = producto.GetProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dtvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    throw new Exception("No hay elementos en el grid");
                }

                Producto producto = new Producto();
                producto.Id = int.Parse(dtvProductos.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                producto.Descripcion = dtvProductos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                producto.PrecioUnitario = decimal.Parse(dtvProductos.Rows[e.RowIndex].Cells["PrecioUnitario"].Value.ToString());

                string mensaje = $"¿Estas seguro de borrar este producto {producto.Descripcion}?";

                DialogResult respuesta = MessageBox.Show(mensaje, "Confirmar!", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    producto.Eliminar(producto.Id);
                    LlenaGrid();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

      
    }
}
