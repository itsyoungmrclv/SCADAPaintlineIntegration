using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Sistema.Datos;
using Sistema.Negocio;
using System.Globalization;

namespace ProjectAddin
{
    class ThreadContainer
    {
        //ThisProject Obj = new ThisProject();
        DataTable[] DtDetalle = ThisProject.dtDetalle;
        DataTable[] DtPs = ThisProject.dtPs;
        zenOn.IVariable[][] iV = ThisProject.IV;
        
        public string tReport(string station, int n)
        {
            string Rpta = "";
            Int64 OrderID = -2;
            string SOrderID = "";
                        
            try
            {
                DtDetalle[n].Clear();
                DtPs[n].Clear();
                Rpta = tReadVariables(station, n);
                if (Rpta == "OK")
                {
                    Rpta = "";

                    Int64 iPKN = Int64.Parse(iV[n][1].get_Value(0).ToString());
                    int iJITSec = int.Parse(iV[n][0].get_Value(0).ToString());

                    SOrderID = tGetIDOrden(iPKN, iJITSec, station);


                    if (SOrderID == "There is no row at position 0.")
                        OrderID = -1;
                    else
                        OrderID = Convert.ToInt64(SOrderID);

                    if (OrderID == -1)
                    {
                        /*SOrderID = tInsertarOrden(DtPs[n].Rows[0][11].ToString(), DtPs[n].Rows[0][12].ToString(),
                                                  Convert.ToInt32(DtPs[n].Rows[0][10].ToString()), Convert.ToInt16(DtPs[n].Rows[0][09].ToString()));
                        OrderID = Convert.ToInt64(SOrderID);*/
                        if (OrderID == -1)
                        {
                            SOrderID = tGetIDOrden(iPKN, iJITSec, station);
                        }
                        else
                            Rpta = "Error getting ID Order: Order no exists from PKN " + iPKN.ToString() + " & JITSec " + iJITSec.ToString() ;  //"Error creating new ID Order";
                    }
                    if (OrderID != -1)
                        Rpta = tinsertProtocolo(OrderID, DtDetalle[n], DtPs[n]);
                    else
                        Rpta = "Error getting ID Order: Order no exists from PKN " + iPKN.ToString() + " & JITSec " + iJITSec.ToString(); //"Error Reading ID Order";

                }
            }
            catch (Exception ex)
            {
                Rpta = station + " : " + ex;
                //throw;
                
            }
            return Rpta;
        }

