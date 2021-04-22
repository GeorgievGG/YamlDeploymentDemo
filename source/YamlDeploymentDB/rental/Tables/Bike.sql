﻿CREATE TABLE [dbo].[Bike]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL UNIQUE,
	[Price] NUMERIC(7,2) NOT NULL,
	[Available] BIT NOT NULL,
	[RentedUntil] DATETIME2 (7) NULL
)
