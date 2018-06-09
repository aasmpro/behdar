 use [BehdarDrugStore]


CREATE TABLE [dbo].[user]
(
    [username] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [password] NVARCHAR(50) NOT NULL,
	[fname] NVARCHAR(50) NOT NULL,
	[lname] NVARCHAR(50) NOT NULL,
	[ncode] NVARCHAR(10) NOT NULL,
	[type] INT NOT NULL DEFAULT 0,
	[status] INT NOT NULL
)

CREATE TABLE [dbo].[dfactory]
(
	[id] INT NOT NULL IDENTITY(0,1) PRIMARY KEY,
	[name] NVARCHAR(50) NOT NULL,
	[data] TEXT NOT NULL
)

CREATE TABLE [dbo].[insurance]
(
	[id] INT NOT NULL IDENTITY(0,1) PRIMARY KEY,
	[name] NVARCHAR(50) NOT NULL,
	[off] FLOAT(2) NOT NULL
)

CREATE TABLE [dbo].[drug]
(
	[id] INT NOT NULL IDENTITY(0,1) PRIMARY KEY,
	[name] NVARCHAR(50) NOT NULL,
	[type] NVARCHAR(50) NOT NULL,
	[price] INT NOT NULL,
	[dfactory] INT NULL,
	[amount] INT NOT NULL,
	FOREIGN KEY ([dfactory]) REFERENCES [dbo].[dfactory]([id]) ON UPDATE CASCADE ON DELETE SET NULL
)

--CREATE TABLE [dbo].[store]
--(
--	[drug] INT NOT NULL PRIMARY KEY,
--	FOREIGN KEY (drug) REFERENCES [dbo].[drug]([id]) ON UPDATE CASCADE ON DELETE CASCADE
--)

CREATE TABLE [dbo].[prescription]
(
	[id] INT NOT NULL IDENTITY(0,1) PRIMARY KEY,
	[flname] NVARCHAR(100) NOT NULL,
	[ncode] NVARCHAR(10) NOT NULL,
	[creator] NVARCHAR(50) NULL,
	[insurance] INT NULL,
	[date] SMALLDATETIME NULL,
	FOREIGN KEY ([creator]) REFERENCES [dbo].[user]([username]) ON UPDATE CASCADE ON DELETE SET NULL,
	FOREIGN KEY ([insurance]) REFERENCES [dbo].[insurance]([id]) ON UPDATE CASCADE ON DELETE SET NULL
)

CREATE TABLE [dbo].[presdrug]
(
	[prescription] INT NOT NULL,
	[drug] INT NOT NULL,
	[amount] INT NOT NULL,
	PRIMARY KEY([prescription], [drug]),
	FOREIGN KEY([prescription]) REFERENCES [dbo].[prescription]([id]) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY([drug]) REFERENCES [dbo].[drug]([id]) ON UPDATE CASCADE ON DELETE NO ACTION
)