        public string tReadVariables(string station, int n)
        {
            
            string Rpta = "";

            try
            {
                /*
                DataTable DtDetalle = ThisProject.dtDetalle;
                DataTable DtPs = ThisProject.dtPs;
                zenOn.IVariable[][] iV = ThisProject.IV;
                */

                //create table DtDetalle
                if (DtDetalle[n] == null)
                    DtDetalle[n] = ThisProject.CrearTablaDetalle();
                if (DtPs[n] == null)
                    DtPs[n] = ThisProject.CrearTablaPs();

                //create rows for Datatables
                DataRow Fila;
                DataRow FilaPs;
                Fila = DtDetalle[n].NewRow();
                FilaPs = DtPs[n].NewRow();

                // Primera fila de datos de protocolo
                Fila[0] = station;
                Fila[1] = station;

                string initTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture);

                if (iV[n][12].IsOnline() == true)
                {
                    //this.Cel().WriteCelString("Tags are online" + station);
                    Rpta = "Tags are online"+  station + " " + iV[n][12].Name.ToString();

                    if (station == ThisProject.stations[0])
                    {
                        // boolean values
                        for (int i = 2; i < 16; i++)
                        {
                            Fila[i] = Convert.ToBoolean(iV[n][i + 10].get_Value(0));
                        }

                        for (int i = 46; i < 48; i++)
                        {
                            Fila[i] = iV[n][i + 170].get_Value(0);
                        }

                        DtDetalle[n].Rows.Add(Fila);

                        //Punch Values
                        for (int j = 0; j < 5; j++)
                        {
                            if (Convert.ToBoolean(iV[n][j + 14].get_Value(0)))
                            {
                                Fila = DtDetalle[n].NewRow();

                                Fila[0] = "Punch";
                                Fila[1] = station.ToString();

                                for (int i = 46; i < 52; i++) // ANTES < 53
                                {
                                    Fila[i] = iV[n][((i - 16) + (j * 10))].get_Value(0);
                                }

                                for (int i = 54; i < 58; i++)
                                {
                                    Fila[i] = iV[n][((i - 28) + (j * 10))].get_Value(0);
                                }
                                Fila[58] = ThisProject.names[j + 1].ToString();

                                DtDetalle[n].Rows.Add(Fila);
                            }
                        }
                        //Weld data Values
                        for (int j = 0; j < 14; j++)
                        {
                            if (j < 2)
                            {
                                if (Convert.ToBoolean(iV[n][14].get_Value(0)))
                                {
                                    addWeldData(station, DtDetalle[n], Fila, j, 6, iV[n]);
                                }
                            }
                            else if (j > 1 && j < 7)
                            {
                                if (Convert.ToBoolean(iV[n][15].get_Value(0)))
                                {
                                    addWeldData(station, DtDetalle[n], Fila, j, 6, iV[n]);
                                }
                            }
                            else if (j > 6 && j < 12)
                            {
                                if (Convert.ToBoolean(iV[n][16].get_Value(0)))
                                {
                                    addWeldData(station, DtDetalle[n], Fila, j, 6, iV[n]);
                                }
                            }
                            else if (j > 11 && j < 14)
                            {
                                if (Convert.ToBoolean(iV[n][17].get_Value(0)))
                                {
                                    addWeldData(station, DtDetalle[n], Fila, j, 6, iV[n]);
                                }
                            }

                        }

                    }
                    else if (station == ThisProject.stations[1])
                    {
                        //Boolean Values
                        for (int i = 2; i < 42; i++)
                        {
                            Fila[i] = Convert.ToBoolean(iV[n][i + 10].get_Value(0));

                        }
                        DtDetalle[n].Rows.Add(Fila);
                    }
                    else if (station == ThisProject.stations[2])
                    {
                        //Boolean Values
                        for (int i = 2; i < 32; i++)
                        {
                            Fila[i] = Convert.ToBoolean(iV[n][i + 10].get_Value(0));

                        }
                        DtDetalle[n].Rows.Add(Fila);
                    }
                    else if (station == ThisProject.stations[3])
                    {
                        //Boolean Values
                        for (int i = 2; i < 28; i++)
                        {
                            Fila[i] = Convert.ToBoolean(iV[n][i + 10].get_Value(0));

                        }

                        Fila[54] = Convert.ToDecimal(iV[n][39].get_Value(0));
                        Fila[55] = Convert.ToDecimal(iV[n][40].get_Value(0));
                        Fila[58] = Convert.ToString(iV[n][38].get_Value(0));

                        DtDetalle[n].Rows.Add(Fila);
                    }
                    else if (station == ThisProject.stations[4])
                    {
                        //Boolean Values
                        Fila[2] = Convert.ToBoolean(iV[n][90].get_Value(0));
                        Fila[3] = Convert.ToBoolean(iV[n][91].get_Value(0));
                        Fila[4] = Convert.ToBoolean(iV[n][100].get_Value(0));

                        if (Convert.ToInt32(iV[n][92].get_Value(0)) != 0 || Convert.ToInt32(iV[n][93].get_Value(0)) != 0 ||
                            Convert.ToInt32(iV[n][94].get_Value(0)) != 0 || Convert.ToInt32(iV[n][95].get_Value(0)) != 0 ||
                            Convert.ToInt32(iV[n][96].get_Value(0)) != 0 || Convert.ToInt32(iV[n][97].get_Value(0)) != 0 ||
                            Convert.ToInt32(iV[n][98].get_Value(0)) != 0)
                            Fila[5] = Convert.ToBoolean(iV[n][62].get_Value(0));
                        else
                            Fila[5] = false;
                        if (Convert.ToInt32(iV[n][92].get_Value(0)) != 0 && Convert.ToInt32(iV[n][93].get_Value(0)) != 0 &&
                            Convert.ToInt32(iV[n][94].get_Value(0)) != 0 && Convert.ToInt32(iV[n][95].get_Value(0)) != 0 &&
                            Convert.ToInt32(iV[n][96].get_Value(0)) != 0 && Convert.ToInt32(iV[n][97].get_Value(0)) != 0 &&
                            Convert.ToInt32(iV[n][98].get_Value(0)) != 0)
                            Fila[6] = true;
                        else
                            Fila[6] = false;
                        if (Convert.ToInt32(iV[n][101].get_Value(0)) != 0)
                            Fila[7] = true;
                        else
                            Fila[7] = false;

                        //Scrapped Flags
                        Fila[8] = Convert.ToBoolean(iV[n][12].get_Value(0));
                        Fila[9] = Convert.ToBoolean(iV[n][13].get_Value(0));
                        Fila[10] = Convert.ToBoolean(iV[n][14].get_Value(0));
                        Fila[11] = Convert.ToBoolean(iV[n][15].get_Value(0));
                        Fila[12] = Convert.ToBoolean(iV[n][16].get_Value(0));

                        //process data
                        for (int i = 46; i < 61; i++)
                        {
                            //Cycle Timer
                            if (i < 54)
                                Fila[i] = Convert.ToInt32(iV[n][(i + 56)].get_Value(0));
                            //Etest
                            if (i > 53 && i < 58)  // antes if (i > 53 && i < 59)
                                Fila[i] = Convert.ToDecimal(iV[n][(i + 38)].get_Value(0));

                            if (i > 57)
                                Fila[i + 3] = Convert.ToDecimal(iV[n][(i + 38)].get_Value(0));
                        }
                        /*
                        Fila[61] = Convert.ToDecimal(iV[n][96].get_Value(0));
                        Fila[62] = Convert.ToDecimal(iV[n][97].get_Value(0));
                        Fila[63] = Convert.ToDecimal(iV[n][98].get_Value(0));*/
                        
                        //Id_Etest & Clipping count
                        Fila[65] = Convert.ToInt32(iV[n][99].get_Value(0));
                        Fila[66] = Convert.ToInt32(iV[n][101].get_Value(0));

                        DtDetalle[n].Rows.Add(Fila);

                        //torque data
                        for (int j = 0; j < 8; j++)
                        {

                            if (Convert.ToInt32(iV[n][42 + (j * 3)].get_Value(0)) != 0)
                            {
                                Fila = DtDetalle[n].NewRow();
                                Fila[0] = "Torque";
                                Fila[1] = station.ToString();

                                for (int i = 46; i < 49; i++)
                                {
                                    Fila[i] = Convert.ToInt32(iV[n][((i - 4) + (j * 3))].get_Value(0));

                                }

                                Fila[58] = "Torque";

                                DtDetalle[n].Rows.Add(Fila);
                            }

                        }

                        //scan data
                        for (int j = 0; j < 8; j++)
                        {
                            if (Convert.ToInt16(iV[n][66 + (j * 3)].get_Value(0)) != 0)
                            {
                                Fila = DtDetalle[n].NewRow();
                                Fila[0] = "Scan";
                                Fila[1] = station.ToString();

                                Fila[46] = iV[n][((66) + (j * 3))].get_Value(0);

                                Fila[73] = Convert.ToString(iV[n][((67) + (j * 3))].get_Value(0));

                                Fila[74] = Convert.ToString(iV[n][((68) + (j * 3))].get_Value(0));

                                DtDetalle[n].Rows.Add(Fila);
                            }
                        }

                    }
                    else if (station == ThisProject.stations[5] || station == ThisProject.stations[6])
                    {
                        //Boolean Values
                        for (int i = 2; i < 30; i++)
                        {
                            Fila[i] = Convert.ToBoolean(iV[n][i + 10].get_Value(0));
                        }
                        DtDetalle[n].Rows.Add(Fila);
                    }
                    else if (station == ThisProject.stations[7])
                    {
                        //Boolean Values
                        for (int i = 2; i < 17; i++)
                        {
                            Fila[i] = Convert.ToBoolean(iV[n][i + 10].get_Value(0));

                        }
                        DtDetalle[n].Rows.Add(Fila);
                        //Punch Values
                        for (int j = 0; j < 6; j++)
                        {
                            if (Convert.ToBoolean(iV[n][j + 13].get_Value(0)))
                            {
                                Fila = DtDetalle[n].NewRow();

                                Fila[0] = "Punch";
                                Fila[1] = station.ToString();

                                for (int i = 46; i < 52; i++)
                                {
                                    Fila[i] = iV[n][((i - 16) + (j * 10))].get_Value(0);
                                }

                                for (int i = 54; i < 58; i++)
                                {
                                    Fila[i] = iV[n][((i - 28) + (j * 10))].get_Value(0);
                                }
                                Fila[58] = ThisProject.names[j + 20].ToString();

                                DtDetalle[n].Rows.Add(Fila);
                            }
                        }
                        //Weld data Values
                        for (int j = 1; j < 13; j++)
                        {
                            if (j < 3)
                            {
                                if (Convert.ToBoolean(iV[n][13].get_Value(0)))
                                {
                                    addWeldData(station, DtDetalle[n], Fila, j, 25, iV[n]);
                                }
                            }
                            else if (j > 2 && j < 5)
                            {
                                if (Convert.ToBoolean(iV[n][14].get_Value(0)))
                                {
                                    addWeldData(station, DtDetalle[n], Fila, j, 25, iV[n]);
                                }
                            }
                            else if (j > 4 && j < 7)
                            {
                                if (Convert.ToBoolean(iV[n][15].get_Value(0)))
                                {
                                    addWeldData(station, DtDetalle[n], Fila, j, 25, iV[n]);
                                }
                            }
                            else if (j > 6 && j < 9)
                            {
                                if (Convert.ToBoolean(iV[n][16].get_Value(0)))
                                {
                                    addWeldData(station, DtDetalle[n], Fila, j, 25, iV[n]);
                                }
                            }
                            else if (j > 8 && j < 11)
                            {
                                if (Convert.ToBoolean(iV[n][17].get_Value(0)))
                                {
                                    addWeldData(station, DtDetalle[n], Fila, j, 25, iV[n]);
                                }
                            }
                            else if (j > 10 && j < 13)
                            {
                                if (Convert.ToBoolean(iV[n][18].get_Value(0)))
                                {
                                    addWeldData(station, DtDetalle[n], Fila, j, 25, iV[n]);
                                }
                            }

                        }
                    }
                    else if (station == ThisProject.stations[8] || station == ThisProject.stations[9] )
                    {
                        //Boolean Values
                        for (int i = 2; i < 46; i++)
                        {
                            Fila[i] = Convert.ToBoolean(iV[n][i + 10].get_Value(0));

                        }
                        Fila[46] = Convert.ToInt32(iV[n][56].get_Value(0));
                        DtDetalle[n].Rows.Add(Fila);
                    }

                    // add data to the row PS

                    FilaPs[1] = station;

                    
                    //Ftime = Convert.ToString(iV[n][5].get_Value(0));

                    IFormatProvider culture = new CultureInfo("en-US", true);
                    Rpta = Convert.ToString(iV[n][4].get_Value(0));
                    FilaPs[2] = DateTime.ParseExact(Rpta, "dd/MM/yyyy HH:mm:ss", culture);
                    Rpta = Convert.ToString(iV[n][5].get_Value(0));
                    FilaPs[3] = DateTime.ParseExact(Rpta, "dd/MM/yyyy HH:mm:ss", culture);

                    // se necesita checar flujo actual y restar con flujo de maquina (posicion)
                    //FilaPs[4] = 10101;

                    //Cycle time
                    FilaPs[5] = Convert.ToDecimal(iV[n][6].get_Value(0));
                    //Convert.ToDecimal(iV[6].get_Value(0));

                    //Obtener estatus de la maquina de una tag directa online
                    FilaPs[6] = 1;


                    //Estatus de Calidad
                    if (Convert.ToBoolean(iV[n][7].get_Value(0))) FilaPs[7] = 16;
                    else if (Convert.ToBoolean(iV[n][8].get_Value(0))) FilaPs[7] = 8;
                    else if (Convert.ToBoolean(iV[n][9].get_Value(0))) FilaPs[7] = 4;
                    else if (Convert.ToBoolean(iV[n][10].get_Value(0))) FilaPs[7] = 2;
                    else if (Convert.ToBoolean(iV[n][11].get_Value(0))) FilaPs[7] = 1;
                    else FilaPs[7] = 0;

                    //Comentario
                    FilaPs[8] = "Auto";

                    //JITSec
                    FilaPs[9] = iV[n][0].get_Value(0);
                    //PKN
                    FilaPs[10] = Int64.Parse(iV[n][1].get_Value(0).ToString());
                    //Version
                    FilaPs[11] = iV[n][2].get_Value(0);
                    //Color;
                    //FilaPs[12] = iV[n][3].get_Value(0);

                    //-----------------------------------------PAINLINEINTEGRATION----------------------------------------------------------------
                    //Color;LabelID;Consecutive
                    string colorstring = Convert.ToString(iV[n][3].get_Value(0));

                    int semicolon1_index = colorstring.IndexOf(';');
                    int semicolon2_index = colorstring.IndexOf(';', semicolon1_index + 1);
            

                    if (semicolon1_index != -1)
                    {
                        //Color
                        FilaPs[12] = colorstring.Substring(0, semicolon1_index);
                        if (semicolon2_index != -1)
                        {
                            //LabelID
                            FilaPs[13] = Convert.ToInt32(colorstring.Substring(semicolon1_index + 1, semicolon2_index - semicolon1_index - 1));
                            
                            //Consecutive
                            FilaPs[14] = Convert.ToInt32(colorstring.Substring(semicolon2_index + 1));
                        }
                        else 
                        {
                            FilaPs[13] = 0;
                            FilaPs[14] = 0;
                        }
                    }
                    else
                    {
                        FilaPs[12] = colorstring;
                        FilaPs[13] = 0;
                        FilaPs[14] = 0;
                    }
                    //---------------------------------------------------------------------------------------------------------

                    DtPs[n].Rows.Add(FilaPs);
                    
                    ThisProject.dtDetalle = DtDetalle;
                    ThisProject.dtPs = DtPs;
                    
                    Rpta = "OK";


                }
                else
                    Rpta = "Tags are offline" + station + " " + iV[n][12].Name.ToString();
                //this.Cel().WriteCelString("Tags are offline" + station);


            }

