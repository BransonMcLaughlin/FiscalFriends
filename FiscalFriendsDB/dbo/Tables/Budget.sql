CREATE TABLE [dbo].[Budget] (
    [BudgetID]    INT          NOT NULL,
    [Userid]      INT          NOT NULL,
    [TotalBudget] DECIMAL (18) NOT NULL,
    [StartDate]   DATE         NOT NULL,
    [EndDate]     DATE         NOT NULL,
    CONSTRAINT [PK_Budget] PRIMARY KEY CLUSTERED ([BudgetID] ASC)
);

