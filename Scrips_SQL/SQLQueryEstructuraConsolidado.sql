
/****** Object:  Table [dbo].[Admision]    Script Date: 17/03/2021 20:07:57 ******/
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
/****** Object:  Table [dbo].[Atenciones]    Script Date: 17/03/2021 20:07:57 ******/
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
/****** Object:  Table [dbo].[Auditoria]    Script Date: 17/03/2021 20:07:57 ******/
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
/****** Object:  Table [dbo].[Interconsulta]    Script Date: 17/03/2021 20:07:57 ******/
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
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicina]    Script Date: 17/03/2021 20:07:57 ******/
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
/****** Object:  Table [dbo].[Medicos]    Script Date: 17/03/2021 20:07:57 ******/
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
ALTER TABLE [dbo].[Medicina]  WITH CHECK ADD FOREIGN KEY([AtenId])
REFERENCES [dbo].[Atenciones] ([Id])
GO
