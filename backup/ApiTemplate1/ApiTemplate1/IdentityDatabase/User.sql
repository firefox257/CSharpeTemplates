CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [UserName] VARCHAR(50) NOT NULL, 
    [Created] DATETIME NOT NULL, 
    [Updated] DATETIME NULL, 
    [Enabled] BIT NOT NULL, 
    [PasswordHash] VARCHAR(64) NOT NULL
)
