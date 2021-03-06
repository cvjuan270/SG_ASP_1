USE [SG_ASP_1]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetRoles] DROP CONSTRAINT [DF__AspNetRol__Discr__440B1D61]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 9/04/2021 16:36:50 ******/
DROP TABLE [dbo].[Medicos]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/04/2021 16:36:50 ******/
DROP TABLE [dbo].[AspNetUsers]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/04/2021 16:36:50 ******/
DROP TABLE [dbo].[AspNetUserRoles]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/04/2021 16:36:50 ******/
DROP TABLE [dbo].[AspNetUserLogins]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/04/2021 16:36:50 ******/
DROP TABLE [dbo].[AspNetUserClaims]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/04/2021 16:36:50 ******/
DROP TABLE [dbo].[AspNetRoles]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 9/04/2021 16:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 9/04/2021 16:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 9/04/2021 16:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 9/04/2021 16:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 9/04/2021 16:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Medico] [nvarchar](max) NULL,
	[Nombre] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 9/04/2021 16:36:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Medico] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Medico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'09aef747-65f9-4094-8db8-7194d518bc3e', N'Admin', N'ApplicationRole')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'48fab920-c9b3-4b31-808a-18d936b06b5f', N'Auditoria', N'IdentityRole')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'6995e2fb-285a-4bc8-9bf5-581c5726c169', N'Admision', N'IdentityRole')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'7036e47e-87c0-4b5b-bb48-ed412c972af6', N'Medicina', N'IdentityRole')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'a924f9f1-d53c-4038-9770-efef5dcb74e0', N'Enfermeria', N'IdentityRole')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6ef207a0-42be-4fac-8c91-6a69fe50135a', N'09aef747-65f9-4094-8db8-7194d518bc3e')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8e18e96f-f39d-44f1-a148-5f88b430feec', N'48fab920-c9b3-4b31-808a-18d936b06b5f')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'235a5bb3-9cc7-4ef0-8fb6-ae67a05df6fa', N'6995e2fb-285a-4bc8-9bf5-581c5726c169')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1da00380-b46e-452e-a500-1fa10bd2a9e3', N'7036e47e-87c0-4b5b-bb48-ed412c972af6')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8d885745-ba40-4fdb-9203-152044199a36', N'7036e47e-87c0-4b5b-bb48-ed412c972af6')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b6d26645-c37d-4678-b963-5d20bb4e2ae3', N'7036e47e-87c0-4b5b-bb48-ed412c972af6')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e138c19f-4047-4096-bd68-c23c5a2c55cf', N'a924f9f1-d53c-4038-9770-efef5dcb74e0')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ef54a7c6-01c1-4742-a9d1-735f159993e3', N'a924f9f1-d53c-4038-9770-efef5dcb74e0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Medico], [Nombre]) VALUES (N'1da00380-b46e-452e-a500-1fa10bd2a9e3', N'medicina3@sg', 0, N'ABKWZjsfYse72hFuXWnzyYEM6+9tdZuYBCCJCaaE/Ky8J98uuyOoDuhfh/JERMiX5g==', N'4a5b4039-43f1-446c-8c64-5ac66e5ef1e4', NULL, 0, 0, NULL, 1, 0, N'medicina3@sg', N'ARIAS ALI MIRIAN EDITH', N'Miriam')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Medico], [Nombre]) VALUES (N'235a5bb3-9cc7-4ef0-8fb6-ae67a05df6fa', N'admision1@sg', 0, N'ALEHgV9F/rDpmLKgc65lRx33K0zHE9SmoMAZHHGdjABLobWVOM+cUEe/tMMDuf8WrQ==', N'73f5be1e-8f37-4986-a930-62e44cdbb0aa', NULL, 0, 0, NULL, 1, 0, N'admision1@sg', N'SM', N'Claudia')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Medico], [Nombre]) VALUES (N'6ef207a0-42be-4fac-8c91-6a69fe50135a', N'cvjuan270@gmail.com', 0, N'ANZ0R4pi9GCY8uZwpl1H+8McqX5JKBMyOW6hjtVKQJcqNWIzCfwBVV6xE8/s9MqDjQ==', N'a8e6d5f2-35eb-46c6-b026-7698ba759878', NULL, 0, 0, NULL, 0, 0, N'cvjuan270@gmail.com', N'SM', N'Juan Diego')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Medico], [Nombre]) VALUES (N'8d885745-ba40-4fdb-9203-152044199a36', N'medicina2@sg', 0, N'ACYR6XzS3LDSkj5Nl3WunKaXfRvcuUxksc/lkTSHSPpHtxX69oMW0E5GKIP+RLaVAg==', N'28cebaee-d5b3-49d2-b953-8fa836bd48d9', NULL, 0, 0, NULL, 1, 0, N'medicina2@sg', N'MONTES LIMA ELIANA JOANIE', N'Eliana')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Medico], [Nombre]) VALUES (N'8e18e96f-f39d-44f1-a148-5f88b430feec', N'auditor1@sg', 0, N'AIh3e7lLT3p34XOPO6D9LYmq1EqH494VzVcfbVyooZRCOGS98WBgGYrinpELE/SaHw==', N'6ec09b27-a2fd-4d86-b12a-e126c129a8d6', NULL, 0, 0, NULL, 1, 0, N'auditor1@sg', N'SM', N'Leonel')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Medico], [Nombre]) VALUES (N'b6d26645-c37d-4678-b963-5d20bb4e2ae3', N'medicina1@sg', 0, N'AEBdy8EoPEX4D9WBgfvgHGx56oiDzD8NV/bYdpVGbn0wcX4GGeXMpDDlIQ3zFTMW3Q==', N'9085a5aa-2b95-468f-bfa4-5ee06edcd0f4', NULL, 0, 0, NULL, 1, 0, N'medicina1@sg', N'BARREDA CUBA MAIGRET', N'Maigred')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Medico], [Nombre]) VALUES (N'e138c19f-4047-4096-bd68-c23c5a2c55cf', N'enfer1@sg', 0, N'AH9E+/U4+bb7F78ZFVR0Hv8NBsP7hA1hZG4tNfAZaVUaguJ5cD3h1DEdiQVsc+XX6w==', N'431160d1-8a31-458c-aad2-33da1ccec7b6', NULL, 0, 0, NULL, 1, 0, N'enfer1@sg', N'SM', N'Karolina')
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Medico], [Nombre]) VALUES (N'ef54a7c6-01c1-4742-a9d1-735f159993e3', N'enfer2@sg', 0, N'APm9VIYWU5fyAaW01UmLUFGC0rTcRy6xDkg82/G+f1WSu3eIQbkvndXIJzmt1hw2pQ==', N'1566f0e3-53ef-4b0e-a04b-b18ff8c4edf3', NULL, 0, 0, NULL, 1, 0, N'enfer2@sg', N'SM', N'Maite')
GO
SET IDENTITY_INSERT [dbo].[Medicos] ON 
GO
INSERT [dbo].[Medicos] ([id], [Medico]) VALUES (1, N'ARIAS ALI MIRIAN EDITH')
GO
INSERT [dbo].[Medicos] ([id], [Medico]) VALUES (1004, N'BARREDA CUBA MAIGRET')
GO
INSERT [dbo].[Medicos] ([id], [Medico]) VALUES (1003, N'GALBAN CEDEñO MARIA CELINA')
GO
INSERT [dbo].[Medicos] ([id], [Medico]) VALUES (1001, N'MONTES LIMA ELIANA JOANIE')
GO
INSERT [dbo].[Medicos] ([id], [Medico]) VALUES (1002, N'PACHECO CHAVEZ MONIKA')
GO
INSERT [dbo].[Medicos] ([id], [Medico]) VALUES (2001, N'SM')
GO
SET IDENTITY_INSERT [dbo].[Medicos] OFF
GO
ALTER TABLE [dbo].[AspNetRoles] ADD  DEFAULT ('') FOR [Discriminator]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
