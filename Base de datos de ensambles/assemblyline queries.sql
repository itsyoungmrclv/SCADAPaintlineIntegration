

-- crear vista de la tabla Paintline_OEE.dbo.Skidprotocol en la db Assemblyline_data

CREATE VIEW Skidprotocol
AS
SELECT * FROM Paintline_OEE.dbo.Skidprotocol

--crear tabla PaintTrack

CREATE TABLE PaintTrack(
    idPaintTrack int IDENTITY PRIMARY KEY,
    idProtocolo int FOREIGN KEY REFERENCES Protocolo(idProtocolo),
    LabelID int not null,
    Consecutive int not null,
    Comment varchar(20) null,
);

