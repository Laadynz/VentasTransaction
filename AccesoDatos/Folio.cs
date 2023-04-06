using System;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Folio
    {
        public int Id { get; set; }
        public int FolioActual { get; set; }

        public int ObtenerFolioActual(SqlConnection con, SqlTransaction transaction)
        {
            try
            {
                string query = "select top(1) FolioActual from Folios";
                int folioActual = 0;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = transaction;

                    if (!int.TryParse(cmd.ExecuteScalar().ToString(), out folioActual))
                    {
                        throw new Exception("Ocurrio un error al obtener el folio");
                    }
                }
                return folioActual;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
