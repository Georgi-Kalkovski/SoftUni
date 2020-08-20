CREATE DATABASE Airport
USE Airport

-- Problem 01

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
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
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

INSERT INTO Planes
VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes
VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

-- Problem 03

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId IN(SELECT Id FROM Flights WHERE Destination LIKE 'Carlsbad')

-- Problem 04

DELETE FROM Tickets
WHERE FlightId IN(SELECT Id FROM Flights WHERE Destination LIKE 'Ayn Halagim')

DELETE FROM Flights
WHERE Destination LIKE 'Ayn Halagim'

-- Problem 05

SELECT 
  Origin, 
  Destination
FROM Flights
ORDER BY
  Origin,
  Destination

-- Problem 06

SELECT 
  Id, 
  [Name],
  Seats,
  [Range] 
FROM Planes
WHERE [Name] LIKE '%Tr%'
ORDER BY 
  Id,
  [Name],
  Seats,
  [Range]

-- Problem 07

SELECT 
  FlightId,
  SUM(Price) AS Price
FROM Tickets
GROUP BY FlightId
ORDER BY 
  Price DESC,
  FlightId

-- Problem 08

SELECT TOP(10)
  FirstName,
  LastName,
  Price
FROM Passengers AS p
JOIN Tickets AS t 
  ON t.PassengerId = p.Id
ORDER BY 
  Price DESC,
  FirstName,
  LastName

-- Problem 09

SELECT 
  [Type],
  COUNT(l.Id) AS MostUsedLuggage
FROM LuggageTypes AS lt
JOIN Luggages AS l 
  ON l.LuggageTypeId = lt.Id
JOIN Passengers AS p 
  ON p.Id = l.PassengerId
GROUP BY 
  [Type]
ORDER BY 
  MostUsedLuggage DESC,
  [Type]

-- Problem 10

SELECT 
  (FirstName + ' ' + LastName) AS [Full Name],
  Origin,
  Destination
FROM Passengers AS p
JOIN Tickets AS t 
  ON t.PassengerId = p.Id
JOIN Flights AS  f 
  ON f.Id = t.FlightId
ORDER BY
  [Full Name],
  Origin,
  Destination

-- Problem 11

SELECT 
  FirstName,
  LastName,
  Age
FROM Passengers AS p
LEFT JOIN Tickets AS t 
  ON t.PassengerId = p.Id
WHERE t.Id IS NULL
ORDER BY 
  Age DESC,
  FirstName,
  LastName

-- Problem 12

SELECT
  PassportId,
  [Address]
FROM Passengers AS p
LEFT JOIN Luggages AS l 
  ON l.PassengerId = p.Id
WHERE l.Id IS NULL
ORDER BY 
  PassportId,
  [Address]

-- Problem 13

SELECT
  FirstName,
  LastName,
  COUNT(Destination) AS [Total Trips]
FROM Passengers AS p
LEFT JOIN Tickets AS t 
  ON t.PassengerId = p.Id
LEFT JOIN Flights AS f
  ON f.Id = t.FlightId
GROUP BY FirstName, LastName
ORDER BY 
  [Total Trips] DESC,
  FirstName,
  LastName

-- Problem 14

SELECT
  (FirstName + ' ' + LastName) AS [Full Name],
  pl.[Name] AS [Plane Name],
  (Origin + ' - ' + Destination) AS Trip,
  lt.[Type] AS [Luggage Type]
FROM Passengers AS p
JOIN Tickets AS t ON t.PassengerId = p.Id
JOIN Flights AS f ON f.Id = t.FlightId
JOIN Planes AS pl ON pl.Id = f.PlaneId
JOIN Luggages AS l ON l.Id = t.LuggageId
JOIN LuggageTypes AS lt ON lt.Id = l.LuggageTypeId
ORDER BY 
  p.FirstName,
  p.LastName,
  pl.Name,
  f.Origin,
  f.Destination,
  lt.Type

-- Problem 15

SELECT
  FirstName,
  LastName,
  Destination,
  Price
  FROM (SELECT
        FirstName,
        LastName,
        Destination,
        Price,
        DENSE_RANK() OVER (PARTITION BY p.FirstName 
                           ORDER BY t.Price DESC) AS [row] 
        FROM Passengers AS p
        JOIN Tickets AS t ON t.PassengerId = p.Id
        JOIN Flights AS f ON f.Id = t.FlightId) AS t
WHERE [row] = 1
ORDER BY 
  Price DESC,
  FirstName,
  LastName,
  Destination

-- Problem 16

SELECT 
  Destination,
  COUNT(t.Id) AS FilesCount
FROM Flights AS f
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
GROUP BY f.Destination
ORDER BY 
  FilesCount DESC,
  Destination

-- Problem 17

SELECT
  pl.[Name],
  Seats,
  COUNT(p.Id) AS [Passengers Count]
FROM Planes AS pl
LEFT JOIN Flights AS f ON f.PlaneId = pl.Id
LEFT JOIN Tickets AS t ON t.FlightId = f.Id
LEFT JOIN Passengers AS p ON p.Id = t.PassengerId
GROUP BY
  pl.[Name],
  Seats
ORDER BY
  [Passengers Count] DESC,
  pl.[Name],
  Seats

-- Problem 18

GO

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(30), 
                                     @destination VARCHAR(30), 
				     @peopleCount INT) 
RETURNS NVARCHAR(50)
AS 
BEGIN
  IF @peopleCount <= 0
    RETURN 'Invalid people count!'

  DECLARE @flightId INT = (SELECT Id FROM Flights
                           WHERE Origin = @origin
			   AND Destination = @destination)

  IF @flightId IS NULL
    RETURN 'Invalid flight!'

  DECLARE @totalPrice DECIMAL(15,2) = (SELECT Price FROM Tickets AS t
                                       JOIN Flights AS f ON f.Id = t.FlightId
									   WHERE Origin = @origin
						               AND Destination = @destination)

  RETURN 'Total price ' + CAST(@totalPrice * @peopleCount AS VARCHAR)
END

GO

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)

-- Problem 19

GO

CREATE PROC usp_CancelFlights 
AS
UPDATE Flights
SET DepartureTime = NULL, ArrivalTime = NULL
WHERE DepartureTime < ArrivalTime

GO

EXEC usp_CancelFlights
SELECT COUNT(*) 
 FROM Flights 
 WHERE DepartureTime IS NULL

-- Problem 20

CREATE TABLE DeletedPlanes
(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(30),
Seats INT,
[Range] INT
)

GO

CREATE TRIGGER tr_DeletedPlanes ON Planes
FOR DELETE AS
  INSERT INTO DeletedPlanes(Id,[Name], Seats, [Range])
  SELECT d.Id, d.Name, d.Seats, d.Range FROM deleted AS d

GO
