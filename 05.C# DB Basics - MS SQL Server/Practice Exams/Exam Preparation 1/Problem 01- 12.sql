CREATE DATABASE Airport

USE Airport

--- Problem 01

CREATE TABLE Planes
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range] INT NOT NULL
)

CREATE TABLE Flights
(
Id INT PRIMARY KEY IDENTITY,
DepartureTime DATETIME,
ArrivalTime DATETIME,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
PlaneId INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age INT NOT NULL,
[Address] VARCHAR(30) NOT NULL,
PassportId VARCHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
Id INT PRIMARY KEY IDENTITY,
LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
Id INT PRIMARY KEY IDENTITY,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
FlightId INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
LuggageId INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
Price DECIMAL(15,2) NOT NULL
)

-- Problem 02

INSERT INTO Planes ([Name], Seats, [Range])
VALUES 
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes ([Type])
VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

-- Problem 03

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Carlsbad')

-- Problem 04

DELETE FROM Tickets
WHERE FlightId = (SELECT TOP(1) Id FROM Flights WHERE Destination = 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

-- Empty the Tables
-- Use the given Dataset for the next Problems

-- Problem 05

SELECT * 
FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id, [Name], Seats, [Range]

-- Problem 06

SELECT FlightId, SUM(Price) AS Price 
FROM Tickets
GROUP BY FlightId
ORDER BY Price DESC, FlightId

-- Problem 07

SELECT 
  (p.FirstName + ' ' + p.LastName) AS [Full Name], 
  f.Origin, 
  f.Destination 
FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
JOIN Flights AS f ON f.Id = t.FlightId 
ORDER BY [Full Name], Origin, Destination

-- Problem 08

SELECT 
  FirstName AS [First Name],
  LastName AS [Last Name],
  Age 
FROM Passengers AS p
LEFT JOIN Tickets AS t 
  ON t.PassengerId = p.Id
WHERE t.Id IS NULL
ORDER BY Age DESC, [First Name],[Last Name]

-- Problem 09

SELECT 
  (p.FirstName + ' ' + p.LastName) AS [Full Name],
  pl.[Name] AS [Plane Name],
  (f.Origin + ' - ' + f.Destination) AS [Trip],
  lt.[Type] AS [Luggage Type]
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
JOIN Flights AS f ON f.Id = t.FlightId
JOIN Luggages AS l ON l.Id = t.LuggageId
JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
JOIN Planes AS pl ON pl.Id = f.PlaneId
ORDER BY 
  [Full Name],
  [Name],
  Origin,
  Destination,
  [Luggage Type]

  -- Problem 10

SELECT 
  p.[Name],
  Seats,
  COUNT(t.Id) AS [Passengers Count]
FROM Planes AS p
LEFT JOIN Flights AS f ON f.PlaneId = p.Id
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
GROUP BY [Name], Seats
ORDER BY 
  [Passengers Count] DESC,
  p.[Name], 
  Seats

GO
  -- Problem 11

CREATE FUNCTION udf_CalculateTickets
(@origin NVARCHAR(30),
@destination NVARCHAR(30), 
@peopleCount INT) 
RETURNS NVARCHAR(50)
AS
BEGIN
  DECLARE @result NVARCHAR(50)

  IF @peopleCount <= 0
  BEGIN
    SET @result = 'Invalid people count!'
	RETURN @result
  END
  
  DECLARE @tripId INT = (SELECT f.Id FROM Flights AS f
                         JOIN Tickets AS t ON t.FlightId = f.Id
                         WHERE Destination  = @destination 
						       AND Origin = @origin)
  
  IF @tripId IS NULL
  BEGIN
    SET @result = 'Invalid flight!'
	RETURN @result
  END

  DECLARE @totalPrice DECIMAL(15,2) = (SELECT t.Price FROM Flights AS f
                                    JOIN Tickets AS t ON t.FlightId = f.Id
                                    WHERE Destination  = @destination 
				                       AND Origin = @origin)
  SET @result = 'Total price ' + CAST(@totalPrice * @peopleCount AS NVARCHAR(50))
  RETURN @result
END

GO
-- Problem 12

CREATE PROC usp_CancelFlights
AS
  UPDATE Flights
  SET ArrivalTime = NULL, DepartureTime = NULL
  WHERE ArrivalTime > DepartureTime
GO
