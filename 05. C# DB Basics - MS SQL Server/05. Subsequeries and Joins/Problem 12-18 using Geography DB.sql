
-- Problem 12

SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation 
FROM MountainsCountries AS mc
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON p.MountainId = mc.MountainId
WHERE p.Elevation > 2835 AND mc.CountryCode = 'BG'
ORDER BY p.Elevation DESC

-- Problem 13

SELECT mc.CountryCode, COUNT(*) AS MountainRanges
FROM MountainsCountries AS mc
JOIN Countries AS c ON c.CountryCode = mc.CountryCode
WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY  mc.CountryCode

-- Проблем 14

SELECT TOP 5 c.CountryName AS CountryName, r.RiverName FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY CountryName

-- Problem 15

SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage
FROM (SELECT 
      c.ContinentCode,
	  c.CurrencyCode,
	  COUNT(c.CurrencyCode) AS [CurrencyUsage],
	  DENSE_RANK() OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS CurrencyRank
	  FROM Countries AS c
	  GROUP BY c.ContinentCode,c.CurrencyCode
	  HAVING COUNT(c.CurrencyCode) > 1) AS k
WHERE k.CurrencyRank = 1
ORDER BY k.ContinentCode

-- Problem 16

SELECT COUNT(*) AS [Count] 
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
WHERE mc.MountainId IS NULL

-- Problem 17

SELECT TOP(5) 
  c.CountryName, 
  MAX(p.Elevation) AS HighestPeakElevation, 
  MAX(r.Length) AS LongestRiverLength 
FROM Countries AS c
JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m ON m.Id = mc.MountainId
JOIN Peaks AS p ON p.MountainId = m.Id
JOIN CountriesRivers AS cr ON cr.CountryCode = c.CountryCode
JOIN Rivers AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY 
   HighestPeakElevation DESC, 
   LongestRiverLength DESC, 
   CountryName

   -- Problem 18 (Wrong Solution)

SELECT TOP 5
  c.CountryName AS Country, 
  ISNULL(p.PeakName, 'no highest peak') AS [Highest Peak Name],
  ISNULL(p.Elevation, 0) AS [Highest Peak Elevation], 
  ISNULL(m.MountainRange, '(no mountain)') AS Mountain
  FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
GROUP BY CountryName, MountainRange, PeakName, Elevation
ORDER BY Country, [Highest Peak Name]

-- Problem 18 (Simple Solution)

SELECT TOP(5) e.CountryName,
CASE
    WHEN p.PeakName IS NULL THEN '(no highest peak)'
    ELSE p.PeakName
END AS [Highest Peak Name],
CASE   
    WHEN p.Elevation IS NULL THEN '0'
    ELSE p.Elevation
END AS [Highest Peak Elevation],
CASE
    WHEN m.MountainRange IS NULL THEN '(no mountain)'
    ELSE m.MountainRange
END AS [Mountain]
FROM Countries AS e
LEFT JOIN MountainsCountries AS mc ON e.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p ON p.MountainId = m.Id
ORDER BY CountryName ASC, [Highest Peak Name] ASC
