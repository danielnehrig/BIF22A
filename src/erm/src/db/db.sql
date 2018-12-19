USE [master]
GO
DROP DATABASE [master2]
GO
CREATE DATABASE [master2]
GO
USE [master2]
GO
/****** Object:  Table [dbo].[Geräte]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[Geräte](
	[id] [int] NOT NULL IDENTITY(1,1),
	[datumAnschaffung] [date] NOT NULL,
	[kategorieId] [int] NOT NULL,
	[inventarNr] [int] NOT NULL,
	[verkäufterId] [int] NOT NULL,
	[preis] [float] NOT NULL,
 CONSTRAINT [PK_Geräte] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GeräteVerkäufter]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[GeräteVerkäufter](
	[id] [int] NOT NULL IDENTITY(1,1),
	[standort] [nvarchar](255) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_GeräteVerkäufter] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hardware]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[Hardware](
	[id] [int] NOT NULL IDENTITY(1,1),
	[kategorieId] [int] NOT NULL,
	[austausch] [tinyint] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Hardware] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HardwareGeräte]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[HardwareGeräte](
	[hardwareId] [int] NOT NULL,
	[geräteId] [int] NOT NULL,
	[austauschDatum] [date] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kategorie]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[Kategorie](
	[id] [int] NOT NULL IDENTITY(1,1),
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Kategorie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL IDENTITY(1,1),
	[username] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[admin] [tinyint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lehrer]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[Lehrer](
	[id] [int] NOT NULL IDENTITY(1,1),
	[vorname] [nvarchar](255) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[raumId] [int] NOT NULL,
	[raumbetreuer] [tinyint] NOT NULL,
 CONSTRAINT [PK_Lehrer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Mangel]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[Mangel](
	[id] [int] NOT NULL IDENTITY(1,1),
	[datum] [date] NOT NULL,
	[beschreibung] [nvarchar](255) NOT NULL,
	[geräteId] [int] NOT NULL,
 CONSTRAINT [PK_Mangel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Räume]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[Räume](
	[id] [int] NOT NULL IDENTITY(1,1),
	[raumNr] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Räume] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RäumeLehrer]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[RäumeLehrer](
	[lehrerId] [int] NOT NULL,
	[raumId] [int] NOT NULL
) ON [PRIMARY]

/** Adding Key Relations to Tables **/
GO
ALTER TABLE [dbo].[HardwareGeräte]  WITH CHECK ADD  CONSTRAINT [FK_HardwareGeräte_Geräte] FOREIGN KEY([geräteId])
REFERENCES [dbo].[Geräte] ([id])
GO
ALTER TABLE [dbo].[HardwareGeräte] CHECK CONSTRAINT [FK_HardwareGeräte_Geräte]
GO
ALTER TABLE [dbo].[HardwareGeräte]  WITH CHECK ADD  CONSTRAINT [FK_HardwareGeräte_Hardware] FOREIGN KEY([hardwareId])
REFERENCES [dbo].[Hardware] ([id])
GO
ALTER TABLE [dbo].[HardwareGeräte] CHECK CONSTRAINT [FK_HardwareGeräte_Hardware]
GO
ALTER TABLE [dbo].[Mangel]  WITH CHECK ADD  CONSTRAINT [FK_Mangel_Geräte] FOREIGN KEY([geräteId])
REFERENCES [dbo].[Geräte] ([id])
GO
ALTER TABLE [dbo].[Mangel] CHECK CONSTRAINT [FK_Mangel_Geräte]
GO
ALTER TABLE [dbo].[Lehrer]  WITH CHECK ADD  CONSTRAINT [FK_Lehrer_Räume] FOREIGN KEY([raumId])
REFERENCES [dbo].[Räume] ([id])
GO
ALTER TABLE [dbo].[Lehrer] CHECK CONSTRAINT [FK_Lehrer_Räume]
GO
ALTER TABLE [dbo].[Geräte]  WITH CHECK ADD  CONSTRAINT [FK_Geräte_Kategorie] FOREIGN KEY([kategorieId])
REFERENCES [dbo].[Kategorie] ([id])
GO
ALTER TABLE [dbo].[Geräte] CHECK CONSTRAINT [FK_Geräte_Kategorie]
GO
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_Kategorie] FOREIGN KEY([kategorieId])
REFERENCES [dbo].[Kategorie] ([id])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_Kategorie]
GO
ALTER TABLE [dbo].[Geräte]  WITH CHECK ADD  CONSTRAINT [FK_Geräte_Verkäufer] FOREIGN KEY([verkäufterId])
REFERENCES [dbo].[GeräteVerkäufter] ([id])
GO
ALTER TABLE [dbo].[HardwareGeräte] CHECK CONSTRAINT [FK_HardwareGeräte_Hardware]
GO
ALTER TABLE [dbo].[RäumeLehrer]  WITH CHECK ADD  CONSTRAINT [FK_RäumeLehrer_Lehrer] FOREIGN KEY([lehrerId])
REFERENCES [dbo].[Lehrer] ([id])
GO
ALTER TABLE [dbo].[RäumeLehrer] CHECK CONSTRAINT [FK_RäumeLehrer_Lehrer]
GO
ALTER TABLE [dbo].[RäumeLehrer]  WITH CHECK ADD  CONSTRAINT [FK_RäumeLehrer_Räume] FOREIGN KEY([raumId])
REFERENCES [dbo].[Räume] ([id])
GO
ALTER TABLE [dbo].[RäumeLehrer] CHECK CONSTRAINT [FK_RäumeLehrer_Räume]
GO
USE [master2]
GO
ALTER DATABASE [master2] SET  READ_WRITE 
GO

