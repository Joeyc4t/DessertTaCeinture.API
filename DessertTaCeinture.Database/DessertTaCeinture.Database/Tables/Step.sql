CREATE TABLE [dbo].[Step]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [StepOrder] INT NOT NULL, 
    [Description] TEXT NOT NULL
)
