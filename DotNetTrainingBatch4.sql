USE [master]
GO
/****** Object:  Database [DotNetTrainingBatch4]    Script Date: 26-Apr-24 10:07:16 AM ******/
CREATE DATABASE [DotNetTrainingBatch4] ON  PRIMARY 
( NAME = N'DotNetTrainingBatch4', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DotNetTrainingBatch4.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DotNetTrainingBatch4_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DotNetTrainingBatch4_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DotNetTrainingBatch4].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DotNetTrainingBatch4] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET ARITHABORT OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET RECOVERY FULL 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET  MULTI_USER 
GO
ALTER DATABASE [DotNetTrainingBatch4] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DotNetTrainingBatch4] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DotNetTrainingBatch4', N'ON'
GO
USE [DotNetTrainingBatch4]
GO
/****** Object:  Table [dbo].[Tbl_Blog]    Script Date: 26-Apr-24 10:07:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Blog](
	[BlogId] [int] IDENTITY(1,1) NOT NULL,
	[BlogTitle] [varchar](50) NOT NULL,
	[BlogAuthor] [varchar](50) NOT NULL,
	[BlogContent] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Tbl_Blog] ON 

INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (1, N'superman', N'spiderman', N'ironman')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (2, N'test title', N'test author', N'test content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (3, N'test title', N'test author', N'test content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (4, N'test title', N'test author', N'test content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (5, N'test title', N'test author', N'test content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (6, N'test title', N'test author', N'test content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (7, N'test title', N'test author', N'test content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (8, N'test title', N'test author', N'test content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (9, N'test title', N'test author', N'test content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (10, N'title', N'author', N'content')
INSERT [dbo].[Tbl_Blog] ([BlogId], [BlogTitle], [BlogAuthor], [BlogContent]) VALUES (17, N'title', N'author', N'title')
SET IDENTITY_INSERT [dbo].[Tbl_Blog] OFF
GO
USE [master]
GO
ALTER DATABASE [DotNetTrainingBatch4] SET  READ_WRITE 
GO
