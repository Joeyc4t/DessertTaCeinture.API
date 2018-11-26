CREATE TABLE [dbo].[Rating]
(
	[UserId] INT NOT NULL, 
    [RecipeId] INT NOT NULL, 
    [RateId] INT NOT NULL, 
    [RatingDate] DATETIME2 NOT NULL , 
    [Commentary] TEXT NULL, 
    CONSTRAINT [PK_Rating] PRIMARY KEY ([UserId], [RecipeId]), 
    CONSTRAINT [FK_Rating_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Rating_ToRecipe] FOREIGN KEY ([RecipeId]) REFERENCES [Recipe]([Id]), 
    CONSTRAINT [FK_Rating_ToRate] FOREIGN KEY ([RateId]) REFERENCES [Rate]([Id]) 
)
