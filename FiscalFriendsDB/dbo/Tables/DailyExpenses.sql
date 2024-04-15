CREATE TABLE [dbo].[DailyExpenses] (
    [ExpenseId]     INT           IDENTITY (1, 1) NOT NULL,
    [UserId]        INT           NULL,
    [Date]          DATETIME      NOT NULL,
    [Category]      INT           NOT NULL,
    [Vendor]        VARCHAR (50)  NOT NULL,
    [Status]        VARCHAR (20)  NULL,
    [PaymentMethod] VARCHAR (25)  NOT NULL,
    [Amount]        DECIMAL (18)  NOT NULL,
    [Recurring]     VARCHAR (3)   NULL,
    [ReceiptImage]  VARCHAR (100) NULL,
    [Description]   VARCHAR (100) NULL,
    CONSTRAINT [PK_DailyExpenses] PRIMARY KEY CLUSTERED ([ExpenseId] ASC),
    CONSTRAINT [FK_DailyExpenses_DailyExpenses] FOREIGN KEY ([Category]) REFERENCES [dbo].[ExpenseCategories] ([CategoryId])
);

