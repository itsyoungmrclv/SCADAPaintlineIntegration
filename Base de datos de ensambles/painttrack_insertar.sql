USE [Assemblyline_data]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
-- Procedure PaintTrack_insertar
CREATE PROC [dbo].[PaintTrack_insertar]
@idprotocolotemp int,
@LabelID int,
@Consecutive int,
@Comment varchar(20)
as
begin
    insert into PaintTrack (idProtocolo, LabelID, Consecutive, Comment)
    values (@idprotocolotemp, @LabelID, @Consecutive, @Comment);
end