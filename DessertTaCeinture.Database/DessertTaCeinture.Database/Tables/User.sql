CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	
    [Email] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(MAX) NOT NULL, 
    [Salt] VARCHAR(90) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL, 
    [FirstName] VARCHAR(50) NOT NULL,
    [Gender] BIT NULL, 
    [InscriptionDate] DATETIME2 NOT NULL , 
    [IsActive] BIT NOT NULL , 
    [RoleId] INT NOT NULL , 
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
        DECLARE @UserId INT

		SELECT @UserId = DELETED.Id
		FROM DELETED

        UPDATE [User]
		SET IsActive = 0
		WHERE Id = @UserId
    END