CREATE TABLE [dbo].[UserProfile]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [IdentityId] INT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(50) NOT NULL, 
    [RoleId] INT NOT NULL, 
    [Enabled] BIT NULL
)
