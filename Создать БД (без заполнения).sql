/*Создать таблицу подразделений*/
CREATE TABLE [dbo].[Departments]
(
	[ID] [int] IDENTITY(1,1) PRIMARY KEY,
	[DepName] [nvarchar](75) NOT NULL
)

/*Создать таблицу сотрудников*/
CREATE TABLE [dbo].[Employees]
(
	[ID] [int] IDENTITY(1,1) PRIMARY KEY,
	[FIO] [nvarchar](100) NOT NULL,
	[DepName] [nvarchar](75) NOT NULL,
	[Phone] [nvarchar](30) NOT NULL,
	[PhotoURL] [nvarchar](255) NULL,
	[DepID] [int] NOT NULL
)

/*Заполнить таблицу подразделений*/
INSERT INTO [dbo].[Departments] ([DepName])
VALUES (N'Служба ИТ'), (N'Служба теплосбыта'), (N'Отдел кадров'), (N'Бухгалтерия'), (N'Охрана труда');