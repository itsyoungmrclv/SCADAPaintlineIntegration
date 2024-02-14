using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Security.Permissions;
using Sistema.Datos;
using Sistema.Negocio;
using System.IO;
using System.Globalization;

namespace ProjectAddin
{
    [System.AddIn.AddIn("ThisProject", Version = "1.0", Publisher = "", Description = "")]

    // Set the ControlThread property.
    [SecurityPermissionAttribute(SecurityAction.Deny, ControlThread = true)]

    public partial class ThisProject
    {
        public zenOn.IOnlineVariable[] mOCV = new zenOn.IOnlineVariable[20];
        public zenOn.IOnlineVariable[] myOnlineContainerSKID = new zenOn.IOnlineVariable[20];
        private static DataTable[] DtDetalle;
        private static DataTable[] DtPs;
        public static string[] stations;
        public static string[] names;
        private static zenOn.IVariable[][] iV;
        public zenOn.IVariable[] AR;
        public zenOn.IVariable[] OC;
        public zenOn.IVariable[] ER;
        public zenOn.IVariable[] rND;
        public zenOn.IVariable[] aND;
        public zenOn.IVariable[] LB;
        public zenOn.IVariable[] CS;
        public zenOn.IVariable[] RiP;
        public zenOn.IVariable SDT;
        public zenOn.IVariable[] iSDT;
        public Thread[] ThreadContainerStation;
        private const int stationsLen = 10;
        //Entrance Handshale tags
        public zenOn.IVariable[] EpPKN;
        public zenOn.IVariable[] EpJIT;
        public zenOn.IVariable[] EpSR;
        public zenOn.IVariable[] EpAA;
        public zenOn.IVariable[] EpP;
        public zenOn.IVariable[] EpC;
        public zenOn.IVariable[] EcR;
        public zenOn.IVariable[] EcS;
        public zenOn.IVariable[] EcA;
        public zenOn.IVariable[] EcF;
        public zenOn.IVariable[] EcFC;
        public zenOn.IVariable[] EcAC;

        //Last stations cycles tags
        public zenOn.IVariable[] idEstation;
        public zenOn.IVariable[] DateTimeFdk;
        public zenOn.IVariable[] TiempoCiclo;

