USE [master]
GO
DROP DATABASE [coffee]
GO
CREATE DATABASE [coffee]
GO
USE [coffee]
GO

CREATE TABLE [dbo].[User](
  [id] [int] NOT NULL IDENTITY(1,1),
  [username] [nvarchar](255) NOT NULL,
  [password] [nvarchar](255) NOT NULL,
  [firstName] [nvarchar](255) NOT NULL,
  [lastName] [nvarchar](255) NOT NULL,
  [accAmount] [float] NOT NULL,
  [isActive] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
  [id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Items](
  [id] [int] NOT NULL IDENTITY(1,1),
  [name] [nvarchar](255) NOT NULL,
  [description] [nvarchar](255) NOT NULL,
  [amount] [float] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
  [id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ItemLog](
  [id] [int] NOT NULL IDENTITY(1,1),
  [dateWhen] [date] NOT NULL,
  [itemId] [nvarchar](255) NOT NULL,
  [userId] [float] NOT NULL,
 CONSTRAINT [PK_ItemLog] PRIMARY KEY CLUSTERED 
(
  [id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/** Adding Key Relations to Tables **/
GO
ALTER TABLE [dbo].[ItemLog]  WITH CHECK ADD  CONSTRAINT [FK_ItemLog_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemLog] CHECK CONSTRAINT [FK_ItemLog_User]
GO
ALTER TABLE [dbo].[ItemLog]  WITH CHECK ADD  CONSTRAINT [FK_ItemLog_Items] FOREIGN KEY([itemId])
REFERENCES [dbo].[Items] ([id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemLog] CHECK CONSTRAINT [FK_ItemLog_Items]
GO

USE [master2]
GO
ALTER DATABASE [master2] SET  READ_WRITE 
GO

/** Test Data **/


USE [master]
GO
