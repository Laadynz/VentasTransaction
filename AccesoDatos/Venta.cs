using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Venta
    {
        public int Id { get; set; }
        public int Folio { get; private set; }
        public DateTime Fecha { get; private set; }
        public int CLienteId { get; set; }
        public decimal Total { get; set; }
        public List<VentaDetalle> Conceptos { get; set; } = new List<VentaDetalle>();

        public void Guardar(Venta venta)
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

                            string ejecutaQuery = cmd.ExecuteScalar().ToString(); 
                            bool sePudoConvertir = int.TryParse(ejecutaQuery, out int idVenta);

                            if (!sePudoConvertir)
                            {
                                throw new Exception("Ocurrio un error al obtener el id de la venta");
                            }
                            venta.Id = idVenta;
                        }

                        foreach (VentaDetalle concepto in venta.Conceptos)
                        {
                            concepto.VentaId = venta.Id; //llave foranea de ventas
                            concepto.GuardarConceptos(con, transaction, concepto);

                            ProductoExistencia existencia = new ProductoExistencia();
                            existencia.ActualizarExistencia(con, transaction, concepto);
                        }

                        folio.ActualizaFolio(con, transaction);
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
