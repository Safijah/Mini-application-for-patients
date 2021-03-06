USE [Patients]

DELETE FROM [dbo].[__EFMigrationsHistory]

DELETE FROM [dbo].[Appointment]

DELETE FROM [dbo].[Patient]

DELETE FROM [dbo].[AspNetUserTokens]

DELETE FROM [dbo].[AspNetUserLogins]

DELETE FROM [dbo].[AspNetUserClaims]

DELETE FROM [dbo].[AspNetUserRoles]

DELETE FROM [dbo].[AspNetUsers]

DELETE FROM [dbo].[AspNetRoleClaims]

DELETE FROM [dbo].[AspNetRoles]

INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Admin', N'ADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'Patient', N'PATIENT', NULL)

INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'36375244-b5f3-442f-b548-3c8be2ff05cd', N'amina@hotmail.com', N'AMINA@HOTMAIL.COM', N'amina@hotmail.com', N'AMINA@HOTMAIL.COM', 0, N'AQAAAAEAACcQAAAAEKCHLkuthZoIQE2clEmfX1n0ISiTdPc3yhNikfwO/BQeklQe+2oY27TEugnUVfZPvg==', N'VFD2JT7U3ZQRWDTIKXDIUHCQTXZB4F2F', N'0f291aec-75e3-47a2-a8bc-fc5fc2e33540', NULL, 0, 0, NULL, 1, 0, N'Amina', N'Hubljar')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'f58e313e-5eab-4ccf-a3ed-7c8488861fc6', N'safija.hubljar@edu.fit.ba', N'SAFIJA.HUBLJAR@EDU.FIT.BA', N'safija.hubljar@edu.fit.ba', N'SAFIJA.HUBLJAR@EDU.FIT.BA', 0, N'AQAAAAEAACcQAAAAEGzR3Q996KSFbdHNi731T09e76lZELyoDD4KveAt17fIi16+EwvRn7/Ph63ko3+u9A==', N'BGYL5KVBYXNXIWNHHJGP7WDGINUHZAUB', N'6da6b83c-430a-4fa9-879a-b9f2ae570ff6', NULL, 0, 0, NULL, 1, 0, N'Safija', N'Hubljar')
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'fc138fb2-bb4c-4f63-ba3e-708cd58e89c3', N'Fatima@hotmail.com', N'FATIMA@HOTMAIL.COM', N'Fatima@hotmail.com', N'FATIMA@HOTMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPaGXpCwDPciSoTnI/u2CaCVoaaQBZUZJhAuYKOThYe3Bhbsa8OZP5RrdKVRDJOEmQ==', N'AWBMY6GOFCBRP2S2WN5BCYSBB5ENIVDT', N'1cfa6808-36f7-4409-8d6d-aa36b47d2549', NULL, 0, 0, NULL, 1, 0, N'Fatima', N'Hubljar')

INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f58e313e-5eab-4ccf-a3ed-7c8488861fc6', N'1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'36375244-b5f3-442f-b548-3c8be2ff05cd', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fc138fb2-bb4c-4f63-ba3e-708cd58e89c3', N'2')

INSERT [dbo].[Patient] ([ID]) VALUES (N'36375244-b5f3-442f-b548-3c8be2ff05cd')
INSERT [dbo].[Patient] ([ID]) VALUES (N'fc138fb2-bb4c-4f63-ba3e-708cd58e89c3')

SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([ID], [Date], [Note], [PatientID]) VALUES (1, CAST(N'2022-01-14T03:00:00.0000000' AS DateTime2), NULL, N'36375244-b5f3-442f-b548-3c8be2ff05cd')
INSERT [dbo].[Appointment] ([ID], [Date], [Note], [PatientID]) VALUES (2, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'36375244-b5f3-442f-b548-3c8be2ff05cd')
INSERT [dbo].[Appointment] ([ID], [Date], [Note], [PatientID]) VALUES (3, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'36375244-b5f3-442f-b548-3c8be2ff05cd')
INSERT [dbo].[Appointment] ([ID], [Date], [Note], [PatientID]) VALUES (4, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'36375244-b5f3-442f-b548-3c8be2ff05cd')
INSERT [dbo].[Appointment] ([ID], [Date], [Note], [PatientID]) VALUES (5, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, N'fc138fb2-bb4c-4f63-ba3e-708cd58e89c3')
SET IDENTITY_INSERT [dbo].[Appointment] OFF

INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220111114529_initial', N'3.1.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220111175920_NewTable', N'3.1.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220113110808_Appointment', N'3.1.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220113112631_Relationship', N'3.1.21')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220113113122_ChangesForID', N'3.1.21')

