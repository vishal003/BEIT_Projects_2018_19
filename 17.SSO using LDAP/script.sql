USE [master]
GO
/****** Object:  Database [sso]    Script Date: 21-02-2019 17:36:04 ******/
CREATE DATABASE [sso]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'sso', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\sso.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'sso_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\sso_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [sso] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [sso].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [sso] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [sso] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [sso] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [sso] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [sso] SET ARITHABORT OFF 
GO
ALTER DATABASE [sso] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [sso] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [sso] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [sso] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [sso] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [sso] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [sso] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [sso] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [sso] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [sso] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [sso] SET  DISABLE_BROKER 
GO
ALTER DATABASE [sso] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [sso] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [sso] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [sso] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [sso] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [sso] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [sso] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [sso] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [sso] SET  MULTI_USER 
GO
ALTER DATABASE [sso] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [sso] SET DB_CHAINING OFF 
GO
ALTER DATABASE [sso] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [sso] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [sso]
GO
/****** Object:  Table [dbo].[admin_master]    Script Date: 21-02-2019 17:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[admin_master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[branch_master]    Script Date: 21-02-2019 17:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[branch_master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Branch] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[semester_master]    Script Date: 21-02-2019 17:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[semester_master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Semester] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[student_master]    Script Date: 21-02-2019 17:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[student_master](
	[Id] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Branch] [varchar](50) NULL,
	[Semester] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[admin_master] ON 

INSERT [dbo].[admin_master] ([Id], [Username], [Password]) VALUES (CAST(1 AS Numeric(18, 0)), N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[admin_master] OFF
SET IDENTITY_INSERT [dbo].[branch_master] ON 

INSERT [dbo].[branch_master] ([Id], [Branch]) VALUES (CAST(1 AS Numeric(18, 0)), N'IT')
INSERT [dbo].[branch_master] ([Id], [Branch]) VALUES (CAST(2 AS Numeric(18, 0)), N'COMP')
SET IDENTITY_INSERT [dbo].[branch_master] OFF
SET IDENTITY_INSERT [dbo].[semester_master] ON 

INSERT [dbo].[semester_master] ([Id], [Semester]) VALUES (CAST(1 AS Numeric(18, 0)), N'Sem1')
INSERT [dbo].[semester_master] ([Id], [Semester]) VALUES (CAST(2 AS Numeric(18, 0)), N'Sem2')
INSERT [dbo].[semester_master] ([Id], [Semester]) VALUES (CAST(3 AS Numeric(18, 0)), N'Sem3')
INSERT [dbo].[semester_master] ([Id], [Semester]) VALUES (CAST(4 AS Numeric(18, 0)), N'Sem4')
SET IDENTITY_INSERT [dbo].[semester_master] OFF
SET IDENTITY_INSERT [dbo].[student_master] ON 

INSERT [dbo].[student_master] ([Id], [Name], [Branch], [Semester], [Email], [Password]) VALUES (CAST(1 AS Numeric(18, 0)), N'test', N'IT', N'Sem1', N'test@gmail.com', N'pBckp1')
INSERT [dbo].[student_master] ([Id], [Name], [Branch], [Semester], [Email], [Password]) VALUES (CAST(2 AS Numeric(18, 0)), N'swap', N'IT', N'Sem1', N'swap@gmail.com', N'XGhtQe')
INSERT [dbo].[student_master] ([Id], [Name], [Branch], [Semester], [Email], [Password]) VALUES (CAST(3 AS Numeric(18, 0)), N'testing', N'IT', N'Sem2', N'testing@gmail.com', N'Nctb5Q')
SET IDENTITY_INSERT [dbo].[student_master] OFF
USE [master]
GO
ALTER DATABASE [sso] SET  READ_WRITE 
GO
