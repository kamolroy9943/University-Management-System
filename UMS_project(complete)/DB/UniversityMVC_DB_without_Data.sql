USE [master]
GO
/****** Object:  Database [UniversityMVC_DB]    Script Date: 29-Aug-16 12:39:58 PM ******/
CREATE DATABASE [UniversityMVC_DB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityMVC_DB', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UniversityMVC_DB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityMVC_DB_log', FILENAME = N'D:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\UniversityMVC_DB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityMVC_DB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityMVC_DB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityMVC_DB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityMVC_DB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityMVC_DB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityMVC_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityMVC_DB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityMVC_DB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityMVC_DB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityMVC_DB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityMVC_DB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityMVC_DB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [UniversityMVC_DB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [UniversityMVC_DB]
GO
/****** Object:  Table [dbo].[AllocateClassRoom]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AllocateClassRoom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[Day] [varchar](10) NOT NULL,
	[FromHour] [int] NOT NULL,
	[FromMin] [int] NOT NULL,
	[FromDay] [varchar](2) NULL,
	[ToHour] [int] NULL,
	[ToMin] [int] NULL,
	[ToDay] [varchar](2) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_AllocateClassRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Course]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [int] NOT NULL,
	[Description] [text] NULL,
	[DepartementId] [int] NOT NULL,
	[SemisterId] [int] NOT NULL,
 CONSTRAINT [PK_course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Code] [varchar](50) NOT NULL,
 CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrollStudent]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollStudent](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[EnrollmentDate] [date] NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_EnrollStudent] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNumber] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](20) NOT NULL,
	[ContactNo] [varchar](20) NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [text] NOT NULL,
	[DepartmenteId] [int] NOT NULL,
	[RegistrationNo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentGrade]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentGrade](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Grade] [varchar](3) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [text] NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](20) NOT NULL,
	[DesignationId] [int] NULL,
	[DepartmentId] [int] NULL,
	[CreditToBeTaken] [int] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TeacherAssign]    Script Date: 29-Aug-16 12:39:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherAssign](
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [UniversityMVC_DB] SET  READ_WRITE 
GO
