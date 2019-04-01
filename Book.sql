 CREATE TABLE [dbo].[Book] (
    [ISBN] NVARCHAR(30),
    [Title] NVARCHAR(100),
    [Year_Published] INT,
    [Author_ID] INT,
    [Author_First_Name] NVARCHAR(30),
    [Author_Last_Name] NVARCHAR(30),
    [Author_TFN] INT,
	PRIMARY KEY (ISBN),
);
