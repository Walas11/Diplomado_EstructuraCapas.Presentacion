SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Sebastian Acero Leon>
-- Create date: <26-03-2024>
-- Description:	<Crud Estudiantes>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[crudEstudiante]
    -- Add the parameters for the stored procedure here
    @param_idOPeracion NUMERIC,
    @param_id NUMERIC = 0,
    @param_nombre nvarchar(100)='',
    @param_telefono  NUMERIC=0,
    @param_direccion  nvarchar(200)='',
    @param_correo  nvarchar(200)=''
AS
BEGIN
    -- CREACION DE USUARIO
    IF @param_idOPeracion = 1
    BEGIN
        INSERT INTO estudiante VALUES (@param_nombre,@param_telefono,@param_direccion,@param_correo);
        SELECT * FROM estudiante WHERE id_estudiante = @@IDENTITY;
    END
       
    -- UPDATE DE USUARIO
    IF @param_idOPeracion = 2
    BEGIN
        UPDATE estudiante SET 
        nombre = @param_nombre, 
        telefono = @param_telefono, 
        direccion = @param_direccion, 
        correo = @param_correo 
        WHERE id_estudiante = @param_id;

        SELECT * FROM estudiante WHERE id_estudiante = @param_id;
    END

    -- DELETE DE USUARIO
    IF @param_idOPeracion = 3
    BEGIN 
        DELETE estudiante WHERE id_estudiante = @param_id;
        SELECT * FROM estudiante;
    END
        
    -- CONSULTA POR ID
    IF @param_idOPeracion = 4
       SELECT * FROM estudiante WHERE id_estudiante = @param_id;

    -- CONSULTA TODO
    IF @param_idOPeracion = 5
       SELECT * FROM estudiante;

    -- Consulta por Correo
    IF @param_idOPeracion = 6
       SELECT * FROM estudiante where correo=@param_correo;
END
GO