using AccesoDatos;
using System;
using System.Windows.Forms;

namespace VentasTransaction
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            LlenaGrid();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlenaGrid()
        {
            try
            {
                Cliente cliente = new Cliente();
                dtvClientes.DataSource = cliente.GetClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                {
                    throw new Exception("No hay elementos en el grid");
                }

                Cliente cliente = new Cliente();
                cliente.Id = int.Parse(dtvClientes.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                cliente.Nombre = dtvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

                string mensaje = $"¿Estas seguro de borrar el cliente {cliente.Nombre}?";

                DialogResult respuesta = MessageBox.Show(mensaje, "Confirmar!", MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    cliente.Eliminar(cliente.Id);
                    LlenaGrid();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text)) { throw new Exception("Se debe especificar nombre"); }

                Cliente cliente = new Cliente();
                cliente.Nombre = txtNombre.Text;

                cliente.Agregar(cliente);

                txtNombre.Text = "";
                LlenaGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
