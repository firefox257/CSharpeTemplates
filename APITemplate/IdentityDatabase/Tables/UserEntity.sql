CREATE TABLE [dbo].[UserEntity]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [UserName] VARCHAR(100) NOT NULL, 
    [First] VARCHAR(50) NULL, 
    [Last] VARCHAR(50) NULL, 
    [Created] DATETIME NOT NULL, 
    [LastUpdated] DATETIME NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0,
    [Blocked] BIT NOT NULL DEFAULT 0, 
    [BlockedReason] VARCHAR(100) NULL, 
    [PassHash] VARCHAR(256) NULL, 
    [EmailVerified] BIT NOT NULL DEFAULT 0, 
    [AdminVerified] BIT NOT NULL DEFAULT 0, 
    [Email] VARCHAR(100) NULL, 
    [RoleId] VARCHAR(10) NOT NULL DEFAULT 'User', 
    [ForceChangePassword] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT PK_USERENTITY PRIMARY KEY (Id),
    CONSTRAINT AK_USERENTITY_USERNAME UNIQUE([UserName])
)
