-- Problem 09

CREATE PROC usp_GetHoldersFullName 
AS
  SELECT (FirstName + ' ' + LastName) AS [Full Name] 
  FROM AccountHolders
GO

-- Problem 10

CREATE PROC usp_GetHoldersWithBalanceHigherThan @Number DECIMAL(18,4)
AS
  SELECT 
    ah.FirstName, 
    ah.LastName 
  FROM AccountHolders AS ah
  JOIN Accounts AS a 
    ON a.AccountHolderId = ah.Id
  GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
  HAVING SUM(a.Balance) > @Number
  ORDER BY
    ah.FirstName,
    ah.LastName

EXEC usp_GetHoldersWithBalanceHigherThan @Number = 50000
GO

-- Problem 11

CREATE FUNCTION ufn_CalculateFutureValue (@initialSum DECIMAL(18,4), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
  DECLARE @result DECIMAL(18,4)
    SET @result = @initialSum * POWER((1 + @yearlyInterestRate), @numberOfYears)
  RETURN @result
END
GO

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)
GO

-- Problem 12

CREATE PROC usp_CalculateFutureValueForAccount (@accountId INT, @yearlyInterestRate FLOAT)
AS
  SELECT  
    ah.Id AS [Account Id],
    ah.FirstName AS [First Name],
    ah.LastName AS [Last Name],
	a.Balance AS [Current Balance],
	dbo.ufn_CalculateFutureValue(a.Balance, @yearlyInterestRate, 5) AS [Balance in 5 years]
  FROM AccountHolders AS ah
  JOIN Accounts AS a
    ON a.Id = ah.Id
  WHERE ah.Id = @accountId
GO

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1
GO
