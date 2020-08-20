-- Problem 01

CREATE DATABASE Minions
USE Minions

-- Problem 02

CREATE TABLE Minions
(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL,
AGE INT
)

CREATE TABLE Towns
(
Id INT PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

-- Problem 03

ALTER TABLE Minions
ADD TownId INT FOREIGN KEY REFERENCES Towns(Id)

-- Problem 04

INSERT INTO Towns
VALUES (1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions
VALUES (1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

-- Problem 05

TRUNCATE TABLE Minions

-- Problem 06

DROP TABLE Minions
DROP TABLE Towns

-- Problem 07

CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture NVARCHAR(MAX),
Height DECIMAL(3,2),
[Weight] DECIMAL(4,2),
Gender CHAR(1) NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People
VALUES ('Gosho', 'fasdfahsgdfusd', 1.70,65.50, 'm', '1992-04-30', 'fsdafjasdf'),
('Gosho', 'fasdfahsgdfusd', 1.70,65.50, 'm', '1992-04-30', 'fsdafjasdf'),
('Gosho', 'fasdfahsgdfusd', 1.70,65.50, 'm', '1992-04-30', 'fsdafjasdf'),
('Gosho', 'fasdfahsgdfusd', 1.70,65.50, 'm', '1992-04-30', 'fsdafjasdf'),
('Gosho', 'fasdfahsgdfusd', 1.70,65.50, 'm', '1992-04-30', 'fsdafjasdf')

-- Problem 08

CREATE TABLE Users
(
Id INT PRIMARY KEY IDENTITY,
Username NVARCHAR(30) NOT NULL,
[Password] NVARCHAR(26) NOT NULL,
ProfilePicture NVARCHAR(MAX),
LastLoginTime DATETIME2,
Biography BIT
)

INSERT INTO Users
VALUES ('Gosho', 'parolka','dgdggdfsdfg','01-01-1000', 0),
('Gosho', 'parolka','dgdggdfsdfg','01-01-1000', 0),
('Gosho', 'parolka','dgdggdfsdfg','01-01-1000', 0),
('Gosho', 'parolka','dgdggdfsdfg','01-01-1000', 0),
('Gosho', 'parolka','dgdggdfsdfg','01-01-1000', 0)

-- Problem 09

ALTER TABLE Users
DROP PK__Users__3214EC0782CA3FE3

ALTER TABLE Users
ADD CONSTRAINT PK__Users__3214EC0782CA3FE3 PRIMARY KEY (Id,Username);

-- Problem 10

ALTER TABLE Users
ADD CONSTRAINT CHK_Password CHECK (LEN([Password])>=5);

-- Problem 11

UPDATE Users SET LastLoginTime = GETDATE()

-- Problem 12

ALTER TABLE Users
DROP PK__Users__3214EC0782CA3FE3

ALTER TABLE Users
ADD CONSTRAINT PK__Users__3214EC0782CA3FE3 PRIMARY KEY (Id) ;

ALTER TABLE Users
ADD CONSTRAINT CHK_Usernames CHECK (LEN(Username) >= 3)
