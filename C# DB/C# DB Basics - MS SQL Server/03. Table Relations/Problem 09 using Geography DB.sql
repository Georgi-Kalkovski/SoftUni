-- Problem 09

SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
ON p.MountainID = m.Id
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC
