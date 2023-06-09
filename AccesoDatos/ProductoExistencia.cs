﻿using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class ProductoExistencia
    {
        public void ActualizarExistencia(SqlConnection con, SqlTransaction transaction, VentaDetalle concepto)
        {
            string query = "Update Existencias " +
                                "set Existencia = Existencia-@Cantidad" +
                                "where ProductoId = @ProductoId";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@ProductoId", concepto.ProductoId);
                cmd.Parameters.AddWithValue("@Cantidad", concepto.Cantidad);
                cmd.ExecuteNonQuery();

            }

        }

        public void AgregarExistenciaEnCero(SqlConnection con, SqlTransaction transaction, int ProductoId)
        {
            string query = "Insert Into Existencias (Existencia, ProductoId) VALUES (0, @ProductoId)";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@ProductoId", ProductoId);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarExistencia(SqlConnection con, SqlTransaction transaction,int productoId)
        {
            string query = "Delete From Existencias where ProductoId = @ProductoId";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = transaction;

                cmd.Parameters.AddWithValue("@ProductoId", productoId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
