CREATE TABLE [dbo].[DailyExpenses] (
    [ExpenseId]     INT           NOT NULL,
    [UserId]        INT           NOT NULL,
    [Date]          DATE          NOT NULL,
    [Category]      INT           NOT NULL,
    [Vendor]        VARCHAR (50)  NOT NULL,
    [Status]        VARCHAR (20)  NOT NULL,
    [PaymentMethod] VARCHAR (25)  NOT NULL,
    [Amount]        DECIMAL (18)  NOT NULL,
    [Recurring]     VARCHAR (3)   NOT NULL,
    [ReceiptImage]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_DailyExpenses] PRIMARY KEY CLUSTERED ([ExpenseId] ASC)
);

