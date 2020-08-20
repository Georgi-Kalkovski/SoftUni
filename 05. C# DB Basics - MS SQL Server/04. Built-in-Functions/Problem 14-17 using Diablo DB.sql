-- Problem 14

SELECT TOP(50) 
[Name],
CONVERT(DATE,[Start]) AS [Start] 
FROM Games
WHERE YEAR([Start]) IN (2011,2012)
ORDER BY [Start],[Name]

-- Problem 15

SELECT 
Username, 
SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider] 
FROM Users
ORDER BY [Email Provider],Username

-- Problem 16

SELECT 
u.Username, 
u.IpAddress AS 'IP Address' 
FROM Users AS u
WHERE IpAddress LIKE ('___.1%.%.___')
ORDER BY Username

-- Problem 17

SELECT 
[Name] AS Game,
CASE
   WHEN DATEPART(HOUR, [START]) BETWEEN 0 AND 11 THEN 'Morning'
   WHEN DATEPART(HOUR, [START]) BETWEEN 12 AND 17 THEN 'Afternoon'
   WHEN DATEPART(HOUR, [START]) BETWEEN 18 AND 23 THEN 'Evening'
END AS [Part of the Day],
CASE
   WHEN Duration BETWEEN 0 AND 3 THEN 'Extra Short'
   WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
   WHEN Duration > 6 THEN 'Long'
   ELSE 'Extra Long'
END AS Duration
FROM Games
ORDER BY [Name], Duration, [Part of the Day] 

