-- Problem 18

CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns 
(
Id INT PRIMARY KEY IDENTITY, 
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Addresses 
(
Id INT PRIMARY KEY IDENTITY, 
AddressText NVARCHAR(30) NOT NULL, 
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Departments 
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Employees 
(
Id INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(30) NOT NULL, 
MiddleName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL,  
JobTitle NVARCHAR(30) NOT NULL, 
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL, 
HireDate DATE NOT NULL,
Salary DECIMAL (5,2) NOT NULL,
AddressId INT NOT NULL
)
INSERT INTO Towns
VALUES ('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments
VALUES ('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees
VALUES ('Ivan', 'Ivanov', 'Ivanov',	'.NET Developer',4,'2013-02-01',3500.00,1),
('Petar','Petrov','Petrov','Senior Engineer',1,'2004-03-02',4000.00,2),
('Maria', 'Petrova', 'Ivanova', 'Intern',5, '2016-08-28', 525.25,3),
('Georgi','Teziev','Ivanov','CEO',2,'2007-12-09',3000.00,4),
('Peter','Pan','Pan','Intern',3,'2016-08-28',599.88,4)

--Problem 19

SELECT * FROM Towns
SELECT * FROM Departments 
SELECT * FROM Employees 

-- Problem 20

SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

--Problem 21

SELECT[Name] 
FROM Towns
ORDER BY [Name]

SELECT[Name] 
FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary
FROM Employees
ORDER BY Salary DESC

-- Problem 22

UPDATE Employees 
SET Salary *= 1.1

SELECT Salary
FROM Employees

-- Problem 23

USE Hotel

UPDATE Payments
SET TaxRate -= 0.03

SELECT TaxRate FROM Payments

-- Problem 24
DELETE FROM Occupancies
