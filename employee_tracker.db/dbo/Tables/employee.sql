CREATE TABLE [dbo].[employee] (
    [Name]     VARCHAR (100) NOT NULL,
    [ID]       INT           NOT NULL,
    [Email]    VARCHAR (100) NULL,
    [phone]    VARCHAR (20)  NULL,
    [Address 1]VARCHAR (100) NULL,
	[Address 2]VARCHAR (100) NULL,
	[City]		VARCHAR(50)	NULL,
	[State]		VARCHAR(100)NULL,
	[Zip_Code]	VARCHAR(50) NULL,
	[Pay Rate] MONEY         NOT NULL,
    [Hired_at] DATETIME      NOT NULL

);

