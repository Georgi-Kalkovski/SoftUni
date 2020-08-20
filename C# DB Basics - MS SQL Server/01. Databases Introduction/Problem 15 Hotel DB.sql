--Problem 15

CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL, 
LastName NVARCHAR(30) NOT NULL, 
Title NVARCHAR(30) NOT NULL, 
Notes NVARCHAR(MAX)
)

CREATE TABLE Customers 
(
AccountNumber INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(30) NOT NULL, 
LastName NVARCHAR(30) NOT NULL,
PhoneNumber INT NOT NULL, 
EmergencyName NVARCHAR(30) NOT NULL, 
EmergencyNumber INT NOT NULL,
Notes NVARCHAR(MAX)
)

CREATE TABLE RoomStatus 
(
RoomStatus BIT NOT NULL,
Notes NVARCHAR(30)
)

CREATE TABLE RoomTypes 
(
RoomType NVARCHAR(30) NOT NULL,
Notes NVARCHAR(30)
)

CREATE TABLE BedTypes 
(
BedType NVARCHAR(30) NOT NULL, 
Notes NVARCHAR(30)
)

CREATE TABLE Rooms 
(
RoomNumber INT PRIMARY KEY IDENTITY,
RoomType NVARCHAR(30) NOT NULL,
BedType NVARCHAR(30) NOT NULL, 
Rate DECIMAL (3,1) NOT NULL,
RoomStatus NVARCHAR(30) NOT NULL, 
Notes NVARCHAR(30)
)

CREATE TABLE Payments
(
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
PaymentDate DATE NOT NULL, 
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
FirstDateOccupied DATE NOT NULL,
LastDateOccupied DATE NOT NULL, 
TotalDays INT NOT NULL, 
AmountCharged DECIMAL(15,2) NOT NULL, 
TaxRate DECIMAL(15,2) NOT NULL,  
TaxAmount DECIMAL(15,2) NOT NULL, 
PaymentTotal DECIMAL(15,2) NOT NULL, 
Notes NVARCHAR(1000)
)
CREATE TABLE Occupancies 
(
Id INT PRIMARY KEY IDENTITY, 
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
DateOccupied DATE, 
AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumber),
RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
RateApplied DECIMAL(15,2), 
PhoneCharge DECIMAL(15,2), 
Notes NVARCHAR(1000)
)

INSERT INTO Employees
VALUES ('Georgi','Georgiev','Hotelier', NULL),
('Georgi','Georgiev','Hotelier', NULL),
('Georgi','Georgiev','Hotelier', NULL)

INSERT INTO Customers
VALUES ('Petur','Petrov', 101010,'Panika', 191919,NULL),
('Petur','Petrov', 101010,'Panika', 191919,NULL),
('Petur','Petrov', 101010,'Panika', 191919,NULL)

INSERT INTO RoomStatus
VALUES (1,NULL),
(0,NULL),
(1,NULL)

INSERT INTO RoomTypes
VALUES ('Hubava', NULL),
('Hubava', NULL),
('Hubava', NULL)

INSERT INTO BedTypes
VALUES ('dvoino', NULL),
('edinichno', NULL),
('kingsize', NULL)

INSERT INTO Rooms
VALUES ('Hubava','dvoino',1,'gotova',NULL),
('Hubava','dvoino',1,'gotova',NULL),
('Hubava','dvoino',1,'gotova',NULL)

INSERT INTO Payments
VALUES (1, '02-02-2002', 3, '02-02-2002', '02-03-2002', 1, 2, 2, 2, 2, NULL),
	   (1, '02-02-2002', 3, '02-02-2002', '02-03-2002', 1, 2, 2, 2, 2, NULL),
	   (1, '02-02-2002', 3, '02-02-2002', '02-03-2002', 1, 2, 2, 2, 2, NULL)

INSERT INTO Occupancies
VALUES (1, '02-02-2002', 1, 1, 2, 123, NULL),
	   (1, '02-02-2002', 1, 1, 2, 123, NULL),
	   (1, '02-02-2002', 1, 1, 2, 123, NULL)
