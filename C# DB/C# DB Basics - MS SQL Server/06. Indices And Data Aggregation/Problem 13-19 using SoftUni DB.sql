-- Problem 13

SELECT 
  DepartmentID, 
  SUM(Salary) AS TotalSalary 
FROM Employees
GROUP BY DepartmentID

-- Problem 14

SELECT
  DepartmentID,
  MIN(Salary) AS MinimumSalary
FROM Employees
WHERE 
  DepartmentID IN (2,5,7) 
  AND HireDate > '01-01-2000'
GROUP BY DepartmentID

-- Problem 15

SELECT * 
INTO temp_new_table 
FROM Employees
WHERE Salary > 30000

DELETE 
FROM temp_new_table 
WHERE ManagerID = 42

UPDATE temp_new_table
SET Salary += 5000
WHERE DepartmentID = 1

SELECT 
  DepartmentID,
  AVG(Salary) AS AverageSalary
FROM temp_new_table
GROUP BY DepartmentID

-- Problem 16

SELECT
  DepartmentID,
  MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

-- Problem 17

SELECT
  COUNT(Salary) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

-- Problem 18 *

SELECT
  DepartmentID,
  Salary AS ThirdHighestSalary
FROM
  (SELECT
    DepartmentID, 
	Salary, 
	DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS RankedSalary
  FROM Employees) AS e
WHERE RankedSalary = 3
GROUP BY DepartmentID, Salary

-- Problem 19 **

SELECT TOP 10 
  FirstName,
  LastName,
  e.DepartmentID
FROM Employees AS e
JOIN 
  (SELECT 
    DepartmentID, 
    AVG(Salary) AS AverageSalary
  FROM Employees 
  GROUP BY DepartmentID) AS avr 
  ON avr.DepartmentID = e.DepartmentID
WHERE e.Salary > avr.AverageSalary
ORDER BY e.DepartmentID