-- Problem 01

SELECT 
  Count(*) AS Count 
FROM WizzardDeposits

-- Problem 02

SELECT 
  MAX(MagicWandSize) AS LongestMagicWand 
FROM WizzardDeposits

-- Problem 03

SELECT 
  DepositGroup, 
  MAX(MagicWandSize) AS LongestMagicWand 
FROM WizzardDeposits
GROUP BY DepositGroup

-- Problem 04 *

SELECT TOP 2 
  DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

-- Problem 05

SELECT 
  DepositGroup, 
  SUM(DepositAmount) 
FROM WizzardDeposits
GROUP BY DepositGroup

-- Problem 06

SELECT 
  DepositGroup, 
  SUM(DepositAmount) 
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- Problem 07

SELECT 
  DepositGroup, 
  SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- Problem 08

SELECT 
  DepositGroup, 
  MagicWandCreator, 
  MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

-- Problem 09

SELECT 
  AgeGroup, 
  COUNT(Age) AS WizardCount 
FROM 
  (SELECT 
    Age,
    CASE
      WHEN Age >= 0 AND Age <= 10 THEN '[0-10]'
      WHEN Age >= 11 AND Age <= 20 THEN '[11-20]'
      WHEN Age >= 21 AND Age <= 30 THEN '[21-30]'
      WHEN Age >= 31 AND Age <= 40 THEN '[31-40]'
      WHEN Age >= 41 AND Age <= 50 THEN '[41-50]'
      WHEN Age >= 51 AND Age <= 60 THEN '[51-60]'
      ELSE '[61+]'
    END AS AgeGroup
  FROM WizzardDeposits) AS w
GROUP BY AgeGroup

-- Problem 10

SELECT 
  DISTINCT(FirstLetter)
FROM 
  (SELECT FirstName, 
    SUBSTRING(FirstName, 1,1) AS FirstLetter 
  FROM WizzardDeposits
  WHERE DepositGroup = 'Troll Chest') AS w
GROUP BY FirstLetter

-- Problem 11

SELECT 
  w.DepositGroup,
  w.IsDepositExpired,
  AVG(w.DepositInterest) AS AverageInterest
FROM
  (SELECT 
    DepositGroup, 
    IsDepositExpired, 
    DepositInterest 
  FROM WizzardDeposits
  WHERE DepositStartDate > '01-01-1985') AS w
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

-- Problem 12 *

SELECT  
  SUM(w.[Host Wizard Deposit] - w.[Guest Wizard Deposit]) AS SumDifference
FROM
  (SELECT
    FirstName AS [Host Wizard],
    DepositAmount AS [Host Wizard Deposit],
    LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard],
    LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit]
  FROM WizzardDeposits) as w