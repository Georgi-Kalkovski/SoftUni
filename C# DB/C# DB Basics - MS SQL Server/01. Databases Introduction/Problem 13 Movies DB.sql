-- Problem 13

CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors
(
Id INT PRIMARY KEY IDENTITY,
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(50)
)

CREATE TABLE Genres 
(
Id INT PRIMARY KEY IDENTITY,
GenreName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(50)
)

CREATE TABLE Categories  
(
Id INT PRIMARY KEY IDENTITY,
CategoryName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(50)
)

CREATE TABLE Movies  
(
Id INT PRIMARY KEY IDENTITY,
Title NVARCHAR(50) NOT NULL,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
CopyrightYear INT NOT NULL,
[Length] TIME NOT NULL,
GenreId INT FOREIGN KEY REFERENCES Genres(Id),
CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
Rating DECIMAL(3,2) NOT NULL,
Notes NVARCHAR(50)
)

INSERT INTO Directors
VALUES ('Purvi Direktor', 'dsfasdgasdgdsa'),
('Vtori Direktor', 'dsfasdgasdgdsa'),
('Treti Direktor', 'dsfasdgasdgdsa'),
('Chetvurti Direktor', 'dsfasdgasdgdsa'),
('Peti Direktor', 'dsfasdgasdgdsa')

INSERT INTO Genres
VALUES ('Purvi Janr', 'dsfasdgasdgdsa'),
('Vtori Janr', 'dsfasdgasdgdsa'),
('Treti Janr', 'dsfasdgasdgdsa'),
('Chetvurti Janr', 'dsfasdgasdgdsa'),
('Peti Janr', 'dsfasdgasdgdsa')

INSERT INTO Categories
VALUES ('Purva Kategoriq', 'dsfasdgasdgdsa'),
('Vtora Kategoriq', 'dsfasdgasdgdsa'),
('Treta Kategoriq', 'dsfasdgasdgdsa'),
('Chetvurta Kategoriq', 'dsfasdgasdgdsa'),
('Peta Kategoriq', 'dsfasdgasdgdsa')

INSERT INTO Movies
VALUES ('Titanic1', 1, 1997, '03:15:00', 2, 3, 7.80, 'dsfasduifgasdufgg'),
('Titanic2', 2, 1997, '03:15:00', 3, 4, 7.80, 'dsfasduifgasdufgg'),
('Titanic3', 3, 1997, '03:15:00', 4, 5, 7.80, 'dsfasduifgasdufgg'),
('Titanic4', 4, 1997, '03:15:00', 5, 1, 7.80, 'dsfasduifgasdufgg'),
('Titanic5', 5, 1997, '03:15:00', 1, 2, 7.80, 'dsfasduifgasdufgg')
