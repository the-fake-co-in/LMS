Use LMS
Go
------------------------------------------------------------------------------------------------------------------------------

Truncate Table [UserMaster]
INSERT [dbo].[UserMaster] ([UserName], [Password], [Email], [RoleId], [FailAttempt], [IsBlocked], [BlockReason], [LastLoginDate], [LastLogoutDate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'superadmin', N'WlmdhimBZ0G7PORKYhxiCSmlT5asitGptdS01js7rk8H+AeBHYhzM+aQe9LiKAU3el7sn3ogVRNUDlSpbabLX2tzTCTWB5biJ+weL/+fbPrUX3brDtd6nesK8tfUn/9v', N'lms.sa.1234567@gmail.com', 1, 0, 0, NULL, GetDate(), GetDate(), 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[UserMaster] ([UserName], [Password], [Email], [RoleId], [FailAttempt], [IsBlocked], [BlockReason], [LastLoginDate], [LastLogoutDate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'admin', N'WlmdhimBZ0G7PORKYhxiCSmlT5asitGptdS01js7rk8H+AeBHYhzM+aQe9LiKAU3el7sn3ogVRNUDlSpbabLX2tzTCTWB5biJ+weL/+fbPrUX3brDtd6nesK8tfUn/9v', N'lms.sa.1234567@gmail.com', 2, 0, 0, NULL, GetDate(), GetDate(), 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[UserMaster] ([UserName], [Password], [Email], [RoleId], [FailAttempt], [IsBlocked], [BlockReason], [LastLoginDate], [LastLogoutDate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'librarian', N'WlmdhimBZ0G7PORKYhxiCSmlT5asitGptdS01js7rk8H+AeBHYhzM+aQe9LiKAU3el7sn3ogVRNUDlSpbabLX2tzTCTWB5biJ+weL/+fbPrUX3brDtd6nesK8tfUn/9v', N'lms.sa.1234567@gmail.com', 3, 0, 0, NULL, GetDate(), GetDate(), 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[UserMaster] ([UserName], [Password], [Email], [RoleId], [FailAttempt], [IsBlocked], [BlockReason], [LastLoginDate], [LastLogoutDate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'staff', N'WlmdhimBZ0G7PORKYhxiCSmlT5asitGptdS01js7rk8H+AeBHYhzM+aQe9LiKAU3el7sn3ogVRNUDlSpbabLX2tzTCTWB5biJ+weL/+fbPrUX3brDtd6nesK8tfUn/9v', N'lms.sa.1234567@gmail.com', 4, 0, 0, NULL, GetDate(), GetDate(), 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[UserMaster] ([UserName], [Password], [Email], [RoleId], [FailAttempt], [IsBlocked], [BlockReason], [LastLoginDate], [LastLogoutDate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'student', N'WlmdhimBZ0G7PORKYhxiCSmlT5asitGptdS01js7rk8H+AeBHYhzM+aQe9LiKAU3el7sn3ogVRNUDlSpbabLX2tzTCTWB5biJ+weL/+fbPrUX3brDtd6nesK8tfUn/9v', N'lms.sa.1234567@gmail.com', 5, 0, 0, NULL, GetDate(), GetDate(), 0, 1, GetDate(), 1, GetDate())
select * From [UserMaster]

Truncate Table [UserInfo]
INSERT [dbo].[UserInfo] ([Userid], [FirstName], [MiddleName], [LastName], [Gender], [DateOfBirth], [MobileNo], [HomeContactNo], [Address1], [Address2], [City], [State], [Country], [Pincode], [DateOfJoin]) VALUES (1, N'SuperAdmin', N'P', N'SuperAdmin', N'M', GetDate(), N'1234567890', N'9876543210', N'Address1', N'1', N'Vadodara', N'Gujarat', N'India', N'390021', GetDate())
INSERT [dbo].[UserInfo] ([Userid], [FirstName], [MiddleName], [LastName], [Gender], [DateOfBirth], [MobileNo], [HomeContactNo], [Address1], [Address2], [City], [State], [Country], [Pincode], [DateOfJoin]) VALUES (2, N'Admin', N'P', N'Admin', N'F', GetDate(), N'1234567890', N'9876543210', N'Address1', N'1', N'Vadodara', N'Gujarat', N'India', N'390021', GetDate())
INSERT [dbo].[UserInfo] ([Userid], [FirstName], [MiddleName], [LastName], [Gender], [DateOfBirth], [MobileNo], [HomeContactNo], [Address1], [Address2], [City], [State], [Country], [Pincode], [DateOfJoin]) VALUES (3, N'Librarian', N'P', N'Librarian', N'M', GetDate(), N'1234567890', N'9876543210', N'Address1', N'1', N'Vadodara', N'Gujarat', N'India', N'390021', GetDate())
INSERT [dbo].[UserInfo] ([Userid], [FirstName], [MiddleName], [LastName], [Gender], [DateOfBirth], [MobileNo], [HomeContactNo], [Address1], [Address2], [City], [State], [Country], [Pincode], [DateOfJoin]) VALUES (4, N'Staff', N'P', N'Staff', N'F', GetDate(), N'1234567890', N'9876543210', N'Address1', N'1', N'Vadodara', N'Gujarat', N'India', N'390021', GetDate())
INSERT [dbo].[UserInfo] ([Userid], [FirstName], [MiddleName], [LastName], [Gender], [DateOfBirth], [MobileNo], [HomeContactNo], [Address1], [Address2], [City], [State], [Country], [Pincode], [DateOfJoin]) VALUES (5, N'Student', N'P', N'Student', N'M', GetDate(), N'1234567890', N'9876543210', N'Address1', N'1', N'Vadodara', N'Gujarat', N'India', N'390021', GetDate())
select * From [UserInfo]

------------------------------------------------------------------------------------------------------------------------------

Truncate Table [AuthorMaster]
INSERT [dbo].[AuthorMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Author1', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[AuthorMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Author2', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[AuthorMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Author3', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[AuthorMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Author4', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[AuthorMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Author5', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[AuthorMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Author6', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[AuthorMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Author7', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[AuthorMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Author8', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[AuthorMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Author9', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[AuthorMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Author10', 0, 1, GetDate(), 1, GetDate())
select * From [AuthorMaster]

------------------------------------------------------------------------------------------------------------------------------

Truncate Table [BookTypeMaster]
INSERT [dbo].[BookTypeMaster] ([Type], [PriceDepreciationTime], [PriceDepreciationRate], [MaxDepreciationRate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Academic', 12, 10, 50, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookTypeMaster] ([Type], [PriceDepreciationTime], [PriceDepreciationRate], [MaxDepreciationRate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Magazine', 1, 75, 25, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookTypeMaster] ([Type], [PriceDepreciationTime], [PriceDepreciationRate], [MaxDepreciationRate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Novel', 6, 50, 25, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookTypeMaster] ([Type], [PriceDepreciationTime], [PriceDepreciationRate], [MaxDepreciationRate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'CD/DVD', 1, 75, 25, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookTypeMaster] ([Type], [PriceDepreciationTime], [PriceDepreciationRate], [MaxDepreciationRate], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Other', 12, 10, 25, 0, 1, GetDate(), 1, GetDate())
select * From [BookTypeMaster]

------------------------------------------------------------------------------------------------------------------------------
Truncate Table [BookMaster]
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Academic Book1', 1, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Academic Book2', 2, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Academic Book3', 3, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Academic Book4', 4, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Academic Book5', 5, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Magazine Book1', 6, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Magazine Book2', 7, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Magazine Book3', 8, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Magazine Book4', 9, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Magazine Book5', 10, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Novel Book1', 9, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Novel Book2', 8, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Novel Book3', 7, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Novel Book4', 6, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Novel Book5', 5, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'CD/DVD Book1', 4, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'CD/DVD Book2', 3, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'CD/DVD Book3', 2, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'CD/DVD Book4', 1, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'CD/DVD Book5', 2, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Other Book1', 3, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Other Book2', 4, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Other Book3', 5, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Other Book4', 6, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookMaster] ([BookTypeId], [Name], [AuthorId], [Publisher], [PublishDate], [Edition], [ISBN], [Price], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Academic Book5', 7, NULL, GetDate(), N'1', N'3423423423', 200, 0, 1, GetDate(), 1, GetDate())

--Randomize data------------
Update [BookMaster] set [Publisher] = 'Publisher' + str(authorId)
Update [BookMaster] set [PublishDate] = DateAdd(Year, ([AuthorId] + 10) * -1, GetDate())
Update [BookMaster] set Price = 500 * [BookTypeId]
Update [BookMaster] set Edition = ([AuthorId] % 4) + 5
--Randomize data------------

select * From [BookMaster]

------------------------------------------------------------------------------------------------------------------------------

Truncate Table [BookCodeMaster]

INSERT [dbo].[BookCodeMaster]
select Id, 'BookCode_' + Convert(Varchar(3),Id) + '_1', 0, 0, 0, 0, 1, GetDate(), 1, GetDate() From [BookMaster]
INSERT [dbo].[BookCodeMaster]
select Id, 'BookCode_' + Convert(Varchar(3),Id) + '_2', 0, 0, 0, 0, 1, GetDate(), 1, GetDate() From [BookMaster]
INSERT [dbo].[BookCodeMaster]
select Id, 'BookCode_' + Convert(Varchar(3),Id) + '_3', 0, 0, 0, 0, 1, GetDate(), 1, GetDate() From [BookMaster]

select * From [BookCodeMaster]

------------------------------------------------------------------------------------------------------------------------------

Truncate Table [FineTypeMaster]
INSERT [dbo].[FineTypeMaster] ([Type], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Demage', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FineTypeMaster] ([Type], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Lost', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FineTypeMaster] ([Type], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'LateReturn', 0, 1, GetDate(), 1, GetDate())
select * From [FineTypeMaster]

------------------------------------------------------------------------------------------------------------------------------

Truncate Table [FormTypeMaster]
INSERT [dbo].[FormTypeMaster] ([Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Login', 1, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormTypeMaster] ([Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Profile', 2, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormTypeMaster] ([Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Master', 3, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormTypeMaster] ([Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Settings', 4, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormTypeMaster] ([Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Book', 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormTypeMaster] ([Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'FinePayment', 6, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormTypeMaster] ([Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Reports', 8, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormTypeMaster] ([Type], [DisplayOrder], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Misc', 8, 0, 1, GetDate(), 1, GetDate())
select * From [FormTypeMaster]

------------------------------------------------------------------------------------------------------------------------------

Truncate Table [FormMaster]
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Login', N'/Login/Login', 1, N'0', N'0', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Forgot Password', N'/Login/ForgotPassword', 2, N'0', N'0', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, N'Reset Passwrod', N'/Login/ResetPassword', 3, N'0', N'0', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Update Profile', N'/Profile/UpdateProfile', 1, N'0', N'0', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Change Password', N'/Profile/ChangePassword', 2, N'0', N'0', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, N'Log Out', N'/Profile/LogOut', 3, N'0', N'0', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Author', N'/AuthorMaster/Index', 1, N'2,3', N'2', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Book Type', N'/BookTypeMaster/Index', 2, N'2,3', N'2', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Book', N'/BookMaster/Index', 3, N'0', N'2', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'User', N'/User/Index', 9, N'2', N'2', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'Carousel', N'/Settings/Carousel', 1, N'2,3', N'2,3', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'Fine Manager', N'/Settings/FineManager', 2, N'2,3', N'2,3', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, N'Role Access', N'/Settings/RoleAccess', 3, N'1', N'2', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Search Book', N'/Book/Search', 1, N'0', N'0', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Reserve Book', N'/Book/Reserve', 2, N'0', N'0', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Issue Book', N'/Book/Issue', 3, N'3', N'3', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, N'Add to wishlist', N'/Book/AddToWishlist', 4, N'0', N'0', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (6, N'Manage Fine', N'/FinePayment/Manage', 1, N'0', N'0', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (6, N'Fine History', N'/FinePayment/History', 2, N'0', N'0', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (6, N'Get Fine', N'/FinePayment/GetFine', 3, N'3', N'3', NULL, NULL, 1, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Book Code', N'/BookCodeMaster/Index', 4, N'2,3', N'2', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Book Fine', N'/BookFineMaster/Index', 6, N'2,3', N'2', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Fine Type', N'/FineTypeMaster/Index', 5, N'2,3', N'2', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Role Master', N'/RoleMaster/Index', 10, N'2', N'0', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Form Type', N'/FormTypeMaster/Index', 7, N'2', N'0', NULL, NULL, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[FormMaster] ([FormTypeId], [Name], [Path], [DisplayOrder], [ReadAccess], [WriteAccess], [SpecialReadAccess], [SpecialWriteAccess], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, N'Form Master', N'/FormMaster/Index', 8, N'2', N'0', NULL, NULL, 1, 1, GetDate(), 1, GetDate())

Update formMaster set specialReadAccess = '4,5', specialWriteAccess = '3' where Name = 'Author'
Update formMaster set specialReadAccess = '4,5', specialWriteAccess = '3' where Name = 'Book Type'
Update formMaster set specialReadAccess = '4,5', specialWriteAccess = '3' where Name = 'Book Fine'
Update formMaster set specialReadAccess = '3,4,5', specialWriteAccess = '' where Name = 'Role Master'
Update formMaster set specialReadAccess = '3,4,5', specialWriteAccess = '' where Name = 'Form Type'

select * From [FormMaster]

------------------------------------------------------------------------------------------------------------------------------

Truncate Table [dbo].[BookFineMaster]
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, 1, 100, 30, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, 1, 100, 30, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, 1, 100, 30, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, 1, 100, 30, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, 1, 100, 30, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, 2, 100, 75, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, 2, 100, 75, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, 2, 100, 75, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, 2, 100, 75, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, 2, 100, 75, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (1, 3, 100, 15, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (2, 3, 100, 15, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (3, 3, 100, 15, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (4, 3, 100, 15, 25, 5, 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[BookFineMaster] ([BookTypeId], [FineTypeId], [LateFeeBaseChargeAmount], [LateFeeBaseChargePercent], [LateFeeIncreaseAmount], [LateFeeIncreasePercentage], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (5, 3, 100, 15, 25, 5, 0, 1, GetDate(), 1, GetDate())
Select * From [dbo].[BookFineMaster]

------------------------------------------------------------------------------------------------------------------------------

Truncate Table [RoleMaster]
INSERT [dbo].[RoleMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'SuperAdmin', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[RoleMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Admin', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[RoleMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Librarian', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[RoleMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Staff', 0, 1, GetDate(), 1, GetDate())
INSERT [dbo].[RoleMaster] ([Name], [IsDeleted], [CreatedBy], [CreatedOn], [ModifiedBy], [ModifiedOn]) VALUES (N'Student', 0, 1, GetDate(), 1, GetDate())
select * From [RoleMaster]

------------------------------------------------------------------------------------------------------------------------------

Truncate Table [BookWishList]
Insert Into dbo.BookWishList
Select 'BookName_1', 'BookDetails_1', 0, 1, GetDate(), 1, GetDate() Union All
Select 'BookName_2', 'BookDetails_2', 0, 1, GetDate(), 1, GetDate() Union All
Select 'BookName_3', 'BookDetails_3', 0, 1, GetDate(), 1, GetDate() Union All
Select 'BookName_4', 'BookDetails_4', 0, 1, GetDate(), 1, GetDate() Union All
Select 'BookName_5', 'BookDetails_5', 0, 1, GetDate(), 1, GetDate() Union All
Select 'BookName_6', 'BookDetails_6', 0, 1, GetDate(), 1, GetDate() Union All
Select 'BookName_7', 'BookDetails_7', 0, 1, GetDate(), 1, GetDate() Union All
Select 'BookName_8', 'BookDetails_8', 0, 1, GetDate(), 1, GetDate() Union All
Select 'BookName_9', 'BookDetails_9', 0, 1, GetDate(), 1, GetDate() Union All
Select 'BookName_10', 'BookDetails_10', 0, 1, GetDate(), 1, GetDate()
select * From [BookWishList]

------------------------------------------------------------------------------------------------------------------------------