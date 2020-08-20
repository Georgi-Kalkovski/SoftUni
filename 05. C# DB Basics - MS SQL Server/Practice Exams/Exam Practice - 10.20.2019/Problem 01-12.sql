CREATE DATABASE [Service]
USE [Service]
-- Problem 01

CREATE TABLE Users
(
Id INT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(50) NOT NULL,
[Name] VARCHAR(50),
Birthdate DATETIME,
Age INT CHECK (Age > 0),
Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(25),
LastName VARCHAR(25),
Birthdate DATETIME,
Age INT CHECK (Age > 0),
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
Id INT PRIMARY KEY IDENTITY,
[Label] VARCHAR(25) NOT NULL
)

CREATE TABLE Reports
(
Id INT PRIMARY KEY IDENTITY,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
[Description] VARCHAR(200) NOT NULL,
UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

-- Problem 02

INSERT INTO Employees(FirstName, 
                      LastName, 
					  Birthdate, 
					  DepartmentId)
VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports(CategoryId,
                    StatusId,
                    OpenDate, CloseDate,
                    [Description],
                    UserId,
                    EmployeeId)
VALUES
(1,	1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6,	3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2,	'2015-09-07', NULL, 'Falling bricks on Str.58',5, 2),
(4,	3, '2017-07-03', '2017-07-06',	'Cut off streetlight on Str.11', 1, 1)

-- Problem 03

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

-- Problem 04

DELETE FROM Reports
WHERE StatusId = 4

DELETE FROM [Status]
WHERE Id = 4

-- Problem 05

SELECT 
  [Description], 
  FORMAT(OpenDate,'dd-MM-yyyy') AS [OpenDate]
FROM Reports AS r
LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
WHERE e.Id IS NULL
ORDER BY 
  r.OpenDate, 
  [Description]

--Problem 06

SELECT 
  [Description],
  [Name] AS CategoryName 
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
ORDER BY 
  [Description],
  CategoryName

-- Problem 07

SELECT TOP(5)
  c.[Name], 
  COUNT(CategoryId) AS ReportsNumber 
FROM Reports AS r
JOIN Categories AS c ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY 
  ReportsNumber DESC, 
  c.[Name]

-- Problem 08

SELECT 
  u.Username,
  c.[Name] AS CategoryName 
FROM Reports AS r
JOIN Users AS u ON u.Id = r.UserId
JOIN Categories AS c ON c.Id = r.CategoryId
WHERE FORMAT(u.Birthdate, 'MM dd') = FORMAT(r.OpenDate,'MM dd')
ORDER BY 
  Username, 
  CategoryName

-- Problem 09

SELECT
  (e.FirstName + ' '+ e.LastName) AS FullName,
  COUNT(DISTINCT u.Name) AS UsersCount
FROM Reports AS r
RIGHT JOIN Users AS u ON u.Id = r.UserId
RIGHT JOIN Employees AS e ON e.Id = r.EmployeeId

GROUP BY 
  e.FirstName, 
  e.LastName
ORDER BY 
  UsersCount DESC,
  FullName

-- Problem 10

SELECT 
  ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS Employee, 
  ISNULL(d.[Name], 'None') AS [Department],
  ISNULL(c.[Name], 'None') AS [Category],
  ISNULL([Description], 'None') AS [Description],
  ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None') AS [OpenDate],
  ISNULL(s.[Label], 'None') AS [Status],
  ISNULL(u.Name, 'None') AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e ON e.Id = r.EmployeeId
LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
LEFT JOIN [Status] AS s ON s.Id = r.StatusId
LEFT JOIN Categories AS c ON c.Id = r.CategoryId
LEFT JOIN Users AS u ON u.Id = r.UserId
ORDER BY 
  e.FirstName DESC,
  e.LastName DESC,
  d.[Name],
  c.[Name],
  r.[Description],
  r.[OpenDate],
  s.[Id],
  u.[Id]


-- Problem 11
GO

CREATE FUNCTION udf_HoursToComplete (@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
DECLARE @result INT

  IF (@StartDate IS NULL OR @EndDate IS NULL)
  BEGIN
    SET @result = 0
  END

  ELSE
  BEGIN
    SET @result = DATEDIFF(HOUR, @StartDate,@EndDate)
  END

  RETURN @result
END

GO 

 SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports

-- Problem 12

GO
CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS 
  
  DECLARE @employeeDeparment INT = (SELECT e.DepartmentId 
                                    FROM Employees AS e
								    WHERE e.Id = @EmployeeId)

  DECLARE @catetegoryDepartment INT = (SELECT c.DepartmentId 
                                       FROM Reports AS r 
								       JOIN Categories AS c ON r.CategoryId = c.Id 
								       WHERE r.Id = @ReportId)
  
  IF(@employeeDeparment = @catetegoryDepartment)
  BEGIN
    UPDATE Reports
    SET EmployeeId = @EmployeeId
    WHERE Id = @ReportId
  END
  
  ELSE
  BEGIN
    RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
  END
  
GO

EXEC usp_AssignEmployeeToReport 17, 2
EXEC usp_AssignEmployeeToReport 30, 1

GO