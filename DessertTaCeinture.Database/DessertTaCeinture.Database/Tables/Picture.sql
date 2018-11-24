CREATE TABLE [dbo].[Picture]
(
	[Id] INT NOT NULL IDENTITY(1,1),	
    [Name] VARCHAR(50) NOT NULL, 
    [Path] VARCHAR(255) NOT NULL, 
    CONSTRAINT [PK_Picture] PRIMARY KEY ([Id]) 
)
