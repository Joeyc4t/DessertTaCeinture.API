CREATE TABLE [dbo].[Origin]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Country] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Origin] PRIMARY KEY ([Id]), 
    CONSTRAINT [AK_Origin_Country] UNIQUE ([Country]) 
)
