CREATE TABLE [dbo].[User] (
    [UserID]       INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (30)  NOT NULL,
    [LastName]     VARCHAR (30)  NOT NULL,
    [Email]        VARCHAR (20)  NOT NULL,
    [PhoneNumber]  VARCHAR (20)  NOT NULL,
    [UserName]     VARCHAR (12)  NOT NULL,
    [PasswordHash] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

