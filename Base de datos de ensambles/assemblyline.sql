--create skidprotocol and skidprotocol_repl on assemblyline server (it's the same table, only name changes)

CREATE TABLE Skidprotocol_repl(
    ProtID VARCHAR(36) PRIMARY KEY, 
    OrderID VARCHAR(36) NOT NULL,
    SkidID VARCHAR(36) NOT NULL,
    LabelID INT NOT NULL,
    OrderName VARCHAR(15) NOT NULL,
    OrderRef TINYINT NOT NULL,
    Skid_Number TINYINT NOT NULL,
    Skid_Serial_Number TINYINT NOT NULL,
    Position TINYINT NOT NULL,
    TypeID TINYINT NOT NULL,
    TypeCode VARCHAR(6) NOT NULL,
    TypeLab VARCHAR(30) NOT NULL,
    ColorID TINYINT NOT NULL,
    ColorCode VARCHAR(6) NOT NULL,
    ColorLab VARCHAR(20) NOT NULL,
    ProductID SMALLINT NOT NULL,
    ProductLab VARCHAR(30) NOT NULL,
    PrimerID TINYINT NOT NULL,
    PrimerCode VARCHAR(3) NOT NULL,
    PrimerLab VARCHAR(30) NOT NULL,
    ClearID TINYINT NOT NULL,
    ClearCode VARCHAR(3) NOT NULL,
    ClearLab VARCHAR(30) NOT NULL,
    VariantNo TINYINT NOT NULL,
    PitchVar SMALLINT NOT NULL,
    QTY1 SMALLINT NOT NULL,
    QTY2 SMALLINT NOT NULL,
    PartSide1 BIT NOT NULL,
    PartSide2 BIT NOT NULL,
    CO2 BIT NOT NULL,
    Flaming BIT NOT NULL,
    Basecoat BIT NOT NULL,
    SpFlagCO21 BIT NULL,
    SpFlagCO22 BIT NULL,
    SpFlagFL1 BIT NULL,
    SpFlagFL2 BIT NULL,
    SpFlagPR1 BIT NULL,
    SpFlagPR2 BIT NULL,
    SpFlagBC1 BIT NULL,
    SpFlagBC2 BIT NULL, 
    SpFlagBC3 BIT NULL,
    SpFlagBC4 BIT NULL,
    SpFlagBC5 BIT NULL,
    SpFlagBC6 BIT NULL,
    SpFlagCC1 BIT NULL,
    SpFlagCC2 BIT NULL,
    SpFlagCC3 BIT NULL,
    SpFlagCC4 BIT NULL,
    FlagR1 BIT NULL,
    FlagR2 BIT NULL,
    FlagR3 BIT NULL,
    FlagR4 BIT NULL,
    FlagR5 BIT NULL,
    FlagR6 BIT NULL,
    CheckSideA BIT NULL,
    CheckSideB BIT NULL,
    BypassAppl BIT NULL,
    BypassCV BIT NULL,
    BypassOnlChgCO2FL BIT NULL,
    BypassOnlChgPR BIT NULL,
    BypassOnlChgBC BIT NULL,
    BypassOnlChgCC BIT NULL,
    ResinR1 SMALLINT NULL,
    ResinR2 SMALLINT NULL,
    ResinR3 SMALLINT NULL,
    ResinR4 SMALLINT NULL,
    ResinR5 SMALLINT NULL,
    ResinR6 SMALLINT NULL,
    HardenerR1 TINYINT NULL,
    HardenerR2 TINYINT NULL,
    HardenerR3 TINYINT NULL,
    HardenerR4 TINYINT NULL,
    Cleaning_R1 FLOAT NULL,
    Cleaning_R2 FLOAT NULL,
    Cleaning_R3 FLOAT NULL,
    Cleaning_R4 FLOAT NULL,
    Cleaning_R5 FLOAT NULL,
    Cleaning_R6 FLOAT NULL,
    ColorChg_R1 FLOAT NULL,
    ColorChg_R2 FLOAT NULL,
    ColorChg_R3 FLOAT NULL,
    ColorChg_R4 FLOAT NULL,
    ColorChg_R5 FLOAT NULL,
    ColorChg_R6 FLOAT NULL,
    CO2_R1 TINYINT NULL,
    CO2_R2 TINYINT NULL,
    TempBooth FLOAT NULL,
    HumBoothCC FLOAT NULL,
    TempOvenCC FLOAT NULL,
    DateAndTimeIN DATETIME NOT NULL,
    DateAndTimeFbk DATETIME NULL
);

--create trigger to copy insert rows from replication table to persistent table

CREATE TRIGGER repl2skp
ON Skidprotocol_repl
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON; 
    INSERT INTO Skidprotocol
    SELECT ProtID,OrderID,SkidID,LabelID,OrderName,OrderRef,Skid_Number,Skid_Serial_Number,Position,TypeID,TypeCode,TypeLab,ColorID,ColorCode,ColorLab,ProductID,ProductLab,PrimerID,PrimerCode,PrimerLab,ClearID,ClearCode,ClearLab,VariantNo,PitchVar,QTY1,QTY2,PartSide1,PartSide2,CO2,Flaming,Basecoat,SpFlagCO21,SpFlagCO22,SpFlagFL1,SpFlagFL2,SpFlagPR1,SpFlagPR2,SpFlagBC1,SpFlagBC2,SpFlagBC3,SpFlagBC4,SpFlagBC5,SpFlagBC6,SpFlagCC1,SpFlagCC2,SpFlagCC3,SpFlagCC4,FlagR1,FlagR2,FlagR3,FlagR4,FlagR5,FlagR6,CheckSideA,CheckSideB,BypassAppl,BypassCV,BypassOnlChgCO2FL,BypassOnlChgPR,BypassOnlChgBC,BypassOnlChgCC,ResinR1,ResinR2,ResinR3,ResinR4,ResinR5,ResinR6,HardenerR1,HardenerR2,HardenerR3,HardenerR4,Cleaning_R1,Cleaning_R2,Cleaning_R3,Cleaning_R4,Cleaning_R5,Cleaning_R6,ColorChg_R1,ColorChg_R2,ColorChg_R3,ColorChg_R4,ColorChg_R5,ColorChg_R6,CO2_R1,CO2_R2,TempBooth,HumBoothCC,TempOvenCC,DateAndTimeIN,DateAndTimeFbk
    FROM inserted;
END;

--create table for paint traceability from assemblylineserver

CREATE TABLE Painttrack(
    idPainttrack int IDENTITY PRIMARY KEY,
    idProtocolo int FOREIGN KEY REFERENCES Protocolo(idProtocolo),
    LabelID int not null,
    Consecutive int not null,
    Comment varchar(20) null,
);