        #region Addin-Context
        /// <summary>
        /// This event handler is executed:
        /// -When the addin has been loaded into the host-application.
        /// USAGE:
        /// Use this event to initialize any custom objects.
        /// 
        /// API: This event should not be used to create any API-Objects,
        /// only the handlers for "IProject" should be initialized here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisProject_Startup(object sender, EventArgs e)
        {
                       
            
            try
            {
                //create array de online containers

                //Create online variables
                for (int i = 0; i <= stationsLen; i++)
                {
                    myOnlineContainerSKID[i] = this.OnlineVariables().CreateOnlineVariables("SKID station" + i.ToString());
                }

                //create array of names of the stations
                ReadStationsfromFile("Stations");

                //Crear array of names Punch & Weld Data
                CreateArrayofNames();

                //Inicializate array IVariables
                iV = new zenOn.IVariable[stationsLen][];

                //Inicializate datatables
                DtDetalle = new DataTable[stationsLen];
                DtPs = new DataTable[stationsLen];

                //new station =
                for (int i = 0; i < stationsLen; i++)
                {
                    DtDetalle[i] = CrearTablaDetalle();
                    DtPs[i] = CrearTablaPs();
                }

                //Inicializate Threads cointeiners
                ThreadContainerStation = new Thread[stationsLen];

                //procedure to read tags from a CSV file
                //string station = "2019101";

                //new station =
                for (int i = 0; i < stationsLen; i++)
                {
                    ReadVariablesfromFileToOnlineContainer(stations[i].ToString(), i);

                }

                // inicializate IVariable for handshake Report
                AR = new zenOn.IVariable[stationsLen];
                OC = new zenOn.IVariable[stationsLen];
                ER = new zenOn.IVariable[stationsLen];
                rND = new zenOn.IVariable[stationsLen];
                aND = new zenOn.IVariable[stationsLen];
                LB = new zenOn.IVariable[stationsLen];
                CS = new zenOn.IVariable[stationsLen];
                RiP = new zenOn.IVariable[stationsLen];

                // inicializate IVariable for handshake Entrance
                EpPKN = new zenOn.IVariable[stationsLen];
                EpJIT = new zenOn.IVariable[stationsLen];

                EpSR = new zenOn.IVariable[stationsLen];
                EpAA = new zenOn.IVariable[stationsLen];
                EpP = new zenOn.IVariable[stationsLen];
                EpC = new zenOn.IVariable[stationsLen];
                EcR = new zenOn.IVariable[stationsLen];
                EcS = new zenOn.IVariable[stationsLen];
                EcA = new zenOn.IVariable[stationsLen];
                EcF = new zenOn.IVariable[stationsLen];
                EcFC = new zenOn.IVariable[stationsLen];
                EcAC = new zenOn.IVariable[stationsLen];

                //inicializate IVariable for Last stations cycles
                idEstation = new zenOn.IVariable[stationsLen];
                DateTimeFdk = new zenOn.IVariable[stationsLen];
                TiempoCiclo = new zenOn.IVariable[stationsLen];

                //new station =
                for (int i = 0; i < stationsLen; i++)
                {
                    //IVariable for handshake report for each station
                    AR[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Report.X_Reserve02");
                    ER[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Report.X_Reserve03");
                    OC[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Report.X_Reserve04");
                    rND[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Report.P_NewData");
                    aND[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Report.C_AckNewData");
                    CS[i] = this.Variables().Item(stations[i].ToString() + "!ConnectionStates");
                    RiP[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Report.X_Reserve05");

                    //IVariable for handshake entrance for each station
                    EpPKN[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.P_PKN");
                    EpJIT[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.P_JITSec");

                    EpSR[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.P_startR");
                    EpAA[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.P_AckAut");
                    EpP[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.P_Process");
                    EpC[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.P_Cancel");

                    EcR[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.C_Ready");
                    EcS[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.C_Seeking");
                    EcA[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.C_Authr");
                    EcF[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.C_Fail");
                    EcFC[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.C_FailCode");
                    EcAC[i] = this.Variables().Item(stations[i].ToString() + "!SCADA.Entrance.C_AckCancel");

                    idEstation[i] = this.Variables().Item("vidEstation[" + i + "]");
                    DateTimeFdk[i] = this.Variables().Item("vDateAndTimeFbk[" + i + "]");
                    TiempoCiclo[i] = this.Variables().Item("vTiempoCiclo[" + i + "]"); 

                    if (i == 0 || i == 3 || i == 4 || i == 7)
                    {
                        LB[i] = this.Variables().Item("S" +stations[i].ToString() + "_I_Status");
                    }
                    else
                        LB[i] = this.Variables().Item(stations[i].ToString() + "_I_Status");
                }

                //new station =
                for (int i = 0; i < stationsLen; i++)
                {
                    mOCV[i] = this.OnlineVariables().CreateOnlineVariables("Handshake signals " + stations[i].ToString());
                    if (mOCV[i] == null)
                        mOCV[i] = this.OnlineVariables().CreateOnlineVariables("Handshake signals " + stations[i].ToString());
                    //Handshake signal to report
                    //mOCV[i].Add(stations[i].ToString() + "!SCADA.Report.X_Reserve02");   //almost ready - define online cointenaier
                    //mOCV[i].Add(stations[i].ToString() + "!SCADA.Report.X_Reserve03");   //error to report
                    //mOCV[i].Add(stations[i].ToString() + "!SCADA.Report.X_Reserve04");   //Online cointeiner Defined
                    mOCV[i].Add(stations[i].ToString() + "!SCADA.Report.P_NewData");
                    mOCV[i].Add(stations[i].ToString() + "!SCADA.Entrance.P_startR");

                    mOCV[i].Add(stations[i].ToString() + "!SCADA.Entrance.P_AckAut");

                    //mOCV[i].Add(stations[i].ToString() + "!SCADA.Report.C_AckNewData");
                    //mOCV[i].Add(stations[i].ToString() + "!SCADA.Report.X_Reserve05");  //Report in process
                    //Life bit status
                    //mOCV[i].Add(stations[i].ToString() + "_I_Status");

                    mOCV[i].Define();

                }

                //Create any required API-References here (Event handlers, OnlineContainers, local references,etc. )

                this.Active += new zenOn.ActiveEventHandler(ThisProject_Active);
                this.Inactive += new zenOn.InactiveEventHandler(ThisProject_Inactive);

                mOCV[0].VariableChange += new zenOn.VariableChangeEventHandler(mOCV0_VariableChange);
                mOCV[1].VariableChange += new zenOn.VariableChangeEventHandler(mOCV1_VariableChange);
                mOCV[2].VariableChange += new zenOn.VariableChangeEventHandler(mOCV2_VariableChange);
                mOCV[3].VariableChange += new zenOn.VariableChangeEventHandler(mOCV3_VariableChange);
                mOCV[4].VariableChange += new zenOn.VariableChangeEventHandler(mOCV4_VariableChange);
                mOCV[5].VariableChange += new zenOn.VariableChangeEventHandler(mOCV5_VariableChange);
                mOCV[6].VariableChange += new zenOn.VariableChangeEventHandler(mOCV6_VariableChange);
                mOCV[7].VariableChange += new zenOn.VariableChangeEventHandler(mOCV7_VariableChange);
                mOCV[8].VariableChange += new zenOn.VariableChangeEventHandler(mOCV8_VariableChange);
                mOCV[9].VariableChange += new zenOn.VariableChangeEventHandler(mOCV9_VariableChange);

                Macro_UpdateOrders();

                SDT = this.Variables().Item("System Time");
                iSDT = new zenOn.IVariable[7];
                for (int i = 0; i < 7; i++)
			    {
			        iSDT[i] = this.Variables().Item("SystemDateTime["+i+"]");
			    }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Init fail! : " + ex.Message);
                throw;
            }
        }

        void mOCV0_VariableChange(zenOn.IVariable obVar)
        {
            /*
            try
            {
                //string Rpta = "";
                if (Convert.ToBoolean(LB[0].get_Value(0))== false ) // || CS[0].ToString() == "0:0;")
                {
                    if (Convert.ToBoolean(rND[0].get_Value(0)) && Convert.ToBoolean(RiP[0].get_Value(0)) == false)//&& Convert.ToBoolean(OC[0].get_Value(0)) //Solicitud de reportar Datos con Online Container Definido
                    {
                        RiP[0].set_Value(0, true);
                        ER[0].set_Value(0, false);
                        this.Cel().WriteCelStringEx("Report in progress in " + stations[0].ToString(), stations[0].ToString(), 6, 3, rND[0], 0);
                        string Rpta = "";

                        //Rpta = Report(stations[i].ToString(), i);

                        try
                        {
                            //var myThreadContainer = new ThreadContainer[stationsLen];
                            var myThreadContainer = new ThreadContainer();
                            ThreadContainerStation[0] = new Thread(() => { Rpta = myThreadContainer.tReport(stations[0].ToString(), 0); });
                            ThreadContainerStation[0].Start();
                            ThreadContainerStation[0].Join();

                        }
                        catch (ThreadAbortException e)
                        {
                            this.Cel().WriteCelString("Thread number " + 0 + " abort : " + e.Message);
                            Thread.ResetAbort();
                        }

                        if (Rpta == "OK")
                        {
                            aND[0].set_Value(0, true);
                            this.Cel().WriteCelStringEx("Report in " + stations[0].ToString() + " : " + Rpta, stations[0].ToString(), 6, 3, rND[0], 0);
                            RiP[0].set_Value(0, false);

                        }
                        else
                        {
                            ER[0].set_Value(0, true);
                            this.Cel().WriteCelStringEx("Error report in " + stations[0].ToString() + " : " + Rpta, stations[0].ToString(), 6, 2, rND[0], 0);
                            RiP[0].set_Value(0, false);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //this.Cel().WriteCelString("No se pudo en " + stations[i].ToString() + " : " + ex.Message);
                this.Cel().WriteCelStringEx("Fail in report of " + stations[0].ToString() + " : " + ex.Message, stations[0].ToString(), 6, 2, ex, 0);

                if (Convert.ToBoolean(rND[0].get_Value(0)))
                {
                    //AR[i].set_Value(0, false);
                    ER[0].set_Value(0, true);
                    RiP[0].set_Value(0, false);
                    //OC[i].set_Value(0, false);
                }

                //this.Cel().WriteCelStringEx("No se pudo " + ex.Message, stations[i].ToString(), 6, 4, LB[i], 0);
                //throw;
            }
            if (Convert.ToBoolean(rND[0].get_Value(0)))
            {
                ReportData(0);
            }
            else if (Convert.ToBoolean(EpSR[0].get_Value(0)))
            {
                EntranceData(0);
            }*/

            Handshake(0);
            
        }

        void mOCV1_VariableChange(zenOn.IVariable obVar)
        {
            Handshake(1);
        }


        void mOCV2_VariableChange(zenOn.IVariable obVar)
        {
             Handshake(2);
        }

        void mOCV3_VariableChange(zenOn.IVariable obVar)
        {
            Handshake(3);
        }

        void mOCV4_VariableChange(zenOn.IVariable obVar)
        {
            Handshake(4);
        }

        void mOCV5_VariableChange(zenOn.IVariable obVar)
        {
            Handshake(5);
        }

        void mOCV6_VariableChange(zenOn.IVariable obVar)
        {
            Handshake(6);
        }

        void mOCV7_VariableChange(zenOn.IVariable obVar)
        {
            Handshake(7);
        }

        void mOCV8_VariableChange(zenOn.IVariable obVar)
        {
            Handshake(8);
        }

        void mOCV9_VariableChange(zenOn.IVariable obVar)
        {
            Handshake(9);
        }

        /// <summary>
        /// This event handler is executed:
        /// -When the addin is about to be terminated and unloaded from the host-application.
        /// USAGE:
        /// Use to store any custom-information.
        /// 
        /// API: This event should be used to release existing "IProject" event handlers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThisProject_Shutdown(object sender, EventArgs e)
        {
            this.Active -= new zenOn.ActiveEventHandler(ThisProject_Active);
            this.Inactive -= new zenOn.InactiveEventHandler(ThisProject_Inactive);

            try
            {
                this.mOCV[0].VariableChange -= new zenOn.VariableChangeEventHandler(mOCV0_VariableChange);
                this.mOCV[1].VariableChange -= new zenOn.VariableChangeEventHandler(mOCV1_VariableChange);
                this.mOCV[2].VariableChange -= new zenOn.VariableChangeEventHandler(mOCV2_VariableChange);
                this.mOCV[3].VariableChange -= new zenOn.VariableChangeEventHandler(mOCV3_VariableChange);
                this.mOCV[4].VariableChange -= new zenOn.VariableChangeEventHandler(mOCV4_VariableChange);
                this.mOCV[5].VariableChange -= new zenOn.VariableChangeEventHandler(mOCV5_VariableChange);
                this.mOCV[6].VariableChange -= new zenOn.VariableChangeEventHandler(mOCV6_VariableChange);
                this.mOCV[7].VariableChange -= new zenOn.VariableChangeEventHandler(mOCV7_VariableChange);
                this.mOCV[8].VariableChange -= new zenOn.VariableChangeEventHandler(mOCV8_VariableChange);
                this.mOCV[9].VariableChange -= new zenOn.VariableChangeEventHandler(mOCV9_VariableChange);

                this.OnlineVariables().DeleteOnlineVariables("Handshake signals");
                this.OnlineVariables().DeleteOnlineVariables("myOnlineVariablesSKID");

                //new station =
                for (int i = 0; i < stationsLen; i++)
                {
                    if (myOnlineContainerSKID[i].Define())
                    {
                        Limpiar(i);
                        myOnlineContainerSKID[i].Undefine();
                        mOCV[i].Undefine();
                    }
                    //ThreadContainerStation[i].Abort();
                }
                //Thread.ResetAbort();
     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fail during shutdown : " + ex.Message);
            }
        }
        #endregion
        #region General
        /// <summary>
        /// This function ensures the release and garbage collection of API objects,
        /// and should be called in each scenario where API-Objects are about to be destroyed.
        /// </summary>
        private void FreeObjects()
        {
            //GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        #endregion
        #region Project-Context
        /// <summary>
        /// This event handler is executed:
        /// -When the RT was started and the project has been loaded.
        /// -After a Reload has been executed.
        /// USAGE:
        /// Create any API-Objects/Event handler/etc. in this event.
        /// </summary>
        void ThisProject_Active()
        {

        }


        /// <summary>
        /// This event handler is executed:
        /// -Shortly before the RT is being terminated.
        /// -Shortly before a reload.
        /// And is a notification that all API-Objects are about to be destroyed.
        /// USAGE:
        /// Make sure that ALL API-Objects are released in this handler,
        /// before the Garbage collection is been triggered.
        /// </summary>
        void ThisProject_Inactive()
        {
            //Release all API-References here (Event handlers, OnlineContainers, local references, etc. )
            // << TODO: Add Clean-up code here >>
            //Final release and garbage collection of any API-Objects.
            FreeObjects();
        }
        #region Macros (Add macros in this region)
        #endregion
        #endregion
        #region VSTA generated code (DO NOT MODIFY THIS REGION!)
        private void InternalStartup()
        {
            //(DO NOT modify this event handler!)
            this.Startup += new System.EventHandler(ThisProject_Startup);
            this.Shutdown += new System.EventHandler(ThisProject_Shutdown);
        }
        #endregion

        #region Macros

        public void Macro_TestSQLConnection()
        {
            //SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                zenOn.IVariable CycleTime = this.Variables().Item("2019101!SKID[0].Cycle_time");

                if (CycleTime == null) return;

                if (CycleTime.IsOnline())
                {
                    MessageBox.Show("Is Online Variable, the Tag " + CycleTime.Name + " with Value: " + CycleTime.get_Value(0).ToString());
                }
                else
                {
                    MessageBox.Show("Is not Online the Tag " + CycleTime.Name + " with Value:: " + CycleTime.get_Value(0).ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection FAIL!");
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
        public void Macro_GetLastStationsCycles()
        {
            var myThreadContainer = new ThreadContainer();
            DataTable Tabla = new DataTable();

            try
            {
                Thread myThread = new Thread(() => { Tabla = myThreadContainer.updateLastStationsCycles(); });
                myThread.Start();
                myThread.Join();

                if (Tabla.Rows.Count > 0)
                {
                    for (int i = 0; i < stationsLen; i++)
                    {
                        
                        idEstation[i].set_Value(0, Tabla.Rows[i]["IdEstacion"].ToString());
                        DateTimeFdk[i].set_Value(0, Tabla.Rows[i]["DateAndTimeFbk"].ToString());
                        TiempoCiclo[i].set_Value(0, int.Parse(Tabla.Rows[i]["TiempoCiclo"].ToString()));
                    }
                }

                this.Cel().WriteCelString("Update Last Stations Cycles");
            }
            catch (Exception ex)
            {
                this.Cel().WriteCelString("Fail Update Last Stations Cycles : " + ex.Message);
                throw;
            }
        }

        public void Macro_DefineOC()
        {
            myOnlineContainerSKID[0].Define();


        }

        public void Macro_GetDateAndTime()
        {
            string stringSDT = SDT.get_Value(0).ToString();

            try
            {
                if ((stringSDT != "") && (stringSDT.Length > 18))
                {
                    iSDT[0].set_Value(0, Convert.ToInt16(stringSDT.Substring(6, 4)));
                    iSDT[1].set_Value(0, Convert.ToInt16(stringSDT.Substring(0, 2)));
                    iSDT[2].set_Value(0, Convert.ToInt16(stringSDT.Substring(3, 2)));
                    iSDT[3].set_Value(0, Convert.ToInt16(stringSDT.Substring(11, 2)));
                    iSDT[4].set_Value(0, Convert.ToInt16(stringSDT.Substring(14, 2)));
                    iSDT[5].set_Value(0, Convert.ToInt16(stringSDT.Substring(17, 2)));
                    iSDT[6].set_Value(0, 0);
                }
            }
            catch (Exception ex)
            {
                this.Cel().WriteCelString("Error getting Date and Time : " + ex.Message);
                throw;
            }
    
        }

        public static DataTable[] dtDetalle
        {
            get { return DtDetalle; }
            set { DtDetalle = value; }
        }

        public static DataTable[] dtPs
        {
            get { return DtPs; }
            set { DtPs = value; }
        }

        public static zenOn.IVariable[][] IV
        {
            get { return iV; }
            set { iV = value; }
        }

        public void Macro_UpdateOrders()
        {
            var myThreadContainer = new ThreadContainer();

            try
            {
                Thread myThread = new Thread(() => myThreadContainer.updateOrders());
                myThread.Start();
                myThread.Join();
                this.Cel().WriteCelString("Update Orders from Lyncs View");
            }
            catch (Exception ex)
            {
                this.Cel().WriteCelString("Fail Update Orders : " + ex.Message);
                throw;
            }
        }

        #endregion Macros

        public static DataTable CrearTablaPs()
        {
            DataTable Ps = new DataTable();
            Ps.Clear();
            Ps.Columns.Add("idOrden", System.Type.GetType("System.Int64"));
            Ps.Columns.Add("idEstacion", System.Type.GetType("System.String"));
            Ps.Columns.Add("DateAndTimeIn", System.Type.GetType("System.DateTime"));
            Ps.Columns.Add("DateAndTimeFbk", System.Type.GetType("System.DateTime"));
            Ps.Columns.Add("FlujoActual", System.Type.GetType("System.Int32"));
            Ps.Columns.Add("TiempoCiclo ", System.Type.GetType("System.Decimal"));
            Ps.Columns.Add("EstatusMaquina", System.Type.GetType("System.Int32"));
            Ps.Columns.Add("EstatusCalidad", System.Type.GetType("System.Int32"));
            Ps.Columns.Add("Comentario", System.Type.GetType("System.String"));
            Ps.Columns.Add("JITSec", System.Type.GetType("System.Int32"));
            Ps.Columns.Add("PKN", System.Type.GetType("System.Int64"));
            Ps.Columns.Add("Version", System.Type.GetType("System.String"));
            Ps.Columns.Add("Color", System.Type.GetType("System.String"));
            //-------------------------------PAINLINEINTEGRATION----------------------------------------------
            Ps.Columns.Add("LabelID", System.Type.GetType("System.Int"));
            Ps.Columns.Add("Consecutive", System.Type.GetType("System.Int"));
            //-----------------------------------------------------------------------------

            return Ps;
        }

        public static DataTable CrearTablaDetalle()
        {
            DataTable Detalle = new DataTable();
            Detalle.Clear();
            Detalle.Columns.Add("name", System.Type.GetType("System.String"));
            Detalle.Columns.Add("idEstacion", System.Type.GetType("System.String"));
            Detalle.Columns.Add("flag01", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag02", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag03", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag04", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag05", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag06", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag07", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag08", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag09", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag10", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag11", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag12", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag13", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag14", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag15", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag16", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag17", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag18", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag19", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag20", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag21", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag22", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag23", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag24", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag25", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag26", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag27", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag28", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag29", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag30", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag31", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag32", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag33", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag34", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag35", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag36", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag37", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag38", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag39", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag40", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag41", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag42", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag43", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("flag44", System.Type.GetType("System.Boolean"));
            Detalle.Columns.Add("parameter01", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter02", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter03", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter04", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter05", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter06", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter07", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter08", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter09", System.Type.GetType("System.Decimal"));
            Detalle.Columns.Add("parameter10", System.Type.GetType("System.Decimal"));
            Detalle.Columns.Add("parameter11", System.Type.GetType("System.Decimal"));
            Detalle.Columns.Add("parameter12", System.Type.GetType("System.Decimal"));
            Detalle.Columns.Add("parameter13", System.Type.GetType("System.String"));
            Detalle.Columns.Add("parameter14", System.Type.GetType("System.DateTime"));
            Detalle.Columns.Add("parameter15", System.Type.GetType("System.DateTime"));
            Detalle.Columns.Add("parameter16", System.Type.GetType("System.Decimal"));
            Detalle.Columns.Add("parameter17", System.Type.GetType("System.Decimal"));
            Detalle.Columns.Add("parameter18", System.Type.GetType("System.Decimal"));
            Detalle.Columns.Add("parameter19", System.Type.GetType("System.Decimal"));
            Detalle.Columns.Add("parameter20", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter21", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter22", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter23", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter24", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter25", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter26", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter27", System.Type.GetType("System.Int32"));
            Detalle.Columns.Add("parameter28", System.Type.GetType("System.String"));
            Detalle.Columns.Add("parameter29", System.Type.GetType("System.String"));
            Detalle.Columns.Add("parameter30", System.Type.GetType("System.String"));

            return Detalle;
        }

        public void CreateArrayofNames()
        {
            names = new string[40];
            names[0] = "";
            names[1] = "PLA_LH";
            names[2] = "SMR_LH";
            names[3] = "SMR_RH";
            names[4] = "PLA_RH";
            names[5] = "Camera";
            names[6] = "PLA_LH_son1";
            names[7] = "PLA_LH_son2";
            names[8] = "SMR_LH_son1";
            names[9] = "SMR_LH_son2";
            names[10] = "SMR_LH_son3";
            names[11] = "SMR_LH_son4";
            names[12] = "SMR_LH_son5";
            names[13] = "SMR_RH_son1";
            names[14] = "SMR_RH_son2";
            names[15] = "SMR_RH_son3";
            names[16] = "SMR_RH_son4";
            names[17] = "SMR_RH_son5";
            names[18] = "PLA_RH_son1";
            names[19] = "PLA_RH_son2";
            names[20] = "PLA_LH";
            names[21] = "PDC_LHO";
            names[22] = "PDC_LHI";
            names[23] = "PDC_RHI";
            names[24] = "PDC_RHO";
            names[25] = "PLA_RH";
            names[26] = "PLA_LH_son1";
            names[27] = "PLA_LH_son2";
            names[28] = "PDC_LHO_son1";
            names[29] = "PDC_LHO_son2";
            names[30] = "PDC_LHI_son1";
            names[31] = "PDC_LHI_son2";
            names[32] = "PDC_RHI_son1";
            names[33] = "PDC_RHI_son2";
            names[34] = "PDC_RHO_son1";
            names[35] = "PDC_RHO_son2";
            names[36] = "PLA_RH_son1";
            names[37] = "PLA_RH_son2";
        }

        public void Handshake(int i)
        {
            if (Convert.ToBoolean(rND[i].get_Value(0)))
            {
                ReportData(i);
            } 
            else if (Convert.ToBoolean(EpSR[i].get_Value(0)))
            {
                EntranceData(i);
            }
            else if (Convert.ToBoolean(EpAA[i].get_Value(0)))
            {
                EcA[i].set_Value(0, false);
            }
	
        }

        public void EntranceData(int i)
        {
            try
            {
                if (Convert.ToBoolean(LB[i].get_Value(0)) == false)
                {
                    Int64 iPKN = Int64.Parse(EpPKN[i].get_Value(0).ToString());
                    int iJITSec = int.Parse(EpJIT[i].get_Value(0).ToString());

                    if (Convert.ToBoolean(EpSR[i].get_Value(0)) && Convert.ToBoolean(EpAA[i].get_Value(0)) == false && 
                        Convert.ToBoolean(EpP[i].get_Value(0)) == false && Convert.ToBoolean(EpC[i].get_Value(0)) == false && 
                        iPKN != 0 && iJITSec != -1)
                    {
                        EcS[i].set_Value(0, true);
                        EcF[i].set_Value(0, false);
                        EcFC[i].set_Value(0, 0);
                        EcA[i].set_Value(0, false);

                        this.Cel().WriteCelStringEx("Entrance request in progress at " + stations[i].ToString() + ", PKN : " + EpPKN[i].get_Value(0).ToString()
                                                    + ", JITSec : " + EpJIT[i].get_Value(0).ToString(), stations[i].ToString(), 6, 3, EpSR[i], 0);
                        string ERpta = "";

                        try
                        {
                            var myThreadContainer = new ThreadContainer();
                            ThreadContainerStation[i] = new Thread(() => { ERpta = myThreadContainer.tGetStationEntrance(iPKN, iJITSec, stations[i].ToString()); });
                            ThreadContainerStation[i].Start();
                            ThreadContainerStation[i].Join();
                        }
                        catch (ThreadAbortException e)
                        {
                            this.Cel().WriteCelString("Thread number " + i + " abort : " + e.Message);
                            Thread.ResetAbort();
                        }

                        if (ERpta == "400")
                        {
                            EcS[i].set_Value(0, false);
                            this.Cel().WriteCelStringEx("Entrance Authorization in " + stations[i].ToString() + " : " + ERpta + ". PKN : " + EpPKN[i].get_Value(0).ToString()
                                                    + ", JITSec : " + EpJIT[i].get_Value(0).ToString(), stations[i].ToString(), 6, 3, EpSR[i], 0);
                            EcA[i].set_Value(0, true);
                            EcFC[i].set_Value(0, 0);
                        }
                        else
                        {
                            EcS[i].set_Value(0, false);
                            this.Cel().WriteCelStringEx("Entrance Error in Authorization " + stations[i].ToString() + " : " + ERpta + ". PKN : " + EpPKN[i].get_Value(0).ToString()
                                                    + ", JITSec : " + EpJIT[i].get_Value(0).ToString(), stations[i].ToString(), 6, 2, EpSR[i], 0);
                            EcF[i].set_Value(0, true);
                            EcFC[i].set_Value(0, int.Parse(ERpta.ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.Cel().WriteCelStringEx("Entrance Fail check of " + stations[i].ToString() + " : " + ex.Message, stations[i].ToString(), 6, 2, ex, 0);
                EcF[i].set_Value(0, true);
                EcS[i].set_Value(0, false);
                EcFC[i].set_Value(0, 999);

                /*if (Convert.ToBoolean(rND[i].get_Value(0)))
                {
                    EcF[i].set_Value(0, true);
                    EcS[i].set_Value(0, false);
                    EcFC[i].set_Value(0, 999);
                }*/

            }
        }

        public void ReportData(int i)
        {
            try
            {
                //string Rpta = "";
                if (Convert.ToBoolean(LB[i].get_Value(0)) == false ) // || CS[i].ToString()  == "0:0;")
                    {
                        /*if (iV[i][12].IsOnline() == true)   //Si Online Container esta definido
                        {
                            OC[i].set_Value(0, true);
                            //this.Cel().WriteCelStringEx("Online container of " + stations[i].ToString() + " is Online", stations[i].ToString(), 6, 3, OC[i], 0);
                            //AR[i].set_Value(0, false);  --Signal set from each PLC and reset
                        }*/
                       /*
                        if (Convert.ToBoolean(AR[i].get_Value(0)) && Convert.ToBoolean(OC[i].get_Value(0)) == false) //Solicitud de Definir el Online Container
                        {
                            myOnlineContainerSKID[i].Define();
                            OC[i].set_Value(0, true);
                            this.Cel().WriteCelStringEx("Online container of " + stations[i].ToString() + " was requested and is Online", stations[i].ToString(), 6, 3, OC[i], 0);
                        }*/

                        if (Convert.ToBoolean(rND[i].get_Value(0)) && Convert.ToBoolean(RiP[i].get_Value(0)) == false) // && Convert.ToBoolean(OC[i].get_Value(0)) //Solicitud de reportar Datos con Online Container Definido
                        {
                            RiP[i].set_Value(0, true);
                            ER[i].set_Value(0, false);
                            this.Cel().WriteCelStringEx("Report in progress at " + stations[i].ToString(), stations[i].ToString(), 6, 3, rND[i], 0);
                            string Rpta = "";
                            Limpiar(i);
                            
                            //Rpta = Report(stations[i].ToString(), i);

                            try
                            {
                                //var myThreadContainer = new ThreadContainer[stationsLen];
                                var myThreadContainer = new ThreadContainer();
                                ThreadContainerStation[i] = new Thread(() => { Rpta = myThreadContainer.tReport(stations[i].ToString(), i); });
                                ThreadContainerStation[i].Start();
                                ThreadContainerStation[i].Join();
                            
                            }
                            catch (ThreadAbortException e)
                            {
                                this.Cel().WriteCelString("Thread number " + i + " abort : " + e.Message);
                                Thread.ResetAbort();
                            }


                            //myOnlineContainerSKID[i].Undefine();  -- TEST 210902
                            //OC[i].set_Value(0, false);
                            //this.Cel().WriteCelStringEx("Online container of " + stations[i].ToString() + " is Offline", stations[i].ToString(), 6, 3, OC[i], 0);

                            if (Rpta == "OK")
                            {
                                aND[i].set_Value(0, true);
                                this.Cel().WriteCelStringEx("Report in " + stations[i].ToString() + " : " + Rpta, stations[i].ToString(), 6, 3, rND[i], 0);
                                RiP[i].set_Value(0, false);

                            }
                            else
                            {
                                ER[i].set_Value(0, true);
                                this.Cel().WriteCelStringEx("Error report in " + stations[i].ToString() + " : " + Rpta, stations[i].ToString(), 6, 2, rND[i], 0);
                                RiP[i].set_Value(0, false);
                            }

                        }
                    }
            }
            catch (Exception ex)
            {
                //this.Cel().WriteCelString("No se pudo en " + stations[i].ToString() + " : " + ex.Message);
                this.Cel().WriteCelStringEx("Fail in report of " + stations[i].ToString() + " : " + ex.Message, stations[i].ToString(), 6, 2, ex, 0);

                if (Convert.ToBoolean(rND[i].get_Value(0)))
                {
                    //AR[i].set_Value(0, false);
                    ER[i].set_Value(0, true);
                    RiP[i].set_Value(0, false);
                    //OC[i].set_Value(0, false);
                }

                //this.Cel().WriteCelStringEx("No se pudo " + ex.Message, stations[i].ToString(), 6, 4, LB[i], 0);
                //throw;
            }
        }

        public void ReadVariablesfromFileToOnlineContainer(string station, int number)
        {
            string path = @"C:\Project\data\stations\";
            string[] varLine = new String[2];

            
            iV[number] = new zenOn.IVariable[270];

            try
            {
                string line = string.Empty;
                StreamReader importReader = new StreamReader(path + station + ".csv", System.Text.Encoding.Default);

                int x = 0;
                while ((line = importReader.ReadLine()) != null)
                {
                    varLine = line.Split(new Char[] { ',' });
                    myOnlineContainerSKID[number].Add(station + "!" + varLine[0]);
                    iV[number][x] = this.Variables().Item(station + "!" + varLine[0]);
                    x++;
                }
                importReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Import Variable to Online Container fail : " + ex);
                throw;
            }

        }

        public void ReadStationsfromFile(string file)
        {
            string path = @"C:\Project\data\stations\";
            string[] varLine = new String[2];

            stations = new string[20];

            try
            {
                string line = string.Empty;
                StreamReader importReader = new StreamReader(path + file + ".csv", System.Text.Encoding.Default);
               
                int x = 0;
                while ((line = importReader.ReadLine()) != null)
                {
                    varLine = line.Split(new Char[] { ',' });
                    stations[x] = varLine[0];
                    x++;
                }
                importReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Import Variable to Online Container fail : " + ex);
                throw;
            }
        }

        public string Report(string station, int n)
        {
            String Rpta;
            Rpta = "";

            var myThreadContainer = new ThreadContainer();
            try
            {
                try
                {
                    
                    ThreadContainerStation[n] = new Thread(() => { Rpta = myThreadContainer.tReport(station, n); });
                    ThreadContainerStation[n].Start();
                    ThreadContainerStation[n].Join();
                }
                catch (Exception ex)
                {

                    this.Cel().WriteCelStringEx("Report data Fail : " + ex.Message, station, 6, 4, ex, 0);
                    throw;
                }
            }
            catch (ThreadAbortException e)
            {
                this.Cel().WriteCelString("Thread number " + n + " abort : " + e.Message);
                Thread.ResetAbort();
            }

            return Rpta;
        }

        public void Limpiar(int n)
        {
            DtDetalle[n].Clear();
            DtPs[n].Clear();
           
        }

    }

}
