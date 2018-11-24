CREATE TABLE [dbo].[Rate]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [RateOnFive] INT NOT NULL, 
    CONSTRAINT [PK_Rate] PRIMARY KEY ([Id]), 
    CONSTRAINT [CK_Rate_OnFive] CHECK ([RateOnFive] >= 0 AND [RateOnFive] <= 5) 
)
