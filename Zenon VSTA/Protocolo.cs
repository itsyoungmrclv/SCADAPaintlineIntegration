using System;
using System.Data;


namespace Sistema.Entidades
{
    public class Protocolo
    {
        public int idProtocolo { get; set; }
        public Int64 idOrden { get; set; }
        public string idEstacion { get; set; }
        public DateTime DateAndTimeIn { get; set; }
        public DateTime DateAndTimeFbk { get; set; }
        public int FlujoActual { get; set; }
        public decimal TiempoCiclo { get; set; }
        public int EstatusMaquina { get; set; }
        public int EstatusCalidad { get; set; }
        public string Comentario { get; set; }
        public DataTable Detalles { get; set; }
        //---------------------------------PAINLINEINTEGRATION------------------------------------------------------------------------------
        public int LabelID { get; set;}
        public int Consecutive { get; set;}
        //---------------------------------------------------------------------------------------------------------------
    }
}
