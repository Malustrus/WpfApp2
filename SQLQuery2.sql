IF OBJECT_ID(N'dbo.Info', N'U') IS NULL
CREATE TABLE Info (
   Fauf INTEGER,
   Boat INTEGER,
   Position INTEGER,
   SerialNumber NVARCHAR(50)
   PRIMARY KEY (Fauf, Boat, Position));

IF OBJECT_ID(N'dbo.Charge', N'U') IS NULL
CREATE TABLE Charge (
   Fauf INTEGER,
   Boat INTEGER,
   Position INTEGER,
   Charge NVARCHAR(50),
   FOREIGN KEY (Fauf, Boat, Position) REFERENCES Info
      (Fauf, Boat, Position));

IF OBJECT_ID(N'dbo.Process', N'U') IS NULL
CREATE TABLE Process (
   Process_ID INTEGER IDENTITY (1,1),
   Fauf INTEGER NOT NULL,
   Boat INTEGER NOT NULL,
   Status INTEGER,
   DateFin DATETIME,
   Stand NVARCHAR(50),
   Version NVARCHAR(50));

IF OBJECT_ID(N'dbo.Result', N'U') IS NULL
CREATE TABLE Result (
   Process_ID INTEGER,
   Position INTEGER,
   Data1 INTEGER,
   Data2 INTEGER,
   Data3 INTEGER,
   CONSTRAINT FK_Process_Result FOREIGN KEY (Process_ID) REFERENCES Process(Process_ID));