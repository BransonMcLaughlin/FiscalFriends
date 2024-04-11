/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([PersonID], [FirstName], [LastName], [Email], [PhoneNumber], [UserName], [PasswordHash], [LastLoggedIn], [Birthday], [AccountMade]) VALUES (1, N'1', N'1', N'11', N'1', N'1', N'$2a$13$LkxvZ4OydPvFWB2SQNp9HuPsYBRAz1CE5Y0DfP0d5oGvCg/fp890K', N'Apr  3 2024  4:53PM', CAST(N'1111-01-01' AS Date), CAST(N'2024-04-01' AS Date))
GO
INSERT [dbo].[User] ([PersonID], [FirstName], [LastName], [Email], [PhoneNumber], [UserName], [PasswordHash], [LastLoggedIn], [Birthday], [AccountMade]) VALUES (2, N'Branson', N'McLaughlin', N'mclaughlbw@jacks.sfasu.edu', N'1', N'Branson', N'$2a$13$3NsSiZWbZvgqNLbUs2pgWOcUqFPF4i6GhOItRwTf2rd2BaNFqVL8a', N'4/1/2024 1:30:16 PM', CAST(N'2004-05-20' AS Date), CAST(N'2024-04-01' AS Date))
GO
INSERT [dbo].[User] ([PersonID], [FirstName], [LastName], [Email], [PhoneNumber], [UserName], [PasswordHash], [LastLoggedIn], [Birthday], [AccountMade]) VALUES (3, N'Branson', N'McLaughlin', N'mclaughlbw@jacks.sfasu.edu', N'1', N'b', N'$2a$13$.e1xE1MJ7uEQ2g/Qd4wxbuqy6R2KLKuyFXdKOGdjDVpvoTohrrrCa', N'4/1/2024 1:55:36 PM', CAST(N'1111-01-11' AS Date), CAST(N'2024-04-01' AS Date))
GO
INSERT [dbo].[User] ([PersonID], [FirstName], [LastName], [Email], [PhoneNumber], [UserName], [PasswordHash], [LastLoggedIn], [Birthday], [AccountMade]) VALUES (4, N'Branson', N'McLaughlin', N'mclaughlbw@jacks.sfasu.edu', N'1', N'b', N'$2a$13$vCswPI6gF45.vRwCFXgMZ.wfwBQ1BjqLblNEGnZPU4D1lKQDkJLP6', N'4/1/2024 2:05:29 PM', CAST(N'1111-01-11' AS Date), CAST(N'2024-04-01' AS Date))
GO
INSERT [dbo].[User] ([PersonID], [FirstName], [LastName], [Email], [PhoneNumber], [UserName], [PasswordHash], [LastLoggedIn], [Birthday], [AccountMade]) VALUES (5, N'Branson', N'McLaughlin', N'mclaughlbw@jacks.sfasu.edu', N'1', N'b', N'$2a$13$zN/wHAY5XEVvNHsnypM.lOHX1xIysJICGr1B1iJckxTOXiheZ8cDO', N'4/1/2024 4:02:01 PM', CAST(N'2004-05-20' AS Date), CAST(N'2024-04-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
