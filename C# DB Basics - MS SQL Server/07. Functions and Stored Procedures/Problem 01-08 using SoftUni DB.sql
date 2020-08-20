-- Problem 01

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
  SELECT FirstName, LastName 
  FROM Employees
  WHERE Salary > 35000
GO

EXEC usp_GetEmployeesSalaryAbove35000
GO

-- Problem 02

CREATE PROC usp_GetEmployeesSalaryAboveNumber @Number DECIMAL(18,4)
AS
  SELECT FirstName, LastName 
  FROM Employees
  WHERE Salary >= @Number
GO

EXEC usp_GetEmployeesSalaryAboveNumber @Number = 48100
GO

-- Problem 03

CREATE PROC usp_GetTownsStartingWith @TownNameStartingWith NVARCHAR(50)
AS
  SELECT [Name] AS Town 
  FROM Towns
  WHERE [Name] LIKE @TownNameStartingWith + '%'
GO

EXEC usp_GetTownsStartingWith @TownNameStartingWith = 'b'
GO

-- Problem 04

CREATE PROC usp_GetEmployeesFromTown @TownName NVARCHAR(50)
AS
  SELECT FirstName, LastName 
  FROM Employees AS e
  JOIN Addresses AS a ON e.AddressID = a.AddressID
  JOIN Towns AS t ON t.TownID = a.TownID
  WHERE t.[Name] = @TownName
GO

EXEC usp_GetEmployeesFromTown @TownName = 'Sofia'
GO

-- Problem 05

CREATE FUNCTION dbo.ufn_GetSalaryLevel (@salary DECIMAL(18,4))
RETURNS NVARCHAR(50)
AS 
BEGIN
  DECLARE @result NVARCHAR(50)

  IF @salary < 30000 
    SET @result ='Low'

  IF @salary >= 30000 AND @salary <= 50000 
    SET @result = 'Average'

  IF @salary > 50000 
    SET @result ='High'

  RETURN @result
END
GO

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level] 
FROM Employees
GO 

-- Problem 05 with Case

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS VARCHAR(20)
AS
BEGIN
  DECLARE @result VARCHAR(20)
  RETURN CASE
    WHEN @salary < 30000 THEN 'Low'
    WHEN @salary <= 50000 THEN 'Average'
    ELSE 'High'
END
END

-- Problem 06

CREATE PROC usp_EmployeesBySalaryLevel @SalaryLevel NVARCHAR(50)
AS
  SELECT FirstName, LastName 
  FROM Employees
  WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
GO

EXEC usp_EmployeesBySalaryLevel @SalaryLevel = 'high'
GO

-- Problem 07

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(25))
RETURNS BIT
AS 
BEGIN
  DECLARE @result BIT = 1;
  DECLARE @counter INT = 1;
  DECLARE @wordLen INT = LEN(@word);
    WHILE(@counter <= @wordLen)
	BEGIN
	DECLARE @currentLetter CHAR(1) = SUBSTRING(@word, @counter, 1);
	  IF(@setOfLetters NOT LIKE '%' + @currentLetter + '%')
	  BEGIN
	  SET @result = 0;
	  END
	SET @counter += 1;
	END
  RETURN @result;
END
GO

SELECT 
  FirstName, 
  dbo.ufn_IsWordComprised('j', FirstName) AS [Result] 
FROM Employees
GO

-- Problem 08 *

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
  DELETE FROM EmployeesProjects
  WHERE EmployeeID 
    IN (SELECT EmployeeID 
        FROM Employees 
        WHERE DepartmentID = @departmentId)
  
  ALTER TABLE Departments
  ALTER COLUMN ManagerID INT NULL

  UPDATE Employees
  SET ManagerID = NULL
  WHERE ManagerID 
    IN (SELECT EmployeeID 
        FROM Employees 
        WHERE DepartmentID = @departmentId)

  UPDATE Departments
  SET ManagerID = NULL
  WHERE DepartmentID = @departmentId

  DELETE FROM Employees
  WHERE DepartmentID = @departmentId

  DELETE FROM Departments
  WHERE DepartmentID = @departmentId

  SELECT COUNT(*)
  FROM Employees
  WHERE DepartmentID = @departmentId
GO
