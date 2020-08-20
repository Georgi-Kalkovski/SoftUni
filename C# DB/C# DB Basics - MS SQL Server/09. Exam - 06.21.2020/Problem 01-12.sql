CREATE DATABASE TripService
USE TripService

-- Problem 01

CREATE TABLE Cities
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(20) NOT NULL,
CountryCode VARCHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(30) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
EmployeeCount INT NOT NULL,
BaseRate DECIMAL (15,2)
)

CREATE TABLE Rooms
(
Id INT PRIMARY KEY IDENTITY,
Price DECIMAL (15,2) NOT NULL,
[Type] NVARCHAR(20) NOT NULL,
Beds INT NOT NULL,
HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
Id INT PRIMARY KEY IDENTITY,
RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
BookDate DATETIME NOT NULL,
ArrivalDate DATETIME NOT NULL,
ReturnDate DATETIME NOT NULL,
CancelDate DATETIME,
CONSTRAINT CheckArrivalDate CHECK (ArrivalDate < ReturnDate),
CONSTRAINT CheckBookDate CHECK (BookDate < ArrivalDate)
)

CREATE TABLE Accounts
(
Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(50) NOT NULL,
MiddleName NVARCHAR(20),
LastName NVARCHAR(50) NOT NULL,
CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
BirthDate DATETIME NOT NULL,
Email NVARCHAR(100) NOT NULL,
CONSTRAINT AK_Email UNIQUE(Email)
)

CREATE TABLE AccountsTrips
(
AccountId INT FOREIGN KEY REFERENCES Accounts(Id) NOT NULL,
TripId INT FOREIGN KEY REFERENCES Trips(Id) NOT NULL,
Luggage INT NOT NULL CHECK (Luggage >= 0)
CONSTRAINT PK_AccountsTripsPK PRIMARY KEY (AccountId,TripId)
)

-- Problem 02

INSERT INTO Accounts
VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov',	59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20',	'2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22',	'2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24',	NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01',	'2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29',	NULL)

-- Problem 03 

UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5,7,9)

-- Problem 04

DELETE FROM AccountsTrips
WHERE AccountId = (SELECT Id FROM Accounts WHERE Id = 47)

DELETE FROM Accounts
WHERE Id = 47

-- Problem 05

SELECT 
  FirstName,
  LastName,
  FORMAT(BirthDate,'MM-dd-yyyy') AS BirthDate,
  c.[Name] AS Hometown,
  Email
FROM Accounts AS a
JOIN Cities AS c ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY 
  Hometown

-- Problem 06

SELECT 
  c.[Name],
  COUNT(h.Id) AS Hotels
FROM Cities AS c
JOIN Hotels AS h ON h.CityId = c.Id
GROUP BY 
  c.[Name]
ORDER BY 
  Hotels DESC, 
  c.[Name]

-- Problem 07

SELECT 
  a.Id,
  FirstName + ' ' + LastName AS FullName,
  MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
  MIN(DATEDIFF(DAY, ArrivalDate , ReturnDate)) AS ShortestTrip
FROM Trips AS t
JOIN AccountsTrips AS at ON at.TripId = t.Id
JOIN Accounts AS a ON a.Id = at.AccountId
WHERE MiddleName IS NULL
GROUP BY 
  a.Id,FirstName,
  LastName
ORDER BY 
  LongestTrip DESC,
  ShortestTrip

-- Problem 08

SELECT TOP 10
  c.Id,
  c.[Name],
  c.CountryCode,
  COUNT(a.Id) AS Accounts
FROM Cities AS c
JOIN Accounts AS a ON a.CityId = c.Id
GROUP BY 
  c.Id,
  [Name],
  CountryCode
ORDER BY 
  COUNT(a.Id) DESC

-- Problem 09

SELECT
  a.Id,
  Email,
  c.Name AS City,
  COUNT(c.[Name]) AS Trips
FROM Accounts AS a
JOIN Cities As c On a.CityId=c.Id
JOIN AccountsTrips As at ON at.AccountId=a.Id
JOIN Trips As t ON t.Id=at.TripId
JOIN Rooms As r ON r.Id=t.RoomId
JOIN Hotels As h ON h.Id=r.HotelId
WHERE h.CityId = a.CityId 
      AND t.Id > 1
GROUP BY 
  a.Id,
  Email,
  c.Name
ORDER BY 
  Trips DESC, 
  a.Id

-- Problem 10

SELECT 
  Trips.Id, 
  CASE
    WHEN MiddleName IS NOT NULL THEN FirstName + ' ' + MiddleName + ' ' + LastName
    ELSE FirstName + ' ' + LastName
  END AS FullName, 
  cityOne.[Name] AS [From], 
  cityTwo.[Name] AS [To],
  CASE
    WHEN CancelDate IS NULL THEN CONVERT(NVARCHAR(MAX), DATEDIFF(DAY, Trips.ArrivalDate, Trips.ReturnDate)) + ' days'
    ELSE 'Canceled'
  END AS Duration
