USE [master]
GO
/****** Object:  Database [LMS]    Script Date: 02/28/2021 21:00:41 ******/
CREATE DATABASE [LMS] ON  PRIMARY 
( NAME = N'LMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\LMS.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\LMS_log.LDF' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LMS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LMS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [LMS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [LMS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [LMS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [LMS] SET ARITHABORT OFF
GO
ALTER DATABASE [LMS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [LMS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [LMS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [LMS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [LMS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [LMS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [LMS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [LMS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [LMS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [LMS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [LMS] SET  DISABLE_BROKER
GO
ALTER DATABASE [LMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [LMS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [LMS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [LMS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [LMS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [LMS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [LMS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [LMS] SET  READ_WRITE
GO
ALTER DATABASE [LMS] SET RECOVERY SIMPLE
GO
ALTER DATABASE [LMS] SET  MULTI_USER
GO
ALTER DATABASE [LMS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [LMS] SET DB_CHAINING OFF
GO
USE [LMS]
GO
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RoleMaster](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_RoleMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[RoleMaster] ON
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'SuperAdmin', 0, 1, CAST(0x0000ACD20073EE67 AS DateTime), 0, CAST(0x0000ACD20073EE67 AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Admin', 0, 2, CAST(0x0000ACD20073F4D6 AS DateTime), 0, CAST(0x0000ACD20073EE67 AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Librarian', 0, 3, CAST(0x0000ACD20074015C AS DateTime), 0, CAST(0x0000ACD20073EE67 AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'Staff', 0, 4, CAST(0x0000ACD20074090C AS DateTime), 0, CAST(0x0000ACD20073EE67 AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Student', 0, 0, CAST(0x0000ACDD002478FB AS DateTime), 1, CAST(0x0000ACDD002478FB AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (8, N'Other1', 0, 0, CAST(0x0000ACDD000871AA AS DateTime), 1, CAST(0x0000ACDD000871AA AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (9, N'Other2', 0, 0, CAST(0x0000ACDD0024CFAB AS DateTime), 1, CAST(0x0000ACDD0024CFAB AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (10, N'Other3', 0, 0, CAST(0x0000ACDD000DCDE4 AS DateTime), 1, CAST(0x0000ACDD000DCDE4 AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (11, N'Other4', 0, 0, CAST(0x0000ACDD00256B34 AS DateTime), 1, CAST(0x0000ACDD00256B34 AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (12, N'Other', 1, 1, CAST(0x0000ACDD00135624 AS DateTime), 0, CAST(0x0000ACDD00135624 AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (13, N'Other', 0, 1, CAST(0x0000ACDD00141167 AS DateTime), 0, CAST(0x0000ACDD00141167 AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (14, N'Other2', 0, 1, CAST(0x0000ACDD00142784 AS DateTime), 0, CAST(0x0000ACDD00142784 AS DateTime))
INSERT [dbo].[RoleMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (15, N'Other2', 0, 1, CAST(0x0000ACDD00147C8F AS DateTime), 0, CAST(0x0000ACDD00147C8F AS DateTime))
SET IDENTITY_INSERT [dbo].[RoleMaster] OFF
/****** Object:  Table [dbo].[PasswordHistory]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PasswordHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OldPassword] [nvarchar](50) NOT NULL,
	[NewPassword] [nvarchar](50) NOT NULL,
	[ModifyingSource] [varchar](10) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_PasswordHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FormTypeMaster]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FormTypeMaster](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[DisplayOrder] [tinyint] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_FormTypeMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FormTypeMaster] ON
INSERT [dbo].[FormTypeMaster] ([Id], [Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Login', 1, 0, 1, CAST(0x0000ACD600B1AF88 AS DateTime), 0, CAST(0x0000ACD600B1AF88 AS DateTime))
INSERT [dbo].[FormTypeMaster] ([Id], [Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Profile', 2, 0, 1, CAST(0x0000ACD600B1B21F AS DateTime), 0, CAST(0x0000ACD600B1AF88 AS DateTime))
INSERT [dbo].[FormTypeMaster] ([Id], [Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Master', 3, 0, 1, CAST(0x0000ACD600B1B58D AS DateTime), 0, CAST(0x0000ACD600B1AF88 AS DateTime))
INSERT [dbo].[FormTypeMaster] ([Id], [Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'Settings', 4, 0, 1, CAST(0x0000ACD600B1BA0A AS DateTime), 0, CAST(0x0000ACD600B1AF88 AS DateTime))
INSERT [dbo].[FormTypeMaster] ([Id], [Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Book', 5, 0, 1, CAST(0x0000ACD600B1C71A AS DateTime), 0, CAST(0x0000ACD600B1AF88 AS DateTime))
INSERT [dbo].[FormTypeMaster] ([Id], [Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (6, N'Fine', 6, 0, 1, CAST(0x0000ACD600B1C983 AS DateTime), 0, CAST(0x0000ACD600B1AF88 AS DateTime))
SET IDENTITY_INSERT [dbo].[FormTypeMaster] OFF
/****** Object:  Table [dbo].[FormMaster]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FormMaster](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[FormTypeId] [tinyint] NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Path] [varchar](50) NOT NULL,
	[DisplayOrder] [tinyint] NOT NULL,
	[ReadAccess] [varchar](50) NULL,
	[WriteAccess] [varchar](10) NOT NULL,
	[SpecialReadAccess] [varchar](100) NULL,
	[SpecialWriteAccess] [varchar](100) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_FormMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FormMaster] ON
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, 1, N'Login', N'/Login/Login', 1, N'0', N'0', NULL, NULL, 1, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, 1, N'Forgot Password', N'/Login/ForgotPassword', 2, N'0', N'0', NULL, NULL, 1, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, 1, N'Reset Passwrod', N'/Login/ResetPassword', 3, N'0', N'0', NULL, NULL, 1, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, 2, N'Update Profile', N'/Profile/UpdateProfile', 1, N'0', N'0', NULL, NULL, 1, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, 2, N'Change Password', N'/Profile/ChangePassword', 2, N'0', N'0', NULL, NULL, 1, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (6, 2, N'Log Out', N'/Profile/LogOut', 3, N'0', N'0', NULL, NULL, 1, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (7, 3, N'Author', N'/AuthorMaster/Index', 1, N'2,3', N'2', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (8, 3, N'Book Type', N'/BookTypeMaster/Index', 3, N'2,3', N'2', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (10, 3, N'Book', N'BookMaster/Index', 4, N'0', N'2', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (11, 3, N'User', N'UserMaster/Index', 8, N'2', N'2', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (12, 4, N'Carousel', N'/Settings/Carousel', 1, N'2,3', N'2,3', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (13, 4, N'Fine Manager', N'/Settings/FineManager', 2, N'2,3', N'2,3', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (14, 4, N'Role Access', N'/Settings/RoleAccess', 3, N'1', N'2', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (16, 5, N'Search Book', N'/Book/Search', 1, N'0', N'0', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (17, 5, N'Reserve Book', N'/Book/Reserve', 2, N'0', N'0', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (18, 5, N'Issue Book', N'/Book/Issue', 3, N'3', N'3', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (19, 5, N'Add to wishlist', N'/Book/AddToWishlist', 4, N'0', N'0', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (20, 6, N'Pending Fine', N'/Fine/Pending', 1, N'0', N'0', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (21, 6, N'Fine History', N'/Fine/History', 2, N'0', N'0', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (22, 6, N'Get Fine', N'/Fine/GetFine', 3, N'3', N'3', NULL, NULL, 0, 1, CAST(0x0000ACD600B39F1A AS DateTime), 0, CAST(0x0000ACD8017371A5 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (23, 3, N'Book Code', N'BookCodeMaster/Index', 5, N'2,3', N'2', NULL, NULL, 0, 1, CAST(0x0000ACDB010D6EF8 AS DateTime), 0, CAST(0x0000ACDB010D6EF8 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (24, 3, N'Book Fine', N'BookFineMaster/Index', 6, N'2,3', N'2', NULL, NULL, 0, 1, CAST(0x0000ACDB010D97A7 AS DateTime), 0, CAST(0x0000ACDB010D97A7 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (25, 3, N'Fine Type', N'FineTypeMaster/Index', 7, N'2,3', N'2', NULL, NULL, 0, 1, CAST(0x0000ACDB010E0564 AS DateTime), 0, CAST(0x0000ACDB010E0564 AS DateTime))
INSERT [dbo].[FormMaster] ([Id], [FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (28, 3, N'Role Master', N'RoleMaster/Index', 2, N'2', N'0', NULL, NULL, 0, 1, CAST(0x0000ACDB010E5CBE AS DateTime), 0, CAST(0x0000ACDB010E5CBE AS DateTime))
SET IDENTITY_INSERT [dbo].[FormMaster] OFF
/****** Object:  Table [dbo].[FineTypeMaster]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FineTypeMaster](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](10) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_FineTypeMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FineTypeMaster] ON
INSERT [dbo].[FineTypeMaster] ([Id], [Type], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Demage', 0, 1, CAST(0x0000ACD200813251 AS DateTime), 0, CAST(0x0000ACD200813251 AS DateTime))
INSERT [dbo].[FineTypeMaster] ([Id], [Type], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Lost', 0, 1, CAST(0x0000ACD20081361A AS DateTime), 0, CAST(0x0000ACD200813251 AS DateTime))
INSERT [dbo].[FineTypeMaster] ([Id], [Type], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'LateReturn', 0, 1, CAST(0x0000ACD200815CC4 AS DateTime), 0, CAST(0x0000ACD200813251 AS DateTime))
SET IDENTITY_INSERT [dbo].[FineTypeMaster] OFF
/****** Object:  Table [dbo].[FinePayment]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FinePayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FineTypeId] [tinyint] NOT NULL,
	[BookId] [int] NOT NULL,
	[PaidBy] [int] NOT NULL,
	[BaseAmount] [smallint] NOT NULL,
	[FinalAmount] [smallint] NOT NULL,
	[PaidAmount] [smallint] NOT NULL,
	[ExemptionAmount] [smallint] NOT NULL,
	[PaymentReceiptNo] [varchar](20) NOT NULL,
	[PaidOn] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_FinePayment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookTypeMaster]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookTypeMaster](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[PriceDepreciationTime] [tinyint] NULL,
	[PriceDepreciationRate] [tinyint] NULL,
	[MaxDepreciationRate] [tinyint] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_BookTypeMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BookTypeMaster] ON
INSERT [dbo].[BookTypeMaster] ([Id], [Type], [PriceDepreciationTime], [PriceDepreciationRate], [MaxDepreciationRate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Academic', 12, 10, 50, 0, 1, CAST(0x0000ACD2007343CC AS DateTime), 0, CAST(0x0000ACD2007343CC AS DateTime))
INSERT [dbo].[BookTypeMaster] ([Id], [Type], [PriceDepreciationTime], [PriceDepreciationRate], [MaxDepreciationRate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Magazine', 1, 75, 25, 0, 1, CAST(0x0000ACD200734E29 AS DateTime), 0, CAST(0x0000ACD2007343CC AS DateTime))
INSERT [dbo].[BookTypeMaster] ([Id], [Type], [PriceDepreciationTime], [PriceDepreciationRate], [MaxDepreciationRate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Novel', 12, 5, 33, 0, 1, CAST(0x0000ACD200735273 AS DateTime), 0, CAST(0x0000ACD2007343CC AS DateTime))
INSERT [dbo].[BookTypeMaster] ([Id], [Type], [PriceDepreciationTime], [PriceDepreciationRate], [MaxDepreciationRate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'CD/DVD', 1, 75, 25, 0, 1, CAST(0x0000ACD20073740F AS DateTime), 0, CAST(0x0000ACD2007343CC AS DateTime))
INSERT [dbo].[BookTypeMaster] ([Id], [Type], [PriceDepreciationTime], [PriceDepreciationRate], [MaxDepreciationRate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (6, N'Other', 12, 10, 25, 0, 1, CAST(0x0000ACD20077C848 AS DateTime), 0, CAST(0x0000ACD2007343CC AS DateTime))
SET IDENTITY_INSERT [dbo].[BookTypeMaster] OFF
/****** Object:  Table [dbo].[BookMaster]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookTypeId] [tinyint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[AuthorId] [int] NOT NULL,
	[Publisher] [varchar](50) NULL,
	[PublishDate] [datetime] NULL,
	[Edition] [varchar](50) NULL,
	[ISBN] [varchar](25) NULL,
	[Price] [int] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_BookMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookIssue]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookIssue](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookCodeId] [int] NOT NULL,
	[IssuedFor] [int] NOT NULL,
	[IssuedBy] [int] NOT NULL,
	[IssuedOn] [datetime] NOT NULL,
	[ReceivedBy] [int] NULL,
	[ReturnedOn] [date] NULL,
	[Remarks] [nvarchar](200) NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_BookIssue] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookFineMaster]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookFineMaster](
	[Id] [tinyint] NOT NULL,
	[BookTypeId] [tinyint] NOT NULL,
	[LateFeeBaseChargeAmount] [tinyint] NOT NULL,
	[LateFeeBaseChargePercent] [tinyint] NOT NULL,
	[LateFeeIncreaseAmount] [tinyint] NOT NULL,
	[LateFeeIncreasePercentage] [tinyint] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_BookFineMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookCodeMaster]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookCodeMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[BookCode] [varchar](50) NOT NULL,
	[IsIssued] [bit] NOT NULL,
	[IsLost] [bit] NOT NULL,
	[IsDamaged] [bit] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_BookCodeMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AuthorMaster]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_AuthorMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AuthorMaster] ON
INSERT [dbo].[AuthorMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Premchand', 0, 1, CAST(0x0000ACDC0090BBD1 AS DateTime), 0, CAST(0x0000ACDC0090BBD1 AS DateTime))
INSERT [dbo].[AuthorMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (14, N'Zaverchand Meghani', 0, 1, CAST(0x0000ACDC012A75FD AS DateTime), 0, CAST(0x0000ACDC012A75FD AS DateTime))
INSERT [dbo].[AuthorMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (15, N'Amit', 0, 1, CAST(0x0000ACDC01378A59 AS DateTime), 0, CAST(0x0000ACDC01378A59 AS DateTime))
INSERT [dbo].[AuthorMaster] ([Id], [Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (16, N'Amit Anjar', 0, 0, CAST(0x0000ACDC013888C1 AS DateTime), 0, CAST(0x0000ACDC013888C1 AS DateTime))
SET IDENTITY_INSERT [dbo].[AuthorMaster] OFF
/****** Object:  Table [dbo].[UserMaster]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[RoleId] [tinyint] NOT NULL,
	[FailAttempt] [tinyint] NOT NULL,
	[IsBlocked] [bit] NOT NULL,
	[BlockReason] [varchar](200) NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[LastLogoutDate] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_UserMaster_1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[UserMaster] ON
INSERT [dbo].[UserMaster] ([UserId], [UserName], [Password], [Email], [RoleId], [FailAttempt], [IsBlocked], [BlockReason], [LastLoginDate], [LastLogoutDate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'amitsorathiya', N'amitsorathiya', N'the.fake.co.in@gmail.com', 1, 0, 0, NULL, CAST(0x0000ACAD00A6551A AS DateTime), CAST(0x0000ACAD00A6551A AS DateTime), 0, 0, CAST(0x0000ACAD00A6551A AS DateTime), 0, CAST(0x0000ACAD00A6551A AS DateTime))
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
/****** Object:  Table [dbo].[UserInfo]    Script Date: 02/28/2021 21:00:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Userid] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[Gender] [char](1) NOT NULL,
	[DateOfBirth] [date] NOT NULL,
	[MobileNo] [varchar](20) NULL,
	[HomeContactNo] [varchar](20) NULL,
	[Address1] [nvarchar](100) NULL,
	[Address2] [nvarchar](100) NOT NULL,
	[City] [nvarchar](50) NULL,
	[State] [nvarchar](50) NULL,
	[Country] [nvarchar](50) NULL,
	[Pincode] [varchar](10) NULL,
	[DateOfJoin] [date] NOT NULL,
	[ImagePath] [varchar](100) NULL,
 CONSTRAINT [PK_UserInfo_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[UserInfo] ON
INSERT [dbo].[UserInfo] ([Id], [Userid], [FirstName], [MiddleName], [LastName], [Gender], [DateOfBirth], [MobileNo], [HomeContactNo], [Address1], [Address2], [City], [State], [Country], [Pincode], [DateOfJoin], [ImagePath]) VALUES (1, 1, N'Amit', N'P', N'Sorathiya', N'M', CAST(0x5B950A00 AS Date), N'1234567890', N'9876543210', N'Address1', N'1', N'Vadodara', N'Gujarat', N'India', N'390021', CAST(0xB63D0B00 AS Date), NULL)
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
/****** Object:  View [dbo].[UserDetail]    Script Date: 02/28/2021 21:00:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserDetail]
AS
SELECT     dbo.UserMaster.UserId, dbo.UserMaster.UserName, dbo.UserMaster.Email, dbo.UserMaster.RoleId, dbo.UserMaster.FailAttempt, dbo.UserMaster.IsBlocked, 
                      dbo.UserMaster.IsDeleted, dbo.UserInfo.FirstName, dbo.UserInfo.MiddleName, dbo.UserInfo.LastName, dbo.UserInfo.Gender, dbo.UserInfo.DateOfBirth, 
                      dbo.UserInfo.MobileNo, dbo.UserInfo.HomeContactNo, dbo.UserInfo.Address1, dbo.UserInfo.Address2, dbo.UserInfo.City, dbo.UserInfo.State, dbo.UserInfo.Country, 
                      dbo.UserInfo.Pincode, dbo.UserInfo.DateOfJoin, dbo.UserInfo.ImagePath, dbo.UserMaster.Password, dbo.UserMaster.BlockReason, dbo.UserMaster.LastLoginDate, 
                      dbo.UserMaster.LastLogoutDate, dbo.UserMaster.CreatedBy, dbo.UserMaster.CreatedOn, dbo.UserMaster.ModifiedBy, dbo.UserMaster.ModifiedOn
FROM         dbo.UserMaster INNER JOIN
                      dbo.UserInfo ON dbo.UserMaster.UserId = dbo.UserInfo.Userid
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "UserMaster"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 229
               Right = 194
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "UserInfo"
            Begin Extent = 
               Top = 6
               Left = 232
               Bottom = 227
               Right = 390
            End
            DisplayFlags = 280
            TopColumn = 6
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserDetail'
GO
/****** Object:  Default [DF_RoleMaster_IsDeleted]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_RoleMaster_CreatedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_CreatedBy]  DEFAULT ((1)) FOR [CreatedBy]
GO
/****** Object:  Default [DF_RoleMaster_CreatedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_RoleMaster_ModifiedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_RoleMaster_ModifiedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_PasswordHistory_ModifySource]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[PasswordHistory] ADD  CONSTRAINT [DF_PasswordHistory_ModifySource]  DEFAULT ('Unknown') FOR [ModifyingSource]
GO
/****** Object:  Default [DF_PasswordHistory_ModifyDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[PasswordHistory] ADD  CONSTRAINT [DF_PasswordHistory_ModifyDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_FormTypeMaster_IsDeleted]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FormTypeMaster] ADD  CONSTRAINT [DF_FormTypeMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_FormTypeMaster_CreatedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FormTypeMaster] ADD  CONSTRAINT [DF_FormTypeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_FormMaster_RoleAccess]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_RoleAccess]  DEFAULT ((0)) FOR [WriteAccess]
GO
/****** Object:  Default [DF_FormMaster_IsDeleted]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_FormMaster_CreatedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_CreatedBy]  DEFAULT ((1)) FOR [CreatedBy]
GO
/****** Object:  Default [DF_FormMaster_CreatedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_FormMaster_ModifiedB]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_ModifiedB]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_FormMaster_ModifiedOn]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_FineTypeMaster_CreatedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FineTypeMaster] ADD  CONSTRAINT [DF_FineTypeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_FineTypeMaster_ModifiedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FineTypeMaster] ADD  CONSTRAINT [DF_FineTypeMaster_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_FineTypeMaster_ModifiedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FineTypeMaster] ADD  CONSTRAINT [DF_FineTypeMaster_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_FinePayment_IsFinePaid]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_IsFinePaid]  DEFAULT ((0)) FOR [PaymentReceiptNo]
GO
/****** Object:  Default [DF_FinePayment_IsDeleted]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_FinePayment_CreatedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_FinePayment_ModifiedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_FinePayment_ModifiedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_BookTypeMaster_IsDeleted]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookTypeMaster] ADD  CONSTRAINT [DF_BookTypeMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookTypeMaster_CreatedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookTypeMaster] ADD  CONSTRAINT [DF_BookTypeMaster_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
/****** Object:  Default [DF_BookTypeMaster_CreatedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookTypeMaster] ADD  CONSTRAINT [DF_BookTypeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_BookMaster_BookAuthor]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookMaster] ADD  CONSTRAINT [DF_BookMaster_BookAuthor]  DEFAULT ((1)) FOR [AuthorId]
GO
/****** Object:  Default [DF_BookMaster_IsDeleted]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookMaster] ADD  CONSTRAINT [DF_BookMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookIssue_IssuedOn]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookIssue] ADD  CONSTRAINT [DF_BookIssue_IssuedOn]  DEFAULT (getdate()) FOR [IssuedOn]
GO
/****** Object:  Default [DF_BookIssue_IsDeleted]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookIssue] ADD  CONSTRAINT [DF_BookIssue_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookIssue_CreatedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookIssue] ADD  CONSTRAINT [DF_BookIssue_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_BookIssue_ModifiedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookIssue] ADD  CONSTRAINT [DF_BookIssue_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_BookIssue_ModifiedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookIssue] ADD  CONSTRAINT [DF_BookIssue_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_BookFineMaster_IsDeleted]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookFineMaster] ADD  CONSTRAINT [DF_BookFineMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookFineMaster_CreatedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookFineMaster] ADD  CONSTRAINT [DF_BookFineMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_BookFineMaster_ModifiedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookFineMaster] ADD  CONSTRAINT [DF_BookFineMaster_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_BookFineMaster_ModifiedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookFineMaster] ADD  CONSTRAINT [DF_BookFineMaster_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_BookCodeMaster_IsLost]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_IsLost]  DEFAULT ((0)) FOR [IsIssued]
GO
/****** Object:  Default [DF_BookCodeMaster_IsLost_1]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_IsLost_1]  DEFAULT ((0)) FOR [IsLost]
GO
/****** Object:  Default [DF_BookCodeMaster_IsDamaged]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_IsDamaged]  DEFAULT ((0)) FOR [IsDamaged]
GO
/****** Object:  Default [DF_BookCodeMaster_IsDeleted_1]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_IsDeleted_1]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookCodeMaster_CreatedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_BookCodeMaster_ModifiedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_BookCodeMaster_ModifiedDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_AuthorMaster_IsDeleted]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[AuthorMaster] ADD  CONSTRAINT [DF_AuthorMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_AuthorMaster_CreatedOn]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[AuthorMaster] ADD  CONSTRAINT [DF_AuthorMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_AuthorMaster_ModifiedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[AuthorMaster] ADD  CONSTRAINT [DF_AuthorMaster_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_AuthorMaster_ModifiedOn]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[AuthorMaster] ADD  CONSTRAINT [DF_AuthorMaster_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_UserMaster_FailAttempt]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_FailAttempt]  DEFAULT ((0)) FOR [FailAttempt]
GO
/****** Object:  Default [DF_UserMaster_IsBlocked]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_IsBlocked]  DEFAULT ((0)) FOR [IsBlocked]
GO
/****** Object:  Default [DF_UserMaster_LastLoginDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_LastLoginDate]  DEFAULT (getdate()) FOR [LastLoginDate]
GO
/****** Object:  Default [DF_UserMaster_LastLogoutDate]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_LastLogoutDate]  DEFAULT (getdate()) FOR [LastLogoutDate]
GO
/****** Object:  Default [DF_UserMaster_IsDeleted]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_UserMaster_CreatedBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
/****** Object:  Default [DF_UserMaster_CreatedOn]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_UserMaster_ModifyBy]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_ModifyBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_UserMaster_ModifyOn]    Script Date: 02/28/2021 21:00:43 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_ModifyOn]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
