CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	
    [Email] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(MAX) NOT NULL, 
    [Salt] VARCHAR(90) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL, 
    [BirthDate] DATETIME2 NULL, 
    [Gender] BIT NULL, 
    [InscriptionDate] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [RoleId] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_User_Email] UNIQUE ([Email]), 
    CONSTRAINT [CK_User_Email] CHECK ([Email] LIKE '%_@__%.__%'), 
    CONSTRAINT [FK_User_ToRole] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id])
)

GO

CREATE TRIGGER [dbo].[Trigger_User_InsteadOfDelete]
    ON [dbo].[User]
    INSTEAD OF DELETE
    AS
    BEGIN
        UPDATE [User]
		SET IsActive = 0
    END