USE [master]
GO
/****** Object:  Database [sisteman_TEKUS]    Script Date: 14/11/2018 9:56:20 a. m. ******/
CREATE DATABASE [sisteman_TEKUS] ON  PRIMARY 
( NAME = N'sisteman_TEKUS', FILENAME = N'C:\Program Files (x86)\Parallels\Plesk\Databases\MSSQL\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\sisteman_TEKUS.mdf' , SIZE = 3328KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sisteman_TEKUS_log', FILENAME = N'C:\Program Files (x86)\Parallels\Plesk\Databases\MSSQL\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\sisteman_TEKUS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [sisteman_TEKUS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sisteman_TEKUS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sisteman_TEKUS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET ARITHABORT OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [sisteman_TEKUS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sisteman_TEKUS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sisteman_TEKUS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [sisteman_TEKUS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sisteman_TEKUS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sisteman_TEKUS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sisteman_TEKUS] SET  MULTI_USER 
GO
ALTER DATABASE [sisteman_TEKUS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sisteman_TEKUS] SET DB_CHAINING OFF 
GO
USE [sisteman_TEKUS]
GO
/****** Object:  User [sisteman_siste_snhevs2]    Script Date: 14/11/2018 9:56:21 a. m. ******/
CREATE USER [sisteman_siste_snhevs2] FOR LOGIN [sisteman_siste_snhevs2] WITH DEFAULT_SCHEMA=[sisteman_siste_snhevs2]
GO
/****** Object:  User [sisteman_dario]    Script Date: 14/11/2018 9:56:22 a. m. ******/
CREATE USER [sisteman_dario] FOR LOGIN [sisteman_dario] WITH DEFAULT_SCHEMA=[sisteman_dario]
GO
/****** Object:  User [sisteman_6]    Script Date: 14/11/2018 9:56:22 a. m. ******/
CREATE USER [sisteman_6] FOR LOGIN [sisteman_6] WITH DEFAULT_SCHEMA=[sisteman_6]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [sisteman_siste_snhevs2]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [sisteman_siste_snhevs2]
GO
ALTER ROLE [db_datareader] ADD MEMBER [sisteman_siste_snhevs2]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [sisteman_siste_snhevs2]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [sisteman_dario]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [sisteman_dario]
GO
ALTER ROLE [db_datareader] ADD MEMBER [sisteman_dario]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [sisteman_dario]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [sisteman_6]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [sisteman_6]
GO
ALTER ROLE [db_datareader] ADD MEMBER [sisteman_6]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [sisteman_6]
GO
/****** Object:  Schema [sisteman_6]    Script Date: 14/11/2018 9:56:24 a. m. ******/
CREATE SCHEMA [sisteman_6]
GO
/****** Object:  Schema [sisteman_dario]    Script Date: 14/11/2018 9:56:24 a. m. ******/
CREATE SCHEMA [sisteman_dario]
GO
/****** Object:  Schema [sisteman_siste_snhevs2]    Script Date: 14/11/2018 9:56:24 a. m. ******/
CREATE SCHEMA [sisteman_siste_snhevs2]
GO
/****** Object:  Table [sisteman_dario].[TBL_TEKUS_CLIENTES]    Script Date: 14/11/2018 9:56:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sisteman_dario].[TBL_TEKUS_CLIENTES](
	[ID_CLIENTES] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[NIT] [numeric](18, 0) NULL,
	[NOMBRE] [nvarchar](max) NULL,
	[CORREOE] [nvarchar](max) NULL,
	[ID_PAIS] [numeric](18, 0) NULL,
 CONSTRAINT [PK_TBL_TEKUS_CLIENTES] PRIMARY KEY CLUSTERED 
(
	[ID_CLIENTES] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sisteman_dario].[TBL_TEKUS_PAIS]    Script Date: 14/11/2018 9:56:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sisteman_dario].[TBL_TEKUS_PAIS](
	[ID_PAIS] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](max) NULL,
 CONSTRAINT [PK_TBL_TEKUS_PAIS] PRIMARY KEY CLUSTERED 
(
	[ID_PAIS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [sisteman_dario].[TBL_TEKUS_SERVICIOS]    Script Date: 14/11/2018 9:56:25 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [sisteman_dario].[TBL_TEKUS_SERVICIOS](
	[ID_SERVICIOS] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[NOMBRE] [nvarchar](max) NULL,
	[VPORHORA] [money] NULL,
	[ID_CLIENTE] [numeric](18, 0) NULL,
	[ID_PAIS] [numeric](18, 0) NULL,
 CONSTRAINT [PK_TBL_TEKUS_SERVICIOS] PRIMARY KEY CLUSTERED 
(
	[ID_SERVICIOS] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [sisteman_dario].[TBL_TEKUS_CLIENTES]  WITH CHECK ADD  CONSTRAINT [FK_TBL_TEKUS_CLIENTES_TBL_TEKUS_PAIS] FOREIGN KEY([ID_PAIS])
REFERENCES [sisteman_dario].[TBL_TEKUS_PAIS] ([ID_PAIS])
GO
ALTER TABLE [sisteman_dario].[TBL_TEKUS_CLIENTES] CHECK CONSTRAINT [FK_TBL_TEKUS_CLIENTES_TBL_TEKUS_PAIS]
GO
ALTER TABLE [sisteman_dario].[TBL_TEKUS_SERVICIOS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_TEKUS_SERVICIOS_TBL_TEKUS_PAIS] FOREIGN KEY([ID_PAIS])
REFERENCES [sisteman_dario].[TBL_TEKUS_PAIS] ([ID_PAIS])
GO
ALTER TABLE [sisteman_dario].[TBL_TEKUS_SERVICIOS] CHECK CONSTRAINT [FK_TBL_TEKUS_SERVICIOS_TBL_TEKUS_PAIS]
GO
ALTER TABLE [sisteman_dario].[TBL_TEKUS_SERVICIOS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_TEKUS_SERVICIOS_TBL_TEKUS_SERVICIOS] FOREIGN KEY([ID_CLIENTE])
REFERENCES [sisteman_dario].[TBL_TEKUS_CLIENTES] ([ID_CLIENTES])
GO
ALTER TABLE [sisteman_dario].[TBL_TEKUS_SERVICIOS] CHECK CONSTRAINT [FK_TBL_TEKUS_SERVICIOS_TBL_TEKUS_SERVICIOS]
GO
/****** Object:  StoredProcedure [sisteman_dario].[SP_DATA_DELETE]    Script Date: 14/11/2018 9:56:26 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DARIO CAMPAÑA
-- Create date: 12/11/2018
-- Description:	DATA DELETE
-- =============================================
CREATE PROCEDURE [sisteman_dario].[SP_DATA_DELETE]
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	 
	DELETE sisteman_TEKUS.sisteman_dario.TBL_TEKUS_SERVICIOS
	delete sisteman_TEKUS.sisteman_dario.TBL_TEKUS_CLIENTES
END
GO
USE [master]
GO
ALTER DATABASE [sisteman_TEKUS] SET  READ_WRITE 
GO
