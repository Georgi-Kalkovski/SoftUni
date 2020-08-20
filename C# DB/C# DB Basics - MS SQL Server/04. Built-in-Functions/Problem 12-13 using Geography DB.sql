-- Problem 12

SELECT CountryName, IsoCode FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

-- Problem 13

SELECT 
PeakName,
RiverName,  
LOWER(SUBSTRING(PeakName,1,LEN(PeakName)-1) + RiverName) AS Mix
FROM 
Peaks,
Rivers
WHERE RIGHT(PeakName,1) = LEFT(RiverName,1)
ORDER BY Mix
