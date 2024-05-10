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
SET IDENTITY_INSERT [dbo].[ExpenseCategories] ON 
GO
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (1, N'Fast Food                                                                                           ')
GO
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (2, N'Groceries                                                                                           ')
GO
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (3, N'Housing                                                                                             ')
GO
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (4, N'Healthcare                                                                                          ')
GO
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (5, N'Utilities                                                                                           ')
GO
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (6, N'Entertainment                                                                                       ')
GO
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (7, N'Education                                                                                           ')
GO
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (8, N'Miscellaneous                                                                                       ')
GO
SET IDENTITY_INSERT [dbo].[ExpenseCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([PersonID], [FirstName], [LastName], [Email], [PhoneNumber], [UserName], [PasswordHash], [LastLoggedIn], [Birthday], [AccountMade]) VALUES (1, N'Root', N'User', N'Root@FiscalFriends.com', N'1111111111', N'Root', N'$2a$13$Xop1oGt8cuZYGl9QJOBRY.F0CPJFRYhqVizoZcwlAi9H51UYXdMiu', CAST(N'2024-05-10T10:05:55.223' AS DateTime), CAST(N'2024-05-10' AS Date), CAST(N'2024-05-10T10:05:38.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
