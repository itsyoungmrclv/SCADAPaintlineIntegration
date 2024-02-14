USE [Assemblyline_data]
GO
/****** Object:  StoredProcedure [dbo].[Protocolo_insertar_detalle]    Script Date: 02/01/2024 17:10:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Procedimiento Insertar detalle 
ALTER proc [dbo].[Protocolo_insertar_detalle]
(
@idOrden bigint,
--@PKN int,
--@JitSec int,
@idEstacion varchar(15),
@DateAndTimeIn datetime,
@DateAndTimeFbk datetime,
--@FlujoActual int,
@TiempoCiclo decimal(6,2),
@EstatusMaquina tinyint,
@EstatusCalidad tinyint,
@Comentario varchar(250),
--------------------------------------------PaintlineIntegration--------------------------------------------------------------------------
@LabelID int,
@Consecutive int,
------------------------------------------------------------------------------------------------------------------------------------------
@detalle PROCESSDATA READONLY
)
as
begin
	/*DECLARE @idOrden bigint = (select top 1 IdOrden from orden o, Secuencia s, Producto p, Estacion e
					where o.IdProducto = p.idProducto 
					and p.idSecuencia = s.idSecuencia
					and s.idLinea = e.idLinea
					and o.PKN = @PKN
					and o.JitSec = @JitSec
					and e.idestacion = @idEstacion)*/
	--DECLARE @name VARCHAR(16) = (select name from @detalle)
	DECLARE @DCTEMP AS BIT;
	DECLARE @Comentario2 varchar(250);
	DECLARE @FlujoActual as int;
	DECLARE @FlujoActualv as varchar(15);
	DECLARE @idprotocolotemp int;
	--DECLARE @id int;
	--DROP TABLE IF EXISTS @table;
	--DECLARE @table table (id int);

	-- Checar doble ciclo y checar flujo actual
	exec protocolo_get_checkdobleciclo @idOrden, @idEstacion, @DCTEMP OUTPUT
	IF @DCTEMP = 1
	begin
		SET @Comentario2 = 'Doble Ciclo'
		SET @FlujoActual = (
			SELECT top 1 FlujoActual FROM Protocolo
			WHERE IdOrden = @idOrden
			AND IdEstacion = @idEstacion
			order by DateAndTimeIn
			)
	end
	ELSE
	begin
		SET @Comentario2 = @Comentario
		exec secuencia_get_SecuenciaActual @idOrden,  @idEstacion, @FlujoActualv OUTPUT
		SET @FlujoActual = CAST(@FlujoActualv as int)
	end


	insert into Protocolo (IdOrden,IdEstacion, DateAndTimeIn, DateAndTimeFbk, FlujoActual,TiempoCiclo,EstatusMaquina,EstatusCalidad,Comentario)
	--Output Inserted.IdProtocolo into @table
	values (@idOrden,@idEstacion,@DateAndTimeIn,@DateAndTimeFbk,@FlujoActual,@TiempoCiclo,@EstatusMaquina,@EstatusCalidad,@Comentario2);
	
	set @idprotocolotemp = @@IDENTITY;
	--set valeu = (SELECT id from @table)

	--------------------------------------------agregado para proyecto PaintlineIntegration---------------------------------------------------
	IF @LabelID IS NOT NULL AND @Consecutive IS NOT NULL
		EXEC PaintTrack_insertar @idprotocolotemp, @LabelID, @Consecutive, "Auto";
	------------------------------------------------------------------------------------------------------------------------------------------

		if @FlujoActual = 0
		exec orden_actualizar_Estatus @idOrden, 4
	else
		exec orden_actualizar_Estatus @idOrden, 3
	
	if  @idEstacion = 'S10921M'
			insert into TPL_S10921M (idProtocolo, idEstacion, F_UpperFasciaSelected, F_SpoilerSelected, F_UpperChromeSelected,
			F_MiddleReflectorSelected, F_ExhaustPipeFinisherSelected, F_DiffuserSelected, F_TecBracketSelected, F_LHOutReflectorSelected,
			F_LHInnReflectorSelected, F_RHOutReflectorSelected, F_RHInnReflectorSelected, F_UpperFasciaScanned, F_SpoilerScanned,
			F_ColorScanned, Fk_UpperFasciaSelected, Fk_SpoilerSelected, Fk_UpperChromeSelected, Fk_MiddleReflectorSelected,
			Fk_ExhaustPipeFinisherSelected, Fk_DiffuserSelected, Fk_TecBracketSelected, Fk_LHOutReflectorSelected, Fk_LHInnReflectorSelected,
			Fk_RHOutReflectorSelected, Fk_RHInnReflectorSelected, Fk_UpperFasciaScanned, Fk_SpoilerScanned, Fk_ColorScanned)
			Select @idprotocolotemp, @idEstacion, d.flag01, d.flag02, d.flag03, d.flag04, d.flag05, d.flag06, d.flag07, d.flag08, 
			d.flag09, d.flag10, d.flag11, d.flag12, d.flag13, d.flag14, d.flag15, d.flag16, d.flag17, d.flag18, d.flag19, d.flag20, 
			d.flag21, d.flag22, d.flag23, d.flag24, d.flag25, d.flag26, d.flag27, d.flag28
			from  @detalle d where d.name = 'S10921M'
	else if @idEstacion = 'S10920M'
			insert into TPL_S10920M (idProtocolo, idEstacion, F_UpperFasciaSelected, F_LowerFasciaSelected, F_LHLateralCoverSelected, 
			F_RHLateralCoverSelected, F_LHLateralFinisherSelected, F_RHLateralFinisherSelected, F_UnderRideSelected, F_TecBracketSelected,
			F_TopLineTrimSelected, F_MiddleTrimSelected, F_TechInfSelected, F_LowerFasciaScanned, F_LHLateralCoverScanned, 
			F_RHLateralCoverScanned, F_ColorScanned, F_MiddleTrimScanned, F_LHLateralFinisherPTL, F_RHLateralFinisherPTL, F_TecBracketPTL, 
			F_TechInfPTL, Fk_UpperFasciaSelected, Fk_LowerFasciaSelected, Fk_LHLateralCoverSelected, Fk_RHLateralCoverSelected, 
			Fk_LHLateralFinisherSelected, Fk_RHLateralFinisherSelected, Fk_UnderRideSelected, Fk_TecBracketSelected, Fk_TopLineTrimSelected, 
			Fk_MiddleTrimSelected, Fk_TechInfSelected, Fk_LowerFasciaScanned, Fk_LHLateralCoverScanned, Fk_RHLateralCoverScanned, 
			Fk_ColorScanned, Fk_MiddleTrimScanned, Fk_LHLateralFinisherPTL, Fk_RHLateralFinisherPTL, Fk_TecBracketPTL, Fk_TechInfPTL)
			Select @idprotocolotemp, @idEstacion,  d.flag01, d.flag02, d.flag03, d.flag04, d.flag05, d.flag06, d.flag07, d.flag08, 
			d.flag09, d.flag10, d.flag11, d.flag12, d.flag13, d.flag14, d.flag15, d.flag16, d.flag17, d.flag18, d.flag19, d.flag20, 
			d.flag21, d.flag22, d.flag23, d.flag24, d.flag25, d.flag26, d.flag27, d.flag28, d.flag29, d.flag30, d.flag31, d.flag32,
			d.flag33, d.flag34, d.flag35, d.flag36, d.flag37, d.flag38, d.flag39, d.flag40
			from @detalle d where d.name = 'S10920M'
	else if @idEstacion = 'S10922M'
			insert into TPL_S10922M (idProtocolo, idEstacion, F_AssemblyFasciaSelected, F_PLASensorSelected, F_PDCSensorSelected, 
			F_LHDampingSelected, F_RHDampingSelected, F_UNutSelected, F_VIPSensorSelected, F_HernessSelected, F_AssemblyFasciaScanned, 
			F_HernessScanned, F_ColorScanned, F_PLASensorPTL, F_PDCSensorPTL, F_VIPSensorPTL, F_HernessPTL, F_PLASensorETest, 
			F_PDCSensorETest, F_VIPSensorETest, F_LHDampingCamInsp, F_RHDampingCamInsp, F_VIPSensorCamInsp, F_VIPSensorWetOut, 
			Fk_AssemblyFasciaSelected, 	Fk_PLASensorSelected, Fk_PDCSensorSelected, Fk_LHDampingSelected, Fk_RHDampingSelected,
			Fk_UNutSelected, Fk_VIPSensorSelected, Fk_HernessSelected, Fk_AssemblyFasciaScanned, Fk_HernessScanned, Fk_ColorScanned, 
			Fk_PLASensorPTL, Fk_PDCSensorPTL, Fk_VIPSensorPTL, Fk_HernessPTL, Fk_PLASensorETest, Fk_PDCSensorETest, Fk_VIPSensorETest, 
			Fk_LHDampingCamInsp, Fk_RHDampingCamInsp, Fk_VIPSensorCamInsp, Fk_VIPSensorWetOut, P_WetOut_Test)
			Select @idprotocolotemp, @idEstacion,  d.flag01, d.flag02, d.flag03, d.flag04, d.flag05, d.flag06, d.flag07, d.flag08, 
			d.flag09, d.flag10, d.flag11, d.flag12, d.flag13, d.flag14, d.flag15, d.flag16, d.flag17, d.flag18, d.flag19, d.flag20, 
			d.flag21, d.flag22, d.flag23, d.flag24, d.flag25, d.flag26, d.flag27, d.flag28, d.flag29, d.flag30, d.flag31, d.flag32,
			d.flag33, d.flag34, d.flag35, d.flag36, d.flag37, d.flag38, d.flag39, d.flag40, d.flag41, d.flag42, d.flag43, d.flag44,
			parameter01
			from @detalle d where d.name = 'S10922M'
	else if @idEstacion = 'X10376'
			insert into TPL_X10376 (idProtocolo, idEstacion, F_AssemblyFasciaSelected, F_PLASensorSelected, F_PDCSensorSelected, 
			F_LHDampingSelected, F_RHDampingSelected, F_UNutSelected, F_VIPSensorSelected, F_HernessSelected, F_AssemblyFasciaScanned, 
			F_HernessScanned, F_ColorScanned, F_PLASensorPTL, F_PDCSensorPTL, F_VIPSensorPTL, F_HernessPTL, F_PLASensorETest, 
			F_PDCSensorETest, F_VIPSensorETest, F_LHDampingCamInsp, F_RHDampingCamInsp, F_VIPSensorCamInsp, F_VIPSensorWetOut, 
			Fk_AssemblyFasciaSelected, 	Fk_PLASensorSelected, Fk_PDCSensorSelected, Fk_LHDampingSelected, Fk_RHDampingSelected,
			Fk_UNutSelected, Fk_VIPSensorSelected, Fk_HernessSelected, Fk_AssemblyFasciaScanned, Fk_HernessScanned, Fk_ColorScanned, 
			Fk_PLASensorPTL, Fk_PDCSensorPTL, Fk_VIPSensorPTL, Fk_HernessPTL, Fk_PLASensorETest, Fk_PDCSensorETest, Fk_VIPSensorETest, 
			Fk_LHDampingCamInsp, Fk_RHDampingCamInsp, Fk_VIPSensorCamInsp, Fk_VIPSensorWetOut, P_WetOut_Test)
			Select @idprotocolotemp, @idEstacion,  d.flag01, d.flag02, d.flag03, d.flag04, d.flag05, d.flag06, d.flag07, d.flag08, 
			d.flag09, d.flag10, d.flag11, d.flag12, d.flag13, d.flag14, d.flag15, d.flag16, d.flag17, d.flag18, d.flag19, d.flag20, 
			d.flag21, d.flag22, d.flag23, d.flag24, d.flag25, d.flag26, d.flag27, d.flag28, d.flag29, d.flag30, d.flag31, d.flag32,
			d.flag33, d.flag34, d.flag35, d.flag36, d.flag37, d.flag38, d.flag39, d.flag40, d.flag41, d.flag42, d.flag43, d.flag44,
			parameter01
			from @detalle d where d.name = 'X10376'
	else if @idEstacion = 'S10923M'
			insert into TPL_S10923M (idProtocolo, idEstacion, F_UpperFasciaSelected, F_LowerFasciaSelected, F_LateralCoverLHSelected, 
			F_LateralCoverRHSelected, F_LateralTrimLHSelected, F_LateralTrimRHSelected, F_ChromeStripSelected, F_CenterStripSelected, 
			F_TrimLowerSelected, F_TecBracketSelected, F_TechInfSelected, F_PushPinsSelected, F_ColorScanned, F_TecBracketPTL, 
			F_TechInfPTL, Fk_UpperFasciaSelected, Fk_LowerFasciaSelected, Fk_LateralCoverLHSelected, Fk_LateralCoverRHSelected, 
			Fk_LateralTrimLHSelected, Fk_LateralTrimRHSelected, Fk_ChromeStripSelected, Fk_CenterStripSelected, Fk_TrimLowerSelected, 
			Fk_TecBracketSelected, Fk_TechInfSelected, Fk_PushPinsSelected, Fk_ColorScanned, Fk_TecBracketPTL, Fk_TechInfPTL)
			Select @idprotocolotemp, @idEstacion,  d.flag01, d.flag02, d.flag03, d.flag04, d.flag05, d.flag06, d.flag07, d.flag08, 
			d.flag09, d.flag10, d.flag11, d.flag12, d.flag13, d.flag14, d.flag15, d.flag16, d.flag17, d.flag18, d.flag19, d.flag20, 
			d.flag21, d.flag22, d.flag23, d.flag24, d.flag25, d.flag26, d.flag27, d.flag28, d.flag29, d.flag30
			from @detalle d where d.name = 'S10923M'
	else if @idEstacion = 'S10924M'
			insert into TPL_S10924M (idProtocolo, idEstacion, F_UpperFasciaSelected, F_LowerFasciaSelected, F_OutterLHReflectorSelected, 
			F_InnerLHReflectorSelected, F_OutterRHReflectorSelected, F_InnerRHReflectorSelected, F_UpperChromeBlackSelected, 
			F_TecBracketSelected, F_CenterCoverSelected, F_ExhaustPipSelected, F_MiddleReflectorSelected, F_DiffuserSelected, 
			F_UpperFasciaScanned, F_ColorScanned, Fk_UpperFasciaSelected, Fk_LowerFasciaSelected, Fk_OutterLHReflectorSelected, 
			Fk_InnerLHReflectorSelected, Fk_OutterRHReflectorSelected, Fk_InnerRHReflectorSelected, Fk_UpperChromeBlackSelected, 
			Fk_TecBracketSelected, Fk_CenterCoverSelected, Fk_ExhaustPipSelected, Fk_MiddleReflectorSelected, Fk_DiffuserSelected, 
			Fk_UpperFasciaScanned, Fk_ColorScanned)
			Select @idprotocolotemp, @idEstacion,  d.flag01, d.flag02, d.flag03, d.flag04, d.flag05, d.flag06, d.flag07, d.flag08, 
			d.flag09, d.flag10, d.flag11, d.flag12, d.flag13, d.flag14, d.flag15, d.flag16, d.flag17, d.flag18, d.flag19, d.flag20, 
			d.flag21, d.flag22, d.flag23, d.flag24, d.flag25, d.flag26, d.flag27, d.flag28
			from @detalle d where d.name = 'S10924M'
	else if @idEstacion = '2019101'
			insert into TPL_S2019101 (idProtocolo, idEstacion, F_ScanBumper, F_ScanColor, F_PunchWeldPLALH, F_PunchWeldSMRLH,
			F_PunchWeldSMRRH, F_PunchWeldPLARH, F_PunchGlueCamera, Fk_ScanBumper, Fk_ScanColor, Fk_PunchWeldPLALH, Fk_PunchWeldSMRLH,
			Fk_PunchWeldSMRRH, Fk_PunchWeldPLARH, Fk_PunchGlueCamera, P_CameraGlueTime, P_CameraGluePressure)
			Select @idprotocolotemp, @idEstacion,  d.flag01, d.flag02, d.flag03, d.flag04, d.flag05, d.flag06, d.flag07, d.flag08, 
			d.flag09, d.flag10, d.flag11, d.flag12, d.flag13, d.flag14, parameter01, parameter02
			from @detalle d where d.name = '2019101'
	else if @idEstacion = '2019103'
			insert into TPL_S2019103 (idProtocolo, idEstacion, F_ScanBumper, F_PunchWeldPLALH, F_PunchWeldPDCLHO, 
			F_PunchWeldPDCLHI, F_PunchWeldPDCRHI, F_PunchWeldPDCRHO, F_PunchWeldPLARH, Fk_ScanBumper, Fk_PunchWeldPLALH,
			Fk_PunchWeldPDCLHO, Fk_PunchWeldPDCLHI, Fk_PunchWeldPDCRHI, Fk_PunchWeldPDCRHO, Fk_PunchWeldPLARH)
			Select @idprotocolotemp, @idEstacion, d.flag01, d.flag02, d.flag03, d.flag04, d.flag05, d.flag06, d.flag07, d.flag08, 
			d.flag09, d.flag10, d.flag11, d.flag12, d.flag13, d.flag14
			from @detalle d where d.name = '2019103'
	else if @idEstacion = '2019149'
			insert into TPL_S2019149 (idProtocolo, idEstacion, F_BumperScan, F_Picktolightsensors, F_LPtypeECE, F_LPtypeCameraSAM, 
			F_LPtypeCameraECE, F_LPtypeCameraSWI, F_LPtypeECEwithNAV, F_LPtypeSAM, F_LPtypeSAMwithAV, F_LPtypeSchweizWithAV,
			F_LPtypePATaiwan, F_LPtypeRLineTaiwan, F_Glue, Fk_BumperScan, Fk_Picktolightsensors, Fk_LPtypeECE, Fk_LPtypeCameraSAM,
			Fk_LPtypeCameraECE, Fk_LPtypeCameraSWI, Fk_LPtypeECEwithNAV, Fk_LPtypeSAM, Fk_LPtypeSAMwithAV, Fk_LPtypeSchweizWithAV, 
			Fk_LPtypePATaiwan, Fk_LPtypeRLineTaiwan, Fk_Glue, P_GluePressure,	P_GlueTime, P_LicensePlateScan)
			Select @idprotocolotemp, @idEstacion,  d.flag01, d.flag02, d.flag03, d.flag04, d.flag05, d.flag06, d.flag07, d.flag08, 
			d.flag09, d.flag10, d.flag11, d.flag12, d.flag13, d.flag14, d.flag15, d.flag16, d.flag17, d.flag18, d.flag19, d.flag20, 
			d.flag21, d.flag22, d.flag23, d.flag24, d.flag25, d.flag26, CONVERT(DECIMAL(8,2), d.parameter09),
			CONVERT(DECIMAL(4,2), d.parameter10), CONVERT(varchar(16), d.parameter13)
			from @detalle d where d.name = '2019149'

	else if (@idEstacion = 'ASCLT01' or @idEstacion = 'ASCLT02' or @idEstacion = 'SPUEW0075')
			insert into TPL_PCClient(idProtocolo, idEstacion, idUsuario, Nombre, Cancelacion, FechaYHoraCan, Modifacion,
			FechaYHoraMod, OriginalPKN, NuevoPKN)
			Select @idprotocolotemp,  @idEstacion, CONVERT(tinyint, parameter01), CONVERT(varchar(16), parameter13), d.flag01, d.parameter14,
			d.flag02, d.parameter15, d.parameter02, d.parameter03
			from @detalle d
	
	else if @idEstacion = '4160273'
			insert into TPL_4160273 (idProtocolo, IdEstacion, F_Etest, F_EtestAllVersion, F_Clipping, Fk_Etest, Fk_EtestAllVersion,
			Fk_Clipping, LoadScrapped, Sta1Scrapped, Sta2Scrapped, Sta3Scrapped, Sta4Scrapped,
			Sta1ACycleTime, Sta1BCycleTime, Sta2ACycleTime, Sta2BCycleTime, Sta3ACycleTime, Sta3BCycleTime, Sta4aCycleTime,
			Sta4BCycleTime, EtestVAPLA1, EtestVAPLA2, EtestVAPDC1, EtestVAPDC2, EtestVAPDC3, EtestVAPDC4, EtestVACAM, idEtest,
			ClippingCountEvent)
			Select @idprotocolotemp, @idEstacion, d.flag01, d.flag02, d.flag03, d.flag04, d.flag05, d.flag06, d.flag07, d.flag08,
			d.flag09, d.flag10, d.flag11, d.parameter01, d.parameter02, d.parameter03, d.parameter04, d.parameter05,
			d.parameter06, d.parameter07, d.parameter08, CONVERT(decimal(6,3), d.parameter09),	CONVERT(decimal(6,3), d.parameter10),
			CONVERT(decimal(6,3), d.parameter11), CONVERT(decimal(6,3), d.parameter12),	CONVERT(decimal(6,3), d.parameter16),
			CONVERT(decimal(6,3), d.parameter17), CONVERT(decimal(6,3), d.parameter18),	d.parameter20, d.parameter21
			from @detalle d where d.name = '4160273'
	
	insert into TPL_PunchData (idProtocolo, idEstacion, name, P_PunchSpeed, P_PunchDepth, P_RadiusSpeed,
	P_RadiusDepth, P_RadiusHoldTime, P_WeldTime, P_Energy, P_Amplitude, P_Frequency, P_MaxPower)
	Select @idprotocolotemp, @idEstacion, CONVERT(varchar(16), d.parameter13), CONVERT(decimal(5,1), d.parameter09),
	CONVERT(decimal(5,1), d.parameter10), CONVERT(decimal(5,1), d.parameter11), 
	CONVERT(decimal(5,1), d.parameter12), d.parameter01, d.parameter02, d.parameter03, d.parameter04,
	d.parameter05, d.parameter06 
	from @detalle d where d.name = 'Punch'

	insert into TPL_WeldData (idProtocolo, idEstacion, name, P_Setpoint, P_Reached, P_Pressure, P_CoolingTime,
	P_AfterCoolTime, P_WeldTime, P_Energy, P_Amplitude, P_Frequency, P_MaxPower)
	Select @idprotocolotemp, @idEstacion, CONVERT(varchar(16), d.parameter13), CONVERT(decimal(5,2), d.parameter09),
	CONVERT(decimal(10,8), d.parameter10), d.parameter08, d.parameter01, d.parameter02,
	d.parameter03, d.parameter04, d.parameter05, d.parameter06,  d.parameter07
	from @detalle d where d.name = 'Weld'

	insert into TPL_TorqueData (idProtocolo, idEstacion, name, idSTA, NumTrq, NumTrqOK)
	Select @idprotocolotemp, @idEstacion, CONVERT(varchar(16), d.parameter13), d.parameter01, d.parameter02,
	d.parameter03
	from @detalle d where d.name = 'Torque'

	insert into TPL_ScanData (idProtocolo, idEstacion, name, idSTA, StringScan, StringStep)
	Select @idprotocolotemp, @idEstacion, CONVERT(varchar(16), d.name), d.parameter01,  CONVERT(varchar(15), d.parameter28),
	CONVERT(varchar(64), d.parameter29)
	from @detalle d where d.name = 'Scan'


end