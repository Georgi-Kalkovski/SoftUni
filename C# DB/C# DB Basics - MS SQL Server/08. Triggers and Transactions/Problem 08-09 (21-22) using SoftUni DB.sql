
-- Problem 08 (21)

CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
  BEGIN TRANSACTION
  
  DECLARE @assignsProjects INT = (SELECT COUNT(*) 
                                  FROM EmployeesProjects
  								  WHERE EmployeeID = @emloyeeId)
  
  IF @assignsProjects >= 3
  BEGIN
    ROLLBACK
    RAISERROR('The employee has too many projects!', 16,1)
    RETURN
  END

  INSERT INTO  EmployeesProjects(EmployeeId, ProjectId)
  VALUES(@emloyeeId,@projectID)

COMMIT

GO

SELECT * FROM EmployeesProjects

-- Problem 09 (22)

GO

CREATE TABLE Deleted_Employees
(
EmployeeId INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(50) NOT NULL, 
LastName NVARCHAR(50) NOT NULL, 
MiddleName NVARCHAR(50), 
JobTitle NVARCHAR(50), 
DepartmentId INT, 
Salary DECIMAL(15,4)
)

GO

CREATE TRIGGER tr_Deleted_Employees
ON Employees
AFTER DELETE
AS
BEGIN
  INSERT INTO Deleted_Employees
    SELECT 
	  FirstName,
	  LastName,
	  MiddleName,
	  JobTitle,
	  DepartmentID,
	  Salary
	FROM deleted
END