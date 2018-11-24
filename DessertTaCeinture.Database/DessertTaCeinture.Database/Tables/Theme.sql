CREATE TABLE [dbo].[Theme]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Theme] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Theme_Name] UNIQUE ([Name]) 
)
