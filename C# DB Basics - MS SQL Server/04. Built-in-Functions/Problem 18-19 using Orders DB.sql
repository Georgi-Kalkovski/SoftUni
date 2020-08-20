
-- Problem 18

SELECT 
ProductName, 
OrderDate,
DATEADD(DAY, 3, OrderDate) AS [Pay Due],
DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

-- Problem 19

CREATE TABLE People
(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
[Birthdate] DATETIME2 NOT NULL
)

INSERT INTO People
VALUES
('Victor', '2000-12-07'),
('Steven','1992-09-10'),
('Stephen','1910-09-19'),
('John','2010-01-06')

SELECT
[Name],
  DATEDIFF(year, [Birthdate], GETDATE()) AS [Age in Years],
  DATEDIFF(month, [Birthdate], GETDATE()) AS [Age in Months],
  DATEDIFF(day, [Birthdate], GETDATE()) AS [Age in Days],
  DATEDIFF(minute, [Birthdate], GETDATE()) AS [Age in Minutes]
FROM People
