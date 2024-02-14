using System;
using System.Data;
using System.Data.SqlClient;
using Sistema.Entidades;

namespace Sistema.Datos
{
    
    public class DProtocolo
    {
        public string Insertar(Protocolo Obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("Protocolo_insertar_detalle", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@idOrden", SqlDbType.BigInt).Value = Obj.idOrden;
                Comando.Parameters.Add("@idEstacion", SqlDbType.VarChar).Value = Obj.idEstacion;
                Comando.Parameters.Add("@DateAndTimeIn", SqlDbType.DateTime).Value = Obj.DateAndTimeIn;
                Comando.Parameters.Add("@DateAndTimeFbk", SqlDbType.DateTime).Value = Obj.DateAndTimeFbk;
                //Comando.Parameters.Add("@FlujoActual", SqlDbType.Int).Value = Obj.FlujoActual;
                Comando.Parameters.Add("@TiempoCiclo", SqlDbType.Decimal).Value = Obj.TiempoCiclo;
                Comando.Parameters.Add("@EstatusMaquina", SqlDbType.Int).Value = Obj.EstatusMaquina;
                Comando.Parameters.Add("@EstatusCalidad", SqlDbType.Int).Value = Obj.EstatusCalidad;
                Comando.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = Obj.Comentario;
                //----------------------------------------------PAINLINEINTEGRATION-----------------------------------------------------------------
                Comando.Parameters.Add("@LabelID", SqlDbType.Int).Value = Obj.LabelID;
                Comando.Parameters.Add("@Consecutive", SqlDbType.Int).Value = Obj.Consecutive;
                //---------------------------------------------------------------------------------------------------------------
                Comando.Parameters.Add("@detalle", SqlDbType.Structured).Value = Obj.Detalles;

                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = "OK";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

    }
}