            catch (Exception ex)
            {
                Rpta = ex.Message;
                throw;
            }

            return Rpta;
        }

        public void addWeldData(string station, DataTable DtDetalle, DataRow Fila, int j, int offsetname, zenOn.IVariable[] iV)
        {
            Fila = DtDetalle.NewRow();

            Fila[0] = "Weld";
            Fila[1] = station.ToString();

            for (int i = 46; i < 53; i++)
            {
                Fila[i] = iV[((i + 33) + (j * 10))].get_Value(0);
            }

            for (int i = 53; i < 54; i++)
            {
                Fila[i] = iV[((i + 25) + (j * 10))].get_Value(0);
            }

            for (int i = 54; i < 56; i++)
            {
                Fila[i] = iV[((i + 22) + (j * 10))].get_Value(0);

            }
            Fila[58] = ThisProject.names[j + offsetname].ToString();

            DtDetalle.Rows.Add(Fila);
        }

        public string tGetIDOrden(Int64 gPKN, int gJITSec, string gEstacion)
        {
           string Rpta = "";

           try
           {
               Rpta = NOrden.GetIDOrden(gPKN, gJITSec, gEstacion);
           }
           catch (Exception ex)
           {
               Rpta = ex.Message;
           }
           return Rpta;
        }

        public string tInsertarOrden(string Version, string Color, int PKN, int JITSec)
        {
           string Rpta = "";

           try
           {
               Rpta = NOrden.InsertarOrden(Version, Color, PKN, JITSec);
           }
           catch (Exception ex)
           {
               Rpta = ex.Message;
           }
           return Rpta;
        }

