USE [master]
GO
/****** Object:  Database [UniversityMVC_DB]    Script Date: 29-Aug-16 12:37:16 PM ******/
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
/****** Object:  Table [dbo].[AllocateClassRoom]    Script Date: 29-Aug-16 12:37:17 PM ******/
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
/****** Object:  Table [dbo].[Course]    Script Date: 29-Aug-16 12:37:17 PM ******/
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
/****** Object:  Table [dbo].[Department]    Script Date: 29-Aug-16 12:37:17 PM ******/
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
/****** Object:  Table [dbo].[Designation]    Script Date: 29-Aug-16 12:37:17 PM ******/
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
/****** Object:  Table [dbo].[EnrollStudent]    Script Date: 29-Aug-16 12:37:17 PM ******/
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
/****** Object:  Table [dbo].[Room]    Script Date: 29-Aug-16 12:37:17 PM ******/
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
/****** Object:  Table [dbo].[Semester]    Script Date: 29-Aug-16 12:37:17 PM ******/
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
/****** Object:  Table [dbo].[Student]    Script Date: 29-Aug-16 12:37:17 PM ******/
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
/****** Object:  Table [dbo].[StudentGrade]    Script Date: 29-Aug-16 12:37:17 PM ******/
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 29-Aug-16 12:37:17 PM ******/
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
/****** Object:  Table [dbo].[TeacherAssign]    Script Date: 29-Aug-16 12:37:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherAssign](
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] ON 

INSERT [dbo].[AllocateClassRoom] ([Id], [CourseId], [RoomId], [Day], [FromHour], [FromMin], [FromDay], [ToHour], [ToMin], [ToDay], [Status]) VALUES (3, 3, 1, N'Saturday', 9, 0, N'PM', 11, 20, N'PM', 0)
INSERT [dbo].[AllocateClassRoom] ([Id], [CourseId], [RoomId], [Day], [FromHour], [FromMin], [FromDay], [ToHour], [ToMin], [ToDay], [Status]) VALUES (4, 3, 2, N'Saturday', 10, 0, N'AM', 11, 0, N'AM', 0)
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartementId], [SemisterId]) VALUES (1, N'CSE-101', N'Programming Language 1 ', 3, NULL, 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartementId], [SemisterId]) VALUES (2, N'EEE-101', N'Electronic Devices', 3, NULL, 2, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartementId], [SemisterId]) VALUES (3, N'CE-101', N'Geology and Geotechnical Engineering', 3, N'Geology and Geotechnical Engineering', 3, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartementId], [SemisterId]) VALUES (5, N'EEE-102', N'A triple E subject', 3, N'Test Description', 2, 7)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartementId], [SemisterId]) VALUES (6, N'EEE-103', N'Devices and intrumentation', 15, N'', 2, 2)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [DepartementId], [SemisterId]) VALUES (7, N'OOP-1', N'Encapsulation', 2, N'', 21, 4)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Name], [Code]) VALUES (1, N'Computer Science and Engineering', N'CSE')
INSERT [dbo].[Department] ([Id], [Name], [Code]) VALUES (2, N'Electrical Engineering', N'EEE')
INSERT [dbo].[Department] ([Id], [Name], [Code]) VALUES (3, N'Civil Engineering', N'CE')
INSERT [dbo].[Department] ([Id], [Name], [Code]) VALUES (20, N'BioTech', N'BioTech')
INSERT [dbo].[Department] ([Id], [Name], [Code]) VALUES (21, N'Object Oriented Programming', N'OOP')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [Name]) VALUES (1, N'Lecturer')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (2, N'Assistant Professor')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (3, N'Associate Professor')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (4, N'Professor')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[EnrollStudent] ON 

INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (1, 1, 1, CAST(N'2016-08-14' AS Date), 0)
INSERT [dbo].[EnrollStudent] ([Id], [StudentId], [CourseId], [EnrollmentDate], [Status]) VALUES (3, 2, 1, CAST(N'2016-08-14' AS Date), 0)
SET IDENTITY_INSERT [dbo].[EnrollStudent] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([Id], [RoomNumber]) VALUES (1, N'A-101')
INSERT [dbo].[Room] ([Id], [RoomNumber]) VALUES (2, N'A-102')
INSERT [dbo].[Room] ([Id], [RoomNumber]) VALUES (3, N'A-103')
INSERT [dbo].[Room] ([Id], [RoomNumber]) VALUES (4, N'A-104')
INSERT [dbo].[Room] ([Id], [RoomNumber]) VALUES (5, N'A-105')
INSERT [dbo].[Room] ([Id], [RoomNumber]) VALUES (6, N'B-101')
INSERT [dbo].[Room] ([Id], [RoomNumber]) VALUES (7, N'B-102')
INSERT [dbo].[Room] ([Id], [RoomNumber]) VALUES (8, N'B-103')
INSERT [dbo].[Room] ([Id], [RoomNumber]) VALUES (9, N'B-104')
INSERT [dbo].[Room] ([Id], [RoomNumber]) VALUES (10, N'B-105')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([Id], [Name]) VALUES (1, N'First Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (2, N'Second Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (3, N'Third Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (4, N'Fourth Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (5, N'Fifth Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (6, N'Sixth Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (7, N'Seventh Semester')
INSERT [dbo].[Semester] ([Id], [Name]) VALUES (8, N'Eighth Semester')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmenteId], [RegistrationNo]) VALUES (1, N'Mostak Sheikh', N'mostak@yahoo.com', N'01711554499', CAST(N'2016-08-14' AS Date), N'Khulna', 1, N'CSE-2016-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmenteId], [RegistrationNo]) VALUES (2, N'Saiful Islam', N'saiful@aolmail.com', N'01714445589', CAST(N'2016-08-14' AS Date), N'Bagura', 1, N'CSE-2016-002')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmenteId], [RegistrationNo]) VALUES (3, N'Joyashree Sarkar', N'joya@rocektmail.com', N'01914785966', CAST(N'2016-08-14' AS Date), N'Chittagong', 2, N'EEE-2016-003')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmenteId], [RegistrationNo]) VALUES (4, N'Tanjia Mim', N'mim@ymail.com', N'01552589744', CAST(N'2016-08-14' AS Date), N'Rajshahi', 3, N'CE-2016-004')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmenteId], [RegistrationNo]) VALUES (6, N'Arifur Rahman', N'arif@dwasa.bd', N'01669874123', CAST(N'2016-08-15' AS Date), N'Feni', 1, N'CSE-2016-005')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmenteId], [RegistrationNo]) VALUES (7, N'Shible Noman', N'shblnmn@gmail.com', N'01674779908', CAST(N'2016-01-08' AS Date), N'Mohammadpur, Dhaka', 21, N'OOP-2016-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [ContactNo], [Date], [Address], [DepartmenteId], [RegistrationNo]) VALUES (8, N'Himel', N'himu@gmail.com', N'01265741', CAST(N'2016-02-08' AS Date), N'Mirpur, Dhaka', 21, N'OOP-2016-002')
SET IDENTITY_INSERT [dbo].[Student] OFF
INSERT [dbo].[StudentGrade] ([StudentId], [CourseId], [Grade]) VALUES (1, 1, N'B+')
INSERT [dbo].[StudentGrade] ([StudentId], [CourseId], [Grade]) VALUES (3, 5, N'A+')
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (1, N'MD. Sabur Khan', N'Sobhanbag, Dhaka', N'sabur@sabur.com', N'0171122334455', 4, 1, 12)
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (3, N'Samawat Ullah', N'Banani, Dhaka', N'samawat@aiub.edu', N'0181222233333', 1, 3, 36)
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (4, N'Kalpona Akter', N'Banani, Dhaka', N'kalpona@aiub.edu', N'0299887744', 3, 2, 18)
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (5, N'Sobra Das', N'Mirpur, Dhaka', N'sobra@gmail.com', N'0236974712', 2, 1, 12)
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (6, N'Shirajul Mamun', N'Khulna', N'shijarul.mamun@gmail.com', N'017177889933', 2, 1, 15)
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (7, N'Rakib Hossain', N'Barishal', N'rakib@gmail.com', N'123456789', 1, 3, 5)
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [ContactNo], [DesignationId], [DepartmentId], [CreditToBeTaken]) VALUES (8, N'Tiemoon', N'Dhaka', N'tiemoon@gmail.com', N'012589632', 4, 21, 8)
SET IDENTITY_INSERT [dbo].[Teacher] OFF
INSERT [dbo].[TeacherAssign] ([TeacherId], [CourseId]) VALUES (4, 6)
INSERT [dbo].[TeacherAssign] ([TeacherId], [CourseId]) VALUES (4, 5)
INSERT [dbo].[TeacherAssign] ([TeacherId], [CourseId]) VALUES (4, 2)
INSERT [dbo].[TeacherAssign] ([TeacherId], [CourseId]) VALUES (8, 7)
USE [master]
GO
ALTER DATABASE [UniversityMVC_DB] SET  READ_WRITE 
GO
