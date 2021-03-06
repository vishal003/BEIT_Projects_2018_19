USE [master]
GO
/****** Object:  Database [DataIntegrity_split_DB]    Script Date: 04/21/2019 18:09:06 ******/
CREATE DATABASE [DataIntegrity_split_DB] ON  PRIMARY 
( NAME = N'DataIntegrity_split_DB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\DataIntegrity_split_DB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DataIntegrity_split_DB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\DataIntegrity_split_DB_log.ldf' , SIZE = 1792KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DataIntegrity_split_DB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DataIntegrity_split_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DataIntegrity_split_DB] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET ANSI_NULLS OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET ANSI_PADDING OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET ARITHABORT OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [DataIntegrity_split_DB] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [DataIntegrity_split_DB] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [DataIntegrity_split_DB] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET  DISABLE_BROKER
GO
ALTER DATABASE [DataIntegrity_split_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [DataIntegrity_split_DB] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [DataIntegrity_split_DB] SET  READ_WRITE
GO
ALTER DATABASE [DataIntegrity_split_DB] SET RECOVERY FULL
GO
ALTER DATABASE [DataIntegrity_split_DB] SET  MULTI_USER
GO
ALTER DATABASE [DataIntegrity_split_DB] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [DataIntegrity_split_DB] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'DataIntegrity_split_DB', N'ON'
GO
USE [DataIntegrity_split_DB]
GO
/****** Object:  Table [dbo].[fileMaster]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[fileMaster](
	[file_id] [int] IDENTITY(1,1) NOT NULL,
	[file_path] [varchar](200) NOT NULL,
	[file_name] [varchar](200) NOT NULL,
	[FileKey] [varchar](max) NOT NULL,
	[IV] [varchar](max) NOT NULL,
	[dt] [datetime] NOT NULL,
	[keyword] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[File_Info]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[File_Info](
	[file_id] [int] IDENTITY(1,1) NOT NULL,
	[file_name] [nvarchar](50) NULL,
	[key1] [nvarchar](50) NULL,
	[dt] [datetime] NULL,
	[hashValue] [varchar](max) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[Select_Data]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_Data]
	@file_name nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from File_Master where file_name=@file_name
END
GO
/****** Object:  Table [dbo].[requestMaster]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[requestMaster](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[file_id] [int] NOT NULL,
	[dt] [datetime] NOT NULL,
	[status] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[requestMaster] ON
INSERT [dbo].[requestMaster] ([id], [user_id], [file_id], [dt], [status]) VALUES (1, 2, 10, CAST(0x0000AA3100FBFFCE AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[requestMaster] OFF
/****** Object:  Table [dbo].[Share_Master]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Share_Master](
	[share_id] [int] IDENTITY(1,1) NOT NULL,
	[file_name] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[cloud_id] [nvarchar](50) NULL,
	[fid] [int] NULL,
	[dt] [datetime] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Share_Master] ON
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (1, N'IDEalgo2.txt', N'guidance@projectideas.co.in', N'Cloud', 1, CAST(0x0000A827013EAFF8 AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (2, N'IDataEncryalgo.txt', N'guidance@projectideas.co.in', N'Cloud', 2, CAST(0x0000A8280126B8FD AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (3, N'link.txt', N'guidance@projectideas.co.in', N'Cloud', 3, CAST(0x0000A88F01130FC3 AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (4, N'Jellyfish.jpg', N'guidance@projectideas.co.in', N'Cloud', 4, CAST(0x0000A88F01171F5D AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (5, N'youtubedata.txt', N'guidance@projectideas.co.in', N'Cloud', 6, CAST(0x0000A89501518F4C AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (6, N'Jellyfish.jpg', N'guidance@projectideas.co.in', N'Cloud', 4, CAST(0x0000A8950151F495 AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (7, N'IDEalgo2.txt', N'guidance@projectideas.co.in', N'Cloud', 1, CAST(0x0000A8AC0157A48A AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (8, N'AA_v3.5.log', N'guidance@projectideas.co.in', N'Cloud', 8, CAST(0x0000A8AC015B47DC AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (9, N'amici.png', N'guidance@projectideas.co.in', N'Cloud', 11, CAST(0x0000AA2400CC85E5 AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (10, N'636262175450539526.txt', N'mansigangurde0@gmail.com', N'Cloud', 12, CAST(0x0000AA3100FE6BC4 AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (11, N'outdoor.jpeg', N'guidance@projectideas.co.in', N'Cloud', 10, CAST(0x0000AA3100FED0CE AS DateTime))
INSERT [dbo].[Share_Master] ([share_id], [file_name], [username], [cloud_id], [fid], [dt]) VALUES (12, N'data_privacy_0.jpg', N'ankitkesarwani122@gmail.com', N'Cloud', 13, CAST(0x0000AA310109B66C AS DateTime))
SET IDENTITY_INSERT [dbo].[Share_Master] OFF
/****** Object:  Table [dbo].[admin_login]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin_login](
	[admin_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[admin_login] ON
INSERT [dbo].[admin_login] ([admin_id], [username], [password]) VALUES (1, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[admin_login] OFF
/****** Object:  Table [dbo].[User_Master]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Master](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [nvarchar](50) NULL,
	[contact_no] [nvarchar](50) NULL,
	[email_id] [nvarchar](50) NULL,
	[address] [nvarchar](max) NULL,
	[password] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User_Master] ON
INSERT [dbo].[User_Master] ([user_id], [full_name], [contact_no], [email_id], [address], [password]) VALUES (3, N'mansi', N'8605973598', N'mansigangurde0@gmail.com', N'dsnfkj', N'12345')
INSERT [dbo].[User_Master] ([user_id], [full_name], [contact_no], [email_id], [address], [password]) VALUES (2, N'chintan', N'9892369017', N'guidance@projectideas.co.in', N'asdad', N'12345')
INSERT [dbo].[User_Master] ([user_id], [full_name], [contact_no], [email_id], [address], [password]) VALUES (5, N'ankit', N'8605973598', N'ankitkesarwani122@gmail.com', N'dfs', N'VBAhCNjh')
SET IDENTITY_INSERT [dbo].[User_Master] OFF
/****** Object:  StoredProcedure [dbo].[uploadHashData]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		sys
-- =============================================
CREATE PROCEDURE [dbo].[uploadHashData]
	-- Add the parameters for the stored procedure here
	@fname nvarchar(50),
	@key1 nvarchar(50),
	@hValue varchar(max)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into File_Info values(@fname,@key1,getdate(),@hValue)
END
GO
/****** Object:  StoredProcedure [dbo].[upload_data]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		sy
-- =============================================
CREATE PROCEDURE [dbo].[upload_data]
	-- Add the parameters for the stored procedure here
	@path varchar(200),
	@name varchar(200),
	@key varchar(max),
	@iv varchar(max),
	@keyword varchar(max)
AS
BEGIN
	
	SET NOCOUNT ON;
	insert into fileMaster values (@path,@name,@key,@iv,getdate(),@keyword)
END
GO
/****** Object:  StoredProcedure [dbo].[shareFile]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		sy
-- =============================================
CREATE PROCEDURE [dbo].[shareFile]
	-- Add the parameters for the stored procedure here
	@reqId int,
	@fid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update requestMaster set status=1 where id=@reqId
	
	Insert into Share_Master select file_name,email_id,'Cloud',a.file_id,getdate() from (select id,file_name,rm.file_id from fileMaster as fm left join requestMaster as rm on fm.file_id=rm.file_id where id=@reqId) as a left join (select id,email_id from User_Master as um left join requestMaster as rm on um.user_id=rm.user_id where id=@reqId) as b on a.id=b.id
	
	select FileKey from fileMaster where file_id=@fid
 
END
GO
/****** Object:  StoredProcedure [dbo].[Select_info]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_info]
	@file_name nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from fileMaster where file_name=@file_name
END
GO
/****** Object:  StoredProcedure [dbo].[keywordSearch]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		sy
-- =============================================
CREATE PROCEDURE [dbo].[keywordSearch]
@str varchar(50),
@uid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
CREATE TABLE #Temp (tDay VARCHAR(100))
WHILE LEN(@str) > 0
BEGIN
    DECLARE @TDay VARCHAR(100)
    IF CHARINDEX(' ',@str) > 0
        SET  @TDay = SUBSTRING(@str,0,CHARINDEX(' ',@str))
    ELSE
        BEGIN
        SET  @TDay = @str
        SET @str = ''
        END
  INSERT INTO  #Temp VALUES (@TDay)
 SET @str = REPLACE(@str,@TDay + ' ' , '')
 END
 
  SELECT file_id,file_name 
	 FROM fileMaster as fm left join (select fid from Share_Master left join User_Master on username=email_id where user_id=@uid) as sm on file_id=sm.fid
		WHERE fid is NULL and keyword like '%'+(SELECT tDay FROM #Temp)+'%'
 
END
GO
/****** Object:  StoredProcedure [dbo].[insertRequest]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		sy
-- =============================================
CREATE PROCEDURE [dbo].[insertRequest]
	-- Add the parameters for the stored procedure here
	@uid int,
	@fid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	create table #temp2 (reqId int)
	insert into #temp2  select id from requestMaster where user_id=@uid and file_id=@fid
	declare @value int
	set @value=(select count(reqId) from #temp2)
	if(@value>0)
	begin
	select count(reqId) from #temp2
	end
	else
	begin
	insert into requestMaster values (@uid,@fid,getdate(),0)
	select count(reqId) from #temp2
	end
END
GO
/****** Object:  StoredProcedure [dbo].[CompareKeys]    Script Date: 04/21/2019 18:09:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CompareKeys]
	@key_value varchar(500)

AS
BEGIN
	SET NOCOUNT ON;
	Declare @count int;
	set @count = 0;
	-- Check key id 
	
	Declare @keyValue varchar(500);
	Select @keyValue=FileKey from fileMaster where FileKey = @key_value
	if(@keyValue is not null)
	begin		
			select file_id, file_path,file_name from fileMaster where FileKey = @keyValue	
 	End
 	else 
 	begin
 		-- key value is wrong
 		return 0;
 	end 
 	
 	 
 	
END
GO
