CREATE TABLE [dbo].[Subscription] (
    [SubscriptionId]     INT          NOT NULL,
    [UserId]             INT          NOT NULL,
    [ServiceTierName]    VARCHAR (20) NOT NULL,
    [MonthlyCost]        DECIMAL (18) NOT NULL,
    [StartDate]          DATE         NOT NULL,
    [RenewalDate]        DATE         NOT NULL,
    [ActiveSubscription] VARCHAR (3)  NOT NULL,
    CONSTRAINT [PK_Subscription] PRIMARY KEY CLUSTERED ([SubscriptionId] ASC),
    CONSTRAINT [FK_Subscription] FOREIGN KEY ([SubscriptionId]) REFERENCES [dbo].[Subscription] ([SubscriptionId])
);