/** Test Data **/

INSERT INTO [dbo].[Räume] (raumNr) VALUES
('C102'),
('C103'),
('C104'),
('C105'),
('C105'),
('C106'),
('C212'),
('C213'),
('C214'),
('C215'),
('C216')
GO

INSERT INTO [dbo].[Kategorie] (name) VALUES
('PC'),
('Printer'),
('CPU'),
('Motherboard'),
('PSU'),
('HDD'),
('RAM'),
('Mouse'),
('Keyboard')
GO

INSERT INTO [dbo].[GeräteVerkäufter] (name, standort) VALUES
('Müller CO KG', 'OptenBurg 23 41442 Germany'),
('Kaktus GmbH', 'OptenBurg 22 41442 Germany'),
('FranzJosef KG', 'OptenBurg 21 41442 Germany')
GO

INSERT INTO [dbo].[Geräte] (datumAnschaffung, inventarNr, kategorieId, verkäufterId, preis) VALUES
(GETDATE(), 1, 1, 1, '300.10'),
(GETDATE(), 2, 1, 1, '290.10'),
(GETDATE(), 3, 2, 2, '50.10'),
(GETDATE(), 4, 2, 3, '48.10')
GO


INSERT INTO [dbo].[Lehrer] (name, vorname, email, raumId, raumbetreuer) VALUES
('Franz', 'Kostas', 'fKostas@bk-tm.de', 1, 1),
('Heinz', 'Badu', 'hBadu@bk-tm.de', 2, 0),
('Peter', 'Kakau', 'pKakau@bk-tm.de', 3, 0)
GO

INSERT INTO [dbo].[Hardware] (name, austausch, kategorieId) VALUES
('Intel i7 K4700', 1, 3),
('Intel i9 K9990', 0, 3),
('Intel i7 K6770', 0, 3)
GO

INSERT INTO [dbo].[Mangel] (beschreibung, datum, geräteId) VALUES
('Broken', GETDATE(), 1),
('Broken', GETDATE(), 2),
('Broken', GETDATE(), 3)
GO

USE [master]
GO