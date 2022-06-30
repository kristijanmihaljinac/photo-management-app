USE [master]
GO
/****** Object:  Database [PhotoManagementDb]    Script Date: 30.6.2022. 15:15:56 ******/
CREATE DATABASE [PhotoManagementDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PhotoManagementDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PhotoManagementDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PhotoManagementDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\PhotoManagementDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [PhotoManagementDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PhotoManagementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PhotoManagementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PhotoManagementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PhotoManagementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PhotoManagementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PhotoManagementDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET RECOVERY FULL 
GO
ALTER DATABASE [PhotoManagementDb] SET  MULTI_USER 
GO
ALTER DATABASE [PhotoManagementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PhotoManagementDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PhotoManagementDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PhotoManagementDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PhotoManagementDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PhotoManagementDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [PhotoManagementDb] SET QUERY_STORE = OFF
GO
USE [PhotoManagementDb]
GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 30.6.2022. 15:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AppUser](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AppUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Package]    Script Date: 30.6.2022. 15:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreatedId] [uniqueidentifier] NOT NULL,
	[DateLastModified] [datetimeoffset](0) NULL,
	[UserLastModifiedId] [uniqueidentifier] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Package_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageRestriction]    Script Date: 30.6.2022. 15:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageRestriction](
	[Id] [bigint] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](255) NULL,
	[OrderLevel] [int] NOT NULL,
	[DataType] [nvarchar](255) NOT NULL,
	[DefaultValue] [nvarchar](255) NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreatedId] [uniqueidentifier] NOT NULL,
	[DateLastModified] [datetimeoffset](0) NULL,
	[UserLastModifiedId] [uniqueidentifier] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_PackageRestriction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageRestrictionValue]    Script Date: 30.6.2022. 15:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageRestrictionValue](
	[Id] [bigint] NOT NULL,
	[PackageRestrictionId] [bigint] NOT NULL,
	[PackageId] [uniqueidentifier] NOT NULL,
	[Value] [nvarchar](255) NOT NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreatedId] [uniqueidentifier] NOT NULL,
	[DateLastModified] [datetimeoffset](0) NULL,
	[UserLastModifiedId] [uniqueidentifier] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_PackageRestrictionValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistryType]    Script Date: 30.6.2022. 15:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistryType](
	[Id] [bigint] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RegistryType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemSetting]    Script Date: 30.6.2022. 15:15:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemSetting](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_SystemSetting] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Package]  WITH CHECK ADD  CONSTRAINT [FK_Package_AppUser] FOREIGN KEY([UserCreatedId])
REFERENCES [dbo].[AppUser] ([Id])
GO
ALTER TABLE [dbo].[Package] CHECK CONSTRAINT [FK_Package_AppUser]
GO
ALTER TABLE [dbo].[Package]  WITH CHECK ADD  CONSTRAINT [FK_Package_AppUser1] FOREIGN KEY([UserLastModifiedId])
REFERENCES [dbo].[AppUser] ([Id])
GO
ALTER TABLE [dbo].[Package] CHECK CONSTRAINT [FK_Package_AppUser1]
GO
ALTER TABLE [dbo].[PackageRestriction]  WITH CHECK ADD  CONSTRAINT [FK_PackageRestriction_AppUser] FOREIGN KEY([UserCreatedId])
REFERENCES [dbo].[AppUser] ([Id])
GO
ALTER TABLE [dbo].[PackageRestriction] CHECK CONSTRAINT [FK_PackageRestriction_AppUser]
GO
ALTER TABLE [dbo].[PackageRestriction]  WITH CHECK ADD  CONSTRAINT [FK_PackageRestriction_AppUser1] FOREIGN KEY([UserLastModifiedId])
REFERENCES [dbo].[AppUser] ([Id])
GO
ALTER TABLE [dbo].[PackageRestriction] CHECK CONSTRAINT [FK_PackageRestriction_AppUser1]
GO
ALTER TABLE [dbo].[PackageRestrictionValue]  WITH CHECK ADD  CONSTRAINT [FK_PackageRestrictionValue_AppUser] FOREIGN KEY([UserCreatedId])
REFERENCES [dbo].[AppUser] ([Id])
GO
ALTER TABLE [dbo].[PackageRestrictionValue] CHECK CONSTRAINT [FK_PackageRestrictionValue_AppUser]
GO
ALTER TABLE [dbo].[PackageRestrictionValue]  WITH CHECK ADD  CONSTRAINT [FK_PackageRestrictionValue_AppUser1] FOREIGN KEY([UserLastModifiedId])
REFERENCES [dbo].[AppUser] ([Id])
GO
ALTER TABLE [dbo].[PackageRestrictionValue] CHECK CONSTRAINT [FK_PackageRestrictionValue_AppUser1]
GO
ALTER TABLE [dbo].[PackageRestrictionValue]  WITH CHECK ADD  CONSTRAINT [FK_PackageRestrictionValue_Package] FOREIGN KEY([PackageId])
REFERENCES [dbo].[Package] ([Id])
GO
ALTER TABLE [dbo].[PackageRestrictionValue] CHECK CONSTRAINT [FK_PackageRestrictionValue_Package]
GO
ALTER TABLE [dbo].[PackageRestrictionValue]  WITH CHECK ADD  CONSTRAINT [FK_PackageRestrictionValue_PackageRestriction] FOREIGN KEY([PackageRestrictionId])
REFERENCES [dbo].[PackageRestriction] ([Id])
GO
ALTER TABLE [dbo].[PackageRestrictionValue] CHECK CONSTRAINT [FK_PackageRestrictionValue_PackageRestriction]
GO
USE [master]
GO
ALTER DATABASE [PhotoManagementDb] SET  READ_WRITE 
GO
