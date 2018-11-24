CREATE TABLE [dbo].[Category]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id]) 
)
