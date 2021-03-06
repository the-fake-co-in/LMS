USE [master]
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
/****** Object:  Table [dbo].[RoleMaster]    Script Date: 04/15/2021 11:49:34 ******/
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
/****** Object:  Table [dbo].[PasswordHistory]    Script Date: 04/15/2021 11:49:34 ******/
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
/****** Object:  Table [dbo].[OTPDetails]    Script Date: 04/15/2021 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OTPDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[OTP] [varchar](5) NOT NULL,
	[ExpiresOn] [datetime] NOT NULL,
 CONSTRAINT [PK_OTPDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GlobalSettings]    Script Date: 04/15/2021 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GlobalSettings](
	[Emailid] [varchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FormTypeMaster]    Script Date: 04/15/2021 11:49:34 ******/
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
/****** Object:  Table [dbo].[FormMaster]    Script Date: 04/15/2021 11:49:34 ******/
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
/****** Object:  Table [dbo].[FineTypeMaster]    Script Date: 04/15/2021 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FineTypeMaster](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](25) NOT NULL,
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
/****** Object:  Table [dbo].[FinePayment]    Script Date: 04/15/2021 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FinePayment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookIssueId] [int] NOT NULL,
	[FineTypeId] [tinyint] NOT NULL,
	[PaymentReceiptNo] [varchar](20) NOT NULL,
	[BaseAmount] [smallint] NOT NULL,
	[FinalAmount] [smallint] NOT NULL,
	[ExemptionAmount] [smallint] NOT NULL,
	[PaidAmount] [smallint] NOT NULL,
	[PaidOn] [datetime] NOT NULL,
	[PaymentReceivedBy] [int] NOT NULL,
	[Remarks] [varchar](250) NULL,
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
/****** Object:  Table [dbo].[BookWishList]    Script Date: 04/15/2021 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BookWishList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [varchar](100) NOT NULL,
	[BookDetails] [varchar](250) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [int] NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_BookWishList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BookTypeMaster]    Script Date: 04/15/2021 11:49:34 ******/
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
/****** Object:  Table [dbo].[BookReservation]    Script Date: 04/15/2021 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookReservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookCodeId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ReservedOn] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_BookReservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookMaster]    Script Date: 04/15/2021 11:49:34 ******/
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
/****** Object:  Table [dbo].[BookIssue]    Script Date: 04/15/2021 11:49:34 ******/
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
	[ReturnedOn] [datetime] NULL,
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
/****** Object:  Table [dbo].[BookFineMaster]    Script Date: 04/15/2021 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookFineMaster](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[BookTypeId] [tinyint] NOT NULL,
	[FineTypeId] [tinyint] NOT NULL,
	[LateFeeBaseChargeAmount] [int] NOT NULL,
	[LateFeeBaseChargePercent] [tinyint] NOT NULL,
	[LateFeeIncreaseAmount] [int] NOT NULL,
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
/****** Object:  Table [dbo].[BookCodeMaster]    Script Date: 04/15/2021 11:49:34 ******/
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
/****** Object:  Table [dbo].[AuthorMaster]    Script Date: 04/15/2021 11:49:34 ******/
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
/****** Object:  Table [dbo].[UserMaster]    Script Date: 04/15/2021 11:49:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserMaster](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](130) NOT NULL,
	[Email] [varchar](100) NOT NULL,
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
/****** Object:  Table [dbo].[UserInfo]    Script Date: 04/15/2021 11:49:34 ******/
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
 CONSTRAINT [PK_UserInfo_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[UserDetail]    Script Date: 04/15/2021 11:49:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserDetail]
