CREATE TABLE [dbo].[User] (
    [PersonID]     INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (30)  NOT NULL,
    [LastName]     VARCHAR (30)  NOT NULL,
    [Email]        VARCHAR (100) NOT NULL,
    [PhoneNumber]  VARCHAR (20)  NOT NULL,
    [UserName]     VARCHAR (12)  NOT NULL,
    [PasswordHash] VARCHAR (100) NOT NULL,
    [LastLoggedIn] VARCHAR (100) NOT NULL,
    [Birthday]     DATE          NOT NULL,
    [AccountMade]  DATE          NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([PersonID] ASC)
);





