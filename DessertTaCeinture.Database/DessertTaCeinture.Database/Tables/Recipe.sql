CREATE TABLE [dbo].[Recipe]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Title] VARCHAR(75) NOT NULL,
    [CreationDate] DATETIME2 NOT NULL DEFAULT GETDATE(),  
    [OriginId] INT NULL, 
    [CreatorId] INT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [PictureId] INT NOT NULL, 
    [ThemeId] INT NOT NULL, 
    [IsPublic] BIT NOT NULL, 
    CONSTRAINT [PK_Recipe] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Recipe_ToUser] FOREIGN KEY ([CreatorId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Recipe_ToCategory] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]), 
    CONSTRAINT [FK_Recipe_ToPicture] FOREIGN KEY ([PictureId]) REFERENCES [Picture]([Id]), 
    CONSTRAINT [FK_Recipe_ToOrigin] FOREIGN KEY ([OriginId]) REFERENCES [Origin]([Id]), 
    CONSTRAINT [FK_Recipe_ToTheme] FOREIGN KEY ([ThemeId]) REFERENCES [Theme]([Id]) 
)
