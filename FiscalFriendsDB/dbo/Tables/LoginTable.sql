CREATE TABLE [dbo].[LoginTable] (
    [loginId]      INT           NOT NULL,
    [UserId]       INT           NOT NULL,
    [Email]        VARCHAR (50)  NOT NULL,
    [PasswordHash] VARCHAR (100) NOT NULL,
    CONSTRAINT [Login] PRIMARY KEY CLUSTERED ([loginId] ASC)
);