FROM AccountsTrips
JOIN Trips ON AccountsTrips.TripId = Trips.Id
JOIN Accounts ON Accounts.Id = AccountsTrips.AccountId
JOIN Cities AS cityOne ON cityOne.Id = Accounts.CityId
JOIN Rooms ON Rooms.Id = Trips.RoomId
JOIN Hotels ON Hotels.Id = Rooms.HotelId
JOIN Cities AS cityTwo ON cityTwo.Id = Hotels.CityId
ORDER BY 
  FullName, 
  Trips.Id

-- Problem 11

GO

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(200)
AS
BEGIN
    DECLARE @hotelBaseRate DECIMAL(15,2)
      SET @hotelBaseRate = (SELECT Hotels.BaseRate 
	                    FROM Hotels 
	  		    WHERE Hotels.Id = @HotelId)
 
    DECLARE @roomId INT
      SET @roomId = (SELECT TOP(1) tempDB.roomId
                     FROM(SELECT 
	  	            Rooms.Id AS roomId, 
	  	            Price,
			    [Type],
	  	            Beds,
			    ArrivalDate, 
	  	            ReturnDate, 
	  	            CancelDate
                          FROM Rooms
                          JOIN Hotels ON Hotels.Id = Rooms.HotelId
                          JOIN Trips ON Trips.RoomId = Rooms.Id
                          WHERE Hotels.Id = @HotelId 
	  			AND Rooms.Beds >= @People ) as tempDB
                     WHERE NOT EXISTS (SELECT tempDBTwo.roomId
                                       FROM(SELECT 
	  				      RoomsTwo.Id AS roomId,
	  				      Price,
	  				      [Type],
	  				      Beds, 
	  				      ArrivalDate, 
	  				      ReturnDate, 
	  				      CancelDate
                                            FROM Rooms as RoomsTwo
                                            JOIN Hotels AS HotelsTwo ON HotelsTwo.Id = RoomsTwo.HotelId
                                            JOIN Trips AS TripsTwo ON TripsTwo.RoomId = RoomsTwo.Id
                                            WHERE HotelsTwo.Id = @HotelId 
	  					  AND RoomsTwo.Beds >= @People ) as tempDBTwo
                                       WHERE (CancelDate IS NULL 
	  				      AND @Date > ArrivalDate 
	  				      AND @Date < ReturnDate))
                                       ORDER BY tempDB.Price DESC)
 
    IF(@roomId IS NULL) 
      RETURN 'No rooms available'
 
    DECLARE @highestPrice DECIMAL(15,2)
      SET @highestPrice = (SELECT Rooms.Price 
	                   FROM Rooms 
			   WHERE Rooms.Id = @roomId)
 
    DECLARE @roomType NVARCHAR(200)
      SET @roomType = (SELECT Rooms.[Type] 
	               FROM Rooms 
		       WHERE Rooms.Id = @roomId);
 
    DECLARE @roomBeds INT
      SET @roomBeds = (SELECT Rooms.Beds 
	               FROM Rooms 
		       WHERE Rooms.Id = @roomId)
 
    DECLARE @totalPrice DECIMAL(15,2)  
      SET @totalPrice = (@hotelBaseRate + @highestPrice) * @People
    RETURN FORMATMESSAGE('Room %i: %s (%i beds) - $%s', @roomId, @roomType, @roomBeds, CONVERT(NVARCHAR(100),@totalPrice))
END

GO
SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)


-- Problem 12

GO

CREATE PROCEDURE usp_SwitchRoom(@TripID INT, @TargetRoomID INT)
AS
BEGIN
    DECLARE @HotelID INT, @HotelID2 INT
    SELECT @HotelID = HotelID 
    FROM trips AS t
    JOIN rooms AS r ON r.id = t.roomid
    JOIN hotels AS h ON h.id = r.hotelid
    WHERE t.id = @TripID
 
    SELECT @HotelID2 = hotelID 
    FROM rooms
    WHERE id = @TargetRoomID

    DECLARE @TripAccounts INT, @BedsCounts INT
    SELECT @TripAccounts = COUNT(*) 
    FROM AccountsTrips
    WHERE tripID = @TripID
 
    SELECT @BedsCounts =  Beds 
    FROM rooms
    WHERE id = @TargetRoomID
   
    IF @HotelID != @HotelID2
    BEGIN
      RAISERROR('Target room is in another hotel!',16,1)
    END

    ELSE
    BEGIN

        IF @TripAccounts > @BedsCounts
        BEGIN
          RAISERROR('Not enough beds in target room!',16,1)
        END

        ELSE
        BEGIN
          UPDATE trips 
	  SET roomID = @TargetRoomID 
	  WHERE id = @TripID
        END
    END
END

GO

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8
