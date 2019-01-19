CREATE TABLE [dbo].[News]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Title] VARCHAR(200) NOT NULL, 
    [ImageUrl] VARCHAR(255) NULL, 
    [Summary] TEXT NOT NULL, 
    [Description] TEXT NOT NULL, 
    [ReleaseDate] DATETIME2 NOT NULL DEFAULT GETDATE()
)
