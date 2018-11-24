CREATE TABLE [dbo].[Role]
(
	[Id] INT NOT NULL, 
    [Function] VARCHAR(20) NOT NULL,
    [Level] INT NOT NULL, 
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id]), 
    CONSTRAINT [CK_Role_Level] CHECK ([Level] > 0) 
)
