IF OBJECT_ID(N'dbo.TableInfo', N'U') IS NULL
CREATE TABLE TableInfo (
   Fauf INTEGER,
   Boat INTEGER,
   Position INTEGER,
   PRIMARY KEY (Fauf, Boat, Position));

IF OBJECT_ID(N'dbo.TableProcess', N'U') IS NULL
CREATE TABLE TableProcess (
   Fauf INTEGER,
   Boat INTEGER,
   Position INTEGER,
   Charge NVARCHAR(50),
   FOREIGN KEY (Fauf, Boat, Position) REFERENCES TableInfo
      (Fauf, Boat, Position));

IF OBJECT_ID(N'dbo.TableProcess', N'U') IS NULL
CREATE TABLE TableProcess (
   Process_ID INTEGER IDENTITY (1,1),
   Fauf INTEGER,
   Boat INTEGER,
   Position INTEGER,
   Status INTEGER,
   DateFin DATETIME,
   Stand NVARCHAR(50),
   Version NVARCHAR(50),

   FOREIGN KEY (Fauf, Boat, Position) REFERENCES TableInfo
      (Fauf, Boat, Position));

IF OBJECT_ID(N'dbo.TableResult', N'U') IS NULL
CREATE TABLE TableResult (
   Process_ID INTEGER,
   Data1 INTEGER,
   Data2 INTEGER,
   Data3 INTEGER,
   FOREIGN KEY (Process_ID) REFERENCES TableProcess(Process_ID));