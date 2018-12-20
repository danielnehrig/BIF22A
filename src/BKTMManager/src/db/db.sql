USE [master]
GO
DROP DATABASE [master2]
GO
CREATE DATABASE [master2]
GO
USE [master2]
GO

CREATE TABLE [dbo].[Device](
	[id] [int] NOT NULL IDENTITY(1,1),
	[dateBuy] [date] NOT NULL,
	[categoryId] [int] NOT NULL,
	[inventoryNr] [int] NOT NULL,
	[resellerId] [int] NOT NULL,
	[price] [float] NOT NULL,
 CONSTRAINT [PK_Device] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[DeviceReseller](
	[id] [int] NOT NULL IDENTITY(1,1),
	[location] [nvarchar](255) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_DeviceReseller] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Hardware](
	[id] [int] NOT NULL IDENTITY(1,1),
	[categoryId] [int] NOT NULL,
	[exchange] [tinyint] NOT NULL,
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Hardware] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[HardwareDevice](
	[hardwareId] [int] NOT NULL,
	[deviceId] [int] NOT NULL,
	[dateExchange] [date] NULL,
	[installedDate] [date] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kategorie]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[Category](
	[id] [int] NOT NULL IDENTITY(1,1),
	[name] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
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
/****** Object:  Table [dbo].[Teacher]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[Teacher](
	[id] [int] NOT NULL IDENTITY(1,1),
	[firstname] [nvarchar](255) NOT NULL,
	[lastname] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[roomid] [int] NOT NULL,
	[roomOwner] [tinyint] NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Damaged]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[Damaged](
	[id] [int] NOT NULL IDENTITY(1,1),
	[date] [date] NOT NULL,
	[description] [nvarchar](255) NOT NULL,
	[deviceId] [int] NOT NULL,
 CONSTRAINT [PK_Damaged] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[Room](
	[id] [int] NOT NULL IDENTITY(1,1),
	[roomNr] [nvarchar](255) NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RäumeLehrer]    Script Date: 16.11.2018 12:49:14 ******/
CREATE TABLE [dbo].[RoomTeacher](
	[teacherId] [int] NOT NULL,
	[roomId] [int] NOT NULL
) ON [PRIMARY]

/** Adding Key Relations to Tables **/
GO
ALTER TABLE [dbo].[HardwareDevice]  WITH CHECK ADD  CONSTRAINT [FK_HardwareDevice_Device] FOREIGN KEY([deviceId])
REFERENCES [dbo].[Device] ([id])
GO
ALTER TABLE [dbo].[HardwareDevice] CHECK CONSTRAINT [FK_HardwareDevice_Device]
GO
ALTER TABLE [dbo].[HardwareDevice]  WITH CHECK ADD  CONSTRAINT [FK_HardwareDevice_Hardware] FOREIGN KEY([hardwareId])
REFERENCES [dbo].[Hardware] ([id])
GO
ALTER TABLE [dbo].[HardwareDevice] CHECK CONSTRAINT [FK_HardwareDevice_Hardware]
GO
ALTER TABLE [dbo].[Damaged]  WITH CHECK ADD  CONSTRAINT [FK_Damaged_Device] FOREIGN KEY([deviceId])
REFERENCES [dbo].[Device] ([id])
GO
ALTER TABLE [dbo].[Damaged] CHECK CONSTRAINT [FK_Damaged_Device]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_room] FOREIGN KEY([roomId])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_room]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_Category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Device] CHECK CONSTRAINT [FK_Device_Category]
GO
ALTER TABLE [dbo].[Hardware]  WITH CHECK ADD  CONSTRAINT [FK_Hardware_Category] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Hardware] CHECK CONSTRAINT [FK_Hardware_Category]
GO
ALTER TABLE [dbo].[Device]  WITH CHECK ADD  CONSTRAINT [FK_Device_DeviceReseller] FOREIGN KEY([resellerId])
REFERENCES [dbo].[DeviceReseller] ([id])
GO
ALTER TABLE [dbo].[HardwareDevice] CHECK CONSTRAINT [FK_HardwareDevice_Hardware]
GO
ALTER TABLE [dbo].[RoomTeacher]  WITH CHECK ADD  CONSTRAINT [FK_RoomTeacher_Teacher] FOREIGN KEY([teacherId])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[RoomTeacher] CHECK CONSTRAINT [FK_RoomTeacher_Teacher]
GO
ALTER TABLE [dbo].[RoomTeacher]  WITH CHECK ADD  CONSTRAINT [FK_RoomTeacher_Room] FOREIGN KEY([roomId])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[RoomTeacher] CHECK CONSTRAINT [FK_RoomTeacher_Room]
GO
USE [master2]
GO
ALTER DATABASE [master2] SET  READ_WRITE 
GO

/** Test Data **/

INSERT INTO [dbo].[Room] (roomId) VALUES
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

INSERT INTO [dbo].[Category] (name) VALUES
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

INSERT INTO [dbo].[DeviceReseller] (name, location) VALUES
('Müller CO KG', 'OptenBurg 23 41442 Germany'),
('Kaktus GmbH', 'OptenBurg 22 41442 Germany'),
('FranzJosef KG', 'OptenBurg 21 41442 Germany')
GO

INSERT INTO [dbo].[Device] (dateBuy, inventoryNr, categoryId, resellerId, price) VALUES
(GETDATE(), 1, 1, 1, '300.10'),
(GETDATE(), 2, 1, 1, '290.10'),
(GETDATE(), 3, 2, 2, '50.10'),
(GETDATE(), 4, 2, 3, '48.10')
GO


INSERT INTO [dbo].[Teacher] (firstname, lastname, email, roomId, roomOwner) VALUES
('Franz', 'Kostas', 'fKostas@bk-tm.de', 1, 1),
('Heinz', 'Badu', 'hBadu@bk-tm.de', 2, 0),
('Peter', 'Kakau', 'pKakau@bk-tm.de', 3, 0)
GO

INSERT INTO [dbo].[Hardware] (name, exchange, categoryId) VALUES
('Intel i7 K4700', 1, 3),
('Intel i9 K9990', 0, 3),
('Intel i7 K6770', 0, 3)
GO

INSERT INTO [dbo].[Damaged] (description, dateExchange, deviceId) VALUES
('Broken', GETDATE(), 1),
('Broken', GETDATE(), 2),
('Broken', GETDATE(), 3)
GO

USE [master]
GO