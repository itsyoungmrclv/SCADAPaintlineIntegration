using System;
using System.Data;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class NProtocolo
    {
        public static string Insertar(Int64 IdOrden, string IdEstacion, DateTime DateAndTimeIn, DateTime DateAndTimeFbk, decimal TiempoCiclo, int EstatusMaquina, int EstatusCalidad, string Comentario, int LabelID, int Consecutive, DataTable Detalles)
        {
            DProtocolo Protcolo = new DProtocolo();
            Protocolo Obj = new Protocolo();
            //var instance = new DProtocolo();
            Obj.idOrden = IdOrden;
            Obj.idEstacion = IdEstacion;
            Obj.DateAndTimeIn = DateAndTimeIn;
            Obj.DateAndTimeFbk = DateAndTimeFbk;
            //Obj.FlujoActual = FlujoActual;
            Obj.TiempoCiclo = TiempoCiclo;
            Obj.EstatusMaquina = EstatusMaquina;
            Obj.EstatusCalidad = EstatusCalidad;
            Obj.Comentario = Comentario;
            //----------------------------------PAINLINEINTEGRATION-----------------------------------------------------------------------------
            Obj.LabelID = LabelID;
            Obj.Consecutive = Consecutive;
            //---------------------------------------------------------------------------------------------------------------
            Obj.Detalles = Detalles;

            return Protcolo.Insertar(Obj);

        }
    }
}
