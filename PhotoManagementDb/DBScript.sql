USE [master]
GO
/****** Object:  Database [photoManagementDb]    Script Date: 18/05/2022 22:03:56 ******/
CREATE DATABASE [photoManagementDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'photoManagementDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\photoManagementDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'photoManagementDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\photoManagementDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [photoManagementDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [photoManagementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [photoManagementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [photoManagementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [photoManagementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [photoManagementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [photoManagementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [photoManagementDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [photoManagementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [photoManagementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [photoManagementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [photoManagementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [photoManagementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [photoManagementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [photoManagementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [photoManagementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [photoManagementDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [photoManagementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [photoManagementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [photoManagementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [photoManagementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [photoManagementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [photoManagementDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [photoManagementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [photoManagementDb] SET RECOVERY FULL 
GO
ALTER DATABASE [photoManagementDb] SET  MULTI_USER 
GO
ALTER DATABASE [photoManagementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [photoManagementDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [photoManagementDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [photoManagementDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [photoManagementDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [photoManagementDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'photoManagementDb', N'ON'
GO
ALTER DATABASE [photoManagementDb] SET QUERY_STORE = OFF
GO
USE [photoManagementDb]
GO
/****** Object:  Table [dbo].[AppUser]    Script Date: 18/05/2022 22:03:56 ******/
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
/****** Object:  Table [dbo].[Package]    Script Date: 18/05/2022 22:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreatedId] [uniqueidentifier] NOT NULL,
	[DateLastModified] [datetimeoffset](0) NULL,
	[UserLastModifiedId] [uniqueidentifier] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageRestriction]    Script Date: 18/05/2022 22:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageRestriction](
	[Id] [bigint] NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DataType] [nvarchar](255) NOT NULL,
	[DefaultValue] [nvarchar](255) NULL,
	[DateCreated] [datetimeoffset](0) NOT NULL,
	[UserCreatedId] [uniqueidentifier] NOT NULL,
	[DateLastModified] [datetimeoffset](7) NULL,
	[UserLastModifiedId] [uniqueidentifier] NULL,
	[Active] [bigint] NOT NULL,
 CONSTRAINT [PK_PackageRestriction] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PackageRestrictionValue]    Script Date: 18/05/2022 22:03:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PackageRestrictionValue](
	[Id] [bigint] NOT NULL,
	[PackageRestrictionId] [bigint] NOT NULL,
	[PackageId] [bigint] NOT NULL,
	[Value] [nvarchar](255) NOT NULL,
	[DateCreated] [datetimeoffset](7) NOT NULL,
	[UserCreatedId] [uniqueidentifier] NOT NULL,
	[DateLastModified] [datetimeoffset](7) NULL,
	[UserLastModifiedId] [uniqueidentifier] NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_PackageRestrictionValue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistryType]    Script Date: 18/05/2022 22:03:56 ******/
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
/****** Object:  Table [dbo].[SystemSetting]    Script Date: 18/05/2022 22:03:56 ******/
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
ALTER DATABASE [photoManagementDb] SET  READ_WRITE 
GO
