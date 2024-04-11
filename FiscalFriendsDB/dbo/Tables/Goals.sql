CREATE TABLE [dbo].[Goals] (
    [GoalId]       INT          NOT NULL,
    [UserId]       INT          NOT NULL,
    [GoalName]     VARCHAR (50) NOT NULL,
    [GoalNumber]   DECIMAL (18) NOT NULL,
    [GoalDate]     DATE         NOT NULL,
    [GoalStatus]   VARCHAR (50) NOT NULL,
    [GoalProgress] DECIMAL (18) NOT NULL,
    CONSTRAINT [PK_Goals] PRIMARY KEY CLUSTERED ([GoalId] ASC),
    CONSTRAINT [FK_Goal] FOREIGN KEY ([GoalId]) REFERENCES [dbo].[Goals] ([GoalId])
);

