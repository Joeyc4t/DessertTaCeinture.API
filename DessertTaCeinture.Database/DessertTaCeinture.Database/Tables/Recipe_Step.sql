CREATE TABLE [dbo].[Recipe_Step]
(
	[RecipeId] INT NOT NULL , 
    [StepId] INT NOT NULL, 
	CONSTRAINT [PK_Recipe_Step] PRIMARY KEY ([RecipeId], [StepId]), 
    CONSTRAINT [FK_Recipe_Step_ToRecipe] FOREIGN KEY ([RecipeId]) REFERENCES [Recipe]([Id]), 
    CONSTRAINT [FK_Recipe_Ingredients_ToStep] FOREIGN KEY ([StepId]) REFERENCES [Step]([Id]), 
)
