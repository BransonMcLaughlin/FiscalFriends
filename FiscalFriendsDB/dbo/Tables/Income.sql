CREATE TABLE [dbo].[Income] (
    [Incomeid]       INT          NOT NULL,
    [Userid]         INT          NOT NULL,
    [IncomeSource]   VARCHAR (50) NOT NULL,
    [IncomeAmount]   DECIMAL (18) NOT NULL,
    [IncomeInterval] DECIMAL (18) NOT NULL,
    [NetPayday]      DATE         NOT NULL,
    [Recurring]      VARCHAR (3)  NOT NULL,
    CONSTRAINT [PK_Income] PRIMARY KEY CLUSTERED ([Incomeid] ASC),
    CONSTRAINT [FK_Income_Income2] FOREIGN KEY ([Userid]) REFERENCES [dbo].[Income] ([Incomeid])
);

