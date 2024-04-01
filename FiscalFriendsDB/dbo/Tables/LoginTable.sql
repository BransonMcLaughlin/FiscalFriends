CREATE TABLE [dbo].[LoginTable] (
    [loginId]      INT           NOT NULL,
    [UserId]       INT           NOT NULL,
    [Email]        VARCHAR (100)  NOT NULL,
    [PasswordHash] VARCHAR (100) NOT NULL,
    CONSTRAINT [Login] PRIMARY KEY CLUSTERED ([loginId] ASC)
);

