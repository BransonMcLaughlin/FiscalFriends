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
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (1, N'Fast Food')
GO
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (2, N'Groceries')
GO
INSERT [dbo].[ExpenseCategories] ([CategoryId], [CategoryDescription]) VALUES (3, N'Misc.')
GO
SET IDENTITY_INSERT [dbo].[ExpenseCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([PersonID], [FirstName], [LastName], [Email], [PhoneNumber], [UserName], [PasswordHash], [LastLoggedIn], [Birthday], [AccountMade]) VALUES (1, N'Andrew', N'Lambert', N'Andrew2020Lambert@gmail.com', N'18324973965', N'Lambertal1', N'$2a$13$j7/oIxHHX32XRUGYfWRhXOyhqoN0Vt2DyYAojtpraWRDdaDS3x6AG', CAST(N'2024-04-15T10:01:43.747' AS DateTime), CAST(N'2024-04-24' AS Date), CAST(N'2024-04-15T08:26:31.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
