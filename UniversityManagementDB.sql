USE [master]
GO
/****** Object:  Database [UniversityManagementDB]    Script Date: 1/26/2018 4:07:04 PM ******/
CREATE DATABASE [UniversityManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UniversityManagementDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\UniversityManagementDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityManagementDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityManagementDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityManagementDB]
GO
/****** Object:  Table [dbo].[AllocateClassRoom]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocateClassRoom](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[DayId] [int] NOT NULL,
	[DateFrom] [time](7) NOT NULL,
	[DateTo] [time](7) NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_AllocateClassRoom] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AssignedCourse]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignedCourse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Department_Id] [int] NOT NULL,
	[Teacher_Id] [int] NOT NULL,
	[Course_Id] [int] NOT NULL,
	[Status_Id] [int] NOT NULL,
 CONSTRAINT [PK_AssignedCourse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](5) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [float] NOT NULL,
	[Description] [text] NOT NULL,
	[Department_Id] [int] NOT NULL,
	[Semester_Id] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Day]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Day](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](7) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 1/26/2018 4:07:04 PM ******/
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
/****** Object:  Table [dbo].[Enrolled]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrolled](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Course_ID] [int] NOT NULL,
	[Student_ID] [int] NOT NULL,
	[GradeId] [int] NOT NULL,
	[Status_Id] [int] NOT NULL,
 CONSTRAINT [PK_Enrolled] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grade]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grade](
	[Id] [int] NOT NULL,
	[GradeLetter] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Room]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contactno] [varchar](14) NOT NULL,
	[Date] [date] NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[Registrationno] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Contactno] [varchar](20) NOT NULL,
	[Designation_Id] [int] NOT NULL,
	[Department_Id] [int] NOT NULL,
	[CreditToTake] [int] NULL,
	[Creditremain] [sql_variant] NULL,
 CONSTRAINT [PK_Teacher_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[AssigendCourseview]    Script Date: 1/26/2018 4:07:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[AssigendCourseview]
as
select D.id as DeptId, c.Id as CourseId,C.Code as CourseCode,C.Name As CourseName,s.Name As Semester,T.Name as TeacherName,AC.Status_Id as Status_Id from Course as C
left join Department as D
on 
C.Department_Id= d.Id
left join AssignedCourse as Ac
on
Ac.Course_Id = C.Id
left join Teacher as T
on
Ac.Teacher_Id = T.Id
left join Semester as S
on
C.Semester_Id = S.Id
where ac.Status_Id Is Null or ac.Status_Id =1


GO
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] ON 

INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [DateFrom], [DateTo], [StatusId]) VALUES (2, 1, 3, 1, 1, CAST(0x0700A8E76F4B0000 AS Time), CAST(0x07000236D36C0000 AS Time), 0)
INSERT [dbo].[AllocateClassRoom] ([Id], [DepartmentId], [CourseId], [RoomId], [DayId], [DateFrom], [DateTo], [StatusId]) VALUES (3, 1, 3, 1, 1, CAST(0x07007CDB27710000 AS Time), CAST(0x070050891C730000 AS Time), 0)
SET IDENTITY_INSERT [dbo].[AllocateClassRoom] OFF
SET IDENTITY_INSERT [dbo].[AssignedCourse] ON 

INSERT [dbo].[AssignedCourse] ([Id], [Department_Id], [Teacher_Id], [Course_Id], [Status_Id]) VALUES (56, 1, 1005, 3, 1)
INSERT [dbo].[AssignedCourse] ([Id], [Department_Id], [Teacher_Id], [Course_Id], [Status_Id]) VALUES (57, 1, 1008, 6, 1)
INSERT [dbo].[AssignedCourse] ([Id], [Department_Id], [Teacher_Id], [Course_Id], [Status_Id]) VALUES (58, 1, 1009, 10, 1)
INSERT [dbo].[AssignedCourse] ([Id], [Department_Id], [Teacher_Id], [Course_Id], [Status_Id]) VALUES (59, 1, 1010, 11, 1)
INSERT [dbo].[AssignedCourse] ([Id], [Department_Id], [Teacher_Id], [Course_Id], [Status_Id]) VALUES (60, 1, 1011, 12, 1)
SET IDENTITY_INSERT [dbo].[AssignedCourse] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [Department_Id], [Semester_Id]) VALUES (3, N'Cse1', N'C Programing', 5, N'its aprogrmain', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [Department_Id], [Semester_Id]) VALUES (6, N'Cse2', N'C Programin lab', 0.5, N'Its a lab Class', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [Department_Id], [Semester_Id]) VALUES (10, N'CSE99', N'Algorithm lab', 0.5, N'its a lab class', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [Department_Id], [Semester_Id]) VALUES (11, N'CSE10', N'C Programing lab', 0.5, N'its lab class', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [Department_Id], [Semester_Id]) VALUES (12, N'gfdh', N'dfhg', 0.5, N'dfsgfd', 1, 1)
INSERT [dbo].[Course] ([Id], [Code], [Name], [Credit], [Description], [Department_Id], [Semester_Id]) VALUES (14, N'CSE11', N'NCS', 3, N'Netork', 1, 1)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Day] ON 

INSERT [dbo].[Day] ([Id], [Name]) VALUES (1, N'Satarday')
INSERT [dbo].[Day] ([Id], [Name]) VALUES (2, N'Sunday')
INSERT [dbo].[Day] ([Id], [Name]) VALUES (3, N'Monday')
INSERT [dbo].[Day] ([Id], [Name]) VALUES (4, N'Thuesday')
INSERT [dbo].[Day] ([Id], [Name]) VALUES (5, N'Wednesday')
INSERT [dbo].[Day] ([Id], [Name]) VALUES (6, N'Thrusday')
INSERT [dbo].[Day] ([Id], [Name]) VALUES (7, N'Friday')
SET IDENTITY_INSERT [dbo].[Day] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (1, N'CSE', N'Computer Science and Engineering')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (2, N'Phy', N'Physics')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (3, N'BBA', N'Bachelor Of Business Adminstration')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (4, N'EEE', N'Electronics and Electrical')
INSERT [dbo].[Department] ([Id], [Code], [Name]) VALUES (5, N'ENG', N'English Language & Literature ')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([Id], [Name]) VALUES (1, N'Professor')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (2, N'Ass. Professor')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (3, N'Lecturer')
INSERT [dbo].[Designation] ([Id], [Name]) VALUES (4, N'Ass. Lecturer')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[Enrolled] ON 

INSERT [dbo].[Enrolled] ([ID], [Course_ID], [Student_ID], [GradeId], [Status_Id]) VALUES (2, 3, 4, 0, 1)
INSERT [dbo].[Enrolled] ([ID], [Course_ID], [Student_ID], [GradeId], [Status_Id]) VALUES (3, 6, 4, 1, 1)
SET IDENTITY_INSERT [dbo].[Enrolled] OFF
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (0, N'NA')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (1, N'A+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (2, N'A')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (3, N'A-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (4, N'B+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (5, N'B')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (6, N'B-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (7, N'C+')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (8, N'C')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (9, N'C-')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (10, N'D')
INSERT [dbo].[Grade] ([Id], [GradeLetter]) VALUES (11, N'F')
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([id], [Name]) VALUES (1, N'Lab-701')
INSERT [dbo].[Room] ([id], [Name]) VALUES (2, N'Lab-702')
INSERT [dbo].[Room] ([id], [Name]) VALUES (3, N'R-501')
INSERT [dbo].[Room] ([id], [Name]) VALUES (4, N'R-502')
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

INSERT [dbo].[Student] ([Id], [Name], [Email], [Contactno], [Date], [Address], [DepartmentId], [Registrationno]) VALUES (4, N'Prothom', N'prothom@gmail.com', N'0181810548', CAST(0x00000000 AS Date), N'sfsfs', 1, N'CSE-1-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [Contactno], [Date], [Address], [DepartmentId], [Registrationno]) VALUES (5, N'Pranto', N'pranto@g.vom', N'023164651', CAST(0x6C3E0B00 AS Date), N'sdfdfdf', 4, N'EEE-2018-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [Contactno], [Date], [Address], [DepartmentId], [Registrationno]) VALUES (6, N'Puffin', N'sjljfjshf@sdfj.sdf', N'023154', CAST(0x00000000 AS Date), N'sgsfsdfs', 2, N'Phy-1-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [Contactno], [Date], [Address], [DepartmentId], [Registrationno]) VALUES (7, N'fsdfs', N'sdfsdf@ss.cjj', N'0212', CAST(0xA93E0B00 AS Date), N'rtetert', 1, N'CSE-2018-001')
INSERT [dbo].[Student] ([Id], [Name], [Email], [Contactno], [Date], [Address], [DepartmentId], [Registrationno]) VALUES (8, N'Bishu', N'jffhgf@kgkj.com', N'05184', CAST(0x00000000 AS Date), N'hgfhgfh', 1, N'CSE-1-002')
INSERT [dbo].[Student] ([Id], [Name], [Email], [Contactno], [Date], [Address], [DepartmentId], [Registrationno]) VALUES (9, N'Prothom', N'prothom@gmail.coms', N'0181810548', CAST(0xCC3D0B00 AS Date), N'tynrsyny', 1, N'CSE-2018-002')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [Contactno], [Designation_Id], [Department_Id], [CreditToTake], [Creditremain]) VALUES (1005, N'Taybur', N'Chittagong', N'taybur@mail.com', N'01814829883', 1, 1, 45, CAST(Convert(text, N'23.5') AS varchar(4)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [Contactno], [Designation_Id], [Department_Id], [CreditToTake], [Creditremain]) VALUES (1008, N'Rahman', N'Chittagon', N'rahman@mail.com', N'01814829883', 1, 1, 45, CAST(Convert(text, N'44.5') AS varchar(4)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [Contactno], [Designation_Id], [Department_Id], [CreditToTake], [Creditremain]) VALUES (1009, N'Faisal Faruqee', N'Chittagong', N'faisal@uits.com', N'01814-000000', 1, 1, 30, CAST(Convert(text, N'29.5') AS varchar(4)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [Contactno], [Designation_Id], [Department_Id], [CreditToTake], [Creditremain]) VALUES (1010, N'Saimun', N'Chittagong', N'shaonmahajan@gmail.com', N'01814829833', 1, 1, 1, CAST(Convert(text, N'-6.0') AS varchar(4)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [Contactno], [Designation_Id], [Department_Id], [CreditToTake], [Creditremain]) VALUES (1011, N'Rakib', N'Chittagong', N'rqb.tctg@gmail.com', N'01814-000000', 1, 1, 10, CAST(Convert(text, N'-5.5') AS varchar(4)))
INSERT [dbo].[Teacher] ([Id], [Name], [Address], [Email], [Contactno], [Designation_Id], [Department_Id], [CreditToTake], [Creditremain]) VALUES (1012, N'Hero Alom', N'Chittagong', N'hero@mail.com', N'01814-000000', 2, 2, 5, CAST(5.00 AS decimal(18,2)))
SET IDENTITY_INSERT [dbo].[Teacher] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course]    Script Date: 1/26/2018 4:07:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Course] ON [dbo].[Course]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Course_1]    Script Date: 1/26/2018 4:07:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Course_1] ON [dbo].[Course]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Department]    Script Date: 1/26/2018 4:07:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Department] ON [dbo].[Department]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Enrolled] ADD  CONSTRAINT [DF_Enrolled_GradeId]  DEFAULT ((0)) FOR [GradeId]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Course]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Day] FOREIGN KEY([DayId])
REFERENCES [dbo].[Day] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Day]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Department]
GO
ALTER TABLE [dbo].[AllocateClassRoom]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassRoom_Room] FOREIGN KEY([RoomId])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[AllocateClassRoom] CHECK CONSTRAINT [FK_AllocateClassRoom_Room]
GO
ALTER TABLE [dbo].[AssignedCourse]  WITH CHECK ADD  CONSTRAINT [FK_AssignedCourse_Course] FOREIGN KEY([Course_Id])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[AssignedCourse] CHECK CONSTRAINT [FK_AssignedCourse_Course]
GO
ALTER TABLE [dbo].[AssignedCourse]  WITH CHECK ADD  CONSTRAINT [FK_AssignedCourse_Department] FOREIGN KEY([Department_Id])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[AssignedCourse] CHECK CONSTRAINT [FK_AssignedCourse_Department]
GO
ALTER TABLE [dbo].[AssignedCourse]  WITH CHECK ADD  CONSTRAINT [FK_AssignedCourse_Teacher] FOREIGN KEY([Teacher_Id])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[AssignedCourse] CHECK CONSTRAINT [FK_AssignedCourse_Teacher]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Course] FOREIGN KEY([Department_Id])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Course]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Course1] FOREIGN KEY([Semester_Id])
REFERENCES [dbo].[Semester] ([Id])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Course1]
GO
ALTER TABLE [dbo].[Enrolled]  WITH CHECK ADD  CONSTRAINT [FK_Enrolled_Course] FOREIGN KEY([Course_ID])
REFERENCES [dbo].[Course] ([Id])
GO
ALTER TABLE [dbo].[Enrolled] CHECK CONSTRAINT [FK_Enrolled_Course]
GO
ALTER TABLE [dbo].[Enrolled]  WITH CHECK ADD  CONSTRAINT [FK_Enrolled_Grade] FOREIGN KEY([GradeId])
REFERENCES [dbo].[Grade] ([Id])
GO
ALTER TABLE [dbo].[Enrolled] CHECK CONSTRAINT [FK_Enrolled_Grade]
GO
ALTER TABLE [dbo].[Enrolled]  WITH CHECK ADD  CONSTRAINT [FK_Enrolled_Student] FOREIGN KEY([Student_ID])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[Enrolled] CHECK CONSTRAINT [FK_Enrolled_Student]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([Department_Id])
REFERENCES [dbo].[Department] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Designation] FOREIGN KEY([Designation_Id])
REFERENCES [dbo].[Designation] ([Id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Designation]
GO
USE [master]
GO
ALTER DATABASE [UniversityManagementDB] SET  READ_WRITE 
GO