        public string tinsertProtocolo(Int64 OrderID, DataTable Dt, DataTable Ps)
        {
            string Rpta = "";

            try
            {
                Rpta = NProtocolo.Insertar(OrderID, Ps.Rows[0][1].ToString(), Convert.ToDateTime(Ps.Rows[0][2].ToString()),
                        Convert.ToDateTime(Ps.Rows[0][3].ToString()), //Convert.ToInt32(Ps.Rows[0][4].ToString()),
                        Convert.ToDecimal(Ps.Rows[0][5].ToString()), Convert.ToInt32(Ps.Rows[0][6].ToString()),
                        Convert.ToInt32(Ps.Rows[0][7].ToString()), Ps.Rows[0][8].ToString(),
                        Convert.ToInt32(Ps.Rows[0][9].ToString()), Convert.ToInt32(Ps.Rows[0][10].ToString()),
                        Dt);
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

        public string updateOrders()
        {
            string Rpta = "";

            try
            {
                Rpta = NOrden.UpdateOrders();
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;

        }

        public DataTable updateLastStationsCycles()
        {
            DataTable Tabla = new DataTable();

            try
            {
                Tabla = NvLastStationCycles.Listar();
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string tGetStationEntrance(Int64 gPKN, int gJITSec, string gEstacion)
        {
            string Rpta = "";

            try
            {
                Rpta = NOrden.GetStationEntrance(gPKN, gJITSec, gEstacion);
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            return Rpta;
        }

    }
}
