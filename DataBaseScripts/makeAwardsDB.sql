USE [master]
GO
/****** Object:  Database [AwardsDB]    Script Date: 2/24/2018 23:43:35 ******/
CREATE DATABASE [AwardsDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AwardsDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AwardsDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AwardsDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\AwardsDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [AwardsDB] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AwardsDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AwardsDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AwardsDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AwardsDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AwardsDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AwardsDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [AwardsDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AwardsDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AwardsDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AwardsDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AwardsDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AwardsDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AwardsDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AwardsDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AwardsDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AwardsDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AwardsDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AwardsDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AwardsDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AwardsDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AwardsDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AwardsDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AwardsDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AwardsDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AwardsDB] SET  MULTI_USER 
GO
ALTER DATABASE [AwardsDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AwardsDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AwardsDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AwardsDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AwardsDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AwardsDB] SET QUERY_STORE = OFF
GO
USE [AwardsDB]
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
USE [AwardsDB]
GO
/****** Object:  Table [dbo].[Awards]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Awards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageAwards]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageAwards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Byte] [varbinary](max) NULL,
	[Type] [nvarchar](50) NULL,
	[id_award] [int] NULL,
 CONSTRAINT [PK_ImageAwards] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ImageUsers]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ImageUsers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Byte] [varbinary](max) NULL,
	[Type] [nvarchar](50) NULL,
	[id_user] [int] NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAndAward]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAndAward](
	[id_user] [int] NULL,
	[id_award] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Birthdate] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserAndAward]    Script Date: 2/24/2018 23:43:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_UserAndAward] ON [dbo].[UserAndAward]
(
	[id_user] ASC,
	[id_award] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ImageAwards]  WITH CHECK ADD  CONSTRAINT [FK_ImageAwards_Awards] FOREIGN KEY([id_award])
REFERENCES [dbo].[Awards] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageAwards] CHECK CONSTRAINT [FK_ImageAwards_Awards]
GO
ALTER TABLE [dbo].[ImageUsers]  WITH CHECK ADD  CONSTRAINT [FK_ImageUsers_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ImageUsers] CHECK CONSTRAINT [FK_ImageUsers_Users]
GO
ALTER TABLE [dbo].[UserAndAward]  WITH CHECK ADD  CONSTRAINT [FK_UserAndAward_Awards] FOREIGN KEY([id_award])
REFERENCES [dbo].[Awards] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAndAward] CHECK CONSTRAINT [FK_UserAndAward_Awards]
GO
ALTER TABLE [dbo].[UserAndAward]  WITH CHECK ADD  CONSTRAINT [FK_UserAndAward_Users] FOREIGN KEY([id_user])
REFERENCES [dbo].[Users] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserAndAward] CHECK CONSTRAINT [FK_UserAndAward_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddAward]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAward]
	@Title nvarchar(50),
	@Description nvarchar(250)
AS
BEGIN
	INSERT INTO dbo.Awards (Title,Description) 
	VALUES (@Title, @Description); 
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[AddAwardImage]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddAwardImage] 
	@Name nvarchar(50),
	@Byte varbinary(MAX),
	@Type nvarchar(50),
	@idAward int
AS
BEGIN
	INSERT INTO dbo.ImageAwards (Name,Byte,Type,id_award) 
	VALUES (@Name, @Byte, @Type, @idAward); 
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser] 	
	@Name nvarchar(50),
	@Birthdate datetime
AS
BEGIN
	INSERT INTO dbo.Users (Name,Birthdate) 
	VALUES (@Name, @Birthdate); 
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[AddUserImage]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddUserImage]
	@Name nvarchar(50),
	@Byte varbinary(MAX),
	@Type nvarchar(50),
	@idUser int
AS
BEGIN
	INSERT INTO dbo.ImageUsers (Name,Byte,Type,id_user)
	VALUES (@Name, @Byte, @Type, @idUser); 
	SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[CancelAwardToUser]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CancelAwardToUser]
	@idAward int,
	@idUser int
AS
BEGIN
	DELETE FROM dbo.UserAndAward 
	Where id_award = @idAward AND id_user= @idUser
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteAward]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAward]
	@ID int
AS
BEGIN
	DELETE FROM dbo.Awards Where ID = @ID;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteAwardImage]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteAwardImage] 
 @idAward int
AS
BEGIN
	DELETE FROM dbo.ImageAwards Where dbo.ImageAwards.id_award = @idAward
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
	@ID int
AS
BEGIN
	DELETE FROM dbo.Users 
	Where ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteUserImage]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteUserImage] 
	@idUser int
AS
BEGIN
	DELETE FROM dbo.ImageUsers Where dbo.ImageUsers.id_user = @idUser;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardById]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardById]
	@idAward int
AS
BEGIN
	SELECT TOP 1 a.id, a.title, a.Description 
	FROM dbo.Awards a 
	WHERE a.id =@idAward
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardByLetterName]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardByLetterName]
	@letterName nvarchar(50)
AS
BEGIN
	SELECT a.id, a.title, a.description 
	FROM dbo.Awards a 
	where a.title LIKE @letterName
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardByName]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAwardByName]
	@title nvarchar(50)
AS
BEGIN
	SELECT TOP 1 a.id, a.title, a.description
	FROM dbo.Awards a 
	WHERE a.title =@title
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardByPartName]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardByPartName]
	@partName nvarchar(50)
AS
BEGIN
	SELECT a.id, a.title, a.description 
	FROM dbo.Awards a 
	where a.title LIKE @partName
END

GO
/****** Object:  StoredProcedure [dbo].[GetAwardsByUser]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAwardsByUser]
	@idUser int
AS
BEGIN
	SELECT a.id, a.Title, a.Description 
    FROM dbo.UserAndAward, dbo.Awards a 
    Where dbo.UserAndAward.id_User = @idUser 
    AND dbo.UserAndAward.id_Award = a.ID
END

GO
/****** Object:  StoredProcedure [dbo].[GetFreeAwards]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetFreeAwards]
	@idUser int
AS
BEGIN
	SELECT a.ID, a.Title, a.[Description] FROM dbo.Awards a
    EXCEPT
    (
		SELECT a.ID, a.Title, a.[Description] FROM dbo.Users u
		INNER JOIN  dbo.UserAndAward ua
		ON ua.id_user = u.ID
		INNER JOIN dbo.Awards a
		ON ua.id_award = a.ID
		WHERE u.ID = @idUser
    )
END

GO
/****** Object:  StoredProcedure [dbo].[GetImageByAward]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetImageByAward]
	@idAward int
AS
BEGIN
	SELECT TOP 1 i.ID, i.Name, i.Byte, i.Type, i.id_award 
	FROM dbo.ImageAwards i 
	WHERE i.id_award =@idAward
END

GO
/****** Object:  StoredProcedure [dbo].[GetImageByUser]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetImageByUser]
	@idUser int
AS
BEGIN
	SELECT i.ID, i.Name, i.Byte, i.Type, i.id_user 
	FROM dbo.ImageUsers i 
	WHERE i.id_user =@idUser
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById]
	@idUser int 
AS
BEGIN
	SELECT TOP 1 u.id, u.name, u.Birthdate 
	FROM dbo.Users u 
	WHERE u.id =@idUser
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserByName]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByName]	
	@name nvarchar(50)
AS
BEGIN
	SELECT u.id, u.name, u.Birthdate 
	FROM dbo.Users u 
	WHERE u.name =@name
END

GO
/****** Object:  StoredProcedure [dbo].[GetUsersByLetterName]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsersByLetterName]
	@letterName nvarchar(50)
AS
BEGIN
	SELECT u.id, u.name, u.Birthdate 
	FROM dbo.Users u 
	WHERE u.name LIKE @letterName
END

GO
/****** Object:  StoredProcedure [dbo].[GetUsersByPartName]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUsersByPartName]
	@partNameFirst nvarchar(50),
	@partNameEnd nvarchar(50)
AS
BEGIN
	SELECT u.id, u.name, u.Birthdate 
	FROM dbo.Users u 
	where u.name 
	LIKE @partNameFirst or u.name LIKE @partNameEnd
END

GO
/****** Object:  StoredProcedure [dbo].[SetAwardToUser]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SetAwardToUser] 
	@idUser int,
	@idAward int
AS
BEGIN
	INSERT INTO dbo.UserAndAward (id_user,id_award) VALUES (@idUser, @idAward)
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateAward]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAward]
	@Title nvarchar(50),
	@Description nvarchar(250),
	@ID int 
AS
BEGIN
	UPDATE dbo.Awards SET title=@Title, description =@Description Where ID = @ID
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 2/24/2018 23:43:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@Name nvarchar(50),
	@Birthdate datetime,
	@ID int
AS
BEGIN
	UPDATE dbo.Users 
	SET name=@Name, birthdate=@Birthdate 
	Where ID = @ID;
END

GO
USE [master]
GO
ALTER DATABASE [AwardsDB] SET  READ_WRITE 
GO
