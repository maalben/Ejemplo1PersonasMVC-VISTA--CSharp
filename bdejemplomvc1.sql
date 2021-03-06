USE [master]
GO
CREATE DATABASE [bdejemplomvc1] ON  PRIMARY 
( NAME = N'bdejemplomvc1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\bdejemplomvc1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bdejemplomvc1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\bdejemplomvc1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bdejemplomvc1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bdejemplomvc1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET ARITHABORT OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [bdejemplomvc1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bdejemplomvc1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bdejemplomvc1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [bdejemplomvc1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bdejemplomvc1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bdejemplomvc1] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [bdejemplomvc1] SET  MULTI_USER 
GO
ALTER DATABASE [bdejemplomvc1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bdejemplomvc1] SET DB_CHAINING OFF 
GO
USE [bdejemplomvc1]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [tblpersonas](
	[cedula] [int] NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[edad] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [tblpersonas] ([cedula], [nombre], [edad]) VALUES (123, N'El Chavo', 8)
INSERT [tblpersonas] ([cedula], [nombre], [edad]) VALUES (456, N'Don Ramón', 43)
INSERT [tblpersonas] ([cedula], [nombre], [edad]) VALUES (9876543, N'Fulano de los ángeles', 25)
INSERT [tblpersonas] ([cedula], [nombre], [edad]) VALUES (22222222, N'Viviana López', 18)
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [sppersonas_eliminar]
@cedula INT
AS
BEGIN
DELETE FROM dbo.tblpersonas WHERE
cedula = @cedula
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [sppersonas_guardarcambios]
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [sppersonas_insertar]
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [sppersonas_listar]
AS
BEGIN
	SELECT * FROM dbo.tblpersonas
END
GO
USE [master]
GO
ALTER DATABASE [bdejemplomvc1] SET  READ_WRITE 
GO
