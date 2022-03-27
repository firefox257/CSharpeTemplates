CREATE TABLE [dbo].[UserProfile]
(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [IdentityId] UNIQUEIDENTIFIER NULL, 
    [FirstName] TEXT NOT NULL, 
    [LastName] TEXT NOT NULL, 
    [Email] TEXT NOT NULL, 
    [RoleId] INT NOT NULL, 
    [Enabled] BIT NULL
)
