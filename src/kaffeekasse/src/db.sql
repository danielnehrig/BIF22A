USE [test]
GO
USE [master]
GO
USE [test]
GO
DROP DATABASE [coffee]
GO
CREATE DATABASE [coffee]
GO
USE [coffee]
GO

CREATE TABLE [dbo].[User](
  [userId] [int] NOT NULL IDENTITY(1,1),
  [kzl] [nvarchar](255) NOT NULL,
  [username] [nvarchar](255) NOT NULL,
  [password] [nvarchar](255) NOT NULL,
  [firstName] [nvarchar](255) NOT NULL,
  [lastName] [nvarchar](255) NOT NULL,
  [accAmount] [float] NOT NULL,
  [isActive] [tinyint] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
  [userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[Item](
  [itemId] [int] NOT NULL IDENTITY(1,1),
  [name] [nvarchar](255) NOT NULL,
  [description] [nvarchar](255) NOT NULL,
  [amount] [float] NOT NULL,
 CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED 
(
  [itemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[ItemLog](
  [itemLogId] [int] NOT NULL IDENTITY(1,1),
  [dateWhen] [datetime] NOT NULL,
  [itemId] [int] NOT NULL,
  [userId] [int] NOT NULL,
 CONSTRAINT [PK_ItemLog] PRIMARY KEY CLUSTERED 
(
  [itemLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/** Adding Key Relations to Tables **/
GO
ALTER TABLE [dbo].[ItemLog]  WITH CHECK ADD  CONSTRAINT [FK_ItemLog_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([userId]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemLog] CHECK CONSTRAINT [FK_ItemLog_User]
GO
ALTER TABLE [dbo].[ItemLog]  WITH CHECK ADD  CONSTRAINT [FK_ItemLog_Items] FOREIGN KEY([itemId])
REFERENCES [dbo].[Item] ([itemId]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ItemLog] CHECK CONSTRAINT [FK_ItemLog_Items]
GO

/** Test Data **/
INSERT INTO [dbo].[User] (kzl, username, password, firstName, lastName, accAmount, isActive) VALUES
('dne', 'daniel.nehrig', 'test123', 'daniel', 'nehrig', 100, 1)
GO
INSERT INTO [dbo].[Item] (name, description, amount) VALUES
('coffee', 'normal coffee', '10')
GO
INSERT INTO [dbo].[ItemLog] (dateWhen, itemId, userId) VALUES
('2019-04-13 08:12:00', 1, 1)
GO

CREATE PROCEDURE GetUser
    @UserName nvarchar(50)
AS
    SELECT *
    FROM [dbo].[User]
    WHERE username = @UserName
GO

CREATE PROCEDURE GetItem
    @Name nvarchar(50)
AS
    SELECT *
    FROM [dbo].[Item]
    WHERE name = @Name
GO

CREATE PROCEDURE GetItemLogFromUser
    @UserName nvarchar(50)
AS
    SELECT *
    FROM [dbo].[ItemLog]
    INNER JOIN [dbo].[Item]
    ON [ItemLog].[itemId] = [Item].[itemId]
    INNER JOIN [dbo].[User]
    ON [ItemLog].[userId] = [User].[userId]
    WHERE [User].[username] = @UserName
GO

CREATE PROCEDURE UpdateUserAmount
    @UserName nvarchar(50),
    @Amount float(50),
AS
  UPDATE [dbo].[User]
  SET amount = @Amount
  WHERE username = @UserName
GO

CREATE PROCEDURE SetUserStatus
    @UserName nvarchar(50),
    @Active tinyint,
AS
  UPDATE [dbo].[User]
  SET isActive = @Active
  WHERE username = @UserName
GO

CREATE TRIGGER checkAccAmount
ON User
BEFORE UPDATE  
AS  
IF (ROWCOUNT_BIG() = 0)
RETURN
IF EXISTS (
  SELECT User.accAmount  
  FROM Insert)
BEGIN  
ROLLBACK TRANSACTION;
RETURN
END
GO 

CREATE TRIGGER accUpdate
ON User
AFTER UPDATE
AS
EXEC msdb.dbo.sp_send_dbmail
@profile_name = 'Coffee Log Administrator',
@recipients = 'danw@Adventure-Works.com',
@body = 'Account Amount Updated',
@subject = 'Account Amount Update'
GO  

USE [test]
GO
