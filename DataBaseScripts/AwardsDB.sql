USE [master]
GO
/****** Object:  Database [Awards]    Script Date: 2/18/2018 17:47:21 ******/
CREATE DATABASE [Awards]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Awards', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Awards.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Awards_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Awards_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Awards] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Awards].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Awards] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Awards] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Awards] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Awards] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Awards] SET ARITHABORT OFF 
GO
ALTER DATABASE [Awards] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Awards] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Awards] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Awards] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Awards] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Awards] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Awards] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Awards] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Awards] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Awards] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Awards] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Awards] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Awards] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Awards] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Awards] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Awards] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Awards] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Awards] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Awards] SET  MULTI_USER 
GO
ALTER DATABASE [Awards] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Awards] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Awards] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Awards] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Awards] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Awards] SET QUERY_STORE = OFF
GO
USE [Awards]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Awards]
GO
/****** Object:  Table [dbo].[Award]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Award](
	[id] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[pictureId] [int] NULL,
 CONSTRAINT [PK_Award_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pictures](
	[id] [int] NOT NULL,
	[data] [varbinary](max) NULL,
	[type] [nvarchar](50) NULL,
 CONSTRAINT [PK_PicturesAwards] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[birthdate] [datetime] NULL,
	[pictureId] [int] NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User-Awards]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User-Awards](
	[userId] [int] NOT NULL,
	[awardId] [int] NOT NULL,
 CONSTRAINT [PK_User-Awards] PRIMARY KEY CLUSTERED 
(
	[userId] ASC,
	[awardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Award] ADD  CONSTRAINT [DF_Award_pictureId]  DEFAULT ((1)) FOR [pictureId]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_pictureId]  DEFAULT ((1)) FOR [pictureId]
GO
ALTER TABLE [dbo].[Award]  WITH CHECK ADD  CONSTRAINT [FK_Award_Pictures] FOREIGN KEY([pictureId])
REFERENCES [dbo].[Pictures] ([id])
GO
ALTER TABLE [dbo].[Award] CHECK CONSTRAINT [FK_Award_Pictures]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Pictures] FOREIGN KEY([pictureId])
REFERENCES [dbo].[Pictures] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Pictures]
GO
ALTER TABLE [dbo].[User-Awards]  WITH CHECK ADD  CONSTRAINT [FK_User-Awards_Award1] FOREIGN KEY([awardId])
REFERENCES [dbo].[Award] ([id])
GO
ALTER TABLE [dbo].[User-Awards] CHECK CONSTRAINT [FK_User-Awards_Award1]
GO
ALTER TABLE [dbo].[User-Awards]  WITH CHECK ADD  CONSTRAINT [FK_User-Awards_User1] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[User-Awards] CHECK CONSTRAINT [FK_User-Awards_User1]
GO
/****** Object:  StoredProcedure [dbo].[addAward]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[addAward]
	-- Add the parameters for the stored procedure here
	@id int,
	@title nvarchar(50),
	@description nvarchar(50),
	@pictureId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Award]
           ([id]
           ,[Title]
           ,[Description]
           ,[pictureId])
     VALUES
           (@id,
		   @title,
		   @description,
		   @pictureId)
END
GO
/****** Object:  StoredProcedure [dbo].[addPicture]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[addPicture]
	-- Add the parameters for the stored procedure here
	@id int,
	@bin varbinary(MAX),
	@type nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[Pictures]
           ([id]
           ,[data]
           ,[type])
     VALUES
           (@id,
		   @bin,
		   @type)
END
GO
/****** Object:  StoredProcedure [dbo].[addUser]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[addUser]
	-- Add the parameters for the stored procedure here
	@id int,
	@name nvarchar(50),
	@birthdate datetime,
	@pictureId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[User]
           ([id]
           ,[name]
           ,[birthdate]
           ,[pictureId])
     VALUES
           (@id,
		   @name,
		   @birthdate,
		   @pictureId)
END
GO
/****** Object:  StoredProcedure [dbo].[addUserAward]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[addUserAward]
	-- Add the parameters for the stored procedure here
	@idUser int,
	@idAward int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF NOT EXISTS (SELECT * FROM [dbo].[User-Awards] WHERE @idAward=awardId AND @idUser=userId)
	INSERT INTO [dbo].[User-Awards]
           ([userId]
           ,[awardId])
     VALUES
           (@idUser,
		   @idAward)
	ELSE RETURN 0
END
GO
/****** Object:  StoredProcedure [dbo].[getAllUsers]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getAllUsers] 

AS
BEGIN
	SELECT [id]
      ,[name]
      ,[birthdate]
  FROM [Awards].[dbo].[User]
END
GO
/****** Object:  StoredProcedure [dbo].[getAwardById]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getAwardById]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [id]
      ,[Title]
      ,[Description]
      ,[pictureId]
  FROM [dbo].[Award] WHERE @id=id
END
GO
/****** Object:  StoredProcedure [dbo].[getUserById]    Script Date: 2/18/2018 17:47:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getUserById]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [id]
      ,[name]
      ,[birthdate]
      ,[pictureId]
  FROM [dbo].[User] WHERE @id=id
END
GO
USE [master]
GO
ALTER DATABASE [Awards] SET  READ_WRITE 
GO
