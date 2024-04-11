CREATE TABLE [dbo].[Debt] (
    [DebtId]             INT          NOT NULL,
    [UserId]             INT          NOT NULL,
    [LenderName]         VARCHAR (50) NOT NULL,
    [OutstandingBalance] DECIMAL (18) NOT NULL,
    [InterestRate]       DECIMAL (18) NOT NULL,
    [DateDue]            DATE         NOT NULL,
    [MonthlyPayment]     DECIMAL (18) NOT NULL,
    CONSTRAINT [PK_Debt] PRIMARY KEY CLUSTERED ([DebtId] ASC),
    CONSTRAINT [FK_UserId] FOREIGN KEY ([DebtId]) REFERENCES [dbo].[Debt] ([DebtId])
);

