CREATE DATABASE Bitbucket
USE Bitbucket

-- Problem 01

CREATE TABLE Users
(
Id INT PRIMARY KEY IDENTITY,
Username  VARCHAR(30) NOT NULL,
[Password] VARCHAR(30) NOT NULL,
Email VARCHAR(30) NOT NULL
)

CREATE TABLE Repositories
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
CONSTRAINT PK_RepositoryContributorPK PRIMARY KEY (RepositoryId ,ContributorId)
)

CREATE TABLE Issues
(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(255) NOT NULL,
IssueStatus VARCHAR(6) NOT NULL,
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
Id INT PRIMARY KEY IDENTITY,
[Message] VARCHAR(255) NOT NULL,
IssueId INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(100) NOT NULL,
Size DECIMAL(15,2) NOT NULL,
ParentId INT FOREIGN KEY REFERENCES Files(Id),
CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

-- Problem 02

INSERT INTO Files
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix',	7662.92, 7, 7)

INSERT INTO Issues
VALUES
('Critical Problem with HomeController.cs file','open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs',	'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

-- Problem 03

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

-- Problem 04

DELETE 
FROM RepositoriesContributors
WHERE RepositoryId IN (SELECT Id 
                       FROM Repositories 
                       WHERE [Name] LIKE 'Softuni-Teamwork')

DELETE 
FROM Issues
WHERE RepositoryId IN (SELECT Id 
                       FROM Repositories 
                       WHERE [Name] LIKE 'Softuni-Teamwork')

-- Problem 05

SELECT 
  Id,
  [Message], 
  RepositoryId, 
  ContributorId 
FROM Commits
ORDER BY 
  Id, 
  [Message],
  RepositoryId,
  ContributorId

-- Problem 06

SELECT 
  Id,
  [Name], 
  Size 
FROM Files
WHERE 
  Size > 1000
  AND [Name] LIKE '%html%'
ORDER BY 
  Size DESC, 
  Id, 
  [Name]

-- Problem 07

SELECT 
  i.Id,
  (u.Username + ' : '+ i.Title) AS [IssueAssignee]
FROM Issues AS i
JOIN Users AS u 
  ON i.AssigneeId = u.Id
ORDER BY 
  i.Id DESC, 
  i.AssigneeId

-- Problem 08

SELECT
  f.Id,
  f.[Name],
  CAST(f.Size AS VARCHAR(50)) + 'KB' AS Size
FROM Files AS f
LEFT JOIN Files AS p 
  ON p.ParentId = f.Id
WHERE p.ParentId IS NULL
ORDER BY 
  f.Id,
  f.[Name],
  Size DESC

-- Problem 09

SELECT TOP(5) 
  r.Id,
  [Name],
  COUNT(c.RepositoryId) AS Commits
FROM Repositories AS r
JOIN Commits AS c 
  ON c.RepositoryId = r.Id
LEFT JOIN RepositoriesContributors AS rc 
  ON rc.RepositoryId = r.Id
GROUP BY  
  r.Id,
  [Name]
ORDER BY 
  Commits DESC,
  r.Id, 
  [Name]

-- Problem 10

SELECT
  Username,
  AVG(Size) AS Size 
FROM Users AS u
JOIN Commits AS c 
  ON c.ContributorId = u.Id
JOIN Files AS f 
  ON f.CommitId = c.Id
GROUP BY Username
ORDER BY 
  Size DESC, 
  Username

-- Problem 11

GO

CREATE FUNCTION udf_UserTotalCommits(@username VARCHAR(20)) 
RETURNS VARCHAR(20)
AS
BEGIN
 RETURN (SELECT
           COUNT(Username)
         FROM Users AS u
         JOIN Commits AS c 
           ON c.ContributorId = u.Id
	 WHERE u.Username = @username)
END

GO

SELECT dbo.udf_UserTotalCommits('UnderSinduxrein')

-- Problem 12

GO

CREATE PROC usp_FindByExtension(@extension VARCHAR(10))
AS
  SELECT DISTINCT
    f.Id,
    f.[Name],
    CAST(f.Size AS VARCHAR(50)) + 'KB' AS Size
  FROM Files AS f
  LEFT JOIN Files AS p ON p.ParentId = f.Id
  WHERE f.[Name] LIKE '%' + @extension
  ORDER BY 
  f.Id,
  f.[Name],
  Size DESC
GO

EXEC usp_FindByExtension 'txt'
