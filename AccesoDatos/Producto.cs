using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }

        public DataTable GetProductos()
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
                    adapter.SelectCommand = new SqlCommand("Select * from Productos", connection);

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

        public void Agregar(Producto producto)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.ConnectionString))
                {
                    SqlTransaction transaction;
                    con.Open();
                    transaction = con.BeginTransaction();
                    try
                    {
                        string query = "INSERT INTO Productos " +
                          "(Descripcion, PrecioUnitario) " +
                          "VALUES " +
                          "(@Descripcion, @PrecioUnitario); select scope_identity()";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = transaction;

                            cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                            cmd.Parameters.AddWithValue("@PrecioUnitario", producto.PrecioUnitario);

                            string ejecutaQuery = cmd.ExecuteScalar().ToString();
                            bool sePudoConvertir = int.TryParse(ejecutaQuery, out int idProducto);

                            if (!sePudoConvertir)
                            {
                                throw new Exception("Ocurrio un error al obtener el id del producto");
                            }
                            producto.Id = idProducto;
                        }

                        ProductoExistencia existencia = new ProductoExistencia();
                        existencia.AgregarExistenciaEnCero(con, transaction, producto.Id);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        
        public void Eliminar(int productoId) 
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.ConnectionString))
                {
                    SqlTransaction transaction;
                    con.Open();
                    transaction = con.BeginTransaction();
                    try
                    {
                        ProductoExistencia existencia = new ProductoExistencia();
                        existencia.EliminarExistencia(con, transaction, productoId);


                        string query = "DELETE From Productos Where Id = @Id;";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = transaction;

                            cmd.Parameters.AddWithValue("@Id", productoId);

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
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
