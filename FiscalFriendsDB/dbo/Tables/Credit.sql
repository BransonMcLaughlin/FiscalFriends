CREATE TABLE [dbo].[Credit] (
    [PaymentMethodId] INT           NOT NULL,
    [MethodName]      VARCHAR (50)  NOT NULL,
    [UserId]          INT           NOT NULL,
    [AccountDetails]  VARCHAR (100) NOT NULL,
    [ActiveCard]      VARCHAR (3)   NOT NULL
);

