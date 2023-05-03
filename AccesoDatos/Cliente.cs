using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }


        public DataTable GetClientes()
        {
            try
            {
                DataTable dataTable = new DataTable();

                //Declaramos la conexion
                using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
                {
                    //Declaramos un adaptador para poder regresar todos los datos de una tabla
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    //Ejecutamos el adaptador para obtener la informacion
                    adapter.SelectCommand = new SqlCommand("Select * from Clientes", connection);
                   
                    //Llenamos el datatable con la informacion obtenida 
                    adapter.Fill(dataTable);
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Agregar(Cliente cliente) 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString)) 
                {
                    string query = "Insert into Clientes (Nombre) VALUES (@Nombre)";
                    using (SqlCommand cmd = new SqlCommand(query, connection)) 
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(int clienteId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion.ConnectionString))
                {
                    string query = "Delete from Clientes Where Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", clienteId);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