AS
SELECT     dbo.UserMaster.UserId, dbo.UserMaster.UserName, dbo.UserMaster.Email, dbo.UserMaster.RoleId, dbo.UserMaster.FailAttempt, dbo.UserMaster.IsBlocked, 
                      dbo.UserMaster.IsDeleted, dbo.UserInfo.FirstName, dbo.UserInfo.MiddleName, dbo.UserInfo.LastName, dbo.UserInfo.Gender, dbo.UserInfo.DateOfBirth, 
                      dbo.UserInfo.MobileNo, dbo.UserInfo.HomeContactNo, dbo.UserInfo.Address1, dbo.UserInfo.Address2, dbo.UserInfo.City, dbo.UserInfo.State, dbo.UserInfo.Country, 
                      dbo.UserInfo.Pincode, dbo.UserInfo.DateOfJoin, dbo.UserMaster.Password, dbo.UserMaster.BlockReason, dbo.UserMaster.LastLoginDate, 
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
/****** Object:  StoredProcedure [dbo].[SP_GetBookFineMaster]    Script Date: 04/15/2021 11:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetBookFineMaster]
As
BEGIN
	Select	BFM.Id,BFM.BookTypeId,BTM.[Type] BookType,BFM.FineTypeId,FTM.[Type] FineType,
			BFM.LateFeeBaseChargeAmount,BFM.LateFeeBaseChargePercent,BFM.LateFeeIncreaseAmount,
			BFM.LateFeeIncreasePercentage,
			BFM.IsDeleted,BFM.CreatedBy,BFM.CreatedOn,BFM.ModifiedBy,BFM.ModifiedOn
	From	BookFineMaster BFM
			Inner Join BookTypeMaster BTM On BFM.BookTypeId = BTM.Id And BTM.IsDeleted= 0
			Inner Join FineTypeMaster FTM On BFM.FineTypeId = FTM.Id And FTM.IsDeleted = 0
End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetBookCodeMaster]    Script Date: 04/15/2021 11:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetBookCodeMaster]
As
BEGIN
	Select	BCM.Id, BCM.BookId, BM.Name BookName, BCM.BookCode, BCM.IsIssued,
			BCM.IsLost, BCM.IsDamaged, BCM.IsDeleted,
			BCM.CreatedBy,BCM.CreatedOn,BCM.ModifiedBy,BCM.ModifiedOn
	From	BookCodeMaster BCM
			Inner Join BookMaster BM On BCM.BookId = BM.Id And BM.IsDeleted= 0
End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetBookAvailability]    Script Date: 04/15/2021 11:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetBookAvailability]
As
BEGIN
	Select	BM.Id,BM.BookTypeId,BTM.[TYPE] BookType,BM.Name BookName,BM.AuthorId,
			AM.Name AuthorName,BM.Publisher,BM.PublishDate,BM.Edition,BM.ISBN,BM.Price,
			Cast(0 as bit) As IsAlreadyReserved, Cast(0 as bit) As IsAvailable
	From	BookMaster BM
			Inner Join BookTypeMaster BTM On BM.BookTypeId = BTM.Id And BTM.IsDeleted= 0
			Left Join AuthorMaster AM On BM.AuthorId = AM.Id And AM.IsDeleted= 0
End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetBookMaster]    Script Date: 04/15/2021 11:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetBookMaster]
As
BEGIN
	Select	BM.Id,BM.BookTypeId,BTM.[TYPE] BookType,BM.Name BookName,BM.AuthorId,
			AM.Name AuthorName,BM.Publisher,BM.PublishDate,BM.Edition,BM.ISBN,BM.Price,
			BM.IsDeleted,BM.CreatedBy,BM.CreatedOn,BM.ModifiedBy,BM.ModifiedOn
	From	BookMaster BM
			Inner Join BookTypeMaster BTM On BM.BookTypeId = BTM.Id And BTM.IsDeleted= 0
			Left Join AuthorMaster AM On BM.AuthorId = AM.Id And AM.IsDeleted= 0
End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetFormMaster]    Script Date: 04/15/2021 11:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetFormMaster]
As
BEGIN
	Select	FM.Id,FM.FormTypeId,FTM.[Type] FormType,FM.Name,FM.[Path],FM.DisplayOrder,
			FM.ReadAccess,FM.WriteAccess,FM.SpecialReadAccess,FM.SpecialWriteAccess,
			FM.IsDeleted,FM.CreatedBy,FM.CreatedOn,FM.ModifiedBy,FM.ModifiedOn
	From	FormMaster FM
			Inner Join FormTypeMaster FTM On FM.FormTypeId = FTM.Id And FTM.IsDeleted= 0
End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetFinePayment]    Script Date: 04/15/2021 11:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetFinePayment]
As
BEGIN
	Select	BI.Id, BCM.BookCode, BM.Name BookName, BTM.[Type] BookType,
			U1.FirstName + ' ' + U1.LastName PaidBy, IsNull(FP.BaseAmount,0)BaseAmount,
			IsNull(FP.FinalAmount,0)FinalAmount,IsNull(FP.ExemptionAmount,0)ExemptionAmount,
			IsNull(FP.PaidAmount,0)PaidAmount, FP.PaidOn, FP.PaymentReceiptNo,
			U2.FirstName + ' ' + U2.LastName PaymentReceivedBy, FP.Remarks,
			IsNull(FP.IsDeleted,0)IsDeleted
	From	BookIssue BI
			Inner Join BookCodeMaster BCM On BI.BookCodeId = BCM.Id
			Inner Join BookMaster BM On BM.Id = BCM.BookId
			Inner Join BookTypeMaster BTM On BM.BookTypeId = BTM.Id
			Inner Join UserDetail U1 On U1.UserId = BI.IssuedFor
			Left Join FinePayment FP On FP.BookIssueId = BI.Id
			Left Join FineTypeMaster FTM On FP.FineTypeId = FTM.Id
			Left Join UserDetail U2 On U2.UserId = FP.PaymentReceivedBy
	Where	(datediff(day, BI.IssuedOn, GetDate()) > 7) or FP.Id IS NOT NULL
End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetBookIssue]    Script Date: 04/15/2021 11:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetBookIssue]
As
BEGIN
	Select	BI.Id, BI.BookCodeId, BCM.BookCode, BM.Name BookName, BTM.[Type] BookType,
			AM.Name AuthorName, BM.Publisher, BI.IssuedFor,
			U1.FirstName + ' ' + U1.LastName IssuedForName, 
			BI.IssuedBy, U2.FirstName + ' ' + U2.LastName IssuedByName,BI.IssuedOn,
			BI.ReceivedBy, IsNull(U3.FirstName + ' ' + U3.LastName,'') ReceivedByName, BI.ReturnedOn,
			BI.Remarks, BI.IsDeleted
	From	BookIssue BI
			Inner Join BookCodeMaster BCM On BI.BookCodeId = BCM.Id
			Inner Join BookMaster BM On BM.Id = BCM.BookId
			Inner Join BookTypeMaster BTM On BM.BookTypeId = BTM.Id
			Inner Join AuthorMaster AM On BM.AuthorId = AM.Id
			Inner Join UserDetail U1 On U1.UserId = BI.IssuedFor
			Inner Join UserDetail U2 On U2.UserId = BI.IssuedBy
			Left Join UserDetail U3 On U3.UserId = BI.ReceivedBy
End
GO
/****** Object:  StoredProcedure [dbo].[SP_GetPasswordHistory]    Script Date: 04/15/2021 11:49:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetPasswordHistory]
As
BEGIN
	Select	PH.Id,PH.UserId,UD.UserName, UD.FirstName + ' ' + UD.LastName,
			PH.OldPassword, PH.NewPassword,PH.ModifyingSource,PH.ModifiedOn
	From	PasswordHistory PH
			Inner Join UserDetail UD On PH.UserId = UD.UserId
End
GO
/****** Object:  Default [DF_RoleMaster_IsDeleted]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_RoleMaster_CreatedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_CreatedBy]  DEFAULT ((1)) FOR [CreatedBy]
GO
/****** Object:  Default [DF_RoleMaster_CreatedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_RoleMaster_ModifiedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_RoleMaster_ModifiedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[RoleMaster] ADD  CONSTRAINT [DF_RoleMaster_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_PasswordHistory_ModifySource]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[PasswordHistory] ADD  CONSTRAINT [DF_PasswordHistory_ModifySource]  DEFAULT ('Unknown') FOR [ModifyingSource]
GO
/****** Object:  Default [DF_PasswordHistory_ModifyDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[PasswordHistory] ADD  CONSTRAINT [DF_PasswordHistory_ModifyDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_FormTypeMaster_IsDeleted]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FormTypeMaster] ADD  CONSTRAINT [DF_FormTypeMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_FormTypeMaster_CreatedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FormTypeMaster] ADD  CONSTRAINT [DF_FormTypeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_FormMaster_RoleAccess]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_RoleAccess]  DEFAULT ((0)) FOR [WriteAccess]
GO
/****** Object:  Default [DF_FormMaster_IsDeleted]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_FormMaster_CreatedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_CreatedBy]  DEFAULT ((1)) FOR [CreatedBy]
GO
/****** Object:  Default [DF_FormMaster_CreatedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_FormMaster_ModifiedB]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_ModifiedB]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_FormMaster_ModifiedOn]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FormMaster] ADD  CONSTRAINT [DF_FormMaster_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_FineTypeMaster_CreatedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FineTypeMaster] ADD  CONSTRAINT [DF_FineTypeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_FineTypeMaster_ModifiedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FineTypeMaster] ADD  CONSTRAINT [DF_FineTypeMaster_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_FineTypeMaster_ModifiedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FineTypeMaster] ADD  CONSTRAINT [DF_FineTypeMaster_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_FinePayment_IsFinePaid]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_IsFinePaid]  DEFAULT ((0)) FOR [PaymentReceiptNo]
GO
/****** Object:  Default [DF_FinePayment_ExemptionAmount]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_ExemptionAmount]  DEFAULT ((0)) FOR [ExemptionAmount]
GO
/****** Object:  Default [DF_FinePayment_PaidOn]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_PaidOn]  DEFAULT (getdate()) FOR [PaidOn]
GO
/****** Object:  Default [DF_FinePayment_IsDeleted]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_FinePayment_CreatedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_FinePayment_ModifiedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_FinePayment_ModifiedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[FinePayment] ADD  CONSTRAINT [DF_FinePayment_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_Table_1_IsActive]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookWishList] ADD  CONSTRAINT [DF_Table_1_IsActive]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookWishList_CreatedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookWishList] ADD  CONSTRAINT [DF_BookWishList_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
/****** Object:  Default [DF_BookWishList_AddedOn]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookWishList] ADD  CONSTRAINT [DF_BookWishList_AddedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_BookWishList_ModifiedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookWishList] ADD  CONSTRAINT [DF_BookWishList_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_BookWishList_ModifiedOn]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookWishList] ADD  CONSTRAINT [DF_BookWishList_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_BookTypeMaster_IsDeleted]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookTypeMaster] ADD  CONSTRAINT [DF_BookTypeMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookTypeMaster_CreatedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookTypeMaster] ADD  CONSTRAINT [DF_BookTypeMaster_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
/****** Object:  Default [DF_BookTypeMaster_CreatedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookTypeMaster] ADD  CONSTRAINT [DF_BookTypeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_BookReservation_ReservedOn]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookReservation] ADD  CONSTRAINT [DF_BookReservation_ReservedOn]  DEFAULT (getdate()) FOR [ReservedOn]
GO
/****** Object:  Default [DF_BookReservation_IsActive]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookReservation] ADD  CONSTRAINT [DF_BookReservation_IsActive]  DEFAULT ((1)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookMaster_BookAuthor]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookMaster] ADD  CONSTRAINT [DF_BookMaster_BookAuthor]  DEFAULT ((1)) FOR [AuthorId]
GO
/****** Object:  Default [DF_BookMaster_IsDeleted]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookMaster] ADD  CONSTRAINT [DF_BookMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookIssue_IssuedOn]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookIssue] ADD  CONSTRAINT [DF_BookIssue_IssuedOn]  DEFAULT (getdate()) FOR [IssuedOn]
GO
/****** Object:  Default [DF_BookIssue_IsDeleted]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookIssue] ADD  CONSTRAINT [DF_BookIssue_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookIssue_CreatedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookIssue] ADD  CONSTRAINT [DF_BookIssue_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_BookIssue_ModifiedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookIssue] ADD  CONSTRAINT [DF_BookIssue_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_BookIssue_ModifiedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookIssue] ADD  CONSTRAINT [DF_BookIssue_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_BookFineMaster_IsDeleted]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookFineMaster] ADD  CONSTRAINT [DF_BookFineMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookFineMaster_CreatedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookFineMaster] ADD  CONSTRAINT [DF_BookFineMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_BookFineMaster_ModifiedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookFineMaster] ADD  CONSTRAINT [DF_BookFineMaster_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_BookFineMaster_ModifiedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookFineMaster] ADD  CONSTRAINT [DF_BookFineMaster_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_BookCodeMaster_IsLost]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_IsLost]  DEFAULT ((0)) FOR [IsIssued]
GO
/****** Object:  Default [DF_BookCodeMaster_IsLost_1]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_IsLost_1]  DEFAULT ((0)) FOR [IsLost]
GO
/****** Object:  Default [DF_BookCodeMaster_IsDamaged]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_IsDamaged]  DEFAULT ((0)) FOR [IsDamaged]
GO
/****** Object:  Default [DF_BookCodeMaster_IsDeleted_1]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_IsDeleted_1]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_BookCodeMaster_CreatedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_CreatedDate]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_BookCodeMaster_ModifiedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_BookCodeMaster_ModifiedDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[BookCodeMaster] ADD  CONSTRAINT [DF_BookCodeMaster_ModifiedDate]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_AuthorMaster_IsDeleted]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[AuthorMaster] ADD  CONSTRAINT [DF_AuthorMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_AuthorMaster_CreatedOn]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[AuthorMaster] ADD  CONSTRAINT [DF_AuthorMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_AuthorMaster_ModifiedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[AuthorMaster] ADD  CONSTRAINT [DF_AuthorMaster_ModifiedBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_AuthorMaster_ModifiedOn]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[AuthorMaster] ADD  CONSTRAINT [DF_AuthorMaster_ModifiedOn]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
/****** Object:  Default [DF_UserMaster_FailAttempt]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_FailAttempt]  DEFAULT ((0)) FOR [FailAttempt]
GO
/****** Object:  Default [DF_UserMaster_IsBlocked]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_IsBlocked]  DEFAULT ((0)) FOR [IsBlocked]
GO
/****** Object:  Default [DF_UserMaster_LastLoginDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_LastLoginDate]  DEFAULT (getdate()) FOR [LastLoginDate]
GO
/****** Object:  Default [DF_UserMaster_LastLogoutDate]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_LastLogoutDate]  DEFAULT (getdate()) FOR [LastLogoutDate]
GO
/****** Object:  Default [DF_UserMaster_IsDeleted]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
/****** Object:  Default [DF_UserMaster_CreatedBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_CreatedBy]  DEFAULT ((0)) FOR [CreatedBy]
GO
/****** Object:  Default [DF_UserMaster_CreatedOn]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_CreatedOn]  DEFAULT (getdate()) FOR [CreatedOn]
GO
/****** Object:  Default [DF_UserMaster_ModifyBy]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_ModifyBy]  DEFAULT ((0)) FOR [ModifiedBy]
GO
/****** Object:  Default [DF_UserMaster_ModifyOn]    Script Date: 04/15/2021 11:49:34 ******/
ALTER TABLE [dbo].[UserMaster] ADD  CONSTRAINT [DF_UserMaster_ModifyOn]  DEFAULT (getdate()) FOR [ModifiedOn]
GO
