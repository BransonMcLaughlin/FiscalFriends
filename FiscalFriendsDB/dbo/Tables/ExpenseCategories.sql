CREATE TABLE [dbo].[ExpenseCategories] (
    [CategoryId]          INT         IDENTITY (1, 1) NOT NULL,
    [CategoryDescription] NCHAR (100) NULL,
    CONSTRAINT [PK_ExpenseCategories] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
    CONSTRAINT [FK_ExpenseCategories_ExpenseCategories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[ExpenseCategories] ([CategoryId])
);

