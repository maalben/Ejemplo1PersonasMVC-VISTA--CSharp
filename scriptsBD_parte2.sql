use bdejemplomvc1

CREATE PROC sppersonas_insertar
@cedula INT,
@nombre VARCHAR(50),
@edad TINYINT = NULL
AS
BEGIN
INSERT INTO dbo.tblpersonas 
(cedula, nombre, edad)
VALUES
(@cedula, @nombre, @edad)
END
GO


CREATE PROC sppersonas_eliminar
@cedula INT
AS
BEGIN
DELETE FROM dbo.tblpersonas WHERE
cedula = @cedula
END
GO


CREATE PROC sppersonas_guardarcambios
@cedula INT,
@nombre VARCHAR(50),
@edad TINYINT = NULL
AS
BEGIN
UPDATE dbo.tblpersonas SET 
nombre = @nombre, edad = @edad
WHERE cedula = @cedula
END
GO


