-- Problem 01

SELECT TOP 5 
EmployeeID, JobTitle, e.AddressID, AddressText 
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY e.AddressID

-- Problem 02

SELECT TOP 50 e.FirstName, e.LastName, t.[Name], a.AddressText 
FROM Addresses AS a
JOIN Towns AS t ON a.TownID = t.TownID
JOIN Employees AS e ON e.AddressID = a.AddressID
ORDER BY FirstName,LastName

-- Problem 03

SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name] AS DepartmentName
FROM Departments AS d
JOIN Employees AS e ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

-- Problem 04

SELECT TOP 5 e.EmployeeID, e.FirstName, e.Salary, d.[Name] AS DepartmentName 
FROM Departments AS d
JOIN Employees AS e ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY d.DepartmentID

-- Problem 05

SELECT TOP 3 e.EmployeeID, e.FirstName 
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

-- Problem 06

SELECT e.FirstName, e.LastName, e.HireDate, d.[Name] AS DeptName 
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '01-01-1999' AND d.[Name] IN ('Sales','Finance')
ORDER BY e.HireDate

-- Problem 07

SELECT TOP 5 e.EmployeeID, e.FirstName, p.[Name] AS ProjectName 
FROM EmployeesProjects AS ep
JOIN Employees AS e ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '08-13-2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

-- Problem 08

SELECT e.EmployeeID, e.FirstName, 
CASE
    WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	ELSE p.[Name]
END AS ProjectName
FROM EmployeesProjects AS ep
JOIN Employees AS e ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

-- Problem 09

SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS ManagerName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID

-- Problem 10

SELECT TOP 50
e.EmployeeID, 
(e.FirstName + ' ' + e.LastName) AS EmployeeName,
(m.FirstName + ' ' + m.LastName) AS ManagerName,
d.[Name] AS DepartmentName
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- Problem 11

SELECT TOP 1 AVG(e.Salary) AS MinAverageSalary
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
ORDER BY AVG(e.Salary)
