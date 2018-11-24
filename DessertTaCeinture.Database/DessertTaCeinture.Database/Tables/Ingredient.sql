CREATE TABLE [dbo].[Ingredient]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Name] NCHAR(50) NOT NULL,
    CONSTRAINT [PK_Ingredient] PRIMARY KEY ([Id]) 
)
