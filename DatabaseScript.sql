USE [master]
GO
/****** Object:  Database [TigerhallKittens]    Script Date: 04/03/2022 20:50:31 ******/
CREATE DATABASE [TigerhallKittens] ON  PRIMARY 
( NAME = N'TigerhallKittens', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\TigerhallKittens.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TigerhallKittens_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\TigerhallKittens_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TigerhallKittens] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TigerhallKittens].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TigerhallKittens] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [TigerhallKittens] SET ANSI_NULLS OFF
GO
ALTER DATABASE [TigerhallKittens] SET ANSI_PADDING OFF
GO
ALTER DATABASE [TigerhallKittens] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [TigerhallKittens] SET ARITHABORT OFF
GO
ALTER DATABASE [TigerhallKittens] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [TigerhallKittens] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [TigerhallKittens] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [TigerhallKittens] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [TigerhallKittens] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [TigerhallKittens] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [TigerhallKittens] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [TigerhallKittens] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [TigerhallKittens] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [TigerhallKittens] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [TigerhallKittens] SET  DISABLE_BROKER
GO
ALTER DATABASE [TigerhallKittens] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [TigerhallKittens] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [TigerhallKittens] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [TigerhallKittens] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [TigerhallKittens] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [TigerhallKittens] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [TigerhallKittens] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [TigerhallKittens] SET  READ_WRITE
GO
ALTER DATABASE [TigerhallKittens] SET RECOVERY SIMPLE
GO
ALTER DATABASE [TigerhallKittens] SET  MULTI_USER
GO
ALTER DATABASE [TigerhallKittens] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [TigerhallKittens] SET DB_CHAINING OFF
GO
USE [TigerhallKittens]
GO
/****** Object:  Table [dbo].[Tiger]    Script Date: 04/03/2022 20:50:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tiger](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tiger] ON
INSERT [dbo].[Tiger] ([ID], [Name], [DateOfBirth]) VALUES (17, N'Siberian Tiger', CAST(0x0000901A00000000 AS DateTime))
INSERT [dbo].[Tiger] ([ID], [Name], [DateOfBirth]) VALUES (18, N'Asian Tiger', CAST(0x0000918700000000 AS DateTime))
INSERT [dbo].[Tiger] ([ID], [Name], [DateOfBirth]) VALUES (19, N'African Tiger', CAST(0x000092F400000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Tiger] OFF
/****** Object:  Table [dbo].[TigerSighting]    Script Date: 04/03/2022 20:50:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TigerSighting](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TigerId] [int] NULL,
	[Longitude] [float] NULL,
	[Latitude] [float] NULL,
	[LastSeenTimeStamp] [datetime] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TigerSighting] ON
INSERT [dbo].[TigerSighting] ([Id], [TigerId], [Longitude], [Latitude], [LastSeenTimeStamp]) VALUES (13, 17, 100, 1.2, CAST(0x0000AE1000000000 AS DateTime))
INSERT [dbo].[TigerSighting] ([Id], [TigerId], [Longitude], [Latitude], [LastSeenTimeStamp]) VALUES (14, 18, 100, 1.2, CAST(0x0000AE2F00000000 AS DateTime))
INSERT [dbo].[TigerSighting] ([Id], [TigerId], [Longitude], [Latitude], [LastSeenTimeStamp]) VALUES (15, 19, 100, 1.2, CAST(0x0000AE4B00000000 AS DateTime))
INSERT [dbo].[TigerSighting] ([Id], [TigerId], [Longitude], [Latitude], [LastSeenTimeStamp]) VALUES (16, 17, 111, 12, CAST(0x000095CF00000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[TigerSighting] OFF
/****** Object:  View [dbo].[vw_GetAllTigersOrderedBy]    Script Date: 04/03/2022 20:50:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vw_GetAllTigersOrderedBy] AS

SELECT tigerid, 
	(SELECT name FROM Tiger WHERE ID = tigerid) Name,
    (SELECT DateOfBirth FROM Tiger WHERE ID = tigerid) DateOfBirth,
    MAX(lastseentimestamp) AS LastSeenTimeStamp
 FROM TigerSighting  
GROUP BY tigerid --ORDER BY Lastseentimestamp DESC
GO
/****** Object:  StoredProcedure [dbo].[CreateTigerSighting]    Script Date: 04/03/2022 20:50:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateTigerSighting]
@TigerId int,
@Longitude float,
@Latitude float,  
@LastSeenTimeStamp datetime 
AS

SET NOCOUNT ON;

	INSERT INTO TigerSighting 
	VALUES 
	(@TigerId,@Longitude,@Latitude,@LastSeenTimeStamp)
GO
/****** Object:  StoredProcedure [dbo].[CreateTiger]    Script Date: 04/03/2022 20:50:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateTiger]
@Name nvarchar(50),
@DateOfBirth datetime, 
@LastSeenTimeStamp datetime, 
@Latitude float, 
@Longitude float
AS

SET NOCOUNT ON;

	BEGIN TRAN
	
	declare @AddId int;
	INSERT INTO Tiger VALUES (@Name, @DateOfBirth)
	SET @AddId = SCOPE_IDENTITY()
	INSERT INTO TigerSighting VALUES (@AddId,@Longitude,@Latitude,@LastSeenTimeStamp)
	
	COMMIT TRAN
GO;
GO
/****** Object:  ForeignKey [FK__TigerSigh__Tiger__023D5A04]    Script Date: 04/03/2022 20:50:31 ******/
ALTER TABLE [dbo].[TigerSighting]  WITH CHECK ADD FOREIGN KEY([TigerId])
REFERENCES [dbo].[Tiger] ([ID])
GO
