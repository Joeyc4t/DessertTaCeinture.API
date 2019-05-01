CREATE TABLE [dbo].[Recipe_Ingredients]
(
    [Id] INT NOT NULL IDENTITY(1,1), 
	[RecipeId] INT NOT NULL, 
    [IngredientId] INT NOT NULL,  
    [Quantity] FLOAT NOT NULL,  
    [Unit] VARCHAR(50) NOT NULL,
    CONSTRAINT [PK_Recipe_Ingredients] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Recipe_Ingredients_ToRecipe] FOREIGN KEY ([RecipeId]) REFERENCES [Recipe]([Id]), 
    CONSTRAINT [FK_Recipe_Ingredients_ToIngredient] FOREIGN KEY ([IngredientId]) REFERENCES [Ingredient]([Id]), 
    CONSTRAINT [CK_Recipe_Ingredients_Quantity] CHECK ([Quantity] > 0) 
)