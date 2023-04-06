using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Venta
    {
        public int Id { get; set; }
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public int CLienteId { get; set; }
        public decimal Total { get; set; }
        public List<VentaDetalle> Conceptos { get; set; } = new List<VentaDetalle>();

        public Venta GuardarVenta(Venta venta)
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
                        Folio folio = new Folio();
                        int folioActual = folio.ObtenerFolioActual(con, transaction);

                        venta.Folio = folioActual + 1;
                        venta.Fecha = DateTime.Now;

                        string query = "INSERT INTO Ventas " +
                            "(Folio,Fecha,ClienteId,Total) " +
                            "VALUES " +
                            "(@Folio,@Fecha,@ClienteId,@Total);select scope_identity()";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = transaction;
                            cmd.Parameters.AddWithValue("@Folio", venta.Folio);
                            cmd.Parameters.AddWithValue("@Fecha", venta.Fecha);
                            cmd.Parameters.AddWithValue("@ClienteId", venta.CLienteId);
                            cmd.Parameters.AddWithValue("@Total", venta.Total);


                            if (!int.TryParse(cmd.ExecuteScalar().ToString(), out int idVenta))
                            {
                                throw new Exception("Ocurrio un error al obtener el id de la venta");
                            }
                            venta.Id = idVenta;
                        }

                        foreach (VentaDetalle concepto in venta.Conceptos)
                        {
                            concepto.VentaId = venta.Id;
                            concepto.GuardarConceptos(con, transaction, concepto);


                            query = "Update Existencias " +
                                    "set Existencia = Existencia-@Cantidad " +
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

                        query = "Update Folios set Folio = Folio + 1 ";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Transaction = transaction;

                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show($"Venta guardada correctamente con folio {venta.Folio}");

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }





                return venta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
