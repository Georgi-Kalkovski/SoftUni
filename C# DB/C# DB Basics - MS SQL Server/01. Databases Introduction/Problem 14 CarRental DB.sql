-- Problem 14

CREATE DATABASE CarRental 
USE CarRental

CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(30) NOT NULL,
DailyRate DECIMAL(3,1) NOT NULL,
WeeklyRate DECIMAL(3,1) NOT NULL,
MonthlyRate DECIMAL(3,1) NOT NULL,
WeekendRate DECIMAL(3,1) NOT NULL
)

CREATE TABLE Cars
(
Id INT PRIMARY KEY IDENTITY,
PlateNumber INT NOT NULL,
Manufacturer NVARCHAR(30) NOT NULL,
Model NVARCHAR(30) NOT NULL,
CarYear INT NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
Doors INT NOT NULL,
Picture NVARCHAR(MAX) NOT NULL,
Condition NVARCHAR(30) NOT NULL,
Available BIT NOT NULL
)

CREATE TABLE Employees 
(
Id INT PRIMARY KEY IDENTITY, 
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(30) NOT NULL, 
Title NVARCHAR(30) NOT NULL, 
Notes NVARCHAR(30) NOT NULL
)

CREATE TABLE Customers 
(
Id INT PRIMARY KEY IDENTITY, 
DriverLicenceNumber INT NOT NULL, 
FullName NVARCHAR(30) NOT NULL, 
[Address] NVARCHAR(30) NOT NULL, 
City NVARCHAR(30) NOT NULL, 
ZIPCode INT NOT NULL, 
Notes NVARCHAR(30) NOT NULL
)

CREATE TABLE RentalOrders 
(
Id INT PRIMARY KEY IDENTITY, 
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id) NOT NULL, 
CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL, 
CarId INT FOREIGN KEY REFERENCES Cars(Id) NOT NULL, 
TankLevel INT NOT NULL, 
KilometrageStart DECIMAL(15,3) NOT NULL, 
KilometrageEnd DECIMAL(15,3) NOT NULL,
TotalKilometrage DECIMAL(15,3) NOT NULL, 
StartDate DATE NOT NULL, 
EndDate DATE NOT NULL, 
TotalDays INT NOT NULL, 
RateApplied DECIMAL(15,3), 
TaxRate DECIMAL(15,3), 
OrderStatus NVARCHAR(30), 
Notes NVARCHAR(MAX)
)

INSERT INTO Categories
VALUES ('Speedy', 11.1, 11.1,11.1, 11.1),
('Not So Speedy', 11.1, 11.1,11.1, 11.1),
('Not Speedy At All', 11.1, 11.1,11.1, 11.1)

INSERT INTO Cars
VALUES (1010120, 'BUGATI', 'asfasf',2000,1,2,'dfgasdgsdgasda', 'perfect', 1),
(1010101, 'BMW', 'asfasf',2000,2,4,'dfgasdgsdgasda', 'very perfect', 1),
(1031010, 'TOYOTA', 'asfasf',2000,3,6,'dfgasdgsdgasda', 'most perfect', 1)

INSERT INTO Employees
VALUES ('Georgi', 'Georgiev', 'Menidjur', 'dfgsdgasdgasd'),
('Pesho', 'Pesho', 'Ne e menidjur', 'dfgsdgasdgasd'),
('Petur', 'Petrov', 'Chistach', 'dfgsdgasdgasd')

INSERT INTO Customers
VALUES (51461, 'Ani', 'adress1', 'Sofia', 1231, 'Iskamkolichka'),
(2351235, 'Mimi', 'adress2', 'Plovdiv', 12312, 'Iskamkola'),
(5113461, 'Gabi', 'adress3', 'Varna', 1124, 'Iskam kolishte')

INSERT INTO RentalOrders
VALUES (1, 1, 1, 123, 2, 4, 20, '02-02-2020', '03-02-2020', 1, NULL, NULL, NULL, NULL),
	   (2, 2, 2, 123, 2, 4, 20, '02-02-2020', '03-02-2020', 1, NULL, NULL, NULL, NULL),
	   (3, 3, 3, 123, 2, 4, 20, '02-02-2020', '03-02-2020', 1, NULL, NULL, NULL, NULL)
