USE [SG_ASP_1]
GO
ALTER TABLE [dbo].[Medicina] DROP CONSTRAINT [FK__Medicina__AtenId__33D4B598]
GO
ALTER TABLE [dbo].[Interconsulta] DROP CONSTRAINT [FK_dbo.Interconsulta_dbo.EnfermeriaViewModels_EnfermeriaViewModel_Id]
GO
ALTER TABLE [dbo].[Interconsulta] DROP CONSTRAINT [FK__Intercons__AtenI__32E0915F]
GO
ALTER TABLE [dbo].[Auditoria] DROP CONSTRAINT [FK__Auditoria__AtenI__31EC6D26]
GO
ALTER TABLE [dbo].[Atenciones] DROP CONSTRAINT [FK__Atencione__Medic__30F848ED]
GO
ALTER TABLE [dbo].[Admision] DROP CONSTRAINT [FK__Admision__AtenId__300424B4]
GO
ALTER TABLE [dbo].[Auditoria] DROP CONSTRAINT [DF__Auditoria__Medic__47DBAE45]
GO
/****** Object:  Table [dbo].[Medicina]    Script Date: 9/04/2021 16:35:54 ******/
DROP TABLE [dbo].[Medicina]
GO
/****** Object:  Table [dbo].[Interconsulta]    Script Date: 9/04/2021 16:35:54 ******/
DROP TABLE [dbo].[Interconsulta]
GO
/****** Object:  Table [dbo].[EnfermeriaViewModels]    Script Date: 9/04/2021 16:35:54 ******/
DROP TABLE [dbo].[EnfermeriaViewModels]
GO
/****** Object:  Table [dbo].[Auditoria]    Script Date: 9/04/2021 16:35:54 ******/
DROP TABLE [dbo].[Auditoria]
GO
/****** Object:  Table [dbo].[Atenciones]    Script Date: 9/04/2021 16:35:54 ******/
DROP TABLE [dbo].[Atenciones]
GO
/****** Object:  Table [dbo].[Admision]    Script Date: 9/04/2021 16:35:54 ******/
DROP TABLE [dbo].[Admision]
GO
/****** Object:  Table [dbo].[Admision]    Script Date: 9/04/2021 16:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admision](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AtenId] [int] NULL,
	[HorIng] [time](7) NULL,
	[HorSal] [time](7) NULL,
	[Usuari] [varchar](10) NOT NULL,
	[Pendie] [varchar](200) NULL,
	[UserName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[AtenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Atenciones]    Script Date: 9/04/2021 16:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atenciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Local0] [varchar](20) NULL,
	[TipExa] [varchar](20) NULL,
	[FecAte] [date] NULL,
	[NomApe] [varchar](100) NULL,
	[DocIde] [varchar](20) NULL,
	[Empres] [varchar](100) NULL,
	[SubCon] [varchar](100) NULL,
	[Proyec] [varchar](100) NULL,
	[Perfil] [varchar](100) NULL,
	[Area] [varchar](100) NULL,
	[PueTra] [varchar](100) NULL,
	[PeReAd] [varchar](50) NULL,
	[Hora] [time](7) NULL,
	[Medico] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Auditoria]    Script Date: 9/04/2021 16:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auditoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AtenId] [int] NULL,
	[ExaCom] [bit] NOT NULL,
	[ExaCom1] [varchar](20) NULL,
	[DatInc] [bit] NOT NULL,
	[DatInc1] [varchar](20) NULL,
	[AptErr] [bit] NOT NULL,
	[AptErr1] [varchar](20) NULL,
	[FaFiMe] [bit] NOT NULL,
	[FaFiMe1] [varchar](20) NULL,
	[FaFiPa] [bit] NOT NULL,
	[FaFiPa1] [varchar](20) NULL,
	[Restri] [bit] NOT NULL,
	[Restri1] [varchar](20) NULL,
	[Contro] [bit] NOT NULL,
	[Contro1] [varchar](20) NULL,
	[Diagno] [bit] NOT NULL,
	[Diagno1] [varchar](20) NULL,
	[ErrLle] [bit] NOT NULL,
	[ErrLle1] [varchar](20) NULL,
	[ObNoRe] [varchar](100) NULL,
	[EmSnOb] [bit] NOT NULL,
	[EmSnOb1] [varchar](20) NULL,
	[HorAud] [time](7) NULL,
	[FecAud] [date] NULL,
	[Alerta] [int] NULL,
	[UserName] [varchar](100) NULL,
	[Medico] [nvarchar](128) NOT NULL,
	[OmiInt] [bit] NULL,
	[OmiInt1] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[AtenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnfermeriaViewModels]    Script Date: 9/04/2021 16:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnfermeriaViewModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomApe] [nvarchar](max) NULL,
	[DocIde] [nvarchar](max) NULL,
	[Empres] [nvarchar](max) NULL,
	[AtenId] [int] NULL,
 CONSTRAINT [PK_dbo.EnfermeriaViewModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interconsulta]    Script Date: 9/04/2021 16:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interconsulta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AtenId] [int] NULL,
	[NumLine] [int] NULL,
	[IntCon] [varchar](50) NULL,
	[FecEnv] [date] NULL,
	[PeEnCo] [varchar](50) NULL,
	[EnHoIn] [bit] NOT NULL,
	[FeCoPa] [date] NULL,
	[PeCoPa] [varchar](50) NULL,
	[FeLeObs] [date] NULL,
	[UserName] [varchar](100) NULL,
	[EnfermeriaViewModel_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicina]    Script Date: 9/04/2021 16:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicina](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AtenId] [int] NULL,
	[HorIng] [time](7) NULL,
	[HorSal] [time](7) NULL,
	[Medico] [varchar](50) NULL,
	[Aptitu] [varchar](50) NULL,
	[FecApt] [date] NULL,
	[FecEnv] [date] NULL,
	[Coment] [varchar](100) NULL,
	[Observ] [varchar](100) NULL,
	[Alerta] [int] NULL,
	[UserName] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[AtenId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Auditoria] ADD  DEFAULT ('') FOR [Medico]
GO
ALTER TABLE [dbo].[Admision]  WITH CHECK ADD FOREIGN KEY([AtenId])
REFERENCES [dbo].[Atenciones] ([Id])
GO
ALTER TABLE [dbo].[Atenciones]  WITH CHECK ADD FOREIGN KEY([Medico])
REFERENCES [dbo].[Medicos] ([Medico])
GO
ALTER TABLE [dbo].[Auditoria]  WITH CHECK ADD FOREIGN KEY([AtenId])
REFERENCES [dbo].[Atenciones] ([Id])
GO
ALTER TABLE [dbo].[Interconsulta]  WITH CHECK ADD FOREIGN KEY([AtenId])
REFERENCES [dbo].[Atenciones] ([Id])
GO
ALTER TABLE [dbo].[Interconsulta]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Interconsulta_dbo.EnfermeriaViewModels_EnfermeriaViewModel_Id] FOREIGN KEY([EnfermeriaViewModel_Id])
REFERENCES [dbo].[EnfermeriaViewModels] ([Id])
GO
ALTER TABLE [dbo].[Interconsulta] CHECK CONSTRAINT [FK_dbo.Interconsulta_dbo.EnfermeriaViewModels_EnfermeriaViewModel_Id]
GO
ALTER TABLE [dbo].[Medicina]  WITH CHECK ADD FOREIGN KEY([AtenId])
REFERENCES [dbo].[Atenciones] ([Id])
GO
