CREATE TABLE [dbo].[Rate]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [RateOnFive] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [RecipeId] INT NOT NULL, 
    [Date] DATETIME2 NOT NULL, 
    [Commentary] NVARCHAR(MAX) NULL, 
    CONSTRAINT [PK_Rate] PRIMARY KEY ([Id]), 
	CONSTRAINT [FK_Rate_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Rate_ToRecipe] FOREIGN KEY ([RecipeId]) REFERENCES [Recipe]([Id]), 
    CONSTRAINT [CK_Rate_OnFive] CHECK ([RateOnFive] >= 0 AND [RateOnFive] <= 5),
	CONSTRAINT [AK_UserId_RecipeId] UNIQUE(UserId, RecipeId)
)
